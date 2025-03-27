using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ProjApp.Common;

namespace ProjApp
{
    public partial class NetworkForm : Form
    {
        private bool isRunning = true; //用于标识本界面程序是否运行的状态
        private List<byte> buffer = new List<byte>(); //用于存放串口接收缓冲区数据     
        private Label showLabel; //用于显示信息的标签
        private int coNum = 0; //用于统计网络内协调器节点数量
        private int roNum = 0; //用于统计网络内路由器节点数量
        private int edNum = 0; //用于统计网络内终端节点数量
        //用于存储已创建节点的信息(key->name, value->NodeContorl)
        private Dictionary<string, NodeControl> nodes = new Dictionary<string, NodeControl>(); 
        public NetworkForm() //初始化构造器
        {
            InitializeComponent();   
        }
        /* “ZigBee网络”界面初次加载时的事件处理函数 */
        private void NetworkForm_Load(object sender, EventArgs e)
        {
            inspectTimer1.Start(); //启动inspectTimer1定时器
            inspectTimer2.Start(); //启动inspectTimer2定时器
            //添加节点类型选项
            string[] type = { "协调器", "路由器", "终端" };
            devTypeBox.Items.AddRange(type);           
            //添加波特率选项
            string[] baud = { "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            baudBox.Items.AddRange(baud); //加入波特率选择框
        }
        /* “连接网络”按钮被点击时的事件处理函数 */
        private void LinkNetBtn_Click(object sender, EventArgs e)
        {
            if (!serialPort3.IsOpen) //串口未打开
            {
                string[] ports = SerialPort.GetPortNames(); //获取可用串口名
                if (ports.Length > 0)
                {
                    serialPort3.PortName = ports[0]; //使用第一个可用的串口
                    //订阅串口接收事件并打开串口
                    serialPort3.DataReceived += new SerialDataReceivedEventHandler(SerialPort3_DataReceived);
                    serialPort3.Open(); //默认参数，无需更改：波特率38400、无校验、数据位8、停止位1                  
                    linkNetBtn.Text = "断开网络"; //"连接网络"->"断开网络"，代表按钮功能被切换
                    linkNetBtn.BackColor = Color.Tomato; //按钮颜色改变便于区分
                }
                else
                    MessageBox.Show("没有找到可用网络");
            }
            else
            {
                //取消订阅串口接收事件并关闭串口
                serialPort3.DataReceived -= new SerialDataReceivedEventHandler(SerialPort3_DataReceived);
                serialPort3.Close();
                linkNetBtn.Text = "连接网络"; //"断开网络"->"连接网络"，代表按钮功能被切换
                linkNetBtn.BackColor = Color.DarkSeaGreen; //按钮颜色改变便于区分
            }
        }
        /* 界面内的串口3接收到数据时的事件处理函数 */
        private void SerialPort3_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //检查标志是否仍在运行，为了避免关闭程序时串口缓冲区仍有数据待读取，根据标志位判断是否停止该线程
            if (!isRunning)
            {
                return; //如果标志为false，则停止、退出线程
            }
            int size = serialPort3.BytesToRead; //获取接收缓冲区字节大小
            byte[] tempBuf = new byte[size]; //声明一个数组临时存放从缓冲区读出的数据
            serialPort3.Read(tempBuf, 0, size); //串口读取指定大小的数据到数组中
            /*将数组中的数据放入定义的缓冲区列表，由于串口在接收区读取数据并处理的同时仍会不断接收到数据，
             * 这容易导致部分数据处理不及时而被挤占忽略，因此先读出来保存到另一个缓冲区再处理就可以避免*/
            buffer.AddRange(tempBuf); 
            this.Invoke((EventHandler)(delegate
            {
                while (buffer.Count >= 6) //确保缓冲区中有足够的数据处理，处理函数以6个字节为单位进行处理
                {
                    byte[] readPkt = buffer.GetRange(0, 6).ToArray(); //获取前6个字节的数据包
                    buffer.RemoveRange(0, 6); //从缓冲区中移除已处理的数据
                    if (readPkt[0] == 0xCA) //判断帧头
                    {
                        ProcessTheData(readPkt); //处理收到的数据
                        serialPort3.DiscardInBuffer(); //清空接收缓冲区
                    }
                    else //帧头不符合则返回退出处理
                    {
                        return;
                    }
                }
            }));
        }
        /* InspectTimer1定时器工作函数,显示当前的系统时间 */
        private void InspectTimer1_Tick(object sender, EventArgs e)
        {
            //在下方状态栏处显示以下信息
            toolStripStatusLabel1.Text = "系统时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        /* InspectTimer2定时器工作函数,定时5s检查并删除网络中离线的节点 */
        private void InspectTimer2_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now; //获取当前时间戳
            List<string> nodesToRemove = new List<string>(); //用于存放待删除节点的列表
            foreach (var node in nodes.Values) //遍历字典中的所有节点
            {
                if ((now - node.LastUpdated).TotalSeconds > 7) //若有节点超过15秒没有更新时间戳则放入待删除列表
                {
                    nodesToRemove.Add(node.Name);
                }
            }
            foreach (var nodeName in nodesToRemove) //遍历列表中的所有节点，逐一删除
            {
                RemoveNode(nodeName);
            }
        }
        private void NetTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (var nodes in nodes.Values)
            {
                nodes.SetSelected(false);
            }
            // 获取当前选中的树节点的名称
            string selectedNodeName = e.Node.Text.Substring(e.Node.Text.Length - 4); // 假设节点名称为"路由器xxxx"或"终端xxxx"
            // 设置对应节点控件的选中状态
            if (nodes.TryGetValue(selectedNodeName, out NodeControl node))
            {
                node.SetSelected(true);
            }
        }
        /* "节点类型"选择框有动作时的处理函数 */
        private void DevTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (devTypeBox.SelectedIndex)
            {
                //执行其中一个，将对应命令值转换为字节数据并添加到数据包第2位
                case 0: //协调器 字节1代表类型编号
                    Array.Copy(StringToHexByte("00"), 0, setBuf, 1, 1); break;
                case 1: //路由器
                    Array.Copy(StringToHexByte("01"), 0, setBuf, 1, 1); break;
                case 2: //终端
                    Array.Copy(StringToHexByte("02"), 0, setBuf, 1, 1); break;
            }
        }
        /* "波特率"选择框有动作时的处理函数 */
        private void BaudBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (baudBox.SelectedIndex)
            {
                case 0: //2400 
                    Array.Copy(StringToHexByte("00"), 0, setBuf, 2, 1); break;
                case 1: //4800
                    Array.Copy(StringToHexByte("01"), 0, setBuf, 2, 1); break;
                case 2: //9600
                    Array.Copy(StringToHexByte("02"), 0, setBuf, 2, 1); break;
                case 3: //19200
                    Array.Copy(StringToHexByte("03"), 0, setBuf, 2, 1); break;
                case 4: //38400 
                    Array.Copy(StringToHexByte("04"), 0, setBuf, 2, 1); break;
                case 5: //57600
                    Array.Copy(StringToHexByte("05"), 0, setBuf, 2, 1); break;
                case 6: //115200
                    Array.Copy(StringToHexByte("06"), 0, setBuf, 2, 1); break;
            }
        }

        private void SetButton_Click(object sender, EventArgs e)
        {
            if (setBuf[0] != 0xEA) //防误触，如果帧头不是EA就不是配置操作，直接返回不作处理
            {
                return;
            }
            try
            {
                serialPort3.Write(setBuf, 0, 5); //串口发送
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "失败，请重试！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /* “ZigBee网络”界面被关闭的事件处理函数 */
        private void NetworkForm_FormClosed(object sender, FormClosedEventArgs e)
        {         
            isRunning = false; //设为false，通知接收线程停止
            //关闭界面时如果串口仍打开，则强制关闭，避免下次打开时出错
            if (serialPort3.IsOpen)
            {
                //取消订阅串口接收事件
                serialPort3.DataReceived -= new SerialDataReceivedEventHandler(SerialPort3_DataReceived);                   
                serialPort3.Close(); //关闭串口
            }
            //关闭定时器
            inspectTimer1.Stop();
            inspectTimer2.Stop();
        }
        /* 串口接收函数中调用的对数据进行分类处理的函数 */
        private void ProcessTheData(byte[] pkt)
        {
            string nName = null; //创建节点函数所需给参数的初始值
            string nType = null;
            string nFather = null;
            int nSize = 0;
            Color nColor = Color.White;
            nName = pkt[2].ToString("X2") + pkt[3].ToString("X2"); //先获取并判断是否有同名节点，有就跳过处理
            if (nodes.ContainsKey(nName)) //如果已经创建了该节点，就只更新最后接收时间
            {              
                nodes[nName].LastUpdated = DateTime.Now;
                if(nName == "0000") //判断这个键是否是0000，是则该节点是协调器，还需更新网络号信息
                {
                    idLabel.Text = nodes["0000"].NodeFather;//协调器的父节点属性中存放的是网络号
                }
            }
            else //如果没有同名的节点存在于字典列表中，则允许创建新节点
            {
                switch (pkt[1]){
                case 0x00: //协调器节点，给定大小、颜色并计数
                    { 
                        nType = "C"; nSize = 45; nColor = Color.Orange; coNum++; coCLabel.Text = coNum.ToString(); 
                    }   break;
                case 0x01: //路由器节点，给定大小、颜色并计数
                        { 
                        nType = "R"; nSize = 40; nColor = Color.CadetBlue; roNum++; roCLabel.Text = roNum.ToString();
                        }   break;
                case 0x02: //终端节点，给定大小、颜色并计数
                        { 
                        nType = "E"; nSize = 40; nColor = Color.RosyBrown; edNum++; edCLabel.Text = edNum.ToString();
                        }   break;
                }     
                nFather = pkt[4].ToString("X2") + pkt[5].ToString("X2");           
                CreateNode(nName, nType, nSize, nColor, 30+nodes.Count*2, nFather); //创建节点
                countCLabel.Text = (coNum + roNum + edNum).ToString(); //统计总节点数              
            }             
        }
        /* 用于创建一个NodeControl节点控件的函数 */
        private void CreateNode(string name, string text, int size, Color color, int px, string father)
        {
            //定义一个NodeContorl控件,并初始化相关属性
            NodeControl newNode = new NodeControl()
            {
                Name = name, //设置节点控件的名称
                NodeText = text, //设置节点控件的文本内容
                NodeSize = size,  //设置节点控件的大小
                FillColor = color, //设置节点控件的填充颜色
                Location = new Point(px, 100), //设置节点控件的初始位置
                NodeFather = father, //填充节点父端的信息
                LastUpdated = DateTime.Now //获取时间戳
            };
            //将节点控件添加到showPanel容器中
            showPanel.Controls.Add(newNode);
            //将新创建的节点添加到字典中，键是节点名称name，值是节点对象NodeControl
            nodes[name] = newNode;
            //订阅鼠标进入/鼠标离开事件
            newNode.MouseEnter += NewNode_MouseEnter;
            newNode.MouseLeave += NewNode_MouseLeave;
            newNode.ContextMenuStrip.Items["MenuItem1"].Click += MenuItem1_Click;
            //统计总节点数并显示
            countCLabel.Text = nodes.Count.ToString();
            showPanel.Invalidate(); //触发重绘以更新连线
            UpdateTreeView(); //更新拓扑信息的菜单显示
        }
        /* 用于删除一个NodeControl节点控件的函数 */
        private void RemoveNode(string nodeName)
        {
            if (nodes.ContainsKey(nodeName)) //判断待删除节点是否存在于字典中
            {
                NodeControl node = nodes[nodeName]; //获取待删除节点对象
                showPanel.Controls.Remove(node); //从容器中移除该节点控件
                nodes.Remove(nodeName); //从字典中移除该键值对
                node.Dispose(); //释放资源，清理控件
                showPanel.Invalidate(); //触发重绘以更新连线                                                                 
                UpdateTreeView(); //重绘并更新拓扑信息菜单
                countCLabel.Text = nodes.Count.ToString(); //更新总节点数
            }
        }
        /* 节点控件订阅的鼠标进入节点控件时触发的处理函数 */
        private void NewNode_MouseEnter(object sender, EventArgs e)
        {
            NodeControl node = (NodeControl)sender; //获取触发事件的节点控件
            //创建标签控件并设置属性
            showLabel = new Label();
            showLabel.Font = new Font("宋体", 14.5f);
            showLabel.ForeColor = Color.Black;
            showLabel.Text = node.Name; //显示节点名称
            //设置标签控件位置为当前指向的控件位置上方
            int showLabelX = node.Location.X; //与当前节点控件在X方向上位置相同
            int showLabelY = node.Location.Y - showLabel.Height; //与当前节点控件在Y方向上偏移5个像素点
            showLabel.Location = new Point(showLabelX, showLabelY); //应用设定的位置
            //将标签控件添加到showPanel中
            showPanel.Controls.Add(showLabel);
        }
        /* 节点控件订阅的鼠标离开节点控件时触发的处理函数 */
        private void NewNode_MouseLeave(object sender, EventArgs e)
        {           
            if (showLabel != null) //如果控件存在
            {
                showPanel.Controls.Remove(showLabel); //移除该控件
                showLabel.Dispose(); //释放资源
                showLabel = null; //设置标志：控件不存在
            }
        }
        /* 节点控件订阅的鼠标点击“远程配置”菜单按钮时触发的处理函数 */
        private void MenuItem1_Click(object sender, EventArgs e)
        {
            // 获取触发事件的ToolStripMenuItem
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            // 获取MenuItem所属的ContextMenuStrip
            ContextMenuStrip contextMenu = menuItem?.Owner as ContextMenuStrip;
            // 获取ContextMenuStrip所属的NodeControl
            NodeControl node = contextMenu?.SourceControl as NodeControl;
            //添加帧头，用于在Zsatck协议栈中校验
            Array.Copy(StringToHexByte("EA"), 0, setBuf, 0, 1);
            //添加触发该事件的节点短地址，用于向指定节点发送配置数据        
            Array.Copy(StringToHexByte(node.Name), 0, setBuf, 3, 2);
            //指示当前配置的节点是哪个
            tarLabel.Text = node.Name;
        }
        /* showPanel的绘制函数，用于绘制各节点之间的连线 */
        private void ShowPanel_Paint(object sender, PaintEventArgs e)
        {
            //Graphics对象提供了GDI绘图的各种方法，将e.Graphics返回的Graphics对象赋值给g，方便操作
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; //启用抗锯齿
            //遍历字典中所有节点
            foreach (var node in nodes.Values)
            {
                //判断节点的父节点属性是否为空，并且父节点是否存在于nodes字典中(判断节点名称name)
                if (!string.IsNullOrEmpty(node.NodeFather) && nodes.ContainsKey(node.NodeFather))
                {
                    NodeControl parentNode = nodes[node.NodeFather]; //从字典中获取父节点对象
                    //计算当前节点的中心点坐标
                    Point startPoint = new Point(node.Location.X + node.Width / 2, node.Location.Y + node.Height / 2);
                    //计算当前节点的父节点中心点坐标
                    Point endPoint = new Point(parentNode.Location.X + parentNode.Width / 2, parentNode.Location.Y + parentNode.Height / 2);
                    //创建一个黑色的笔，宽度为2
                    using (Pen pen = new Pen(Color.Black, 2))
                    {
                        g.DrawLine(pen, startPoint, endPoint); //绘制连线
                    }
                }
            }
        }
        private void UpdateTreeView()
        {
            netTreeView.Nodes.Clear(); //清空树节点
            TreeNode rootNode = netTreeView.Nodes.Add("协调器0000"); //创建根节点(固定且只可能是协调器节点，短地址为0000)
            //维护一个字典用于存储每个节点对应的树节点，该字典的键是节点名称，值是节点对应的树节点对象
            Dictionary<string, TreeNode> treeNodeDict = new Dictionary<string, TreeNode>
            {
                { "0000", rootNode } //将每个节点名(字符串)映射到其对应的树节点对象
            };
            foreach (var node in nodes.Values) //遍历存储已创建节点字典中的所有节点
            {
                if (node.Name != "0000") //如果节点名不是0000，即不是根节点
                {
                    if (!string.IsNullOrEmpty(node.NodeFather) && nodes.ContainsKey(node.NodeFather))
                    {
                        //根据节点的父节点属性，把父节点作为树节点的上一级节点
                        if (treeNodeDict.TryGetValue(node.NodeFather, out TreeNode parentNode))
                        {
                            //判断当前节点的类型，如果文本中是字符R则为路由器，反之为终端
                            string nodeType = node.NodeText == "R" ? "路由器" : "终端";
                            string nodeName = nodeType + node.Name; //树节点的名称为类型+短地址(名称)
                            TreeNode childNode = parentNode.Nodes.Add(nodeName); //在上一级节点下创建子节点
                            //将树节点添加到treeNodeDict字典中
                            treeNodeDict[node.Name] = childNode;
                        }
                    }
                }
            }
            netTreeView.ExpandAll(); //默认展开所有树节点
        }
    }
}

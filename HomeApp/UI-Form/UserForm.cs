using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Windows.Forms;
using MyApp.My_Class;
using static MyApp.Common;
using MyApp.UI_Form;
using DocumentFormat.OpenXml.EMMA;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace MyApp
{
    public partial class UserForm : Form
    {      
        private SQLiteDB sqliteDB; //保存SQLiteDB的实例
        private readonly MenuForm menuForm; //保存MenuForm的实例
        private AiHelper aiService; //保存TomatoHelper的实例
        private bool isRunning = true; //用于标识本界面程序是否运行的状态   
        private Label showLabel; //用于显示网络节点弹窗信息的标签
        private float[] dataArray = new float[6]; //保存用于算法评价的各传感器数据（空气温度/空气湿度/土壤水分/土壤PH/光照度/CO2浓度）
        private string[] dataStr = new string[6]; //保存用于AI评价的各传感器数据（空气温度/空气湿度/土壤水分/土壤PH/光照度/CO2浓度）
        //用于存储已创建节点的信息(key->name, value->NodeContorl)
        private Dictionary<string, NodeControl> nodes = new Dictionary<string, NodeControl>();
        //用于存储已创建的显示节点对应传感器数据的label控件与节点控件匹配的信息(key->NodeContorl, value->Label)
        private Dictionary<NodeControl, Label> nodeLabelMap = new Dictionary<NodeControl, Label>();
        public UserForm(MenuForm menuForm)//有参构造，参数为MenuForm的实例
        {
            this.menuForm = menuForm; //将传递过来的实例用私有字段存储
            InitializeComponent(); //初始化组件
        }
        /* “主界面”界面加载时的事件处理函数 */
        private void UserForm_Load(object sender, EventArgs e)
        {
            //开启时间显示定时器
            showTimer.Start();
            //创建SQLiteDB的实例并打开与数据库的连接
            sqliteDB = new SQLiteDB();
            sqliteDB.ConnectToDataBase();
            //添加远程配置的节点类型选项
            string[] type = { "协调器", "路由器", "终端" };
            devTypeBox.Items.AddRange(type);
            //添加远程配置的波特率选项
            string[] baud = { "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            baudBox.Items.AddRange(baud); //加入波特率选择框
            //创建Ai助手类实例
            aiService = new AiHelper();
        }
        /* 向AI提问后确认发送的按钮被点击时的处理函数 */

        /* "连接网络"按钮被点击时的处理函数，即打开串口 */
        private void LinkUButton_Click(object sender, EventArgs e)
        {
            if (!UserPort.IsOpen) //串口未打开
            {
                string[] ports = SerialPort.GetPortNames(); //获取可用串口名
                if (ports.Length > 0)
                {
                    UserPort.PortName = ports[0]; //使用第一个可用的串口
                    //订阅串口接收事件并打开串口
                    UserPort.DataReceived += new SerialDataReceivedEventHandler(UserPort_DataReceived);
                    UserPort.Open(); //默认参数，无需更改：波特率115200、无校验、数据位8、停止位1                                    
                    inspectTimer.Start(); //开启ZigBee节点刷新定时器
                    triggerTimer.Start(); //开启评价系统触发定时器
                    linkUButton.Text = "断开网络"; //"连接网络"->"断开网络"，代表按钮功能被切换
                    linkUButton.BackColor = Color.Tomato; //按钮颜色改变便于区分
                }
                else
                    MessageBox.Show("没有找到可用网络");
            }
            else
            {
                //取消订阅串口接收事件并关闭串口
                UserPort.DataReceived -= new SerialDataReceivedEventHandler(UserPort_DataReceived);
                UserPort.Close(); //关闭串口
                inspectTimer.Stop(); //停止ZigBee节点刷新定时器
                triggerTimer.Stop(); //停止评价系统触发定时器
                linkUButton.Text = "连接网络"; //"断开网络"->"连接网络"，代表按钮功能被切换
                linkUButton.BackColor = Color.DarkSeaGreen; //按钮颜色改变便于区分
            }
        }
        /* UserPort串口控件接收到数据时的处理函数 */
        private void UserPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {        
            //检查标志是否仍在运行，为了避免关闭程序时串口缓冲区仍有数据待读取，根据标志位判断是否停止该线程
            if (!isRunning)
            {
                return; //如果标志为false，则停止、退出线程
            }
            string strBuf = UserPort.ReadExisting(); //读取串口缓冲区的所有数据
            if (string.IsNullOrEmpty(strBuf)) //检查strBuf是否为空
            {
                return; //如果为空，直接退出
            }
            this.Invoke((EventHandler)(delegate
            {
                //根据接收到的不同类型数据，分别处理
                if (strBuf[0] == 'C') //以'C'开头则是接收的节点信息的数据
                {
                    if (strBuf.Length >= 17) //Hex数据包的长度是6个字节＋空格（即17个字符）
                    {
                        //如果有多组数据，以6个字节为单位来处理
                        string hexSegment = strBuf.Substring(0, 17); //Hex数据包的长度是6个字节＋空格（即17个字符）                                                                   
                        //将字符串转换为字节数组来处理Hex数据
                        byte[] hexData = StringToHexByte(hexSegment);
                        ProcessHexData(hexData);
                        strBuf = strBuf.Substring(17); //清除缓冲区中已处理的数据
                    }                   
                }
                else if (strBuf[0] == 'D') //以'D'开头则是接收的传感器采集的数据
                {
                    ProcessStrData(strBuf); //处理字符串型数据
                    UserPort.DiscardInBuffer(); //清空接收缓冲区
                }
                else
                {
                    UserPort.DiscardInBuffer(); //清空接收缓冲区
                    return;
                }                  
            }));
        }
        /* 传感器数据改变时，采用json格式把数据发给网关，最后通过4G模块发给云平台 */
        private void AirTempLabel_TextChanged(object sender, EventArgs e)
        {
            string jsonStr = "{\"id\":\"1\",\"params\":{\"AirT\":{\"value\":\"" + airTempLabel.Text + "\"}}}";
            UserPort.Write(jsonStr);
        }
        private void AirHumiLabel_TextChanged(object sender, EventArgs e)
        {
            string jsonStr = "{\"id\":\"2\",\"params\":{\"AirH\":{\"value\":\"" + airHumiLabel.Text + "\"}}}";
            UserPort.Write(jsonStr);
        }
        private void HumiLabel_TextChanged(object sender, EventArgs e)
        {
            string jsonStr = "{\"id\":\"3\",\"params\":{\"SoilH\":{\"value\":\"" + humiLabel.Text + "\"}}}";
            UserPort.Write(jsonStr);
        }
        private void PhLabel_TextChanged(object sender, EventArgs e)
        {
            string jsonStr = "{\"id\":\"4\",\"params\":{\"SoilP\":{\"value\":\"" + phLabel.Text + "\"}}}";
            UserPort.Write(jsonStr);
        }
        private void Co2Label_TextChanged(object sender, EventArgs e)
        {
            string jsonStr = "{\"id\":\"5\",\"params\":{\"Co2\":{\"value\":\"" + co2Label.Text + "\"}}}";
            UserPort.Write(jsonStr);
        }
        private void LightLabel_TextChanged(object sender, EventArgs e)
        {
            string jsonStr = "{\"id\":\"6\",\"params\":{\"Lig\":{\"value\":\"" + lightLabel.Text + "\"}}}";         
            UserPort.Write(jsonStr);
        }
        private void LevelLabel_TextChanged(object sender, EventArgs e)
        {
            string jsonStr;
            if (levelLabel.Text == "适宜")
                jsonStr = "{\"id\":\"7\",\"params\":{\"EV\":{\"value\":\"Comfortable\"}}}";
            else 
                jsonStr = "{\"id\":\"7\",\"params\":{\"EV\":{\"value\":\"Uncomfortable\"}}}";
            UserPort.Write(jsonStr);
        }
        /* "showTimer"定时器的工作函数，辅助在界面中显示系统时间 */
        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            //在下方状态栏处显示以下信息
            toolStripStatusLabel4.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
        /* "triggerTimer"定时器的工作函数，每11s触发评价系统进行生长舒适度评价 */
        private async void TriggerTimer_Tick(object sender, EventArgs e)
        {
            //先判断是否都收到了各个传感器的数据，如果没有接收完全则无法进行评价
            if (dataArray[0] * dataArray[1] * dataArray[2] * dataArray[3] * dataArray[4] * dataArray[5] != 0) 
            {      
                //创建DSAlgorithm类的实例
                DSAlgorithm dsAlgorithm = new DSAlgorithm();
                //第一路评价：将数据带入D-S证据理论算法模型得出评价结果一
                string result = dsAlgorithm.EvaluateConditions(dataArray[0], dataArray[1], dataArray[2], dataArray[3]);
                //第二路评价：将数据带入专用AI模型得出评价结果二
                string question = "空气温度 " + dataStr[0] + " 空气湿度 " + dataStr[1] + " 土壤水分 " + dataStr[2] + " 土壤PH " + dataStr[3] +
                                  "光照度" + dataStr[4] + "CO2浓度" + dataStr[5];
                AiHelpRe response = await aiService.AskQuestionAsync(lev2Str + question + comStr);
                replyBox.Text = response.Result;
                //将两个评价结果进行比对，相同则直接得出最终结果，不同则根据下一步的第三路评价结果来决出最终结果
                if (!(GetFinalEvalFlag(result, response.Result)))
                {
                    AiHelpRe reElse = await aiService.AskQuestionAsync(lev1Str + question + comStr);
                    GetAiEvaluateMessage(reElse.Result);
                }                 
            }           
            return;
        }
        /* InspectTimer定时器工作函数，每4s检查并删除网络中离线的节点 */
        private void InspectTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now; //获取当前时间戳
            List<string> nodesToRemove = new List<string>(); //用于存放待删除节点的列表
            foreach (var node in nodes.Values) //遍历字典中的所有节点
            {
                if ((now - node.LastUpdated).TotalSeconds > 7) //若有节点超过7秒没有更新时间戳则放入待删除列表
                {
                    nodesToRemove.Add(node.Name);
                    if (nodeLabelMap.ContainsKey(node)) //如果该节点已经有一个Label，则更新内容；否则创建新的Label
                    {
                        showLabel = nodeLabelMap[node];
                        showPanel.Controls.Remove(showLabel);
                    }
                }
            }
            foreach (var nodeName in nodesToRemove) //遍历列表中的所有节点，逐一删除
            {
                RemoveNode(nodeName);             
            }
        }
        /* 选中ZigBee网络拓扑信息中的某个节点时的处理函数 */
        private void NetTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (var nodes in nodes.Values)
            {
                nodes.SetSelected(false);
            }
            // 获取当前选中的树节点的名称
            string selectedNodeName = e.Node.Text.Substring(e.Node.Text.Length - 4); //假设节点名称为"路由器xxxx"或"终端xxxx"
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
                UserPort.Write(setBuf, 0, 5); //串口发送
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "失败，请重试！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /* “清理数据”按钮被点击时的处理函数，清除掉数据库中保存到各表数据 */
        private void ClearTableButton_Click(object sender, EventArgs e)
        {
            //显示一个二次确认对话框
            DialogResult result = MessageBox.Show(
                "确定要清空数据库中保存的所有数据吗？删除后无法恢复。",
                "确认清空数据",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (result == DialogResult.Yes) //确认则调用清理数据的函数
            {

                sqliteDB.ClearTableData();
            }
            else //取消则返回，不操作
            {
                return;
            }
        }
        /* “历史数据”按钮被点击时的处理函数，打开历史数据界面 */
        private void HistoryButton_Click(object sender, EventArgs e)
        {
            //创建历史数据界面的实例
            HistortDataForm histortDataForm = new HistortDataForm();
            //加载AirHumiTable表中的数据并显示在airHumiGridView中        
            histortDataForm.airHumiGridView.DataSource = sqliteDB.GetFormDataBase("AirHumiTable");
            //加载AirTempTable表中的数据并显示在airTempGridView中        
            histortDataForm.airTempGridView.DataSource = sqliteDB.GetFormDataBase("AirTempTable");
            //加载HumiTable表中的数据并显示在humiGridView中        
            histortDataForm.humiGridView.DataSource = sqliteDB.GetFormDataBase("HumiTable");
            //加载PhTable表中的数据并显示在phGridView中        
            histortDataForm.phGridView.DataSource = sqliteDB.GetFormDataBase("PhTable");
            //加载Co2Table表中的数据并显示在co2GridView中        
            histortDataForm.co2GridView.DataSource = sqliteDB.GetFormDataBase("Co2Table");
            //加载LightTable表中的数据并显示在lightGridView中        
            histortDataForm.lightGridView.DataSource = sqliteDB.GetFormDataBase("LightTable");
            //显示历史数据界面
            histortDataForm.Show(); 
        }
        /* “导出Excel”按钮被点击时的处理函数，将数据库所有表内容导出为Excel表格 */
        private void ExportButton_Click(object sender, EventArgs e)
        {
            //依次导出所有表格并以相应的名称命名文件，导出路径默认是软件工作目录下
            sqliteDB.ExportToExcel("AirTempTable", "AirTempData.xlsx");
            sqliteDB.ExportToExcel("AirHumiTable", "AirHumiData.xlsx");
            sqliteDB.ExportToExcel("HumiTable", "SoilHumiData.xlsx");
            sqliteDB.ExportToExcel("PhTable", "SoilPhData.xlsx");
            sqliteDB.ExportToExcel("Co2Table", "Co2Data.xlsx");
            sqliteDB.ExportToExcel("LightTable", "LightData.xlsx");
            //提示导出完成，多次导出会自动覆盖前面的文件，只保留最新版本
            MessageBox.Show("导出Excel表格成功！");
        }
        /* 快捷功能区，“ZigBee模块管理”按钮被点击时的处理函数 */
        private void SkipButton1_Click(object sender, EventArgs e)
        {
            ManageForm manageForm = new ManageForm();
            manageForm.Show(); //显示模块管理界面
        }
        /* 快捷功能区，“AI帮助”按钮被点击时的处理函数 */
        private void SkipButton2_Click(object sender, EventArgs e)
        {
            AiForm aiForm = new AiForm();
            aiForm.Show(); //显示AI帮助界面
        }
        /* “主界面”被关闭时的处理函数 */
        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //设为false，通知接收线程停止
            isRunning = false;
            //关闭该界面自动关闭串口并取消订阅串口接收事件
            UserPort.DataReceived -= new SerialDataReceivedEventHandler(UserPort_DataReceived);
            UserPort.Close();
            //关闭定时器
            showTimer.Stop();
            triggerTimer.Stop();
            inspectTimer.Stop();
            //断开与数据库的连接
            if (sqliteDB != null)
            {
                sqliteDB.DisconnectToDataBase();
            }
            //恢复菜单首界面
            menuForm.WindowState = FormWindowState.Normal; 
        }
        /* 串口接收函数中调用的对hex类型数据进行分类处理的函数 */
        private void ProcessHexData(byte[] pkt)
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
                if (nName == "0000") //判断这个键是否是0000，是则该节点是协调器，还需更新网络号信息
                {
                    idSLabel.Text = nodes["0000"].NodeFather;//协调器的父节点属性中存放的是网络号
                }
            }
            else //如果没有同名的节点存在于字典列表中，则允许创建新节点
            {
                switch (pkt[1])
                {
                    case 0x00: //协调器节点，给定大小、颜色并计数
                        {
                            nType = "C"; nSize = 45; nColor = Color.Orange;
                        }
                        break;
                    case 0x01: //路由器节点，给定大小、颜色并计数
                        {
                            nType = "R"; nSize = 40; nColor = Color.CadetBlue;
                        }
                        break;
                    case 0x02: //终端节点，给定大小、颜色并计数
                        {
                            nType = "E"; nSize = 40; nColor = Color.RosyBrown; 
                        }
                        break;
                }
                nFather = pkt[4].ToString("X2") + pkt[5].ToString("X2");
                CreateNode(nName, nType, nSize, nColor, 30 + nodes.Count * 2, nFather); //创建节点            
            }
        }
        /* 串口接收函数中调用的对str类型数据进行分类处理的函数 */
        private void ProcessStrData(string pkt)
        {
            //以空格为界将字符串划分为不同的部分
            string[] parts = pkt.Split(' ');
            if (parts[0] == "DS") //土壤参数传感器数据：土壤水分/PH
            {
                //截取传感器数据,并将结果显示在参数对应位置，放入dataStr[]等候AI处理
                string strT1 = parts[1];
                dataStr[2] = strT1;
                humiLabel.Text = strT1;                                         
                string strT2 = parts[2];
                dataStr[3] = strT2;
                phLabel.Text = strT2;              
                //将传感器数据与对应节点控件进行匹配并显示                           
                string combData = " 土壤水分:" + strT1 + " 土壤PH:" + strT2;
                string strT3 = parts[3];
                MatchSensorNode(strT3, combData);
                //将截取后的字符串转化为float型数据并放入对应参数数组位置等候处理，然后添加到数据库对应表格中
                float humiVal = float.Parse(strT1);
                dataArray[2] = humiVal;
                sqliteDB.InsertToDataBase("HumiTable", humiVal, "HumiValue");             
                float phVal = float.Parse(strT2);
                dataArray[3] = phVal;
                sqliteDB.InsertToDataBase("PhTable", phVal, "PhValue");
            }
            if (parts[0] == "DC") //二氧化碳浓度传感器数据：CO2浓度
            {
                //截取传感器数据,并将结果显示在参数对应位置，放入dataStr[]等候AI处理
                string strT1 = parts[1];
                dataStr[5] = strT1;
                co2Label.Text = strT1;             
                //将传感器数据与对应节点控件进行匹配并显示               
                string combData = "CO2浓度:" + strT1;
                string strT2 = parts[2];
                MatchSensorNode(strT2, combData);
                //将截取后的字符串转化为float型数据并放入对应参数数组位置等候处理，然后添加到数据库对应表格中
                float co2Val = float.Parse(strT1);
                dataArray[5] = co2Val;
                sqliteDB.InsertToDataBase("Co2Table", co2Val, "Co2Value");             
            }
            if (parts[0] == "DLT") //光照温湿度传感器数据：光照度/空气温度/空气湿度
            {
                //截取传感器数据,并将结果显示在参数对应位置，放入dataStr[]等候AI处理
                string strT1 = parts[1];               
                dataStr[4] = strT1;
                lightLabel.Text = strT1;
                string strT2 = parts[2];
                dataStr[0] = strT2;
                airTempLabel.Text = strT2;
                string strT3 = parts[3];
                dataStr[1] = strT3;
                airHumiLabel.Text = strT3;
                //将传感器数据与对应节点控件进行匹配并显示               
                string combData = "空气温度:" + strT2 + "空气湿度:" + strT3 + "光照度:" + strT1;
                string strT4 = parts[4];
                MatchSensorNode(strT4, combData);
                //将截取后的字符串转化为float型数据并放入dataArray[]等候算法处理，然后添加到数据库对应表格中
                float lightVal = float.Parse(strT1);
                dataArray[4] = lightVal;
                sqliteDB.InsertToDataBase("LightTable", lightVal, "LightValue");
                float airTempVal = float.Parse(strT2);
                dataArray[0] = airTempVal;
                sqliteDB.InsertToDataBase("AirTempTable", airTempVal, "AirTempValue");
                float airHumiVal = float.Parse(strT3);
                dataArray[1] = airHumiVal;
                sqliteDB.InsertToDataBase("AirHumiTable", airHumiVal, "AirHumiValue");
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
            newNode.ContextMenuStrip.Items["MenuItem1"].Click += MenuItem1_Click;
            //订阅控件位置改变事件
            newNode.LocationChanged += NodeControl_LocationChanged;
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
        /* 用于更新treeview控件的显示列表 */
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
        /* 用来匹配每个节点控件及其对应的显示传感器数据的label控件 */
        private void MatchSensorNode(string shortAddr, string sensorData)
        {
            foreach (var node in nodes.Values) //遍历存储已创建节点字典中的所有节点
            {
                if (node.Name == shortAddr)
                {
                    Label showLabel;                 
                    if (nodeLabelMap.ContainsKey(node)) //如果该节点已经有一个Label，则更新内容；否则创建新的Label
                    {
                        showLabel = nodeLabelMap[node];
                        showLabel.Text = sensorData; //更新传感器数据
                    }
                    else //创建新的Label控件并设置属性
                    {                       
                        showLabel = new Label();
                        showLabel.AutoSize = true;
                        showLabel.Font = new Font("宋体", 14.5f);
                        showLabel.ForeColor = Color.Black;
                        showLabel.Text = sensorData; //显示节点对应传感器数据
                        //将Label控件添加到Panel中，并保存到字典
                        showPanel.Controls.Add(showLabel);
                        nodeLabelMap[node] = showLabel;
                    }
                    //更新Label控件的位置为当前节点控件的位置上方
                    int showLabelX = node.Location.X; //与当前节点控件在X方向上位置相同
                    int showLabelY = node.Location.Y - showLabel.Height; //在Y方向上偏移
                    showLabel.Location = new Point(showLabelX, showLabelY); //设置Label的显示位置
                }
            }
        }
        /* NodeControl节点控件的位置发生改变时的处理函数，用于更新label控件显示位置 */
        private void NodeControl_LocationChanged(object sender, EventArgs e)
        {
            NodeControl node = sender as NodeControl;
            //确保该节点有一个对应的Label
            if (nodeLabelMap.ContainsKey(node))
            {
                Label showLabel = nodeLabelMap[node];
                int showLabelX = node.Location.X; //更新X坐标
                int showLabelY = node.Location.Y - showLabel.Height; //更新Y坐标
                showLabel.Location = new Point(showLabelX, showLabelY); //更新Label的位置
            }
        }
        /* 用于判断并显示舒适度评价结果的函数 */
        public void GetAiEvaluateMessage(string str)
        {
            if (str.Contains("不适宜"))
            {
                levelLabel.ForeColor = Color.Red;
                levelLabel.Text = "不适宜";             
            }
            else 
            {
                levelLabel.ForeColor = Color.Green;
                levelLabel.Text = "适宜";
            }
        }
        public bool GetFinalEvalFlag(string str1, string str2)
        {
            string tempstr1 = str1.Contains("不适宜") ? "不适宜" : "适宜";
            string tempstr2 = str2.Contains("不适宜") ? "不适宜" : "适宜";
            if (string.Equals(tempstr1, tempstr2, StringComparison.Ordinal))
            {
                if (tempstr1 == "适宜")
                    levelLabel.ForeColor = Color.Green;
                else
                    levelLabel.ForeColor = Color.Red;
                levelLabel.Text = tempstr1;
                return true;
            }
            else
                return false;   
        }
    }
}

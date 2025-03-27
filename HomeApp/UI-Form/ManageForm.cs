using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using static MyApp.Common;

namespace MyApp
{
    public partial class ManageForm : Form
    {
        private bool isReadBtnCk = false; //判断<读取参数>按钮是否被点击的标识符
        private string[] chan; //成员字段方便整个类中使用
        public ManageForm() 
        {        
            InitializeComponent();            
        }      
        /* 当管理界面被创建时，需要加载的初始信息 */
        private void ManageForm_Load(object sender, EventArgs e)
        {
            //添加波特率选项
            string[] baud = { "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            baudBox1.Items.AddRange(baud); //加入波特率选择框
            baudBox2.Items.AddRange(baud); //加入波特率修改框
            //添加节点类型选项
            string[] type = { "协调器", "路由器", "终端" };
            devTypeBox.Items.AddRange(type);
            //添加信道选项
            string[] channel = { "11", "12", "13", "14", "15", "16", "17", "18",
                "19", "20", "21", "22", "23", "24", "25", "26"};
            chanBox.Items.AddRange(channel);
            chan = new string[] { "0B", "0C", "0D", "0E", "0F", "10", "11", "12", "13",
                "14", "15", "16", "17", "18", "19", "1A" }; //11~26信道对应的hex命令值的初始化
            //添加传输方式选项
            string[] trans = { "仅透传", "透传+自定义地址" };
            transBox.Items.AddRange(trans);
            //添加发射功率选项
            string[] txPower = { "19dbm" };
            setPowBox.Items.AddRange(txPower);
            //添加绑定传感器类型选项
            string[] sensors = { "土壤参数传感器", "光照温湿度传感器" ,"二氧化碳传感器"};
            sensorBox.Items.AddRange(sensors);  
            //添加设置命令的帧头，用于在Zsatck协议栈中校验
            Array.Copy(StringToHexByte("AA"), 0, dataPkt, 0, 1);
            //添加网关配置时目标云平台选项
            string[] cloud = { "OneNET云", "阿里云"};
            netBox2.Items.AddRange(cloud);
            //打开软件默认禁用设置/读取/重启按钮
            sendButton.Enabled = false;
            readButton.Enabled = false;
            rstButton.Enabled = false;
        }
        /* "串口选择"框点击展开时的处理函数 */
        private void PortBox_DropDown(object sender, EventArgs e)
        {
            //获取电脑当前可用串口并添加到选项列表中
            string[] ports = SerialPort.GetPortNames();
            portBox.Items.Clear();
            portBox.Items.AddRange(ports);
        }
        /* "连接模块"按钮被点击时的处理函数，即打开串口 */
        private void LinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                //将可能产生异常的代码放置在try块中
                if (!serialPort1.IsOpen) //串口未开启则打开
                {
                    //设置串口参数串口号与波特率，其他参数均使用默认值，比如数据位8，停止位1，无校验
                    serialPort1.PortName = portBox.Text;
                    serialPort1.BaudRate = Convert.ToInt32(baudBox1.Text);                 
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived); //订阅串口接收事件                  
                    serialPort1.Open(); //打开串口
                    //如果串口开启，则使能设置/读取/重启按钮
                    sendButton.Enabled = true; 
                    readButton.Enabled = true;
                    rstButton.Enabled = true;
                    linkButton.Text = "断开模块"; //从“连接模块”-->“断开模块”
                    linkButton.BackColor = Color.Tomato; //按钮颜色变为番茄红
                }
                else //串口已开启则关闭
                {
                    serialPort1.DataReceived -= new SerialDataReceivedEventHandler(SerialPort1_DataReceived); //取消订阅串口接收事件                  
                    serialPort1.Close(); //关闭串口
                    //禁用设置/读取/重启按钮
                    sendButton.Enabled = false;
                    readButton.Enabled = false;
                    rstButton.Enabled = false;
                    linkButton.Text = "连接模块"; //恢复默认文本
                    linkButton.BackColor = Color.DarkSeaGreen; //按钮颜色恢复深绿色
                }
            }
            catch (Exception ex) //发生异常的处理
            {
                MessageBox.Show(ex.Message, "连接失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        /* "设置参数"按钮被点击时的处理函数 */
        private void SendButton_Click(object sender, EventArgs e)
        {           
            try
            {
                //串口发送给ZigBee模块
                serialPort1.Write(dataPkt, 0, 10); 
                //显示操作状态前清空消息框
                showBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "失败，请重试！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /* 串口接收到数据时的处理函数 */
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (isReadBtnCk == true)
            {                  
                int size = 19; //接收缓冲区固定字节大小
                byte[] readPkt = new byte[size]; //声明一个字节数组用于存放读出的byte型数据                   
                int half1 = serialPort1.Read(readPkt, 0, size / 2); //分两次读取缓冲区，第一次读size的一半长度
                Thread.Sleep(100); //线程休眠，等于暂停100ms
                int half2 = serialPort1.Read(readPkt, half1, size - half1); //读取剩下的数据，并从第一次读取完的数据后放入
                Thread.Sleep(100); //线程休眠，等于暂停100ms
                this.Invoke((EventHandler)(delegate
                {
                    if ((readPkt[0] == 0xBA) && (half1 + half2 == 19)) //判断帧头和数据包大小
                    {                  
                         MatchThePara(readPkt); //将读取到的数据与界面各个控件参数匹配
                         serialPort1.DiscardInBuffer(); //清空接收缓冲区
                         showBox.AppendText("Read Success  ");
                         isReadBtnCk = false; //处理后清除标识符
                    }
                    else
                    {
                        serialPort1.DiscardInBuffer(); //清空接收缓冲区
                        isReadBtnCk = false; //处理后清除标识符
                    }
                }));
            }
            else 
            {
                string strbuf = serialPort1.ReadExisting(); //读取接收区所有数据
                /*this.Invoke是跨线程访问ui的方法，因为串口接收是单独一个线程，不属于main函数主线程，而这里用到
                *的showBox这个控件是在主线程创建的，原则上不能跨线程调用。所以在这里通过Invoke实现跨线程访问*/
                this.Invoke((EventHandler)(delegate
                {
                    showBox.AppendText(strbuf); //将数据显示到消息框
                } ) );
            }                                                
        }
        /* "节点类型"选择框有动作时的处理函数 */
        private void DevTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (devTypeBox.SelectedIndex){
                //执行其中一个，将对应命令值转换为字节数据并添加到数据包第2位
                case 0: //协调器 字节1代表类型编号
                    { Array.Copy(StringToHexByte("00"), 0, dataPkt, 1, 1);
                        sensorBox.Enabled = false; break; }
                case 1: //路由器
                    { Array.Copy(StringToHexByte("01"), 0, dataPkt, 1, 1);
                        sensorBox.Enabled = false; break; }
                case 2: //终端
                    { Array.Copy(StringToHexByte("02"), 0, dataPkt, 1, 1); 
                        sensorBox.Enabled = true;  break;  } 
            }
        }
        /* "网络号"输入框有按键输入时的处理函数 */
        private void PanBox_KeyPress(object sender, KeyPressEventArgs e)
        {          
            //只允许输入：48-57为数字0~9; 65-70为大写字母A~F; 8为退格键
            bool isWrong = !((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 65 && e.KeyChar <= 70)) && e.KeyChar != 8;
            //如果不满足上述条件
            if (isWrong)
            {
                e.Handled = true; //阻止该字符输入
            }
            //将小写字母转换为大写字母
            //e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }
        /* 当离开输入框时执行该函数，此时再将框内数据更新到数据包 */
        private void PanBox_Leave(object sender, EventArgs e)
        {
            //写入的字符不为FFFF且是四个字符
            if (panBox.Text != "FFFF" && panBox.Text.Length == 4)
            {
                //将命令值添加到数据包第2位与第3位
                Array.Copy(StringToHexByte(panBox.Text), 0, dataPkt, 2, 2);
            }
            else 
            {
                showBox.AppendText("请输入有效的四个字符！0不可省略！") ;
            }
        }
        /* "信道"选择框有动作时的处理函数 */
        private void ChanBox_SelectedIndexChanged(object sender, EventArgs e)
        {           
            //利用下拉框的索引去对应channel数组的索引,以此取值
            int i = chanBox.SelectedIndex;
            //将命令值添加到数据包第4位
            Array.Copy(StringToHexByte(chan[i]), 0, dataPkt, 4, 1);
        }
        /* "传输方式"选择框有动作时的处理函数 */
        private void TransBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (transBox.SelectedIndex){
                case 0: //仅透传,禁止在addrBox写入数据 
                    { 
                        Array.Copy(StringToHexByte("8B"), 0, dataPkt, 5, 1);
                        addrBox.ReadOnly = true;
                        //将虚假地址00添加进去补足数据长度
                        Array.Copy(StringToHexByte("00"), 0, dataPkt, 6, 1); 
                        break; 
                    }
                case 1: //透传+自定义地址，允许写入数据
                    { 
                        Array.Copy(StringToHexByte("8A"), 0, dataPkt, 5, 1);
                        addrBox.ReadOnly = false; 
                        break; 
                    }
            }
        }
        /* "自定义地址"输入框有按键输入时的处理函数 */
        private void AddrBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只允许输入：48-57为数字0~9; 65-70为大写字母A~F; 8为退格键
            bool isWrong = !((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 65 && e.KeyChar <= 70)) && e.KeyChar != 8;
            //如果不满足上述条件
            if (isWrong)
            {
                e.Handled = true; //阻止该字符输入
            }
        }
        /* 当离开输入框时执行该函数，此时再将框内数据更新到数据包 */
        private void AddrBox_Leave(object sender, EventArgs e)
        {
            //如果传输方式是“透传+自定义地址”才执行以下代码
            if (transBox.SelectedIndex == 1)
            {
                if (addrBox.Text != "00" && addrBox.Text.Length == 2) //自定义地址不能为00
                {
                    //将命令值添加到数据包第9位
                    Array.Copy(StringToHexByte(addrBox.Text), 0, dataPkt, 6, 1);
                }
                else
                {
                    showBox.AppendText("请输入有效的两个字符！0不可省略！");
                }
            }
            else //否则直接退出该函数，无动作
            {
                return;
            }
        }
        /* "发射功率"选择框有动作时的处理函数 */
        private void SetPowBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (setPowBox.SelectedIndex){
                case 0: //19dbm
                    Array.Copy(StringToHexByte("D5"), 0, dataPkt, 7, 1); break;
                /*
                case 0: //10dbm 
                    Array.Copy(StringToHexByte("65"), 0, dataPkt, 7, 1); break;
                case 1: //15dbm
                    Array.Copy(StringToHexByte("A5"), 0, dataPkt, 7, 1); break;
                */
            }
        }
        /* "波特率修改"选择框有动作时的处理函数 */
        private void BaudBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (baudBox2.SelectedIndex){
                case 0: //2400 
                    Array.Copy(StringToHexByte("00"), 0, dataPkt, 8, 1); break;
                case 1: //4800
                    Array.Copy(StringToHexByte("01"), 0, dataPkt, 8, 1); break;
                case 2: //9600
                    Array.Copy(StringToHexByte("02"), 0, dataPkt, 8, 1); break;
                case 3: //19200
                    Array.Copy(StringToHexByte("03"), 0, dataPkt, 8, 1); break;
                case 4: //38400 
                    Array.Copy(StringToHexByte("04"), 0, dataPkt, 8, 1); break;
                case 5: //57600
                    Array.Copy(StringToHexByte("05"), 0, dataPkt, 8, 1); break;
                case 6: //115200
                    Array.Copy(StringToHexByte("06"), 0, dataPkt, 8, 1); break;
            }
        }       
        /* "绑定传感器"选择框有动作时的处理函数 */
        private void SensorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (sensorBox.SelectedIndex)
            {
                case 0: //土壤参数传感器
                    Array.Copy(StringToHexByte("E1"), 0, dataPkt, 9, 1); break;
                case 1: //光照温度传感器
                    Array.Copy(StringToHexByte("E2"), 0, dataPkt, 9, 1); break;
                case 2: //二氧化碳传感器
                    Array.Copy(StringToHexByte("E3"), 0, dataPkt, 9, 1); break;
            }
        }
        /* "读取参数"按钮被点击时的处理函数 */
        private void ReadButton_Click(object sender, EventArgs e)
        {
            try
            {//查询返回格式 BA type panid channel short mac trans 2E 共18个字节
                serialPort1.Write(StringToHexByte("AB"), 0, 1); //发送查询命令
                isReadBtnCk = true; //已被按下，用于在串口接收函数中标识
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "失败，请重试！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /* "重启模块"按钮被点击时的处理函数 */
        private void ResetButton_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write(StringToHexByte("AC"), 0, 1); //发送复位命令
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "失败，请重试！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /* "开始配置"按钮被点击时的处理函数 */
        private void NetButton_Click(object sender, EventArgs e)
        {
            if (netButton.Text == "开始配置")
            {
                serialPort1.Write("+++"); //向4G模块发送以上命令进入AT指令模式                
                netButton.Text = "结束配置"; //进入配置模式后切换按钮功能为结束配置
                netButton.BackColor = Color.Tomato; //按钮颜色改变以提示用户
            }
            else 
            {
                serialPort1.Write("AT+S"); //向网口模块发送命令来保存配置并重启，重启后自动退出AT指令模式
                netButton.Text = "开始配置"; //结束配置后切换按钮功能为开始配置
                netButton.BackColor = Color.DarkSeaGreen;//按钮颜色改变以提示用户
            }        
        }
        /* "云模式"勾选框有动作时的处理函数 */
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                serialPort1.Write("AT+WKMOD=1,CLOUD"); //默认启用云模式
            }
        }
        /* "云平台"选择框有动作时的处理函数 */
        private void NetBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //连接其他云平台时只需要填写设备名，故启用netBox3;只有连接阿里云只需要填写产品密钥,故启用netBox4
            switch (netBox2.SelectedIndex) {
                case 0: //连接到OneNET云平台
                    serialPort1.Write("AT+CLOUD=1,ONENET"); break;
                case 1: //连接到阿里云平台
                    serialPort1.Write("AT+CLOUD=1,ALIYUN"); break;
            }
        }
        /* 离开"云平台"选择框时的处理函数，离开时自动配置接入类型 */
        private void NetBox2_Leave(object sender, EventArgs e)
        {           
            switch (netBox2.SelectedIndex) {               
                case 0: //连接到OneNET云平台              
                    serialPort1.Write("AT+ONENETTP=1,USER"); break; 
                case 1: //连接到阿里云平台
                    serialPort1.Write("AT+ALIYUNTP=1,ONE_MACHINE"); break;          
            }
        }
        /* 离开"连接参数"输入框时的处理函数 */
        private void NetBox3_Leave(object sender, EventArgs e)
        {
            string atStr;
            if (netBox2.SelectedIndex == 0) //如果是连接OneNet云则发送以下指令
            {
                atStr = "AT+ONENETCN=1," + netBox3.Text; //将AT指令与用户输入的网络参数结合
                serialPort1.Write(atStr); //发送给网口模块
            }
            else //反之连接阿里云则发送以下指令
            {
                atStr = "AT+ALIYUNCN=1," + netBox3.Text; //将AT指令与用户输入的网络参数结合
                serialPort1.Write(atStr);
            }
        }      
        /* 离开"订阅参数"输入框时的处理函数 */
        private void NetBox7_Leave(object sender, EventArgs e)
        {
            string atStr;
            if (netBox2.SelectedIndex == 0) //如果是连接OneNet云则发送以下指令
            {
                atStr = "AT+ONENETSUB=1," + netBox4.Text + ",0"; //将AT指令与用户输入的网络参数结合
                serialPort1.Write(atStr); //发送给网口模块
            }
            else //反之连接阿里云则发送以下指令
            {
                atStr = "AT+ALIYUNSUB=1," + netBox4.Text + ",0"; //将AT指令与用户输入的网络参数结合
                serialPort1.Write(atStr);
            }       
        }
        /* 离开"发布参数"输入框时的处理函数 */
        private void NetBox8_Leave(object sender, EventArgs e)
        {
            string atStr;
            if (netBox2.SelectedIndex == 0) //如果是连接OneNet云则发送以下指令
            {
                atStr = "AT+ONENETPUB=1," + netBox5.Text + ",0,0"; //将AT指令与用户输入的网络参数结合
                serialPort1.Write(atStr); //发送给网口模块
            }
            else //反之连接阿里云则发送以下指令
            {
                atStr = "AT+ALIYUNPUB=1," + netBox5.Text + ",0,0"; //将AT指令与用户输入的网络参数结合
                serialPort1.Write(atStr);
            }
        }
        /* "清空"按钮被点击时的处理函数 */
        private void ClearButton_Click(object sender, EventArgs e)
        {
            //清空消息框
            showBox.Clear();
        }
        /* 当前界面被关闭时的处理函数 */
        private void ManageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭界面时如果串口仍打开，则强制关闭，避免下次打开时出错
            if (serialPort1.IsOpen)
            {
                serialPort1.DataReceived -= new SerialDataReceivedEventHandler(SerialPort1_DataReceived); //取消订阅串口接收事件                  
                serialPort1.Close(); //关闭串口
            }
        }
        /* 读取参数时所需功能函数 */
        private void MatchThePara(byte[] pkt)
        {
            //将数据与节点类型参数匹配
            switch (pkt[1]){
                case 0x00: devTypeBox.SelectedIndex = 0;  break;
                case 0x01: devTypeBox.SelectedIndex = 1;  break;
                case 0x02: devTypeBox.SelectedIndex = 2;  break;
            }
            //将数据与网络号参数匹配
            panBox.Text = pkt[2].ToString("X2") + pkt[3].ToString("X2"); //ToString("X2")重载版本，将其格式转为2位的十六进制
            /*遍历数组chan[]，找到pkt[4]中与之相等的一项，记录该项下标。由于chan[]与channel[]的逻辑一致，
             *因此该下标与chanBox的索引相匹配，这样就能把读取到的信道正确显示在界面*/
            for (int i = 0; i < chan.Length; i++)
            {
                if (pkt[4].ToString("X2") == chan[i])
                {
                    chanBox.SelectedIndex = i;
                    break; //找到匹配项后立即退出循环
                }
                else if (pkt[4].ToString("X2") == "00")
                {
                    break;
                }
            }
            //将数据与网络短地址参数匹配
            nwkAddr.Text = pkt[5].ToString("X2") + pkt[6].ToString("X2");
            //将数据与IEEE地址参数匹配
            macAddr.Text = string.Join(" ", pkt[7].ToString("X2"), pkt[8].ToString("X2"), pkt[9].ToString("X2"), pkt[10].ToString("X2"),
                pkt[11].ToString("X2"), pkt[12].ToString("X2"), pkt[13].ToString("X2"), pkt[14].ToString("X2"));
            //将数据与传输方式参数匹配
            switch (pkt[15]){
                case 0x8B: transBox.SelectedIndex = 0; break;
                case 0x8A:
                    {
                        transBox.SelectedIndex = 1;
                        addrBox.Text = pkt[16].ToString("X2"); //读取自定义的地址
                    } break;
            }
            //将数据与串口通信波特率匹配
            switch (pkt[17]) {
                case 0x00: baudBox2.SelectedIndex = 0; break;
                case 0x01: baudBox2.SelectedIndex = 1; break;
                case 0x02: baudBox2.SelectedIndex = 2; break;
                case 0x03: baudBox2.SelectedIndex = 3; break;
                case 0x04: baudBox2.SelectedIndex = 4; break;
                case 0x05: baudBox2.SelectedIndex = 5; break;
                case 0x06: baudBox2.SelectedIndex = 6; break;
            }
            //将数据与发射功率匹配
            switch (pkt[18]) {
                case 0xD5: setPowBox.SelectedIndex = 0; break;
                default: break;
            }
        }

    }
}

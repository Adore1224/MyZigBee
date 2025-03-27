namespace MyApp
{
    partial class ManageForm
    {
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        /// Clean up any resources being used.
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageForm));
            this.linkButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.baudBox1 = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.portBox = new System.Windows.Forms.ComboBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.devTypeBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panBox = new System.Windows.Forms.TextBox();
            this.showBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.readButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.rstButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.transBox = new System.Windows.Forms.ComboBox();
            this.addrBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.baudBox2 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.chanBox = new System.Windows.Forms.ComboBox();
            this.setPowBox = new System.Windows.Forms.ComboBox();
            this.mac = new System.Windows.Forms.Label();
            this.macAddr = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.nwkAddr = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.netButton = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.netBox3 = new System.Windows.Forms.TextBox();
            this.netBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.netBox5 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.netBox2 = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.sensorBox = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // linkButton
            // 
            this.linkButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.linkButton.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkButton.Location = new System.Drawing.Point(379, 8);
            this.linkButton.Name = "linkButton";
            this.linkButton.Size = new System.Drawing.Size(93, 27);
            this.linkButton.TabIndex = 2;
            this.linkButton.Text = "连接模块";
            this.linkButton.UseVisualStyleBackColor = false;
            this.linkButton.Click += new System.EventHandler(this.LinkButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(34, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(-2, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 2);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(208, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "波特率";
            // 
            // baudBox1
            // 
            this.baudBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudBox1.FormattingEnabled = true;
            this.baudBox1.Location = new System.Drawing.Point(266, 13);
            this.baudBox1.Name = "baudBox1";
            this.baudBox1.Size = new System.Drawing.Size(84, 20);
            this.baudBox1.TabIndex = 1;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // portBox
            // 
            this.portBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portBox.FormattingEnabled = true;
            this.portBox.Location = new System.Drawing.Point(95, 12);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(84, 20);
            this.portBox.TabIndex = 0;
            this.portBox.DropDown += new System.EventHandler(this.PortBox_DropDown);
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.YellowGreen;
            this.sendButton.Location = new System.Drawing.Point(356, 386);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(116, 41);
            this.sendButton.TabIndex = 11;
            this.sendButton.Text = "设置参数";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(18, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "节点类型";
            // 
            // devTypeBox
            // 
            this.devTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devTypeBox.FormattingEnabled = true;
            this.devTypeBox.Location = new System.Drawing.Point(95, 54);
            this.devTypeBox.Name = "devTypeBox";
            this.devTypeBox.Size = new System.Drawing.Size(84, 20);
            this.devTypeBox.TabIndex = 3;
            this.devTypeBox.SelectedIndexChanged += new System.EventHandler(this.DevTypeBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(34, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "网络号";
            // 
            // panBox
            // 
            this.panBox.Location = new System.Drawing.Point(95, 84);
            this.panBox.MaxLength = 4;
            this.panBox.Name = "panBox";
            this.panBox.Size = new System.Drawing.Size(84, 21);
            this.panBox.TabIndex = 4;
            this.panBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PanBox_KeyPress);
            this.panBox.Leave += new System.EventHandler(this.PanBox_Leave);
            // 
            // showBox
            // 
            this.showBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.showBox.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.showBox.Location = new System.Drawing.Point(37, 350);
            this.showBox.Multiline = true;
            this.showBox.Name = "showBox";
            this.showBox.ReadOnly = true;
            this.showBox.Size = new System.Drawing.Size(280, 95);
            this.showBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(50, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "信道";
            // 
            // readButton
            // 
            this.readButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.readButton.Location = new System.Drawing.Point(356, 339);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(116, 41);
            this.readButton.TabIndex = 10;
            this.readButton.Text = "读取参数";
            this.readButton.UseVisualStyleBackColor = false;
            this.readButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(260, 451);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(57, 23);
            this.clearButton.TabIndex = 13;
            this.clearButton.Text = "清空";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // rstButton
            // 
            this.rstButton.BackColor = System.Drawing.Color.Chocolate;
            this.rstButton.Location = new System.Drawing.Point(356, 433);
            this.rstButton.Name = "rstButton";
            this.rstButton.Size = new System.Drawing.Size(116, 41);
            this.rstButton.TabIndex = 12;
            this.rstButton.Text = "重启模块";
            this.rstButton.UseVisualStyleBackColor = false;
            this.rstButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(239, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "传输方式";
            // 
            // transBox
            // 
            this.transBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transBox.FormattingEnabled = true;
            this.transBox.Location = new System.Drawing.Point(312, 55);
            this.transBox.Name = "transBox";
            this.transBox.Size = new System.Drawing.Size(122, 20);
            this.transBox.TabIndex = 6;
            this.transBox.SelectedIndexChanged += new System.EventHandler(this.TransBox_SelectedIndexChanged);
            // 
            // addrBox
            // 
            this.addrBox.Location = new System.Drawing.Point(457, 55);
            this.addrBox.MaxLength = 2;
            this.addrBox.Name = "addrBox";
            this.addrBox.ReadOnly = true;
            this.addrBox.Size = new System.Drawing.Size(35, 21);
            this.addrBox.TabIndex = 7;
            this.addrBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddrBox_KeyPress);
            this.addrBox.Leave += new System.EventHandler(this.AddrBox_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(436, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "+";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(235, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "发射功率";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(215, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "RS485波特率";
            // 
            // baudBox2
            // 
            this.baudBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudBox2.FormattingEnabled = true;
            this.baudBox2.Location = new System.Drawing.Point(312, 111);
            this.baudBox2.Name = "baudBox2";
            this.baudBox2.Size = new System.Drawing.Size(84, 20);
            this.baudBox2.TabIndex = 9;
            this.baudBox2.SelectedIndexChanged += new System.EventHandler(this.BaudBox2_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(-2, 190);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(500, 2);
            this.label12.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.IndianRed;
            this.label13.Location = new System.Drawing.Point(33, 481);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(419, 19);
            this.label13.TabIndex = 29;
            this.label13.Text = "Tips:如有疑惑，可点击<帮助>获取相关文档！";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Pink;
            this.button4.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(12, 451);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "帮助";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // chanBox
            // 
            this.chanBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chanBox.FormattingEnabled = true;
            this.chanBox.Location = new System.Drawing.Point(95, 111);
            this.chanBox.Name = "chanBox";
            this.chanBox.Size = new System.Drawing.Size(84, 20);
            this.chanBox.TabIndex = 5;
            this.chanBox.SelectedIndexChanged += new System.EventHandler(this.ChanBox_SelectedIndexChanged);
            // 
            // setPowBox
            // 
            this.setPowBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setPowBox.FormattingEnabled = true;
            this.setPowBox.Location = new System.Drawing.Point(312, 84);
            this.setPowBox.Name = "setPowBox";
            this.setPowBox.Size = new System.Drawing.Size(84, 20);
            this.setPowBox.TabIndex = 8;
            this.setPowBox.SelectedIndexChanged += new System.EventHandler(this.SetPowBox_SelectedIndexChanged);
            // 
            // mac
            // 
            this.mac.AutoSize = true;
            this.mac.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mac.Location = new System.Drawing.Point(26, 159);
            this.mac.Name = "mac";
            this.mac.Size = new System.Drawing.Size(87, 16);
            this.mac.TabIndex = 31;
            this.mac.Text = "IEEE Addr:";
            // 
            // macAddr
            // 
            this.macAddr.AutoSize = true;
            this.macAddr.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.macAddr.ForeColor = System.Drawing.Color.Red;
            this.macAddr.Location = new System.Drawing.Point(119, 161);
            this.macAddr.Name = "macAddr";
            this.macAddr.Size = new System.Drawing.Size(49, 14);
            this.macAddr.TabIndex = 33;
            this.macAddr.Text = "待读取";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(18, 143);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 16);
            this.label15.TabIndex = 34;
            this.label15.Text = "Short Addr:";
            // 
            // nwkAddr
            // 
            this.nwkAddr.AutoSize = true;
            this.nwkAddr.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nwkAddr.ForeColor = System.Drawing.Color.Red;
            this.nwkAddr.Location = new System.Drawing.Point(119, 143);
            this.nwkAddr.Name = "nwkAddr";
            this.nwkAddr.Size = new System.Drawing.Size(49, 14);
            this.nwkAddr.TabIndex = 35;
            this.nwkAddr.Text = "待读取";
            // 
            // label16
            // 
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(-2, 332);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(500, 2);
            this.label16.TabIndex = 36;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("幼圆", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(17, 181);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(143, 16);
            this.label17.TabIndex = 37;
            this.label17.Text = "网关模块上云配置";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("幼圆", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(18, 35);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 16);
            this.label18.TabIndex = 38;
            this.label18.Text = "模块组网配置";
            // 
            // netButton
            // 
            this.netButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.netButton.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.netButton.Location = new System.Drawing.Point(370, 177);
            this.netButton.Name = "netButton";
            this.netButton.Size = new System.Drawing.Size(75, 26);
            this.netButton.TabIndex = 39;
            this.netButton.Text = "开始配置";
            this.netButton.UseVisualStyleBackColor = false;
            this.netButton.Click += new System.EventHandler(this.NetButton_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(22, 226);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 14);
            this.label20.TabIndex = 44;
            this.label20.Text = "云平台";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(8, 255);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 14);
            this.label22.TabIndex = 47;
            this.label22.Text = "连接参数";
            // 
            // netBox3
            // 
            this.netBox3.Location = new System.Drawing.Point(77, 254);
            this.netBox3.Name = "netBox3";
            this.netBox3.Size = new System.Drawing.Size(409, 21);
            this.netBox3.TabIndex = 48;
            this.netBox3.Text = "依次填产品ID,设备名称,设备密钥(如连接阿里云还需在开头填cn-shanghai)";
            this.netBox3.Leave += new System.EventHandler(this.NetBox3_Leave);
            // 
            // netBox4
            // 
            this.netBox4.Location = new System.Drawing.Point(78, 281);
            this.netBox4.Name = "netBox4";
            this.netBox4.Size = new System.Drawing.Size(217, 21);
            this.netBox4.TabIndex = 57;
            this.netBox4.Leave += new System.EventHandler(this.NetBox7_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(9, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 56;
            this.label11.Text = "订阅参数";
            // 
            // netBox5
            // 
            this.netBox5.Location = new System.Drawing.Point(78, 308);
            this.netBox5.Name = "netBox5";
            this.netBox5.Size = new System.Drawing.Size(217, 21);
            this.netBox5.TabIndex = 59;
            this.netBox5.Leave += new System.EventHandler(this.NetBox8_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(9, 312);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 14);
            this.label19.TabIndex = 58;
            this.label19.Text = "发布参数";
            // 
            // netBox2
            // 
            this.netBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.netBox2.FormattingEnabled = true;
            this.netBox2.Location = new System.Drawing.Point(77, 225);
            this.netBox2.Name = "netBox2";
            this.netBox2.Size = new System.Drawing.Size(115, 20);
            this.netBox2.TabIndex = 60;
            this.netBox2.SelectedIndexChanged += new System.EventHandler(this.NetBox2_SelectedIndexChanged);
            this.netBox2.Leave += new System.EventHandler(this.NetBox2_Leave);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(223, 140);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(87, 16);
            this.label24.TabIndex = 63;
            this.label24.Text = "绑定传感器";
            // 
            // sensorBox
            // 
            this.sensorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sensorBox.FormattingEnabled = true;
            this.sensorBox.Location = new System.Drawing.Point(312, 139);
            this.sensorBox.Name = "sensorBox";
            this.sensorBox.Size = new System.Drawing.Size(122, 20);
            this.sensorBox.TabIndex = 64;
            this.sensorBox.SelectedIndexChanged += new System.EventHandler(this.SensorBox_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label26.Location = new System.Drawing.Point(-1, 139);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(205, 2);
            this.label26.TabIndex = 65;
            // 
            // label27
            // 
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label27.Location = new System.Drawing.Point(203, 139);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(2, 20);
            this.label27.TabIndex = 66;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox.Location = new System.Drawing.Point(12, 205);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(180, 18);
            this.checkBox.TabIndex = 68;
            this.checkBox.Text = "云模式（如上云需勾选）";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(307, 290);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(185, 12);
            this.label14.TabIndex = 69;
            this.label14.Text = "参数填完后点击“结束配置”按钮";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(307, 308);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(101, 12);
            this.label21.TabIndex = 70;
            this.label21.Text = "来保存并启用配置";
            // 
            // ManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(498, 509);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.sensorBox);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.netBox2);
            this.Controls.Add(this.netBox5);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.netBox4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.netBox3);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.netButton);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.nwkAddr);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.macAddr);
            this.Controls.Add(this.mac);
            this.Controls.Add(this.setPowBox);
            this.Controls.Add(this.chanBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.baudBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.addrBox);
            this.Controls.Add(this.transBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rstButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.showBox);
            this.Controls.Add(this.panBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.devTypeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.baudBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模块管理界面";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageForm_FormClosed);
            this.Load += new System.EventHandler(this.ManageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button linkButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox baudBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox portBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox devTypeBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox panBox;
        private System.Windows.Forms.TextBox showBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button rstButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox transBox;
        private System.Windows.Forms.TextBox addrBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox baudBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox chanBox;
        private System.Windows.Forms.ComboBox setPowBox;
        private System.Windows.Forms.Label mac;
        private System.Windows.Forms.Label macAddr;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label nwkAddr;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button netButton;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox netBox3;
        private System.Windows.Forms.TextBox netBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox netBox5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox netBox2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox sensorBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label21;
    }
}
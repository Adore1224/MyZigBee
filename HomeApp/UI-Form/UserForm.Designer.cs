namespace MyApp
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserForm));
            this.dataPanel = new System.Windows.Forms.Panel();
            this.airTempLabel = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.phLabel = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lightLabel = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.humiLabel = new System.Windows.Forms.Label();
            this.airHumiLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.co2Label = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.showTimer = new System.Windows.Forms.Timer(this.components);
            this.levelPanel = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.expotrButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.clearTableButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.UserPort = new System.IO.Ports.SerialPort(this.components);
            this.skipPanel = new System.Windows.Forms.Panel();
            this.skipButton2 = new System.Windows.Forms.Button();
            this.skipButton1 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.triggerTimer = new System.Windows.Forms.Timer(this.components);
            this.linkUButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.inspectTimer = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.setButton = new System.Windows.Forms.Button();
            this.baudBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.netTreeView = new System.Windows.Forms.TreeView();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.showPanel = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.roLabel = new System.Windows.Forms.Label();
            this.coLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.edLabel = new System.Windows.Forms.Label();
            this.idSLabel = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.devTypeBox = new System.Windows.Forms.ComboBox();
            this.configPanel = new System.Windows.Forms.Panel();
            this.tarLabel = new System.Windows.Forms.Label();
            this.replyBox = new System.Windows.Forms.TextBox();
            this.dataPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.levelPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.skipPanel.SuspendLayout();
            this.showPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.configPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataPanel
            // 
            this.dataPanel.BackColor = System.Drawing.Color.Transparent;
            this.dataPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataPanel.Controls.Add(this.airTempLabel);
            this.dataPanel.Controls.Add(this.label28);
            this.dataPanel.Controls.Add(this.label29);
            this.dataPanel.Controls.Add(this.label5);
            this.dataPanel.Controls.Add(this.phLabel);
            this.dataPanel.Controls.Add(this.label27);
            this.dataPanel.Controls.Add(this.label20);
            this.dataPanel.Controls.Add(this.lightLabel);
            this.dataPanel.Controls.Add(this.label22);
            this.dataPanel.Controls.Add(this.humiLabel);
            this.dataPanel.Controls.Add(this.airHumiLabel);
            this.dataPanel.Controls.Add(this.label21);
            this.dataPanel.Controls.Add(this.co2Label);
            this.dataPanel.Controls.Add(this.label11);
            this.dataPanel.Controls.Add(this.label4);
            this.dataPanel.Controls.Add(this.label3);
            this.dataPanel.Controls.Add(this.label2);
            this.dataPanel.Controls.Add(this.label1);
            this.dataPanel.Location = new System.Drawing.Point(744, 227);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(235, 209);
            this.dataPanel.TabIndex = 0;
            // 
            // airTempLabel
            // 
            this.airTempLabel.AutoSize = true;
            this.airTempLabel.BackColor = System.Drawing.Color.Transparent;
            this.airTempLabel.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.airTempLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.airTempLabel.Location = new System.Drawing.Point(128, 9);
            this.airTempLabel.Name = "airTempLabel";
            this.airTempLabel.Size = new System.Drawing.Size(19, 19);
            this.airTempLabel.TabIndex = 20;
            this.airTempLabel.Text = "*";
            this.airTempLabel.TextChanged += new System.EventHandler(this.AirTempLabel_TextChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.Aqua;
            this.label28.Location = new System.Drawing.Point(186, 9);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 19);
            this.label28.TabIndex = 19;
            this.label28.Text = "℃";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.ForeColor = System.Drawing.Color.Aqua;
            this.label29.Location = new System.Drawing.Point(3, 9);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(109, 19);
            this.label29.TabIndex = 18;
            this.label29.Text = "空气温度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Aqua;
            this.label5.Location = new System.Drawing.Point(186, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "--";
            // 
            // phLabel
            // 
            this.phLabel.AutoSize = true;
            this.phLabel.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.phLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.phLabel.Location = new System.Drawing.Point(128, 112);
            this.phLabel.Name = "phLabel";
            this.phLabel.Size = new System.Drawing.Size(19, 19);
            this.phLabel.TabIndex = 16;
            this.phLabel.Text = "*";
            this.phLabel.TextChanged += new System.EventHandler(this.PhLabel_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.ForeColor = System.Drawing.Color.Aqua;
            this.label27.Location = new System.Drawing.Point(3, 109);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(109, 19);
            this.label27.TabIndex = 15;
            this.label27.Text = "土壤PH值：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.Aqua;
            this.label20.Location = new System.Drawing.Point(186, 177);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 19);
            this.label20.TabIndex = 14;
            this.label20.Text = "lux";
            // 
            // lightLabel
            // 
            this.lightLabel.AutoSize = true;
            this.lightLabel.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lightLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.lightLabel.Location = new System.Drawing.Point(128, 177);
            this.lightLabel.Name = "lightLabel";
            this.lightLabel.Size = new System.Drawing.Size(19, 19);
            this.lightLabel.TabIndex = 13;
            this.lightLabel.Text = "*";
            this.lightLabel.TextChanged += new System.EventHandler(this.LightLabel_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.Aqua;
            this.label22.Location = new System.Drawing.Point(186, 79);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 19);
            this.label22.TabIndex = 12;
            this.label22.Text = "%RH";
            // 
            // humiLabel
            // 
            this.humiLabel.AutoSize = true;
            this.humiLabel.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.humiLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.humiLabel.Location = new System.Drawing.Point(128, 79);
            this.humiLabel.Name = "humiLabel";
            this.humiLabel.Size = new System.Drawing.Size(19, 19);
            this.humiLabel.TabIndex = 11;
            this.humiLabel.Text = "*";
            this.humiLabel.TextChanged += new System.EventHandler(this.HumiLabel_TextChanged);
            // 
            // airHumiLabel
            // 
            this.airHumiLabel.AutoSize = true;
            this.airHumiLabel.BackColor = System.Drawing.Color.Transparent;
            this.airHumiLabel.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.airHumiLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.airHumiLabel.Location = new System.Drawing.Point(128, 42);
            this.airHumiLabel.Name = "airHumiLabel";
            this.airHumiLabel.Size = new System.Drawing.Size(19, 19);
            this.airHumiLabel.TabIndex = 10;
            this.airHumiLabel.Text = "*";
            this.airHumiLabel.TextChanged += new System.EventHandler(this.AirHumiLabel_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.Aqua;
            this.label21.Location = new System.Drawing.Point(186, 144);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 19);
            this.label21.TabIndex = 9;
            this.label21.Text = "ppm";
            // 
            // co2Label
            // 
            this.co2Label.AutoSize = true;
            this.co2Label.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.co2Label.ForeColor = System.Drawing.Color.OrangeRed;
            this.co2Label.Location = new System.Drawing.Point(128, 144);
            this.co2Label.Name = "co2Label";
            this.co2Label.Size = new System.Drawing.Size(19, 19);
            this.co2Label.TabIndex = 8;
            this.co2Label.Text = "*";
            this.co2Label.TextChanged += new System.EventHandler(this.Co2Label_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Aqua;
            this.label11.Location = new System.Drawing.Point(186, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 19);
            this.label11.TabIndex = 7;
            this.label11.Text = "%RH";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(3, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "CO2浓度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Aqua;
            this.label3.Location = new System.Drawing.Point(3, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "光照度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(3, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "土壤水分：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "空气湿度：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("华文彩云", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(649, 323);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "实时数据";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(994, 22);
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "SWUN";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabel2.Text = "电气工程学院里";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("华文新魏", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(672, 17);
            this.toolStripStatusLabel3.Text = "一个评分只有3.0的躺赢狗^-^搞的毕业设计。。。              不知道写啥了，塞点东西凑凑字数 ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // showTimer
            // 
            this.showTimer.Interval = 1000;
            this.showTimer.Tick += new System.EventHandler(this.ShowTimer_Tick);
            // 
            // levelPanel
            // 
            this.levelPanel.BackColor = System.Drawing.Color.Transparent;
            this.levelPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.levelPanel.Controls.Add(this.label18);
            this.levelPanel.Controls.Add(this.label17);
            this.levelPanel.Controls.Add(this.label13);
            this.levelPanel.Controls.Add(this.label12);
            this.levelPanel.Controls.Add(this.levelLabel);
            this.levelPanel.Location = new System.Drawing.Point(751, 69);
            this.levelPanel.Name = "levelPanel";
            this.levelPanel.Size = new System.Drawing.Size(228, 91);
            this.levelPanel.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(123, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 12);
            this.label18.TabIndex = 15;
            this.label18.Text = "红色-不适宜";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(44, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 14;
            this.label17.Text = "绿色-适宜";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(3, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 10;
            this.label13.Text = "·不适宜";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Green;
            this.label12.Location = new System.Drawing.Point(3, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 9;
            this.label12.Text = "·适宜";
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.levelLabel.ForeColor = System.Drawing.Color.Black;
            this.levelLabel.Location = new System.Drawing.Point(91, 16);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(35, 24);
            this.levelLabel.TabIndex = 8;
            this.levelLabel.Text = "无";
            this.levelLabel.TextChanged += new System.EventHandler(this.LevelLabel_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("华文彩云", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(747, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "综合适宜度";
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.Transparent;
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.controlPanel.Controls.Add(this.expotrButton);
            this.controlPanel.Controls.Add(this.historyButton);
            this.controlPanel.Controls.Add(this.clearTableButton);
            this.controlPanel.Location = new System.Drawing.Point(751, 449);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(228, 87);
            this.controlPanel.TabIndex = 35;
            // 
            // expotrButton
            // 
            this.expotrButton.BackColor = System.Drawing.Color.Pink;
            this.expotrButton.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.expotrButton.Location = new System.Drawing.Point(9, 16);
            this.expotrButton.Name = "expotrButton";
            this.expotrButton.Size = new System.Drawing.Size(59, 49);
            this.expotrButton.TabIndex = 11;
            this.expotrButton.Text = "导出Excel";
            this.expotrButton.UseVisualStyleBackColor = false;
            this.expotrButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.BackColor = System.Drawing.Color.Pink;
            this.historyButton.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyButton.Location = new System.Drawing.Point(74, 3);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(120, 35);
            this.historyButton.TabIndex = 10;
            this.historyButton.Text = "#历史数据#";
            this.historyButton.UseVisualStyleBackColor = false;
            this.historyButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // clearTableButton
            // 
            this.clearTableButton.BackColor = System.Drawing.Color.Pink;
            this.clearTableButton.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearTableButton.Location = new System.Drawing.Point(75, 44);
            this.clearTableButton.Name = "clearTableButton";
            this.clearTableButton.Size = new System.Drawing.Size(120, 35);
            this.clearTableButton.TabIndex = 9;
            this.clearTableButton.Text = "#清理数据#";
            this.clearTableButton.UseVisualStyleBackColor = false;
            this.clearTableButton.Click += new System.EventHandler(this.ClearTableButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("华文彩云", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(656, 449);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 19);
            this.label9.TabIndex = 8;
            this.label9.Text = "数据管理";
            // 
            // UserPort
            // 
            this.UserPort.BaudRate = 115200;
            this.UserPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.UserPort_DataReceived);
            // 
            // skipPanel
            // 
            this.skipPanel.BackColor = System.Drawing.Color.Transparent;
            this.skipPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skipPanel.Controls.Add(this.skipButton2);
            this.skipPanel.Controls.Add(this.skipButton1);
            this.skipPanel.Location = new System.Drawing.Point(526, 480);
            this.skipPanel.Name = "skipPanel";
            this.skipPanel.Size = new System.Drawing.Size(213, 56);
            this.skipPanel.TabIndex = 36;
            // 
            // skipButton2
            // 
            this.skipButton2.BackColor = System.Drawing.Color.Black;
            this.skipButton2.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skipButton2.ForeColor = System.Drawing.Color.White;
            this.skipButton2.Location = new System.Drawing.Point(137, 10);
            this.skipButton2.Name = "skipButton2";
            this.skipButton2.Size = new System.Drawing.Size(68, 33);
            this.skipButton2.TabIndex = 38;
            this.skipButton2.Text = "AI帮助";
            this.skipButton2.UseVisualStyleBackColor = false;
            this.skipButton2.Click += new System.EventHandler(this.SkipButton2_Click);
            // 
            // skipButton1
            // 
            this.skipButton1.BackColor = System.Drawing.Color.Black;
            this.skipButton1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skipButton1.ForeColor = System.Drawing.Color.White;
            this.skipButton1.Location = new System.Drawing.Point(3, 10);
            this.skipButton1.Name = "skipButton1";
            this.skipButton1.Size = new System.Drawing.Size(126, 33);
            this.skipButton1.TabIndex = 11;
            this.skipButton1.Text = "模块管理界面";
            this.skipButton1.UseVisualStyleBackColor = false;
            this.skipButton1.Click += new System.EventHandler(this.SkipButton1_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("华文彩云", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(522, 456);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 19);
            this.label19.TabIndex = 37;
            this.label19.Text = "快捷功能";
            // 
            // triggerTimer
            // 
            this.triggerTimer.Interval = 11000;
            this.triggerTimer.Tick += new System.EventHandler(this.TriggerTimer_Tick);
            // 
            // linkUButton
            // 
            this.linkUButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.linkUButton.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkUButton.Location = new System.Drawing.Point(29, 98);
            this.linkUButton.Name = "linkUButton";
            this.linkUButton.Size = new System.Drawing.Size(93, 27);
            this.linkUButton.TabIndex = 37;
            this.linkUButton.Text = "连接网络";
            this.linkUButton.UseVisualStyleBackColor = false;
            this.linkUButton.Click += new System.EventHandler(this.LinkUButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("楷体", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(14, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(309, 29);
            this.label15.TabIndex = 38;
            this.label15.Text = "xxx的适宜度评价系统";
            // 
            // inspectTimer
            // 
            this.inspectTimer.Interval = 4000;
            this.inspectTimer.Tick += new System.EventHandler(this.InspectTimer_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(275, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 40;
            this.label6.Text = "当前节点";
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.YellowGreen;
            this.setButton.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setButton.Location = new System.Drawing.Point(413, 15);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(84, 27);
            this.setButton.TabIndex = 31;
            this.setButton.Text = "设置参数";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // baudBox
            // 
            this.baudBox.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.baudBox.FormattingEnabled = true;
            this.baudBox.Location = new System.Drawing.Point(205, 18);
            this.baudBox.Name = "baudBox";
            this.baudBox.Size = new System.Drawing.Size(64, 24);
            this.baudBox.TabIndex = 38;
            this.baudBox.SelectedIndexChanged += new System.EventHandler(this.BaudBox_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("华文彩云", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(12, 461);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 17);
            this.label14.TabIndex = 33;
            this.label14.Text = "ZigBee远程配置";
            // 
            // netTreeView
            // 
            this.netTreeView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.netTreeView.Location = new System.Drawing.Point(15, 177);
            this.netTreeView.Name = "netTreeView";
            this.netTreeView.Size = new System.Drawing.Size(136, 260);
            this.netTreeView.TabIndex = 32;
            this.netTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.NetTreeView_AfterSelect);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(144, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 16);
            this.label23.TabIndex = 39;
            this.label23.Text = "波特率";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.White;
            this.label24.Font = new System.Drawing.Font("华文彩云", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(16, 157);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(121, 17);
            this.label24.TabIndex = 31;
            this.label24.Text = "ZigBee网络拓扑";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(2, 21);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(71, 16);
            this.label25.TabIndex = 35;
            this.label25.Text = "节点类型";
            // 
            // showPanel
            // 
            this.showPanel.BackColor = System.Drawing.Color.Ivory;
            this.showPanel.Controls.Add(this.infoPanel);
            this.showPanel.Location = new System.Drawing.Point(159, 95);
            this.showPanel.Name = "showPanel";
            this.showPanel.Size = new System.Drawing.Size(485, 341);
            this.showPanel.TabIndex = 0;
            this.showPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ShowPanel_Paint);
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.GreenYellow;
            this.infoPanel.Controls.Add(this.roLabel);
            this.infoPanel.Controls.Add(this.coLabel);
            this.infoPanel.Controls.Add(this.idLabel);
            this.infoPanel.Controls.Add(this.edLabel);
            this.infoPanel.Controls.Add(this.idSLabel);
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(485, 26);
            this.infoPanel.TabIndex = 42;
            // 
            // roLabel
            // 
            this.roLabel.AutoSize = true;
            this.roLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roLabel.Location = new System.Drawing.Point(262, 3);
            this.roLabel.Name = "roLabel";
            this.roLabel.Size = new System.Drawing.Size(119, 16);
            this.roLabel.TabIndex = 44;
            this.roLabel.Text = "路由器R-蓝绿色";
            // 
            // coLabel
            // 
            this.coLabel.AutoSize = true;
            this.coLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.coLabel.Location = new System.Drawing.Point(150, 3);
            this.coLabel.Name = "coLabel";
            this.coLabel.Size = new System.Drawing.Size(103, 16);
            this.coLabel.TabIndex = 43;
            this.coLabel.Text = "协调器C-橘色";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.idLabel.Location = new System.Drawing.Point(11, 3);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(71, 16);
            this.idLabel.TabIndex = 42;
            this.idLabel.Text = "本网络号";
            // 
            // edLabel
            // 
            this.edLabel.AutoSize = true;
            this.edLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.edLabel.Location = new System.Drawing.Point(387, 3);
            this.edLabel.Name = "edLabel";
            this.edLabel.Size = new System.Drawing.Size(87, 16);
            this.edLabel.TabIndex = 45;
            this.edLabel.Text = "终端E-棕色";
            // 
            // idSLabel
            // 
            this.idSLabel.AutoSize = true;
            this.idSLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.idSLabel.ForeColor = System.Drawing.Color.Red;
            this.idSLabel.Location = new System.Drawing.Point(88, 3);
            this.idSLabel.Name = "idSLabel";
            this.idSLabel.Size = new System.Drawing.Size(55, 16);
            this.idSLabel.TabIndex = 46;
            this.idSLabel.Text = "0xFFFF";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.White;
            this.label26.Font = new System.Drawing.Font("华文彩云", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(155, 73);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(164, 19);
            this.label26.TabIndex = 30;
            this.label26.Text = "ZigBee网络可视化";
            // 
            // devTypeBox
            // 
            this.devTypeBox.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.devTypeBox.FormattingEnabled = true;
            this.devTypeBox.Location = new System.Drawing.Point(74, 18);
            this.devTypeBox.Name = "devTypeBox";
            this.devTypeBox.Size = new System.Drawing.Size(64, 24);
            this.devTypeBox.TabIndex = 34;
            this.devTypeBox.SelectedIndexChanged += new System.EventHandler(this.DevTypeBox_SelectedIndexChanged);
            // 
            // configPanel
            // 
            this.configPanel.BackColor = System.Drawing.Color.Transparent;
            this.configPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.configPanel.Controls.Add(this.tarLabel);
            this.configPanel.Controls.Add(this.label25);
            this.configPanel.Controls.Add(this.devTypeBox);
            this.configPanel.Controls.Add(this.label23);
            this.configPanel.Controls.Add(this.baudBox);
            this.configPanel.Controls.Add(this.label6);
            this.configPanel.Controls.Add(this.setButton);
            this.configPanel.Location = new System.Drawing.Point(12, 481);
            this.configPanel.Name = "configPanel";
            this.configPanel.Size = new System.Drawing.Size(501, 55);
            this.configPanel.TabIndex = 42;
            // 
            // tarLabel
            // 
            this.tarLabel.AutoSize = true;
            this.tarLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tarLabel.ForeColor = System.Drawing.Color.Red;
            this.tarLabel.Location = new System.Drawing.Point(352, 21);
            this.tarLabel.Name = "tarLabel";
            this.tarLabel.Size = new System.Drawing.Size(23, 16);
            this.tarLabel.TabIndex = 41;
            this.tarLabel.Text = "无";
            // 
            // replyBox
            // 
            this.replyBox.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.replyBox.Location = new System.Drawing.Point(654, 177);
            this.replyBox.Multiline = true;
            this.replyBox.Name = "replyBox";
            this.replyBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.replyBox.Size = new System.Drawing.Size(328, 44);
            this.replyBox.TabIndex = 46;
            this.replyBox.Text = "此处会显示由AI模型评价过程中的回答。";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(994, 567);
            this.Controls.Add(this.replyBox);
            this.Controls.Add(this.skipPanel);
            this.Controls.Add(this.configPanel);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.netTreeView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.showPanel);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.linkUButton);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.levelPanel);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户主界面";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserForm_FormClosed);
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.dataPanel.ResumeLayout(false);
            this.dataPanel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.levelPanel.ResumeLayout(false);
            this.levelPanel.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.skipPanel.ResumeLayout(false);
            this.showPanel.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.configPanel.ResumeLayout(false);
            this.configPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer showTimer;
        private System.Windows.Forms.Panel levelPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button clearTableButton;
        private System.Windows.Forms.Button historyButton;
        private System.IO.Ports.SerialPort UserPort;
        private System.Windows.Forms.Panel skipPanel;
        private System.Windows.Forms.Button skipButton1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button skipButton2;
        private System.Windows.Forms.Label co2Label;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label airHumiLabel;
        private System.Windows.Forms.Label humiLabel;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lightLabel;
        private System.Windows.Forms.Timer triggerTimer;
        private System.Windows.Forms.Button linkUButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button expotrButton;
        private System.Windows.Forms.Timer inspectTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.ComboBox baudBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TreeView netTreeView;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel showPanel;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox devTypeBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label coLabel;
        private System.Windows.Forms.Label roLabel;
        private System.Windows.Forms.Label edLabel;
        private System.Windows.Forms.Label idSLabel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Panel configPanel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Label phLabel;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label tarLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label airTempLabel;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox replyBox;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    }
}
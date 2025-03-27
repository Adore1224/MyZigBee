namespace ProjApp
{
    partial class NetworkForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetworkForm));
            this.netPanel = new System.Windows.Forms.Panel();
            this.tarLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.setButton = new System.Windows.Forms.Button();
            this.baudBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.netTreeView = new System.Windows.Forms.TreeView();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.showPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.devTypeBox = new System.Windows.Forms.ComboBox();
            this.netidLabel = new System.Windows.Forms.Label();
            this.countCLabel = new System.Windows.Forms.Label();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.serialPort3 = new System.IO.Ports.SerialPort(this.components);
            this.inspectTimer2 = new System.Windows.Forms.Timer(this.components);
            this.inspectTimer1 = new System.Windows.Forms.Timer(this.components);
            this.idLabel = new System.Windows.Forms.Label();
            this.coLabel = new System.Windows.Forms.Label();
            this.roLabel = new System.Windows.Forms.Label();
            this.coCLabel = new System.Windows.Forms.Label();
            this.roCLabel = new System.Windows.Forms.Label();
            this.edCLabel = new System.Windows.Forms.Label();
            this.edLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.linkNetBtn = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.netPanel.SuspendLayout();
            this.showPanel.SuspendLayout();
            this.statusStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // netPanel
            // 
            this.netPanel.BackColor = System.Drawing.Color.Linen;
            this.netPanel.Controls.Add(this.tarLabel);
            this.netPanel.Controls.Add(this.label6);
            this.netPanel.Controls.Add(this.setButton);
            this.netPanel.Controls.Add(this.baudBox);
            this.netPanel.Controls.Add(this.label4);
            this.netPanel.Controls.Add(this.netTreeView);
            this.netPanel.Controls.Add(this.label5);
            this.netPanel.Controls.Add(this.label2);
            this.netPanel.Controls.Add(this.label7);
            this.netPanel.Controls.Add(this.showPanel);
            this.netPanel.Controls.Add(this.devTypeBox);
            this.netPanel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.netPanel.Location = new System.Drawing.Point(0, 89);
            this.netPanel.Name = "netPanel";
            this.netPanel.Size = new System.Drawing.Size(809, 415);
            this.netPanel.TabIndex = 0;
            // 
            // tarLabel
            // 
            this.tarLabel.AutoSize = true;
            this.tarLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tarLabel.Location = new System.Drawing.Point(91, 367);
            this.tarLabel.Name = "tarLabel";
            this.tarLabel.Size = new System.Drawing.Size(24, 16);
            this.tarLabel.TabIndex = 41;
            this.tarLabel.Text = "无";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(3, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 40;
            this.label6.Text = "目前节点";
            // 
            // setButton
            // 
            this.setButton.BackColor = System.Drawing.Color.YellowGreen;
            this.setButton.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setButton.Location = new System.Drawing.Point(30, 385);
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
            this.baudBox.Location = new System.Drawing.Point(75, 340);
            this.baudBox.Name = "baudBox";
            this.baudBox.Size = new System.Drawing.Size(64, 24);
            this.baudBox.TabIndex = 38;
            this.baudBox.SelectedIndexChanged += new System.EventHandler(this.BaudBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(3, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 14);
            this.label4.TabIndex = 33;
            this.label4.Text = "ZigBee节点远程配置";
            // 
            // netTreeView
            // 
            this.netTreeView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.netTreeView.Location = new System.Drawing.Point(3, 27);
            this.netTreeView.Name = "netTreeView";
            this.netTreeView.Size = new System.Drawing.Size(136, 260);
            this.netTreeView.TabIndex = 32;
            this.netTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.NetTreeView_AfterSelect);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(14, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "波特率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 14);
            this.label2.TabIndex = 31;
            this.label2.Text = "ZigBee网络拓扑信息";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(3, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 35;
            this.label7.Text = "节点类型";
            // 
            // showPanel
            // 
            this.showPanel.BackColor = System.Drawing.Color.Ivory;
            this.showPanel.Controls.Add(this.label1);
            this.showPanel.Location = new System.Drawing.Point(142, 0);
            this.showPanel.Name = "showPanel";
            this.showPanel.Size = new System.Drawing.Size(667, 415);
            this.showPanel.TabIndex = 0;
            this.showPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ShowPanel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 30;
            this.label1.Text = "ZigBee网络拓扑图";
            // 
            // devTypeBox
            // 
            this.devTypeBox.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.devTypeBox.FormattingEnabled = true;
            this.devTypeBox.Location = new System.Drawing.Point(75, 310);
            this.devTypeBox.Name = "devTypeBox";
            this.devTypeBox.Size = new System.Drawing.Size(64, 24);
            this.devTypeBox.TabIndex = 34;
            this.devTypeBox.SelectedIndexChanged += new System.EventHandler(this.DevTypeBox_SelectedIndexChanged);
            // 
            // netidLabel
            // 
            this.netidLabel.AutoSize = true;
            this.netidLabel.Font = new System.Drawing.Font("宋体", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.netidLabel.Location = new System.Drawing.Point(26, 24);
            this.netidLabel.Name = "netidLabel";
            this.netidLabel.Size = new System.Drawing.Size(69, 19);
            this.netidLabel.TabIndex = 2;
            this.netidLabel.Text = "网络号";
            // 
            // countCLabel
            // 
            this.countCLabel.AutoSize = true;
            this.countCLabel.Font = new System.Drawing.Font("幼圆", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.countCLabel.ForeColor = System.Drawing.Color.Crimson;
            this.countCLabel.Location = new System.Drawing.Point(430, 40);
            this.countCLabel.Name = "countCLabel";
            this.countCLabel.Size = new System.Drawing.Size(20, 20);
            this.countCLabel.TabIndex = 0;
            this.countCLabel.Text = "0";
            // 
            // statusStrip3
            // 
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip3.Location = new System.Drawing.Point(0, 504);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(809, 22);
            this.statusStrip3.TabIndex = 2;
            this.statusStrip3.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "系统时间：";
            // 
            // serialPort3
            // 
            this.serialPort3.BaudRate = 38400;
            this.serialPort3.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort3_DataReceived);
            // 
            // inspectTimer2
            // 
            this.inspectTimer2.Interval = 4000;
            this.inspectTimer2.Tick += new System.EventHandler(this.InspectTimer2_Tick);
            // 
            // inspectTimer1
            // 
            this.inspectTimer1.Interval = 1000;
            this.inspectTimer1.Tick += new System.EventHandler(this.InspectTimer1_Tick);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.idLabel.Location = new System.Drawing.Point(39, 43);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(43, 16);
            this.idLabel.TabIndex = 3;
            this.idLabel.Text = "FFFF";
            // 
            // coLabel
            // 
            this.coLabel.AutoSize = true;
            this.coLabel.Font = new System.Drawing.Font("宋体", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.coLabel.Location = new System.Drawing.Point(118, 24);
            this.coLabel.Name = "coLabel";
            this.coLabel.Size = new System.Drawing.Size(80, 19);
            this.coLabel.TabIndex = 4;
            this.coLabel.Text = "协调器C";
            // 
            // roLabel
            // 
            this.roLabel.AutoSize = true;
            this.roLabel.Font = new System.Drawing.Font("宋体", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roLabel.Location = new System.Drawing.Point(218, 24);
            this.roLabel.Name = "roLabel";
            this.roLabel.Size = new System.Drawing.Size(80, 19);
            this.roLabel.TabIndex = 5;
            this.roLabel.Text = "路由器R";
            // 
            // coCLabel
            // 
            this.coCLabel.AutoSize = true;
            this.coCLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.coCLabel.Location = new System.Drawing.Point(146, 43);
            this.coCLabel.Name = "coCLabel";
            this.coCLabel.Size = new System.Drawing.Size(16, 16);
            this.coCLabel.TabIndex = 6;
            this.coCLabel.Text = "0";
            // 
            // roCLabel
            // 
            this.roCLabel.AutoSize = true;
            this.roCLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roCLabel.Location = new System.Drawing.Point(244, 43);
            this.roCLabel.Name = "roCLabel";
            this.roCLabel.Size = new System.Drawing.Size(16, 16);
            this.roCLabel.TabIndex = 7;
            this.roCLabel.Text = "0";
            // 
            // edCLabel
            // 
            this.edCLabel.AutoSize = true;
            this.edCLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.edCLabel.Location = new System.Drawing.Point(335, 43);
            this.edCLabel.Name = "edCLabel";
            this.edCLabel.Size = new System.Drawing.Size(16, 16);
            this.edCLabel.TabIndex = 9;
            this.edCLabel.Text = "0";
            // 
            // edLabel
            // 
            this.edLabel.AutoSize = true;
            this.edLabel.Font = new System.Drawing.Font("宋体", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.edLabel.Location = new System.Drawing.Point(318, 24);
            this.edLabel.Name = "edLabel";
            this.edLabel.Size = new System.Drawing.Size(60, 19);
            this.edLabel.TabIndex = 8;
            this.edLabel.Text = "终端E";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.countLabel.ForeColor = System.Drawing.Color.Crimson;
            this.countLabel.Location = new System.Drawing.Point(396, 10);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(93, 20);
            this.countLabel.TabIndex = 10;
            this.countLabel.Text = "总节点数";
            // 
            // linkNetBtn
            // 
            this.linkNetBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.linkNetBtn.Location = new System.Drawing.Point(106, 34);
            this.linkNetBtn.Name = "linkNetBtn";
            this.linkNetBtn.Size = new System.Drawing.Size(95, 26);
            this.linkNetBtn.TabIndex = 0;
            this.linkNetBtn.Text = "连接网络";
            this.linkNetBtn.UseVisualStyleBackColor = false;
            this.linkNetBtn.Click += new System.EventHandler(this.LinkNetBtn_Click);
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.Color.Pink;
            this.helpButton.Location = new System.Drawing.Point(207, 36);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(67, 23);
            this.helpButton.TabIndex = 2;
            this.helpButton.Text = "帮助";
            this.helpButton.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 80);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // infoPanel
            // 
            this.infoPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.infoPanel.Controls.Add(this.label3);
            this.infoPanel.Controls.Add(this.countLabel);
            this.infoPanel.Controls.Add(this.countCLabel);
            this.infoPanel.Controls.Add(this.edCLabel);
            this.infoPanel.Controls.Add(this.edLabel);
            this.infoPanel.Controls.Add(this.roCLabel);
            this.infoPanel.Controls.Add(this.netidLabel);
            this.infoPanel.Controls.Add(this.roLabel);
            this.infoPanel.Controls.Add(this.coCLabel);
            this.infoPanel.Controls.Add(this.idLabel);
            this.infoPanel.Controls.Add(this.coLabel);
            this.infoPanel.Location = new System.Drawing.Point(292, 12);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(505, 70);
            this.infoPanel.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 14);
            this.label3.TabIndex = 32;
            this.label3.Text = "ZigBee网络信息统计";
            // 
            // NetworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(809, 526);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.linkNetBtn);
            this.Controls.Add(this.statusStrip3);
            this.Controls.Add(this.netPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NetworkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H∞ ZigBee-ZigBee网络";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NetworkForm_FormClosed);
            this.Load += new System.EventHandler(this.NetworkForm_Load);
            this.netPanel.ResumeLayout(false);
            this.netPanel.PerformLayout();
            this.showPanel.ResumeLayout(false);
            this.showPanel.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel netPanel;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.IO.Ports.SerialPort serialPort3;
        private System.Windows.Forms.Timer inspectTimer2;
        private System.Windows.Forms.Timer inspectTimer1;
        private System.Windows.Forms.Panel showPanel;
        private System.Windows.Forms.Label countCLabel;
        private System.Windows.Forms.Label netidLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label coLabel;
        private System.Windows.Forms.Label edCLabel;
        private System.Windows.Forms.Label edLabel;
        private System.Windows.Forms.Label roCLabel;
        private System.Windows.Forms.Label coCLabel;
        private System.Windows.Forms.Label roLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Button linkNetBtn;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView netTreeView;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox baudBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox devTypeBox;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label tarLabel;
    }
}
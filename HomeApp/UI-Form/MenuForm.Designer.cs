namespace MyApp
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.manageButton = new System.Windows.Forms.Button();
            this.mainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // manageButton
            // 
            this.manageButton.BackColor = System.Drawing.Color.PowderBlue;
            this.manageButton.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.manageButton.Location = new System.Drawing.Point(259, 214);
            this.manageButton.Name = "manageButton";
            this.manageButton.Size = new System.Drawing.Size(182, 43);
            this.manageButton.TabIndex = 2;
            this.manageButton.Text = "*模块管理界面*";
            this.manageButton.UseVisualStyleBackColor = false;
            this.manageButton.Click += new System.EventHandler(this.ManageButton_Click);
            // 
            // mainButton
            // 
            this.mainButton.BackColor = System.Drawing.Color.PowderBlue;
            this.mainButton.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainButton.Location = new System.Drawing.Point(41, 214);
            this.mainButton.Name = "mainButton";
            this.mainButton.Size = new System.Drawing.Size(182, 43);
            this.mainButton.TabIndex = 0;
            this.mainButton.Text = "*用户主界面*";
            this.mainButton.UseVisualStyleBackColor = false;
            this.mainButton.Click += new System.EventHandler(this.MainButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 279);
            this.Controls.Add(this.mainButton);
            this.Controls.Add(this.manageButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "菜单界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button manageButton;
        private System.Windows.Forms.Button mainButton;
    }
}
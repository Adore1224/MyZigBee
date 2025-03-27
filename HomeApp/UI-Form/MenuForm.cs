using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public partial class MenuForm : Form
    {
        public MenuForm() //构造器
        {
            InitializeComponent(); //初始化界面控件
        }
        /* 菜单窗口被关闭时的处理函数 */
        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e) //点击关闭本窗口时
        {
            Application.Exit(); //强制退出应用程序
        }
        /* "ZigBee模块管理"按钮被点击时的处理函数 */
        private void ManageButton_Click(object sender, EventArgs e)
        {
            //创建实例时传递MenuForm的实例，实现在ManageForm中调用这个实例
            ManageForm manageForm = new ManageForm();
            manageForm.Show(); //显示管理窗口
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            //创建实例时传递MenuForm的实例，实现在UserForm中调用这个实例
            UserForm userForm = new UserForm(this);
            userForm.Show(); //显示主界面窗口
            this.WindowState = FormWindowState.Minimized; //最小化菜单窗口
        }
    }
}

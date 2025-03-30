using System;
using System.Windows.Forms;
using MyApp.My_Class;

namespace MyApp.UI_Form
{
    public partial class AiForm : Form
    {
        private AiHelper aiHelp; 
        public AiForm()
        {
            InitializeComponent();
            //启动AI服务，为后续使用AI作准备
            aiHelp = new AiHelper();
        }
        /* 向AI提问后确认发送的按钮被点击时的处理函数 */
        private async void Button1_Click(object sender, System.EventArgs e)
        {
            //从输入框中获取输入的问题
            string question = inputBox.Text;
            if (string.IsNullOrWhiteSpace(question))
            {
                MessageBox.Show("请输入问题", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                inputBox.Clear();
                //获取当前时间并格式化为字符串
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //将用户的问题和时间戳追加到输出框中
                outputBox.AppendText($"[{timestamp}] User: {question}\r\n");
                //解析Ai大模型对应Json格式的数据包
                AiHelpRe response = await aiHelp.AskQuestionAsync(question);
                //将Ai响应的回答结果显示在对应文本框中
                outputBox.AppendText($"[{timestamp}] AI: {response.Result}\r\n");
            }
            catch (Exception ex)
            {
                // 处理异常，例如显示错误消息  
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //检查是否按下了 Enter 键
            if (e.KeyChar == (char)Keys.Enter)
            {
                //调用 Button1_Click 方法
                Button1_Click(sender, e);
                //阻止默认行为（如换行）
                e.Handled = true;
            }
        }
        /* "清空对话框"按钮被点击时的处理函数 */
        private void Button3_Click(object sender, EventArgs e)
        {
            outputBox.Clear();
        }
    }
}

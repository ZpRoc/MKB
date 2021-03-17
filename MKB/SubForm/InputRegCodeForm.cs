using System;
using System.IO;
using System.Windows.Forms;


namespace MKB.SubForm
{
    public partial class InputRegCodeForm : Form
    {
        public InputRegCodeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确定 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                // 将注册码写入 ket.txt 文件
                FileStream fs   = new FileStream(@"key.txt", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(textBoxRegCode.Text);
                sw.Flush();
                sw.Close();
                fs.Close();

                // 关闭窗体并返回
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 取消 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // 关闭窗体并返回
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

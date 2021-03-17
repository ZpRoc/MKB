using System;
using System.Windows.Forms;

using MKB.DataHandle;


namespace MKB.SubForm
{
    public partial class GrpConfigForm : Form
    {
        // 命令组 配置类
        public GrpConfig m_grpConfig = new GrpConfig();

        public GrpConfigForm()
        {
            InitializeComponent();

            // 相关控件初始化
            ComponentInitialization();
        }

        public GrpConfigForm(GrpConfig grpConfig)
        {
            InitializeComponent();

            // 相关控件初始化
            ComponentInitialization();

            // 若指定 grpConfig，则给相关控件赋值
            m_grpConfig = grpConfig;
            SetComponent(m_grpConfig);
        }

        // -------------------------------------------------------------------------------- //
        // --------------------------- ComponentInitialization ---------------------------- //
        // -------------------------------------------------------------------------------- //

        private void ComponentInitialization()
        {
            
        }


        // -------------------------------------------------------------------------------- //
        // ------------------------------------ Events ------------------------------------ //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 确定 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                // 简单的保护，后续可优化
                if (Convert.ToInt32(numericUpDownTimes.Value) < 0)
                {
                    MessageBox.Show("输入有误！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // 控件属性转 GrpConfig 类型
                    m_grpConfig = GetComponent();

                    // 关闭窗体并返回
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 窗体键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrpConfigForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // 回车按键，直接点击确定
                if (e.KeyCode == Keys.Enter)
                {
                    buttonOK_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------------------------------------------------------- //
        // ---------------------------------- Functions ----------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 设置相关控件的属性
        /// </summary>
        /// <param name="grpConfig"></param>
        public void SetComponent(GrpConfig grpConfig)
        {
            numericUpDownTimes.Value = m_grpConfig.m_times;
            textBoxDescr.Text        = m_grpConfig.m_descr;
        }

        /// <summary>
        /// 获取相关控件的属性
        /// </summary>
        /// <returns></returns>
        public GrpConfig GetComponent()
        {
            return new GrpConfig(Convert.ToInt32(numericUpDownTimes.Value), textBoxDescr.Text);
        }
    }
}

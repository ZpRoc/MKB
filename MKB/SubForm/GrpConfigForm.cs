using System;
using System.Linq;
using System.Windows.Forms;

using MKB.DataHandle;


namespace MKB.SubForm
{
    public partial class GrpConfigForm : Form
    {
        // 命令组 配置类
        public GrpConfig m_grpConfig = new GrpConfig();

        // 常量
        public static readonly string[] m_PARAMs = {"Text", "Descr", "PosX", "PosY", "Delay"};

        public GrpConfigForm()
        {
            InitializeComponent();

            // 相关控件初始化
            ComponentInitialization();

            // 循环次数 值改变事件
            numericUpDownTimes_ValueChanged(null, null);
        }

        public GrpConfigForm(GrpConfig grpConfig, TreeNode treeNode)
        {
            InitializeComponent();

            // 相关控件初始化
            ComponentInitialization();

            // 若指定 grpConfig 和 treeNode，则给相关控件赋值
            m_grpConfig = grpConfig;
            SetComponent(m_grpConfig, treeNode);

            // 循环次数 值改变事件
            numericUpDownTimes_ValueChanged(null, null);
        }

        // --------------------------- ComponentInitialization ---------------------------- //
        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //

        private void ComponentInitialization()
        {
            comboBoxParam.Items.AddRange(m_PARAMs);
            comboBoxParam.SelectedIndex = 0;
        }

        // ------------------------------ 保护循环参数输入正确 ------------------------------- //
        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 判断输入是否正确，更新计算 Delta
        /// labelIndexDelta.Tag = new string[] { "Δ= ", "Δ= 无效", "Δ= 非数值", "Δ= 非整型" };
        /// </summary>
        /// <returns></returns>
        private string UpdateDelta()
        {
            // 循环，循环次数大于 1
            if (Convert.ToInt32(numericUpDownTimes.Value) > 1)
            {
                // 控件使能
                textBoxIndexS.Enabled     = true;
                textBoxIndexE.Enabled     = true;
                labelIndexDelta.Enabled   = true;
                comboBoxParamPos.Enabled  = true;
                buttonParamPosAdd.Enabled = true;
                buttonParamPosDel.Enabled = true;
                comboBoxCmd.Enabled       = true;
                comboBoxParam.Enabled     = true;

                // 数值转换
                if (!(int.TryParse(textBoxIndexS.Text, out int indexS) && int.TryParse(textBoxIndexE.Text, out int indexE)))
                {
                    labelIndexDelta.Text = ((string[])labelIndexDelta.Tag)[2];
                    return "循环索引为非数值，输入有误！";
                }

                // 计算 Delta
                int div = Convert.ToInt32(numericUpDownTimes.Value) - 1;
                if (div != 0 && (indexE - indexS) % div == 0)
                {
                    labelIndexDelta.Text = ((string[])labelIndexDelta.Tag)[0] + ((indexE - indexS) / div).ToString();
                }
                else
                {
                    labelIndexDelta.Text = ((string[])labelIndexDelta.Tag)[3];
                    return "Delta 为非整型数据，输入有误！";
                }
            }
            // 不循环，循环次数为 1
            else
            {
                // 控件使能
                textBoxIndexS.Enabled     = false;
                textBoxIndexE.Enabled     = false;
                labelIndexDelta.Enabled   = false;
                comboBoxParamPos.Enabled  = false;
                buttonParamPosAdd.Enabled = false;
                buttonParamPosDel.Enabled = false;
                comboBoxCmd.Enabled       = false;
                comboBoxParam.Enabled     = false;

                // 控件幅值
                textBoxIndexS.Text   = textBoxIndexS.Tag.ToString();
                textBoxIndexE.Text   = textBoxIndexE.Tag.ToString();
                labelIndexDelta.Text = ((string[])labelIndexDelta.Tag)[1];
                comboBoxParamPos.Items.Clear();
            }

            return null;
        }

        /// <summary>
        /// 循环次数 值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownTimes_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateDelta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 起始索引 值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxIndexS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateDelta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 终止索引 值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxIndexE_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateDelta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------ Events ------------------------------------ //
        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 添加参数位置 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonParamPos_Click(object sender, EventArgs e)
        {
            try
            {
                // 防止 comboBoxCmd 或 comboBoxParam 为空
                if (comboBoxCmd.Text == null || comboBoxParam.Text == null)
                {
                    MessageBox.Show("参数为空！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // comboBoxParamPos.Items.Add
                string str = comboBoxCmd.Text.Substring(0, 4) + comboBoxParam.Text;
                if (!comboBoxParamPos.Items.Contains(str))
                {
                    comboBoxParamPos.Items.Add(str);
                    comboBoxParamPos.SelectedItem = str;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 删除参数位置 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonParamPosDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 防止 comboBoxParamPos 为空
                if (comboBoxParamPos.Text == null)
                {
                    MessageBox.Show("参数为空！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // comboBoxParamPos.Items.Remove
                comboBoxParamPos.Items.Remove(comboBoxParamPos.Text);
                if (comboBoxParamPos.Items.Count > 0)
                    comboBoxParamPos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                // 简单的保护，后续可优化
                if (Convert.ToInt32(numericUpDownTimes.Value) > 1 && ((string[])labelIndexDelta.Tag).Contains(labelIndexDelta.Text))
                {
                    MessageBox.Show("循环次数或循环索引输入有误！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Esc 直接关闭窗口
                else if (e.KeyCode == Keys.Escape)
                {
                    buttonCancel_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------- Functions ----------------------------------- //
        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 设置相关控件的属性
        /// </summary>
        /// <param name="grpConfig"></param>
        /// <param name="treeNode"></param>
        public void SetComponent(GrpConfig grpConfig, TreeNode treeNode)
        {
            // 常规控件
            numericUpDownTimes.Value = m_grpConfig.m_times;
            textBoxIndexS.Text       = m_grpConfig.m_indexS.ToString();
            textBoxIndexE.Text       = m_grpConfig.m_indexE.ToString();
            textBoxDescr.Text        = m_grpConfig.m_descr;

            // ParamPos 已经指定的循环参数位置
            comboBoxParamPos.Items.Clear();
            if (!string.IsNullOrWhiteSpace(m_grpConfig.m_paramPos))
            {
                foreach (string item in m_grpConfig.m_paramPos.Split(m_grpConfig.m_SEG_CHAR))
                {
                    comboBoxParamPos.Items.Add(item.ToString());
                }
            }
            if (comboBoxParamPos.Items.Count > 0)
            {
                comboBoxParamPos.SelectedIndex = 0;
            }

            // Group 里存在的所有命令列表
            comboBoxCmd.Items.Clear();
            if (treeNode.Nodes.Count > 0)
            {
                foreach (TreeNode node in treeNode.Nodes)
                {
                    comboBoxCmd.Items.Add(node.Text);
                }
            }
            if (comboBoxCmd.Items.Count > 0)
            {
                comboBoxCmd.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 获取相关控件的属性
        /// </summary>
        /// <returns></returns>
        public GrpConfig GetComponent()
        {
            int.TryParse(labelIndexDelta.Text.Substring(3, labelIndexDelta.Text.Length - 3), out int indexD);

            return new GrpConfig(Convert.ToInt32(numericUpDownTimes.Value), Convert.ToInt32(textBoxIndexS.Text),
                                    Convert.ToInt32(textBoxIndexE.Text), indexD,
                                    m_grpConfig.ItemToStr(comboBoxParamPos.Items), textBoxDescr.Text);
        }
    }
}

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

            // 若指定 grpConfig，则给相关控件赋值
            m_grpConfig = grpConfig;
            SetComponent(m_grpConfig);

            // 更新 comboBoxCmd 和 comboBoxParam
            UpdateComboBox(treeNode);

            // 循环次数 值改变事件
            numericUpDownTimes_ValueChanged(null, null);
        }

        // -------------------------------------------------------------------------------- //
        // --------------------------- ComponentInitialization ---------------------------- //
        // -------------------------------------------------------------------------------- //

        private void ComponentInitialization()
        {
            
        }

        private void UpdateComboBox(TreeNode treeNode)
        {
            comboBoxCmd.Items.Clear();
            foreach (TreeNode node in treeNode.Nodes)
            {
                comboBoxCmd.Items.Add(node.Text);
            }

            if (comboBoxParamPos.Items.Count > 0)       comboBoxParamPos.SelectedIndex = 0;
            if (comboBoxCmd.Items.Count      > 0)       comboBoxCmd.SelectedIndex      = 0;
            if (comboBoxParam.Items.Count    > 0)       comboBoxParam.SelectedIndex    = 0;
        }

        // -------------------------------------------------------------------------------- //
        // ------------------------------ 保护循环参数输入正确 ------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 判断输入是否正确，更新计算 Delta
        /// labelIndexDelta.Tag = new string[] { "Δ= ", "Δ= 无效", "Δ= 非数值", "Δ= 非整型" };
        /// </summary>
        /// <param name="toolTimes"></param>
        /// <param name="toolIndexS"></param>
        /// <param name="toolIndexE"></param>
        /// <param name="toolDelta"></param>
        /// <returns></returns>
        private string UpdateDelta(ref NumericUpDown toolTimes, ref TextBox toolIndexS, ref TextBox toolIndexE, ref Label toolDelta)
        {
            // 循环，循环次数大于 1
            if (Convert.ToInt32(toolTimes.Value) > 1)
            {
                // 控件使能
                toolIndexS.Enabled = true;
                toolIndexE.Enabled = true;
                toolDelta.Enabled  = true;

                // 数值转换
                int indexS = 0;
                int indexE = 0;
                if (!(int.TryParse(toolIndexS.Text, out indexS) && int.TryParse(toolIndexE.Text, out indexE)))
                {
                    toolDelta.Text = ((string[])toolDelta.Tag)[2];
                    return "循环索引为非数值，输入有误！";
                }

                // 计算 Delta
                int div = Convert.ToInt32(toolTimes.Value) - 1;
                if (div != 0 && (indexE - indexS) % div == 0)
                {
                    toolDelta.Text = ((string[])toolDelta.Tag)[0] + ((indexE - indexS) / div).ToString();
                }
                else
                {
                    toolDelta.Text = ((string[])toolDelta.Tag)[3];
                    return "Delta 为非整型数据，输入有误！";
                }
            }
            // 不循环，循环次数为 1
            else
            {
                // 控件使能
                toolIndexS.Enabled = false;
                toolIndexE.Enabled = false;
                toolDelta.Enabled  = false;

                // 控件幅值
                toolIndexS.Text = toolIndexS.Tag.ToString();
                toolIndexE.Text = toolIndexE.Tag.ToString();
                toolDelta.Text  = ((string[])toolDelta.Tag)[1];
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
                UpdateDelta(ref numericUpDownTimes, ref textBoxIndexS, ref textBoxIndexE, ref labelIndexDelta);
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
                UpdateDelta(ref numericUpDownTimes, ref textBoxIndexS, ref textBoxIndexE, ref labelIndexDelta);
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
                UpdateDelta(ref numericUpDownTimes, ref textBoxIndexS, ref textBoxIndexE, ref labelIndexDelta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------------------------------------------------------- //
        // ------------------------------------ Events ------------------------------------ //
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
                if (((string[])labelIndexDelta.Tag).Contains(labelIndexDelta.Text))
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
            textBoxIndexS.Text       = m_grpConfig.m_indexS;
            textBoxIndexE.Text       = m_grpConfig.m_indexE;
            textBoxDescr.Text        = m_grpConfig.m_descr;

            foreach (object item in m_grpConfig.m_paramPos)
            {
                comboBoxParamPos.Items.Add(item.ToString());
            }
        }

        /// <summary>
        /// 获取相关控件的属性
        /// </summary>
        /// <returns></returns>
        public GrpConfig GetComponent()
        {
            return new GrpConfig(Convert.ToInt32(numericUpDownTimes.Value), textBoxIndexS.Text, textBoxIndexE.Text,
                                 comboBoxParamPos.Items, textBoxDescr.Text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MKB.CtrlClass;

namespace MKB.SubForm
{
    public partial class CmdConfigForm : Form
    {
        // 命令配置类
        public CmdConfig m_cmdConfig = new CmdConfig();

        // 鼠标键盘控制类
        MouseControl m_mouseCtrl = new MouseControl();
        KeybdControl m_keybdCtrl = new KeybdControl();

        public CmdConfigForm()
        {
            InitializeComponent();

            // 相关控件初始化
            ComponentInitialization();
        }

        public CmdConfigForm(CmdConfig cmdConfig)
        {
            InitializeComponent();

            // 相关控件初始化
            ComponentInitialization();

            // 若指定 cmdConfig，则给相关控件赋值
            m_cmdConfig = cmdConfig;
            SetComponent(m_cmdConfig);
        }

        // -------------------------------------------------------------------------------- //
        // --------------------------- ComponentInitialization ---------------------------- //
        // -------------------------------------------------------------------------------- //

        public static readonly string[] m_TYPEs     = {"鼠标", "键盘"};
        public static readonly string[] m_MOUSE_OPs = {"移动", "左键单击", "左键双击", "右键单击"};
        public static readonly string[] m_KEYBD_OPs = {"文本输入", "组合键1", "组合键2"};
        public static readonly string[] m_TIMEs     = {"秒"};

        private void ComponentInitialization()
        {
            comboBoxType.Items.AddRange(m_TYPEs);
            comboBoxType.SelectedIndex = 0;

            comboBoxDelay.Items.AddRange(m_TIMEs);
            comboBoxDelay.SelectedIndex = 0;
        }

        // -------------------------------------------------------------------------------- //
        // ------------------------------------ Events ------------------------------------ //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 获取鼠标位置 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetMousePos_Click(object sender, EventArgs e)
        {
            try
            {
                // 只有聚焦在这个 button 上，才能触发 buttonGetMousePos_KeyDown 事件，以获取鼠标位置
                MessageBox.Show("将鼠标移动至目标位置后，按 Ctrl 键获取鼠标位置！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 键盘快捷键 主要用来捕获其他应用程序的鼠标位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetMousePos_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // 快捷键 Ctrl
                if (e.KeyCode == Keys.ControlKey)
                {
                    // 获取鼠标位置
                    Point pos = m_mouseCtrl.GetMousePos();

                    // 更新显示
                    textBoxPosX.Text = pos.X.ToString();
                    textBoxPosY.Text = pos.Y.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                if (Convert.ToDouble(textBoxPosX.Text) < 0 || Convert.ToDouble(textBoxPosY.Text) < 0 || Convert.ToDouble(textBoxDelay.Text) < 0)
                {
                    MessageBox.Show("输入有误！");
                    return;
                }
                else
                {
                    // 控件属性转 CmdConfig 类型
                    m_cmdConfig = GetComponent();

                    // 关闭窗体并返回
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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

        /// <summary>
        /// 类型 选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // ---------- 鼠标类型 更新操作列表 ---------- //
                if (comboBoxType.SelectedItem.ToString() == m_TYPEs[0])
                {
                    comboBoxOp.Items.Clear();
                    comboBoxOp.Items.AddRange(m_MOUSE_OPs);
                    comboBoxOp.SelectedIndex = 1;

                    textBoxOp.Text = string.Empty;
                }

                // ---------- 键盘类型 更新操作列表 ---------- //
                else if (comboBoxType.SelectedItem.ToString() == m_TYPEs[1])
                {
                    comboBoxOp.Items.Clear();
                    comboBoxOp.Items.AddRange(m_KEYBD_OPs);
                    comboBoxOp.SelectedIndex = 0;

                    textBoxOp.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 操作 选择改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxOp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // ---------- 文本输入 ---------- //
                if (comboBoxOp.SelectedItem.ToString() == m_KEYBD_OPs[0])
                {
                    textBoxOp.Text     = string.Empty;      // 清空文字
                    textBoxOp.Enabled  = true;              // 使能文本框输入
                    textBoxOp.ReadOnly = false;             // 可读写
                }

                // ---------- 组合键1 ---------- //
                else if (comboBoxOp.SelectedItem.ToString() == m_KEYBD_OPs[1])
                {
                    textBoxOp.Text     = string.Empty;      // 清空文字
                    textBoxOp.Enabled  = true;              // 禁止文本框输入
                    textBoxOp.ReadOnly = true;              // 只读

                    // 开启捕获快捷键组合
                    // 处理位于：textBoxOp_KeyDown 事件函数中
                }

                // ---------- 组合键2 ---------- //
                else if (comboBoxOp.SelectedItem.ToString() == m_KEYBD_OPs[2])
                {
                    textBoxOp.Text     = "Win+";            // 清空文字
                    textBoxOp.Enabled  = true;              // 禁止文本框输入
                    textBoxOp.ReadOnly = true;              // 只读

                    // 开启捕获快捷键组合
                    // 处理位于：textBoxOp_KeyDown 事件函数中
                }

                // ---------- 其他操作 ---------- //
                else
                {
                    textBoxOp.Enabled = false;      // 禁止文本框输入
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 捕获 快捷键组合 (可以设置一些会影响窗体的快捷键的特殊操作)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxOp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // -------------------- 组合键1 ------------------------------ //
                if (comboBoxOp.SelectedItem.ToString() == m_KEYBD_OPs[1] && textBoxOp.ReadOnly == true)
                {
                    // 一些会影响窗体的快捷键的特殊操作
                    if (e.Alt && e.KeyCode == Keys.F4)      // Alt + F4
                    {
                        e.Handled = true;
                    }

                    // 临时变量定义
                    string keyText   = string.Empty;                        // 保存临时文本，最终幅值给 textBox.Text
                    string[] keyStrs = e.KeyData.ToString().Split(',');     // 键值分解

                    // 判断第一个是否为字母或数字
                    if (!(keyStrs[0].Contains("Control") || keyStrs[0].Contains("Shift") || keyStrs[0].Contains("Menu")))
                    {
                        keyText += keyStrs[0];
                    }

                    // 组合键
                    if (e.Control)      keyText =  "Ctrl+" + keyText;
                    if (e.Shift)        keyText = "Shift+" + keyText;
                    if (e.Alt)          keyText =   "Alt+" + keyText;

                    // 更新显示
                    textBoxOp.Text = keyText;
                }

                // -------------------- 组合键2 ------------------------------ //
                else if (comboBoxOp.SelectedItem.ToString() == m_KEYBD_OPs[2] && textBoxOp.ReadOnly == true)
                {
                    if (e.Modifiers == Keys.None)           // 不接收 Ctrl Shift Alt 组合键
                    {
                        textBoxOp.Text = "Win+" + e.KeyCode.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 窗体键盘按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdConfigForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // 回车按键，直接点击确定
                if (e.KeyCode == Keys.Enter)
                {
                    // 非组合键1模式
                    if (!(comboBoxOp.SelectedItem.ToString() == m_KEYBD_OPs[1] && textBoxOp.ReadOnly == true && textBoxOp.Focused))
                    {
                        buttonOK_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // -------------------------------------------------------------------------------- //
        // ---------------------------------- Functions ----------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 设置相关控件的属性
        /// </summary>
        /// <param name="cmdConfig"></param>
        public void SetComponent(CmdConfig cmdConfig)
        {
            comboBoxType.SelectedItem  = cmdConfig.m_type;
            textBoxPosX.Text           = cmdConfig.m_posX;
            textBoxPosY.Text           = cmdConfig.m_posY;
            comboBoxOp.SelectedItem    = cmdConfig.m_op;
            textBoxOp.Text             = cmdConfig.m_text;
            textBoxDelay.Text          = cmdConfig.m_time;
            comboBoxDelay.SelectedItem = cmdConfig.m_unit;
            textBoxDescr.Text          = cmdConfig.m_descr;
        }

        /// <summary>
        /// 获取相关控件的属性
        /// </summary>
        /// <returns></returns>
        public CmdConfig GetComponent()
        {
            return(new CmdConfig(comboBoxType.SelectedItem.ToString(), textBoxPosX.Text.ToString(), textBoxPosY.Text.ToString(), 
                                 comboBoxOp.SelectedItem.ToString(), textBoxOp.Text.ToString(), textBoxDelay.Text.ToString(), 
                                 comboBoxDelay.SelectedItem.ToString(), textBoxDescr.Text.ToString()));
        }

        
    }
}

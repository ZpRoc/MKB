using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

using MKB.CtrlClass;
using MKB.Encryption;
using MKB.DataHandle;
using MKB.SubForm;


namespace MKB
{
    public partial class MainForm : Form
    {
        // 版本
        string m_dateVersion = "20210314";
        string m_pushVersion = "V1.2.2";

        // 是否过期
        string m_overtime  = string.Empty;
        bool m_isOutOfDate = true;

        // 鼠标键盘控制类
        MouseControl m_mouseCtrl = new MouseControl();
        KeybdControl m_keybdCtrl = new KeybdControl();

        // TreeViewMain
        TreeViewCtrl m_treeViewCtrl = new TreeViewCtrl();

        // 命令列表 & 命令运行标志
        List<CmdConfig> m_cmdConfigList = new List<CmdConfig>();
        int m_runStep      = 0;                 // 命令列表运行的步数
        int m_runStatus    = 1;                 // 0 表示延时状态，1 表示运行状态
        DateTime m_runTime = DateTime.Now;      // 用以记录命令运行结束的时间 (延时用)

        public MainForm()
        {
            InitializeComponent();

            m_overtime    = GetOverTime();
            m_isOutOfDate = IsOutOfDate(m_overtime);

        }

        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 定时器，主要运行的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerMain_Tick(object sender, EventArgs e)
        {
            try
            {
                if (m_runStatus == 1)
                {
                    // -------------------- 当前命令行 高亮 -------------------- //
                    this.Invoke(new EventHandler(delegate
                    {
                        // 取消先前的选中行状态 (ZpRoc 需要添加)


                        // 高亮当前选中行 (ZpRoc 需要添加)


                        // 滚动条设置 一个页面可显示 17 行
                        if (m_runStep > 16)
                        {
                            
                        }
                    }));

                    // -------------------- 鼠标 -------------------- //
                    if (m_cmdConfigList[m_runStep].m_type == CmdConfigForm.m_TYPEs[0])
                    {
                        // ---------- 移动 ---------- //
                        if (m_cmdConfigList[m_runStep].m_op == CmdConfigForm.m_MOUSE_OPs[0])
                        {
                            m_mouseCtrl.MouseMove(Convert.ToInt32(m_cmdConfigList[m_runStep].m_posX), Convert.ToInt32(m_cmdConfigList[m_runStep].m_posY));
                        }

                        // ---------- 左键单击 ---------- //
                        else if (m_cmdConfigList[m_runStep].m_op == CmdConfigForm.m_MOUSE_OPs[1])
                        {
                            m_mouseCtrl.MouseLeftClick(Convert.ToInt32(m_cmdConfigList[m_runStep].m_posX), Convert.ToInt32(m_cmdConfigList[m_runStep].m_posY));
                        }

                        // ---------- 左键双击 ---------- //
                        else if (m_cmdConfigList[m_runStep].m_op == CmdConfigForm.m_MOUSE_OPs[2])
                        {
                            m_mouseCtrl.MouseLeftDoubleClick(Convert.ToInt32(m_cmdConfigList[m_runStep].m_posX), Convert.ToInt32(m_cmdConfigList[m_runStep].m_posY));
                        }

                        // ---------- 右键单击 ---------- //
                        else if (m_cmdConfigList[m_runStep].m_op == CmdConfigForm.m_MOUSE_OPs[3])
                        {
                            m_mouseCtrl.MouseRightClick(Convert.ToInt32(m_cmdConfigList[m_runStep].m_posX), Convert.ToInt32(m_cmdConfigList[m_runStep].m_posY));
                        }

                        // ---------- 更新状态 ---------- //
                        m_runTime = DateTime.Now;
                        m_runStatus = 0;
                    }

                    // -------------------- 键盘 -------------------- //
                    else if (m_cmdConfigList[m_runStep].m_type == CmdConfigForm.m_TYPEs[1])
                    {
                        // ---------- 文本输入 ---------- //
                        if (m_cmdConfigList[m_runStep].m_op == CmdConfigForm.m_KEYBD_OPs[0])
                        {
                            m_keybdCtrl.KeybdText(m_cmdConfigList[m_runStep].m_text);
                        }

                        // ---------- 组合键1 ---------- //
                        else if (m_cmdConfigList[m_runStep].m_op == CmdConfigForm.m_KEYBD_OPs[1])
                        {
                            m_keybdCtrl.KeybdComb(m_cmdConfigList[m_runStep].m_text);
                        }

                        // ---------- 组合键2 ---------- //
                        else if (m_cmdConfigList[m_runStep].m_op == CmdConfigForm.m_KEYBD_OPs[2])
                        {
                            m_keybdCtrl.KeybdComb(m_cmdConfigList[m_runStep].m_text);
                        }

                        // ---------- 更新状态 ---------- //
                        m_runTime = DateTime.Now;
                        m_runStatus = 0;
                    }
                }
                else if (m_runStatus == 0)
                {
                    // -------------------- 延时控制 -------------------- //
                    double curTime = (DateTime.Now - m_runTime).TotalSeconds;
                    double allTime = Convert.ToDouble(m_cmdConfigList[m_runStep].m_time);

                    if (curTime > allTime)
                    {
                        // 判断是否已经遍历完，未完成则继续，完成则禁止定时器
                        if (++m_runStep < m_cmdConfigList.Count)
                        {
                            m_runStatus = 1;
                        }
                        else
                        {
                            // 更新状态
                            timerMain.Enabled     = false;
                            progressBarMain.Value = 0;

                            this.WindowState = FormWindowState.Normal;       // 恢复当前窗口
                        }
                    }
                    else
                    {
                        // 延时未到，更新进度条
                        if (Convert.ToInt32(m_cmdConfigList[m_runStep].m_time) != 0)
                        {
                            progressBarMain.Value = Convert.ToInt32(curTime / allTime * 100.0);
                        }

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        // -------------------------------------------------------------------------------- //
        // ----------------------------- menuStripMain Events ----------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 菜单栏 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemImport_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 菜单栏 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemExport_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 菜单栏 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 菜单栏 获取机器码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemMachineCode_Click(object sender, EventArgs e)
        {
            try
            {
                string machineCode = Encryption.MachineCode.GetMachineCode();

                if (MessageBox.Show("您的机器码为: " + machineCode + "\n单击确定后自动复制至粘贴板，请将该机器码发送给码农！", "警告", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Clipboard.SetDataObject(machineCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 菜单栏 载入注册码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSetRegCode_Click(object sender, EventArgs e)
        {
            try
            {
                // 弹出命令配置窗口
                InputRegCodeForm inputRegCodeForm = new InputRegCodeForm();
                if (inputRegCodeForm.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("注册码写入完毕，请重启软件！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取注册码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemGetRegCode_Click(object sender, EventArgs e)
        {
            try
            {
                // 弹出命令配置窗口
                RegisterForm registerForm = new RegisterForm();
                if (registerForm.ShowDialog(this) == DialogResult.OK)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 菜单栏 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            try
            {
                string authority = string.Empty;

                if (!m_isOutOfDate)
                {
                    authority = m_overtime;
                }
                else
                {
                    authority = "No access";
                }

                // 弹出命令配置窗口
                AboutForm aboutForm = new AboutForm(m_dateVersion, m_pushVersion, authority);
                if (aboutForm.ShowDialog(this) == DialogResult.OK)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // -------------------------------------------------------------------------------- //
        // ------------------------------ 新功能测试，右键菜单栏 ------------------------------ //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // 新建 命令 Ctrl+N
                if (e.Control && e.KeyCode == Keys.N)
                {
                    toolStripMenuItemNewCmd_Click(null, null);
                }
                // 新建 命令组 Alt+N
                else if (e.Alt && e.KeyCode == Keys.N)
                {
                    toolStripMenuItemNewGrp_Click(null, null);
                }
                // 编辑 命令/命令组 Ctrl+E
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    toolStripMenuItemEdit_Click(null, null);
                }
                // 复制 命令/命令组 Ctrl+C
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    toolStripMenuItemCopy_Click(null, null);
                }
                // 粘贴 命令/命令组 Ctrl+E
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    toolStripMenuItemPaste_Click(null, null);
                }
                // 删除 命令/命令组 Delete
                else if (e.KeyCode == Keys.Delete)
                {
                    toolStripMenuItemDel_Click(null, null);
                }
                // 上移 命令/命令组 Ctrl+Up
                else if (e.Shift && e.KeyCode == Keys.Up)
                {
                    toolStripMenuItemMoveUp_Click(null, null);
                }
                // 下移 命令/命令组 Ctrl+Dn
                else if (e.Shift && e.KeyCode == Keys.Down)
                {
                    toolStripMenuItemMoveDn_Click(null, null);
                }
                // 运行 F5
                else if (e.KeyCode == Keys.F5)
                {
                    toolStripMenuItemRun_Click(null, null);
                }
                // 停止 Shift+F5
                else if (e.Shift && e.KeyCode == Keys.F5)
                {
                    toolStripMenuItemStop_Click(null, null);
                }
                // 从这运行 F6
                else if (e.KeyCode == Keys.F6)
                {
                    toolStripMenuItemRunHere_Click(null, null);
                }
                // 单步运行 F10
                else if (e.KeyCode == Keys.F10)
                {
                    toolStripMenuItemRunStep_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 新建 命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemNewCmd_Click(object sender, EventArgs e)
        {
            try
            {
                // 添加 CmdNode 的时候，必须选中某一个 GrpNode
                if (treeViewMain.SelectedNode == null)
                {
                    MessageBox.Show("仅允许在命令组下添加命令，请选中命令组节点或命令节点后再添加！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 弹出命令配置窗口，添加新命令
                CmdConfigForm cmdConfigForm = new CmdConfigForm();
                if (cmdConfigForm.ShowDialog(this) == DialogResult.OK)
                {
                    string str = m_treeViewCtrl.CreateCmd(treeViewMain, cmdConfigForm.m_cmdConfig);
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        MessageBox.Show(str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 新建 命令组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemNewGrp_Click(object sender, EventArgs e)
        {
            try
            {
                // 添加 GrpNode 的时候，必须处于根目录状态
                if (treeViewMain.SelectedNode != null && treeViewMain.SelectedNode.Level != 0)
                {
                    MessageBox.Show("仅允许在根目录下添加命令组，请选中根目录节点后再添加！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 弹出命令组配置窗口，添加新命令组
                GrpConfigForm grpConfigForm = new GrpConfigForm();
                if (grpConfigForm.ShowDialog(this) == DialogResult.OK)
                {
                    string str = m_treeViewCtrl.CreateGrp(treeViewMain, grpConfigForm.m_grpConfig);
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        MessageBox.Show(str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 编辑 命令/命令组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // 必须选中某一个 Node
                if (treeViewMain.SelectedNode == null)
                {
                    MessageBox.Show("请选中所要编辑的命令组节点或命令节点！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 弹出 命令组 配置窗口
                if (treeViewMain.SelectedNode.Level == 0)
                {
                    GrpConfigForm grpConfigForm = new GrpConfigForm((GrpConfig)treeViewMain.SelectedNode.Tag);
                    if (grpConfigForm.ShowDialog(this) == DialogResult.OK)
                    {
                        string str = m_treeViewCtrl.EditGrp(treeViewMain, grpConfigForm.m_grpConfig);
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            MessageBox.Show(str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                // 弹出 命令 配置窗口
                else if (treeViewMain.SelectedNode.Level == 1)
                {
                    CmdConfigForm cmdConfigForm = new CmdConfigForm((CmdConfig)treeViewMain.SelectedNode.Tag);
                    if (cmdConfigForm.ShowDialog(this) == DialogResult.OK)
                    {
                        string str = m_treeViewCtrl.EditCmd(treeViewMain, cmdConfigForm.m_cmdConfig);
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            MessageBox.Show(str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 复制 命令/命令组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            try
            {
                // 必须选中某一个 Node
                if (treeViewMain.SelectedNode == null)
                {
                    MessageBox.Show("请选中所要编辑的命令组节点或命令节点！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 复制 命令组
                if (treeViewMain.SelectedNode.Level == 0)
                {
                    
                }
                // 复制 命令
                else if (treeViewMain.SelectedNode.Level == 1)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 粘贴 命令/命令组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemPaste_Click(object sender, EventArgs e)
        {
            try
            {
                // 必须选中某一个 Node
                if (treeViewMain.SelectedNode == null)
                {
                    MessageBox.Show("请选中所要编辑的命令组节点或命令节点！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 粘贴 命令组
                if (treeViewMain.SelectedNode.Level == 0)
                {

                }
                // 粘贴 命令
                else if (treeViewMain.SelectedNode.Level == 1)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 删除 命令/命令组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            try
            {
                // 必须选中某一个 Node
                if (treeViewMain.SelectedNode == null)
                {
                    MessageBox.Show("请选中所要删除的命令组节点或命令节点！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 删除节点
                m_treeViewCtrl.DeleteNode(treeViewMain);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 上移 命令/命令组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                // 必须选中某一个 Node
                if (treeViewMain.SelectedNode == null)
                {
                    MessageBox.Show("请选中所要删除的命令组节点或命令节点！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 上移节点
                m_treeViewCtrl.MoveUpNode(treeViewMain);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 下移 命令/命令组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemMoveDn_Click(object sender, EventArgs e)
        {
            try
            {
                // 必须选中某一个 Node
                if (treeViewMain.SelectedNode == null)
                {
                    MessageBox.Show("请选中所要删除的命令组节点或命令节点！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 下移节点
                m_treeViewCtrl.MoveDnNode(treeViewMain);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemRun_Click(object sender, EventArgs e)
        {
            try
            {
                // 过期保护
                if (m_isOutOfDate)
                    MessageBox.Show("无权限，请先激活软件！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 提示切换英文输入法
                if (MessageBox.Show("警告：运行前，请切换至英文输入法！", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }

                // 最小化当前窗口
                this.WindowState = FormWindowState.Minimized;

                // 遍历 treeViewMain，解析数据至 m_cmdConfigList



                // 初始化状态变量，并使能定时器
                m_runStep = 0;              // 从头运行
                m_runStatus = 1;
                timerMain.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemStop_Click(object sender, EventArgs e)
        {
            try
            {
                // 关闭定时器，直接停止
                timerMain.Enabled = false;

                // 更新状态
                progressBarMain.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 从这运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemRunHere_Click(object sender, EventArgs e)
        {
            try
            {
                // 过期保护
                if (m_isOutOfDate)
                    MessageBox.Show("无权限，请先激活软件！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 提示切换英文输入法
                if (MessageBox.Show("警告：运行前，请切换至英文输入法！", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }

                // 最小化当前窗口
                this.WindowState = FormWindowState.Minimized;

                // 遍历 treeViewMain，解析数据至 m_cmdConfigList



                // 初始化状态变量，并使能定时器
                m_runStep = 0;              // 从头运行
                m_runStatus = 1;
                timerMain.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 单步运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemRunStep_Click(object sender, EventArgs e)
        {
            try
            {
                // 提示切换英文输入法
                if (MessageBox.Show("警告：运行前，请切换至英文输入法！", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }

                // 最小化当前窗口
                this.WindowState = FormWindowState.Minimized;

                // treeViewMain.SelectedNode，解析数据至 m_cmdConfigList



                // 初始化状态变量，并使能定时器
                m_runStep = 0;              // 从头运行
                m_runStatus = 1;
                timerMain.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------------------------------------------------------- //
        // --------------------------------- 软件过期保护 ---------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 获取过期时间
        /// </summary>
        /// <returns></returns>
        public string GetOverTime()
        {
            // 根据注册码，获取时间
            string keyUrl = @"key.txt";
            if (File.Exists(keyUrl))
            {
                SecretKey sk = new SecretKey();
                return sk.Decrypt(Encryption.MachineCode.GetMachineCode(), File.ReadAllText(keyUrl));
            }
            else
            {
                //MessageBox.Show("注册码文件 (key.txt) 不存在，应放置于可执行文件同级目录下！");
                return null;
            }
        }

        /// <summary>
        /// 判断是否过期
        /// </summary>
        /// <returns></returns>
        public bool IsOutOfDate(string overtime)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(overtime))
                {
                    DateTime dt = DateTime.ParseExact(overtime, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                    if (dt > DateTime.Now)
                    {
                        //MessageBox.Show(string.Format("试用期还剩 {0} 天！", resDays));
                        return (false);
                    }
                    else
                    {
                        //MessageBox.Show("试用期已过，请联系码农！");
                        return (true);
                    }
                }
                else
                {
                    //MessageBox.Show("注册码有误，请联系码农！");
                    return (true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册码有误，请联系码农！");
                return (true);
            }
        }

        // -------------------------------------------------------------------------------- //
        // ------------------------------------- 测试 ------------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 标题 双击事件 (测试用)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTitle_DoubleClick(object sender, EventArgs e)
        {
            
        }

        
    }
}

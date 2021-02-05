using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.in2bits.MyXls;

using MKB.CtrlClass;
using MKB.SubForm;

namespace MKB
{
    public partial class MainForm : Form
    {
        // 版本
        string dateVersion = "20210205";
        string pushVersion = "V1.1.3";

        // 鼠标键盘控制类
        MouseControl m_mouseCtrl = new MouseControl();
        KeybdControl m_keybdCtrl = new KeybdControl();

        // 命令列表 & 命令运行标志
        List<CmdConfig> m_cmdConfigList = new List<CmdConfig>();
        int m_runStep      = 0;                 // 命令列表运行的步数
        int m_runStatus    = 1;                 // 0 表示延时状态，1 表示运行状态
        DateTime m_runTime = DateTime.Now;      // 用以记录命令运行结束的时间 (延时用)

        public MainForm()
        {
            InitializeComponent();
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
                        // 取消先前的选中行状态
                        foreach (DataGridViewRow dr in dataGridViewCmdConfigList.SelectedRows)
                        {
                            dr.Selected = false;
                        }

                        // 高亮当前选中行
                        dataGridViewCmdConfigList.Rows[m_runStep].Selected = true;

                        // 滚动条设置 一个页面可显示 17 行
                        if (m_runStep > 16)
                        {
                            dataGridViewCmdConfigList.FirstDisplayedScrollingRowIndex = m_runStep - 16;
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
                    int curTime = (DateTime.Now - m_runTime).Seconds;
                    int allTime = Convert.ToInt32(m_cmdConfigList[m_runStep].m_time);

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
                            buttonRun.Text        = buttonRun.Tag.ToString().Split(' ')[0];
                            progressBarMain.Value = 0;

                            this.WindowState = FormWindowState.Normal;       // 恢复当前窗口
                        }
                    }
                    else
                    {
                        // 延时未到，更新进度条
                        if (Convert.ToInt32(m_cmdConfigList[m_runStep].m_time) != 0)
                        {
                            progressBarMain.Value = Convert.ToInt32(Convert.ToDouble(curTime) / Convert.ToDouble(allTime) * 100.0);
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
        // ------------------------------------ Events ------------------------------------ //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 运行 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRun_Click(object sender, EventArgs e)
        {
            try
            {
                // 过期保护
                if (IsOutOfDate())
                {
                    return;
                }

                // 运行操作
                if (buttonRun.Text == buttonRun.Tag.ToString().Split(' ')[0])
                {
                    // 提示切换英文输入法
                    DialogResult dialogResult = MessageBox.Show("是否从当前行开始运行？\n\n" +
                                                                "点击是，从当前行开始运行。\n" +
                                                                "点击否，从第一行开始运行。\n" +
                                                                "点击取消，退出运行。\n\n" +
                                                                "警告：运行前，请切换至英文输入法！", 
                                                                "警告", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }

                    // 最小化当前窗口
                    if (checkBoxHide.Checked)
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }

                    // 开始执行 dataGridViewCmdConfigList 的命令列表
                    m_cmdConfigList.Clear();

                    // 判断列表是否为空
                    if (dataGridViewCmdConfigList.Rows.Count == 0)
                    {
                        return;
                    }

                    // 遍历命令列表
                    foreach (DataGridViewRow row in dataGridViewCmdConfigList.Rows)
                    {
                        // 数据解析
                        m_cmdConfigList.Add(new CmdConfig(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(),
                                                          row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(),
                                                          row.Cells[5].Value.ToString().Split(' ')[0], row.Cells[5].Value.ToString().Split(' ')[1],
                                                          row.Cells[6].Value.ToString()));

                        // 执行操作，即使能定时器
                        if (dialogResult == DialogResult.Yes)       // 从当前行开始运行
                        {
                            m_runStep = dataGridViewCmdConfigList.CurrentCell.RowIndex;
                        }
                        else                                        // 从第一行开始运行
                        {
                            m_runStep = 0;
                        }
                        m_runStatus       = 1;
                        timerMain.Enabled = true;
                    }

                    // 更新状态
                    buttonRun.Text = buttonRun.Tag.ToString().Split(' ')[1];
                }
                else if (buttonRun.Text == buttonRun.Tag.ToString().Split(' ')[1])
                {
                    // 关闭定时器，直接停止
                    timerMain.Enabled = false;

                    // 更新状态
                    buttonRun.Text        = buttonRun.Tag.ToString().Split(' ')[0];
                    progressBarMain.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 新建 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNew_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取当前选中的行，若没有，默认为 -1
                int curRow = -1;
                if (dataGridViewCmdConfigList.Rows.Count != 0)
                {
                    curRow = dataGridViewCmdConfigList.CurrentCell.RowIndex;
                }

                // 弹出命令配置窗口
                CmdConfigForm cmdConfigForm = new CmdConfigForm();
                if (cmdConfigForm.ShowDialog(this) == DialogResult.OK)
                {
                    // 这里会返回一个 CmdConfig 类型的变量，可以写到 dataGridViewCmdConfigList 中
                    CmdConfigList_Insert(cmdConfigForm.m_cmdConfig, curRow);
                    if (curRow != -1)
                    {
                        // 光标留在新建行
                        dataGridViewCmdConfigList.CurrentCell = dataGridViewCmdConfigList.Rows[curRow + 1].Cells[dataGridViewCmdConfigList.CurrentCell.ColumnIndex];
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 编辑 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取当前选中的行，若没有，直接返回
                if (dataGridViewCmdConfigList.Rows.Count == 0)
                {
                    return;
                }
                int curRow = dataGridViewCmdConfigList.CurrentCell.RowIndex;
                
                // 弹出命令配置窗口
                CmdConfigForm cmdConfigForm = new CmdConfigForm(CmdConfigList_Get(curRow));
                if (cmdConfigForm.ShowDialog(this) == DialogResult.OK)
                {
                    // 这里会返回一个 CmdConfig 类型的变量，可以写到 dataGridViewCmdConfigList 中
                    CmdConfigList_Set(cmdConfigForm.m_cmdConfig, curRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// 双击 Cell 进入编辑界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewCmdConfigList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                buttonEdit_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 上移 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取当前选中的行，若没有，直接返回
                if (dataGridViewCmdConfigList.Rows.Count == 0)
                {
                    return;
                }
                int curRow = dataGridViewCmdConfigList.CurrentCell.RowIndex;

                // 判断往上是否还有一行
                if (curRow - 1 < 0)
                {
                    return;
                }

                // 交换行
                CmdConfigList_Exchange(curRow - 1, curRow);

                // 光标留在当前行
                dataGridViewCmdConfigList.CurrentCell = dataGridViewCmdConfigList.Rows[curRow - 1].Cells[dataGridViewCmdConfigList.CurrentCell.ColumnIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 下移 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取当前选中的行，若没有，直接返回
                if (dataGridViewCmdConfigList.Rows.Count == 0)
                {
                    return;
                }
                int curRow = dataGridViewCmdConfigList.CurrentCell.RowIndex;

                // 判断往下是否还有一行
                if (curRow + 1 > dataGridViewCmdConfigList.Rows.Count - 1)
                {
                    return;
                }

                // 交换行
                CmdConfigList_Exchange(curRow, curRow + 1);

                // 光标留在当前行
                dataGridViewCmdConfigList.CurrentCell = dataGridViewCmdConfigList.Rows[curRow + 1].Cells[dataGridViewCmdConfigList.CurrentCell.ColumnIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 删除 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCmdConfigList.Rows.Count != 0)
                {
                    CmdConfigList_Delete(dataGridViewCmdConfigList.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 导出 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                // 导出数据
                ExportExcel(dataGridViewCmdConfigList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 导入 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImport_Click(object sender, EventArgs e)
        {
            try
            {
                // 导入数据
                List<CmdConfig> cmdConfigList = ImportExcel();
                if (cmdConfigList == null || cmdConfigList.Count == 0)
                {
                    return;
                }

                // 更新 dataGridViewCmdConfigList
                dataGridViewCmdConfigList.Rows.Clear();
                foreach (CmdConfig cmdConfig in cmdConfigList)
                {
                    CmdConfigList_Add(cmdConfig);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 退出 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
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
                buttonImport_Click(null, null);
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
                buttonExport_Click(null, null);
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
                buttonExit_Click(null, null);
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
                string str = string.Empty;

                str += "鼠标键盘自动控制插件\n";
                str += "Author: ZpRoc\n";
                str += "Date: " + dateVersion + "\n";
                str += "Version: " + pushVersion + "\n";

                MessageBox.Show(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // -------------------------------------------------------------------------------- //
        // ---------------------- dataGridViewCmdConfigList 相关操作 ----------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="cmdConfig"></param>
        public void CmdConfigList_Add(CmdConfig cmdConfig)
        {
            dataGridViewCmdConfigList.Rows.Add(cmdConfig.Decompose());
        }

        /// <summary>
        /// 插入行
        /// </summary>
        /// <param name="cmdConfig"></param>
        /// <param name="index"></param>
        public void CmdConfigList_Insert(CmdConfig cmdConfig, int index)
        {
            dataGridViewCmdConfigList.Rows.Insert(index+1, cmdConfig.Decompose());
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="index"></param>
        public void CmdConfigList_Delete(int index)
        {
            dataGridViewCmdConfigList.Rows.RemoveAt(index);
        }

        /// <summary>
        /// 获取行
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CmdConfig CmdConfigList_Get(int index)
        {
            CmdConfig cmdConfig = new CmdConfig();

            cmdConfig.m_type  = dataGridViewCmdConfigList.Rows[index].Cells[0].Value.ToString();
            cmdConfig.m_posX  = dataGridViewCmdConfigList.Rows[index].Cells[1].Value.ToString();
            cmdConfig.m_posY  = dataGridViewCmdConfigList.Rows[index].Cells[2].Value.ToString();
            cmdConfig.m_op    = dataGridViewCmdConfigList.Rows[index].Cells[3].Value.ToString();
            cmdConfig.m_text  = dataGridViewCmdConfigList.Rows[index].Cells[4].Value.ToString();
            cmdConfig.m_time  = dataGridViewCmdConfigList.Rows[index].Cells[5].Value.ToString().Split(' ')[0];
            cmdConfig.m_unit  = dataGridViewCmdConfigList.Rows[index].Cells[5].Value.ToString().Split(' ')[1];
            cmdConfig.m_descr = dataGridViewCmdConfigList.Rows[index].Cells[6].Value.ToString();

            return (cmdConfig);
        }

        /// <summary>
        /// 设置行
        /// </summary>
        /// <param name="cmdConfig"></param>
        /// <param name="index"></param>
        public void CmdConfigList_Set(CmdConfig cmdConfig, int index)
        {
            dataGridViewCmdConfigList.Rows[index].Cells[0].Value = cmdConfig.m_type;
            dataGridViewCmdConfigList.Rows[index].Cells[1].Value = cmdConfig.m_posX;
            dataGridViewCmdConfigList.Rows[index].Cells[2].Value = cmdConfig.m_posY;
            dataGridViewCmdConfigList.Rows[index].Cells[3].Value = cmdConfig.m_op;
            dataGridViewCmdConfigList.Rows[index].Cells[4].Value = cmdConfig.m_text;
            dataGridViewCmdConfigList.Rows[index].Cells[5].Value = string.Concat(cmdConfig.m_time, " ", cmdConfig.m_unit);
            dataGridViewCmdConfigList.Rows[index].Cells[6].Value = cmdConfig.m_descr;
        }

        /// <summary>
        /// 交换行
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public void CmdConfigList_Exchange(int index1, int index2)
        {
            // 确保 index1 < index2
            if (index1 < index2)
            {
                // 获取 row1, row2 行信息
                DataGridViewRow row1 = dataGridViewCmdConfigList.Rows[index1];
                DataGridViewRow row2 = dataGridViewCmdConfigList.Rows[index2];

                // 删除 row1, row2 行信息
                dataGridViewCmdConfigList.Rows.RemoveAt(index1);
                dataGridViewCmdConfigList.Rows.RemoveAt(index2 - 1);

                // 将 row2 插入至 index1 位置
                dataGridViewCmdConfigList.Rows.Insert(index1, row2);

                // 将 row1 插入至 index2 位置
                dataGridViewCmdConfigList.Rows.Insert(index2, row1);
            }

        }

        // -------------------------------------------------------------------------------- //
        // --------------------------------- 数据导入/导出 --------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="dataGridView"></param>
        public void ExportExcel(DataGridView dataGridView)
        {
            try
            {
                // 保存 excel 文件对话框
                string fileName = "";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter                              = "Excel files (*.xls)|*.xls";
                saveFileDialog.CheckFileExists                     = false;
                saveFileDialog.CheckPathExists                     = false;
                saveFileDialog.FilterIndex                         = 0;
                saveFileDialog.CreatePrompt                        = true;
                saveFileDialog.Title                               = "保存为 Excel 文件";
                saveFileDialog.FileName                            = "CmdConfigList";
                saveFileDialog.InitialDirectory                    = System.Environment.CurrentDirectory;
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                fileName = saveFileDialog.FileName;

                // 添加部分信息
                XlsDocument xls                    = new XlsDocument();
                xls.SummaryInformation.LastSavedBy = "ZpRoc";                                           // 填加 xls 文件最后保存者信息
                xls.SummaryInformation.Comments    = "ZpRoc";                                           // 填加 xls 文件作者信息
                Worksheet sheet                    = xls.Workbook.Worksheets.Add("CmdConfigList");      // 状态栏标题名称
                Cells cells                        = sheet.Cells;

                // ******************** 数据格式 ******************** //
                // 字符串：居中对齐
                XF xfStr = xls.NewXF();
                xfStr.HorizontalAlignment = HorizontalAlignments.Centered;
                xfStr.VerticalAlignment = VerticalAlignments.Centered;

                // 时间格式
                XF xfDate = xls.NewXF();
                xfDate.HorizontalAlignment = HorizontalAlignments.Centered;
                xfDate.VerticalAlignment = VerticalAlignments.Centered;
                xfDate.Format = "yyyy-MM-dd HH:mm:ss";

                // 测量数据：居中对齐，五位整数
                XF xfInt5 = xls.NewXF();
                xfInt5.HorizontalAlignment = HorizontalAlignments.Centered;
                xfInt5.VerticalAlignment = VerticalAlignments.Centered;
                xfInt5.Format = "00000";

                // 测量数据：居中对齐，保留一位小数
                XF xfDecimal1 = xls.NewXF();
                xfDecimal1.HorizontalAlignment = HorizontalAlignments.Centered;
                xfDecimal1.VerticalAlignment = VerticalAlignments.Centered;
                xfDecimal1.Format = "0.0";

                // 测量数据：居中对齐，保留两位小数
                XF xfDecimal2 = xls.NewXF();
                xfDecimal2.HorizontalAlignment = HorizontalAlignments.Centered;
                xfDecimal2.VerticalAlignment = VerticalAlignments.Centered;
                xfDecimal2.Format = "0.00";

                // cells 的 行列索引 从 1 开始

                // 第一行 列标题
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    if (dataGridView.Columns[i].Visible == true)
                    {
                        Cell cell = cells.Add(1, i + 1, dataGridView.Columns[i].HeaderText, xfStr);
                        cell.Font.Bold = true;
                    }
                }

                // 第二行以后，CmdCOnfigList
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Columns[j].Visible == true)
                        {
                            Cell cell = cells.Add(i + 2, j + 1, dataGridView.Rows[i].Cells[j].Value.ToString(), xfStr);
                            cell.Font.Bold = false;
                        }
                    }
                }

                // 保存数据
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }
                xls.FileName = fileName;
                xls.Save();

                // 完成导出
                MessageBox.Show("导出完成！");
            }
            catch (Exception ex)
            {
                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd <HH:mm:ss:ffff>") + "\t"
                                + "MainForm" + "\t" + "\n" + "ExportExcel catch:" + ex.Message);
            }
        }

        /// <summary>
        /// 数据导入
        /// </summary>
        /// <returns></returns>
        public List<CmdConfig> ImportExcel()
        {
            try
            {
                // 提醒
                MessageBox.Show("导入前，请打开 Excel 文件，选中全部列，双击列间的空隙，使其自适应列宽，否则可能造成导入失败！");

                // 选择 excel 文件对话框
                OpenFileDialog openFileDialog = new OpenFileDialog();           
                openFileDialog.Filter           = "Excel files (*.xls)|*.xls";
                openFileDialog.InitialDirectory = System.Environment.CurrentDirectory;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // 获取文件路径
                    string filePath = openFileDialog.FileName.ToString();
                    if (string.IsNullOrEmpty(filePath))
                    {
                        return (null);
                    }

                    // 文件连接
                    string strConn = "";
                    if (System.IO.Path.GetExtension(filePath) == ".xls")
                    {
                        strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties=Excel 8.0;", filePath);
                    }
                    else
                    {
                        strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties=Excel 8.0;", filePath);
                    }

                    // 读取数据
                    DataSet ds = new DataSet();
                    using (var oledbConn = new OleDbConnection(strConn))
                    {
                        oledbConn.Open();
                        var sheetName = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new[] { null, null, null, "Table" });
                        var sheet = new string[sheetName.Rows.Count];
                        for (int i = 0, j = sheetName.Rows.Count; i < j; i++)
                        {
                            sheet[i] = sheetName.Rows[i]["TABLE_NAME"].ToString();
                        }
                        var adapter = new OleDbDataAdapter(string.Format("select * from [{0}]", sheet[0]), oledbConn);
                        adapter.Fill(ds);
                    }

                    // 解析数据 ds.Tables[0]
                    List<CmdConfig> cmdConfigList = new List<CmdConfig>();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        cmdConfigList.Add(new CmdConfig(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), 
                                                        dr[5].ToString().Split(' ')[0], dr[5].ToString().Split(' ')[1], dr[6].ToString()));
                    }

                    // 返回
                    return (cmdConfigList);
                }
                else
                {
                    return (null);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd <HH:mm:ss:ffff>") + "\t"
                                + "MainForm" + "\t" + "\n" + "ImportExcel catch:" + ex.Message);
                return (null);
            }
        }

        // -------------------------------------------------------------------------------- //
        // --------------------------------- 软件过期保护 ---------------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 判断是否过期
        /// </summary>
        /// <returns></returns>
        public bool IsOutOfDate()
        {
            int resDays = (Convert.ToDateTime("2021/3/30 23:59:59") - DateTime.Now).Days;

            if (resDays > 0)
            {
                //MessageBox.Show(string.Format("试用期还剩 {0} 天！", resDays));
                return (false);
            }
            else
            {
                MessageBox.Show("试用期已过，请联系码农！");
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

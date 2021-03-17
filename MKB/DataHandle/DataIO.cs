using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using org.in2bits.MyXls;


namespace MKB.DataHandle
{
    /// <summary>
    /// DataIO:
    ///     数据导入/导出 相关函数
    /// Function:
    ///     public void ExportTxt(TreeView treeView)
    ///     public TreeView ImportTxt()
    ///     
    ///     public void ExportExcel(DataGridView dataGridView)
    ///     public List<CmdConfig> ImportExcel()
    /// Variable:
    ///     None. 
    /// Note:
    ///     None. 
    /// </summary>
    public class DataIO
    {
        // -------------------------------------------------------------------------------- //
        // ------------------------ 数据导入/导出 TreeView <--> TXT ------------------------- //
        // -------------------------------------------------------------------------------- //

        /// <summary>
        /// 数据导出
        /// </summary>
        /// <param name="dataGridView"></param>
        public void ExportTxt(TreeView treeView)
        {
            try
            {
                

                // 完成导出
                MessageBox.Show("导出完成！");
            }
            catch (Exception ex)
            {
                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd <HH:mm:ss:ffff>") + "\t"
                                + "MainForm" + "\t" + "\n" + "ExportTxt catch:" + ex.Message);
            }
        }

        /// <summary>
        /// 数据导入
        /// </summary>
        /// <returns></returns>
        public TreeView ImportTxt()
        {
            try
            {
                // 选择 txt 文件对话框
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.InitialDirectory = System.Environment.CurrentDirectory;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // 获取文件路径
                    string filePath = openFileDialog.FileName.ToString();
                    if (string.IsNullOrEmpty(filePath))
                    {
                        return (null);
                    }

                    // 

                    // 返回
                    return (null);
                }
                else
                {
                    return (null);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd <HH:mm:ss:ffff>") + "\t"
                                + "MainForm" + "\t" + "\n" + "ImportTxt catch:" + ex.Message);
                return (null);
            }
        }

        // -------------------------------------------------------------------------------- //
        // --------------------- 数据导入/导出 DataGridView <--> Excel ---------------------- //
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
                saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
                saveFileDialog.CheckFileExists = false;
                saveFileDialog.CheckPathExists = false;
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.CreatePrompt = true;
                saveFileDialog.Title = "保存为 Excel 文件";
                saveFileDialog.FileName = "CmdConfigList";
                saveFileDialog.InitialDirectory = System.Environment.CurrentDirectory;
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                fileName = saveFileDialog.FileName;

                // 添加部分信息
                XlsDocument xls = new XlsDocument();
                xls.SummaryInformation.LastSavedBy = "ZpRoc";                                           // 填加 xls 文件最后保存者信息
                xls.SummaryInformation.Comments = "ZpRoc";                                           // 填加 xls 文件作者信息
                Worksheet sheet = xls.Workbook.Worksheets.Add("CmdConfigList");      // 状态栏标题名称
                Cells cells = sheet.Cells;

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
                openFileDialog.Filter = "Excel files (*.xls)|*.xls";
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
    }
}

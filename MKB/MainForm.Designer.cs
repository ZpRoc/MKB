namespace MKB
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.dataGridViewCmdConfigList = new System.Windows.Forms.DataGridView();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPosX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPosY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.checkBoxHide = new System.Windows.Forms.CheckBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemActive = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMachineCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSetRegCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGetRegCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSingleStep = new System.Windows.Forms.Button();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCmdConfigList)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNew
            // 
            this.buttonNew.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonNew.Location = new System.Drawing.Point(971, 183);
            this.buttonNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(80, 36);
            this.buttonNew.TabIndex = 0;
            this.buttonNew.Text = "新建";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEdit.Location = new System.Drawing.Point(971, 233);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(80, 36);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "编辑";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonMoveUp.Location = new System.Drawing.Point(971, 282);
            this.buttonMoveUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(80, 36);
            this.buttonMoveUp.TabIndex = 2;
            this.buttonMoveUp.Text = "上移";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonMoveDown.Location = new System.Drawing.Point(971, 332);
            this.buttonMoveDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(80, 36);
            this.buttonMoveDown.TabIndex = 3;
            this.buttonMoveDown.Text = "下移";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonDel.Location = new System.Drawing.Point(971, 381);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(80, 36);
            this.buttonDel.TabIndex = 4;
            this.buttonDel.Text = "删除";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExport.Location = new System.Drawing.Point(971, 431);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(80, 36);
            this.buttonExport.TabIndex = 5;
            this.buttonExport.Text = "导出";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonImport.Location = new System.Drawing.Point(971, 480);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(80, 36);
            this.buttonImport.TabIndex = 6;
            this.buttonImport.Text = "导入";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // dataGridViewCmdConfigList
            // 
            this.dataGridViewCmdConfigList.AllowUserToAddRows = false;
            this.dataGridViewCmdConfigList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewCmdConfigList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCmdConfigList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCmdConfigList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCmdConfigList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnType,
            this.ColumnPosX,
            this.ColumnPosY,
            this.ColumnOp,
            this.ColumnText,
            this.ColumnDelay,
            this.ColumnDescr});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCmdConfigList.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewCmdConfigList.Location = new System.Drawing.Point(12, 82);
            this.dataGridViewCmdConfigList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewCmdConfigList.Name = "dataGridViewCmdConfigList";
            this.dataGridViewCmdConfigList.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCmdConfigList.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewCmdConfigList.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewCmdConfigList.RowTemplate.Height = 23;
            this.dataGridViewCmdConfigList.Size = new System.Drawing.Size(945, 455);
            this.dataGridViewCmdConfigList.TabIndex = 7;
            this.dataGridViewCmdConfigList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCmdConfigList_CellDoubleClick);
            // 
            // ColumnType
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnType.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnType.HeaderText = "类型";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            this.ColumnType.Width = 72;
            // 
            // ColumnPosX
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnPosX.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnPosX.HeaderText = "位置X";
            this.ColumnPosX.Name = "ColumnPosX";
            this.ColumnPosX.ReadOnly = true;
            this.ColumnPosX.Width = 80;
            // 
            // ColumnPosY
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnPosY.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnPosY.HeaderText = "位置Y";
            this.ColumnPosY.Name = "ColumnPosY";
            this.ColumnPosY.ReadOnly = true;
            this.ColumnPosY.Width = 80;
            // 
            // ColumnOp
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnOp.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnOp.HeaderText = "操作";
            this.ColumnOp.Name = "ColumnOp";
            this.ColumnOp.ReadOnly = true;
            // 
            // ColumnText
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnText.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnText.HeaderText = "文本";
            this.ColumnText.Name = "ColumnText";
            this.ColumnText.ReadOnly = true;
            this.ColumnText.Width = 200;
            // 
            // ColumnDelay
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnDelay.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnDelay.HeaderText = "延时";
            this.ColumnDelay.Name = "ColumnDelay";
            this.ColumnDelay.ReadOnly = true;
            // 
            // ColumnDescr
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnDescr.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnDescr.HeaderText = "描述";
            this.ColumnDescr.Name = "ColumnDescr";
            this.ColumnDescr.ReadOnly = true;
            this.ColumnDescr.Width = 250;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(360, 37);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(274, 31);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "鼠标键盘自动控制插件";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.DoubleClick += new System.EventHandler(this.labelTitle_DoubleClick);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.Location = new System.Drawing.Point(971, 530);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(80, 36);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "退出";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAuthor.Location = new System.Drawing.Point(12, 546);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(127, 21);
            this.labelAuthor.TabIndex = 10;
            this.labelAuthor.Text = "Author: ZpRoc";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRun.Location = new System.Drawing.Point(971, 133);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(80, 36);
            this.buttonRun.TabIndex = 11;
            this.buttonRun.Tag = "运行 停止";
            this.buttonRun.Text = "运行";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // progressBarMain
            // 
            this.progressBarMain.Location = new System.Drawing.Point(157, 546);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(800, 20);
            this.progressBarMain.TabIndex = 13;
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // checkBoxHide
            // 
            this.checkBoxHide.AutoSize = true;
            this.checkBoxHide.Location = new System.Drawing.Point(950, 43);
            this.checkBoxHide.Name = "checkBoxHide";
            this.checkBoxHide.Size = new System.Drawing.Size(101, 25);
            this.checkBoxHide.TabIndex = 14;
            this.checkBoxHide.Text = "隐藏窗体";
            this.checkBoxHide.UseVisualStyleBackColor = true;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemActive,
            this.toolStripMenuItemHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1064, 29);
            this.menuStripMain.TabIndex = 15;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemImport,
            this.toolStripMenuItemExport,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(58, 25);
            this.toolStripMenuItemFile.Text = "文件";
            // 
            // toolStripMenuItemImport
            // 
            this.toolStripMenuItemImport.Name = "toolStripMenuItemImport";
            this.toolStripMenuItemImport.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItemImport.Text = "导入";
            this.toolStripMenuItemImport.Click += new System.EventHandler(this.toolStripMenuItemImport_Click);
            // 
            // toolStripMenuItemExport
            // 
            this.toolStripMenuItemExport.Name = "toolStripMenuItemExport";
            this.toolStripMenuItemExport.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItemExport.Text = "导出";
            this.toolStripMenuItemExport.Click += new System.EventHandler(this.toolStripMenuItemExport_Click);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItemExit.Text = "退出";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemActive
            // 
            this.toolStripMenuItemActive.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMachineCode,
            this.toolStripMenuItemSetRegCode,
            this.toolStripMenuItemGetRegCode});
            this.toolStripMenuItemActive.Name = "toolStripMenuItemActive";
            this.toolStripMenuItemActive.Size = new System.Drawing.Size(58, 25);
            this.toolStripMenuItemActive.Text = "激活";
            // 
            // toolStripMenuItemMachineCode
            // 
            this.toolStripMenuItemMachineCode.Name = "toolStripMenuItemMachineCode";
            this.toolStripMenuItemMachineCode.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItemMachineCode.Text = "获取机器码";
            this.toolStripMenuItemMachineCode.Click += new System.EventHandler(this.toolStripMenuItemMachineCode_Click);
            // 
            // toolStripMenuItemSetRegCode
            // 
            this.toolStripMenuItemSetRegCode.Name = "toolStripMenuItemSetRegCode";
            this.toolStripMenuItemSetRegCode.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItemSetRegCode.Text = "载入注册码";
            this.toolStripMenuItemSetRegCode.Click += new System.EventHandler(this.toolStripMenuItemSetRegCode_Click);
            // 
            // toolStripMenuItemGetRegCode
            // 
            this.toolStripMenuItemGetRegCode.Name = "toolStripMenuItemGetRegCode";
            this.toolStripMenuItemGetRegCode.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItemGetRegCode.Text = "获取注册码";
            this.toolStripMenuItemGetRegCode.Click += new System.EventHandler(this.toolStripMenuItemGetRegCode_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(58, 25);
            this.toolStripMenuItemHelp.Text = "帮助";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(180, 26);
            this.toolStripMenuItemAbout.Text = "关于";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // buttonSingleStep
            // 
            this.buttonSingleStep.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSingleStep.Location = new System.Drawing.Point(971, 82);
            this.buttonSingleStep.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSingleStep.Name = "buttonSingleStep";
            this.buttonSingleStep.Size = new System.Drawing.Size(80, 36);
            this.buttonSingleStep.TabIndex = 16;
            this.buttonSingleStep.Tag = "";
            this.buttonSingleStep.Text = "单步";
            this.buttonSingleStep.UseVisualStyleBackColor = true;
            this.buttonSingleStep.Click += new System.EventHandler(this.buttonSingleStep_Click);
            // 
            // treeViewMain
            // 
            this.treeViewMain.Location = new System.Drawing.Point(34, 122);
            this.treeViewMain.Name = "treeViewMain";
            this.treeViewMain.Size = new System.Drawing.Size(397, 403);
            this.treeViewMain.TabIndex = 17;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1064, 581);
            this.Controls.Add(this.treeViewMain);
            this.Controls.Add(this.buttonSingleStep);
            this.Controls.Add(this.checkBoxHide);
            this.Controls.Add(this.progressBarMain);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.dataGridViewCmdConfigList);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonMoveDown);
            this.Controls.Add(this.buttonMoveUp);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximumSize = new System.Drawing.Size(1080, 620);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Keyboard and Mouse Control ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCmdConfigList)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.DataGridView dataGridViewCmdConfigList;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ProgressBar progressBarMain;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.CheckBox checkBoxHide;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDelay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescr;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemActive;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMachineCode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSetRegCode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGetRegCode;
        private System.Windows.Forms.Button buttonSingleStep;
        private System.Windows.Forms.TreeView treeViewMain;
    }
}


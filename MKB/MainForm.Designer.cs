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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemNewCmd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemNewGrp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMoveDn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemRun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRunHere = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRunStep = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTitle = new System.Windows.Forms.Label();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorFile1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemActive = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMachineCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSetRegCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorActive1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemGetRegCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.contextMenuStripMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F);
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewCmd,
            this.toolStripMenuItemNewGrp,
            this.toolStripSeparator1,
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemPaste,
            this.toolStripMenuItemDel,
            this.toolStripSeparator2,
            this.toolStripMenuItemMoveUp,
            this.toolStripMenuItemMoveDn,
            this.toolStripSeparator3,
            this.toolStripMenuItemRun,
            this.toolStripMenuItemStop,
            this.toolStripMenuItemRunHere,
            this.toolStripMenuItemRunStep});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(216, 356);
            // 
            // toolStripMenuItemNewCmd
            // 
            this.toolStripMenuItemNewCmd.Image = global::MKB.Properties.Resources.cmd;
            this.toolStripMenuItemNewCmd.Name = "toolStripMenuItemNewCmd";
            this.toolStripMenuItemNewCmd.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemNewCmd.Text = "新命令 (Ctrl+N)";
            this.toolStripMenuItemNewCmd.Click += new System.EventHandler(this.toolStripMenuItemNewCmd_Click);
            // 
            // toolStripMenuItemNewGrp
            // 
            this.toolStripMenuItemNewGrp.Image = global::MKB.Properties.Resources.group;
            this.toolStripMenuItemNewGrp.Name = "toolStripMenuItemNewGrp";
            this.toolStripMenuItemNewGrp.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemNewGrp.Text = "新建组 (Alt+N)";
            this.toolStripMenuItemNewGrp.Click += new System.EventHandler(this.toolStripMenuItemNewGrp_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Image = global::MKB.Properties.Resources.edit;
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemEdit.Text = "编辑 (Ctrl+E)";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Image = global::MKB.Properties.Resources.copy;
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemCopy.Text = "复制 (Ctrl+C)";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // toolStripMenuItemPaste
            // 
            this.toolStripMenuItemPaste.Image = global::MKB.Properties.Resources.paste;
            this.toolStripMenuItemPaste.Name = "toolStripMenuItemPaste";
            this.toolStripMenuItemPaste.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemPaste.Text = "粘贴 (Ctrl+V)";
            this.toolStripMenuItemPaste.Click += new System.EventHandler(this.toolStripMenuItemPaste_Click);
            // 
            // toolStripMenuItemDel
            // 
            this.toolStripMenuItemDel.Image = global::MKB.Properties.Resources.delete;
            this.toolStripMenuItemDel.Name = "toolStripMenuItemDel";
            this.toolStripMenuItemDel.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemDel.Text = "删除 (Delete)";
            this.toolStripMenuItemDel.Click += new System.EventHandler(this.toolStripMenuItemDel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(212, 6);
            // 
            // toolStripMenuItemMoveUp
            // 
            this.toolStripMenuItemMoveUp.Image = global::MKB.Properties.Resources.move_up;
            this.toolStripMenuItemMoveUp.Name = "toolStripMenuItemMoveUp";
            this.toolStripMenuItemMoveUp.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemMoveUp.Text = "上移 (Ctrl+Up)";
            this.toolStripMenuItemMoveUp.Click += new System.EventHandler(this.toolStripMenuItemMoveUp_Click);
            // 
            // toolStripMenuItemMoveDn
            // 
            this.toolStripMenuItemMoveDn.Image = global::MKB.Properties.Resources.move_down;
            this.toolStripMenuItemMoveDn.Name = "toolStripMenuItemMoveDn";
            this.toolStripMenuItemMoveDn.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemMoveDn.Text = "下移 (Ctrl+Dn)";
            this.toolStripMenuItemMoveDn.Click += new System.EventHandler(this.toolStripMenuItemMoveDn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(212, 6);
            // 
            // toolStripMenuItemRun
            // 
            this.toolStripMenuItemRun.Image = global::MKB.Properties.Resources.run;
            this.toolStripMenuItemRun.Name = "toolStripMenuItemRun";
            this.toolStripMenuItemRun.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemRun.Text = "运行 (F5)";
            this.toolStripMenuItemRun.Click += new System.EventHandler(this.toolStripMenuItemRun_Click);
            // 
            // toolStripMenuItemStop
            // 
            this.toolStripMenuItemStop.Image = global::MKB.Properties.Resources.stop;
            this.toolStripMenuItemStop.Name = "toolStripMenuItemStop";
            this.toolStripMenuItemStop.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemStop.Text = "停止 (Ctrl+F5)";
            this.toolStripMenuItemStop.Click += new System.EventHandler(this.toolStripMenuItemStop_Click);
            // 
            // toolStripMenuItemRunHere
            // 
            this.toolStripMenuItemRunHere.Image = global::MKB.Properties.Resources.run_here;
            this.toolStripMenuItemRunHere.Name = "toolStripMenuItemRunHere";
            this.toolStripMenuItemRunHere.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemRunHere.Text = "从这运行 (F6)";
            this.toolStripMenuItemRunHere.Click += new System.EventHandler(this.toolStripMenuItemRunHere_Click);
            // 
            // toolStripMenuItemRunStep
            // 
            this.toolStripMenuItemRunStep.Image = global::MKB.Properties.Resources.run_step;
            this.toolStripMenuItemRunStep.Name = "toolStripMenuItemRunStep";
            this.toolStripMenuItemRunStep.Size = new System.Drawing.Size(215, 26);
            this.toolStripMenuItemRunStep.Text = "单步运行 (F10)";
            this.toolStripMenuItemRunStep.Click += new System.EventHandler(this.toolStripMenuItemRunStep_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(78, 40);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(274, 31);
            this.labelTitle.TabIndex = 8;
            this.labelTitle.Text = "鼠标键盘自动控制插件";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.DoubleClick += new System.EventHandler(this.labelTitle_DoubleClick);
            // 
            // progressBarMain
            // 
            this.progressBarMain.Location = new System.Drawing.Point(16, 548);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(400, 20);
            this.progressBarMain.TabIndex = 13;
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
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
            this.menuStripMain.Size = new System.Drawing.Size(432, 29);
            this.menuStripMain.TabIndex = 15;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemImport,
            this.toolStripMenuItemExport,
            this.toolStripSeparatorFile1,
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(58, 25);
            this.toolStripMenuItemFile.Text = "文件";
            // 
            // toolStripMenuItemImport
            // 
            this.toolStripMenuItemImport.Image = global::MKB.Properties.Resources.import;
            this.toolStripMenuItemImport.Name = "toolStripMenuItemImport";
            this.toolStripMenuItemImport.Size = new System.Drawing.Size(116, 26);
            this.toolStripMenuItemImport.Text = "导入";
            this.toolStripMenuItemImport.Click += new System.EventHandler(this.toolStripMenuItemImport_Click);
            // 
            // toolStripMenuItemExport
            // 
            this.toolStripMenuItemExport.Image = global::MKB.Properties.Resources.export;
            this.toolStripMenuItemExport.Name = "toolStripMenuItemExport";
            this.toolStripMenuItemExport.Size = new System.Drawing.Size(116, 26);
            this.toolStripMenuItemExport.Text = "导出";
            this.toolStripMenuItemExport.Click += new System.EventHandler(this.toolStripMenuItemExport_Click);
            // 
            // toolStripSeparatorFile1
            // 
            this.toolStripSeparatorFile1.Name = "toolStripSeparatorFile1";
            this.toolStripSeparatorFile1.Size = new System.Drawing.Size(113, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Image = global::MKB.Properties.Resources.exit;
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(116, 26);
            this.toolStripMenuItemExit.Text = "退出";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemActive
            // 
            this.toolStripMenuItemActive.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMachineCode,
            this.toolStripMenuItemSetRegCode,
            this.toolStripSeparatorActive1,
            this.toolStripMenuItemGetRegCode});
            this.toolStripMenuItemActive.Name = "toolStripMenuItemActive";
            this.toolStripMenuItemActive.Size = new System.Drawing.Size(58, 25);
            this.toolStripMenuItemActive.Text = "激活";
            // 
            // toolStripMenuItemMachineCode
            // 
            this.toolStripMenuItemMachineCode.Image = global::MKB.Properties.Resources.locked;
            this.toolStripMenuItemMachineCode.Name = "toolStripMenuItemMachineCode";
            this.toolStripMenuItemMachineCode.Size = new System.Drawing.Size(170, 26);
            this.toolStripMenuItemMachineCode.Text = "获取机器码";
            this.toolStripMenuItemMachineCode.Click += new System.EventHandler(this.toolStripMenuItemMachineCode_Click);
            // 
            // toolStripMenuItemSetRegCode
            // 
            this.toolStripMenuItemSetRegCode.Image = global::MKB.Properties.Resources.unlocked;
            this.toolStripMenuItemSetRegCode.Name = "toolStripMenuItemSetRegCode";
            this.toolStripMenuItemSetRegCode.Size = new System.Drawing.Size(170, 26);
            this.toolStripMenuItemSetRegCode.Text = "载入注册码";
            this.toolStripMenuItemSetRegCode.Click += new System.EventHandler(this.toolStripMenuItemSetRegCode_Click);
            // 
            // toolStripSeparatorActive1
            // 
            this.toolStripSeparatorActive1.Name = "toolStripSeparatorActive1";
            this.toolStripSeparatorActive1.Size = new System.Drawing.Size(167, 6);
            // 
            // toolStripMenuItemGetRegCode
            // 
            this.toolStripMenuItemGetRegCode.Image = global::MKB.Properties.Resources.key;
            this.toolStripMenuItemGetRegCode.Name = "toolStripMenuItemGetRegCode";
            this.toolStripMenuItemGetRegCode.Size = new System.Drawing.Size(170, 26);
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
            this.toolStripMenuItemAbout.Image = global::MKB.Properties.Resources.about;
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(116, 26);
            this.toolStripMenuItemAbout.Text = "关于";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // treeViewMain
            // 
            this.treeViewMain.ContextMenuStrip = this.contextMenuStripMain;
            this.treeViewMain.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeViewMain.Location = new System.Drawing.Point(16, 80);
            this.treeViewMain.Name = "treeViewMain";
            this.treeViewMain.Size = new System.Drawing.Size(400, 455);
            this.treeViewMain.TabIndex = 17;
            this.treeViewMain.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewMain_NodeMouseDoubleClick);
            this.treeViewMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewMain_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(432, 581);
            this.Controls.Add(this.treeViewMain);
            this.Controls.Add(this.progressBarMain);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(448, 620);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(448, 620);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mouse and Keyboard Control ";
            this.contextMenuStripMain.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ProgressBar progressBarMain;
        private System.Windows.Forms.Timer timerMain;
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
        private System.Windows.Forms.TreeView treeViewMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewCmd;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMoveUp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMoveDn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRun;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRunHere;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRunStep;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewGrp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorFile1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorActive1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStop;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPaste;
    }
}


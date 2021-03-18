namespace MKB.SubForm
{
    partial class GrpConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDescr = new System.Windows.Forms.Label();
            this.textBoxDescr = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelTimes = new System.Windows.Forms.Label();
            this.numericUpDownTimes = new System.Windows.Forms.NumericUpDown();
            this.labelIndex = new System.Windows.Forms.Label();
            this.textBoxIndexE = new System.Windows.Forms.TextBox();
            this.textBoxIndexS = new System.Windows.Forms.TextBox();
            this.labelIndexDelta = new System.Windows.Forms.Label();
            this.labelParamPos = new System.Windows.Forms.Label();
            this.comboBoxCmd = new System.Windows.Forms.ComboBox();
            this.comboBoxParam = new System.Windows.Forms.ComboBox();
            this.buttonParamPosDel = new System.Windows.Forms.Button();
            this.buttonParamPosAdd = new System.Windows.Forms.Button();
            this.comboBoxParamPos = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(97, 15);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(196, 31);
            this.labelTitle.TabIndex = 101;
            this.labelTitle.Text = "命令组配置窗口";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDescr
            // 
            this.labelDescr.AutoSize = true;
            this.labelDescr.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDescr.Location = new System.Drawing.Point(15, 258);
            this.labelDescr.Name = "labelDescr";
            this.labelDescr.Size = new System.Drawing.Size(52, 25);
            this.labelDescr.TabIndex = 106;
            this.labelDescr.Text = "描述";
            this.labelDescr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDescr
            // 
            this.textBoxDescr.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDescr.Location = new System.Drawing.Point(73, 255);
            this.textBoxDescr.Name = "textBoxDescr";
            this.textBoxDescr.Size = new System.Drawing.Size(299, 33);
            this.textBoxDescr.TabIndex = 4;
            this.textBoxDescr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCancel.Location = new System.Drawing.Point(272, 310);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 33);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOK.Location = new System.Drawing.Point(145, 310);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 33);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelTimes
            // 
            this.labelTimes.AutoSize = true;
            this.labelTimes.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTimes.Location = new System.Drawing.Point(15, 65);
            this.labelTimes.Name = "labelTimes";
            this.labelTimes.Size = new System.Drawing.Size(92, 25);
            this.labelTimes.TabIndex = 102;
            this.labelTimes.Text = "循环次数";
            this.labelTimes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownTimes
            // 
            this.numericUpDownTimes.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F);
            this.numericUpDownTimes.Location = new System.Drawing.Point(113, 63);
            this.numericUpDownTimes.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownTimes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimes.Name = "numericUpDownTimes";
            this.numericUpDownTimes.Size = new System.Drawing.Size(64, 33);
            this.numericUpDownTimes.TabIndex = 1;
            this.numericUpDownTimes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownTimes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTimes.ValueChanged += new System.EventHandler(this.numericUpDownTimes_ValueChanged);
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.labelIndex.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelIndex.Location = new System.Drawing.Point(15, 114);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(92, 25);
            this.labelIndex.TabIndex = 103;
            this.labelIndex.Text = "循环索引";
            this.labelIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxIndexE
            // 
            this.textBoxIndexE.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxIndexE.Location = new System.Drawing.Point(187, 111);
            this.textBoxIndexE.Name = "textBoxIndexE";
            this.textBoxIndexE.Size = new System.Drawing.Size(64, 33);
            this.textBoxIndexE.TabIndex = 3;
            this.textBoxIndexE.Tag = "0";
            this.textBoxIndexE.Text = "0";
            this.textBoxIndexE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxIndexE.TextChanged += new System.EventHandler(this.textBoxIndexE_TextChanged);
            // 
            // textBoxIndexS
            // 
            this.textBoxIndexS.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxIndexS.Location = new System.Drawing.Point(113, 111);
            this.textBoxIndexS.Name = "textBoxIndexS";
            this.textBoxIndexS.Size = new System.Drawing.Size(64, 33);
            this.textBoxIndexS.TabIndex = 2;
            this.textBoxIndexS.Tag = "0";
            this.textBoxIndexS.Text = "0";
            this.textBoxIndexS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxIndexS.TextChanged += new System.EventHandler(this.textBoxIndexS_TextChanged);
            // 
            // labelIndexDelta
            // 
            this.labelIndexDelta.AutoSize = true;
            this.labelIndexDelta.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelIndexDelta.Location = new System.Drawing.Point(260, 114);
            this.labelIndexDelta.Name = "labelIndexDelta";
            this.labelIndexDelta.Size = new System.Drawing.Size(92, 25);
            this.labelIndexDelta.TabIndex = 104;
            this.labelIndexDelta.Tag = new string[] {
        "Δ= ",
        "Δ= 无效",
        "Δ= 非数值",
        "Δ= 非整型"};
            this.labelIndexDelta.Text = "Δ= 无效";
            this.labelIndexDelta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelParamPos
            // 
            this.labelParamPos.AutoSize = true;
            this.labelParamPos.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelParamPos.Location = new System.Drawing.Point(15, 162);
            this.labelParamPos.Name = "labelParamPos";
            this.labelParamPos.Size = new System.Drawing.Size(92, 25);
            this.labelParamPos.TabIndex = 105;
            this.labelParamPos.Text = "参数位置";
            this.labelParamPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxCmd
            // 
            this.comboBoxCmd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCmd.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxCmd.FormattingEnabled = true;
            this.comboBoxCmd.Location = new System.Drawing.Point(73, 206);
            this.comboBoxCmd.Name = "comboBoxCmd";
            this.comboBoxCmd.Size = new System.Drawing.Size(217, 33);
            this.comboBoxCmd.TabIndex = 8;
            // 
            // comboBoxParam
            // 
            this.comboBoxParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParam.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxParam.FormattingEnabled = true;
            this.comboBoxParam.Location = new System.Drawing.Point(296, 206);
            this.comboBoxParam.Name = "comboBoxParam";
            this.comboBoxParam.Size = new System.Drawing.Size(76, 33);
            this.comboBoxParam.TabIndex = 9;
            // 
            // buttonParamPosDel
            // 
            this.buttonParamPosDel.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonParamPosDel.Image = global::MKB.Properties.Resources.minus;
            this.buttonParamPosDel.Location = new System.Drawing.Point(296, 158);
            this.buttonParamPosDel.Name = "buttonParamPosDel";
            this.buttonParamPosDel.Size = new System.Drawing.Size(32, 32);
            this.buttonParamPosDel.TabIndex = 7;
            this.buttonParamPosDel.UseVisualStyleBackColor = true;
            this.buttonParamPosDel.Click += new System.EventHandler(this.buttonParamPosDel_Click);
            // 
            // buttonParamPosAdd
            // 
            this.buttonParamPosAdd.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonParamPosAdd.Image = global::MKB.Properties.Resources.plus;
            this.buttonParamPosAdd.Location = new System.Drawing.Point(258, 158);
            this.buttonParamPosAdd.Name = "buttonParamPosAdd";
            this.buttonParamPosAdd.Size = new System.Drawing.Size(32, 32);
            this.buttonParamPosAdd.TabIndex = 6;
            this.buttonParamPosAdd.UseVisualStyleBackColor = true;
            this.buttonParamPosAdd.Click += new System.EventHandler(this.buttonParamPos_Click);
            // 
            // comboBoxParamPos
            // 
            this.comboBoxParamPos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParamPos.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxParamPos.FormattingEnabled = true;
            this.comboBoxParamPos.Location = new System.Drawing.Point(113, 158);
            this.comboBoxParamPos.Name = "comboBoxParamPos";
            this.comboBoxParamPos.Size = new System.Drawing.Size(138, 33);
            this.comboBoxParamPos.Sorted = true;
            this.comboBoxParamPos.TabIndex = 5;
            // 
            // GrpConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.buttonParamPosDel);
            this.Controls.Add(this.comboBoxParam);
            this.Controls.Add(this.comboBoxCmd);
            this.Controls.Add(this.buttonParamPosAdd);
            this.Controls.Add(this.labelParamPos);
            this.Controls.Add(this.labelIndexDelta);
            this.Controls.Add(this.textBoxIndexE);
            this.Controls.Add(this.textBoxIndexS);
            this.Controls.Add(this.labelIndex);
            this.Controls.Add(this.numericUpDownTimes);
            this.Controls.Add(this.labelTimes);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxDescr);
            this.Controls.Add(this.labelDescr);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.comboBoxParamPos);
            this.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "GrpConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "命令组配置窗口";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrpConfigForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDescr;
        private System.Windows.Forms.TextBox textBoxDescr;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelTimes;
        private System.Windows.Forms.NumericUpDown numericUpDownTimes;
        private System.Windows.Forms.Label labelIndex;
        private System.Windows.Forms.TextBox textBoxIndexE;
        private System.Windows.Forms.TextBox textBoxIndexS;
        private System.Windows.Forms.Label labelIndexDelta;
        private System.Windows.Forms.Label labelParamPos;
        private System.Windows.Forms.Button buttonParamPosAdd;
        private System.Windows.Forms.ComboBox comboBoxCmd;
        private System.Windows.Forms.ComboBox comboBoxParam;
        private System.Windows.Forms.Button buttonParamPosDel;
        private System.Windows.Forms.ComboBox comboBoxParamPos;
    }
}
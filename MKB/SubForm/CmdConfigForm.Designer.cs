namespace MKB.SubForm
{
    partial class CmdConfigForm
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
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxPosX = new System.Windows.Forms.TextBox();
            this.buttonGetMousePos = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPos = new System.Windows.Forms.Label();
            this.labelOp = new System.Windows.Forms.Label();
            this.labelDelay = new System.Windows.Forms.Label();
            this.labelDescr = new System.Windows.Forms.Label();
            this.comboBoxOp = new System.Windows.Forms.ComboBox();
            this.comboBoxDelay = new System.Windows.Forms.ComboBox();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.textBoxDescr = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxPosY = new System.Windows.Forms.TextBox();
            this.textBoxOp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelType.Location = new System.Drawing.Point(15, 65);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(52, 25);
            this.labelType.TabIndex = 102;
            this.labelType.Text = "类型";
            this.labelType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(73, 62);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(64, 33);
            this.comboBoxType.TabIndex = 1;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // textBoxPosX
            // 
            this.textBoxPosX.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPosX.Location = new System.Drawing.Point(73, 110);
            this.textBoxPosX.Name = "textBoxPosX";
            this.textBoxPosX.Size = new System.Drawing.Size(64, 33);
            this.textBoxPosX.TabIndex = 2;
            this.textBoxPosX.Text = "0";
            this.textBoxPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonGetMousePos
            // 
            this.buttonGetMousePos.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonGetMousePos.Location = new System.Drawing.Point(226, 110);
            this.buttonGetMousePos.Name = "buttonGetMousePos";
            this.buttonGetMousePos.Size = new System.Drawing.Size(80, 33);
            this.buttonGetMousePos.TabIndex = 4;
            this.buttonGetMousePos.Text = "Get";
            this.buttonGetMousePos.UseVisualStyleBackColor = true;
            this.buttonGetMousePos.Click += new System.EventHandler(this.buttonGetMousePos_Click);
            this.buttonGetMousePos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonGetMousePos_KeyDown);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(106, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(170, 31);
            this.labelTitle.TabIndex = 101;
            this.labelTitle.Text = "命令配置窗口";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPos
            // 
            this.labelPos.AutoSize = true;
            this.labelPos.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelPos.Location = new System.Drawing.Point(15, 114);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(52, 25);
            this.labelPos.TabIndex = 103;
            this.labelPos.Text = "位置";
            this.labelPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelOp
            // 
            this.labelOp.AutoSize = true;
            this.labelOp.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelOp.Location = new System.Drawing.Point(15, 162);
            this.labelOp.Name = "labelOp";
            this.labelOp.Size = new System.Drawing.Size(52, 25);
            this.labelOp.TabIndex = 104;
            this.labelOp.Text = "操作";
            this.labelOp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDelay.Location = new System.Drawing.Point(15, 210);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(52, 25);
            this.labelDelay.TabIndex = 105;
            this.labelDelay.Text = "延时";
            this.labelDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // comboBoxOp
            // 
            this.comboBoxOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOp.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxOp.FormattingEnabled = true;
            this.comboBoxOp.Location = new System.Drawing.Point(73, 158);
            this.comboBoxOp.Name = "comboBoxOp";
            this.comboBoxOp.Size = new System.Drawing.Size(105, 33);
            this.comboBoxOp.TabIndex = 5;
            this.comboBoxOp.SelectedIndexChanged += new System.EventHandler(this.comboBoxOp_SelectedIndexChanged);
            // 
            // comboBoxDelay
            // 
            this.comboBoxDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDelay.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxDelay.FormattingEnabled = true;
            this.comboBoxDelay.Location = new System.Drawing.Point(226, 206);
            this.comboBoxDelay.Name = "comboBoxDelay";
            this.comboBoxDelay.Size = new System.Drawing.Size(48, 33);
            this.comboBoxDelay.TabIndex = 8;
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDelay.Location = new System.Drawing.Point(73, 206);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(138, 33);
            this.textBoxDelay.TabIndex = 7;
            this.textBoxDelay.Text = "0";
            this.textBoxDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxDescr
            // 
            this.textBoxDescr.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDescr.Location = new System.Drawing.Point(73, 254);
            this.textBoxDescr.Name = "textBoxDescr";
            this.textBoxDescr.Size = new System.Drawing.Size(299, 33);
            this.textBoxDescr.TabIndex = 9;
            this.textBoxDescr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // textBoxPosY
            // 
            this.textBoxPosY.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxPosY.Location = new System.Drawing.Point(147, 110);
            this.textBoxPosY.Name = "textBoxPosY";
            this.textBoxPosY.Size = new System.Drawing.Size(64, 33);
            this.textBoxPosY.TabIndex = 3;
            this.textBoxPosY.Text = "0";
            this.textBoxPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxOp
            // 
            this.textBoxOp.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxOp.Location = new System.Drawing.Point(187, 158);
            this.textBoxOp.Name = "textBoxOp";
            this.textBoxOp.Size = new System.Drawing.Size(185, 33);
            this.textBoxOp.TabIndex = 6;
            this.textBoxOp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxOp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxOp_KeyDown);
            // 
            // CmdConfigForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.textBoxOp);
            this.Controls.Add(this.textBoxPosY);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxDescr);
            this.Controls.Add(this.textBoxDelay);
            this.Controls.Add(this.comboBoxDelay);
            this.Controls.Add(this.comboBoxOp);
            this.Controls.Add(this.labelDescr);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.labelOp);
            this.Controls.Add(this.labelPos);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonGetMousePos);
            this.Controls.Add(this.textBoxPosX);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelType);
            this.Font = new System.Drawing.Font("YaHei Consolas Hybrid", 12F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "CmdConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "命令配置窗口";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmdConfigForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxPosX;
        private System.Windows.Forms.Button buttonGetMousePos;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPos;
        private System.Windows.Forms.Label labelOp;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.Label labelDescr;
        private System.Windows.Forms.ComboBox comboBoxOp;
        private System.Windows.Forms.ComboBox comboBoxDelay;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.TextBox textBoxDescr;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxPosY;
        private System.Windows.Forms.TextBox textBoxOp;
    }
}
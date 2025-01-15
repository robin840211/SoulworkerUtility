namespace TitleParser
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Export = new System.Windows.Forms.Button();
            this.tb_InputPath = new System.Windows.Forms.TextBox();
            this.btn_InputPathSelect = new System.Windows.Forms.Button();
            this.lb_InputPath = new System.Windows.Forms.Label();
            this.tb_OutputPath = new System.Windows.Forms.TextBox();
            this.btn_OutputPathSelect = new System.Windows.Forms.Button();
            this.lb_OutputPath = new System.Windows.Forms.Label();
            this.gpBox_ExportType = new System.Windows.Forms.GroupBox();
            this.rdBtn_ExportTypeHTML = new System.Windows.Forms.RadioButton();
            this.rdBtn_ExportTypeCSV = new System.Windows.Forms.RadioButton();
            this.rdBtn_ExportTypeTXT = new System.Windows.Forms.RadioButton();
            this.gpBox_LangVersion = new System.Windows.Forms.GroupBox();
            this.rdBtn_LangOther = new System.Windows.Forms.RadioButton();
            this.rdBtn_LangENG = new System.Windows.Forms.RadioButton();
            this.rdBtn_LangKOR = new System.Windows.Forms.RadioButton();
            this.rdBtn_LangJPN = new System.Windows.Forms.RadioButton();
            this.rdBtn_LangTWN = new System.Windows.Forms.RadioButton();
            this.gpBox_ExportType.SuspendLayout();
            this.gpBox_LangVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(335, 70);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 23);
            this.btn_Export.TabIndex = 0;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // tb_InputPath
            // 
            this.tb_InputPath.Location = new System.Drawing.Point(81, 12);
            this.tb_InputPath.Name = "tb_InputPath";
            this.tb_InputPath.Size = new System.Drawing.Size(248, 22);
            this.tb_InputPath.TabIndex = 1;
            // 
            // btn_InputPathSelect
            // 
            this.btn_InputPathSelect.Location = new System.Drawing.Point(335, 12);
            this.btn_InputPathSelect.Name = "btn_InputPathSelect";
            this.btn_InputPathSelect.Size = new System.Drawing.Size(75, 23);
            this.btn_InputPathSelect.TabIndex = 2;
            this.btn_InputPathSelect.Text = "Select...";
            this.btn_InputPathSelect.UseVisualStyleBackColor = true;
            this.btn_InputPathSelect.Click += new System.EventHandler(this.btn_InputPath_Click);
            // 
            // lb_InputPath
            // 
            this.lb_InputPath.AutoSize = true;
            this.lb_InputPath.Location = new System.Drawing.Point(12, 16);
            this.lb_InputPath.Name = "lb_InputPath";
            this.lb_InputPath.Size = new System.Drawing.Size(56, 12);
            this.lb_InputPath.TabIndex = 3;
            this.lb_InputPath.Text = "Input Path:";
            // 
            // tb_OutputPath
            // 
            this.tb_OutputPath.Location = new System.Drawing.Point(81, 40);
            this.tb_OutputPath.Name = "tb_OutputPath";
            this.tb_OutputPath.Size = new System.Drawing.Size(248, 22);
            this.tb_OutputPath.TabIndex = 1;
            // 
            // btn_OutputPathSelect
            // 
            this.btn_OutputPathSelect.Location = new System.Drawing.Point(335, 41);
            this.btn_OutputPathSelect.Name = "btn_OutputPathSelect";
            this.btn_OutputPathSelect.Size = new System.Drawing.Size(75, 23);
            this.btn_OutputPathSelect.TabIndex = 2;
            this.btn_OutputPathSelect.Text = "Select...";
            this.btn_OutputPathSelect.UseVisualStyleBackColor = true;
            this.btn_OutputPathSelect.Click += new System.EventHandler(this.btn_OutputPath_Click);
            // 
            // lb_OutputPath
            // 
            this.lb_OutputPath.AutoSize = true;
            this.lb_OutputPath.Location = new System.Drawing.Point(12, 43);
            this.lb_OutputPath.Name = "lb_OutputPath";
            this.lb_OutputPath.Size = new System.Drawing.Size(63, 12);
            this.lb_OutputPath.TabIndex = 3;
            this.lb_OutputPath.Text = "Output Path:";
            // 
            // gpBox_ExportType
            // 
            this.gpBox_ExportType.Controls.Add(this.rdBtn_ExportTypeHTML);
            this.gpBox_ExportType.Controls.Add(this.rdBtn_ExportTypeCSV);
            this.gpBox_ExportType.Controls.Add(this.rdBtn_ExportTypeTXT);
            this.gpBox_ExportType.Location = new System.Drawing.Point(12, 68);
            this.gpBox_ExportType.Name = "gpBox_ExportType";
            this.gpBox_ExportType.Size = new System.Drawing.Size(142, 50);
            this.gpBox_ExportType.TabIndex = 5;
            this.gpBox_ExportType.TabStop = false;
            this.gpBox_ExportType.Text = "Export to";
            // 
            // rdBtn_ExportTypeHTML
            // 
            this.rdBtn_ExportTypeHTML.AutoSize = true;
            this.rdBtn_ExportTypeHTML.Location = new System.Drawing.Point(92, 22);
            this.rdBtn_ExportTypeHTML.Name = "rdBtn_ExportTypeHTML";
            this.rdBtn_ExportTypeHTML.Size = new System.Drawing.Size(44, 16);
            this.rdBtn_ExportTypeHTML.TabIndex = 0;
            this.rdBtn_ExportTypeHTML.TabStop = true;
            this.rdBtn_ExportTypeHTML.Text = "html";
            this.rdBtn_ExportTypeHTML.UseVisualStyleBackColor = true;
            // 
            // rdBtn_ExportTypeCSV
            // 
            this.rdBtn_ExportTypeCSV.AutoSize = true;
            this.rdBtn_ExportTypeCSV.Location = new System.Drawing.Point(48, 22);
            this.rdBtn_ExportTypeCSV.Name = "rdBtn_ExportTypeCSV";
            this.rdBtn_ExportTypeCSV.Size = new System.Drawing.Size(38, 16);
            this.rdBtn_ExportTypeCSV.TabIndex = 0;
            this.rdBtn_ExportTypeCSV.TabStop = true;
            this.rdBtn_ExportTypeCSV.Text = "csv";
            this.rdBtn_ExportTypeCSV.UseVisualStyleBackColor = true;
            // 
            // rdBtn_ExportTypeTXT
            // 
            this.rdBtn_ExportTypeTXT.AutoSize = true;
            this.rdBtn_ExportTypeTXT.Location = new System.Drawing.Point(7, 22);
            this.rdBtn_ExportTypeTXT.Name = "rdBtn_ExportTypeTXT";
            this.rdBtn_ExportTypeTXT.Size = new System.Drawing.Size(35, 16);
            this.rdBtn_ExportTypeTXT.TabIndex = 0;
            this.rdBtn_ExportTypeTXT.TabStop = true;
            this.rdBtn_ExportTypeTXT.Text = "txt";
            this.rdBtn_ExportTypeTXT.UseVisualStyleBackColor = true;
            // 
            // gpBox_LangVersion
            // 
            this.gpBox_LangVersion.Controls.Add(this.rdBtn_LangOther);
            this.gpBox_LangVersion.Controls.Add(this.rdBtn_LangENG);
            this.gpBox_LangVersion.Controls.Add(this.rdBtn_LangKOR);
            this.gpBox_LangVersion.Controls.Add(this.rdBtn_LangJPN);
            this.gpBox_LangVersion.Controls.Add(this.rdBtn_LangTWN);
            this.gpBox_LangVersion.Location = new System.Drawing.Point(12, 124);
            this.gpBox_LangVersion.Name = "gpBox_LangVersion";
            this.gpBox_LangVersion.Size = new System.Drawing.Size(278, 50);
            this.gpBox_LangVersion.TabIndex = 6;
            this.gpBox_LangVersion.TabStop = false;
            this.gpBox_LangVersion.Text = "Lang Version";
            // 
            // rdBtn_LangOther
            // 
            this.rdBtn_LangOther.AutoSize = true;
            this.rdBtn_LangOther.Location = new System.Drawing.Point(213, 21);
            this.rdBtn_LangOther.Name = "rdBtn_LangOther";
            this.rdBtn_LangOther.Size = new System.Drawing.Size(59, 16);
            this.rdBtn_LangOther.TabIndex = 2;
            this.rdBtn_LangOther.TabStop = true;
            this.rdBtn_LangOther.Text = "Custom";
            this.rdBtn_LangOther.UseVisualStyleBackColor = true;
            this.rdBtn_LangOther.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rdBtn_LangENG
            // 
            this.rdBtn_LangENG.AutoSize = true;
            this.rdBtn_LangENG.Location = new System.Drawing.Point(161, 21);
            this.rdBtn_LangENG.Name = "rdBtn_LangENG";
            this.rdBtn_LangENG.Size = new System.Drawing.Size(46, 16);
            this.rdBtn_LangENG.TabIndex = 1;
            this.rdBtn_LangENG.TabStop = true;
            this.rdBtn_LangENG.Text = "ENG";
            this.rdBtn_LangENG.UseVisualStyleBackColor = true;
            this.rdBtn_LangENG.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rdBtn_LangKOR
            // 
            this.rdBtn_LangKOR.AutoSize = true;
            this.rdBtn_LangKOR.Location = new System.Drawing.Point(6, 21);
            this.rdBtn_LangKOR.Name = "rdBtn_LangKOR";
            this.rdBtn_LangKOR.Size = new System.Drawing.Size(47, 16);
            this.rdBtn_LangKOR.TabIndex = 0;
            this.rdBtn_LangKOR.TabStop = true;
            this.rdBtn_LangKOR.Text = "KOR";
            this.rdBtn_LangKOR.UseVisualStyleBackColor = true;
            this.rdBtn_LangKOR.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rdBtn_LangJPN
            // 
            this.rdBtn_LangJPN.AutoSize = true;
            this.rdBtn_LangJPN.Location = new System.Drawing.Point(59, 21);
            this.rdBtn_LangJPN.Name = "rdBtn_LangJPN";
            this.rdBtn_LangJPN.Size = new System.Drawing.Size(41, 16);
            this.rdBtn_LangJPN.TabIndex = 0;
            this.rdBtn_LangJPN.TabStop = true;
            this.rdBtn_LangJPN.Text = "JPN";
            this.rdBtn_LangJPN.UseVisualStyleBackColor = true;
            this.rdBtn_LangJPN.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rdBtn_LangTWN
            // 
            this.rdBtn_LangTWN.AutoSize = true;
            this.rdBtn_LangTWN.Checked = true;
            this.rdBtn_LangTWN.Location = new System.Drawing.Point(106, 21);
            this.rdBtn_LangTWN.Name = "rdBtn_LangTWN";
            this.rdBtn_LangTWN.Size = new System.Drawing.Size(49, 16);
            this.rdBtn_LangTWN.TabIndex = 0;
            this.rdBtn_LangTWN.TabStop = true;
            this.rdBtn_LangTWN.Text = "TWN";
            this.rdBtn_LangTWN.UseVisualStyleBackColor = true;
            this.rdBtn_LangTWN.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 186);
            this.Controls.Add(this.gpBox_LangVersion);
            this.Controls.Add(this.gpBox_ExportType);
            this.Controls.Add(this.lb_OutputPath);
            this.Controls.Add(this.lb_InputPath);
            this.Controls.Add(this.btn_OutputPathSelect);
            this.Controls.Add(this.btn_InputPathSelect);
            this.Controls.Add(this.tb_OutputPath);
            this.Controls.Add(this.tb_InputPath);
            this.Controls.Add(this.btn_Export);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Title Parser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gpBox_ExportType.ResumeLayout(false);
            this.gpBox_ExportType.PerformLayout();
            this.gpBox_LangVersion.ResumeLayout(false);
            this.gpBox_LangVersion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.TextBox tb_InputPath;
        private System.Windows.Forms.Button btn_InputPathSelect;
        private System.Windows.Forms.Label lb_InputPath;
        private System.Windows.Forms.TextBox tb_OutputPath;
        private System.Windows.Forms.Button btn_OutputPathSelect;
        private System.Windows.Forms.Label lb_OutputPath;
        private System.Windows.Forms.GroupBox gpBox_ExportType;
        private System.Windows.Forms.RadioButton rdBtn_ExportTypeHTML;
        private System.Windows.Forms.RadioButton rdBtn_ExportTypeCSV;
        private System.Windows.Forms.RadioButton rdBtn_ExportTypeTXT;
        private System.Windows.Forms.GroupBox gpBox_LangVersion;
        private System.Windows.Forms.RadioButton rdBtn_LangKOR;
        private System.Windows.Forms.RadioButton rdBtn_LangJPN;
        private System.Windows.Forms.RadioButton rdBtn_LangTWN;
        private System.Windows.Forms.RadioButton rdBtn_LangOther;
        private System.Windows.Forms.RadioButton rdBtn_LangENG;
    }
}


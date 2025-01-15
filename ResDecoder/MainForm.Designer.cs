namespace ResDecoder
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
            this.btn_InputPath = new System.Windows.Forms.Button();
            this.tb_InputPath = new System.Windows.Forms.TextBox();
            this.numUD_Characters = new System.Windows.Forms.NumericUpDown();
            this.lb_Characters = new System.Windows.Forms.Label();
            this.btn_OutputPath = new System.Windows.Forms.Button();
            this.tb_OutputPath = new System.Windows.Forms.TextBox();
            this.rdBtn_LangNone = new System.Windows.Forms.RadioButton();
            this.lb_LangVersion = new System.Windows.Forms.Label();
            this.rdBtn_LangKOR = new System.Windows.Forms.RadioButton();
            this.rdBtn_LangJPN = new System.Windows.Forms.RadioButton();
            this.rdBtn_LangTWN = new System.Windows.Forms.RadioButton();
            this.rdBtn_LangENG = new System.Windows.Forms.RadioButton();
            this.lb_Characters_Hint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Characters)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(424, 40);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(75, 23);
            this.btn_Export.TabIndex = 0;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_InputPath
            // 
            this.btn_InputPath.Location = new System.Drawing.Point(9, 40);
            this.btn_InputPath.Name = "btn_InputPath";
            this.btn_InputPath.Size = new System.Drawing.Size(75, 23);
            this.btn_InputPath.TabIndex = 0;
            this.btn_InputPath.Text = "Res Path";
            this.btn_InputPath.UseVisualStyleBackColor = true;
            this.btn_InputPath.Click += new System.EventHandler(this.btn_InputPath_Click);
            // 
            // tb_InputPath
            // 
            this.tb_InputPath.Location = new System.Drawing.Point(91, 40);
            this.tb_InputPath.Name = "tb_InputPath";
            this.tb_InputPath.Size = new System.Drawing.Size(315, 22);
            this.tb_InputPath.TabIndex = 1;
            // 
            // numUD_Characters
            // 
            this.numUD_Characters.Location = new System.Drawing.Point(91, 12);
            this.numUD_Characters.Name = "numUD_Characters";
            this.numUD_Characters.Size = new System.Drawing.Size(70, 22);
            this.numUD_Characters.TabIndex = 2;
            this.numUD_Characters.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lb_Characters
            // 
            this.lb_Characters.AutoSize = true;
            this.lb_Characters.Location = new System.Drawing.Point(29, 16);
            this.lb_Characters.Name = "lb_Characters";
            this.lb_Characters.Size = new System.Drawing.Size(57, 12);
            this.lb_Characters.TabIndex = 3;
            this.lb_Characters.Text = "Characters:";
            // 
            // btn_OutputPath
            // 
            this.btn_OutputPath.Location = new System.Drawing.Point(9, 68);
            this.btn_OutputPath.Name = "btn_OutputPath";
            this.btn_OutputPath.Size = new System.Drawing.Size(75, 23);
            this.btn_OutputPath.TabIndex = 0;
            this.btn_OutputPath.Text = "Export Path";
            this.btn_OutputPath.UseVisualStyleBackColor = true;
            this.btn_OutputPath.Click += new System.EventHandler(this.btn_OutputPath_Click);
            // 
            // tb_OutputPath
            // 
            this.tb_OutputPath.Location = new System.Drawing.Point(91, 68);
            this.tb_OutputPath.Name = "tb_OutputPath";
            this.tb_OutputPath.Size = new System.Drawing.Size(315, 22);
            this.tb_OutputPath.TabIndex = 1;
            // 
            // rdBtn_LangNone
            // 
            this.rdBtn_LangNone.AutoSize = true;
            this.rdBtn_LangNone.Location = new System.Drawing.Point(91, 97);
            this.rdBtn_LangNone.Name = "rdBtn_LangNone";
            this.rdBtn_LangNone.Size = new System.Drawing.Size(48, 16);
            this.rdBtn_LangNone.TabIndex = 4;
            this.rdBtn_LangNone.Text = "None";
            this.rdBtn_LangNone.UseVisualStyleBackColor = true;
            // 
            // lb_LangVersion
            // 
            this.lb_LangVersion.AutoSize = true;
            this.lb_LangVersion.Location = new System.Drawing.Point(18, 99);
            this.lb_LangVersion.Name = "lb_LangVersion";
            this.lb_LangVersion.Size = new System.Drawing.Size(68, 12);
            this.lb_LangVersion.TabIndex = 5;
            this.lb_LangVersion.Text = "Lang Version";
            // 
            // rdBtn_LangKOR
            // 
            this.rdBtn_LangKOR.AutoSize = true;
            this.rdBtn_LangKOR.Location = new System.Drawing.Point(145, 97);
            this.rdBtn_LangKOR.Name = "rdBtn_LangKOR";
            this.rdBtn_LangKOR.Size = new System.Drawing.Size(47, 16);
            this.rdBtn_LangKOR.TabIndex = 6;
            this.rdBtn_LangKOR.Text = "KOR";
            this.rdBtn_LangKOR.UseVisualStyleBackColor = true;
            // 
            // rdBtn_LangJPN
            // 
            this.rdBtn_LangJPN.AutoSize = true;
            this.rdBtn_LangJPN.Location = new System.Drawing.Point(200, 97);
            this.rdBtn_LangJPN.Name = "rdBtn_LangJPN";
            this.rdBtn_LangJPN.Size = new System.Drawing.Size(41, 16);
            this.rdBtn_LangJPN.TabIndex = 7;
            this.rdBtn_LangJPN.Text = "JPN";
            this.rdBtn_LangJPN.UseVisualStyleBackColor = true;
            // 
            // rdBtn_LangTWN
            // 
            this.rdBtn_LangTWN.AutoSize = true;
            this.rdBtn_LangTWN.Checked = true;
            this.rdBtn_LangTWN.Location = new System.Drawing.Point(247, 97);
            this.rdBtn_LangTWN.Name = "rdBtn_LangTWN";
            this.rdBtn_LangTWN.Size = new System.Drawing.Size(49, 16);
            this.rdBtn_LangTWN.TabIndex = 8;
            this.rdBtn_LangTWN.TabStop = true;
            this.rdBtn_LangTWN.Text = "TWN";
            this.rdBtn_LangTWN.UseVisualStyleBackColor = true;
            // 
            // rdBtn_LangENG
            // 
            this.rdBtn_LangENG.AutoSize = true;
            this.rdBtn_LangENG.Location = new System.Drawing.Point(302, 97);
            this.rdBtn_LangENG.Name = "rdBtn_LangENG";
            this.rdBtn_LangENG.Size = new System.Drawing.Size(46, 16);
            this.rdBtn_LangENG.TabIndex = 9;
            this.rdBtn_LangENG.Text = "ENG";
            this.rdBtn_LangENG.UseVisualStyleBackColor = true;
            // 
            // lb_Characters_Hint
            // 
            this.lb_Characters_Hint.AutoSize = true;
            this.lb_Characters_Hint.Location = new System.Drawing.Point(167, 16);
            this.lb_Characters_Hint.Name = "lb_Characters_Hint";
            this.lb_Characters_Hint.Size = new System.Drawing.Size(281, 12);
            this.lb_Characters_Hint.TabIndex = 10;
            this.lb_Characters_Hint.Text = "※How much characters the client you wanna decode have!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 125);
            this.Controls.Add(this.lb_Characters_Hint);
            this.Controls.Add(this.rdBtn_LangENG);
            this.Controls.Add(this.rdBtn_LangTWN);
            this.Controls.Add(this.rdBtn_LangJPN);
            this.Controls.Add(this.rdBtn_LangKOR);
            this.Controls.Add(this.lb_LangVersion);
            this.Controls.Add(this.rdBtn_LangNone);
            this.Controls.Add(this.lb_Characters);
            this.Controls.Add(this.numUD_Characters);
            this.Controls.Add(this.tb_OutputPath);
            this.Controls.Add(this.btn_OutputPath);
            this.Controls.Add(this.tb_InputPath);
            this.Controls.Add(this.btn_InputPath);
            this.Controls.Add(this.btn_Export);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ResDecoder";
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Characters)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_InputPath;
        private System.Windows.Forms.TextBox tb_InputPath;
        private System.Windows.Forms.NumericUpDown numUD_Characters;
        private System.Windows.Forms.Label lb_Characters;
        private System.Windows.Forms.Button btn_OutputPath;
        private System.Windows.Forms.TextBox tb_OutputPath;
        private System.Windows.Forms.RadioButton rdBtn_LangNone;
        private System.Windows.Forms.Label lb_LangVersion;
        private System.Windows.Forms.RadioButton rdBtn_LangJPN;
        private System.Windows.Forms.RadioButton rdBtn_LangTWN;
        private System.Windows.Forms.RadioButton rdBtn_LangENG;
        private System.Windows.Forms.Label lb_Characters_Hint;
        public System.Windows.Forms.RadioButton rdBtn_LangKOR;
    }
}


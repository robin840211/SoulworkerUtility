namespace CinemaParser
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
            this.btn_OutputPath = new System.Windows.Forms.Button();
            this.tb_OutputPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Export
            // 
            this.btn_Export.Location = new System.Drawing.Point(493, 13);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(83, 23);
            this.btn_Export.TabIndex = 0;
            this.btn_Export.Text = "Export";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_InputPath
            // 
            this.btn_InputPath.Location = new System.Drawing.Point(13, 12);
            this.btn_InputPath.Name = "btn_InputPath";
            this.btn_InputPath.Size = new System.Drawing.Size(110, 23);
            this.btn_InputPath.TabIndex = 1;
            this.btn_InputPath.Text = "ID txt Path";
            this.btn_InputPath.UseVisualStyleBackColor = true;
            this.btn_InputPath.Click += new System.EventHandler(this.btn_InputPath_Click);
            // 
            // tb_InputPath
            // 
            this.tb_InputPath.Location = new System.Drawing.Point(129, 13);
            this.tb_InputPath.Name = "tb_InputPath";
            this.tb_InputPath.Size = new System.Drawing.Size(358, 22);
            this.tb_InputPath.TabIndex = 2;
            // 
            // btn_OutputPath
            // 
            this.btn_OutputPath.Location = new System.Drawing.Point(13, 41);
            this.btn_OutputPath.Name = "btn_OutputPath";
            this.btn_OutputPath.Size = new System.Drawing.Size(110, 23);
            this.btn_OutputPath.TabIndex = 1;
            this.btn_OutputPath.Text = "Xml Path";
            this.btn_OutputPath.UseVisualStyleBackColor = true;
            this.btn_OutputPath.Click += new System.EventHandler(this.btn_OutputPath_Click);
            // 
            // tb_OutputPath
            // 
            this.tb_OutputPath.Location = new System.Drawing.Point(129, 41);
            this.tb_OutputPath.Name = "tb_OutputPath";
            this.tb_OutputPath.Size = new System.Drawing.Size(358, 22);
            this.tb_OutputPath.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 73);
            this.Controls.Add(this.tb_OutputPath);
            this.Controls.Add(this.btn_OutputPath);
            this.Controls.Add(this.tb_InputPath);
            this.Controls.Add(this.btn_InputPath);
            this.Controls.Add(this.btn_Export);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Cinema Parser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_InputPath;
        private System.Windows.Forms.TextBox tb_InputPath;
        private System.Windows.Forms.Button btn_OutputPath;
        private System.Windows.Forms.TextBox tb_OutputPath;
    }
}


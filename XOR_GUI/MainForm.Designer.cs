namespace XOR_GUI
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
            this.btn_XOR = new System.Windows.Forms.Button();
            this.tb_InputPath = new System.Windows.Forms.TextBox();
            this.btn_InputPath = new System.Windows.Forms.Button();
            this.btn_OutputPath = new System.Windows.Forms.Button();
            this.tb_OutputPath = new System.Windows.Forms.TextBox();
            this.tb_Log = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_XOR
            // 
            this.btn_XOR.Location = new System.Drawing.Point(386, 12);
            this.btn_XOR.Name = "btn_XOR";
            this.btn_XOR.Size = new System.Drawing.Size(75, 23);
            this.btn_XOR.TabIndex = 0;
            this.btn_XOR.Text = "XOR";
            this.btn_XOR.UseVisualStyleBackColor = true;
            this.btn_XOR.Click += new System.EventHandler(this.btn_XOR_Click);
            // 
            // tb_InputPath
            // 
            this.tb_InputPath.Location = new System.Drawing.Point(93, 12);
            this.tb_InputPath.Name = "tb_InputPath";
            this.tb_InputPath.Size = new System.Drawing.Size(277, 22);
            this.tb_InputPath.TabIndex = 1;
            // 
            // btn_InputPath
            // 
            this.btn_InputPath.Location = new System.Drawing.Point(12, 12);
            this.btn_InputPath.Name = "btn_InputPath";
            this.btn_InputPath.Size = new System.Drawing.Size(75, 23);
            this.btn_InputPath.TabIndex = 0;
            this.btn_InputPath.Text = "Input Path";
            this.btn_InputPath.UseVisualStyleBackColor = true;
            this.btn_InputPath.Click += new System.EventHandler(this.btn_InputPath_Click);
            // 
            // btn_OutputPath
            // 
            this.btn_OutputPath.Location = new System.Drawing.Point(12, 40);
            this.btn_OutputPath.Name = "btn_OutputPath";
            this.btn_OutputPath.Size = new System.Drawing.Size(75, 23);
            this.btn_OutputPath.TabIndex = 0;
            this.btn_OutputPath.Text = "Output Path";
            this.btn_OutputPath.UseVisualStyleBackColor = true;
            this.btn_OutputPath.Click += new System.EventHandler(this.btn_OutputPath_Click);
            // 
            // tb_OutputPath
            // 
            this.tb_OutputPath.Location = new System.Drawing.Point(93, 40);
            this.tb_OutputPath.Name = "tb_OutputPath";
            this.tb_OutputPath.Size = new System.Drawing.Size(277, 22);
            this.tb_OutputPath.TabIndex = 1;
            // 
            // tb_Log
            // 
            this.tb_Log.Location = new System.Drawing.Point(13, 70);
            this.tb_Log.Multiline = true;
            this.tb_Log.Name = "tb_Log";
            this.tb_Log.ReadOnly = true;
            this.tb_Log.Size = new System.Drawing.Size(448, 109);
            this.tb_Log.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 191);
            this.Controls.Add(this.tb_Log);
            this.Controls.Add(this.tb_OutputPath);
            this.Controls.Add(this.btn_OutputPath);
            this.Controls.Add(this.tb_InputPath);
            this.Controls.Add(this.btn_InputPath);
            this.Controls.Add(this.btn_XOR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "XOR_GUI";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_XOR;
        private System.Windows.Forms.TextBox tb_InputPath;
        private System.Windows.Forms.Button btn_InputPath;
        private System.Windows.Forms.Button btn_OutputPath;
        private System.Windows.Forms.TextBox tb_OutputPath;
        private System.Windows.Forms.TextBox tb_Log;
    }
}


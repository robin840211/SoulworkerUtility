namespace SkillParser
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
            if (disposing && (components != null)) {
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
            this.btn_Parse = new System.Windows.Forms.Button();
            this.tb_InputPath = new System.Windows.Forms.TextBox();
            this.lb_InputPath = new System.Windows.Forms.Label();
            this.tb_OutputPath = new System.Windows.Forms.TextBox();
            this.lb_OutputPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Parse
            // 
            this.btn_Parse.Location = new System.Drawing.Point(441, 12);
            this.btn_Parse.Name = "btn_Parse";
            this.btn_Parse.Size = new System.Drawing.Size(75, 23);
            this.btn_Parse.TabIndex = 0;
            this.btn_Parse.Text = "Parse";
            this.btn_Parse.UseVisualStyleBackColor = true;
            this.btn_Parse.Click += new System.EventHandler(this.btn_Parse_Click);
            // 
            // tb_InputPath
            // 
            this.tb_InputPath.Location = new System.Drawing.Point(78, 12);
            this.tb_InputPath.Name = "tb_InputPath";
            this.tb_InputPath.Size = new System.Drawing.Size(356, 22);
            this.tb_InputPath.TabIndex = 1;
            // 
            // lb_InputPath
            // 
            this.lb_InputPath.AutoSize = true;
            this.lb_InputPath.Location = new System.Drawing.Point(12, 16);
            this.lb_InputPath.Name = "lb_InputPath";
            this.lb_InputPath.Size = new System.Drawing.Size(53, 12);
            this.lb_InputPath.TabIndex = 2;
            this.lb_InputPath.Text = "Input Path";
            // 
            // tb_OutputPath
            // 
            this.tb_OutputPath.Location = new System.Drawing.Point(78, 41);
            this.tb_OutputPath.Name = "tb_OutputPath";
            this.tb_OutputPath.Size = new System.Drawing.Size(356, 22);
            this.tb_OutputPath.TabIndex = 1;
            // 
            // lb_OutputPath
            // 
            this.lb_OutputPath.AutoSize = true;
            this.lb_OutputPath.Location = new System.Drawing.Point(12, 44);
            this.lb_OutputPath.Name = "lb_OutputPath";
            this.lb_OutputPath.Size = new System.Drawing.Size(60, 12);
            this.lb_OutputPath.TabIndex = 2;
            this.lb_OutputPath.Text = "Output Path";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 81);
            this.Controls.Add(this.lb_OutputPath);
            this.Controls.Add(this.lb_InputPath);
            this.Controls.Add(this.tb_OutputPath);
            this.Controls.Add(this.tb_InputPath);
            this.Controls.Add(this.btn_Parse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SkillParser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Parse;
        private System.Windows.Forms.TextBox tb_InputPath;
        private System.Windows.Forms.Label lb_InputPath;
        private System.Windows.Forms.TextBox tb_OutputPath;
        private System.Windows.Forms.Label lb_OutputPath;
    }
}


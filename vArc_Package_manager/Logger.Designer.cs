
namespace vArc_Package_manager
{
	partial class Logger
	{
		/// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
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
            this.tb_Log = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_Log
            // 
            this.tb_Log.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Log.Location = new System.Drawing.Point(0, 0);
            this.tb_Log.Multiline = true;
            this.tb_Log.Name = "tb_Log";
            this.tb_Log.Size = new System.Drawing.Size(471, 238);
            this.tb_Log.TabIndex = 0;
            // 
            // Logger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 238);
            this.Controls.Add(this.tb_Log);
            this.Name = "Logger";
            this.Text = "Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Logger_FormClosing);
            this.Load += new System.EventHandler(this.Logger_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
        
        private System.Windows.Forms.TextBox tb_Log;
	}
}


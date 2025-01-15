
namespace vArc_Package_manager
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
            this.tControl_Action = new System.Windows.Forms.TabControl();
            this.tPage_Unpack = new System.Windows.Forms.TabPage();
            this.cBox_Unpack_FolderOwn = new System.Windows.Forms.CheckBox();
            this.cBox_Unpack_FolderSounds = new System.Windows.Forms.CheckBox();
            this.btn_Unpack_OutputPath = new System.Windows.Forms.Button();
            this.btn_Unpack_ClearFiles = new System.Windows.Forms.Button();
            this.btn_Unpack_RemoveFiles = new System.Windows.Forms.Button();
            this.listBox_Unpack_Files = new System.Windows.Forms.ListBox();
            this.btn_Unpack_AddFiles = new System.Windows.Forms.Button();
            this.btn_Unpack_Unpack = new System.Windows.Forms.Button();
            this.tb_Unpack_OutputPath = new System.Windows.Forms.TextBox();
            this.tPage_Pack = new System.Windows.Forms.TabPage();
            this.btn_Pack_ClearFiles = new System.Windows.Forms.Button();
            this.btn_Pack_RemoveFiles = new System.Windows.Forms.Button();
            this.listBox_Pack_Files = new System.Windows.Forms.ListBox();
            this.btn_Pack_OutputPath = new System.Windows.Forms.Button();
            this.btn_Pack_Pack = new System.Windows.Forms.Button();
            this.tb_Pack_OutputPath = new System.Windows.Forms.TextBox();
            this.btn_Pack_AddFiles = new System.Windows.Forms.Button();
            this.tControl_Action.SuspendLayout();
            this.tPage_Unpack.SuspendLayout();
            this.tPage_Pack.SuspendLayout();
            this.SuspendLayout();
            // 
            // tControl_Action
            // 
            this.tControl_Action.Controls.Add(this.tPage_Unpack);
            this.tControl_Action.Controls.Add(this.tPage_Pack);
            this.tControl_Action.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tControl_Action.Location = new System.Drawing.Point(0, 0);
            this.tControl_Action.Name = "tControl_Action";
            this.tControl_Action.SelectedIndex = 0;
            this.tControl_Action.Size = new System.Drawing.Size(551, 220);
            this.tControl_Action.TabIndex = 0;
            // 
            // tPage_Unpack
            // 
            this.tPage_Unpack.Controls.Add(this.cBox_Unpack_FolderOwn);
            this.tPage_Unpack.Controls.Add(this.cBox_Unpack_FolderSounds);
            this.tPage_Unpack.Controls.Add(this.btn_Unpack_OutputPath);
            this.tPage_Unpack.Controls.Add(this.btn_Unpack_ClearFiles);
            this.tPage_Unpack.Controls.Add(this.btn_Unpack_RemoveFiles);
            this.tPage_Unpack.Controls.Add(this.listBox_Unpack_Files);
            this.tPage_Unpack.Controls.Add(this.btn_Unpack_AddFiles);
            this.tPage_Unpack.Controls.Add(this.btn_Unpack_Unpack);
            this.tPage_Unpack.Controls.Add(this.tb_Unpack_OutputPath);
            this.tPage_Unpack.Location = new System.Drawing.Point(4, 22);
            this.tPage_Unpack.Name = "tPage_Unpack";
            this.tPage_Unpack.Padding = new System.Windows.Forms.Padding(3);
            this.tPage_Unpack.Size = new System.Drawing.Size(543, 194);
            this.tPage_Unpack.TabIndex = 0;
            this.tPage_Unpack.Text = "Unpack";
            this.tPage_Unpack.UseVisualStyleBackColor = true;
            // 
            // cBox_Unpack_FolderOwn
            // 
            this.cBox_Unpack_FolderOwn.AutoSize = true;
            this.cBox_Unpack_FolderOwn.Location = new System.Drawing.Point(282, 38);
            this.cBox_Unpack_FolderOwn.Name = "cBox_Unpack_FolderOwn";
            this.cBox_Unpack_FolderOwn.Size = new System.Drawing.Size(123, 16);
            this.cBox_Unpack_FolderOwn.TabIndex = 11;
            this.cBox_Unpack_FolderOwn.Text = "Extract to own folder";
            this.cBox_Unpack_FolderOwn.UseVisualStyleBackColor = true;
            this.cBox_Unpack_FolderOwn.CheckedChanged += new System.EventHandler(this.cBox_Unpack_FolderOwn_CheckedChanged);
            // 
            // cBox_Unpack_FolderSounds
            // 
            this.cBox_Unpack_FolderSounds.AutoSize = true;
            this.cBox_Unpack_FolderSounds.Enabled = false;
            this.cBox_Unpack_FolderSounds.Location = new System.Drawing.Point(411, 38);
            this.cBox_Unpack_FolderSounds.Name = "cBox_Unpack_FolderSounds";
            this.cBox_Unpack_FolderSounds.Size = new System.Drawing.Size(129, 16);
            this.cBox_Unpack_FolderSounds.TabIndex = 10;
            this.cBox_Unpack_FolderSounds.Text = "Extend \'Sounds\' folder";
            this.cBox_Unpack_FolderSounds.UseVisualStyleBackColor = true;
            // 
            // btn_Unpack_OutputPath
            // 
            this.btn_Unpack_OutputPath.Location = new System.Drawing.Point(0, 4);
            this.btn_Unpack_OutputPath.Name = "btn_Unpack_OutputPath";
            this.btn_Unpack_OutputPath.Size = new System.Drawing.Size(79, 23);
            this.btn_Unpack_OutputPath.TabIndex = 9;
            this.btn_Unpack_OutputPath.Text = "Output Folder";
            this.btn_Unpack_OutputPath.UseVisualStyleBackColor = true;
            this.btn_Unpack_OutputPath.Click += new System.EventHandler(this.btn_Unpack_OutputPath_Click);
            // 
            // btn_Unpack_ClearFiles
            // 
            this.btn_Unpack_ClearFiles.Location = new System.Drawing.Point(180, 34);
            this.btn_Unpack_ClearFiles.Name = "btn_Unpack_ClearFiles";
            this.btn_Unpack_ClearFiles.Size = new System.Drawing.Size(75, 23);
            this.btn_Unpack_ClearFiles.TabIndex = 8;
            this.btn_Unpack_ClearFiles.Text = "Clear";
            this.btn_Unpack_ClearFiles.UseVisualStyleBackColor = true;
            this.btn_Unpack_ClearFiles.Click += new System.EventHandler(this.btn_Unpack_ClearFiles_Click);
            // 
            // btn_Unpack_RemoveFiles
            // 
            this.btn_Unpack_RemoveFiles.Location = new System.Drawing.Point(87, 34);
            this.btn_Unpack_RemoveFiles.Name = "btn_Unpack_RemoveFiles";
            this.btn_Unpack_RemoveFiles.Size = new System.Drawing.Size(87, 23);
            this.btn_Unpack_RemoveFiles.TabIndex = 7;
            this.btn_Unpack_RemoveFiles.Text = "Remove Files";
            this.btn_Unpack_RemoveFiles.UseVisualStyleBackColor = true;
            this.btn_Unpack_RemoveFiles.Click += new System.EventHandler(this.btn_Unpack_RemoveFiles_Click);
            // 
            // listBox_Unpack_Files
            // 
            this.listBox_Unpack_Files.AllowDrop = true;
            this.listBox_Unpack_Files.FormattingEnabled = true;
            this.listBox_Unpack_Files.ItemHeight = 12;
            this.listBox_Unpack_Files.Location = new System.Drawing.Point(4, 64);
            this.listBox_Unpack_Files.Name = "listBox_Unpack_Files";
            this.listBox_Unpack_Files.Size = new System.Drawing.Size(531, 124);
            this.listBox_Unpack_Files.TabIndex = 6;
            this.listBox_Unpack_Files.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_Unpack_Files_DragDrop);
            this.listBox_Unpack_Files.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_Unpack_Files_DragEnter);
            // 
            // btn_Unpack_AddFiles
            // 
            this.btn_Unpack_AddFiles.Location = new System.Drawing.Point(6, 34);
            this.btn_Unpack_AddFiles.Name = "btn_Unpack_AddFiles";
            this.btn_Unpack_AddFiles.Size = new System.Drawing.Size(75, 23);
            this.btn_Unpack_AddFiles.TabIndex = 5;
            this.btn_Unpack_AddFiles.Text = "Add Files";
            this.btn_Unpack_AddFiles.UseVisualStyleBackColor = true;
            this.btn_Unpack_AddFiles.Click += new System.EventHandler(this.btn_Unpack_AddFiles_Click);
            // 
            // btn_Unpack_Unpack
            // 
            this.btn_Unpack_Unpack.Location = new System.Drawing.Point(468, 5);
            this.btn_Unpack_Unpack.Name = "btn_Unpack_Unpack";
            this.btn_Unpack_Unpack.Size = new System.Drawing.Size(75, 23);
            this.btn_Unpack_Unpack.TabIndex = 2;
            this.btn_Unpack_Unpack.Text = "Unpack";
            this.btn_Unpack_Unpack.UseVisualStyleBackColor = true;
            this.btn_Unpack_Unpack.Click += new System.EventHandler(this.btn_Unpack_Unpack_Click);
            // 
            // tb_Unpack_OutputPath
            // 
            this.tb_Unpack_OutputPath.Location = new System.Drawing.Point(81, 6);
            this.tb_Unpack_OutputPath.Name = "tb_Unpack_OutputPath";
            this.tb_Unpack_OutputPath.Size = new System.Drawing.Size(385, 22);
            this.tb_Unpack_OutputPath.TabIndex = 0;
            // 
            // tPage_Pack
            // 
            this.tPage_Pack.Controls.Add(this.btn_Pack_ClearFiles);
            this.tPage_Pack.Controls.Add(this.btn_Pack_RemoveFiles);
            this.tPage_Pack.Controls.Add(this.listBox_Pack_Files);
            this.tPage_Pack.Controls.Add(this.btn_Pack_OutputPath);
            this.tPage_Pack.Controls.Add(this.btn_Pack_Pack);
            this.tPage_Pack.Controls.Add(this.tb_Pack_OutputPath);
            this.tPage_Pack.Controls.Add(this.btn_Pack_AddFiles);
            this.tPage_Pack.Location = new System.Drawing.Point(4, 22);
            this.tPage_Pack.Name = "tPage_Pack";
            this.tPage_Pack.Padding = new System.Windows.Forms.Padding(3);
            this.tPage_Pack.Size = new System.Drawing.Size(543, 194);
            this.tPage_Pack.TabIndex = 1;
            this.tPage_Pack.Text = "Pack";
            this.tPage_Pack.UseVisualStyleBackColor = true;
            // 
            // btn_Pack_ClearFiles
            // 
            this.btn_Pack_ClearFiles.Location = new System.Drawing.Point(180, 34);
            this.btn_Pack_ClearFiles.Name = "btn_Pack_ClearFiles";
            this.btn_Pack_ClearFiles.Size = new System.Drawing.Size(75, 23);
            this.btn_Pack_ClearFiles.TabIndex = 6;
            this.btn_Pack_ClearFiles.Text = "Clear";
            this.btn_Pack_ClearFiles.UseVisualStyleBackColor = true;
            this.btn_Pack_ClearFiles.Click += new System.EventHandler(this.btn_Pack_ClearFiles_Click);
            // 
            // btn_Pack_RemoveFiles
            // 
            this.btn_Pack_RemoveFiles.Location = new System.Drawing.Point(87, 34);
            this.btn_Pack_RemoveFiles.Name = "btn_Pack_RemoveFiles";
            this.btn_Pack_RemoveFiles.Size = new System.Drawing.Size(87, 23);
            this.btn_Pack_RemoveFiles.TabIndex = 5;
            this.btn_Pack_RemoveFiles.Text = "Remove Files";
            this.btn_Pack_RemoveFiles.UseVisualStyleBackColor = true;
            this.btn_Pack_RemoveFiles.Click += new System.EventHandler(this.btn_Pack_RemoveFiles_Click);
            // 
            // listBox_Pack_Files
            // 
            this.listBox_Pack_Files.AllowDrop = true;
            this.listBox_Pack_Files.FormattingEnabled = true;
            this.listBox_Pack_Files.ItemHeight = 12;
            this.listBox_Pack_Files.Location = new System.Drawing.Point(4, 64);
            this.listBox_Pack_Files.Name = "listBox_Pack_Files";
            this.listBox_Pack_Files.Size = new System.Drawing.Size(531, 124);
            this.listBox_Pack_Files.TabIndex = 4;
            this.listBox_Pack_Files.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox_Pack_Files_DragDrop);
            this.listBox_Pack_Files.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox_Pack_Files_DragEnter);
            // 
            // btn_Pack_OutputPath
            // 
            this.btn_Pack_OutputPath.Location = new System.Drawing.Point(0, 4);
            this.btn_Pack_OutputPath.Name = "btn_Pack_OutputPath";
            this.btn_Pack_OutputPath.Size = new System.Drawing.Size(79, 23);
            this.btn_Pack_OutputPath.TabIndex = 3;
            this.btn_Pack_OutputPath.Text = "Output File";
            this.btn_Pack_OutputPath.UseVisualStyleBackColor = true;
            this.btn_Pack_OutputPath.Click += new System.EventHandler(this.btn_Pack_OutputPath_Click);
            // 
            // btn_Pack_Pack
            // 
            this.btn_Pack_Pack.Location = new System.Drawing.Point(468, 5);
            this.btn_Pack_Pack.Name = "btn_Pack_Pack";
            this.btn_Pack_Pack.Size = new System.Drawing.Size(75, 23);
            this.btn_Pack_Pack.TabIndex = 3;
            this.btn_Pack_Pack.Text = "Pack";
            this.btn_Pack_Pack.UseVisualStyleBackColor = true;
            this.btn_Pack_Pack.Click += new System.EventHandler(this.btn_Pack_Pack_Click);
            // 
            // tb_Pack_OutputPath
            // 
            this.tb_Pack_OutputPath.Location = new System.Drawing.Point(81, 6);
            this.tb_Pack_OutputPath.Name = "tb_Pack_OutputPath";
            this.tb_Pack_OutputPath.Size = new System.Drawing.Size(385, 22);
            this.tb_Pack_OutputPath.TabIndex = 1;
            // 
            // btn_Pack_AddFiles
            // 
            this.btn_Pack_AddFiles.Location = new System.Drawing.Point(6, 34);
            this.btn_Pack_AddFiles.Name = "btn_Pack_AddFiles";
            this.btn_Pack_AddFiles.Size = new System.Drawing.Size(75, 23);
            this.btn_Pack_AddFiles.TabIndex = 0;
            this.btn_Pack_AddFiles.Text = "Add Files";
            this.btn_Pack_AddFiles.UseVisualStyleBackColor = true;
            this.btn_Pack_AddFiles.Click += new System.EventHandler(this.btn_Pack_AddFiles_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 220);
            this.Controls.Add(this.tControl_Action);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "vArc Package Manager v0.2.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tControl_Action.ResumeLayout(false);
            this.tPage_Unpack.ResumeLayout(false);
            this.tPage_Unpack.PerformLayout();
            this.tPage_Pack.ResumeLayout(false);
            this.tPage_Pack.PerformLayout();
            this.ResumeLayout(false);

		}

        #endregion

        private System.Windows.Forms.TabControl tControl_Action;
        private System.Windows.Forms.TabPage tPage_Unpack;
        private System.Windows.Forms.TabPage tPage_Pack;
        private System.Windows.Forms.Button btn_Unpack_Unpack;
        private System.Windows.Forms.TextBox tb_Unpack_OutputPath;
        private System.Windows.Forms.ListBox listBox_Pack_Files;
        private System.Windows.Forms.Button btn_Pack_Pack;
        private System.Windows.Forms.TextBox tb_Pack_OutputPath;
        private System.Windows.Forms.Button btn_Pack_AddFiles;
        private System.Windows.Forms.ListBox listBox_Unpack_Files;
        private System.Windows.Forms.Button btn_Unpack_AddFiles;
        private System.Windows.Forms.Button btn_Unpack_RemoveFiles;
        private System.Windows.Forms.Button btn_Pack_RemoveFiles;
        private System.Windows.Forms.Button btn_Pack_OutputPath;
        private System.Windows.Forms.Button btn_Unpack_ClearFiles;
        private System.Windows.Forms.Button btn_Pack_ClearFiles;
        private System.Windows.Forms.Button btn_Unpack_OutputPath;
        private System.Windows.Forms.CheckBox cBox_Unpack_FolderSounds;
        private System.Windows.Forms.CheckBox cBox_Unpack_FolderOwn;
    }
}


namespace TSLogParser
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.treeView = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolLoadClip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLoadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.contextNodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTraceError = new System.Windows.Forms.ToolStripMenuItem();
            this.toolExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextNodeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Location = new System.Drawing.Point(12, 38);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(268, 219);
            this.treeView.TabIndex = 0;
            this.treeView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLoadClip,
            this.toolLoadFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolLoadClip
            // 
            this.toolLoadClip.Name = "toolLoadClip";
            this.toolLoadClip.Size = new System.Drawing.Size(63, 20);
            this.toolLoadClip.Text = "Load CB";
            this.toolLoadClip.Click += new System.EventHandler(this.toolLoadClip_Click);
            // 
            // toolLoadFile
            // 
            this.toolLoadFile.Name = "toolLoadFile";
            this.toolLoadFile.Size = new System.Drawing.Size(76, 20);
            this.toolLoadFile.Text = "Reload File";
            this.toolLoadFile.Click += new System.EventHandler(this.toolLoadFile_Click);
            // 
            // contextNodeMenu
            // 
            this.contextNodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTraceError,
            this.toolExpandAll});
            this.contextNodeMenu.Name = "contextNodeMenu";
            this.contextNodeMenu.Size = new System.Drawing.Size(132, 48);
            this.contextNodeMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextNodeMenu_Opening);
            // 
            // toolTraceError
            // 
            this.toolTraceError.Name = "toolTraceError";
            this.toolTraceError.Size = new System.Drawing.Size(131, 22);
            this.toolTraceError.Text = "Trace Error";
            this.toolTraceError.Visible = false;
            this.toolTraceError.Click += new System.EventHandler(this.toolTraceError_Click);
            // 
            // toolExpandAll
            // 
            this.toolExpandAll.Name = "toolExpandAll";
            this.toolExpandAll.Size = new System.Drawing.Size(131, 22);
            this.toolExpandAll.Text = "Expand All";
            this.toolExpandAll.Click += new System.EventHandler(this.toolExpandAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 269);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Test Studio Log Parser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextNodeMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolLoadClip;
        private System.Windows.Forms.ToolStripMenuItem toolLoadFile;
        private System.Windows.Forms.ContextMenuStrip contextNodeMenu;
        private System.Windows.Forms.ToolStripMenuItem toolExpandAll;
        private System.Windows.Forms.ToolStripMenuItem toolTraceError;
    }
}


namespace LenfLock {
    partial class Setting {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.數學設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.系統設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(290, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基本設定ToolStripMenuItem,
            this.系統設定ToolStripMenuItem,
            this.數學設定ToolStripMenuItem});
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.設定ToolStripMenuItem.Text = "設定";
            // 
            // 基本設定ToolStripMenuItem
            // 
            this.基本設定ToolStripMenuItem.Name = "基本設定ToolStripMenuItem";
            this.基本設定ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.基本設定ToolStripMenuItem.Text = "基本設定";
            this.基本設定ToolStripMenuItem.Click += new System.EventHandler(this.基本設定ToolStripMenuItem_Click);
            // 
            // 數學設定ToolStripMenuItem
            // 
            this.數學設定ToolStripMenuItem.Name = "數學設定ToolStripMenuItem";
            this.數學設定ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.數學設定ToolStripMenuItem.Text = "數學設定";
            this.數學設定ToolStripMenuItem.Click += new System.EventHandler(this.數學設定ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 240);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("PMingLiU", 13F);
            this.button1.Location = new System.Drawing.Point(155, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "離開";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // 系統設定ToolStripMenuItem
            // 
            this.系統設定ToolStripMenuItem.Name = "系統設定ToolStripMenuItem";
            this.系統設定ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.系統設定ToolStripMenuItem.Text = "系統設定";
            this.系統設定ToolStripMenuItem.Click += new System.EventHandler(this.系統設定ToolStripMenuItem_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 264);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Setting";
            this.Text = "Setting";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基本設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 數學設定ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 系統設定ToolStripMenuItem;
    }
}
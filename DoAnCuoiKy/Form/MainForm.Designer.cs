namespace DoAnCuoiKy
{
    partial class MainForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.panel_Sidebar = new System.Windows.Forms.Panel();
            this.btn_DangXuat = new System.Windows.Forms.Button();
            this.btn_DoanhThu = new System.Windows.Forms.Button();
            this.btn_QuanLyTaiKhoan = new System.Windows.Forms.Button();
            this.btn_TrangChu = new System.Windows.Forms.Button();
            this.btn_TraCuuVe = new System.Windows.Forms.Button();
            this.btn_BanVe = new System.Windows.Forms.Button();
            this.btn_QuanLyChuyen = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label_Name = new System.Windows.Forms.Label();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_Sidebar.SuspendLayout();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel_logo);
            this.splitContainer1.Panel1.Controls.Add(this.panel_Sidebar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelContainer);
            this.splitContainer1.Size = new System.Drawing.Size(1549, 742);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel_logo
            // 
            this.panel_logo.BackColor = System.Drawing.Color.IndianRed;
            this.panel_logo.Location = new System.Drawing.Point(3, 4);
            this.panel_logo.Name = "panel_logo";
            this.panel_logo.Size = new System.Drawing.Size(204, 81);
            this.panel_logo.TabIndex = 1;
            // 
            // panel_Sidebar
            // 
            this.panel_Sidebar.Controls.Add(this.btn_DangXuat);
            this.panel_Sidebar.Controls.Add(this.btn_DoanhThu);
            this.panel_Sidebar.Controls.Add(this.btn_QuanLyTaiKhoan);
            this.panel_Sidebar.Controls.Add(this.btn_TrangChu);
            this.panel_Sidebar.Controls.Add(this.btn_TraCuuVe);
            this.panel_Sidebar.Controls.Add(this.btn_BanVe);
            this.panel_Sidebar.Controls.Add(this.btn_QuanLyChuyen);
            this.panel_Sidebar.Location = new System.Drawing.Point(0, 91);
            this.panel_Sidebar.Name = "panel_Sidebar";
            this.panel_Sidebar.Size = new System.Drawing.Size(210, 649);
            this.panel_Sidebar.TabIndex = 0;
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.Font = new System.Drawing.Font("Montserrat", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangXuat.Location = new System.Drawing.Point(3, 522);
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.Size = new System.Drawing.Size(195, 57);
            this.btn_DangXuat.TabIndex = 33;
            this.btn_DangXuat.Text = "Đăng Xuất";
            this.btn_DangXuat.UseVisualStyleBackColor = true;
            this.btn_DangXuat.Click += new System.EventHandler(this.btn_DangXuat_Click);
            // 
            // btn_DoanhThu
            // 
            this.btn_DoanhThu.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoanhThu.Location = new System.Drawing.Point(3, 442);
            this.btn_DoanhThu.Name = "btn_DoanhThu";
            this.btn_DoanhThu.Size = new System.Drawing.Size(195, 74);
            this.btn_DoanhThu.TabIndex = 29;
            this.btn_DoanhThu.Text = "Doanh thu";
            this.btn_DoanhThu.UseVisualStyleBackColor = true;
            this.btn_DoanhThu.Click += new System.EventHandler(this.btn_DoanhThu_Click);
            // 
            // btn_QuanLyTaiKhoan
            // 
            this.btn_QuanLyTaiKhoan.Font = new System.Drawing.Font("Montserrat", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuanLyTaiKhoan.Location = new System.Drawing.Point(3, 340);
            this.btn_QuanLyTaiKhoan.Name = "btn_QuanLyTaiKhoan";
            this.btn_QuanLyTaiKhoan.Size = new System.Drawing.Size(195, 96);
            this.btn_QuanLyTaiKhoan.TabIndex = 32;
            this.btn_QuanLyTaiKhoan.Text = "Quản lý tài khoản";
            this.btn_QuanLyTaiKhoan.UseVisualStyleBackColor = true;
            this.btn_QuanLyTaiKhoan.Click += new System.EventHandler(this.btn_QuanLyTaiKhoan_Click);
            // 
            // btn_TrangChu
            // 
            this.btn_TrangChu.Font = new System.Drawing.Font("Montserrat", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TrangChu.Location = new System.Drawing.Point(3, 3);
            this.btn_TrangChu.Name = "btn_TrangChu";
            this.btn_TrangChu.Size = new System.Drawing.Size(195, 65);
            this.btn_TrangChu.TabIndex = 26;
            this.btn_TrangChu.Text = "Trang chủ";
            this.btn_TrangChu.UseVisualStyleBackColor = true;
            this.btn_TrangChu.Click += new System.EventHandler(this.btn_TrangChu_Click);
            // 
            // btn_TraCuuVe
            // 
            this.btn_TraCuuVe.Font = new System.Drawing.Font("Montserrat", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TraCuuVe.Location = new System.Drawing.Point(3, 157);
            this.btn_TraCuuVe.Name = "btn_TraCuuVe";
            this.btn_TraCuuVe.Size = new System.Drawing.Size(195, 65);
            this.btn_TraCuuVe.TabIndex = 31;
            this.btn_TraCuuVe.Text = "Tra cứu vé";
            this.btn_TraCuuVe.UseVisualStyleBackColor = true;
            this.btn_TraCuuVe.Click += new System.EventHandler(this.btn_TraCuuVe_Click);
            // 
            // btn_BanVe
            // 
            this.btn_BanVe.Font = new System.Drawing.Font("Montserrat", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BanVe.Location = new System.Drawing.Point(3, 74);
            this.btn_BanVe.Name = "btn_BanVe";
            this.btn_BanVe.Size = new System.Drawing.Size(195, 65);
            this.btn_BanVe.TabIndex = 27;
            this.btn_BanVe.Text = "Bán vé";
            this.btn_BanVe.UseVisualStyleBackColor = true;
            this.btn_BanVe.Click += new System.EventHandler(this.btn_BanVe_Click);
            // 
            // btn_QuanLyChuyen
            // 
            this.btn_QuanLyChuyen.Font = new System.Drawing.Font("Montserrat", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuanLyChuyen.Location = new System.Drawing.Point(3, 228);
            this.btn_QuanLyChuyen.Name = "btn_QuanLyChuyen";
            this.btn_QuanLyChuyen.Size = new System.Drawing.Size(195, 96);
            this.btn_QuanLyChuyen.TabIndex = 28;
            this.btn_QuanLyChuyen.Text = "Quản lý chuyến";
            this.btn_QuanLyChuyen.UseVisualStyleBackColor = true;
            this.btn_QuanLyChuyen.Click += new System.EventHandler(this.btn_QuanLyChuyen_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.dataGridView1);
            this.panelContainer.Controls.Add(this.button1);
            this.panelContainer.Controls.Add(this.label_Name);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1335, 742);
            this.panelContainer.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(209, 335);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(757, 150);
            this.dataGridView1.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Montserrat", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(437, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 65);
            this.button1.TabIndex = 27;
            this.button1.Text = "TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("Montserrat", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Name.Location = new System.Drawing.Point(24, 39);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(192, 46);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "Xin chào: ";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1549, 742);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1549, 770);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1549, 28);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit_ToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // Exit_ToolStripMenuItem
            // 
            this.Exit_ToolStripMenuItem.Name = "Exit_ToolStripMenuItem";
            this.Exit_ToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.Exit_ToolStripMenuItem.Text = "Thoát";
            this.Exit_ToolStripMenuItem.Click += new System.EventHandler(this.Exit_ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1549, 770);
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bán vé";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel_Sidebar.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel_Sidebar;
        public System.Windows.Forms.Button btn_DangXuat;
        public System.Windows.Forms.Button btn_DoanhThu;
        public System.Windows.Forms.Button btn_QuanLyTaiKhoan;
        private System.Windows.Forms.Button btn_TrangChu;
        private System.Windows.Forms.Button btn_TraCuuVe;
        private System.Windows.Forms.Button btn_BanVe;
        public System.Windows.Forms.Button btn_QuanLyChuyen;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit_ToolStripMenuItem;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel_logo = new System.Windows.Forms.Panel();
            this.btnReLoad = new System.Windows.Forms.Button();
            this.panel_Sidebar = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_BanVe = new System.Windows.Forms.Button();
            this.btn_DoanhThu = new System.Windows.Forms.Button();
            this.btn_QuanLyTaiKhoan = new System.Windows.Forms.Button();
            this.btn_TraCuuVe = new System.Windows.Forms.Button();
            this.btn_QuanLyChuyen = new System.Windows.Forms.Button();
            this.btn_DangXuat = new System.Windows.Forms.Button();
            this.btn_TrangChu = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dgr_test = new System.Windows.Forms.DataGridView();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_logo.SuspendLayout();
            this.panel_Sidebar.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_test)).BeginInit();
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
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
            this.splitContainer1.Size = new System.Drawing.Size(1924, 923);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel_logo
            // 
            this.panel_logo.BackColor = System.Drawing.Color.Tomato;
            this.panel_logo.Controls.Add(this.btnReLoad);
            this.panel_logo.Location = new System.Drawing.Point(4, 5);
            this.panel_logo.Margin = new System.Windows.Forms.Padding(4);
            this.panel_logo.Name = "panel_logo";
            this.panel_logo.Size = new System.Drawing.Size(303, 100);
            this.panel_logo.TabIndex = 1;
            // 
            // btnReLoad
            // 
            this.btnReLoad.BackColor = System.Drawing.Color.Tomato;
            this.btnReLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReLoad.ForeColor = System.Drawing.Color.Tomato;
            this.btnReLoad.Image = global::DoAnCuoiKy.Properties.Resources.refresh_8138970__1_;
            this.btnReLoad.Location = new System.Drawing.Point(76, 21);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(104, 71);
            this.btnReLoad.TabIndex = 0;
            this.btnReLoad.UseVisualStyleBackColor = false;
            this.btnReLoad.Visible = false;
            // 
            // panel_Sidebar
            // 
            this.panel_Sidebar.Controls.Add(this.tableLayoutPanel1);
            this.panel_Sidebar.Location = new System.Drawing.Point(4, 117);
            this.panel_Sidebar.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Sidebar.Name = "panel_Sidebar";
            this.panel_Sidebar.Size = new System.Drawing.Size(313, 802);
            this.panel_Sidebar.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btn_BanVe, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_DoanhThu, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btn_QuanLyTaiKhoan, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn_TraCuuVe, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_QuanLyChuyen, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_DangXuat, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btn_TrangChu, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(311, 753);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // btn_BanVe
            // 
            this.btn_BanVe.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btn_BanVe.FlatAppearance.BorderSize = 3;
            this.btn_BanVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BanVe.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BanVe.Image = global::DoAnCuoiKy.Properties.Resources.ticket;
            this.btn_BanVe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BanVe.Location = new System.Drawing.Point(4, 78);
            this.btn_BanVe.Margin = new System.Windows.Forms.Padding(4);
            this.btn_BanVe.Name = "btn_BanVe";
            this.btn_BanVe.Size = new System.Drawing.Size(298, 66);
            this.btn_BanVe.TabIndex = 27;
            this.btn_BanVe.Text = "Bán vé";
            this.btn_BanVe.UseVisualStyleBackColor = true;
            this.btn_BanVe.Click += new System.EventHandler(this.btn_BanVe_Click);
            // 
            // btn_DoanhThu
            // 
            this.btn_DoanhThu.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btn_DoanhThu.FlatAppearance.BorderSize = 3;
            this.btn_DoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoanhThu.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoanhThu.Image = ((System.Drawing.Image)(resources.GetObject("btn_DoanhThu.Image")));
            this.btn_DoanhThu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DoanhThu.Location = new System.Drawing.Point(4, 406);
            this.btn_DoanhThu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_DoanhThu.Name = "btn_DoanhThu";
            this.btn_DoanhThu.Size = new System.Drawing.Size(298, 66);
            this.btn_DoanhThu.TabIndex = 29;
            this.btn_DoanhThu.Text = "Doanh thu";
            this.btn_DoanhThu.UseVisualStyleBackColor = true;
            this.btn_DoanhThu.Click += new System.EventHandler(this.btn_DoanhThu_Click);
            // 
            // btn_QuanLyTaiKhoan
            // 
            this.btn_QuanLyTaiKhoan.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btn_QuanLyTaiKhoan.FlatAppearance.BorderSize = 3;
            this.btn_QuanLyTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QuanLyTaiKhoan.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuanLyTaiKhoan.Image = global::DoAnCuoiKy.Properties.Resources.user;
            this.btn_QuanLyTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_QuanLyTaiKhoan.Location = new System.Drawing.Point(4, 316);
            this.btn_QuanLyTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.btn_QuanLyTaiKhoan.Name = "btn_QuanLyTaiKhoan";
            this.btn_QuanLyTaiKhoan.Size = new System.Drawing.Size(298, 82);
            this.btn_QuanLyTaiKhoan.TabIndex = 32;
            this.btn_QuanLyTaiKhoan.Text = "Quản lý tài khoản";
            this.btn_QuanLyTaiKhoan.UseVisualStyleBackColor = true;
            this.btn_QuanLyTaiKhoan.Click += new System.EventHandler(this.btn_QuanLyTaiKhoan_Click);
            // 
            // btn_TraCuuVe
            // 
            this.btn_TraCuuVe.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btn_TraCuuVe.FlatAppearance.BorderSize = 3;
            this.btn_TraCuuVe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TraCuuVe.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TraCuuVe.Image = global::DoAnCuoiKy.Properties.Resources.loupe;
            this.btn_TraCuuVe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TraCuuVe.Location = new System.Drawing.Point(4, 152);
            this.btn_TraCuuVe.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TraCuuVe.Name = "btn_TraCuuVe";
            this.btn_TraCuuVe.Size = new System.Drawing.Size(298, 66);
            this.btn_TraCuuVe.TabIndex = 31;
            this.btn_TraCuuVe.Text = "Tra cứu vé";
            this.btn_TraCuuVe.UseVisualStyleBackColor = true;
            this.btn_TraCuuVe.Click += new System.EventHandler(this.btn_TraCuuVe_Click);
            // 
            // btn_QuanLyChuyen
            // 
            this.btn_QuanLyChuyen.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btn_QuanLyChuyen.FlatAppearance.BorderSize = 3;
            this.btn_QuanLyChuyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_QuanLyChuyen.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuanLyChuyen.Image = global::DoAnCuoiKy.Properties.Resources.mission;
            this.btn_QuanLyChuyen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_QuanLyChuyen.Location = new System.Drawing.Point(4, 226);
            this.btn_QuanLyChuyen.Margin = new System.Windows.Forms.Padding(4);
            this.btn_QuanLyChuyen.Name = "btn_QuanLyChuyen";
            this.btn_QuanLyChuyen.Size = new System.Drawing.Size(298, 81);
            this.btn_QuanLyChuyen.TabIndex = 28;
            this.btn_QuanLyChuyen.Text = "Quản lý chuyến";
            this.btn_QuanLyChuyen.UseVisualStyleBackColor = true;
            this.btn_QuanLyChuyen.Click += new System.EventHandler(this.btn_QuanLyChuyen_Click);
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btn_DangXuat.FlatAppearance.BorderSize = 3;
            this.btn_DangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DangXuat.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangXuat.Image = global::DoAnCuoiKy.Properties.Resources.log_out;
            this.btn_DangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DangXuat.Location = new System.Drawing.Point(4, 480);
            this.btn_DangXuat.Margin = new System.Windows.Forms.Padding(4);
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.Size = new System.Drawing.Size(298, 65);
            this.btn_DangXuat.TabIndex = 33;
            this.btn_DangXuat.Text = "Đăng Xuất";
            this.btn_DangXuat.UseVisualStyleBackColor = true;
            this.btn_DangXuat.Click += new System.EventHandler(this.btn_DangXuat_Click);
            // 
            // btn_TrangChu
            // 
            this.btn_TrangChu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_TrangChu.BackColor = System.Drawing.Color.Transparent;
            this.btn_TrangChu.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btn_TrangChu.FlatAppearance.BorderSize = 3;
            this.btn_TrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TrangChu.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TrangChu.Image = ((System.Drawing.Image)(resources.GetObject("btn_TrangChu.Image")));
            this.btn_TrangChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TrangChu.Location = new System.Drawing.Point(4, 4);
            this.btn_TrangChu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TrangChu.Name = "btn_TrangChu";
            this.btn_TrangChu.Size = new System.Drawing.Size(298, 66);
            this.btn_TrangChu.TabIndex = 26;
            this.btn_TrangChu.Text = "Trang chủ";
            this.btn_TrangChu.UseVisualStyleBackColor = false;
            this.btn_TrangChu.Click += new System.EventHandler(this.btn_TrangChu_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelContainer.Controls.Add(this.button1);
            this.panelContainer.Controls.Add(this.dgr_test);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1599, 923);
            this.panelContainer.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Montserrat", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(591, 180);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 80);
            this.button1.TabIndex = 27;
            this.button1.Text = "TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dgr_test
            // 
            this.dgr_test.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr_test.Location = new System.Drawing.Point(261, 414);
            this.dgr_test.Margin = new System.Windows.Forms.Padding(4);
            this.dgr_test.Name = "dgr_test";
            this.dgr_test.RowHeadersWidth = 51;
            this.dgr_test.RowTemplate.Height = 24;
            this.dgr_test.Size = new System.Drawing.Size(946, 185);
            this.dgr_test.TabIndex = 28;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1924, 923);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1924, 951);
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
            this.menuStrip1.Size = new System.Drawing.Size(1924, 28);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 951);
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bán vé";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel_logo.ResumeLayout(false);
            this.panel_Sidebar.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgr_test)).EndInit();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit_ToolStripMenuItem;
        private System.Windows.Forms.Panel panel_logo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgr_test;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnReLoad;
    }
}


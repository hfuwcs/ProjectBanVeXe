namespace DoAnCuoiKy
{
    partial class DoiMatKhau
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
            this.btn_ThoatDangNhap = new System.Windows.Forms.Button();
            this.btn_DoiMatKhau = new System.Windows.Forms.Button();
            this.txt_TypePass = new System.Windows.Forms.TextBox();
            this.lbl_MKMoi = new System.Windows.Forms.Label();
            this.txt_RetypePass = new System.Windows.Forms.TextBox();
            this.lbl_MKMoi_Again = new System.Windows.Forms.Label();
            this.label_Account = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ThoatDangNhap
            // 
            this.btn_ThoatDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThoatDangNhap.Location = new System.Drawing.Point(304, 265);
            this.btn_ThoatDangNhap.Name = "btn_ThoatDangNhap";
            this.btn_ThoatDangNhap.Size = new System.Drawing.Size(213, 48);
            this.btn_ThoatDangNhap.TabIndex = 12;
            this.btn_ThoatDangNhap.Text = "Thoát";
            this.btn_ThoatDangNhap.UseVisualStyleBackColor = true;
            this.btn_ThoatDangNhap.Click += new System.EventHandler(this.btn_ThoatDangNhap_Click);
            // 
            // btn_DoiMatKhau
            // 
            this.btn_DoiMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoiMatKhau.Location = new System.Drawing.Point(85, 265);
            this.btn_DoiMatKhau.Name = "btn_DoiMatKhau";
            this.btn_DoiMatKhau.Size = new System.Drawing.Size(213, 48);
            this.btn_DoiMatKhau.TabIndex = 11;
            this.btn_DoiMatKhau.Text = "Đổi mật khẩu";
            this.btn_DoiMatKhau.UseVisualStyleBackColor = true;
            // 
            // txt_TypePass
            // 
            this.txt_TypePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TypePass.Location = new System.Drawing.Point(220, 104);
            this.txt_TypePass.Name = "txt_TypePass";
            this.txt_TypePass.Size = new System.Drawing.Size(310, 30);
            this.txt_TypePass.TabIndex = 8;
            // 
            // lbl_MKMoi
            // 
            this.lbl_MKMoi.AutoSize = true;
            this.lbl_MKMoi.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MKMoi.Location = new System.Drawing.Point(26, 108);
            this.lbl_MKMoi.Name = "lbl_MKMoi";
            this.lbl_MKMoi.Size = new System.Drawing.Size(146, 25);
            this.lbl_MKMoi.TabIndex = 7;
            this.lbl_MKMoi.Text = "Mật khẩu mới:";
            // 
            // txt_RetypePass
            // 
            this.txt_RetypePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RetypePass.Location = new System.Drawing.Point(220, 158);
            this.txt_RetypePass.Name = "txt_RetypePass";
            this.txt_RetypePass.Size = new System.Drawing.Size(310, 30);
            this.txt_RetypePass.TabIndex = 15;
            // 
            // lbl_MKMoi_Again
            // 
            this.lbl_MKMoi_Again.AutoSize = true;
            this.lbl_MKMoi_Again.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MKMoi_Again.Location = new System.Drawing.Point(26, 162);
            this.lbl_MKMoi_Again.Name = "lbl_MKMoi_Again";
            this.lbl_MKMoi_Again.Size = new System.Drawing.Size(188, 25);
            this.lbl_MKMoi_Again.TabIndex = 14;
            this.lbl_MKMoi_Again.Text = "Nhập lại mật khẩu:";
            // 
            // label_Account
            // 
            this.label_Account.AutoSize = true;
            this.label_Account.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Account.Location = new System.Drawing.Point(26, 31);
            this.label_Account.Name = "label_Account";
            this.label_Account.Size = new System.Drawing.Size(287, 25);
            this.label_Account.TabIndex = 16;
            this.label_Account.Text = "Tài khoản đang đăng nhập là:";
            // 
            // DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 347);
            this.Controls.Add(this.label_Account);
            this.Controls.Add(this.txt_RetypePass);
            this.Controls.Add(this.lbl_MKMoi_Again);
            this.Controls.Add(this.btn_ThoatDangNhap);
            this.Controls.Add(this.btn_DoiMatKhau);
            this.Controls.Add(this.txt_TypePass);
            this.Controls.Add(this.lbl_MKMoi);
            this.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DoiMatKhau";
            this.Text = "DoiMatKhau";
            this.Load += new System.EventHandler(this.DoiMatKhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_ThoatDangNhap;
        private System.Windows.Forms.Button btn_DoiMatKhau;
        private System.Windows.Forms.TextBox txt_TypePass;
        private System.Windows.Forms.Label lbl_MKMoi;
        private System.Windows.Forms.TextBox txt_RetypePass;
        private System.Windows.Forms.Label lbl_MKMoi_Again;
        private System.Windows.Forms.Label label_Account;
    }
}
namespace DoAnCuoiKy
{
    partial class DangNhap
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
            this.lbl_Email = new System.Windows.Forms.Label();
            this.txtBox_Email = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.txtBox_Pass = new System.Windows.Forms.TextBox();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.btn_ThoatDangNhap = new System.Windows.Forms.Button();
            this.linkLabel_DoiMatKhau = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.Location = new System.Drawing.Point(49, 105);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(72, 25);
            this.lbl_Email.TabIndex = 0;
            this.lbl_Email.Text = "Email:";
            // 
            // txtBox_Email
            // 
            this.txtBox_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Email.Location = new System.Drawing.Point(205, 103);
            this.txtBox_Email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBox_Email.Name = "txtBox_Email";
            this.txtBox_Email.Size = new System.Drawing.Size(279, 30);
            this.txtBox_Email.TabIndex = 1;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.Location = new System.Drawing.Point(49, 151);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(113, 25);
            this.lbl_Password.TabIndex = 2;
            this.lbl_Password.Text = "Password:";
            // 
            // txtBox_Pass
            // 
            this.txtBox_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_Pass.Location = new System.Drawing.Point(205, 151);
            this.txtBox_Pass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBox_Pass.Name = "txtBox_Pass";
            this.txtBox_Pass.Size = new System.Drawing.Size(279, 30);
            this.txtBox_Pass.TabIndex = 3;
            this.txtBox_Pass.Enter += new System.EventHandler(this.txtBox_Pass_Enter);
            this.txtBox_Pass.Leave += new System.EventHandler(this.txtBox_Pass_Leave);
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangNhap.Location = new System.Drawing.Point(84, 244);
            this.btn_DangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(213, 43);
            this.btn_DangNhap.TabIndex = 4;
            this.btn_DangNhap.Text = "Đăng nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = true;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // btn_ThoatDangNhap
            // 
            this.btn_ThoatDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThoatDangNhap.Location = new System.Drawing.Point(303, 244);
            this.btn_ThoatDangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ThoatDangNhap.Name = "btn_ThoatDangNhap";
            this.btn_ThoatDangNhap.Size = new System.Drawing.Size(213, 43);
            this.btn_ThoatDangNhap.TabIndex = 5;
            this.btn_ThoatDangNhap.Text = "Thoát";
            this.btn_ThoatDangNhap.UseVisualStyleBackColor = true;
            this.btn_ThoatDangNhap.Click += new System.EventHandler(this.btn_ThoatDangNhap_Click);
            // 
            // linkLabel_DoiMatKhau
            // 
            this.linkLabel_DoiMatKhau.AutoSize = true;
            this.linkLabel_DoiMatKhau.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_DoiMatKhau.Location = new System.Drawing.Point(359, 194);
            this.linkLabel_DoiMatKhau.Name = "linkLabel_DoiMatKhau";
            this.linkLabel_DoiMatKhau.Size = new System.Drawing.Size(126, 23);
            this.linkLabel_DoiMatKhau.TabIndex = 6;
            this.linkLabel_DoiMatKhau.TabStop = true;
            this.linkLabel_DoiMatKhau.Text = "Đổi mật khẩu";
            this.linkLabel_DoiMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_DoiMatKhau_LinkClicked);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(561, 356);
            this.Controls.Add(this.linkLabel_DoiMatKhau);
            this.Controls.Add(this.btn_ThoatDangNhap);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.txtBox_Pass);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.txtBox_Email);
            this.Controls.Add(this.lbl_Email);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DangNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox txtBox_Email;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox txtBox_Pass;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.Button btn_ThoatDangNhap;
        private System.Windows.Forms.LinkLabel linkLabel_DoiMatKhau;
    }
}
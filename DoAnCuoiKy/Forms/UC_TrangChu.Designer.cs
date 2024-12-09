namespace DoAnCuoiKy.Forms
{
    partial class UC_TrangChu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Name = new System.Windows.Forms.Label();
            this.lb_rolename = new System.Windows.Forms.Label();
            this.uc_lblname = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tomato;
            this.panel1.Controls.Add(this.label_Name);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1596, 100);
            this.panel1.TabIndex = 31;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.BackColor = System.Drawing.Color.Tomato;
            this.label_Name.Font = new System.Drawing.Font("Montserrat", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Name.Location = new System.Drawing.Point(570, 26);
            this.label_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(333, 46);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "Quản lý bán vé xe";
            // 
            // lb_rolename
            // 
            this.lb_rolename.AutoSize = true;
            this.lb_rolename.Font = new System.Drawing.Font("Montserrat", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rolename.Location = new System.Drawing.Point(19, 225);
            this.lb_rolename.Name = "lb_rolename";
            this.lb_rolename.Size = new System.Drawing.Size(352, 46);
            this.lb_rolename.TabIndex = 33;
            this.lb_rolename.Text = "Cấp bật tài khoản: ";
            // 
            // uc_lblname
            // 
            this.uc_lblname.AutoSize = true;
            this.uc_lblname.Font = new System.Drawing.Font("Montserrat", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uc_lblname.Location = new System.Drawing.Point(19, 135);
            this.uc_lblname.Name = "uc_lblname";
            this.uc_lblname.Size = new System.Drawing.Size(192, 46);
            this.uc_lblname.TabIndex = 32;
            this.uc_lblname.Text = "Xin chào: ";
            // 
            // UC_TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_rolename);
            this.Controls.Add(this.uc_lblname);
            this.Controls.Add(this.panel1);
            this.Name = "UC_TrangChu";
            this.Size = new System.Drawing.Size(1429, 822);
            this.Load += new System.EventHandler(this.UC_TrangChu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label lb_rolename;
        private System.Windows.Forms.Label uc_lblname;
    }
}

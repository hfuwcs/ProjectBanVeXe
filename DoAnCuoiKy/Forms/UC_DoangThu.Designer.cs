﻿namespace DoAnCuoiKy
{
    partial class UC_DoangThu
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
            this.btnTinh = new System.Windows.Forms.Button();
            this.dateTimePicker_Endday = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblTuyen = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.comboBox_End = new System.Windows.Forms.ComboBox();
            this.comboBox_Start = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDoanhThu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTinh
            // 
            this.btnTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnTinh.Location = new System.Drawing.Point(418, 551);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(112, 83);
            this.btnTinh.TabIndex = 20;
            this.btnTinh.Text = "Tính";
            this.btnTinh.UseVisualStyleBackColor = true;
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // dateTimePicker_Endday
            // 
            this.dateTimePicker_Endday.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePicker_Endday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_Endday.Location = new System.Drawing.Point(646, 259);
            this.dateTimePicker_Endday.Name = "dateTimePicker_Endday";
            this.dateTimePicker_Endday.Size = new System.Drawing.Size(259, 27);
            this.dateTimePicker_Endday.TabIndex = 19;
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePicker_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(237, 259);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(273, 27);
            this.dateTimePicker_StartDate.TabIndex = 18;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.Location = new System.Drawing.Point(525, 259);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(93, 20);
            this.lblDenNgay.TabIndex = 17;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Enabled = false;
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTongDoanhThu.Location = new System.Drawing.Point(317, 439);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.Size = new System.Drawing.Size(418, 26);
            this.txtTongDoanhThu.TabIndex = 15;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(98, 433);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(202, 29);
            this.lblTongDoanhThu.TabIndex = 14;
            this.lblTongDoanhThu.Text = "Tổng doanh thu:";
            // 
            // lblTuyen
            // 
            this.lblTuyen.AutoSize = true;
            this.lblTuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuyen.Location = new System.Drawing.Point(98, 346);
            this.lblTuyen.Name = "lblTuyen";
            this.lblTuyen.Size = new System.Drawing.Size(92, 29);
            this.lblTuyen.TabIndex = 13;
            this.lblTuyen.Text = "Tuyến:";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgay.Location = new System.Drawing.Point(98, 259);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(113, 29);
            this.lblTuNgay.TabIndex = 12;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.AutoSize = true;
            this.lblDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThu.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblDoanhThu.Location = new System.Drawing.Point(91, 187);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(187, 38);
            this.lblDoanhThu.TabIndex = 11;
            this.lblDoanhThu.Text = "Doanh Thu";
            // 
            // comboBox_End
            // 
            this.comboBox_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_End.FormattingEnabled = true;
            this.comboBox_End.Location = new System.Drawing.Point(545, 339);
            this.comboBox_End.Name = "comboBox_End";
            this.comboBox_End.Size = new System.Drawing.Size(127, 33);
            this.comboBox_End.TabIndex = 76;
            // 
            // comboBox_Start
            // 
            this.comboBox_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Start.FormattingEnabled = true;
            this.comboBox_Start.Location = new System.Drawing.Point(333, 339);
            this.comboBox_Start.Name = "comboBox_Start";
            this.comboBox_Start.Size = new System.Drawing.Size(121, 33);
            this.comboBox_Start.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(482, 343);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 32);
            this.label2.TabIndex = 77;
            this.label2.Text = "=>";
            // 
            // btnDoanhThu
            // 
            this.btnDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDoanhThu.Location = new System.Drawing.Point(577, 551);
            this.btnDoanhThu.Name = "btnDoanhThu";
            this.btnDoanhThu.Size = new System.Drawing.Size(112, 83);
            this.btnDoanhThu.TabIndex = 78;
            this.btnDoanhThu.Text = "In doanh thu";
            this.btnDoanhThu.UseVisualStyleBackColor = true;
            this.btnDoanhThu.Click += new System.EventHandler(this.btnDoanhThu_Click);
            // 
            // UC_DoangThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.Controls.Add(this.btnDoanhThu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_End);
            this.Controls.Add(this.comboBox_Start);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.dateTimePicker_Endday);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.txtTongDoanhThu);
            this.Controls.Add(this.lblTongDoanhThu);
            this.Controls.Add(this.lblTuyen);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.lblDoanhThu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_DoangThu";
            this.Size = new System.Drawing.Size(908, 772);
            this.Load += new System.EventHandler(this.UC_DoangThu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Endday;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label lblTuyen;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.ComboBox comboBox_End;
        private System.Windows.Forms.ComboBox comboBox_Start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDoanhThu;
    }
}

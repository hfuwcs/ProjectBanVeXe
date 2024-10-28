namespace DoAnCuoiKy
{
    partial class QLC_Them
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
            this.lblTuyen = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtp_Endday = new System.Windows.Forms.DateTimePicker();
            this.dtp_StartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbc_hEnd = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbc_hStart = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgr_ReadyBus = new System.Windows.Forms.DataGridView();
            this.btn_Them = new System.Windows.Forms.Button();
            this.cbc_start = new System.Windows.Forms.ComboBox();
            this.cbc_end = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_ReadyBus)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTuyen
            // 
            this.lblTuyen.AutoSize = true;
            this.lblTuyen.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblTuyen.Font = new System.Drawing.Font("Montserrat", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuyen.Location = new System.Drawing.Point(74, 36);
            this.lblTuyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTuyen.Name = "lblTuyen";
            this.lblTuyen.Size = new System.Drawing.Size(89, 32);
            this.lblTuyen.TabIndex = 80;
            this.lblTuyen.Text = "Tuyến";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbc_end);
            this.panel1.Controls.Add(this.cbc_start);
            this.panel1.Controls.Add(this.lblTuyen);
            this.panel1.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 100);
            this.panel1.TabIndex = 80;
            // 
            // dtp_Endday
            // 
            this.dtp_Endday.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtp_Endday.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Endday.Location = new System.Drawing.Point(163, 105);
            this.dtp_Endday.Name = "dtp_Endday";
            this.dtp_Endday.Size = new System.Drawing.Size(273, 28);
            this.dtp_Endday.TabIndex = 84;
            // 
            // dtp_StartDate
            // 
            this.dtp_StartDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtp_StartDate.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_StartDate.Location = new System.Drawing.Point(163, 29);
            this.dtp_StartDate.Name = "dtp_StartDate";
            this.dtp_StartDate.Size = new System.Drawing.Size(273, 28);
            this.dtp_StartDate.TabIndex = 83;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.Location = new System.Drawing.Point(21, 79);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(100, 23);
            this.lblDenNgay.TabIndex = 82;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbc_hEnd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbc_hStart);
            this.panel2.Controls.Add(this.dtp_Endday);
            this.panel2.Controls.Add(this.lblDenNgay);
            this.panel2.Controls.Add(this.dtp_StartDate);
            this.panel2.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 176);
            this.panel2.TabIndex = 85;
            // 
            // cbc_hEnd
            // 
            this.cbc_hEnd.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbc_hEnd.Location = new System.Drawing.Point(608, 102);
            this.cbc_hEnd.Name = "cbc_hEnd";
            this.cbc_hEnd.Size = new System.Drawing.Size(165, 31);
            this.cbc_hEnd.TabIndex = 89;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(445, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 23);
            this.label3.TabIndex = 88;
            this.label3.Text = "Giờ khởi hành";
            // 
            // cbc_hStart
            // 
            this.cbc_hStart.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbc_hStart.Location = new System.Drawing.Point(608, 16);
            this.cbc_hStart.Name = "cbc_hStart";
            this.cbc_hStart.Size = new System.Drawing.Size(165, 31);
            this.cbc_hStart.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 28);
            this.label1.TabIndex = 86;
            this.label1.Text = "Thời gian khởi hành";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgr_ReadyBus);
            this.panel3.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(1, 336);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(785, 159);
            this.panel3.TabIndex = 87;
            // 
            // dgr_ReadyBus
            // 
            this.dgr_ReadyBus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr_ReadyBus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgr_ReadyBus.Location = new System.Drawing.Point(0, 0);
            this.dgr_ReadyBus.Name = "dgr_ReadyBus";
            this.dgr_ReadyBus.RowHeadersWidth = 51;
            this.dgr_ReadyBus.RowTemplate.Height = 24;
            this.dgr_ReadyBus.Size = new System.Drawing.Size(783, 157);
            this.dgr_ReadyBus.TabIndex = 0;
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Montserrat SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Location = new System.Drawing.Point(285, 675);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(132, 73);
            this.btn_Them.TabIndex = 88;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // cbc_start
            // 
            this.cbc_start.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbc_start.FormattingEnabled = true;
            this.cbc_start.Location = new System.Drawing.Point(241, 36);
            this.cbc_start.Name = "cbc_start";
            this.cbc_start.Size = new System.Drawing.Size(175, 31);
            this.cbc_start.TabIndex = 82;
            // 
            // cbc_end
            // 
            this.cbc_end.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbc_end.FormattingEnabled = true;
            this.cbc_end.Location = new System.Drawing.Point(502, 36);
            this.cbc_end.Name = "cbc_end";
            this.cbc_end.Size = new System.Drawing.Size(175, 31);
            this.cbc_end.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(445, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 23);
            this.label2.TabIndex = 90;
            this.label2.Text = "=>";
            // 
            // QLC_Them
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 773);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "QLC_Them";
            this.Text = "Them";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgr_ReadyBus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTuyen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtp_Endday;
        private System.Windows.Forms.DateTimePicker dtp_StartDate;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgr_ReadyBus;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.ComboBox cbc_hStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbc_hEnd;
        private System.Windows.Forms.ComboBox cbc_start;
        private System.Windows.Forms.ComboBox cbc_end;
        private System.Windows.Forms.Label label2;
    }
}
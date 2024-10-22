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
            this.comboBox_End = new System.Windows.Forms.ComboBox();
            this.comboBox_Start = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_Endday = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtp_Hours_End = new System.Windows.Forms.DateTimePicker();
            this.dtp_Hours_Start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgr_ReadyBus = new System.Windows.Forms.DataGridView();
            this.btn_Them = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
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
            this.panel1.Controls.Add(this.comboBox_End);
            this.panel1.Controls.Add(this.lblTuyen);
            this.panel1.Controls.Add(this.comboBox_Start);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 100);
            this.panel1.TabIndex = 80;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBox_End
            // 
            this.comboBox_End.Font = new System.Drawing.Font("Montserrat Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_End.FormattingEnabled = true;
            this.comboBox_End.Location = new System.Drawing.Point(460, 36);
            this.comboBox_End.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_End.Name = "comboBox_End";
            this.comboBox_End.Size = new System.Drawing.Size(168, 36);
            this.comboBox_End.TabIndex = 83;
            // 
            // comboBox_Start
            // 
            this.comboBox_Start.Font = new System.Drawing.Font("Montserrat Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Start.FormattingEnabled = true;
            this.comboBox_Start.Location = new System.Drawing.Point(219, 36);
            this.comboBox_Start.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Start.Name = "comboBox_Start";
            this.comboBox_Start.Size = new System.Drawing.Size(160, 36);
            this.comboBox_Start.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(388, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 32);
            this.label2.TabIndex = 81;
            this.label2.Text = "=>";
            // 
            // dateTimePicker_Endday
            // 
            this.dateTimePicker_Endday.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePicker_Endday.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_Endday.Location = new System.Drawing.Point(375, 115);
            this.dateTimePicker_Endday.Name = "dateTimePicker_Endday";
            this.dateTimePicker_Endday.Size = new System.Drawing.Size(273, 28);
            this.dateTimePicker_Endday.TabIndex = 84;
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePicker_StartDate.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(375, 29);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(273, 28);
            this.dateTimePicker_StartDate.TabIndex = 83;
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
            this.panel2.Controls.Add(this.dtp_Hours_End);
            this.panel2.Controls.Add(this.dtp_Hours_Start);
            this.panel2.Controls.Add(this.dateTimePicker_Endday);
            this.panel2.Controls.Add(this.lblDenNgay);
            this.panel2.Controls.Add(this.dateTimePicker_StartDate);
            this.panel2.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 176);
            this.panel2.TabIndex = 85;
            // 
            // dtp_Hours_End
            // 
            this.dtp_Hours_End.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtp_Hours_End.CustomFormat = "HH:mm";
            this.dtp_Hours_End.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Hours_End.Location = new System.Drawing.Point(140, 115);
            this.dtp_Hours_End.Name = "dtp_Hours_End";
            this.dtp_Hours_End.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtp_Hours_End.RightToLeftLayout = true;
            this.dtp_Hours_End.Size = new System.Drawing.Size(195, 28);
            this.dtp_Hours_End.TabIndex = 86;
            // 
            // dtp_Hours_Start
            // 
            this.dtp_Hours_Start.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtp_Hours_Start.CustomFormat = "HH:mm";
            this.dtp_Hours_Start.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Hours_Start.Location = new System.Drawing.Point(140, 29);
            this.dtp_Hours_Start.Name = "dtp_Hours_Start";
            this.dtp_Hours_Start.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtp_Hours_Start.RightToLeftLayout = true;
            this.dtp_Hours_Start.Size = new System.Drawing.Size(195, 28);
            this.dtp_Hours_Start.TabIndex = 85;
            this.dtp_Hours_Start.ValueChanged += new System.EventHandler(this.dtp_Hours_Start_ValueChanged);
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
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(56, 502);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(100, 20);
            this.radioButton1.TabIndex = 89;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(184, 502);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(100, 20);
            this.radioButton2.TabIndex = 90;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // QLC_Them
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 773);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "QLC_Them";
            this.Text = "Them";
            this.Load += new System.EventHandler(this.QLC_Them_Load);
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
        private System.Windows.Forms.ComboBox comboBox_End;
        public System.Windows.Forms.ComboBox comboBox_Start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Endday;
        private System.Windows.Forms.DateTimePicker dateTimePicker_StartDate;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtp_Hours_Start;
        private System.Windows.Forms.DateTimePicker dtp_Hours_End;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgr_ReadyBus;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}
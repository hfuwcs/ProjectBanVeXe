using System.Drawing;
using System.Windows.Forms;

namespace DoAnCuoiKy.Forms
{
    partial class UC_QuanLyVe
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

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dataGridViewQuanLyVe = new System.Windows.Forms.DataGridView();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.comboBox_Start = new System.Windows.Forms.ComboBox();
            this.comboBox_End = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker_StartDate2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_EndDate2 = new System.Windows.Forms.DateTimePicker();
            this.comboBox_End2 = new System.Windows.Forms.ComboBox();
            this.comboBox_Start2 = new System.Windows.Forms.ComboBox();
            this.btn_Tim2 = new System.Windows.Forms.Button();
            this.btnCount1 = new System.Windows.Forms.Button();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTuyen = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCount2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuanLyVe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(508, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ CHI TIẾT VÉ";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(188, 730);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(153, 35);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Lọc dữ liệu";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(1306, 754);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(96, 35);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // dataGridViewQuanLyVe
            // 
            this.dataGridViewQuanLyVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuanLyVe.Location = new System.Drawing.Point(-18, 59);
            this.dataGridViewQuanLyVe.Name = "dataGridViewQuanLyVe";
            this.dataGridViewQuanLyVe.RowHeadersWidth = 51;
            this.dataGridViewQuanLyVe.Size = new System.Drawing.Size(1397, 377);
            this.dataGridViewQuanLyVe.TabIndex = 0;
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(188, 509);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_StartDate.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(180, 439);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(237, 46);
            this.label6.TabIndex = 20;
            this.label6.Text = "Lọc vé đã bán";
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(188, 571);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_EndDate.TabIndex = 21;
            // 
            // comboBox_Start
            // 
            this.comboBox_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Start.FormattingEnabled = true;
            this.comboBox_Start.Location = new System.Drawing.Point(177, 623);
            this.comboBox_Start.Name = "comboBox_Start";
            this.comboBox_Start.Size = new System.Drawing.Size(121, 33);
            this.comboBox_Start.TabIndex = 76;
            // 
            // comboBox_End
            // 
            this.comboBox_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_End.FormattingEnabled = true;
            this.comboBox_End.Location = new System.Drawing.Point(390, 626);
            this.comboBox_End.Name = "comboBox_End";
            this.comboBox_End.Size = new System.Drawing.Size(121, 33);
            this.comboBox_End.TabIndex = 77;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(381, 730);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 35);
            this.button1.TabIndex = 78;
            this.button1.Text = "Tải lại";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UC_QuanLyVe_Load);
            // 
            // dateTimePicker_StartDate2
            // 
            this.dateTimePicker_StartDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate2.Location = new System.Drawing.Point(1011, 509);
            this.dateTimePicker_StartDate2.Name = "dateTimePicker_StartDate2";
            this.dateTimePicker_StartDate2.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_StartDate2.TabIndex = 79;
            // 
            // dateTimePicker_EndDate2
            // 
            this.dateTimePicker_EndDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_EndDate2.Location = new System.Drawing.Point(1011, 570);
            this.dateTimePicker_EndDate2.Name = "dateTimePicker_EndDate2";
            this.dateTimePicker_EndDate2.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_EndDate2.TabIndex = 80;
            // 
            // comboBox_End2
            // 
            this.comboBox_End2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_End2.FormattingEnabled = true;
            this.comboBox_End2.Location = new System.Drawing.Point(1213, 626);
            this.comboBox_End2.Name = "comboBox_End2";
            this.comboBox_End2.Size = new System.Drawing.Size(121, 33);
            this.comboBox_End2.TabIndex = 81;
            // 
            // comboBox_Start2
            // 
            this.comboBox_Start2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Start2.FormattingEnabled = true;
            this.comboBox_Start2.Location = new System.Drawing.Point(1011, 623);
            this.comboBox_Start2.Name = "comboBox_Start2";
            this.comboBox_Start2.Size = new System.Drawing.Size(121, 33);
            this.comboBox_Start2.TabIndex = 82;
            // 
            // btn_Tim2
            // 
            this.btn_Tim2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim2.Location = new System.Drawing.Point(1021, 720);
            this.btn_Tim2.Name = "btn_Tim2";
            this.btn_Tim2.Size = new System.Drawing.Size(140, 35);
            this.btn_Tim2.TabIndex = 83;
            this.btn_Tim2.Text = "Lọc dữ liệu";
            this.btn_Tim2.UseVisualStyleBackColor = true;
            this.btn_Tim2.Click += new System.EventHandler(this.btn_Tim2_Click);
            // 
            // btnCount1
            // 
            this.btnCount1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCount1.Location = new System.Drawing.Point(177, 675);
            this.btnCount1.Name = "btnCount1";
            this.btnCount1.Size = new System.Drawing.Size(96, 35);
            this.btnCount1.TabIndex = 88;
            this.btnCount1.UseVisualStyleBackColor = true;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgay.Location = new System.Drawing.Point(34, 514);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(113, 29);
            this.lblTuNgay.TabIndex = 89;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(833, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 90;
            this.label2.Text = "Từ ngày:";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.Location = new System.Drawing.Point(34, 570);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(129, 29);
            this.lblDenNgay.TabIndex = 91;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(833, 570);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 29);
            this.label3.TabIndex = 92;
            this.label3.Text = "Đến ngày:";
            // 
            // lblTuyen
            // 
            this.lblTuyen.AutoSize = true;
            this.lblTuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuyen.Location = new System.Drawing.Point(34, 623);
            this.lblTuyen.Name = "lblTuyen";
            this.lblTuyen.Size = new System.Drawing.Size(92, 29);
            this.lblTuyen.TabIndex = 93;
            this.lblTuyen.Text = "Tuyến:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1148, 623);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 32);
            this.label4.TabIndex = 94;
            this.label4.Text = "=>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(322, 623);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 32);
            this.label5.TabIndex = 95;
            this.label5.Text = "=>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(833, 626);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 29);
            this.label7.TabIndex = 96;
            this.label7.Text = "Tuyến:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1192, 720);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 35);
            this.button2.TabIndex = 97;
            this.button2.Text = "Tải lại";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.UC_QuanLyVe_Load);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(860, 439);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(519, 46);
            this.label8.TabIndex = 98;
            this.label8.Text = "Lọc vé theo thời gian khởi hành";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(34, 678);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 28);
            this.label9.TabIndex = 99;
            this.label9.Text = "Tổng số vé";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 789);
            this.splitter1.TabIndex = 100;
            this.splitter1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(833, 675);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 28);
            this.label10.TabIndex = 101;
            this.label10.Text = "Tổng số vé";
            // 
            // btnCount2
            // 
            this.btnCount2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCount2.Location = new System.Drawing.Point(1011, 672);
            this.btnCount2.Name = "btnCount2";
            this.btnCount2.Size = new System.Drawing.Size(96, 35);
            this.btnCount2.TabIndex = 102;
            this.btnCount2.UseVisualStyleBackColor = true;
            // 
            // UC_QuanLyVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCount2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTuyen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.btnCount1);
            this.Controls.Add(this.btn_Tim2);
            this.Controls.Add(this.comboBox_Start2);
            this.Controls.Add(this.comboBox_End2);
            this.Controls.Add(this.dateTimePicker_EndDate2);
            this.Controls.Add(this.dateTimePicker_StartDate2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_End);
            this.Controls.Add(this.comboBox_Start);
            this.Controls.Add(this.dateTimePicker_EndDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker_StartDate);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewQuanLyVe);
            this.Name = "UC_QuanLyVe";
            this.Size = new System.Drawing.Size(1763, 789);
            this.Load += new System.EventHandler(this.UC_QuanLyVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuanLyVe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private Label label1;
        private Button btnThem;
        private Button btnTim;
        private Button btnThoat;
        private DataGridView dataGridViewQuanLyVe;
        private DateTimePicker dateTimePicker_StartDate;
        private Label label6;
        private DateTimePicker dateTimePicker_EndDate;
        private ComboBox comboBox_Start;
        private ComboBox comboBox_End;
        private Button button1;
        private DateTimePicker dateTimePicker_StartDate2;
        private DateTimePicker dateTimePicker_EndDate2;
        private ComboBox comboBox_End2;
        private ComboBox comboBox_Start2;
        private Button btn_Tim2;
        private Button btnCount1;
        private Label lblTuNgay;
        private Label label2;
        private Label lblDenNgay;
        private Label label3;
        private Label lblTuyen;
        private Label label4;
        private Label label5;
        private Label label7;
        private Button button2;
        private Label label8;
        private Label label9;
        private Splitter splitter1;
        private Label label10;
        private Button btnCount2;
    }
}
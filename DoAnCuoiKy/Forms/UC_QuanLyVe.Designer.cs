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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCount2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Tim2 = new System.Windows.Forms.Button();
            this.comboBox_Start2 = new System.Windows.Forms.ComboBox();
            this.comboBox_End2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_EndDate2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_StartDate2 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTuyen = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.btnCount1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_End = new System.Windows.Forms.ComboBox();
            this.comboBox_Start = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_EndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_StartDate = new System.Windows.Forms.DateTimePicker();
            this.btnTim = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewQuanLyVe = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnXuatLaiVe = new System.Windows.Forms.Button();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.dateTimePicker_StartDay = new System.Windows.Forms.DateTimePicker();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblNgayDi = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_TraCuuVe = new System.Windows.Forms.DataGridView();
            this.DetailsTicketID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivalLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuanLyVe)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TraCuuVe)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 835);
            this.splitter1.TabIndex = 100;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1754, 829);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 105;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataGridViewQuanLyVe);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1746, 800);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản lý vé";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCount2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_Tim2);
            this.groupBox2.Controls.Add(this.comboBox_Start2);
            this.groupBox2.Controls.Add(this.comboBox_End2);
            this.groupBox2.Controls.Add(this.dateTimePicker_EndDate2);
            this.groupBox2.Controls.Add(this.dateTimePicker_StartDate2);
            this.groupBox2.Location = new System.Drawing.Point(681, 444);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(639, 338);
            this.groupBox2.TabIndex = 112;
            this.groupBox2.TabStop = false;
            // 
            // btnCount2
            // 
            this.btnCount2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCount2.Location = new System.Drawing.Point(235, 223);
            this.btnCount2.Name = "btnCount2";
            this.btnCount2.Size = new System.Drawing.Size(96, 35);
            this.btnCount2.TabIndex = 102;
            this.btnCount2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(57, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 28);
            this.label10.TabIndex = 101;
            this.label10.Text = "Tổng số vé";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(416, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 35);
            this.button2.TabIndex = 97;
            this.button2.Text = "Tải lại";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(168, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(353, 31);
            this.label8.TabIndex = 98;
            this.label8.Text = "Lọc vé theo thời gian khởi hành";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(57, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 29);
            this.label7.TabIndex = 96;
            this.label7.Text = "Tuyến:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(372, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 32);
            this.label4.TabIndex = 94;
            this.label4.Text = "=>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 29);
            this.label3.TabIndex = 92;
            this.label3.Text = "Đến ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 90;
            this.label2.Text = "Từ ngày:";
            // 
            // btn_Tim2
            // 
            this.btn_Tim2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim2.Location = new System.Drawing.Point(245, 271);
            this.btn_Tim2.Name = "btn_Tim2";
            this.btn_Tim2.Size = new System.Drawing.Size(140, 35);
            this.btn_Tim2.TabIndex = 83;
            this.btn_Tim2.Text = "Lọc dữ liệu";
            this.btn_Tim2.UseVisualStyleBackColor = true;
            // 
            // comboBox_Start2
            // 
            this.comboBox_Start2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Start2.FormattingEnabled = true;
            this.comboBox_Start2.Location = new System.Drawing.Point(235, 174);
            this.comboBox_Start2.Name = "comboBox_Start2";
            this.comboBox_Start2.Size = new System.Drawing.Size(121, 33);
            this.comboBox_Start2.TabIndex = 82;
            // 
            // comboBox_End2
            // 
            this.comboBox_End2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_End2.FormattingEnabled = true;
            this.comboBox_End2.Location = new System.Drawing.Point(437, 177);
            this.comboBox_End2.Name = "comboBox_End2";
            this.comboBox_End2.Size = new System.Drawing.Size(121, 33);
            this.comboBox_End2.TabIndex = 81;
            // 
            // dateTimePicker_EndDate2
            // 
            this.dateTimePicker_EndDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_EndDate2.Location = new System.Drawing.Point(235, 121);
            this.dateTimePicker_EndDate2.Name = "dateTimePicker_EndDate2";
            this.dateTimePicker_EndDate2.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_EndDate2.TabIndex = 80;
            // 
            // dateTimePicker_StartDate2
            // 
            this.dateTimePicker_StartDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate2.Location = new System.Drawing.Point(235, 60);
            this.dateTimePicker_StartDate2.Name = "dateTimePicker_StartDate2";
            this.dateTimePicker_StartDate2.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_StartDate2.TabIndex = 79;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblTuyen);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblDenNgay);
            this.groupBox1.Controls.Add(this.lblTuNgay);
            this.groupBox1.Controls.Add(this.btnCount1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox_End);
            this.groupBox1.Controls.Add(this.comboBox_Start);
            this.groupBox1.Controls.Add(this.dateTimePicker_EndDate);
            this.groupBox1.Controls.Add(this.dateTimePicker_StartDate);
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Location = new System.Drawing.Point(15, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 343);
            this.groupBox1.TabIndex = 111;
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 28);
            this.label9.TabIndex = 99;
            this.label9.Text = "Tổng số vé";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(311, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 32);
            this.label5.TabIndex = 95;
            this.label5.Text = "=>";
            // 
            // lblTuyen
            // 
            this.lblTuyen.AutoSize = true;
            this.lblTuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuyen.Location = new System.Drawing.Point(23, 178);
            this.lblTuyen.Name = "lblTuyen";
            this.lblTuyen.Size = new System.Drawing.Size(92, 29);
            this.lblTuyen.TabIndex = 93;
            this.lblTuyen.Text = "Tuyến:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(187, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 31);
            this.label6.TabIndex = 20;
            this.label6.Text = "Lọc vé đã bán";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDenNgay.Location = new System.Drawing.Point(23, 125);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(129, 29);
            this.lblDenNgay.TabIndex = 91;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuNgay.Location = new System.Drawing.Point(23, 69);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(113, 29);
            this.lblTuNgay.TabIndex = 89;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // btnCount1
            // 
            this.btnCount1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCount1.Location = new System.Drawing.Point(166, 230);
            this.btnCount1.Name = "btnCount1";
            this.btnCount1.Size = new System.Drawing.Size(96, 35);
            this.btnCount1.TabIndex = 88;
            this.btnCount1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(370, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 35);
            this.button1.TabIndex = 78;
            this.button1.Text = "Tải lại";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox_End
            // 
            this.comboBox_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_End.FormattingEnabled = true;
            this.comboBox_End.Location = new System.Drawing.Point(379, 181);
            this.comboBox_End.Name = "comboBox_End";
            this.comboBox_End.Size = new System.Drawing.Size(121, 33);
            this.comboBox_End.TabIndex = 77;
            // 
            // comboBox_Start
            // 
            this.comboBox_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Start.FormattingEnabled = true;
            this.comboBox_Start.Location = new System.Drawing.Point(166, 178);
            this.comboBox_Start.Name = "comboBox_Start";
            this.comboBox_Start.Size = new System.Drawing.Size(121, 33);
            this.comboBox_Start.TabIndex = 76;
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(177, 126);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_EndDate.TabIndex = 21;
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(177, 64);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_StartDate.TabIndex = 19;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(177, 285);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(153, 35);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Lọc dữ liệu";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(579, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 46);
            this.label1.TabIndex = 110;
            this.label1.Text = "QUẢN LÝ VÉ";
            // 
            // dataGridViewQuanLyVe
            // 
            this.dataGridViewQuanLyVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuanLyVe.Location = new System.Drawing.Point(15, 52);
            this.dataGridViewQuanLyVe.Name = "dataGridViewQuanLyVe";
            this.dataGridViewQuanLyVe.RowHeadersWidth = 51;
            this.dataGridViewQuanLyVe.Size = new System.Drawing.Size(1366, 377);
            this.dataGridViewQuanLyVe.TabIndex = 109;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnXuatLaiVe);
            this.tabPage2.Controls.Add(this.btnTraCuu);
            this.tabPage2.Controls.Add(this.dateTimePicker_StartDay);
            this.tabPage2.Controls.Add(this.txtSDT);
            this.tabPage2.Controls.Add(this.lblSDT);
            this.tabPage2.Controls.Add(this.lblNgayDi);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1746, 800);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tra cứu vé";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnXuatLaiVe
            // 
            this.btnXuatLaiVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatLaiVe.Location = new System.Drawing.Point(323, 516);
            this.btnXuatLaiVe.Margin = new System.Windows.Forms.Padding(4);
            this.btnXuatLaiVe.Name = "btnXuatLaiVe";
            this.btnXuatLaiVe.Size = new System.Drawing.Size(113, 33);
            this.btnXuatLaiVe.TabIndex = 85;
            this.btnXuatLaiVe.Text = "Xuất lại vé";
            this.btnXuatLaiVe.UseVisualStyleBackColor = true;
            this.btnXuatLaiVe.Click += new System.EventHandler(this.btnXuatLaiVe_Click);
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraCuu.Location = new System.Drawing.Point(349, 179);
            this.btnTraCuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(111, 46);
            this.btnTraCuu.TabIndex = 84;
            this.btnTraCuu.Text = "Tra Cứu";
            this.btnTraCuu.UseVisualStyleBackColor = true;
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            // 
            // dateTimePicker_StartDay
            // 
            this.dateTimePicker_StartDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDay.Location = new System.Drawing.Point(186, 48);
            this.dateTimePicker_StartDay.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker_StartDay.Name = "dateTimePicker_StartDay";
            this.dateTimePicker_StartDay.Size = new System.Drawing.Size(555, 26);
            this.dateTimePicker_StartDay.TabIndex = 83;
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(186, 145);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(555, 26);
            this.txtSDT.TabIndex = 82;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(42, 149);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(106, 20);
            this.lblSDT.TabIndex = 81;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // lblNgayDi
            // 
            this.lblNgayDi.AutoSize = true;
            this.lblNgayDi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayDi.Location = new System.Drawing.Point(42, 49);
            this.lblNgayDi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayDi.Name = "lblNgayDi";
            this.lblNgayDi.Size = new System.Drawing.Size(65, 20);
            this.lblNgayDi.TabIndex = 80;
            this.lblNgayDi.Text = "Ngày đi";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView_TraCuuVe);
            this.panel1.Location = new System.Drawing.Point(7, 253);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 233);
            this.panel1.TabIndex = 78;
            // 
            // dataGridView_TraCuuVe
            // 
            this.dataGridView_TraCuuVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TraCuuVe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DetailsTicketID,
            this.FullName,
            this.PhoneNumber,
            this.DepartureLocation,
            this.ArrivalLocation,
            this.DepartureTime,
            this.SeatID,
            this.Price});
            this.dataGridView_TraCuuVe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_TraCuuVe.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_TraCuuVe.Name = "dataGridView_TraCuuVe";
            this.dataGridView_TraCuuVe.ReadOnly = true;
            this.dataGridView_TraCuuVe.RowHeadersWidth = 51;
            this.dataGridView_TraCuuVe.RowTemplate.Height = 24;
            this.dataGridView_TraCuuVe.Size = new System.Drawing.Size(1060, 231);
            this.dataGridView_TraCuuVe.TabIndex = 0;
            // 
            // DetailsTicketID
            // 
            this.DetailsTicketID.DataPropertyName = "DetailsTicketID";
            this.DetailsTicketID.HeaderText = "Mã vé";
            this.DetailsTicketID.MinimumWidth = 6;
            this.DetailsTicketID.Name = "DetailsTicketID";
            this.DetailsTicketID.ReadOnly = true;
            this.DetailsTicketID.Width = 125;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "Họ và tên";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 125;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "Số điện thoại";
            this.PhoneNumber.MinimumWidth = 6;
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            this.PhoneNumber.Width = 125;
            // 
            // DepartureLocation
            // 
            this.DepartureLocation.DataPropertyName = "DepartureLocation";
            this.DepartureLocation.HeaderText = "Điểm khởi hành";
            this.DepartureLocation.MinimumWidth = 6;
            this.DepartureLocation.Name = "DepartureLocation";
            this.DepartureLocation.ReadOnly = true;
            this.DepartureLocation.Width = 125;
            // 
            // ArrivalLocation
            // 
            this.ArrivalLocation.DataPropertyName = "ArrivalLocation";
            this.ArrivalLocation.HeaderText = "Điểm đến";
            this.ArrivalLocation.MinimumWidth = 6;
            this.ArrivalLocation.Name = "ArrivalLocation";
            this.ArrivalLocation.ReadOnly = true;
            this.ArrivalLocation.Width = 125;
            // 
            // DepartureTime
            // 
            this.DepartureTime.DataPropertyName = "DepartureTime";
            this.DepartureTime.HeaderText = "Khởi gian khởi hành";
            this.DepartureTime.MinimumWidth = 6;
            this.DepartureTime.Name = "DepartureTime";
            this.DepartureTime.ReadOnly = true;
            this.DepartureTime.Width = 125;
            // 
            // SeatID
            // 
            this.SeatID.DataPropertyName = "SeatNumber";
            this.SeatID.HeaderText = "Mã số ghế";
            this.SeatID.MinimumWidth = 6;
            this.SeatID.Name = "SeatID";
            this.SeatID.ReadOnly = true;
            this.SeatID.Width = 125;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Giá vé";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // UC_QuanLyVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tabControl1);
            this.Name = "UC_QuanLyVe";
            this.Size = new System.Drawing.Size(1763, 835);
            this.Load += new System.EventHandler(this.UC_QuanLyVe_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuanLyVe)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TraCuuVe)).EndInit();
            this.ResumeLayout(false);

        }

        private Button btnThem;
        private Splitter splitter1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox2;
        private Button btnCount2;
        private Label label10;
        private Button button2;
        private Label label8;
        private Label label7;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btn_Tim2;
        private ComboBox comboBox_Start2;
        private ComboBox comboBox_End2;
        private DateTimePicker dateTimePicker_EndDate2;
        private DateTimePicker dateTimePicker_StartDate2;
        private GroupBox groupBox1;
        private Label label9;
        private Label label5;
        private Label lblTuyen;
        private Label label6;
        private Label lblDenNgay;
        private Label lblTuNgay;
        private Button btnCount1;
        private Button button1;
        private ComboBox comboBox_End;
        private ComboBox comboBox_Start;
        private DateTimePicker dateTimePicker_EndDate;
        private DateTimePicker dateTimePicker_StartDate;
        private Button btnTim;
        private Label label1;
        private DataGridView dataGridViewQuanLyVe;
        private TabPage tabPage2;
        private Button btnXuatLaiVe;
        private Button btnTraCuu;
        private DateTimePicker dateTimePicker_StartDay;
        private TextBox txtSDT;
        private Label lblSDT;
        private Label lblNgayDi;
        private Panel panel1;
        private DataGridView dataGridView_TraCuuVe;
        private DataGridViewTextBoxColumn DetailsTicketID;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn DepartureLocation;
        private DataGridViewTextBoxColumn ArrivalLocation;
        private DataGridViewTextBoxColumn DepartureTime;
        private DataGridViewTextBoxColumn SeatID;
        private DataGridViewTextBoxColumn Price;
    }
}
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuanLyVe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(504, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ CHI TIẾT VÉ";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(109, 593);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(96, 35);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(939, 584);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(96, 35);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click_1);
            // 
            // dataGridViewQuanLyVe
            // 
            this.dataGridViewQuanLyVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuanLyVe.Location = new System.Drawing.Point(-18, 72);
            this.dataGridViewQuanLyVe.Name = "dataGridViewQuanLyVe";
            this.dataGridViewQuanLyVe.RowHeadersWidth = 51;
            this.dataGridViewQuanLyVe.Size = new System.Drawing.Size(1397, 281);
            this.dataGridViewQuanLyVe.TabIndex = 0;
            // 
            // dateTimePicker_StartDate
            // 
            this.dateTimePicker_StartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_StartDate.Location = new System.Drawing.Point(12, 405);
            this.dateTimePicker_StartDate.Name = "dateTimePicker_StartDate";
            this.dateTimePicker_StartDate.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_StartDate.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(82, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 46);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tìm kiếm";
            // 
            // dateTimePicker_EndDate
            // 
            this.dateTimePicker_EndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_EndDate.Location = new System.Drawing.Point(12, 451);
            this.dateTimePicker_EndDate.Name = "dateTimePicker_EndDate";
            this.dateTimePicker_EndDate.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_EndDate.TabIndex = 21;
            // 
            // comboBox_Start
            // 
            this.comboBox_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Start.FormattingEnabled = true;
            this.comboBox_Start.Location = new System.Drawing.Point(27, 509);
            this.comboBox_Start.Name = "comboBox_Start";
            this.comboBox_Start.Size = new System.Drawing.Size(121, 33);
            this.comboBox_Start.TabIndex = 76;
            // 
            // comboBox_End
            // 
            this.comboBox_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_End.FormattingEnabled = true;
            this.comboBox_End.Location = new System.Drawing.Point(195, 509);
            this.comboBox_End.Name = "comboBox_End";
            this.comboBox_End.Size = new System.Drawing.Size(121, 33);
            this.comboBox_End.TabIndex = 77;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1060, 431);
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
            this.dateTimePicker_StartDate2.Location = new System.Drawing.Point(512, 405);
            this.dateTimePicker_StartDate2.Name = "dateTimePicker_StartDate2";
            this.dateTimePicker_StartDate2.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_StartDate2.TabIndex = 79;
            // 
            // dateTimePicker_EndDate2
            // 
            this.dateTimePicker_EndDate2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_EndDate2.Location = new System.Drawing.Point(502, 451);
            this.dateTimePicker_EndDate2.Name = "dateTimePicker_EndDate2";
            this.dateTimePicker_EndDate2.Size = new System.Drawing.Size(323, 28);
            this.dateTimePicker_EndDate2.TabIndex = 80;
            // 
            // comboBox_End2
            // 
            this.comboBox_End2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_End2.FormattingEnabled = true;
            this.comboBox_End2.Location = new System.Drawing.Point(704, 509);
            this.comboBox_End2.Name = "comboBox_End2";
            this.comboBox_End2.Size = new System.Drawing.Size(121, 33);
            this.comboBox_End2.TabIndex = 81;
            // 
            // comboBox_Start2
            // 
            this.comboBox_Start2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Start2.FormattingEnabled = true;
            this.comboBox_Start2.Location = new System.Drawing.Point(496, 509);
            this.comboBox_Start2.Name = "comboBox_Start2";
            this.comboBox_Start2.Size = new System.Drawing.Size(121, 33);
            this.comboBox_Start2.TabIndex = 82;
            // 
            // btn_Tim2
            // 
            this.btn_Tim2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tim2.Location = new System.Drawing.Point(595, 584);
            this.btn_Tim2.Name = "btn_Tim2";
            this.btn_Tim2.Size = new System.Drawing.Size(96, 35);
            this.btn_Tim2.TabIndex = 83;
            this.btn_Tim2.Text = "Tìm";
            this.btn_Tim2.UseVisualStyleBackColor = true;
            this.btn_Tim2.Click += new System.EventHandler(this.btn_Tim2_Click);
            // 
            // UC_QuanLyVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Size = new System.Drawing.Size(1763, 711);
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
    }
}
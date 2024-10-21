namespace DoAnCuoiKy
{
    partial class QLC_Sua
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_End = new System.Windows.Forms.ComboBox();
            this.lblTuyen = new System.Windows.Forms.Label();
            this.comboBox_Start = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_Bus = new System.Windows.Forms.DataGridView();
            this.BusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSeat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBox_End);
            this.panel1.Controls.Add(this.lblTuyen);
            this.panel1.Controls.Add(this.comboBox_Start);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 100);
            this.panel1.TabIndex = 79;
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
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridView_Bus);
            this.panel2.Location = new System.Drawing.Point(1, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 272);
            this.panel2.TabIndex = 80;
            // 
            // dataGridView_Bus
            // 
            this.dataGridView_Bus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Bus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BusID,
            this.BusNumber,
            this.TotalSeat,
            this.BusType});
            this.dataGridView_Bus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Bus.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Bus.Name = "dataGridView_Bus";
            this.dataGridView_Bus.RowHeadersWidth = 51;
            this.dataGridView_Bus.RowTemplate.Height = 24;
            this.dataGridView_Bus.Size = new System.Drawing.Size(783, 270);
            this.dataGridView_Bus.TabIndex = 0;
            // 
            // BusID
            // 
            this.BusID.HeaderText = "BusID";
            this.BusID.MinimumWidth = 6;
            this.BusID.Name = "BusID";
            this.BusID.Visible = false;
            this.BusID.Width = 125;
            // 
            // BusNumber
            // 
            this.BusNumber.DataPropertyName = "BusNumber";
            this.BusNumber.HeaderText = "Biển số xe";
            this.BusNumber.MinimumWidth = 6;
            this.BusNumber.Name = "BusNumber";
            this.BusNumber.ReadOnly = true;
            this.BusNumber.Width = 125;
            // 
            // TotalSeat
            // 
            this.TotalSeat.DataPropertyName = "TotalSeat";
            this.TotalSeat.HeaderText = "Tổng số chỗ ngồi";
            this.TotalSeat.MinimumWidth = 6;
            this.TotalSeat.Name = "TotalSeat";
            this.TotalSeat.ReadOnly = true;
            this.TotalSeat.Width = 125;
            // 
            // BusType
            // 
            this.BusType.DataPropertyName = "BusType";
            this.BusType.HeaderText = "Loại xe";
            this.BusType.MinimumWidth = 6;
            this.BusType.Name = "BusType";
            this.BusType.ReadOnly = true;
            this.BusType.Width = 125;
            // 
            // QLC_Sua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 773);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "QLC_Sua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThemXoa_QLChuyen";
            this.Load += new System.EventHandler(this.ThemXoa_QLChuyen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox_End;
        private System.Windows.Forms.Label lblTuyen;
        public System.Windows.Forms.ComboBox comboBox_Start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_Bus;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSeat;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusType;
    }
}
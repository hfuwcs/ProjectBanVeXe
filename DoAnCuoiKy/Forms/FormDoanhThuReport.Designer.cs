namespace DoAnCuoiKy.Forms
{
    partial class FormDoanhThuReport
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
            this.ReportDoanhThu = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReportDoanhThu
            // 
            this.ReportDoanhThu.ActiveViewIndex = -1;
            this.ReportDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportDoanhThu.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.ReportDoanhThu.Name = "ReportDoanhThu";
            this.ReportDoanhThu.Size = new System.Drawing.Size(800, 450);
            this.ReportDoanhThu.TabIndex = 0;
            // 
            // FormDoanhThuReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReportDoanhThu);
            this.Name = "FormDoanhThuReport";
            this.Text = "FormDoanhThuReport";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportDoanhThu;
    }
}
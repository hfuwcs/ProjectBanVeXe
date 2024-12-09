using DoAnCuoiKy.CrystalReport;
using DoAnCuoiKy.Datasets;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy.Forms
{
    public partial class FormDoanhThuReport : Form
    {
        static DbContext db = new DbContext();
        public FormDoanhThuReport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            int tripid = 1;
            IncomeReport incomeReport = new IncomeReport();
            incomeReport.Load("Path to IncomeReport.rpt");

            incomeReport.SetParameterValue("@StartDate", DateTime.Now);
            incomeReport.SetParameterValue("@EndDate", DateTime.Now);
            incomeReport.SetParameterValue("@TripID", tripid);

            ReportDoanhThu.ReportSource = incomeReport;
        }
    }
}

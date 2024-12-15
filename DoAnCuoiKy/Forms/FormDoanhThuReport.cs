using DoAnCuoiKy.CrystalReport;
using DoAnCuoiKy.Datasets;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            int tripid = 1;
            IncomeReport incomeReport = new IncomeReport();
            incomeReport.SetDatabaseLogon("sa", "123","FUC", "DB_DoAnBanVeXe");

            string sqls = "EXEC [dbo].[GetRevenueReport] \r\n\t@StartDate = N'2024/10/12',\r\n\t@EndDate = N'2024/12/15',\r\n\t@TripID = 1";

            DataTable dt = db.ExecuteQuery(sqls);

            incomeReport.SetDataSource(dt);
            crystalReportViewer1.ReportSource = incomeReport;
            crystalReportViewer1.Refresh();
        }
    }
}

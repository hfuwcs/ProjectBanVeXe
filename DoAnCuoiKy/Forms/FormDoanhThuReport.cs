using DoAnCuoiKy.CrystalReport;
using DoAnCuoiKy.Datasets;
using MyLibrary;
using MyLibrary.BLL;
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
        public FormDoanhThuReport(string startDate, string endDate, int routeID, string depLoc, string arrLoc)
        {
            InitializeComponent();
            IncomeReport incomeReport = new IncomeReport();
            incomeReport.SetDatabaseLogon("sa", "123","FUC", "DB_DoAnBanVeXe");
            string SP_RevenueReport = "EXEC [GetRevenueReport] @StartDate , @EndDate , @TripID ";

            object[] param = {
                startDate,
                endDate,
                routeID
            };

            DataTable dt = db.ExecuteQuery(SP_RevenueReport, param);

            string routeName = RouteBLL.Instance.GetRouteName(depLoc, arrLoc);
            incomeReport.SetDataSource(dt);
            incomeReport.SetParameterValue("@StartDate", startDate);
            incomeReport.SetParameterValue("@EndDate", endDate);
            incomeReport.SetParameterValue("@TripName", routeName);
            crystalReportViewer1.ReportSource = incomeReport;
            crystalReportViewer1.Refresh();
        }
    }
}

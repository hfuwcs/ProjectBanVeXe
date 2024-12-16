using DoAnCuoiKy.CrystalReport;
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
    public partial class FormVeReport : Form
    {
        static DbContext db = new DbContext();
        public FormVeReport(int orderTicketID)
        {
            InitializeComponent();
            TicketReport ticketReport = new TicketReport();
            ticketReport.SetDatabaseLogon("sa", "123", "FUC", "DB_DoAnBanVeXe");


            string sqls = "EXEC GetTicketReport @OTID";

            DataTable dt = db.ExecuteQuery(sqls, new object[] { orderTicketID });
            ticketReport.SetDataSource(dt);

            crystalReportViewer1.ReportSource = ticketReport;
            crystalReportViewer1.Refresh();
        }
    }
}

using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary.BLL;
using MyLibrary.DTO;

namespace DoAnCuoiKy
{
    public partial class QLC_Them : Form
    {
        DbContext obj = new DbContext();
        private string today = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
        public QLC_Them()
        {
            InitializeComponent();
            LoadQLC();
        }
        private void LoadQLC()
        {
            //Load các tuyến

            string sqlstart = "select RouteName from Route Group by RouteName";
            cbc_start.DataSource = obj.Instance.ExecuteQuery(sqlstart);
            cbc_start.DisplayMember = "RouteName";

            string sqlend = "select EndLocation from Route group by EndLocation";
            cbc_end.DataSource = obj.Instance.ExecuteQuery(sqlend);
            cbc_end.DisplayMember = "EndLocation";


            //Lấy ID các Bus sẵn sàng:
            dgr_ReadyBus.DataSource = BusBLL.Instance.GetBusReady(today);
            cbc_hStart.DataSource = new BindingSource(MyLibrary.Helpers.Hours, null);
            cbc_hEnd.DataSource = new BindingSource(MyLibrary.Helpers.Hours, null);
            autosizedgv(dgr_ReadyBus);
        }
        private void autosizedgv(object sender)
        {
            DataGridView dataGridView = sender as DataGridView;
            // Set your desired AutoSize Mode:
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            for (int i = 0; i <= dataGridView.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = dataGridView.Columns[i].Width;

                // Remove AutoSizing:
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                dataGridView.Columns[i].Width = colw;
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            string routename =cbc_start.Text + " - " + cbc_end.Text;
            //Lấy RouteID
            Route route = RouteBLL.Instance.GetRouteByName(routename);

            List<int> readyBus = BusBLL.Instance.GetBusIDReady(today);
            int readyBusID = Convert.ToInt32(dgr_ReadyBus.CurrentRow.Cells[0].Value);

            //Lấy Random tài xế đang sẵn sàng
            List<int> readyDriver = DriverBLL.Instance.GetReadyDriverID(today);
            int randomIndex = random.Next(0, readyDriver.Count - 1);
            int readyDriverID = readyDriver[randomIndex];

            //Lấy điểm đi và điểm đến
            string depploc = RouteBLL.Instance.GetStartLocation(routename);
            string arrloc = RouteBLL.Instance.GetEndLocation(routename);

            string depptime = dtp_StartDate.Value.ToString("yyyy/MM/dd ") + cbc_hStart.SelectedValue;
            string arrtime = dtp_StartDate.Value.ToString("yyyy/MM/dd ") + cbc_hEnd.SelectedValue;

            int res = TripBLL.Instance.InsertTrip(route.RouteID, readyBusID, readyDriverID, depploc, arrloc, depptime, arrtime);
            if (res == 0)
            {
                MessageBox.Show("Thêm không thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thành công!");
                dgr_ReadyBus.DataSource = BusBLL.Instance.GetBusReady(today);
            }
        }
    }
}

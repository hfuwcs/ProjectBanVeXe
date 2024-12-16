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
        DbContext db = new DbContext();
        private string today = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
        public QLC_Them()
        {
            InitializeComponent();
            LoadQLC();
            dtp_StartDate.ValueChanged += TimeChange;
            dtp_EndDate.ValueChanged += TimeChange;
            cbc_hStart.SelectedValueChanged += TimeChange;
            cbc_hEnd.SelectedValueChanged += TimeChange;
        }
        public event EventHandler TripAdded;
        private string GetDateTimeString(DateTimePicker datePicker, ComboBox comboBox)
        {
            // Lấy ngày từ DateTimePicker
            string datePart = datePicker.Value.ToString("yyyy/MM/dd ");

            // Lấy giờ từ ComboBox
            string timePart = comboBox.SelectedValue?.ToString();

            // Nếu giờ không hợp lệ, trả về chuỗi trống
            if (string.IsNullOrEmpty(timePart))
            {
                return string.Empty;
            }

            // Ghép ngày và giờ thành chuỗi thời gian hoàn chỉnh
            return datePart + timePart;
        }

        private void TimeChange(object sender, EventArgs e)
        {
            // Lấy chuỗi thời gian đi
            string depptime = GetDateTimeString(dtp_StartDate, cbc_hStart);
            string arrtime = GetDateTimeString(dtp_EndDate, cbc_hEnd);

            // Kiểm tra ràng buộc: thời gian đến phải lớn hơn thời gian đi
            if (DateTime.TryParse(depptime, out DateTime depTime) && DateTime.TryParse(arrtime, out DateTime arrTime))
            {
                if (arrTime < depTime)
                {
                    MessageBox.Show("Thời gian đến phải lớn hơn thời gian đi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtp_StartDate.Value = DateTime.Today;
                    return;
                }

                // Cập nhật DataGridView
                dgr_ReadyBus.DataSource = BusBLL.Instance.GetBusReady(depptime, arrtime);
            }
            else
            {
                MessageBox.Show("Dữ liệu thời gian không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void LoadQLC()
        {
            //Load các tuyến

            string sqlstart = "select StartLocation from Route Group by StartLocation";
            cbc_start.DataSource = db.Instance.ExecuteQuery(sqlstart);
            cbc_start.DisplayMember = "StartLocation";

            string sqlend = "select EndLocation from Route group by EndLocation";
            cbc_end.DataSource = db.Instance.ExecuteQuery(sqlend);
            cbc_end.DisplayMember = "EndLocation";


            //Lấy ID các Bus sẵn sàng:
            //dgr_ReadyBus.DataSource = BusBLL.Instance.GetBusReady(today);
            cbc_hStart.DataSource = new BindingSource(MyLibrary.Helpers.Hours, null);
            cbc_hEnd.DataSource = new BindingSource(MyLibrary.Helpers.Hours, null);
            //autosizedgv(dgr_ReadyBus);
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

            string depptime = GetDateTimeString(dtp_StartDate, cbc_hStart);//dtp_StartDate.Value.ToString("yyyy/MM/dd ") + cbc_hStart.SelectedValue;
            string arrtime = GetDateTimeString(dtp_EndDate, cbc_hEnd);//dtp_StartDate.Value.ToString("yyyy/MM/dd ") + cbc_hEnd.SelectedValue;

            string routename = cbc_start.Text + " - " + cbc_end.Text;
            //Lấy RouteID
            Route route = RouteBLL.Instance.GetRouteByName(routename);
            if(route.RouteName == null)
            {
                MessageBox.Show("Tuyến không tồn tại!");
                return;
            }

            List<int> readyBus = BusBLL.Instance.GetBusIDReady(depptime, arrtime);
            int readyBusID = Convert.ToInt32(dgr_ReadyBus.CurrentRow.Cells[0].Value);

            //Lấy Random tài xế đang sẵn sàng
            List<int> readyDriver = DriverBLL.Instance.GetReadyDriverID(today);
            int randomIndex = random.Next(0, readyDriver.Count - 1);
            int readyDriverID = readyDriver[randomIndex];

            //Lấy điểm đi và điểm đến
            string depploc = RouteBLL.Instance.GetStartLocation(routename);
            string arrloc = RouteBLL.Instance.GetEndLocation(routename);

            //string depptime = dtp_StartDate.Value.ToString("yyyy/MM/dd ") + cbc_hStart.SelectedValue;
            //string arrtime = dtp_StartDate.Value.ToString("yyyy/MM/dd ") + cbc_hEnd.SelectedValue;

            int res = TripBLL.Instance.InsertTrip(route.RouteID, readyBusID, readyDriverID, depploc, arrloc, depptime, arrtime);
            if (res == 0)
            {
                MessageBox.Show("Thêm không thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thành công!");
                dgr_ReadyBus.DataSource = BusBLL.Instance.GetBusReady(depptime, arrtime);
                TripAdded?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

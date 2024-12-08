using MyLibrary;
using MyLibrary.BLL;
using MyLibrary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy
{
    public partial class QLC_Sua : Form
    {
        DbContext db = new DbContext();
        int TripID;
        public QLC_Sua(int tripID)
        {
            this.TripID = tripID;
            InitializeComponent();
            dtp_StartDate.ValueChanged += TimeChange;
            dtp_EndDate.ValueChanged += TimeChange;
        }
        //autosize datagridview
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
            }
            else
            {
                MessageBox.Show("Dữ liệu thời gian không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ThemXoa_QLChuyen_Load(object sender, EventArgs e)
        {

            string sqlstart = "select StartLocation from Route group by StartLocation";
            comboBox_Start.DataSource = db.GetDataTable(sqlstart);
            comboBox_Start.DisplayMember = "StartLocation";

            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = db.GetDataTable(sqlend);
            comboBox_End.DisplayMember = "EndLocation";

            cbc_hStart.DataSource = new BindingSource(MyLibrary.Helpers.Hours, null);
            cbc_hEnd.DataSource = new BindingSource(MyLibrary.Helpers.Hours, null);

            Trip trip = TripBLL.Instance.GetTripByID(TripID);
            string hStart = trip._departureTime.ToString("HH:mm");
            string hEnd = trip._arrivalTime.ToString("HH:mm");

            comboBox_Start.Text = trip._departureLocation;
            comboBox_End.Text = trip._arrivalLocation;
            dtp_StartDate.Value = trip._departureTime;
            dtp_EndDate.Value = trip._arrivalTime;
            cbc_hStart.Text = hStart;
            cbc_hEnd.Text = hEnd;

            panel_Time.Visible = false;
            cb_Gio.Visible = false;
            cbc_hStart.Enabled = false;
            cbc_hEnd.Enabled = false;
        }

        private void cb_Ngay_CheckedChanged(object sender, EventArgs e)
        {
            if(!cb_Ngay.Checked)
            {
                panel_Time.Visible = false;
                cb_Gio.Visible = false;
                return;
            }

            panel_Time.Visible = true;
            cb_Gio.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb_Ngay.Checked)
            {
                if (cb_Gio.Checked)
                {
                    string depptime = GetDateTimeString(dtp_StartDate, cbc_hStart);
                    string arrtime = GetDateTimeString(dtp_EndDate, cbc_hEnd);
                    Trip trip = TripBLL.Instance.GetTripByID(TripID);
                    trip._departureTime = DateTime.Parse(depptime);
                    trip._arrivalTime = DateTime.Parse(arrtime);
                    if (db.UpdateRow(trip))
                    {
                        MessageBox.Show("Sửa thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Trip trip = TripBLL.Instance.GetTripByID(TripID);
                    string depptime = GetDateTimeString(dtp_StartDate, cbc_hStart);
                    string arrtime = GetDateTimeString(dtp_EndDate, cbc_hEnd);
                    trip._departureTime = DateTime.Parse(depptime);
                    trip._arrivalTime = DateTime.Parse(arrtime);
                    if (db.UpdateRow(trip))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void cb_Gio_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_Gio.Checked)
            {
                cbc_hStart.Enabled = false;
                cbc_hEnd.Enabled = false;
                return;
            }
            cbc_hEnd.Enabled =true;
            cbc_hStart.Enabled =true;
        }
    }
}

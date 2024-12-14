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
    public partial class UC_QuanLyVe : UserControl
    {
        DbContext db = new DbContext();

        // Constructor
        public UC_QuanLyVe()
        {
            InitializeComponent();
        }

        // Autosize DataGridView
        private void autosizedgv(object sender)
        {
            DataGridView dataGridView = sender as DataGridView;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i <= dataGridView.Columns.Count - 1; i++)
            {
                int colw = dataGridView.Columns[i].Width;
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView.Columns[i].Width = colw;
            }
        }

        // Load event
        private void UC_QuanLyVe_Load(object sender, EventArgs e)
        {
            string sqls = $"SELECT dt.DetailsTicketID AS \"Mã Vé\", p.FullName AS \"Tên Khách Hàng\", p.PhoneNumber AS \"Số Điện Thoại\", " +
                          $"r.RouteName AS \"Tên Tuyến Đường\", t.DepartureLocation AS \"Nơi Đi\", t.ArrivalLocation AS \"Nơi Đến\", " +
                          $"t.DepartureTime AS \"Giờ Khởi Hành\", t.ArrivalTime AS \"Giờ Đến\", b.BusNumber AS \"Số Xe\", " +
                          $"s.SeatNumber AS \"Số Ghế\", dt.Price AS \"Giá Vé\", ua.FullName AS \"Tên Nhân Viên\", ot.OrderDate AS \"Ngày bán\" " +
                          "FROM DetailsTicket dt " +
                          "JOIN OrderTicket ot ON dt.OrderTicketID = ot.OrderTicketID " +
                          "JOIN Passenger p ON ot.PassengerID = p.PassengerID " +
                          "JOIN Trip t ON dt.TripID = t.TripID " +
                          "JOIN Route r ON t.RouteID = r.RouteID " +
                          "JOIN Bus b ON t.BusID = b.BusID " +
                          "JOIN Seat s ON dt.SeatID = s.SeatID " +
                          "JOIN UserAccount ua ON ot.UserID = ua.UserID ";

            dataGridViewQuanLyVe.DataSource = db.GetDataTable(sqls);
            autosizedgv(dataGridViewQuanLyVe);

            string sqlstart = "select StartLocation from Route group by StartLocation";
            comboBox_Start.DataSource = db.GetDataTable(sqlstart);
            comboBox_Start.DisplayMember = "StartLocation";

            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = db.GetDataTable(sqlend);
            comboBox_End.DisplayMember = "EndLocation";

            comboBox_Start2.DataSource = db.GetDataTable(sqlstart);
            comboBox_Start2.DisplayMember = "StartLocation";
            comboBox_End2.DataSource = db.GetDataTable(sqlend);
            comboBox_End2.DisplayMember = "EndLocation";

            btnCount1.Text = " ";
            btnCount2.Text = " ";
        }

        // Search button 1
        private void btnTim_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker_StartDate.Value.Date;
            DateTime endDate = dateTimePicker_EndDate.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string depLoc = comboBox_Start.Text;
            string arrLoc = comboBox_End.Text;
            string startDay = dateTimePicker_StartDate.Value.ToString("yyyy/MM/dd");
            DateTime endOfDay = dateTimePicker_EndDate.Value.Date.AddDays(1).AddSeconds(-1);
            string endDay = endOfDay.ToString("yyyy/MM/dd HH:mm:ss");

            string sqls = $"SELECT dt.DetailsTicketID AS \"Mã Vé\", p.FullName AS \"Tên Khách Hàng\", p.PhoneNumber AS \"Số Điện Thoại\", " +
                          $"r.RouteName AS \"Tên Tuyến Đường\", t.DepartureLocation AS \"Nơi Đi\", t.ArrivalLocation AS \"Nơi Đến\", " +
                          $"t.DepartureTime AS \"Giờ Khởi Hành\", t.ArrivalTime AS \"Giờ Đến\", b.BusNumber AS \"Số Xe\", " +
                          $"s.SeatNumber AS \"Số Ghế\", dt.Price AS \"Giá Vé\", ua.FullName AS \"Tên Nhân Viên\", ot.OrderDate AS \"Ngày bán\" " +
                          "FROM DetailsTicket dt " +
                          "JOIN OrderTicket ot ON dt.OrderTicketID = ot.OrderTicketID " +
                          "JOIN Passenger p ON ot.PassengerID = p.PassengerID " +
                          "JOIN Trip t ON dt.TripID = t.TripID " +
                          "JOIN Route r ON t.RouteID = r.RouteID " +
                          "JOIN Bus b ON t.BusID = b.BusID " +
                          "JOIN Seat s ON dt.SeatID = s.SeatID " +
                          "JOIN UserAccount ua ON ot.UserID = ua.UserID " +
                          $"WHERE ot.OrderDate >= '{startDay}' AND ot.OrderDate <= '{endDay}' " +
                          $"AND t.DepartureLocation = '{depLoc}' AND t.ArrivalLocation = '{arrLoc}'";

            dataGridViewQuanLyVe.DataSource = db.GetDataTable(sqls);
            autosizedgv(dataGridViewQuanLyVe);

            int count = dataGridViewQuanLyVe.Rows.Count - 1;
            btnCount1.Text = count.ToString();
        }

        // Search button 2
        private void btn_Tim2_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker_StartDate2.Value.Date;
            DateTime endDate = dateTimePicker_EndDate2.Value.Date;

            if (endDate < startDate)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string depLoc = comboBox_Start2.Text;
            string arrLoc = comboBox_End2.Text;
            string startDay = dateTimePicker_StartDate2.Value.ToString("yyyy/MM/dd");
            DateTime endOfDay = dateTimePicker_EndDate2.Value.Date.AddDays(1).AddSeconds(-1);
            string endDay = endOfDay.ToString("yyyy/MM/dd HH:mm:ss");

            string sqls = $"SELECT dt.DetailsTicketID AS \"Mã Vé\", p.FullName AS \"Tên Khách Hàng\", p.PhoneNumber AS \"Số Điện Thoại\", " +
                          $"r.RouteName AS \"Tên Tuyến Đường\", t.DepartureLocation AS \"Nơi Đi\", t.ArrivalLocation AS \"Nơi Đến\", " +
                          $"t.DepartureTime AS \"Giờ Khởi Hành\", t.ArrivalTime AS \"Giờ Đến\", b.BusNumber AS \"Số Xe\", " +
                          $"s.SeatNumber AS \"Số Ghế\", dt.Price AS \"Giá Vé\", ua.FullName AS \"Tên Nhân Viên\", ot.OrderDate AS \"Ngày bán\" " +
                          "FROM DetailsTicket dt " +
                          "JOIN OrderTicket ot ON dt.OrderTicketID = ot.OrderTicketID " +
                          "JOIN Passenger p ON ot.PassengerID = p.PassengerID " +
                          "JOIN Trip t ON dt.TripID = t.TripID " +
                          "JOIN Route r ON t.RouteID = r.RouteID " +
                          "JOIN Bus b ON t.BusID = b.BusID " +
                          "JOIN Seat s ON dt.SeatID = s.SeatID " +
                          "JOIN UserAccount ua ON ot.UserID = ua.UserID " +
                          $"WHERE t.DepartureTime >= '{startDay}' AND t.DepartureTime <= '{endDay}' " +
                          $"AND t.DepartureLocation = '{depLoc}' AND t.ArrivalLocation = '{arrLoc}'";

            dataGridViewQuanLyVe.DataSource = db.GetDataTable(sqls);
            autosizedgv(dataGridViewQuanLyVe);

            int count = dataGridViewQuanLyVe.Rows.Count - 1;
            btnCount2.Text = count.ToString();
        }

        // Exit button
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.MemberwiseClone();
        }
    }
}

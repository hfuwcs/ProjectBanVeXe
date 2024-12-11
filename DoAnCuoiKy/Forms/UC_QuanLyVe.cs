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
        public UC_QuanLyVe()
        {
            InitializeComponent();
        }

        //Autosize datagridview thôi ;)
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
      
        private void UC_QuanLyVe_Load(object sender, EventArgs e)
        {
            string sqls = $"SELECT dt.DetailsTicketID AS \"Mã Vé\", p.FullName AS \"Tên Khách Hàng\", p.PhoneNumber AS \"Số Điện Thoại\", r.RouteName AS \"Tên Tuyến Đường\", t.DepartureLocation AS \"Nơi Đi\", t.ArrivalLocation AS \"Nơi Đến\", t.DepartureTime AS \"Giờ Khởi Hành\", t.ArrivalTime AS \"Giờ Đến\", b.BusNumber AS \"Số Xe\", s.SeatNumber AS \"Số Ghế\", dt.Price AS \"Giá Vé\", ua.FullName AS \"Tên Nhân Viên\",ot.OrderDate AS \"Ngày bán\" " +
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
            //
            string sqlstart = "select StartLocation from Route group by StartLocation";
            comboBox_Start.DataSource = db.GetDataTable(sqlstart);
            comboBox_Start.DisplayMember = "StartLocation";

            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = db.GetDataTable(sqlend);
            comboBox_End.DisplayMember = "EndLocation";
            //
            comboBox_Start2.DataSource = db.GetDataTable(sqlstart);
            comboBox_Start2.DisplayMember = "StartLocation";
            comboBox_End2.DataSource = db.GetDataTable(sqlend);
            comboBox_End2.DisplayMember = "EndLocation";
        }
       
    

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.MemberwiseClone();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            string depLoc = comboBox_Start.Text.ToString();
            string arrLoc = comboBox_End.Text.ToString();
            string startDay = dateTimePicker_StartDate.Value.ToString("yyyy/MM/dd HH:mm:ss");
            string endDay = dateTimePicker_EndDate.Value.ToString("yyyy/MM/dd HH:mm:ss");
           string sqls = $"SELECT dt.DetailsTicketID AS \"Mã Vé\", p.FullName AS \"Tên Khách Hàng\", p.PhoneNumber AS \"Số Điện Thoại\", " +
                          $"r.RouteName AS \"Tên Tuyến Đường\", t.DepartureLocation AS \"Nơi Đi\", t.ArrivalLocation AS \"Nơi Đến\", " +
                          $"t.DepartureTime AS \"Giờ Khởi Hành\", t.ArrivalTime AS \"Giờ Đến\", b.BusNumber AS \"Số Xe\", " +
                          $"s.SeatNumber AS \"Số Ghế\", dt.Price AS \"Giá Vé\", ua.FullName AS \"Tên Nhân Viên\",ot.OrderDate AS \"Ngày bán\"  " +
                          $"FROM DetailsTicket dt " +
                          $"JOIN OrderTicket ot ON dt.OrderTicketID = ot.OrderTicketID " +
                          $"JOIN Passenger p ON ot.PassengerID = p.PassengerID " +
                          $"JOIN Trip t ON dt.TripID = t.TripID " +
                          $"JOIN Route r ON t.RouteID = r.RouteID " +
                          $"JOIN Bus b ON t.BusID = b.BusID " +
                          $"JOIN Seat s ON dt.SeatID = s.SeatID " +
                          $"JOIN UserAccount ua ON ot.UserID = ua.UserID " +
                          $"WHERE ot.OrderDate >= '{startDay}' AND ot.OrderDate <= '{endDay}'"+
                          $"AND t.DepartureLocation = '{depLoc}' AND t.ArrivalLocation = '{arrLoc}'";

            dataGridViewQuanLyVe.DataSource = db.GetDataTable(sqls);
            autosizedgv(dataGridViewQuanLyVe);

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btn_Tim2_Click(object sender, EventArgs e)
        {
            string depLoc = comboBox_Start2.Text.ToString();
            string arrLoc = comboBox_End2.Text.ToString();
            string startDay = dateTimePicker_StartDate2.Value.ToString("yyyy/MM/dd HH:mm:ss:ss");
            string endDay = dateTimePicker_EndDate2.Value.ToString("yyyy/MM/dd HH:mm:ss:ss");
            string sqls = $"SELECT dt.DetailsTicketID AS \"Mã Vé\", p.FullName AS \"Tên Khách Hàng\", p.PhoneNumber AS \"Số Điện Thoại\", " +
                           $"r.RouteName AS \"Tên Tuyến Đường\", t.DepartureLocation AS \"Nơi Đi\", t.ArrivalLocation AS \"Nơi Đến\", " +
                           $"t.DepartureTime AS \"Giờ Khởi Hành\", t.ArrivalTime AS \"Giờ Đến\", b.BusNumber AS \"Số Xe\", " +
                           $"s.SeatNumber AS \"Số Ghế\", dt.Price AS \"Giá Vé\", ua.FullName AS \"Tên Nhân Viên\",ot.OrderDate AS \"Ngày bán\"  " +
                           $"FROM DetailsTicket dt " +
                           $"JOIN OrderTicket ot ON dt.OrderTicketID = ot.OrderTicketID " +
                           $"JOIN Passenger p ON ot.PassengerID = p.PassengerID " +
                           $"JOIN Trip t ON dt.TripID = t.TripID " +
                           $"JOIN Route r ON t.RouteID = r.RouteID " +
                           $"JOIN Bus b ON t.BusID = b.BusID " +
                           $"JOIN Seat s ON dt.SeatID = s.SeatID " +
                           $"JOIN UserAccount ua ON ot.UserID = ua.UserID " +
                           $"WHERE t.DepartureTime >= '{startDay}' AND t.DepartureTime <= '{endDay}'" +
                           $"AND t.DepartureLocation = '{depLoc}' AND t.ArrivalLocation = '{arrLoc}'";

            dataGridViewQuanLyVe.DataSource = db.GetDataTable(sqls);
            autosizedgv(dataGridViewQuanLyVe);
        }
    }
}

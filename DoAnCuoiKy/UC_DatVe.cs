using MyLibrary;
using MyLibrary.BusinessClass;
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
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace DoAnCuoiKy
{
    public partial class UC_DatVe : UserControl
    {
        BanVeXe obj = new BanVeXe();
        int totalPrice;
        public DangNhap dangNhap;
        private int _userID;
        private int TripID;
        public int UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
            }
        }
        public UC_DatVe()
        {
            InitializeComponent();
            RegisterButtonClickEvent(this.Controls);

            TripID = 0;
            totalPrice  = 0;
            //Lấy 2 chữ số thập phân
            obj.nfi.CurrencyDecimalDigits = 2;
        }

        //Autosize datagridview
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

        // Hàm đệ quy để duyệt qua tất cả các control và vô hiệu hóa các button có Text nằm trong valuesToDisable.
        // valuesToDisable là list các ghế đã được đặt của chuyến xe được chọn
        private void DisableButtons(Control.ControlCollection controls, List<string> valuesToDisable)
        {
            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    //So sánh Text button có nằm trong list cần disable không
                    if (valuesToDisable.Contains(button.Text, StringComparer.OrdinalIgnoreCase))
                    {
                        button.Enabled = false;
                        button.BackColor = Color.Gray;
                    }
                }
                // Nếu control có các control con, gọi đệ quy để kiểm tra chúng
                if (control.HasChildren)
                {
                    DisableButtons(control.Controls, valuesToDisable);
                }
            }
        }
        // Hàm kích hoạt lại tất cả các ghế
        private void EnableAllSeats(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button button && (button.Text.StartsWith("A") || button.Text.StartsWith("B")))
                {
                    button.Enabled = true; 
                    button.BackColor = Color.LightCyan;
                }

                // Duyệt đệ quy nếu có các control con
                if (control.HasChildren)
                {
                    EnableAllSeats(control.Controls);
                }
            }
        }
        // Gán sự kiện Click cho tất cả các button trong form.
        private void RegisterButtonClickEvent(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                //Tìm các button là button ghế
                //VD: A01, A02, B01, B11
                if (control is Button button && button.Enabled && (button.Text.StartsWith("A") || button.Text.StartsWith("B")))
                {
                    // Gán sự kiện Click cho mỗi button
                    button.Click += Button_Click;
                }

                // Nếu control có các control con, gọi đệ quy để kiểm tra chúng
                if (control.HasChildren)
                {
                    RegisterButtonClickEvent(control.Controls);
                }
            }
        }

        // Hàm lấy các Ghế đã được click chọn (thành màu cam)
        private List<string> GetClickedButtonTexts(Control.ControlCollection controls)
        {
            List<string> clickedButtonTexts = new List<string>();

            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    // Kiểm tra nếu button đã có màu cam
                    if (button.BackColor == Color.Orange)
                    {
                        clickedButtonTexts.Add(button.Text);
                    }
                }

                // Nếu control có các control con, gọi đệ quy để kiểm tra chúng
                if (control.HasChildren)
                {
                    clickedButtonTexts.AddRange(GetClickedButtonTexts(control.Controls));
                }
            }
            return clickedButtonTexts;
        }

        // Hàm xử lý sự kiện Click cho mỗi button.
        private void Button_Click(object sender, EventArgs e)
        {
            // Lấy danh sách các Text của button đã có màu cam
            List<string> clickedButtonTexts = GetClickedButtonTexts(this.Controls);

            // Hiển thị các Text của các button đã click
            string result = string.Join(", ", clickedButtonTexts);

            Button clickedButton = sender as Button;

            // Kiểm tra trạng thái màu của button
            if (clickedButton.BackColor == Color.Orange)
            {
                if (totalPrice > 0) totalPrice -= 210000;
                txtTamTinh.Text = totalPrice.ToString("C", obj.nfi);
                // Nếu button đã có màu cam (đã chọn), đổi lại thành màu mặc định
                clickedButton.BackColor = Color.LightCyan;
            }
            else
            {
                totalPrice += 210000;
                txtTamTinh.Text = totalPrice.ToString("C",obj.nfi);
                // Nếu button chưa có màu cam, đổi sang màu cam
                clickedButton.BackColor = Color.Orange;
            }
            
        }
        
        //Hàm update cho các textbox sẽ hiển thị nhung ghế đã chọn
        private void UpdateSelectedSeatsTextBox(TextBox textBox, Control.ControlCollection controls)
        {
            List<string> selectedSeats = new List<string>();

            foreach (Control control in controls)
            {
                if (control is Button button && button.BackColor == Color.Orange)
                {
                    // Thêm Text của button vào danh sách nếu button có màu cam
                    selectedSeats.Add(button.Text);
                }

                // Nếu có các control con, gọi lại đệ quy để tìm thêm các button bên trong
                if (control.HasChildren)
                {
                    UpdateSelectedSeatsTextBox(textBox, control.Controls);
                }
            }

            // Hiển thị danh sách ghế đã chọn vào TextBox
            textBox.Text = string.Join(", ", selectedSeats);
        }


        private void UC_DatVe_Load(object sender, EventArgs e)
        {
            //LOAD database cho các Tuyến
            string sqlstart = "select StartLocation from Route group by StartLocation";
            comboBox_Start.DataSource = obj.GetListOneColumn(sqlstart);

            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = obj.GetListOneColumn(sqlend);
            autosizedgv(dataGridView_TimXe);

        }
        private List<string> disableButtonList(int tripID)
        {
            string sqls = "select SeatNumber from Seat S, DetailsTicket DT Where S.SeatID=DT.SeatID and TRIPID="+tripID.ToString();
            List<string> list = obj.GetListOneColumn(sqls);
            return list;
        }


        private void btnTimChuyenXe_Click(object sender, EventArgs e)
        {
            string datepicker = dateTimePicker_StarDate.Value.ToString("yyyy/MM/dd HH:mm");
            string sqls = "select B.BusID, BusNumber, TotalSeat, BusType,  DepartureTime, ArrivalTime from  Bus B Inner join Trip T on b.BusID=t.BusID WHERE DepartureLocation='" + comboBox_Start.Text.ToString() + "'  AND ArrivalLocation= '" + comboBox_End.Text.ToString() + "' AND DATEDIFF(DAY,T.DepartureTime,'"+ datepicker + "')=0";
            dataGridView_TimXe.DataSource = obj.GetDataTable(sqls);

        }
        private void dataGridView_TimXe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EnableAllSeats(this.Controls);
            string sqlTripID = "  SELECT TripID FROM Trip WHERE DepartureLocation='" + comboBox_Start.Text + "'  AND ArrivalLocation= '" + comboBox_End.Text.ToString() + "'";
            TripID = obj.GetOneID(sqlTripID);
            List<string> list = disableButtonList(TripID);
            DisableButtons(this.Controls, list);
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Số điện thoại!","Lỗi!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtSDT.Focus();
            }
            else
            {
                string today = DateTime.Now.Date.ToString("yyyy/MM/dd");
                Passenger passenger = obj.GetOnePassenger(txtSDT.Text,txtEmail.Text);
                if (passenger.PassengerID == 0)
                {
                    obj.InsertPassenger(txtHoTen.Text, txtSDT.Text, txtEmail.Text);
                    passenger = obj.GetOnePassenger(txtSDT.Text, txtEmail.Text);
                }

                DangNhap dangNhap = new DangNhap();

                //Tạo 1 record mới trong bảng OrderTicket (Tạo và lưu 1 giao dịch mới khi bấm đặt vé)
                obj.InsertOrderTicket(passenger.PassengerID, today, UserID);

                //Lấy ID của giao dịch vừa tạo
                string sqlOrderTicketID = "SELECT MAX(OrderTicketID) from OrderTicket where PassengerID = "+passenger.PassengerID+"";
                int OrderTicketID = obj.GetOneID(sqlOrderTicketID);

                //Lấy TripID
                string sqlTripID = "  SELECT TripID FROM Trip WHERE DepartureLocation='" + comboBox_Start.Text + "'  AND ArrivalLocation= '" + comboBox_End.Text.ToString()+"'";
                int TripID = obj.GetOneID(sqlTripID);

                //Lấy ID của Xe đang chứa ghế được chọn
                int BusID = Convert.ToInt32(dataGridView_TimXe.CurrentRow.Cells[0].Value);

                //Lấy danh sách những ghế được chọn
                List<string> listsGheDaChon = GetClickedButtonTexts(this.Controls);
                foreach(var ghe in listsGheDaChon)
                {
                    //Lấy ID ghế
                    string sqlSeatID = "SELECT SEATID FROM SEAT WHERE SeatNumber='"+ghe+"' AND BusID = '"+BusID+"'";
                    int SeatID = obj.GetOneID(sqlSeatID);

                    obj.InsertDetailsTicket(OrderTicketID,TripID, SeatID, 210000);

                }
                List<string> list = disableButtonList(TripID);
                DisableButtons(this.Controls, list);
                txtTamTinh.Text = string.Empty;
                MessageBox.Show("Đặt vé thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}

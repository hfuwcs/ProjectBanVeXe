using MyLibrary;
using MyLibrary.DTO;
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
using MyLibrary.BLL;
using MyLibrary.DAL;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;
using DoAnCuoiKy.Forms;

namespace DoAnCuoiKy
{
    public partial class UC_DatVe : UserControl
    {
        DbContext db = new DbContext();
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
        private void TimeChange(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker_StarDate.Value;
            DateTime today = DateTime.Today;

            if (startDate < today)
            {
                MessageBox.Show("Ngày đi phải lớn hơn hoặc bằng ngày hiện tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker_StarDate.Value = today;
            }
        }

        public UC_DatVe()
        {
            InitializeComponent();
            RegisterButtonClickEvent(this.Controls);
            TripID = 0;
            totalPrice  = 0;
            //Lấy 2 chữ số thập phân
            db.nfi.CurrencyDecimalDigits = 2;
            dateTimePicker_StarDate.ValueChanged += TimeChange;
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
        private void DisableAllSeats(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button button && (button.Text.StartsWith("A") || button.Text.StartsWith("B")))
                {
                    button.Enabled = false;
                    button.BackColor = Color.Gray;
                }

                // Duyệt đệ quy nếu có các control con
                if (control.HasChildren)
                {
                    DisableAllSeats(control.Controls);
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
                txtTamTinh.Text = totalPrice.ToString("C", db.nfi);
                // Nếu button đã có màu cam (đã chọn), đổi lại thành màu mặc định
                clickedButton.BackColor = Color.LightCyan;
            }
            else
            {
                totalPrice += 210000;
                txtTamTinh.Text = totalPrice.ToString("C", db.nfi);
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
            DisableAllSeats(this.Controls);

            //LOAD database cho các Tuyến
            string sqlstart = "select StartLocation from Route group by StartLocation";
            comboBox_Start.DataSource = db.Instance.ExecuteQuery(sqlstart);
            comboBox_Start.DisplayMember = "StartLocation";

            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = db.Instance.ExecuteQuery(sqlend);
            comboBox_End.DisplayMember = "EndLocation";
            autosizedgv(dataGridView_TimXe);

        }
        private List<string> disableButtonList(int tripID)
        {
            List<string> list = BusBLL.Instance.GetListBookedSeat(tripID);
            return list;
        }

        private DateTime deppDate()
        {
            DateTime selectedday = dateTimePicker_StarDate.Value;
            selectedday = selectedday.Date;// + TimeSpan.Parse(start_hours);
            return selectedday;
        }

        private void btnTimChuyenXe_Click(object sender, EventArgs e)
        {
            totalPrice = 0;
            txtTamTinh.Text = "";
            DateTime selectedday = deppDate();
            string deploc = comboBox_Start.Text;
            string arrloc = comboBox_End.Text;

            DataTable Alreadytrip = TripBLL.Instance.SearchTrip(deploc, arrloc, selectedday);

            if (Alreadytrip.Rows.Count <= 0)
            {
                MessageBox.Show("Không tìm thấy chuyến xe phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dataGridView_TimXe.DataSource = Alreadytrip;
                autosizedgv(dataGridView_TimXe);
            }
        }
        private void dataGridView_TimXe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            totalPrice = 0;
            txtTamTinh.Text = "";
            EnableAllSeats(this.Controls);
            DateTime selectedday = deppDate();
            TripID = db.GetTable<Trip>().Where(t => t._departureLocation.Equals(comboBox_Start.Text) && t._arrivalLocation.Equals(comboBox_End.Text)).Select(t => t.tripID).FirstOrDefault();
            //TripBLL.Instance.GetTripID(comboBox_Start.Text, comboBox_End.Text, selectedday);
            List<string> list = disableButtonList(TripID);
            DisableButtons(this.Controls, list);
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSDT.Text == string.Empty)
                {
                    MessageBox.Show("Bạn phải nhập Số điện thoại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                }
                else
                {
                    string OrderDate = DateTime.Now.Date.ToString("yyyy/MM/dd HH:mm");
                    DateTime selectedDate = deppDate();

                    //Lấy Route để tính giá trên mỗi Distance
                    Route route = RouteBLL.Instance.GetRoute(comboBox_Start.Text, comboBox_End.Text);
                    int price = route.Distance * MyLibrary.Helpers.PricePerKm;

                    Passenger passenger = PassengerBLL.Instance.GetOnePassenger(txtSDT.Text, txtEmail.Text);
                    if (passenger.PassengerID == 0)
                    {
                        PassengerBLL.Instance.InsertPassenger(txtHoTen.Text, txtSDT.Text, txtEmail.Text);
                        passenger = PassengerBLL.Instance.GetOnePassenger(txtSDT.Text, txtEmail.Text);
                    }

                    //Tạo 1 record mới trong bảng OrderTicket (Tạo và lưu giao dịch khi bấm đặt vé)
                    OrderTicketBLL.Instance.InsertOrderTicket(passenger.PassengerID, OrderDate, UserID);

                    //Lấy ID của giao dịch vừa tạo
                    int OrderTicketID = OrderTicketBLL.Instance.GetLatestOrderID(OrderDate, passenger.PassengerID);

                    //Lấy TripID
                    int TripID = TripBLL.Instance.GetTripID(comboBox_Start.Text, comboBox_End.Text, selectedDate);

                    //Lấy ID của Xe đang chứa ghế được chọn
                    int BusID = Convert.ToInt32(dataGridView_TimXe.CurrentRow.Cells[0].Value);

                    //Lấy danh sách những ghế được chọn
                    List<string> listsGheDaChon = GetClickedButtonTexts(this.Controls);
                    foreach (var ghe in listsGheDaChon)
                    {
                        //Lấy ID ghế
                        string sqlSeatID = "SELECT SEATID FROM SEAT WHERE SeatNumber= @seatnumber AND BusID = @busid";
                        int SeatID = db.ExecuteScalar(sqlSeatID, new object[] { ghe, BusID });//obj.GetOneID(sqlSeatID);

                        DetailsTicketBLL.Instance.InsertDetailsTicket(OrderTicketID, TripID, SeatID, 1, price);

                    }
                    List<string> list = disableButtonList(TripID);
                    DisableButtons(this.Controls, list);
                    txtTamTinh.Text = string.Empty;
                    MessageBox.Show("Đặt vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormVeReport formVeReport = new FormVeReport(OrderTicketID);
                    formVeReport.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đặt vé thất bại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(ex.Message);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
             {
                Control ctr = (Control)sender;
                e.Handled = true;
                this.errorProvider1.SetError(ctr, "Bạn phải nhập số điện thoại này đúng định dạng");
                txtSDT.Focus();
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            //if(checkBox1.Checked)
            //{
            //    dateTimePicker_StarDate.Enabled = true;
            //    return;
            //}
            //dateTimePicker_StarDate.Enabled = false;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

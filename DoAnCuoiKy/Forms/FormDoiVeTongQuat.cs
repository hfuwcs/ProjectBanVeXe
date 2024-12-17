using MyLibrary.BLL;
using MyLibrary.DTO;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy.Forms
{
    public partial class FormDoiVeTongQuat : Form
    {
        DbContext db = new DbContext();
        int totalPrice;
        public DangNhap dangNhap;
        private int _userID;
        private int TripID;
        private int PriceOnRoute;
        private string depLoc;
        private string arrLoc;
        private string deppTime;
        private int otid;
        public int UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
            }
        }
        public FormDoiVeTongQuat(int otid, string depLoc, string arrLoc, string deppTime)
        {
            InitializeComponent();
            RegisterButtonClickEvent(this.Controls);
            TripID = 0;
            totalPrice = 0;
            this.depLoc = depLoc;
            this.arrLoc = arrLoc;
            this.deppTime = deppTime;
            this.otid = otid;
            //Lấy 2 chữ số thập phân
            db.nfi.CurrencyDecimalDigits = 2;
            dateTimePicker_StarDate.ValueChanged += TimeChange;
        }
        private void FormDoiVeTongQuat_Load(object sender, EventArgs e)
        {
            DisableAllSeats(this.Controls);

            //LOAD database cho các Tuyến
            string sqlstart = "select StartLocation from Route group by StartLocation";
            comboBox_Start.DataSource = db.Instance.ExecuteQuery(sqlstart);
            comboBox_Start.DisplayMember = "StartLocation";

            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = db.Instance.ExecuteQuery(sqlend);
            comboBox_End.DisplayMember = "EndLocation";

            //Set giá trị mặc định cho các combobox
            comboBox_Start.Text = depLoc;
            comboBox_End.Text = arrLoc;
            dateTimePicker_StarDate.Value = DateTime.Parse(deppTime);
            btnTimChuyenXe_Click(sender, e);
            autosizedgv(dataGridView_TimXe);
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
                if (totalPrice > 0) totalPrice -= PriceOnRoute;
                txtTamTinh.Text = totalPrice.ToString("C", db.nfi);
                // Nếu button đã có màu cam (đã chọn), đổi lại thành màu mặc định
                clickedButton.BackColor = Color.LightCyan;
            }
            else
            {
                totalPrice += PriceOnRoute;
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

        private List<string> disableButtonList(int tripID)
        {
            List<string> list = BusBLL.Instance.GetListBookedSeat(tripID);
            return list;
        }

        private DateTime deppDate()
        {
            DateTime selectedday = dateTimePicker_StarDate.Value;
            selectedday = selectedday.Date;
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
                dataGridView_TimXe.DataSource = Alreadytrip;
                autosizedgv(dataGridView_TimXe);
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

            Route route = RouteBLL.Instance.GetRoute(comboBox_Start.Text, comboBox_End.Text);
            PriceOnRoute = route.Distance * MyLibrary.Helpers.PricePerKm;

            EnableAllSeats(this.Controls);
            DateTime selectedday = deppDate();
            TripID = db.GetTable<Trip>().Where(t => t._departureLocation.Equals(comboBox_Start.Text) && t._arrivalLocation.Equals(comboBox_End.Text)).Select(t => t.tripID).FirstOrDefault();
            //TripBLL.Instance.GetTripID(comboBox_Start.Text, comboBox_End.Text, selectedday);
            List<string> list = disableButtonList(TripID);
            DisableButtons(this.Controls, list);
        }


        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
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

        private void btnDatVe_Click_1(object sender, EventArgs e)
        {
            try
            {
                string sqlSEATID = $"select SeatID from DetailsTicket where TripID = {TripID} AND DetailsTicketID = {otid}";
                int seadid = db.ExecuteScalar(sqlSEATID);
                var selectedSeats = GetClickedButtonTexts(this.Controls);
                int BusID = Convert.ToInt32(dataGridView_TimXe.CurrentRow.Cells[0].Value);
                foreach (var ghe in selectedSeats)
                {
                    //Lấy ID ghế
                    string sqlSeatID = "SELECT SEATID FROM SEAT WHERE SeatNumber= @seatnumber AND BusID = @busid ";
                    int SeatID = db.ExecuteScalar(sqlSeatID, new object[] { ghe, BusID });
                    if(SeatID == seadid)
                    {
                        MessageBox.Show("Không thể đổi ghế đã chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string deppLoc = comboBox_Start.Text;
                    string arrLoc = comboBox_End.Text;
                    string deppTime = dateTimePicker_StarDate.Value.ToString("dd/MM/yyyy HH:mm:ss");
                    if(this.depLoc != deppLoc || this.arrLoc != arrLoc || this.deppTime != deppTime)
                    {
                        DateTime selectedDate = deppDate();
                        int TripID = TripBLL.Instance.GetTripID(comboBox_Start.Text, comboBox_End.Text, selectedDate);
                        int routeID = RouteBLL.Instance.GetRouteID(comboBox_Start.Text, comboBox_End.Text);
                        string sqlUpdate = "UPDATE DetailsTicket SET TripID = @tripid, RouteID = @routeid WHERE DetailsTicketID = @otid ";
                        db.ExecuteNonQuery(sqlUpdate, new object[] { TripID, routeID, otid });
                    }
                    string sqlUpdateSeat = "UPDATE DetailsTicket SET SeatID = @seatid WHERE DetailsTicketID = @otid ";
                    db.ExecuteNonQuery(sqlUpdateSeat, new object[] { SeatID, otid });
                    this.Close();
                }
                MessageBox.Show("Đổi vé thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đổi vé that bai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(ex.Message);
            }
        }
    }
}

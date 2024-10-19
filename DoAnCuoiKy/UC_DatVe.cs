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

namespace DoAnCuoiKy
{
    public partial class UC_DatVe : UserControl
    {
        BanVeXe obj = new BanVeXe();
        int totalPrice;
        public UC_DatVe()
        {
            InitializeComponent();
            RegisterButtonClickEvent(this.Controls);
            totalPrice  = 0;
        }
        // Hàm đệ quy để duyệt qua tất cả các control và vô hiệu hóa các button có Text nằm trong valuesToDisable.
        // valuesToDisable là list các ghế đã được đặt của chuyến xe đó
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

        // Gán sự kiện Click cho tất cả các button trong form.
        private void RegisterButtonClickEvent(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
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

        // Hàm xử lý sự kiện Click cho mỗi button.
        private void Button_Click(object sender, EventArgs e)
        {
            // Lấy danh sách các Text của button đã có màu cam
            List<string> clickedButtonTexts = GetClickedButtonTexts(this.Controls);

            // Hiển thị các Text của các button đã click
            string result = string.Join(", ", clickedButtonTexts);
            txtGheDaChon.Text = string.Empty;

            Button clickedButton = sender as Button;

            // Kiểm tra trạng thái màu của button
            if (clickedButton.BackColor == Color.Orange)
            {
                txtGheDaChon.Text += result;
                if (totalPrice > 0) totalPrice -= 20000;
                txtTamTinh.Text = totalPrice.ToString();
                // Nếu button đã có màu cam (đã chọn), đổi lại thành màu mặc định
                clickedButton.BackColor = Color.LightCyan;
            }
            else
            {
                totalPrice += 20000;
                txtTamTinh.Text = totalPrice.ToString();
                txtGheDaChon.Text += result;
                // Nếu button chưa có màu cam, đổi sang màu cam
                clickedButton.BackColor = Color.Orange;
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
        //Hàm update cho các textbox sẽ hiển thị nhưng ghế đã chọn
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
            //START: LOAD database cho Tuyen
            BanVeXe db1 = new BanVeXe();
            string sqls1 = "select StartLocation from Route group by StartLocation";
            string tableName1 = "Route";
            db1.GetDataAdapter(sqls1, tableName1);

            comboBox_Start.DataSource = db1.DataSet.Tables[0];
            comboBox_Start.ValueMember = "StartLocation";
            comboBox_Start.DisplayMember = "StartLocation";

            BanVeXe db2 = new BanVeXe();
            string sqls2 = "select EndLocation from Route group by EndLocation";
            string tableName2 = "Route";
            db2.GetDataAdapter(sqls2, tableName2);

            comboBox_End.DataSource = db2.DataSet.Tables[0];
            comboBox_End.ValueMember = "EndLocation";
            comboBox_End.DisplayMember = "EndLocation";
            //END: LOAD database cho Tuyen


        }
        private List<string> disableButtonList()
        {
            string sqls = "select SeatNumber from Seat S, DetailsTicket DT Where S.SeatID=DT.SeatID and TRIPID=1";
            List<string> list = obj.GetListOneColumn(sqls);
            return list;
        }


        private void btnTimChuyenXe_Click(object sender, EventArgs e)
        {
            btnTimChuyenXe.BackColor = Color.White;
            string datepicker = dateTimePicker_StarDate.Value.ToString("yyyy/MM/dd HH:mm");
            string sqls = "select B.BusID, BusNumber, TotalSeat, BusType,  DepartureTime, ArrivalTime from  Bus B Inner join Trip T on b.BusID=t.BusID WHERE DepartureLocation='" + comboBox_Start.Text.ToString() + "'  AND ArrivalLocation= '" + comboBox_End.Text.ToString() + "' AND DATEDIFF(DAY,T.DepartureTime,'"+ datepicker + "')=0";
            dataGridView_TimXe.DataSource = obj.GetDataTable(sqls);
        }

        private void comboBox_Start_TextChanged(object sender, EventArgs e)
        {
        }
        private void dataGridView_TimXe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> list = disableButtonList();
            DisableButtons(this.Controls, list);

        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text == string.Empty)
            {
                MessageBox.Show("Ban phai nhap sdt");
                txtSDT.Focus();
            }
            else
            {
                string today = DateTime.Now.Date.ToString("yyyy/MM/dd");
                Passenger passenger = obj.GetOnePassenger(txtSDT.Text,txtEmail.Text);
                //if(passenger.PassengerID == 0)
                //{
                //    obj.InsertPassenger(txtHoTen.Text, txtSDT.Text, txtEmail.Text);
                //}

                //Tạo 1 record mới trong bảng OrderTicket (Tạo và lưu 1 giao dịch mới khi bấm đặt vé)
                obj.InsertOrderTicket(passenger.PassengerID, today);

                //Lấy ID của giao dịch vừa tạo
                string sqlOrderTicketID = "SELECT MAX(OrderTicketID) from OrderTicket where PassengerID = "+passenger.PassengerID+"";
                int OrderTicketID = obj.GetOneID(sqlOrderTicketID);

                //Lấy TripID
                string sqlTripID = "  SELECT TripID FROM Trip WHERE DepartureLocation='" + comboBox_Start.Text + "'  AND ArrivalLocation= '" + comboBox_End.Text.ToString()+"'";
                int TripID = obj.GetOneID(sqlTripID);


                //Lấy ID của Xe đang chứa ghế được chọn
                int BusID = Convert.ToInt32(dataGridView_TimXe.CurrentRow.Cells[0].Value);


                int totalPrice = 0;


                //Lấy danh sách những ghế được chọn
                List<string> listsGheDaChon = GetClickedButtonTexts(this.Controls);
                foreach(var ghe in listsGheDaChon)
                {
                    //Lấy ID ghế
                    string sqlSeatID = "SELECT SEATID FROM SEAT WHERE SeatNumber='"+ghe+"' AND BusID = '"+BusID+"'";
                    int SeatID = obj.GetOneID(sqlSeatID);

                    obj.InsertDetailsTicket(OrderTicketID,TripID, SeatID, 20000);
                    totalPrice += 20000;

                }
                List<string> list = disableButtonList();
                DisableButtons(this.Controls, list);
                totalPrice = 0;
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int BusID = Convert.ToInt32(dataGridView_TimXe.CurrentRow.Cells[0].Value);
            MessageBox.Show(BusID.ToString());
        }
    }
}

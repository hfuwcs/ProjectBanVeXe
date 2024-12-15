using MyLibrary;
using MyLibrary.DTO;
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
    public partial class UC_QuanLyKhachHang : UserControl
    {
        DbContext db = new DbContext();
        public UC_QuanLyKhachHang()
        {
            InitializeComponent();
        }
        private void autosizedgv(object sender)
        {
            DataGridView dataGridView = sender as DataGridView;
            // Set your desired AutoSize Mode:
            dataGridView.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            // Now that DataGridView has calculated it's Widths; we can now store each
            // column Width values.
            for (int i = 0; i <= dataGridView.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = dataGridView.Columns[i].Width;

                // Remove AutoSizing:
                dataGridView.Columns[i].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                dataGridView.Columns[i].Width = colw;
            }
        }

        private void UC_QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            string sqls =
                @"
                             SELECT 
                                 p.PassengerID AS [Mã khách hàng],
                                 p.FullName AS [Họ và tên], 
                                 p.PhoneNumber AS [Số điện thoại], 
                                 p.Email AS [Email], 
                                 COUNT(dt.DetailsTicketID) AS [Số vé đã đặt],
                                 ISNULL(SUM(dt.Price), 0) AS [Số tiền đã mua vé]
                             FROM Passenger p
                             LEFT JOIN OrderTicket ot ON p.PassengerID = ot.PassengerID
                             LEFT JOIN DetailsTicket dt ON ot.OrderTicketID = dt.OrderTicketID
                             GROUP BY p.PassengerID, p.FullName, p.PhoneNumber, p.Email;
                            ";
            dataGridViewQuanLyKH.DataSource = db.GetDataTable(sqls);
            autosizedgv(dataGridViewQuanLyKH);
            // Cập nhật giá trị vào TextBox
            txtFullName.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            btnTimKiem.Enabled = true;
            btnCapNhat.Enabled = false;
            LoadTicketByPassengerID(0);
        }

        private void dataGridViewQuanLyKH_CellClick(object sender,
                                                    DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng không click vào tiêu đề cột
            if (e.RowIndex >= 0)
            {
                // Lấy dòng đã chọn
                DataGridViewRow row = dataGridViewQuanLyKH.Rows[e.RowIndex];

                // Cập nhật giá trị vào TextBox
                txtFullName.Text = row.Cells["Họ và tên"].Value.ToString();
                txtPhoneNumber.Text = row.Cells["Số điện thoại"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                try
                {
                    string selectedPassengerID = dataGridViewQuanLyKH.SelectedRows[0]
                                                     .Cells["Mã khách hàng"]
                                                     .Value.ToString();
                    int passengerID = Convert.ToInt32(selectedPassengerID);
                    LoadTicketByPassengerID(passengerID);
                    btnTimKiem.Enabled = false;
                    btnCapNhat.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng !");
                    UC_QuanLyKhachHang_Load(sender, e);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox
            string fullName = txtFullName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            // Kiểm tra định dạng số điện thoại
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 số và bắt đầu bằng số 0!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra định dạng email
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Lấy dòng được chọn trong DataGridView
            if (dataGridViewQuanLyKH.SelectedRows.Count > 0)
            {
                // Lấy PassengerID của khách hàng từ hàng được chọn
                string selectedPassengerID = dataGridViewQuanLyKH.SelectedRows[0]
                                                 .Cells["Mã khách hàng"]
                                                 .Value.ToString();
                int passengerID = Convert.ToInt32(selectedPassengerID);

                // Kiểm tra trùng số điện thoại
                string sqlCheckPhone =
                    $@"
            SELECT COUNT(*) 
            FROM Passenger 
            WHERE PhoneNumber = '{phoneNumber}' AND PassengerID != {passengerID}";

                // Kiểm tra trùng email
                string sqlCheckEmail =
                    $@"
            SELECT COUNT(*) 
            FROM Passenger 
            WHERE Email = '{email}' AND PassengerID != {passengerID}";

                try
                {
                    // Thực thi truy vấn kiểm tra
                    int phoneCount = Convert.ToInt32(db.ExecuteScalar(sqlCheckPhone));
                    int emailCount = Convert.ToInt32(db.ExecuteScalar(sqlCheckEmail));

                    if (phoneCount > 0)
                    {
                        MessageBox.Show("Số điện thoại đã tồn tại. Vui lòng nhập số khác.",
                                        "Thông báo");
                        return;
                    }

                    if (emailCount > 0)
                    {
                        MessageBox.Show("Email đã tồn tại. Vui lòng nhập email khác.",
                                        "Thông báo");
                        return;
                    }

                    // Câu lệnh SQL để cập nhật thông tin
                    string sqlUpdate =
                        $@"
                UPDATE Passenger
                SET 
                    FullName = '{fullName}', 
                    PhoneNumber = '{phoneNumber}', 
                    Email = '{email}'
                WHERE PassengerID = {passengerID}";

                    // Gọi phương thức thực thi SQL từ DbContext
                    db.ExecuteNonQuery(sqlUpdate);  // Giả sử bạn có phương thức
                                                    // ExecuteNonQuery trong DbContext
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");

                    // Làm mới DataGridView sau khi cập nhật
                    UC_QuanLyKhachHang_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Thông báo lỗi");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng trong danh sách để cập nhật.",
                                "Thông báo");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các TextBox
            string fullName = txtFullName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Tạo điều kiện tìm kiếm
            string whereClause = "WHERE 1=1";
            if (!string.IsNullOrEmpty(fullName))
            {
                whereClause += $@"
        AND p.FullName COLLATE SQL_Latin1_General_CP1_CI_AI LIKE N'%{fullName}%'";
            }
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                whereClause += $@"
        AND p.PhoneNumber COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%{phoneNumber}%'";
            }
            if (!string.IsNullOrEmpty(email))
            {
                whereClause += $@"
        AND p.Email COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%{email}%'";
            }


            // Truy vấn SQL
            string sql =
                $@"
        SELECT 
            p.PassengerID AS [Mã khách hàng],
            p.FullName AS [Họ và tên], 
            p.PhoneNumber AS [Số điện thoại], 
            p.Email AS [Email], 
            COUNT(dt.DetailsTicketID) AS [Số vé đã đặt],
            ISNULL(SUM(dt.Price), 0) AS [Số tiền đã dùng]
        FROM Passenger p
        LEFT JOIN OrderTicket ot ON p.PassengerID = ot.PassengerID
        LEFT JOIN DetailsTicket dt ON ot.OrderTicketID = dt.OrderTicketID
        {whereClause}
        GROUP BY p.PassengerID, p.FullName, p.PhoneNumber, p.Email;
    ";

            // Lấy kết quả từ cơ sở dữ liệu
            DataTable result = db.GetDataTable(sql);

            // Kiểm tra kết quả
            if (result.Rows.Count > 0)
            {
                // Hiển thị kết quả trong DataGridView
                dataGridViewQuanLyKH.DataSource = result;
            }
            else
            {
                // Hiển thị thông báo nếu không tìm thấy
                MessageBox.Show("Không tìm thấy ai phù hợp!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadTicketByPassengerID(int passengerID)
        {
            string sqls =
                $@"
                                    SELECT 
                                        dt.DetailsTicketID AS [Mã Vé],
                                        p.PassengerID AS [Mã khách hàng],
                                        p.FullName AS [Họ và tên], 
                                        p.PhoneNumber AS [Số điện thoại], 
                                        r.RouteName AS [Tên Tuyến Đường], 
                                        t.DepartureLocation AS [Nơi Đi], 
                                        t.ArrivalLocation AS [Nơi Đến], 
                                        t.DepartureTime AS [Giờ Khởi Hành], 
                                        t.ArrivalTime AS [Giờ Đến], 
                                        b.BusNumber AS [Số Xe], 
                                        s.SeatNumber AS [Số Ghế], 
                                        dt.Price AS [Giá Vé], 
                                        ua.FullName AS [Tên Nhân Viên], 
                                        ot.OrderDate AS [Ngày Bán]
                                    FROM DetailsTicket dt
                                    JOIN OrderTicket ot ON dt.OrderTicketID = ot.OrderTicketID
                                    JOIN Passenger p ON ot.PassengerID = p.PassengerID
                                    JOIN Trip t ON dt.TripID = t.TripID
                                    JOIN Route r ON t.RouteID = r.RouteID
                                    JOIN Bus b ON t.BusID = b.BusID
                                    JOIN Seat s ON dt.SeatID = s.SeatID
                                    JOIN UserAccount ua ON ot.UserID = ua.UserID
                                    WHERE p.PassengerID = N'{passengerID}';
                                    ";

            // Thực thi truy vấn và hiển thị kết quả
            DataTable tickets = db.GetDataTable(sqls);

            dataGridView2.DataSource = tickets;
        }

        private void txtFullName_Click(object sender, EventArgs e) { }
    }
}

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
    public partial class UC_QuanLyTaiXe : UserControl
    {
        DbContext db = new DbContext();
        public UC_QuanLyTaiXe()
        {
            InitializeComponent();
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
        private void dataGridViewQuanLyTX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng không click vào tiêu đề cột
            if (e.RowIndex >= 0)
            {
                // Lấy dòng đã chọn
                DataGridViewRow row = dataGridViewQuanLyTX.Rows[e.RowIndex];

                // Cập nhật giá trị vào TextBox
                txtFullName.Text = row.Cells["Họ và tên"].Value.ToString();
                txtPhoneNumber.Text = row.Cells["Số điện thoại"].Value.ToString();
                txtLicenseNumber.Text = row.Cells["Giấy phép lái xe"].Value.ToString();
                // Lấy DriverID từ hàng được chọn
                int driverID = Convert.ToInt32(row.Cells["ID"].Value);

                // Hiển thị danh sách chuyến
                LoadDriverTrips(driverID);
            }
            
        }
        private void UC_QuanLyTaiXe_Load(object sender, EventArgs e)
        {
            string sqls = @"
                 SELECT 
                     d.DriverID AS [ID],
                     d.FullName AS [Họ và tên], 
                     d.PhoneNumber AS [Số điện thoại], 
                     d.LicenseNumber AS [Giấy phép lái xe], 
                     COUNT(t.TripID) AS [Số chuyến đã chạy]
                 FROM Driver d
                 LEFT JOIN Trip t ON d.DriverID = t.DriverID
                 GROUP BY d.DriverID, d.FullName, d.PhoneNumber, d.LicenseNumber
                ";
            dataGridViewQuanLyTX.DataSource = db.GetDataTable(sqls);
            autosizedgv(dataGridViewQuanLyTX);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ TextBox
            string fullName = txtFullName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string licenseNumber = txtLicenseNumber.Text.Trim();

            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(licenseNumber))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Câu lệnh SQL để thêm tài xế mới
            string sqlInsert = $@"
        INSERT INTO Driver (FullName, PhoneNumber, LicenseNumber) 
        VALUES (N'{fullName}', '{phoneNumber}', '{licenseNumber}')
    ";

            try
            {
                // Thực thi câu lệnh SQL
                db.ExecuteNonQuery(sqlInsert);

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm tài xế thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu lên DataGridView
                string sqls = @"
            SELECT 
                d.DriverID AS [ID],
                d.FullName AS [Họ và tên], 
                d.PhoneNumber AS [Số điện thoại], 
                d.LicenseNumber AS [Giấy phép lái xe], 
                COUNT(t.TripID) AS [Số chuyến đã chạy]
            FROM Driver d
            LEFT JOIN Trip t ON d.DriverID = t.DriverID
            GROUP BY d.DriverID, d.FullName, d.PhoneNumber, d.LicenseNumber
        ";
                dataGridViewQuanLyTX.DataSource = db.GetDataTable(sqls);
                autosizedgv(dataGridViewQuanLyTX);

                // Xóa nội dung các TextBox sau khi thêm
                txtFullName.Clear();
                txtPhoneNumber.Clear();
                txtLicenseNumber.Clear();
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu thêm thất bại
                MessageBox.Show($"Lỗi khi thêm tài xế: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox
            string fullName = txtFullName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string licenseNumber = txtLicenseNumber.Text;

            // Lấy dòng được chọn trong DataGridView
            if (dataGridViewQuanLyTX.SelectedRows.Count > 0)
            {
                // Lấy PassengerID của khách hàng từ hàng được chọn
                string selectedFullName = dataGridViewQuanLyTX.SelectedRows[0].Cells["Họ và tên"].Value.ToString();

                // Câu lệnh SQL để cập nhật thông tin
                string sqlUpdate = $@"
            UPDATE Driver
            SET 
                FullName = '{fullName}', 
                PhoneNumber = '{phoneNumber}', 
                LicenseNumber = '{licenseNumber}'
            WHERE FullName = '{selectedFullName}'";

                // Gọi phương thức thực thi SQL từ DbContext
                try
                {
                    db.ExecuteNonQuery(sqlUpdate); // Giả sử bạn có phương thức ExecuteNonQuery trong DbContext
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");

                    // Làm mới DataGridView sau khi cập nhật
                    UC_QuanLyTaiXe_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Thông báo lỗi");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng trong danh sách để cập nhật.", "Thông báo");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các TextBox
            string fullName = txtFullName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string licenseNumber = txtLicenseNumber.Text.Trim();

            // Tạo điều kiện tìm kiếm
            string whereClause = "WHERE 1=1";
            if (!string.IsNullOrEmpty(fullName))
            {
                whereClause += $" AND d.FullName LIKE N'%{fullName}%'";
            }
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                whereClause += $" AND d.PhoneNumber LIKE '%{phoneNumber}%'";
            }
            if (!string.IsNullOrEmpty(licenseNumber))
            {
                whereClause += $" AND d.LicenseNumber LIKE '%{licenseNumber}%'";
            }

            // Truy vấn SQL
            string sql = $@"
        SELECT 
                d.DriverID AS [ID],
                d.FullName AS [Họ và tên], 
                d.PhoneNumber AS [Số điện thoại], 
                d.LicenseNumber AS [Giấy phép lái xe], 
                COUNT(t.TripID) AS [Số chuyến đã chạy]
            FROM Driver d
        LEFT JOIN Trip t ON d.DriverID = t.DriverID
        {whereClause}
        GROUP BY d.DriverID, d.FullName, d.PhoneNumber, d.LicenseNumber    ";


            // Lấy kết quả từ cơ sở dữ liệu
            DataTable result = db.GetDataTable(sql);

            // Kiểm tra kết quả
            if (result.Rows.Count > 0)
            {
                // Hiển thị kết quả trong DataGridView
                dataGridViewQuanLyTX.DataSource = result;
            }
            else
            {
                // Hiển thị thông báo nếu không tìm thấy
                MessageBox.Show("Không tìm thấy ai phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LoadDriverTrips(int driverID)
        {
            string sqlTrips = $@"
                                SELECT 
                                    t.TripID AS [Mã chuyến],
                                    t.DepartureLocation AS [Điểm bắt đầu],
                                    t.ArrivalLocation AS [Điểm kết thúc],
                                    t.DepartureTime AS [Thời gian bắt đầu],
                                    t.ArrivalTime AS [Thời gian kết thúc],
                                    r.RouteName AS [Tuyến],
                                    b.BusNumber AS [Biển số xe],
                                    b.BusType AS [Loại xe]
                                FROM Trip t
                                LEFT JOIN Route r ON t.RouteID = r.RouteID
                                LEFT JOIN Bus b ON t.BusID = b.BusID
                                WHERE t.DriverID = {driverID}";

            try
            {
                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable trips = db.GetDataTable(sqlTrips);

                // Hiển thị dữ liệu trong DataGridViewTripList
                dataGridView2.DataSource = trips;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách chuyến: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

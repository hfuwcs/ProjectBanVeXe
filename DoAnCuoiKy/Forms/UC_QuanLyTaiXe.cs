using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DoAnCuoiKy.Forms
{
    public partial class UC_QuanLyTaiXe : UserControl
    {
        DbContext db = new DbContext();
        private int _driverID;
        public UC_QuanLyTaiXe()
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
        private void dataGridViewQuanLyTX_CellClick(object sender,
                                                    DataGridViewCellEventArgs e)
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
                try
                {
                    int driverID = Convert.ToInt32(row.Cells["ID của tài xế "].Value);
                    _driverID = driverID;
                    // Hiển thị danh sách chuyến
                    LoadDriverTrips(driverID);
                    btnThem.Enabled = false;
                    btnTimKiem.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng chọn tuyến !");
                    UC_QuanLyTaiXe_Load(sender, e);
                }
                btnXoa.Enabled = true;
                btnCapNhat.Enabled = true;
                btnLoc.Enabled = true;
                btnLoad.Enabled = true;
            }
        }
        private void UC_QuanLyTaiXe_Load(object sender, EventArgs e)
        {
            string sqls =
                @"
                 SELECT 
                     d.DriverID AS [ID của tài xế ],
                     d.FullName AS [Họ và tên], 
                     d.PhoneNumber AS [Số điện thoại], 
                     d.LicenseNumber AS [Giấy phép lái xe], 
                     COUNT(t.TripID) AS [Số chuyến xe]
                 FROM Driver d
                 LEFT JOIN Trip t ON d.DriverID = t.DriverID
                 GROUP BY d.DriverID, d.FullName, d.PhoneNumber, d.LicenseNumber
                ";
            dataGridViewQuanLyTX.DataSource = db.GetDataTable(sqls);
            autosizedgv(dataGridViewQuanLyTX);
            // Cập nhật giá trị vào TextBox
            txtFullName.Text = "";
            txtPhoneNumber.Text = "";
            txtLicenseNumber.Text = "";
            //
            btnLoad.Enabled = false;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnLoc.Enabled = false;
            btnThem.Enabled = true;
            btnTimKiem.Enabled = true;
            LoadDriverTrips(0);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ TextBox
            string fullName = txtFullName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string licenseNumber = txtLicenseNumber.Text.Trim();

            // Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phoneNumber) ||
                string.IsNullOrEmpty(licenseNumber))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số điện thoại
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 số và bắt đầu bằng số 0!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng giấy phép lái xe
            if (!System.Text.RegularExpressions.Regex.IsMatch(licenseNumber, @"^\d{12}$"))
            {
                MessageBox.Show("Giấy phép lái xe phải có 12 số!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem số điện thoại và giấy phép lái xe đã tồn tại chưa
            string sqlCheck = $@"
        SELECT COUNT(*) 
        FROM Driver 
        WHERE PhoneNumber = '{phoneNumber}' OR LicenseNumber = '{licenseNumber}'
    ";

            try
            {
                int existingCount = (int)db.ExecuteScalar(sqlCheck);

                if (existingCount > 0)
                {
                    MessageBox.Show("Số điện thoại hoặc giấy phép lái xe đã tồn tại!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Câu lệnh SQL để thêm tài xế mới
                string sqlInsert = $@"
            INSERT INTO Driver (FullName, PhoneNumber, LicenseNumber) 
            VALUES (N'{fullName}', '{phoneNumber}', '{licenseNumber}')
        ";

                // Thực thi câu lệnh SQL
                db.ExecuteNonQuery(sqlInsert);

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm tài xế thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu lên DataGridView
                UC_QuanLyTaiXe_Load(sender, e);

                // Xóa nội dung các TextBox sau khi thêm
                txtFullName.Clear();
                txtPhoneNumber.Clear();
                txtLicenseNumber.Clear();
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu thêm thất bại
                MessageBox.Show($"Lỗi khi thêm tài xế: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox
            string fullName = txtFullName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string licenseNumber = txtLicenseNumber.Text.Trim();

            // Kiểm tra dữ liệu rỗng
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(licenseNumber))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng số điện thoại
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^0\d{9}$"))
            {
                MessageBox.Show("Số điện thoại phải có 10 số và bắt đầu bằng số 0!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra định dạng giấy phép lái xe
            if (!System.Text.RegularExpressions.Regex.IsMatch(licenseNumber, @"^\d{12}$"))
            {
                MessageBox.Show("Giấy phép lái xe phải có 12 số!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra dòng được chọn trong DataGridView
            if (dataGridViewQuanLyTX.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một tài xế để cập nhật!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            // Kiểm tra xem số điện thoại và giấy phép lái xe đã tồn tại chưa
            string sqlCheck = $@"
        SELECT COUNT(*) 
        FROM Driver 
        WHERE (PhoneNumber = '{phoneNumber}' OR LicenseNumber = '{licenseNumber}')
          AND DriverID != {_driverID}
    ";

            int existingCount = (int)db.ExecuteScalar(sqlCheck);
            if (existingCount > 0)
            {
                MessageBox.Show("Số điện thoại hoặc giấy phép lái xe đã tồn tại!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Câu lệnh SQL để cập nhật thông tin
            string sqlUpdate = $@"
        UPDATE Driver
        SET 
            FullName = '{fullName}', 
            PhoneNumber = '{phoneNumber}', 
            LicenseNumber = '{licenseNumber}'
        WHERE DriverID = {_driverID}
    ";

            try
            {
                db.ExecuteNonQuery(sqlUpdate);

                // Thông báo cập nhật thành công
                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới DataGridView sau khi cập nhật
                UC_QuanLyTaiXe_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Thông báo lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các TextBox
            string fullName = txtFullName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string licenseNumber = txtLicenseNumber.Text.Trim();

            // Tạo điều kiện tìm kiếm
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
            if (!string.IsNullOrEmpty(licenseNumber))
            {
                whereClause += $@"
        AND p.Email COLLATE SQL_Latin1_General_CP1_CI_AI LIKE '%{licenseNumber}%'";
            }


            // Truy vấn SQL
            string sql =
                $@"
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
                MessageBox.Show("Không tìm thấy ai phù hợp!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LoadDriverTrips(int driverID)
        {
            string sqlTrips =
                $@"
                                SELECT 
                                    t.DriverID AS [ID của tài xế ],
                                    t.TripID AS [Mã chuyến],
                                    t.DepartureLocation AS [Điểm bắt đầu],
                                    t.ArrivalLocation AS [Điểm kết thúc],
                                    t.DepartureTime AS [Thời gian bắt đầu],
                                    t.ArrivalTime AS [Thời gian kết thúc],
                                    r.RouteName AS [Tuyến],
                                    b.BusID AS [Mã xe],
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
                MessageBox.Show($"Lỗi khi tải danh sách chuyến: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDriverTripsByDiverID(int driverID)
        {
            // Lấy giá trị ngày bắt đầu và ngày kết thúc
            DateTime startDate = dateTimePicker_StartDate.Value.Date;
            DateTime endDate = dateTimePicker_EndDate.Value.Date;

            // Kiểm tra ngày kết thúc không được nhỏ hơn ngày bắt đầu
            if (endDate < startDate)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string startDay = dateTimePicker_StartDate.Value.ToString("yyyy/MM/dd");
            DateTime endOfDay =
                dateTimePicker_EndDate.Value.Date.AddDays(1).AddSeconds(-1);
            string endDay = endOfDay.ToString("yyyy/MM/dd HH:mm:ss");
            string sqlTrips =
                $@"
                                SELECT 
                                    t.DriverID AS [ID của tài xế ],
                                    t.TripID AS [Mã chuyến],
                                    t.DepartureLocation AS [Điểm bắt đầu],
                                    t.ArrivalLocation AS [Điểm kết thúc],
                                    t.DepartureTime AS [Thời gian bắt đầu],
                                    t.ArrivalTime AS [Thời gian kết thúc],
                                    r.RouteName AS [Tuyến],
                                    b.BusID AS [Mã xe],
                                    b.BusNumber AS [Biển số xe],
                                    b.BusType AS [Loại xe]
                                FROM Trip t
                                LEFT JOIN Route r ON t.RouteID = r.RouteID
                                LEFT JOIN Bus b ON t.BusID = b.BusID
                                WHERE t.DepartureTime >= '{startDay}' AND t.DepartureTime <= '{endDay}' AND t.DriverID = {driverID} ";
            try
            {
                // Lấy dữ liệu từ cơ sở dữ liệu
                DataTable trips = db.GetDataTable(sqlTrips);

                // Hiển thị dữ liệu trong DataGridViewTripList
                dataGridView2.DataSource = trips;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách chuyến: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadDriverTripsByDiverID(_driverID);
        }

        private void txtFullName_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLoc.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn hay không
            if (_driverID <= 0)
            {
                MessageBox.Show("Vui lòng chọn tài xế để xóa!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tài xế có chuyến hay không
            string sqlCheckTrips =
                $@"
        SELECT COUNT(*) 
        FROM Trip 
        WHERE DriverID = {_driverID}";

            try
            {
                int tripCount = (int)db.ExecuteScalar(sqlCheckTrips);

                if (tripCount > 0)
                {
                    // Nếu tài xế có chuyến, thông báo lỗi
                    MessageBox.Show("Tài xế hiện có chuyến. Không thể xóa!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Nếu tài xế không có chuyến, tiến hành xóa
                    string sqlDeleteDriver =
                        $@"
                DELETE FROM Driver 
                WHERE DriverID = {_driverID}";

                    db.ExecuteNonQuery(sqlDeleteDriver);

                    // Hiển thị thông báo xóa thành công
                    MessageBox.Show("Xóa tài xế thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới danh sách
                    UC_QuanLyTaiXe_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có
                MessageBox.Show($"Lỗi khi xóa tài xế: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

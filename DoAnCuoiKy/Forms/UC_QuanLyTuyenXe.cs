using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy.Forms
{
    public partial class UC_QuanLyTuyenXe : UserControl
    {
        DbContext db = new DbContext();
        public UC_QuanLyTuyenXe()
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
        private void UC_QuanLyTuyenXe_Load(object sender, EventArgs e)
        {
            string sqls =
                @"
                             SELECT 
                                 rt.RouteID AS [Mã tuyến], 
                                 rt.RouteName AS [Tên tuyến], 
                                 rt.StartLocation AS [Điểm bắt đầu], 
                                 rt.EndLocation AS [Điểm kết thúc], 
                                 rt.Distance AS [Khoảng cách],
                                 COUNT(t.TripID) AS [Số chuyến]
                                FROM Route rt
                                LEFT JOIN Trip t ON rt.RouteID = t.RouteID
                                GROUP BY 
                                    rt.RouteID, 
                                    rt.RouteName, 
                                    rt.StartLocation, 
                                    rt.EndLocation, 
                                    rt.Distance";
            dataGridViewQuanLyTuyenXe.DataSource = db.GetDataTable(sqls);
            autosizedgv(dataGridViewQuanLyTuyenXe);
            // Cập nhật giá trị vào TextBox
            txtStartLoc.Text = "";
            txtEndLoc.Text = "";
            txtDistance.Text = "";
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnCapNhat.Enabled = false;
            btnLoad.Enabled = false;

            LoadRouteTrips(0);
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox
            string startLoc = txtStartLoc.Text;
            string endLoc = txtEndLoc.Text;
            string distance = txtDistance.Text;
            // Kiểm tra nếu địa điểm bắt đầu và kết thúc đã tồn tại
            string sqlCheckRoute =
                $@"
                              SELECT COUNT(*) 
                              FROM Route 
                              WHERE StartLocation = '{startLoc}' AND EndLocation = '{endLoc}'";

            try
            {
                int count = (int)db.ExecuteScalar(sqlCheckRoute);

                if (count > 0)
                {
                    MessageBox.Show("Tuyến này đã tồn tại!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Lấy dòng được chọn trong DataGridView
                    if (dataGridViewQuanLyTuyenXe.SelectedRows.Count > 0)
                    {
                        string selectedRouteID = dataGridViewQuanLyTuyenXe.SelectedRows[0]
                                                     .Cells["Mã tuyến"]
                                                     .Value.ToString();
                        int routeID = Convert.ToInt32(selectedRouteID);
                        // Câu lệnh SQL để cập nhật thông tin
                        string sqlUpdate =
                            $@"
            UPDATE Route
            SET 
                RouteName = '{startLoc} - {endLoc}',
                StartLocation = '{startLoc}', 
                EndLocation = '{endLoc}', 
                Distance = '{distance}'
            WHERE RouteID = '{routeID}'";

                        // Gọi phương thức thực thi SQL từ DbContext
                        try
                        {
                            db.ExecuteNonQuery(sqlUpdate);  // Giả sử bạn có phương thức
                                                            // ExecuteNonQuery trong DbContext
                            MessageBox.Show("Cập nhật thành công!", "Thông báo");

                            // Làm mới DataGridView sau khi cập nhật
                            UC_QuanLyTuyenXe_Load(sender, e);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi cập nhật: " + ex.Message,
                                            "Thông báo lỗi");
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Vui lòng chọn một hàng trong danh sách để cập nhật.",
                            "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhập: " + ex.Message, "Thông báo lỗi");
            }
        }

        private void dataGridViewQuanLyTuyenXe_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng không click vào tiêu đề cột
            if (e.RowIndex >= 0)
            {
                // Lấy dòng đã chọn
                DataGridViewRow row = dataGridViewQuanLyTuyenXe.Rows[e.RowIndex];

                // Cập nhật giá trị vào TextBox
                txtStartLoc.Text = row.Cells["Điểm bắt đầu"].Value.ToString();
                txtEndLoc.Text = row.Cells["Điểm kết thúc"].Value.ToString();
                txtDistance.Text = row.Cells["Khoảng cách"].Value.ToString();
                // Lấy RouteID của tuyến được chọn
                try
                {
                    int routeID = Convert.ToInt32(row.Cells["Mã tuyến"].Value);
                    LoadRouteTrips(routeID);
                    btnThem.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng chọn tuyến !");
                    UC_QuanLyTuyenXe_Load(sender, e);
                }
                btnXoa.Enabled = true;
                btnCapNhat.Enabled = true;
                btnLoad.Enabled = true;
            }
        }
        private void LoadRouteTrips(int routeID)
        {
            string sqlTrips =
                $@"
                                SELECT 
                                    r.RouteID AS [Mã tuyến],
                                    r.RouteName AS [Tuyến],     
                                    t.TripID AS [Mã chuyến],
                                    t.DepartureLocation AS [Điểm bắt đầu],
                                    t.ArrivalLocation AS [Điểm kết thúc],
                                    t.DepartureTime AS [Thời gian bắt đầu],
                                    t.ArrivalTime AS [Thời gian kết thúc],
                                    b.BusID AS [Mã xe],
                                    b.BusNumber AS [Biển số xe],
                                    b.BusType AS [Loại xe]
                                FROM Trip t
                                LEFT JOIN Route r ON t.RouteID = r.RouteID
                                LEFT JOIN Bus b ON t.BusID = b.BusID
                                WHERE t.RouteID = {routeID}";

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewQuanLyTuyenXe.SelectedRows.Count > 0)
            {
                string selectedRouteID = dataGridViewQuanLyTuyenXe.SelectedRows[0]
                                             .Cells["Mã tuyến"]
                                             .Value.ToString();

                // Kiểm tra số lượng chuyến liên kết với tuyến
                string sqlCheckTrips =
                    $@"
                                         SELECT COUNT(*) 
                                         FROM Trip 
                                         WHERE RouteID = {selectedRouteID}
                                        ";

                try
                {
                    int tripCount = (int)db.ExecuteScalar(sqlCheckTrips);

                    if (tripCount > 0)
                    {
                        MessageBox.Show("Không thể xóa tuyến này do đã có chuyến!",
                                        "Thông báo", MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Xóa tuyến
                        string sqlDeleteRoute =
                            $@"
                    DELETE FROM Route 
                    WHERE RouteID = {selectedRouteID}";

                        db.ExecuteNonQuery(sqlDeleteRoute);

                        MessageBox.Show("Xóa tuyến thành công!", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Làm mới danh sách tuyến
                        UC_QuanLyTuyenXe_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa tuyến: {ex.Message}", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tuyến để xóa.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            // Lấy giá trị từ TextBox
            string startLoc = txtStartLoc.Text.Trim();
            string endLoc = txtEndLoc.Text.Trim();
            string distance = txtDistance.Text.Trim();

            if (string.IsNullOrEmpty(startLoc) || string.IsNullOrEmpty(endLoc) ||
                string.IsNullOrEmpty(distance))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nếu địa điểm bắt đầu và kết thúc đã tồn tại
            string sqlCheckRoute =
                $@"
                              SELECT COUNT(*) 
                              FROM Route 
                              WHERE StartLocation = '{startLoc}' AND EndLocation = '{endLoc}'";

            try
            {
                int count = (int)db.ExecuteScalar(sqlCheckRoute);

                if (count > 0)
                {
                    MessageBox.Show("Tuyến này đã tồn tại!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Gộp địa điểm để tạo tên tuyến
                    string routeName = $"{startLoc} - {endLoc}";

                    // Thêm tuyến mới
                    string sqlInsertRoute =
                        $@"
                                      INSERT INTO Route (RouteName, StartLocation, EndLocation, Distance)
                                      VALUES ('{routeName}', '{startLoc}', '{endLoc}', {distance})";

                    db.ExecuteNonQuery(sqlInsertRoute);

                    MessageBox.Show("Thêm tuyến mới thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới danh sách tuyến
                    UC_QuanLyTuyenXe_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm tuyến: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtStartLoc_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
        }
    }
}
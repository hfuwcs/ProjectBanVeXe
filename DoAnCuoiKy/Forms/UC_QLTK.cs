using MyLibrary.DTO;
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
using MyLibrary.BLL;
using MyLibrary.DAL;
using System.Web.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DoAnCuoiKy
{
    public partial class UC_QLTK : UserControl
    {
        private int _userID;
        private Account account;
        static DbContext db = new DbContext();
        public int UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
            }
        }
        public UC_QLTK()
        {
            InitializeComponent();
        }

        private void UC_QLTK_Load(object sender, EventArgs e)
        {

            account = AccountBLL.Instance.GetAccount(UserID);
            string str = AccountBLL.Instance.GetRoleName(UserID);
            label_Name.Text += account.Name;
            label_RoleName.Text += str;
            cbcVaiTro.DataSource = Helpers.roles;
            cbcVaiTro.DisplayMember = "RoleName";
            cbcVaiTro.ValueMember = "RoleID";
        }
        private void LoadUserData()
        {
            try
            {
                string sqls = "  SELECT UA.UserID, FullName, Email,UA.CCCD, R.RoleName\r\n  FROM UserAccount UA\r\n  INNER JOIN UserRoles UR\r\n  ON UA.UserID=UR.UserID\r\n  INNER JOIN Roles R\r\n  ON R.RolesID=UR.RoleID";
                DataTable dt = db.ExecuteQuery(sqls);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau(UserID); 
            doiMatKhau.instance.ShowDialog();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            if(AccountDAL.Instance.IsAdmin(account))
            {
                List<Account> list = AccountDAL.Instance.GetListAccount();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập");
                return;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                if (AccountDAL.Instance.IsAdmin(account))
                {
                    string sqls = "  SELECT UA.UserID, FullName, Email,UA.CCCD, R.RoleName\r\n  FROM UserAccount UA\r\n  INNER JOIN UserRoles UR\r\n  ON UA.UserID=UR.UserID\r\n  INNER JOIN Roles R\r\n  ON R.RolesID=UR.RoleID";
                    DataTable dt = db.ExecuteQuery(sqls);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    tabPage2.Controls.Clear();
                    MessageBox.Show("Bạn không có quyền truy cập");
                    tabControl1.SelectedIndex = 0;
                    return;
                }
            }
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên");
                return;
            }

            if (db.GetTable<Account>().Where(a=>a.Name==txtTen.Text) == null) { 
                MessageBox.Show("Không có dữ liệu");
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = db.GetTable<Account>().Where(a=>a.Name.Contains(txtTen.Text)).ToList();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnDoiMatKhau_Click_1(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau(UserID);
            doiMatKhau.instance.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var userId = dataGridView1.CurrentRow.Cells["UID"].Value;
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    string deleteUserRoles = $"DELETE FROM UserRoles WHERE UserID = {userId}";
                    string deleteUser = $"DELETE FROM UserAccount WHERE UserID = {userId}";
                    db.ExecuteNonQuery(deleteUserRoles);
                    db.ExecuteNonQuery(deleteUser);

                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var userId = dataGridView1.CurrentRow.Cells["UID"].Value;
            var confirm = MessageBox.Show("Bạn có chắc muốn đổi mật khẩu khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    DoiMatKhau doiMatKhau = new DoiMatKhau(Convert.ToInt32(userId));
                    doiMatKhau.instance.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Them

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các textbox (giả định rằng các textbox có tên tương ứng)
                string fullName = txtFullName.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPass.Text.Trim();
                string retypePass = txtretypePass.Text.Trim();
                int roleID = (int)cbcVaiTro.SelectedValue;
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(retypePass))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (password != retypePass)
                {
                    MessageBox.Show("Mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Kiểm tra xem tên đăng nhập đã tồn tại chưa
                string checkUsername = $"SELECT COUNT(*) FROM UserAccount WHERE Email = '{username}'";
                var count = db.ExecuteScalar(checkUsername);
                
                if (count > 0) {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string cipherPassword = Helpers.EncryptSHA256(password);

                // Thêm UserAccount
                string insertUserAccount = $"INSERT INTO UserAccount (FullName, Email, Password) VALUES (N'{fullName}', '{username}', '{cipherPassword}'); SELECT SCOPE_IDENTITY();";
                var userId = db.ExecuteScalar(insertUserAccount);

                if (userId != null)
                {
                    // Thêm UserRoles
                    string insertUserRoles = $"INSERT INTO UserRoles (UserID, RoleID) VALUES ({userId}, {roleID})";
                    db.ExecuteNonQuery(insertUserRoles);

                    MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserData(); // Tải lại dữ liệu
                }
                else
                {
                    MessageBox.Show("Không thể thêm tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu người dùng đã chọn một hàng
            {
                txtInfoName.Text = dataGridView1.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
                txtInfoCCCD.Text = dataGridView1.Rows[e.RowIndex].Cells["CCCD"].Value.ToString();
                txtInfoRole.Text = dataGridView1.Rows[e.RowIndex].Cells["Role"].Value.ToString();
                txtInfoEID.Text = dataGridView1.Rows[e.RowIndex].Cells["UID"].Value.ToString();
                txtUsername.Text = dataGridView1.Rows[e.RowIndex].Cells["UserName"].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các textbox (giả định rằng các textbox có tên tương ứng)
                string fullName = txtInfoName.Text.Trim();
                string username = txtUsername.Text.Trim();
                string CCCD = txtInfoCCCD.Text.Trim();
                int MaNV = Convert.ToInt32(txtInfoEID.Text);
                int roleID = (int)cbcVaiTro.SelectedValue;
                int userid = Convert.ToInt32(txtInfoEID.Text);
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(CCCD))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem tên đăng nhập đã tồn tại chưa
                string checkUsername = $"SELECT COUNT(*) FROM UserAccount WHERE Email = '{username}'";
                var count = db.ExecuteScalar(checkUsername);

                if (count > 0)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật thông tin người dùng
                string updateUserSql = $"UPDATE UserAccount SET FullName = N'{fullName}', Email = '{username}', CCCD = {CCCD} WHERE UserID = {userid}";
                int rowsAffected = db.ExecuteNonQuery(updateUserSql);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserData();  // Load lại dữ liệu sau khi cập nhật
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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
            if (AccountDAL.Instance.IsAdmin(account))
            {
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
    }
}

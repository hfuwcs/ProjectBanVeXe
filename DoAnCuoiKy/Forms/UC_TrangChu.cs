using MyLibrary;
using MyLibrary.BLL;
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
    public partial class UC_TrangChu : UserControl
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
        public UC_TrangChu()
        {
            InitializeComponent();
        }

        private void UC_TrangChu_Load(object sender, EventArgs e)
        {
            account = AccountBLL.Instance.GetAccount(UserID);
            string str = AccountBLL.Instance.GetRoleName(UserID);
            uc_lblname.Text += account.Name;
            lb_rolename.Text += str;
        }
    }
}

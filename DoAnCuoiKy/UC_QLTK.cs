using DoAnCuoiKy.BusinessClass;
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

namespace DoAnCuoiKy
{
    public partial class UC_QLTK : UserControl
    {
        private int _userID;
        private Account account;
        BanVeXe obj = new BanVeXe();
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

            account = obj.GetAccount(UserID);
            string str = obj.GetRoleName(UserID);
            label_Name.Text += account.Name;
            label_RoleName.Text += str;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhau doiMatKhau = new DoiMatKhau(UserID); 
            doiMatKhau.instance.ShowDialog();
        }
    }
}

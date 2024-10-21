using DoAnCuoiKy.BusinessClass;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy
{
    public partial class DangNhap : Form
    {
        //public DangNhap instance;
        BanVeXe obj = new BanVeXe();
        public bool isLogin = false;
        public TextBox tb1;
        public TextBox tb2;
        public string Name;
        public Account account;
        
        public DangNhap()
        {
            InitializeComponent();
            //instance = this;
            tb1 = txtBox_Email;
            tb2 = txtBox_Pass;
            Name = string.Empty;
        }

        private void txtBox_Pass_Enter(object sender, EventArgs e)
        {
            txtBox_Pass.Text = "";

            txtBox_Pass.ForeColor = Color.Black;

            txtBox_Pass.UseSystemPasswordChar = true;
        }

        private void txtBox_Pass_Leave(object sender, EventArgs e)
        {
            if (txtBox_Pass.Text.Length == 0)
            {
                txtBox_Pass.ForeColor = Color.Gray;

                txtBox_Pass.Text = "Enter password";

                txtBox_Pass.UseSystemPasswordChar = false;

                SelectNextControl(txtBox_Pass, true, true, false, true);
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            account = new Account() { UserName=txtBox_Email.Text, Password=txtBox_Pass.Text};
            
            //Check xem User có tồn tại không
            if (obj.CheckUser(account))
            {
                //Nếu tồn tại thì lấy tất cả thông tin của user
                account = obj.GetAccount(txtBox_Email.Text);


                //Đặt biến isLogin để biết người dùng đã đăng nhập thành công
                isLogin = true;

                //Truyền UserID cho MainForm để cho biết người dùng nào đã đăng nhập
                MainForm mainForm = new MainForm(account.UserID);
                mainForm.Show();//Mở form chính
                this.Hide();//Đóng form đăng nhập
                mainForm.lbl_Name.Text += account.Name.ToString();
                mainForm.DangXuat += MainForm_DangXuat;
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtBox_Email.Focus();
            }
        }

        private void MainForm_DangXuat(object sender, EventArgs e)
        {
            (sender as MainForm).isExit = false;
            (sender as MainForm).Close();
            this.Show(); 
        }

        private void btn_ThoatDangNhap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel_DoiMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (isLogin)
            {
                DoiMatKhau doiMatKhau = new DoiMatKhau(account.UserID);
                doiMatKhau.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn cần đăng nhập trước khi đổi mật khẩu","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}

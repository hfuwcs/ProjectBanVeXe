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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau instance;
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

        public DoiMatKhau(int userid)
        {
            instance = this;
            InitializeComponent();
            this.UserID = userid;
            account = obj.GetAccount(UserID);

            //Gán sự kiện EnterPassword và Leave cho 2 ô nhập password mới
            txt_TypePass.Enter += EnterPassword;
            txt_RetypePass.Enter += EnterPassword;
            txt_TypePass.Leave += PasswordLeave;
            txt_RetypePass.Leave += PasswordLeave;
        }

        //Xóa dữ liệu trên textbox khi đặt con trỏ vào, chuyển ký tự thành kiểu cho password
        private void EnterPassword(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            textBox.Text = "";

            textBox.ForeColor = Color.Black;

            textBox.UseSystemPasswordChar = true;
        }

        //Place holder cho textbox = Enter password
        private void PasswordLeave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length == 0)
            {
                textBox.ForeColor = Color.Gray;

                textBox.UseSystemPasswordChar = false;

                SelectNextControl(textBox, true, true, false, true);
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            lbl_Account.Text += account.UserName;
        }

        private void btn_ThoatDangNhap_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txt_RetypePass.Text != string.Empty && txt_TypePass.Text != string.Empty)
            {
                if (txt_TypePass.Text != txt_RetypePass.Text)
                {
                    MessageBox.Show("Mật khẩu không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_TypePass.Focus();
                }
                else
                {
                    obj.ChangePassword(UserID, txt_RetypePass.Text);
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Không được để trống mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_TypePass.Focus();
            }
        }
    }
}

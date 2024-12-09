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

namespace DoAnCuoiKy
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau instance;
        private int _userID;
        private Account account;
        DbContext obj = new DbContext();
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
            account = AccountBLL.Instance.GetAccount(UserID);

            //Gán sự kiện EnterPassword và Leave cho 2 ô nhập password mới
            RegisterControl();
        }

        void RegisterControl()
        {
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
                textBox.Text = "Enter Password";

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
        //string ErrorMesssage()
        //{
        //    string default_Text = "Enter Password";
        //    if (!String.IsNullOrEmpty(txt_TypePass.Text) && !String.IsNullOrEmpty(txt_RetypePass.Text))
        //    {
        //        if (txt_TypePass.Text != txt_RetypePass.Text)
        //        {
        //            return "Mật khẩu không trùng khớp!";
        //        }
        //        else if 
        //            ((String.IsNullOrEmpty(txt_RetypePass.Text) && txt_RetypePass.Text!=default_Text)
        //                && (String.IsNullOrEmpty(txt_TypePass.Text) && txt_TypePass.Text != default_Text)
        //            )
        //        {
        //            return "Nhập lại mật khẩu!";
        //        }
        //    }
        //    return null;
        //}

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            string default_Text = "Enter Password";
            if (txt_RetypePass.Text != string.Empty && txt_TypePass.Text != string.Empty)
            {
                if ((txt_TypePass.Text != txt_RetypePass.Text))
                {
                    MessageBox.Show("Mật khẩu không trùng khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_TypePass.Focus();
                }
                else if (txt_RetypePass.Text != default_Text || txt_TypePass.Text != default_Text)
                {
                    AccountBLL.Instance.ChangePassword(txt_RetypePass.Text, UserID);
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không được để trống mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_TypePass.Focus();
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

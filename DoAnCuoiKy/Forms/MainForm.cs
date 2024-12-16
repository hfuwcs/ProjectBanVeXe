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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Security.Cryptography;
using DoAnCuoiKy.Forms;

namespace DoAnCuoiKy
{
    public partial class MainForm : Form
    {
        MainForm ths;
        DbContext db = new DbContext();

        public Button button_Thoat;
        public Button button_QuanLyChuyen;
        public Label lbl_Name;
        private UserControl activeForm;
        private Button currentButton;

        //Biến trạng thái cho phép thoát khỏi form
        public bool isExit = true;

        //UserID đã đăng nhập vào Form này (MainForm)
        private int userID;
        public MainForm(int userid)
        {
            InitializeComponent();

            //Lấy ID người dùng đã được đăng nhập
            this.userID = userid;
            button_Thoat = btn_DoanhThu;
            button_QuanLyChuyen = btn_QuanLyChuyen;
            UC_TrangChu uC_TrangChu = new UC_TrangChu();
            uC_TrangChu.UserID = this.userID;
            AddUserControl(uC_TrangChu);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    {
                        DisableButton();
                        Color color = Color.Tomato;
                        currentButton = (Button)btnSender;
                        currentButton.BackColor = color;
                        currentButton.ForeColor = Color.White;
                        currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in tableLayoutPanel1.Controls)
            {
                if (previousBtn is Button)
                {
                    previousBtn.BackColor = Color.Transparent;
                    previousBtn.ForeColor = Color.Black;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void AddUserControl(UserControl userControl)
        {

            userControl.Dock=DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void AddUserControl(UserControl userControl, object btnSender)
        {
            ActivateButton(btnSender);
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                if (MessageBox.Show("Bạn có muốn thoát", "Thoát?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    isExit = false;
                    Application.Exit();
                }
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
        }

        private void btn_BanVe_Click(object sender, EventArgs e)
        {
            UC_DatVe ucDatVe = new UC_DatVe();
            ucDatVe.UserID = this.userID;
            activeForm = ucDatVe;
            AddUserControl(ucDatVe, sender);
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            UC_TrangChu uC_TrangChu = new UC_TrangChu();
            uC_TrangChu.UserID = this.userID;
            AddUserControl(uC_TrangChu, sender);
            
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isExit) { 
                this.Close();
            }
        }

        public event EventHandler DangXuat;
        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            DangXuat(this, new EventArgs());
        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            UC_DoangThu uC_DoangThu = new UC_DoangThu();
            AddUserControl(uC_DoangThu, sender);
        }

        private void btn_QuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            UC_QLTK uC_QLTK = new UC_QLTK();
            uC_QLTK.UserID = this.userID;
            AddUserControl(uC_QLTK, sender);
        }

        private void btn_QuanLyChuyen_Click(object sender, EventArgs e)
        {
            Account account = AccountBLL.Instance.GetAccount(this.userID);
            if (account != null && AccountBLL.Instance.IsAdmin(account)){
                UC_QuanLyChuyen uC_QuanLyChuyen = new UC_QuanLyChuyen();
                AddUserControl(uC_QuanLyChuyen, sender);
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền hạn để thực hiện việc này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

   
        private void btnQuanLyKH_Click(object sender, EventArgs e)
        {
            Account account = AccountBLL.Instance.GetAccount(this.userID);
            if (account != null && AccountBLL.Instance.IsAdmin(account))
            {
                UC_QuanLyKhachHang uC_QuanLyKhachHang = new UC_QuanLyKhachHang();
                AddUserControl(uC_QuanLyKhachHang, sender);
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền hạn để thực hiện việc này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btn_QuanLyVe_Click(object sender, EventArgs e)
        {
            Account account = AccountBLL.Instance.GetAccount(this.userID);
            if (account != null && AccountBLL.Instance.IsAdmin(account))
            {
                UC_QuanLyVe uC_QuanLyVe = new UC_QuanLyVe();
                AddUserControl(uC_QuanLyVe, sender);
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền hạn để thực hiện việc này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnQuanLyTX_Click(object sender, EventArgs e)
        {
            Account account = AccountBLL.Instance.GetAccount(this.userID);
            if (account != null && AccountBLL.Instance.IsAdmin(account))
            {
                UC_QuanLyTaiXe uC_QuanLyTaiXe = new UC_QuanLyTaiXe();
                AddUserControl(uC_QuanLyTaiXe, sender);
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền hạn để thực hiện việc này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Account account = AccountBLL.Instance.GetAccount(this.userID);
            if (account != null && AccountBLL.Instance.IsAdmin(account))
            {
                UC_QuanLyTuyenXe uC_QuanLyTuyenXe = new UC_QuanLyTuyenXe();
                AddUserControl(uC_QuanLyTuyenXe, sender);
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền hạn để thực hiện việc này.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}

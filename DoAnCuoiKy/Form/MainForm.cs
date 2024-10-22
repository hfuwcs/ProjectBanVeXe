using DoAnCuoiKy.BusinessClass;
using MyLibrary;
using MyLibrary.BusinessClass;
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
    public partial class MainForm : Form
    {
        MainForm ths;
        BanVeXe obj = new BanVeXe();//Khai báo obj để xử dụng các method trong MyLibrary

        public Button button_Thoat;
        public Button button_QuanLyChuyen;
        public Label lbl_Name;

        //Biến trạng thái cho phép thoát khỏi form
        public bool isExit = true;

        //UserID đã đăng nhập vào Form này (MainForm)
        private int userID;
        public MainForm(int userid)
        {
            InitializeComponent();

            //Lấy ID người dùng đã được đăng nhập
            this.userID = userid;
            //instance = this;
            button_Thoat = btn_DoanhThu;
            button_QuanLyChuyen = btn_QuanLyChuyen;
            lbl_Name = label_Name;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock=DockStyle.Fill;
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
            AddUserControl(ucDatVe);
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            Passenger passenger = obj.GetOnePassenger("1", "1@example.com");
            string sqls = "select B.BusID from  Bus B Inner join Trip T on b.BusID=t.BusID WHERE DepartureLocation = 'TP HCM'  AND ArrivalLocation= 'Da Nang'";
            int BusID = obj.GetOneID(sqls); 
        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            UC_DoangThu uC_DoangThu = new UC_DoangThu();
            AddUserControl(uC_DoangThu);
        }

        private void btn_TraCuuVe_Click(object sender, EventArgs e)
        {
            UC_TraCuuVe uC_TraCuuVe = new UC_TraCuuVe();
            AddUserControl(uC_TraCuuVe);
        }

        private void btn_QuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            UC_QLTK uC_QLTK = new UC_QLTK();
            uC_QLTK.UserID = this.userID;
            AddUserControl(uC_QLTK);
        }

        private void btn_QuanLyChuyen_Click(object sender, EventArgs e)
        {
            Account account = obj.GetAccount(this.userID);
            int RoleID = obj.GetIDRole(account.UserID);
            if (account != null) {
                if(RoleID == 1)
                {
                    UC_QuanLyChuyen uC_QuanLyChuyen = new UC_QuanLyChuyen();
                    AddUserControl(uC_QuanLyChuyen);
                }
                else
                {
                    MessageBox.Show("Bạn không đủ quyền hạn để thực hiện việc này.","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Chưa đăng nhập hoặc người dùng không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

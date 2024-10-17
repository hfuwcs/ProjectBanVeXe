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
    public partial class MainForm : Form
    {
        MainForm ths;
        BanVeXe obj = new BanVeXe();//Khai báo obj để xử dụng các method trong MyLibrary
        public Button button_Thoat;
        public Button button_QuanLyChuyen;
        public Label lbl_Name;
        public bool isExit = true;
        public MainForm()
        {
            InitializeComponent();
            //instance = this;
            button_Thoat = btn_DoanhThu;
            button_QuanLyChuyen = btn_QuanLyChuyen;
            lbl_Name = label_Name;
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
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isExit)
                Application.Exit();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            DangNhap dangNhap = new DangNhap();
            dangNhap.Show();
        }

        private void btn_BanVe_Click(object sender, EventArgs e)
        {
            UC_DatVe ucDatVe = new UC_DatVe();
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
            int total = obj.GetIncomeTest("09/10/2024" , "10/10/2024", "TP HCM", "Da Nang");
        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            UC_DoangThu uC_DoangThu = new UC_DoangThu();
            AddUserControl(uC_DoangThu);
        }
    }
}

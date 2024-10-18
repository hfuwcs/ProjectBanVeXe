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
        public bool isExit = true;
        public MainForm()
        {
            InitializeComponent();
            //Init Form chạy toàn màn hình   
            //this.FormBorderStyle = FormBorderStyle.Sizable;
            //this.WindowState = FormWindowState.Maximized;
            //this.TopMost = true;


            //instance = this;
            button_Thoat = btn_DoanhThu;
            button_QuanLyChuyen = btn_QuanLyChuyen;
            lbl_Name = label_Name;
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Escape)
            //{
            //    this.FormBorderStyle = FormBorderStyle.Sizable;
            //    this.WindowState = FormWindowState.Normal;
            //    this.TopMost = false;
            //}
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
            Passenger passenger = obj.GetOnePassenger("1", "1@example.com");
            string sqls = "select B.BusID from  Bus B Inner join Trip T on b.BusID=t.BusID WHERE DepartureLocation = 'TP HCM'  AND ArrivalLocation= 'Da Nang'";
            int BusID = obj.GetOneID(sqls); 
        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            UC_DoangThu uC_DoangThu = new UC_DoangThu();
            AddUserControl(uC_DoangThu);
        }

        
    }
}

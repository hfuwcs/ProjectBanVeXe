using DoAnCuoiKy.Forms;
using MyLibrary;
using MyLibrary.BLL;
using MyLibrary.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy
{
    public partial class UC_DoangThu : UserControl
    {
        DbContext db = new DbContext();
        public UC_DoangThu()
        {
            InitializeComponent();
            //Lấy 2 chữ số thập phân
            db.nfi.CurrencyDecimalDigits = 2;
        }

        private void UC_DoangThu_Load(object sender, EventArgs e)
        {
            //START: LOAD database cho Tuyen
            string sqlstart = "select StartLocation from Route group by StartLocation";
            comboBox_Start.DataSource = db.GetDataTable(sqlstart);
            comboBox_Start.DisplayMember = "StartLocation";

            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = db.GetDataTable(sqlend);
            comboBox_End.DisplayMember = "EndLocation";
            //END: LOAD database cho Tuyen
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            try
            {
                txtTongDoanhThu.Text = string.Empty;//Đặt lại ô txtTongDoanhThu = Empty để ô nhận giá trị mới

                string startDay = dateTimePicker_StartDate.Value.ToString("yyyy/MM/dd HH:mm");
                string endDay = dateTimePicker_Endday.Value.ToString("yyyy/MM/dd HH:mm");
                string depLoc = comboBox_Start.Text.ToString();
                string arrLoc = comboBox_End.Text.ToString();

                txtTongDoanhThu.Text += db.GetIncome(startDay, endDay, depLoc, arrLoc).ToString("C", db.nfi);
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Lỗi không tìm được Doanh thu, liên hệ quản trị viên");
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            string startDay = dateTimePicker_StartDate.Value.ToString("yyyy/MM/dd HH:mm");
            string endDay = dateTimePicker_Endday.Value.ToString("yyyy/MM/dd HH:mm");
            string depLoc = comboBox_Start.Text.ToString();
            string arrLoc = comboBox_End.Text.ToString();
            int routeID = RouteBLL.Instance.GetRouteID(depLoc, arrLoc);
            FormDoanhThuReport frm = new FormDoanhThuReport(startDay, endDay, routeID, depLoc, arrLoc);
            frm.ShowDialog();
        }

       
    }
}

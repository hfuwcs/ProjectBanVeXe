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
    public partial class UC_DoangThu : UserControl
    {
        DbContext obj = new DbContext();
        public UC_DoangThu()
        {
            InitializeComponent();
            //Lấy 2 chữ số thập phân
            obj.nfi.CurrencyDecimalDigits = 2;
        }

        private void UC_DoangThu_Load(object sender, EventArgs e)
        {
            //START: LOAD database cho Tuyen
            string sqlstart = "select StartLocation from Route group by StartLocation";
            comboBox_Start.DataSource = obj.GetDataTable(sqlstart);
            comboBox_Start.DisplayMember = "StartLocation";

            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = obj.GetDataTable(sqlend);
            comboBox_End.DisplayMember = "EndLocation";
            //END: LOAD database cho Tuyen
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            txtTongDoanhThu.Text=string.Empty;//Đặt lại ô txtTongDoanhThu = Empty để ô nhận giá trị mới

            //Khai báo string để truyền vào hàm
            string startDay =  dateTimePicker_StartDate.Value.ToString("yyyy/MM/dd HH:mm");
            string endDay = dateTimePicker_Endday.Value.ToString("yyyy/MM/dd HH:mm");
            string depLoc = comboBox_Start.Text.ToString();
            string arrLoc = comboBox_End.Text.ToString();
            
            txtTongDoanhThu.Text += obj.GetIncome(startDay, endDay, depLoc, arrLoc).ToString("C",obj.nfi);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
        }
    }
}

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
        BanVeXe obj = new BanVeXe();
        public UC_DoangThu()
        {
            InitializeComponent();
        }

        private void UC_DoangThu_Load(object sender, EventArgs e)
        {
            //START: LOAD database cho Tuyen
            BanVeXe db1 = new BanVeXe();
            string sqls1 = "select StartLocation from Route group by StartLocation";
            string tableName1 = "Route";
            db1.GetDataAdapter(sqls1, tableName1);

            comboBox_Start.DataSource = db1.DataSet.Tables[0];
            comboBox_Start.ValueMember = "StartLocation";
            comboBox_Start.DisplayMember = "StartLocation";

            BanVeXe db2 = new BanVeXe();
            string sqls2 = "select EndLocation from Route group by EndLocation";
            string tableName2 = "Route";
            db2.GetDataAdapter(sqls2, tableName2);

            comboBox_End.DataSource = db2.DataSet.Tables[0];
            comboBox_End.ValueMember = "EndLocation";
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
            
            txtTongDoanhThu.Text += obj.GetIncomeTest(startDay, endDay, depLoc, arrLoc).ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
        }
    }
}

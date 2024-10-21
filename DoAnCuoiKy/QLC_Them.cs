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
    public partial class QLC_Them : Form
    {
        BanVeXe obj = new BanVeXe();
        public QLC_Them()
        {
            InitializeComponent();
        }

        private void formatTimePicker(object sender)
        {
            DateTimePicker timerPicker = sender as DateTimePicker;
            timerPicker.Format = DateTimePickerFormat.Time;
            timerPicker.CustomFormat = "HH:mm";
            timerPicker.ShowUpDown = true;
            timerPicker.Value = DateTime.Today.AddHours(6);

        }

        private void QLC_Them_Load(object sender, EventArgs e)
        {
            //Load các tuyến
            string sqlstart = "select StartLocation from Route group by StartLocation";
            comboBox_Start.DataSource = obj.GetListOneColumn(sqlstart);
            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = obj.GetListOneColumn(sqlend);

            //Lấy ID các Bus sẵn sàng:
            string sqlReaduBuses = "SELECT BusID FROM TRIP WHERE DATEDIFF(HOUR,GETDATE(),ArrivalTime)>0";
            List<int> readyBuses = obj.GetListIntOneColumn(sqlReaduBuses);
            //Load Các xe còn sẵn sàng (còn có thể nhận chuyến mới, không trong chuyến cũ)
            //string sqlAvlBus = "SELECT * FROM TRIP WHERE BusID=3 AND DATEDIFF(HOUR,GETDATE(),ArrivalTime)>0"
            dgr_ReadyBus.DataSource = obj.GetBus(readyBuses, "Bus");
            formatTimePicker(dtp_Hours_Start);
            formatTimePicker(dtp_Hours_End);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtp_Hours_Start_ValueChanged(object sender, EventArgs e)
        {
            dtp_Hours_End.Value = DateTime.Today.AddHours(8);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vẫn chưa thực hiện xong ;0");
        }
    }
}

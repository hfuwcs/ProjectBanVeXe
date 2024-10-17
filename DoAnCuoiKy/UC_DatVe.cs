using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCuoiKy
{
    public partial class UC_DatVe : UserControl
    {
        BanVeXe db = new BanVeXe();
        public UC_DatVe()
        {
            InitializeComponent();
        }
        private void DisableButtons(Control.ControlCollection controls, List<string> valuesToDisable)
        {
            foreach (Control control in controls)
            {
                if (control is Button button)
                {
                    if (valuesToDisable.Contains(button.Text, StringComparer.OrdinalIgnoreCase))
                    {
                        button.Enabled = false;
                    }
                }
                // Nếu control là container, gọi đệ quy
                if (control.HasChildren)
                {
                    DisableButtons(control.Controls, valuesToDisable);
                }
            }
        }

        private void UC_DatVe_Load(object sender, EventArgs e)
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

        private void btnTimChuyenXe_Click(object sender, EventArgs e)
        {
            string datepicker = dateTimePicker_StarDate.Value.ToString("yyyy/MM/dd HH:mm");
            string sqls = "select BusNumber, TotalSeat, BusType,  DepartureTime, ArrivalTime from  Bus B Inner join Trip T on b.BusID=t.BusID WHERE DepartureLocation='" + comboBox_Start.Text.ToString() + "'  AND ArrivalLocation= '" + comboBox_End.Text.ToString() + "' AND DATEDIFF(DAY,T.DepartureTime,'"+ datepicker + "')=0";
            dataGridView_TimXe.DataSource = db.GetDataTable(sqls);
        }

        private void comboBox_Start_TextChanged(object sender, EventArgs e)
        {
        }
        private void dataGridView_TimXe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sqls = "select SeatNumber from Seat S, DetailsTicket DT Where S.SeatID=DT.SeatID and TRIPID=1";
            List<string> list = db.GetListOneColumn(sqls);
            DisableButtons(this.Controls, list);

        }
    }
}

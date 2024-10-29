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
    public partial class UC_QuanLyChuyen : UserControl
    {
        DbContext obj = new DbContext();
        QLC_Sua QLC_Sua = new QLC_Sua();
        QLC_Them QLC_Them = new QLC_Them();
        public UC_QuanLyChuyen()
        {
            InitializeComponent();
        }

        //Autosize datagridview thôi ;)
        private void autosizedgv(object sender)
        {
            DataGridView dataGridView = sender as DataGridView;
            // Set your desired AutoSize Mode:
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            for (int i = 0; i <= dataGridView.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = dataGridView.Columns[i].Width;

                // Remove AutoSizing:
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                dataGridView.Columns[i].Width = colw;
            }
        }

        private void UC_QuanLyChuyen_Load(object sender, EventArgs e)
        {
            string sqls = "select Distinct B.BusID, BusNumber, TotalSeat, BusType,  DepartureTime, ArrivalTime \r\nfrom  Bus B \r\nInner join Trip T on b.BusID=t.BusID \r\n";
            dataGridView_TatCaChuyenXe.DataSource = obj.GetDataTable(sqls);
            autosizedgv(dataGridView_TatCaChuyenXe);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            QLC_Them.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang phát triển");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.MemberwiseClone();
        }
    }
}

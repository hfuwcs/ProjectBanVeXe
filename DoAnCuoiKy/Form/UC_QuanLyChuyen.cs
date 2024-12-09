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
        DbContext db = new DbContext();
        QLC_Them QLC_Them = new QLC_Them();
        public UC_QuanLyChuyen()
        {
            InitializeComponent();
            QLC_Them.TripAdded += QLC_Them_TripAdded;
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
        private void QLC_Them_TripAdded(object sender, EventArgs e)
        {
            // Refresh the dataGridView_TatCaChuyenXe
            UC_QuanLyChuyen_Load(sender, e);
        }
        private void UC_QuanLyChuyen_Load(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy/MM/dd") + (" 00:00");

            string sqls = $"select Distinct T.TRIPID, B.BusID, BusNumber, TotalSeat, BusType,  DepartureTime, ArrivalTime, DepartureLocation, ArrivalLocation \r\nfrom  Bus B \r\nInner join Trip T on b.BusID=t.BusID WHERE ArrivalTime>= '{today}'";
            dataGridView_TatCaChuyenXe.DataSource = db.GetDataTable(sqls);
            autosizedgv(dataGridView_TatCaChuyenXe);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            QLC_Them.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int tripID = int.Parse(dataGridView_TatCaChuyenXe.CurrentRow.Cells[0].Value.ToString());

            QLC_Sua qlc = new QLC_Sua(tripID);
            qlc.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string deppTime = dataGridView_TatCaChuyenXe.CurrentRow.Cells[4].Value.ToString();
            deppTime = DateTime.Parse(deppTime).ToString("yyyy/MM/dd HH:mm");

            string arrTime = dataGridView_TatCaChuyenXe.CurrentRow.Cells[5].Value.ToString();
            arrTime = DateTime.Parse(arrTime).ToString("yyyy/MM/dd HH:mm");
            if (MessageBox.Show("Bạn có chắc muốn xóa?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                string sqls = "Select TripID from Trip where DepartureTime = '" + deppTime + "' and ArrivalTime = '" + arrTime + "'";
                int tripId = db.ExecuteScalar(sqls);
                string sqlDelete = "Delete from Trip where TripID = " + tripId;
                int res = db.ExecuteNonQuery(sqlDelete);
                if (res > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    UC_QuanLyChuyen_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
                
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.MemberwiseClone();
        }
    }
}

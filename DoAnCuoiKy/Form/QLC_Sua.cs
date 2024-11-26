using MyLibrary;
using MyLibrary.BLL;
using MyLibrary.DTO;
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
    public partial class QLC_Sua : Form
    {
        DbContext db = new DbContext();
        int TripID;
        public QLC_Sua(int tripID)
        {
            this.TripID = tripID;
            InitializeComponent();
        }
        //autosize datagridview
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
        private void ThemXoa_QLChuyen_Load(object sender, EventArgs e)
        {
            string sqlstart = "select StartLocation from Route group by StartLocation";
            comboBox_Start.DataSource = db.GetDataTable(sqlstart);
            comboBox_Start.DisplayMember = "StartLocation";

            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = db.GetDataTable(sqlend);
            comboBox_End.DisplayMember = "EndLocation";

            Trip trip = TripBLL.Instance.GetTripByID(TripID);
            comboBox_Start.Text = trip._departureLocation;
            comboBox_End.Text = trip._arrivalLocation;
        }

    }
}

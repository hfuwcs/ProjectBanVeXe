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
    public partial class QLC_Sua : Form
    {
        BanVeXe obj = new BanVeXe();
        public QLC_Sua()
        {
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
            comboBox_Start.DataSource = obj.GetListOneColumn(sqlstart);
            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = obj.GetListOneColumn(sqlend);

            string sqlBus = "Select * from Bus";
            //obj.GetDataTable(sqlBus,"Bus");
            dataGridView_Bus.DataSource = obj.GetDataTable(sqlBus);
            autosizedgv(dataGridView_Bus);
        }

    }
}

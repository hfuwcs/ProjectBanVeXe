using MyLibrary;
using MyLibrary.BLL;
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
    public partial class UC_TraCuuVe : UserControl
    {
        DbContext obj = new DbContext();
        public UC_TraCuuVe()
        {
            InitializeComponent();
        }
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
        private void UC_TraCuuVe_Load(object sender, EventArgs e)
        {
            autosizedgv(dataGridView_TraCuuVe);
            //LOAD database cho các Tuyến
            string sqlstart = "select StartLocation from Route group by StartLocation";
            comboBox_Start.DataSource = obj.GetDataTable(sqlstart);
            comboBox_Start.DisplayMember = "StartLocation";

            string sqlend = "select EndLocation from Route group by EndLocation";
            comboBox_End.DataSource = obj.GetDataTable(sqlend);
            comboBox_End.DisplayMember = "EndLocation";
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Số điện thoại!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
            }
            else
            {
                string dpt = dateTimePicker_StartDay.Value.ToString("yyyy/MM/dd");
                dataGridView_TraCuuVe.DataSource = DetailsTicketBLL.Instance.TRACUUVE(txtSDT.Text, dpt);//obj.GetDataTable(txtSDT.Text, dpt, "TraCuuVe");

                autosizedgv(dataGridView_TraCuuVe);
            }
        }
    }
}

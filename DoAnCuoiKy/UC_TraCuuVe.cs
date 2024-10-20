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
    public partial class UC_TraCuuVe : UserControl
    {
        BanVeXe obj = new BanVeXe();
        public UC_TraCuuVe()
        {
            InitializeComponent();
        }

        private void UC_TraCuuVe_Load(object sender, EventArgs e)
        {
            //START: LOAD database cho các Tuyến
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
            //END: LOAD database cho các Tuyến
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
                dataGridView_TraCuuVe.DataSource = obj.GetDataTable(txtSDT.Text, dpt, "TraCuuVe");

                // AutoSize cho Datadgridview
                //FYI: Code copy trên StackOverflow =))
                //Link here: https://stackoverflow.com/questions/1025670/how-do-you-automatically-resize-columns-in-a-datagridview-control-and-allow-the

                // Set your desired AutoSize Mode:
                dataGridView_TraCuuVe.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_TraCuuVe.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView_TraCuuVe.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
                for (int i = 0; i <= dataGridView_TraCuuVe.Columns.Count - 1; i++)
                {
                    // Store Auto Sized Widths:
                    int colw = dataGridView_TraCuuVe.Columns[i].Width;

                    // Remove AutoSizing:
                    dataGridView_TraCuuVe.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                    // Set Width to calculated AutoSize value:
                    dataGridView_TraCuuVe.Columns[i].Width = colw;
                }
            }
        }
    }
}

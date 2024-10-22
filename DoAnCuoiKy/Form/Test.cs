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
    public partial class Test : Form
    {
        BanVeXe obj = new BanVeXe();
        SqlDataAdapter userada = new SqlDataAdapter();
        public string sqls;
        public string tableName;
        public Test()
        {
            sqls = "Select * from UserAccount";
            tableName = "UserTable";
            userada = obj.GetDataAdapter(sqls, tableName);
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = obj.DataSet.Tables["UserTable"];
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            string sqlinsert = "Insert into UserAccount([FullName],[Email] ,[Password]) VALUES(@name,@email,@pass)";
            obj.OpenConnect();
            userada.TableMappings.Add("UserAccount", tableName);
            userada = obj.GetDataAdapter(sqls, tableName);
            userada.InsertCommand = new SqlCommand(sqlinsert,obj.conn);
            userada.InsertCommand.Parameters.AddWithValue("@name", "TEST");
            userada.InsertCommand.Parameters.AddWithValue("@email", "TEST");
            userada.InsertCommand.Parameters.AddWithValue("@pass", "TEST");
            obj.CloseConnect();
        }
    }
}

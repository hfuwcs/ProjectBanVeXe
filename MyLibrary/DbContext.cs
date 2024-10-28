using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

using System.Data;
using System.Data.SqlClient;
using MyLibrary.DTO;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;


namespace MyLibrary
{
    public class DbContext
    {
        SqlConnection _conn;
        DataSet _dataSet = new DataSet();
        public enum ConnectionType
        {
            ConnectionString,
            ConfigurationManager
        }

        private DbContext instance;
        public DbContext Instance { 
        get { if (instance == null) { 
                instance = new DbContext();
                }
                return instance; 
            }
        set { instance = value; }
        }
        public DbContext()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        //Khai báo format currency cho tiền VN
        public NumberFormatInfo nfi = new CultureInfo("vi-VN", false).NumberFormat;

        public DataSet DataSet
        {
            get { return _dataSet; }
            set { _dataSet = value; }
        }

        public SqlConnection conn
        {
            get { return _conn; }
            set { _conn = value; }
        } 

        public void OpenConnect()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        public void CloseConnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public void DiposeConnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Dispose();
        }



        //START: Xử lý Database
          //START:Xử lý Doanh thu

        public int GetIncome(string startDay, string endDay, string depLoc, string arrLoc)
        {
            int TotalIncome = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.TIMDOANHTHU";
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Connection = conn;

            // Thêm các tham số cho stored procedure
            cmd.Parameters.AddWithValue("@STARTDAY", startDay);
            cmd.Parameters.AddWithValue("@ENDDAY", endDay);
            cmd.Parameters.AddWithValue("@DEPLOC", depLoc);
            cmd.Parameters.AddWithValue("@ARRLOC", arrLoc);

            // Thêm tham số OUTPUT @TOTALINCOME
            SqlParameter outputParam = new SqlParameter("@TOTALINCOME", SqlDbType.Decimal);
            outputParam.Direction = ParameterDirection.Output;
            outputParam.Precision = 18;
            outputParam.Scale = 2;
            cmd.Parameters.Add(outputParam);

            OpenConnect();
            cmd.ExecuteNonQuery();//Thực thi Stored Procedure trên Database

            //Lấy giá trị từ output parameter @TOTALINCOME
            object res = cmd.Parameters["@TOTALINCOME"].Value;
            if (res != null && res!=DBNull.Value)
            {
                TotalIncome = Convert.ToInt32(res);
            }
            CloseConnect();
            return TotalIncome;
        }

            //END: Xử lý Doanh thu



        //END: Xử lý hành khách/Passenger
        

        public DataTable GetDataTable(string sqls)
        {
            OpenConnect();
            SqlCommand cmd = new SqlCommand(sqls,conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            CloseConnect();
            return dataTable;
        }
        public DataTable ExecuteQuery(string sql, object[] parameter = null)
        {
            OpenConnect();

            SqlCommand cmd = new SqlCommand(sql,conn);

            if(parameter != null)
            {
                string[] listParameter = sql.Split(' ');
                int i = 0;

                foreach(var item in listParameter)
                {
                    if (item.Contains("@"))
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }

            DataTable data = new DataTable();

            SqlDataAdapter ada = new SqlDataAdapter(cmd);

            ada.Fill(data);

            CloseConnect();

            return data;
        }
        public int ExecuteScalar(string sql, object[] parameter = null)
        {
            OpenConnect();
            SqlCommand cmd = new SqlCommand(sql, conn);

            if (parameter != null)
            {
                string[] listParameter = sql.Split(' ');
                int i = 0;

                foreach (var item in listParameter)
                {
                    if (item.Contains("@"))
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            var kq = Convert.ToInt32(cmd.ExecuteScalar());
            CloseConnect();
            return kq;
        }
        public int ExecuteNonQuery(string sql, object[] parameter =null)
        {
            OpenConnect();
            SqlCommand cmd = new SqlCommand(sql, conn);

            if (parameter != null)
            {
                string[] listParameter = sql.Split(' ');
                int i = 0;

                foreach (var item in listParameter)
                {
                    if (item.Contains("@"))
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            int kq = cmd.ExecuteNonQuery();
            CloseConnect();
            return kq;
        }
        //END: Xử lý Database
    }
}

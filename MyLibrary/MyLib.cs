using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DoAnCuoiKy.BusinessClass;
using MyLibrary.BusinessClass;


namespace MyLibrary
{
    public class BanVeXe
    {
        public string constr = "Data Source=FUC;Initial Catalog=DB_DoAnBanVeXe;Integrated Security=True";
        private SqlConnection _conn;
        private string _strConnect, _strServerName, _strDBName, _strUserID, _strPassword;
        DataSet _dataSet = new DataSet();

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
        public string strConnect
        {
            get { return _strConnect; }
            set { _strConnect = value; }
        }
        public string strServerName
        {
            get { return _strServerName; }
            set { _strServerName = value; }
        }
        public string strDBName
        {
            get { return _strDBName; }
            set { _strDBName = value; }
        }
        public string strUserID
        {
            get { return _strUserID; }
            set { _strUserID = value; }
        }
        public string strPassword
        {
            get { return _strPassword; }
            set { _strPassword = value; }
        }
        public BanVeXe()
        {
            strConnect = constr;
            conn = new SqlConnection(strConnect);
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
        //START: Xử lý logic
        public bool CheckUser(Account account)
        {
            //Kiểm tra xem có tồn tại account trong database chưa
            List<Account> accounts = ListAccount.Instance.LstAccount;
            foreach(var acc in accounts)
            {
                if(acc.UserName.Equals(account.UserName) && acc.Password==account.Password)
                    return true;
            }
            return false;
        }
        //END: Xử lý logic

        //START: Xử lý Database


        //START: Xử lý account/tài khoản

        public Account GetAccount(string userName)
        {
            Account account = new Account();
            string sqls = "Select * from UserAccount where Email='"+userName+"'";
            SqlCommand cmd  = new SqlCommand(sqls,conn);
            cmd.CommandType = CommandType.Text;
            OpenConnect();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                account.UserID = rdr.GetInt32(0);
                account.Name = rdr.GetString(1);
                account.UserName = rdr.GetString(2);
                account.Password = rdr.GetString(3);
            }
            return account;
        }

        public List<Account> GetListAccount()
        {
            string sqls = "Select email, password from UserAccount";
            List<Account> list = new List<Account>();
            SqlCommand cmd = new SqlCommand(sqls, conn);
            cmd.CommandType = CommandType.Text;
            OpenConnect();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Account temp = new Account();
                temp.UserName = rdr.GetString(0);
                temp.Password = rdr.GetString(1);
                list.Add(temp);
            }
            return list;
        }

        //END: Xử lý account/tài khoản

        //START:Xử lý Doanh thu
        public int GetIncome(string IncomeDay)
        {
            int TotalIncome = 0;
            string sqls = "Select sum(Total) from OrderTicket where OrderDate =@DayIncome";
            SqlCommand cmd = new SqlCommand(sqls,conn);
            cmd.Parameters.AddWithValue("@DayIncome", IncomeDay);
            cmd.CommandType = CommandType.Text;
            OpenConnect();
            object res= cmd.ExecuteScalar();
            if (res != null)
            {
                TotalIncome = Convert.ToInt32(res);
            }
            CloseConnect();
            return TotalIncome;
        }

        public int GetIncomeTest(string startDay, string endDay, string depLoc, string arrLoc)
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

            // Thêm tham số OUTPUT cho @TOTALINCOME
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

        public List<string> GetListOneColumn(string sqls)
        {
             //Select sum(Total)
             //from OrderTicket OT
             //JOIN DetailsTicket DT ON OT.OrderTicketID = DT.OrderTicketID
             //   JOIN Trip T ON DT.TripID = T.TripID
             //where
             //   OrderDate >= '09/10/2024' and OrderDate<= '10/10/2024'
             //   AND
             //   T.DepartureLocation = 'TP HCM' AND T.ArrivalLocation = 'Da Nang'
            List<string> list = new List<string>();
            SqlCommand cmd = new SqlCommand(sqls, conn);
            cmd.CommandType = CommandType.Text;
            OpenConnect();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(rdr.GetString(0));
            }
            CloseConnect();
            return list;

        }
        

        public SqlDataAdapter GetDataAdapter(string sqls, string tableName){
            OpenConnect();
            SqlDataAdapter da = new SqlDataAdapter(sqls, conn);
            da.Fill(DataSet, tableName);
            CloseConnect();
            return da;
        }
        public DataTable GetDataTable(string sqls, string tableName)
        {
            SqlDataAdapter ada = GetDataAdapter(sqls, tableName);
            return DataSet.Tables[tableName];
        }

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
        //END: Xử lý Database
    }
}

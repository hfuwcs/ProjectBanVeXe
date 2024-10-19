using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DoAnCuoiKy.BusinessClass;
using MyLibrary.BusinessClass;
using System.Globalization;


namespace MyLibrary
{
    public class BanVeXe
    {
        public string constr = "Data Source=FUC;Initial Catalog=DB_DoAnBanVeXe;Integrated Security=True";
        private SqlConnection _conn;
        private string _strConnect, _strServerName, _strDBName, _strUserID, _strPassword;
        DataSet _dataSet = new DataSet();

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
        //Kiểm tra acc đăng nhập đúng tài khoản mật khẩu trong Database không
        public bool CheckUser(Account account)
        {
            //Lấy ra danh sách các tài khoản có trong database
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
            CloseConnect();
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
            CloseConnect();
            return list;
        }

            //END: Xử lý account/tài khoản

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

            //START: Xử lý hành khách/Passenger

        //Lấy thông tin 1 khách hàng bằng SĐT và Email
        public Passenger GetOnePassenger(string phonenumber, string email)
        {
            Passenger passenger = new Passenger();
            string sqls = "SELECT * FROM Passenger where PhoneNumber = @PhoneNumber and Email = @Email";
            SqlCommand cmd = new SqlCommand(sqls,conn);
            cmd.CommandType = CommandType.Text;
            //Truyền giá trị cho tham số
            cmd.Parameters.AddWithValue("@PhoneNumber", phonenumber);
            cmd.Parameters.AddWithValue("@Email", email);

            OpenConnect();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                passenger.PassengerID = rdr.GetInt32(0);
                passenger.PassengerName = rdr.GetString(1);
                passenger.PhoneNumber = rdr.GetString(2);
                passenger.Email = rdr.GetString(3);
            }
            CloseConnect();
            return passenger;            
        }

            //Insert khách hàng vào Database
        public int InsertPassenger(string hoten, string sdt, string email)
        {
            string sqls = "Insert into Passenger VALUES (@FullName, @PhoneNumber ,@Email)";
            SqlCommand cmd =new SqlCommand(sqls,conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@FullName", hoten);
            cmd.Parameters.AddWithValue("@PhoneNumber", sdt);
            cmd.Parameters.AddWithValue ("@Email", email);
            OpenConnect();
            int kt = cmd.ExecuteNonQuery();
            CloseConnect();
            return kt; 
        }


        //END: Xử lý hành khách/Passenger

        //START: Xử lý Vé/Ticket
        public int InsertOrderTicket(int pID, string today)
        {
            string sqls = "Insert into OrderTicket([PassengerID], [Total], [OrderDate], [UserID]) VALUES (@pID, @Total ,@today, @UserID)";
            SqlCommand cmd = new SqlCommand(sqls, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@pID", pID);
            cmd.Parameters.AddWithValue("@PhoneNumber", 0);
            cmd.Parameters.AddWithValue("@Total", 0);
            cmd.Parameters.AddWithValue("@today", today);
            cmd.Parameters.AddWithValue("@UserID", 2);
            OpenConnect();
            int kt = cmd.ExecuteNonQuery();
            CloseConnect();
            return kt;
        }

        public int InsertDetailsTicket(int OrderTicketID, int TripID, int SeatID, int Price)
        {
            string sqls = "INSERT INTO DetailsTicket(OrderTicketID, TripID , SeatID, IsBooked, Price) " +
                            "VALUES(@OrderTicketID,  @TripID, @SeatID, @IsBooked, @Price)";
            SqlCommand cmd = new SqlCommand(sqls, conn);
            cmd.CommandType= CommandType.Text;
            cmd.Parameters.AddWithValue("@OrderTicketID", OrderTicketID);
            cmd.Parameters.AddWithValue("@TripID", TripID);
            cmd.Parameters.AddWithValue("@SeatID", SeatID);
            cmd.Parameters.AddWithValue("@IsBooked", 1);
            cmd.Parameters.AddWithValue("@Price", Price);
            OpenConnect();
            int kt = cmd .ExecuteNonQuery();
            CloseConnect();
            return kt;
        }
        //END: Xử lý Vé/Ticket

        public List<string> GetListOneColumn(string sqls)
        {
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
        //Lấy propety ID thuộc bảng nào đó theo ý muốn
        public int GetOneID(string sqls)
        {
            int ID = -1;
            SqlCommand cmd =new SqlCommand(sqls, conn);
            cmd.CommandType = CommandType.Text;
            OpenConnect();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ID = rdr.GetInt32(0);
            }
            CloseConnect() ;
            return ID;
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

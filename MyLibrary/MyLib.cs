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
        public string constr = "Data Source=FUC;Initial Catalog=DB_DoAnBanVeXe2;Integrated Security=True";
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
                if(acc.UserName.Equals(account.UserName.ToLower()) && acc.Password==account.Password)
                    return true;
            }
            return false;
        }
        //END: Xử lý logic

        //START: Xử lý Database
            //START: Xử lý account/tài khoản

        //Lấy Tài khoản bằng ID
        public Account GetAccount(int id)
        {
            Account account = new Account();
            string sqsl = "Select * from UserAccount where UserID = @userid";
            SqlCommand cmd = new SqlCommand(sqsl,conn);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@userid", id);

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
           
        //Lấy Tài khoản bằng tên đăng nhập

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

        //Lấy danh sách Tài khoản
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
        
        //Lấy RoleName
        public string GetRoleName(int userid)
        {
            string sqls = "SELECT RoleName from Roles R INNER JOIN UserRoles UR ON R.RolesID = UR.RoleID INNER JOIN UserAccount UA ON UR.UserID = UA.UserID WHERE UA.UserID = @userid";
            string str = string.Empty;
            SqlCommand cmd = new SqlCommand(sqls, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@userid",userid);
            OpenConnect();
            str = cmd.ExecuteScalar().ToString();
            CloseConnect();
            return str;
        }
        
        public int GetIDRole(int userid)
        {
            int roleid = 0;
            string sqlGetIDRole = "SELECT RoleID from UserRoles where userid = @userid";
            SqlCommand cmd = new SqlCommand(sqlGetIDRole, conn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@userid", userid);

            OpenConnect();
            roleid = Convert.ToInt32(cmd.ExecuteScalar());
            CloseConnect() ;

            return roleid;
        }


        //Đổi mật khẩu
        public int ChangePassword(int userid, string newPassword)
        {          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.DOIMATKHAU";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            // Thêm các tham số cho stored procedure
            cmd.Parameters.AddWithValue("@NEWPASS", newPassword);
            cmd.Parameters.AddWithValue("@USERID", userid);

            OpenConnect();
            int kt = cmd.ExecuteNonQuery();
            CloseConnect();
            
            //Nếu kt = 1 có nghĩa là có 1 dòng bị ảnh hưởng (row affected) => đã cập nhật thành công mật khẩu
            //Nếu kt = 0 là ngược lại
            return kt;
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

            //Truyền tham số
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

        //Insert Hóa đơn vào OrderTicket
        public int InsertOrderTicket(int pID, string today,int userID)
        {
            string sqls = "Insert into OrderTicket([PassengerID], [Total], [OrderDate], [UserID]) VALUES (@pID, @Total ,@today, @UserID)";
            SqlCommand cmd = new SqlCommand(sqls, conn);
            cmd.CommandType = CommandType.Text;

            //Truyền tham số
            cmd.Parameters.AddWithValue("@pID", pID);
            cmd.Parameters.AddWithValue("@Total", 0);
            cmd.Parameters.AddWithValue("@today", today);
            cmd.Parameters.AddWithValue("@UserID", userID);
            OpenConnect();
            int kt = cmd.ExecuteNonQuery();
            CloseConnect();
            return kt;
        }

        //Insert Vé  vào Bảng DetailsTicket
        public int InsertDetailsTicket(int OrderTicketID, int TripID, int SeatID, int Price)
        {
            string sqls = "INSERT INTO DetailsTicket(OrderTicketID, TripID , SeatID, IsBooked, Price) " +
                            "VALUES(@OrderTicketID,  @TripID, @SeatID, @IsBooked, @Price)";
            SqlCommand cmd = new SqlCommand(sqls, conn);
            cmd.CommandType= CommandType.Text;

            //Truyền tham số
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

        //Get Databale Tra cứu vé
        public DataTable GetDataTable(string sdt, string dpt, string tableName)
        {
            // Xây dựng câu truy vấn gọi hàm TRACUUVE trong Database
            string sqls = "SELECT * FROM dbo.TRACUUVE(@SDT, @DPT)";

            // Tạo SqlCommand để thêm tham số
            SqlCommand cmd = new SqlCommand(sqls, conn);
            cmd.Parameters.AddWithValue("@SDT", sdt);
            cmd.Parameters.AddWithValue("@DPT", dpt);

            OpenConnect();

            // Tạo SqlDataAdapter từ SqlCommand
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(DataSet, tableName);

            CloseConnect();

            return DataSet.Tables[tableName];
        }

        //END: Xử lý Vé/Ticket

        //Xử lý Bus
        public DataTable GetBus(List<int> readyBuses, string tableName)
        {
            // Trả về null hoặc DataTable rỗng nếu không có Bus ID
            if (readyBuses == null || readyBuses.Count == 0)
            {
                return null; 
            }

            // Tạo danh sách các tham số để sử dụng trong câu truy vấn
            List<string> parameters = new List<string>();
            for (int i = 0; i < readyBuses.Count; i++)
            {
                parameters.Add($"@busid{i}"); // Tạo tham số như @busid0, @busid1,...
            }

            //Phải đặt dấu $ thì nó mới cho điền hàm vào
            //Kiểu như Ajax
            string sqls = $"SELECT * FROM TRIP WHERE BusID IN ({string.Join(", ", parameters)}) AND DATEDIFF(HOUR, GETDATE(), ArrivalTime) > 0";

            SqlCommand cmd = new SqlCommand(sqls, conn);

            // Thêm các tham số với giá trị tương ứng
            for (int i = 0; i < readyBuses.Count; i++)
            {
                cmd.Parameters.AddWithValue($"@busid{i}", readyBuses[i]);
            }

            OpenConnect();

            // Tạo SqlDataAdapter để thực thi câu lệnh SQL
            SqlDataAdapter ada = new SqlDataAdapter(cmd);

            DataSet dataSet = new DataSet();

            ada.Fill(dataSet, tableName);

            return dataSet.Tables[tableName];
        }


        public List<string> GetListOneColumn(string sqlstring)
        {
            List<string> list = new List<string>();
            SqlCommand cmd = new SqlCommand(sqlstring, conn);
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

        public List<int> GetListIntOneColumn(string slqint)
        {
            List<int> list = new List<int>();
            SqlCommand cmd = new SqlCommand(slqint, conn);
            cmd.CommandType = CommandType.Text;
            OpenConnect();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(rdr.GetInt32(0));
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
            ID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            CloseConnect() ;
            return ID;
        }

        public string GetOndPropChar(string sqls)
        {
            string str = string.Empty;
            SqlCommand cmd = new SqlCommand(sqls,conn);
            cmd.CommandType = CommandType.Text;
            OpenConnect();
            str = cmd.ExecuteScalar().ToString();
            CloseConnect();
            return str;
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

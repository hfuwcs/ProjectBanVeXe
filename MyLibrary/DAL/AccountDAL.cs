using MyLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL
{
    public class AccountDAL
    {
        private static AccountDAL instance;//Khai báo Instance để các Class khác có thể truy cập
        DbContext db = new DbContext();
        public static AccountDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAL();//Gán instance bằng List accounts mới
                }
                return instance;
            }
            set => instance = value;
        }

        public bool isLogin(Account account)
        {
            string sqls = "EXEC IsLogin @USERNAME , @PASSWORD";
            DataTable dataTable = db.Instance.ExecuteQuery(sqls, new object[] { account.UserName, account.Password });
            return dataTable.Rows.Count > 0;
        }
        public bool IsAdmin(Account account)
        {
            string sqls = "EXEC IsAdmin @USERNAME , @PASSWORD";
            DataTable dataTable = db.Instance.ExecuteQuery(sqls, new object[] { account.UserName, account.Password });
            return dataTable.Rows.Count > 0;
        }

        public List<Account> GetListAccount()
        {
            string sqls = "Select * from UserAccount";
            List<Account> list = new List<Account>();
            DataTable dataTable = db.Instance.ExecuteQuery(sqls);
            foreach (DataRow row in dataTable.Rows)
            {
                Account account = new Account();
                account.UserID = Convert.ToInt32(row["UserID"].ToString());
                account.Name = row["FullName"].ToString();
                account.UserName = row["Email"].ToString();
                account.Password = row["Password"].ToString();
                list.Add(account);
            }
            return list;
        }

        //Lấy Tài khoản bằng UserName
        public Account GetAccount(string userName)
        {
            Account account = new Account();
            string sqls = "EXEC GetUserByUsername @username ";
            DataTable dataTable = db.Instance.ExecuteQuery(sqls, new object[] { userName });
            foreach (DataRow row in dataTable.Rows) {
                account.UserID = Convert.ToInt32(row["UserID"].ToString());
                account.Name = row["FullName"].ToString();
                account.UserName = row["Email"].ToString();
                account.Password = row["Password"].ToString();
                return account;
            } 
            return null;
        }

        public Account GetAccount(int userid)
        {
            Account account = new Account();
            string sqls = "EXEC GetUserByUserID @userid ";
            DataTable dataTable = db.Instance.ExecuteQuery(sqls, new object[] { userid });
            foreach (DataRow row in dataTable.Rows)
            {
                account.UserID = Convert.ToInt32(row["UserID"].ToString());
                account.Name = row["FullName"].ToString();
                account.UserName = row["Email"].ToString();
                account.Password = row["Password"].ToString();
                return account;
            }
            return null;
        }
        public string GetRoleName(int userid)
        {
            string sqls = "EXEC GetRoleName @USERID";
            string str = string.Empty;
            DataTable data = db.Instance.ExecuteQuery(sqls, new object[] { userid });
            foreach(DataRow row in data.Rows)
            {
                return row["RoleName"].ToString();
            }
            return null;
        }

        public void ChangePassword( string password, int userid)
        {
            string sqls = "EXEC DOIMATKHAU @NEWPASS , @USERID";
            db.Instance.ExecuteNonQuery(sqls, new object[] { password, userid });
        }
    }
}

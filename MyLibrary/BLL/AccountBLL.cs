using MyLibrary.DTO;
using MyLibrary.DAL;
using MyLibrary.BusinessClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL
{
    public class AccountBLL
    {
        private static AccountBLL instance;//Khai báo Instance để các Class khác có thể truy cập
        public static AccountBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountBLL();//Gán instance bằng List accounts mới
                }
                return instance;
            }
            set => instance = value;
        }
        public bool IsLogin(Account account)
        {
            return AccountDAL.Instance.isLogin(account);
        }
        public bool IsAdmin(Account account)
        {
            return AccountDAL.Instance.IsAdmin(account);
        }
        public List<Account> GetListAccount()
        {
            return AccountDAL.Instance.GetListAccount();
        }
        public Account GetAccount(string username) { 
            return AccountDAL.Instance.GetAccount(username);
        }
        public Account GetAccount(int userid)
        {
            return AccountDAL.Instance.GetAccount(userid);
        }
        public string GetRoleName(int userid)
        {
            return AccountDAL.Instance.GetRoleName(userid);
        }
        public void ChangePassword(string password, int userid)
        {
            AccountDAL.Instance.ChangePassword(password, userid);
        }

    }
}

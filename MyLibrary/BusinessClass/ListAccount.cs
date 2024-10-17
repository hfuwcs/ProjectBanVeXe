using DoAnCuoiKy.BusinessClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BusinessClass
{
    public class ListAccount
    {
        private static ListAccount instance;//Khai báo Instance để các Class khác có thể truy cập
        BanVeXe db = new BanVeXe();
        List<Account> lstAccount;

        public List<Account> LstAccount { get => lstAccount; set => lstAccount = value; }
        public static ListAccount Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ListAccount();//Gán instance bằng List accounts mới
                }
                return instance;
            }
            set=>instance = value;
        }

        public ListAccount() {
            lstAccount = db.GetListAccount();
        }

    }
}

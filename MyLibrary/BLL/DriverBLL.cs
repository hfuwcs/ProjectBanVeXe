using MyLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL
{
    public class DriverBLL
    {

        private static DriverBLL instance;
        DbContext db = new DbContext();

        public static DriverBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DriverBLL();
                return instance;
            }
            private set => instance = value;
        }
        public List<int> GetReadyDriverID(string today)
        {
            return DriverDAL.Instance.GetReadyDriverID(today);
        }
    }
}

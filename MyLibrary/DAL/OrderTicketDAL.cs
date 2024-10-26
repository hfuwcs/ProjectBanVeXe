using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL
{
    internal class OrderTicketDAL
    {
        private static OrderTicketDAL instance;
        DbContext db = new DbContext();

        internal static OrderTicketDAL Instance { 
            get { 
               if (instance == null)
                    instance = new OrderTicketDAL();
               return instance;
            }
            set => instance = value; 
        }
        public int GetLatestOrderID(string orderDate, int passengerID)
        {
            string sqls = "EXEC GetLatestOrderID @ORDERDATE , @PASSENGERID";
            int res = Convert.ToInt32(db.ExecuteScalar(sqls, new object[] { orderDate, passengerID }));
            return res;
        }
        public void InsertOrderTicket(int pID, string today, int userID)
        {
            string sqls = "EXEC InsertOrderTicket @pID , @ORDERDATE , @userID";
            db.Instance.ExecuteNonQuery(sqls, new object[] { pID, today, userID });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL
{
    internal class DetailsTicketDAL
    {
        private static DetailsTicketDAL instance;
        DbContext db = new DbContext();

        public static DetailsTicketDAL Instance {
            get { 
                if (instance == null)
                    instance = new DetailsTicketDAL();
                return instance;
            } 
            private set => instance = value; 
        }
        public int HUYVE(int OrderTicketID)
        {
            string sqls = "UPDATE DetailsTicket " +
                "SET IsBooked = 0 " +
                "WHERE OrderTicketID = @OrderTicketID ";
            int res = db.ExecuteNonQuery(sqls, new object[] { OrderTicketID });
            return res;
        }
        public void InsertDetailsTicket(int OrderTicketID, int TripID, int SeatID, int IsBooked, int Price)
        {
            string sqls = "EXEC InsertDetailsTicket @OrderTicketID , @TripID , @SeatID , @IsBooked , @PRICE ";
            db.ExecuteNonQuery(sqls, new object[] { OrderTicketID , TripID , SeatID, IsBooked, Price });
        }
        public DataTable TRACUUVE(string sdt, string dpt)
        {
            string sqls = "SELECT * FROM dbo.TRACUUVE( @SDT , @DPT )";
            DataTable data = db.ExecuteQuery(sqls, new object[] { sdt, dpt });
            return data;
        }
    }
}

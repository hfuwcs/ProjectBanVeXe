using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.DTO;

namespace MyLibrary.DAL
{
    internal class BusDAL
    {
        private static BusDAL instance;
        DbContext db = new DbContext();
        internal static BusDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new BusDAL();
                return instance;
            }
            set => instance = value;
        }
        public List<string> GetListBookedSeat(int tripID)
        {
            List<string> list = new List<string>();
            string sqls = "select SeatNumber from Seat S, DetailsTicket DT Where S.SeatID=DT.SeatID and TRIPID = @tripid";
            DataTable data = db.ExecuteQuery(sqls, new object[] {tripID});
            foreach (DataRow row in data.Rows)
            {
                list.Add(row["SeatNumber"].ToString());
            }
            return list;
        }
        public DataTable GetBusReady(string deppTime, string arrTime)
        {
            string sqls = "EXEC GETREADYBUS @deppTime , @arrTime ";
            DataTable data = db.ExecuteQuery(sqls,new object[] { deppTime , arrTime});
            return data;
        }
        public List<int> GetBusIDReady(string deppTime, string arrTime) {
            DataTable data = GetBusReady(deppTime, arrTime);
            List<int> list = new List<int>();
            foreach (DataRow row in data.Rows)
            {
                list.Add(Convert.ToInt32(row["Mã xe"]));
            }
            return list;
        }
    }
}

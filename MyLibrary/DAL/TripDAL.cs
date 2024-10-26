using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.DTO;
using static System.Net.Mime.MediaTypeNames;

namespace MyLibrary.DAL
{
    internal class TripDAL
    {
        private static TripDAL instance;
        DbContext db = new DbContext();

        internal static TripDAL Instance { 
            get { 
                if (instance == null)
                    instance = new TripDAL();
                return instance;
            }
            set => instance = value; 
        }
        public DataTable SearchTrip(string deploc, string arrloc, string selectedday)
        {
            string sqls = "EXEC TIMCHUYENXE @DEPLOC , @ARRLOC , @SECLECTEDDAY";
            DataTable data = db.Instance.ExecuteQuery(sqls, new object[] { deploc, arrloc, selectedday });
            return data;
        }
        public int GetTripID(string deppLoc, string arrLoc, string deppDate)
        {
            string sqlTripID = $"SELECT TripID FROM Trip WHERE DepartureLocation = '{deppLoc}' AND ArrivalLocation = '{arrLoc}' AND DepartureTime = '{deppDate}'";
            int id = db.Instance.ExecuteScalar(sqlTripID);
            return id;
        }
        public int InsertTrip(int routeid, int busid, int driverid, string depploc, string arrloc, string depptime, string arrtime)
        {
            int res = 0;
            string sqls = "EXEC InsertTrip @RouteID , @BusID , @DriverID , @DeppLoc , @ArrLoc , @DeppTime , @ArrTime";
            
            res = db.ExecuteNonQuery(sqls, new object[] { routeid, busid, driverid, depploc, arrloc, depptime, arrtime });
            return res;
        }
    }
}

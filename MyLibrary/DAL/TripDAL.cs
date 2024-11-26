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
        public DataTable SearchTrip(string deploc, string arrloc, DateTime selectedday)
        {
            string sqls = "EXEC TIMCHUYENXE @DEPLOC , @ARRLOC , @SECLECTEDDAY";
            DataTable data = db.Instance.ExecuteQuery(sqls, new object[] { deploc, arrloc, selectedday });
            return data;
        }
        public int GetTripID(string deppLoc, string arrLoc, DateTime deppDateA)
        {
            string deppDate = deppDateA.ToString("yyyy-MM-dd HH:mm:ss");
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

        public Trip GetTripByID(int tripID)
        {
            string sqls = $"SELECT * FROM Trip WHERE TripID = {tripID}";
            DataTable data = db.GetDataTable(sqls);
            Trip trip = new Trip();
            foreach (DataRow dr in data.Rows)
            {
                trip.tripID = int.Parse(dr["TripID"].ToString());
                trip._routeID = int.Parse(dr["RouteID"].ToString());
                trip._busID = int.Parse(dr["BusID"].ToString());
                trip._driverID = int.Parse(dr["DriverID"].ToString());
                trip._departureLocation = dr["DepartureLocation"].ToString();
                trip._arrivalLocation = dr["ArrivalLocation"].ToString();
                trip._departureLocation = dr["DepartureTime"].ToString();
                trip._arrivalLocation = dr["ArrivalTime"].ToString();
            }
            return trip;
        }
    }
}

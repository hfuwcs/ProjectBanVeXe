using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.DAL;
using MyLibrary.DTO;
namespace MyLibrary.BLL
{
    public class TripBLL
    {
        private static TripBLL instance;
        DbContext db = new DbContext();

        public static TripBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TripBLL();
                return instance;
            }
            private set => instance = value;
        }
        public DataTable SearchTrip(string deploc, string arrloc, DateTime selectedday)
        {
            string sqls = "EXEC TIMCHUYENXE @DEPLOC , @ARRLOC , @SECLECTEDDAY";
            DataTable data = db.Instance.ExecuteQuery(sqls, new object[] { deploc, arrloc, selectedday });
            return data;
        }
        public int GetTripID(string deppLoc, string arrLoc, DateTime deppDate)
        {
            return TripDAL.Instance.GetTripID(deppLoc, arrLoc, deppDate);
        }
        public int InsertTrip(int routeid, int busid, int driverid, string depploc, string arrloc, string depptime, string arrtime)
        {
            return TripDAL.Instance.InsertTrip(routeid, busid, driverid, depploc, arrloc, depptime, arrtime);
        }
        public Trip GetTripByID(int tripID)
        {
            return TripDAL.Instance.GetTripByID(tripID);
        }
    }
}

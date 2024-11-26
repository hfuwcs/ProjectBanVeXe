using MyLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL
{
    public class BusBLL
    {
        private static BusBLL instance;
        public static BusBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new BusBLL();
                return instance;
            }
            private set => instance = value;
        }
        public BusBLL() { }
        public List<string> GetListBookedSeat(int tripID)
        {
            return BusDAL.Instance.GetListBookedSeat(tripID);
        }
        public DataTable GetBusReady(string deppTime, string arrTime)
        {
            return BusDAL.Instance.GetBusReady(deppTime, arrTime);
        }
        public List<int> GetBusIDReady(string deppTime, string arrTime)
        {
            return BusDAL.Instance.GetBusIDReady(deppTime, arrTime);
        }
    }
}

using MyLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL
{
    public class DetailsTicketBLL
    {
        private static DetailsTicketBLL instance;
        public static DetailsTicketBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new DetailsTicketBLL();
                return instance;
            }
            private set => instance = value;
        }
        public void InsertDetailsTicket(int OrderTicketID, int TripID, int SeatID, int IsBooked, int Price)
        {
            DetailsTicketDAL.Instance.InsertDetailsTicket(OrderTicketID, TripID, SeatID, IsBooked, Price);
        }
        public DataTable TRACUUVE(string sdt, string dpt)
        {
            return DetailsTicketDAL.Instance.TRACUUVE(sdt, dpt);
        }
    }
}

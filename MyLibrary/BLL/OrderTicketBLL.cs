using MyLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL
{
    public class OrderTicketBLL
    {
        private static OrderTicketBLL instance;

        public static OrderTicketBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new OrderTicketBLL();
                return instance;
            }
            private set => instance = value;
        }
        public int GetLatestOrderID(string orderDate, int passengerID)
        {
            return OrderTicketDAL.Instance.GetLatestOrderID(orderDate, passengerID);
        }
        public void InsertOrderTicket(int pID, string today, int userID)
        {
            OrderTicketDAL.Instance.InsertOrderTicket(pID, today, userID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    internal class OrderTicket
    {
        private int _orderTicketID;
        private int _passengerID;
        private Decimal _totalIncome;
        private string _orderDate;
        private int _userID;

        public int OrderTicketID { get => _orderTicketID; set => _orderTicketID = value; }
        public int PassengerID { get => _passengerID; set => _passengerID = value; }
        public decimal TotalIncome { get => _totalIncome; set => _totalIncome = value; }
        public string OrderDate { get => _orderDate; set => _orderDate = value; }
        public int UserID { get => _userID; set => _userID = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    [Table("OrderTicket")]
    public class OrderTicket
    {
        private int _orderTicketID;
        private int _passengerID;
        private Decimal _totalIncome;
        private DateTime _orderDate;
        private int _userID;

        [Column("OrderTicketID",true)]
        public int OrderTicketID { get => _orderTicketID; set => _orderTicketID = value; }
        [Column("PassengerID")]
        public int PassengerID { get => _passengerID; set => _passengerID = value; }
        [Column("Total")]
        public decimal TotalIncome { get => _totalIncome; set => _totalIncome = value; }
        [Column("OrderDate")]
        public DateTime OrderDate { get => _orderDate; set => _orderDate = value; }
        [Column("UserID")]
        public int UserID { get => _userID; set => _userID = value; }
    }
}

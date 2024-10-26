using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    internal class DetailsTicket
    {
        private int _detailsTicketID;
        private int _orderTicketID;
        private int _tripID;
        private int _seatID;
        private int _isBooked;
        private decimal _price;

        public int DetailsTicketID { get => _detailsTicketID; set => _detailsTicketID = value; }
        public int OrderTicketID { get => _orderTicketID; set => _orderTicketID = value; }
        public int TripID { get => _tripID; set => _tripID = value; }
        public int SeatID { get => _seatID; set => _seatID = value; }
        public int IsBooked { get => _isBooked; set => _isBooked = value; }
        public decimal Price { get => _price; set => _price = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    internal class Seat
    {
        private int _seadID;
        private int _busID;
        private string _seatNumber;

        public int SeadID { get => _seadID; set => _seadID = value; }
        public int BusID { get => _busID; set => _busID = value; }
        public string SeatNumber { get => _seatNumber; set => _seatNumber = value; }
    }
}

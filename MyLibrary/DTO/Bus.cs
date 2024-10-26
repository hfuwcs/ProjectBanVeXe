using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    internal class Bus
    {
        private int _busID;
        private string _busNumber;
        private int _totalSeat;
        private string _busType;

        public int BusID { get => _busID; set => _busID = value; }
        public string BusNumber { get => _busNumber; set => _busNumber = value; }
        public int TotalSeat { get => _totalSeat; set => _totalSeat = value; }
        public string BusType { get => _busType; set => _busType = value; }
    }
}

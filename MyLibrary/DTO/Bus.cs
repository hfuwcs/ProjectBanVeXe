using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    [Table("Bus")]
    public class Bus
    {
        private int _busID;
        private string _busNumber;
        private int _totalSeat;
        private string _busType;

        [Column("BusID", true, true)]
        public int BusID { get => _busID; set => _busID = value; }
        [Column("BusNumber")]
        public string BusNumber { get => _busNumber; set => _busNumber = value; }
        [Column("TotalSeat")]
        public int TotalSeat { get => _totalSeat; set => _totalSeat = value; }
        [Column("BusType")]
        public string BusType { get => _busType; set => _busType = value; }
    }
}

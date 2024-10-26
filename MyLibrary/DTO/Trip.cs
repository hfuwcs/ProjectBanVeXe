using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    internal class Trip
    {
        private int _tripID;
        private int _routeID;
        private int _busID;
        private int? _driverID;
        private string _departureLocation;
        private string _arrivalLocation;
        private string _departureTime;
        private string _arrivalTime;
    }
}

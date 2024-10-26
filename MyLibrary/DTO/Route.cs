using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    public class Route
    {
        private int _routeID;
        private string _routeName;
        private string _startLocation;
        private string _endLocation;
        private int _distance;

        public int RouteID { get => _routeID; set => _routeID = value; }
        public string RouteName { get => _routeName; set => _routeName = value; }
        public string StartLocation { get => _startLocation; set => _startLocation = value; }
        public string EndLocation { get => _endLocation; set => _endLocation = value; }
        public int Distance { get => _distance; set => _distance = value; }
    }
}

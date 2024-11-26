using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyLibrary.DTO
{
    [Table("Trip")]
    public class Trip
    {
        [Column("TripID", true, true)]
        public int tripID { get; set; }
        [Column("RouteID")]
        public int _routeID { get; set; }
        [Column("BusID")]
        public int _busID { get; set; }
        [Column("DriverID")]
        public int _driverID { get; set; }
        [Column("DepartureLocation")]
        public string _departureLocation { get; set; }
        [Column("ArrivalLocation")]
        public string _arrivalLocation { get; set; }
        [Column("DepartureTime")]
        public DateTime _departureTime { get; set; }
        [Column("ArrivalTime")]
        public DateTime _arrivalTime { get; set; }
    }
}

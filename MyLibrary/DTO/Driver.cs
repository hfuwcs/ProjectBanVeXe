using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    internal class Driver
    {
        private string _driverID;
        private string _driverName;
        private string _licenseNumber;
        private string _phoneNumber;

        public string DriverID { get => _driverID; set => _driverID = value; }
        public string DriverName { get => _driverName; set => _driverName = value; }
        public string LicenseNumber { get => _licenseNumber; set => _licenseNumber = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    public class Passenger
    {
        private int _passengerID;
        private string _name;
        private string _phoneNumber;
        private string _email;

        public int PassengerID { get => _passengerID; set => _passengerID = value; }
        public string Name { get => _name; set => _name = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Email { get => _email; set => _email = value; }
        public Passenger() { }
    }
}

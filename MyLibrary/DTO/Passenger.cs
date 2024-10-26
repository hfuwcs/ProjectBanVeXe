using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BusinessClass
{
    public class Passenger
    {
        int _passengerID;
        string _name;
        string _phoneNumber;
        string _email;

        public int PassengerID { get => _passengerID; set => _passengerID = value; }
        public string Name { get => Name; set => Name = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Email { get => _email; set => _email = value; }

    }
}

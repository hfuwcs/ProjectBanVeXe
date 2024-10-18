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
        string _passengerName;
        string _phoneNumber;
        string _email;

        public int PassengerID { get => _passengerID; set => _passengerID = value; }
        public string PassengerName { get => _passengerName; set => _passengerName = value; }
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public string Email { get => _email; set => _email = value; }

    }
}

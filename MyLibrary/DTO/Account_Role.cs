using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    internal class Account_Role
    {
        private int _userID;
        private string _name;
        private string userName;
        private string cccd;
        private string role;

        public int UserID { get => _userID; set => _userID = value; }
        public string Name { get => _name; set => _name = value; }
        public string UserName { get => userName; set => userName = value; }
        public string CCCD { get => cccd; set => cccd = value; }
        public string Role { get => role; set => role = value; }
        public Account_Role() { }
    }
}

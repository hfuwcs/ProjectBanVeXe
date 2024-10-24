using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DTO
{
    public class Account
    {
        private int _userID;
        private string _name;
        private string userName;
        private string password;

        public int UserID { get => _userID; set => _userID = value; }
        public string Name { get => _name; set => _name = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }

        public Account() { }

        public Account(string username, string password) {
            this.UserName = username;
            this.Password = password;
        }
    }
}

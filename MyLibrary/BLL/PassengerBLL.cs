using MyLibrary.DTO;
using MyLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL
{
    public class PassengerBLL
    {
        private static PassengerBLL instance;
        public static PassengerBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PassengerBLL();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        public int InsertPassenger(string hoten, string sdt, string email)
        {
            return PassengerDAL.Instance.InsertPassenger(hoten, sdt, email);
        }
        public Passenger GetOnePassenger(string phonenumber, string email)
        {
            return PassengerDAL.Instance.GetOnePassenger(phonenumber, email);
        }
    }
}

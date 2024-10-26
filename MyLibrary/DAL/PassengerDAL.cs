using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL
{
    public class PassengerDAL
    {
        private PassengerDAL instance;

        public PassengerDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PassengerDAL();
                return instance;
            }
            set
            {
                instance = value;
            }
        }


    }
}

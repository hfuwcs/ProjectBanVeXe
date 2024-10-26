using MyLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL
{
    internal class SeatDAL
    {
        private static SeatDAL instance;
        public static SeatDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SeatDAL();//Gán instance bằng List accounts mới
                }
                return instance;
            }
            set => instance = value;
        }
        //public Seat GetSeat(string seatNumber, int busID) {
            
        //}
    }
}

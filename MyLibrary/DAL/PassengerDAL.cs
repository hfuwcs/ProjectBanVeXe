using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.DTO;

namespace MyLibrary.DAL
{
    public class PassengerDAL
    {
        private static PassengerDAL instance;
        DbContext db = new DbContext();

        public static PassengerDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new PassengerDAL();
                return instance;
            }
           private set => instance = value; 
        }

        public int InsertPassenger(string hoten, string sdt, string email)
        {
            int kt = 0;
            string sqls = "Insert into Passenger VALUES ( @FullName , @PhoneNumber , @Email )";
            kt = db.Instance.ExecuteNonQuery(sqls, new object[] {hoten, sdt , email});
            return kt;
        }
        public Passenger GetOnePassenger(string phonenumber, string email)
        {
            Passenger passenger = new Passenger();
            string sqls = "SELECT * FROM Passenger where PhoneNumber = @PhoneNumber and Email = @Email";
            DataTable data = db.ExecuteQuery(sqls, new object[] { phonenumber , email });
            foreach (DataRow row in data.Rows) { 
                passenger.PassengerID = Convert.ToInt32(row["PassengerID"]);
                passenger.Name = row["FullName"].ToString();
                passenger.PhoneNumber = row["PhoneNumber"].ToString();
                passenger.Email = row["Email"].ToString();
            }
            return passenger;
        }
    }
}

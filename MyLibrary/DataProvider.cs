using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class DataProvider
    {
        private static DataProvider instance;

        public DataProvider Instance
        {
            get { if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance; 
                }
            private set { instance = value; }
        }
    }
}

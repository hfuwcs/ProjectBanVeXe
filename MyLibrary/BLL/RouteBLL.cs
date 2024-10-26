using MyLibrary.DAL;
using MyLibrary.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BLL
{
    public class RouteBLL
    {
        private static RouteBLL instance;
        DbContext db = new DbContext();

        public static RouteBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new RouteBLL();
                return instance;
            }
            private set => instance = value;
        }
        public Route GetRoute(string start, string end)
        {
            return RouteDAL.Instance.GetRoute(start, end);
        }
        public Route GetRouteByName(string name)
        {
            return RouteDAL.Instance.GetRouteByName(name);
        }
    }
}

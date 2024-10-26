using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.DTO;

namespace MyLibrary.DAL
{
    internal class RouteDAL
    {
        private static RouteDAL instance;
        DbContext db = new DbContext();

        public static RouteDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new RouteDAL();
                return instance;
            }
            private set => instance = value;
        }
        public Route GetRoute(string start, string end)
        {
            Route route = new Route();
            string sqls = $"SELECT * FROM ROUTE WHERE StartLocation = '{start}' AND EndLocation = '{end}'";
            DataTable data = db.ExecuteQuery(sqls);
            foreach (DataRow row in data.Rows) { 
                route.RouteID = Convert.ToInt32(row["RouteID"]);
                route.RouteName = row["RouteName"].ToString();
                route.StartLocation = row["StartLocation"].ToString();
                route.EndLocation = row["EndLocation"].ToString();
                route.Distance = Convert.ToInt32(row["Distance"]);
            }
            return route;
        }
        public Route GetRouteByName(string name)
        {
            Route route = new Route();
            string sqls = $"SELECT * FROM ROUTE WHERE RouteName = '{name}'";
            DataTable data = db.ExecuteQuery(sqls);
            foreach (DataRow row in data.Rows)
            {
                route.RouteID = Convert.ToInt32(row["RouteID"]);
                route.RouteName = row["RouteName"].ToString();
                route.StartLocation = row["StartLocation"].ToString();
                route.EndLocation = row["EndLocation"].ToString();
                route.Distance = Convert.ToInt32(row["Distance"]);
            }
            return route;
        }
    }
}

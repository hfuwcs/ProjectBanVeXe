using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

using System.Data;
using System.Data.SqlClient;
using MyLibrary.DTO;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;


namespace MyLibrary
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public string Name { get; set; }

        public TableAttribute(string name)
        {
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsIdentity { get; set; }

        public ColumnAttribute(string name, bool isPrimaryKey = false, bool isIdentity = false)
        {
            Name = name;
            IsPrimaryKey = isPrimaryKey;
            IsIdentity = isIdentity;
        }
    }
    public class DbContext
    {
        SqlConnection _conn;
        DataSet _dataSet = new DataSet();
        public enum ConnectionType
        {
            ConnectionString,
            ConfigurationManager
        }

        private DbContext instance;
        public DbContext Instance { 
        get { if (instance == null) { 
                instance = new DbContext();
                }
                return instance; 
            }
        set { instance = value; }
        }
        public DbContext()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        //Khai báo format currency cho tiền VN
        public NumberFormatInfo nfi = new CultureInfo("vi-VN", false).NumberFormat;

        public DataSet DataSet
        {
            get { return _dataSet; }
            set { _dataSet = value; }
        }

        public SqlConnection conn
        {
            get { return _conn; }
            set { _conn = value; }
        } 

        public void OpenConnect()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }
        public void CloseConnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public void DiposeConnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Dispose();
        }


        //Generic Method
        public DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            DataTable table = new DataTable();
            if (data == null || !data.Any())
                return table;

            // Lấy thông tin thuộc tính từ kiểu T
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                table.Columns.Add(property.Name, property.PropertyType);
            }

            // Thêm dữ liệu vào DataTable
            foreach (var item in data)
            {
                DataRow row = table.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
        }


        public IEnumerable<T> GetTable<T>(Func<T, bool> predicate = null)
        {
            List<T> result = new List<T>();
            Type type = typeof(T);
            TableAttribute tableAttr = (TableAttribute)type.GetCustomAttribute(typeof(TableAttribute));
            if (tableAttr == null)
                return result;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {tableAttr.Name}";
            cmd.CommandType = CommandType.Text;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                PropertyInfo[] properties = type.GetProperties();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    T curr = (T)Activator.CreateInstance(typeof(T));
                    foreach (PropertyInfo property in properties)
                    {
                        var columnAttr = (ColumnAttribute)property.GetCustomAttribute(typeof(ColumnAttribute));
                        if (columnAttr == null)
                            continue;
                        string column = columnAttr.Name;
                        object pValue = reader[column];
                        if (string.IsNullOrEmpty(column) || string.IsNullOrEmpty(pValue?.ToString()))
                            continue;
                        property.SetValue(curr, pValue, null);
                    }

                    if (predicate != null)
                    {
                        if (predicate(curr))
                            result.Add(curr);
                    }
                    else
                        result.Add(curr);
                }
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public bool InsertRow<T>(T data)
        {
            bool result = false;
            if (data == null)
                return result;
            Type type = typeof(T);
            TableAttribute tableAttr = (TableAttribute)type.GetCustomAttribute(typeof(TableAttribute));
            if (tableAttr == null)
                return result;
            List<string> keys = new List<string>();
            List<object> values = new List<object>();

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                ColumnAttribute columnAttr = (ColumnAttribute)property.GetCustomAttribute(typeof(ColumnAttribute));
                if (columnAttr == null || columnAttr.IsIdentity)
                    continue;
                object value = property.GetValue(data, null);
                if (value == null || value.ToString().Length == 0)
                    continue;
                Type pType = property.PropertyType;
                if (pType == typeof(int) || pType == typeof(float) || pType == typeof(double))
                    values.Add(value);
                else if (pType == typeof(DateTime))
                {
                    DateTime dt = (DateTime)value;
                    if (dt.Year == 1)
                        continue;
                    else
                        values.Add($"'{((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss")}'");
                }
                else if (pType == typeof(bool))
                {
                    if ((bool)value)
                        values.Add(1);
                    else
                        values.Add(0);
                }
                else
                    values.Add($"N'{value}'");
                keys.Add(columnAttr.Name);
            }
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"INSERT INTO {tableAttr.Name} ({string.Join(", ", keys)}) VALUES ({string.Join(", ", values)})";
            cmd.CommandType = CommandType.Text;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                if (cmd.ExecuteNonQuery() != 0)
                    result = true;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
        public bool UpdateRow<T>(T data)
        {
            bool result = false;
            if (data == null)
                return result;
            Type type = typeof(T);
            TableAttribute tableAttr = (TableAttribute)type.GetCustomAttribute(typeof(TableAttribute));
            if (tableAttr == null)
                return result;

            List<string> sets = new List<string>();
            List<string> where = new List<string>();

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                ColumnAttribute columnAttr = (ColumnAttribute)property.GetCustomAttribute(typeof(ColumnAttribute));
                if (columnAttr == null) continue;
                object value = property.GetValue(data, null);
                Type pType = property.PropertyType;
                object fValue = null;
                if (columnAttr.IsPrimaryKey)
                {
                    if (pType == typeof(int) || pType == typeof(float) || pType == typeof(double))
                        fValue = value;
                    else if (pType == typeof(DateTime))
                    {
                        DateTime dt = (DateTime)value;
                        if (dt == new DateTime())
                            continue;
                        else
                            fValue = $"'{((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss")}'";
                    }
                    else if (pType == typeof(bool))
                        fValue = (bool)value ? 1 : 0;
                    else
                        fValue = $"N'{value}'";
                    where.Add($"{columnAttr.Name} = {fValue}");
                }
                else
                {
                    if (pType == typeof(int) || pType == typeof(float) || pType == typeof(double))
                        fValue = value;
                    else if (pType == typeof(DateTime))
                    {
                        DateTime dt = (DateTime)value;
                        if (dt.Year == 1)
                            continue;
                        else
                            fValue = $"'{((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss")}'";
                    }
                    else if (pType == typeof(bool))
                        fValue = (bool)value ? 1 : 0;
                    else
                        fValue = $"N'{value}'";
                    sets.Add($"{columnAttr.Name} = {fValue}");
                }
            }
            if (where.Count == 0)
                return result;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"UPDATE {tableAttr.Name} SET {string.Join(", ", sets)} WHERE {string.Join(", ", where)}";
            cmd.CommandType = CommandType.Text;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                if (cmd.ExecuteNonQuery() != 0)
                    result = true;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        public int DeleteRows<T>(Func<T, bool> predicate)
        {
            int result = 0;
            Type type = typeof(T);
            TableAttribute tableAttr = (TableAttribute)type.GetCustomAttribute(typeof(TableAttribute));
            if (tableAttr == null) return result;
            IEnumerable<T> list = GetTable<T>(predicate);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                foreach (T c in list)
                {
                    List<string> where = new List<string>();
                    PropertyInfo[] properties = type.GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        ColumnAttribute columnAttr = (ColumnAttribute)property.GetCustomAttribute(typeof(ColumnAttribute));
                        if (columnAttr == null) continue;
                        object value = property.GetValue(c, null);
                        Type pType = property.PropertyType;
                        object fValue = null;
                        if (columnAttr.IsPrimaryKey)
                        {
                            if (pType == typeof(int) || pType == typeof(float) || pType == typeof(double))
                                fValue = value;
                            else if (pType == typeof(DateTime))
                            {
                                DateTime dt = (DateTime)value;
                                if (dt.Year == 1)
                                    continue;
                                else
                                    fValue = $"'{((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss")}'";
                            }
                            else if (pType == typeof(bool))
                                fValue = (bool)value ? 1 : 0;
                            else
                                fValue = $"N'{value}'";
                            where.Add($"{columnAttr.Name} = {fValue}");
                        }
                    }
                    cmd.CommandText = $"DELETE FROM {tableAttr.Name} WHERE {string.Join(", ", where)}";
                    result += cmd.ExecuteNonQuery();
                }
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }


        //START: Xử lý Database
        //START:Xử lý Doanh thu

        public int GetIncome(string startDay, string endDay, string depLoc, string arrLoc)
        {
            int TotalIncome = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.TIMDOANHTHU";
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Connection = conn;

            // Thêm các tham số cho stored procedure
            cmd.Parameters.AddWithValue("@STARTDAY", startDay);
            cmd.Parameters.AddWithValue("@ENDDAY", endDay);
            cmd.Parameters.AddWithValue("@DEPLOC", depLoc);
            cmd.Parameters.AddWithValue("@ARRLOC", arrLoc);

            // Thêm tham số OUTPUT @TOTALINCOME
            SqlParameter outputParam = new SqlParameter("@TOTALINCOME", SqlDbType.Decimal);
            outputParam.Direction = ParameterDirection.Output;
            outputParam.Precision = 18;
            outputParam.Scale = 2;
            cmd.Parameters.Add(outputParam);

            OpenConnect();
            cmd.ExecuteNonQuery();//Thực thi Stored Procedure trên Database

            //Lấy giá trị từ output parameter @TOTALINCOME
            object res = cmd.Parameters["@TOTALINCOME"].Value;
            if (res != null && res!=DBNull.Value)
            {
                TotalIncome = Convert.ToInt32(res);
            }
            CloseConnect();
            return TotalIncome;
        }

            //END: Xử lý Doanh thu



        //END: Xử lý hành khách/Passenger
        

        public DataTable GetDataTable(string sqls)
        {
            OpenConnect();
            SqlCommand cmd = new SqlCommand(sqls,conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            CloseConnect();
            return dataTable;
        }
        public DataTable ExecuteQuery(string sql, object[] parameter = null)
        {
            try
            {
                OpenConnect();

                SqlCommand cmd = new SqlCommand(sql, conn);

                if (parameter != null)
                {
                    string[] listParameter = sql.Split(' ');
                    int i = 0;

                    foreach (var item in listParameter)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                DataTable data = new DataTable();

                SqlDataAdapter ada = new SqlDataAdapter(cmd);

                ada.Fill(data);

                CloseConnect();

                return data;
            }
            catch (Exception ex)
            {
                CloseConnect();
                throw ex;
            }
        }
        public int ExecuteScalar(string sql, object[] parameter = null)
        {
            OpenConnect();
            SqlCommand cmd = new SqlCommand(sql, conn);

            if (parameter != null)
            {
                string[] listParameter = sql.Split(' ');
                int i = 0;

                foreach (var item in listParameter)
                {
                    if (item.Contains("@"))
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            var kq = Convert.ToInt32(cmd.ExecuteScalar());
            CloseConnect();
            return kq;
        }
        public int ExecuteNonQuery(string sql, object[] parameter =null)
        {
            OpenConnect();
            SqlCommand cmd = new SqlCommand(sql, conn);

            if (parameter != null)
            {
                string[] listParameter = sql.Split(' ');
                int i = 0;

                foreach (var item in listParameter)
                {
                    if (item.Contains("@"))
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            int kq = cmd.ExecuteNonQuery();
            CloseConnect();
            return kq;
        }
        //END: Xử lý Database
    }
}

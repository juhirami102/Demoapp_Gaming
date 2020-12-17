using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.Helpers.DataHelper
{
    public enum DataType
    {
        AsInt
        , AsString
        , AsDouble
        , AsDataTime
        , AsBoolean
        , AsByteArray
    }

    public interface IdbParameter
    {

    }
    internal class DbParameter : IdbParameter
    {
        private List<SqlParameter> parameters;
        public DbParameter()
        {
            parameters = new List<SqlParameter>();
        }
        internal List<SqlParameter> Parameters
        {
            get
            {
                return parameters;
            }
        }
    }
    public class DBHelper
    {
        private string _connectionString = string.Empty;
        private List<Type> _dataTypeList = new List<Type> { typeof(int), typeof(Int32), typeof(Int64),
                                                    typeof(string), typeof(double), typeof(bool), typeof(DateTime), typeof(byte[])};
        public DBHelper()
        {
            this._connectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["dbconnection"]);
        }
        public void ExecuteNonQuery(string dataBaseName, string procedureName, IdbParameter parameters = null)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                using (SqlConnection conn = new SqlConnection(GenerateConnectionstring(dataBaseName)))
                {
                    SqlCommand sqlComm = new SqlCommand(procedureName, conn);
                    sqlComm.Parameters.Clear();
                    if(parameters != null)
                    {
                        var _parameter = (parameters as DbParameter).Parameters;
                        sqlComm.Parameters.AddRange(_parameter.ToArray<SqlParameter>());
                    }

                    sqlComm.CommandType = CommandType.StoredProcedure;
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    sqlComm.ExecuteNonQuery();
                }
            }
            finally
            {
                da.Dispose();
                da = null;
            }

        }

        public DataSet GetDataSet(string dataBaseName, string procedureName, IdbParameter parameters = null)
        {
            DataSet ds = new DataSet("Table");
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                using (SqlConnection conn = new SqlConnection(GenerateConnectionstring(dataBaseName)))
                {
                    SqlCommand sqlComm = new SqlCommand(procedureName, conn);
                    sqlComm.Parameters.Clear();
                    if (parameters != null)
                    {
                        var _parameter = (parameters as DbParameter).Parameters;
                        sqlComm.Parameters.AddRange(_parameter.ToArray<SqlParameter>());
                    }

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand = sqlComm;

                    da.Fill(ds);
                }
                return ds;
            }
            finally
            {
                da.Dispose();
                da = null;
                ds = null;
            }

        }

        public DataTable GetDataTable(string dataBaseName, string procedureName, IdbParameter parameters = null)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                using (SqlConnection conn = new SqlConnection(GenerateConnectionstring(dataBaseName)))
                {
                    SqlCommand sqlComm = new SqlCommand(procedureName, conn);
                    sqlComm.Parameters.Clear();
                    if (parameters != null)
                    {
                        var _parameter = (parameters as DbParameter).Parameters;
                        sqlComm.Parameters.AddRange(_parameter.ToArray<SqlParameter>());
                    }

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand = sqlComm;

                    da.Fill(dt);
                }
                return dt;
            }
            finally
            {
                da.Dispose();
                da = null;
                dt = null;
            }

        }

        public List<T> GetDataTableToList<T>(string dataBaseName, string procedureName, IdbParameter parameters = null)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            List<T> dataResult = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(GenerateConnectionstring(dataBaseName)))
                {
                    SqlCommand sqlComm = new SqlCommand(procedureName, conn);
                    sqlComm.Parameters.Clear();
                    if (parameters != null)
                    {
                        var _parameter = (parameters as DbParameter).Parameters;
                        sqlComm.Parameters.AddRange(_parameter.ToArray<SqlParameter>());
                    }

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand = sqlComm;

                    da.Fill(dt);
                }
                var stringDT = JsonConvert.SerializeObject(dt);
                dataResult = JsonConvert.DeserializeObject<List<T>>(stringDT, new IntegerConverter());
                return dataResult;
            }
            finally
            {
                da.Dispose();
                dataResult = null;
                da = null;
            }

        }

        public IdbParameter CreateSqlParameter(string name, object value, DataType type)
        {
            var param = new SqlParameter();
            switch (type)
            {
                case DataType.AsInt:
                    param.DbType = DbType.Int32;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToInt32(value);
                    break;
                case DataType.AsString:
                    param.DbType = DbType.String;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToString(value);
                    break;
                case DataType.AsBoolean:
                    param.DbType = DbType.Boolean;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToBoolean(value);
                    break;
                case DataType.AsDataTime:
                    param.DbType = DbType.DateTime;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToDateTime(value);
                    break;
                case DataType.AsDouble:
                    param.DbType = DbType.Double;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToDateTime(value);
                    break;
                case DataType.AsByteArray:
                    param.SqlDbType = SqlDbType.VarBinary;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = (byte[])value;
                    break;
                default:
                    param.DbType = DbType.String;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToString(value);
                    break;

            }
             var parameters = new DbParameter();
                parameters.Parameters.Add(param);
            return parameters;
        }

        public IdbParameter CreateSqlParameterByDataTable(string name, DataTable value, string type)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@" + name.Trim();
            param.SqlDbType = SqlDbType.Structured;
            param.TypeName = type;
            param.Value = value;
            var parameters = new DbParameter();
            parameters.Parameters.Add(param);
            return parameters;
        }
        public IdbParameter CreateSqlParamByObj(object obj, string[] parameter)
        {
            if(parameter == null)
            {
                throw new Exception("Parameter value is null.");
            }
            if (obj == null)
            {
                throw new Exception("object value is null.");
            }
            var _parameter = new DbParameter();
            Type _type = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(_type.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            foreach (var prop in props)
            {
                object value = prop.GetValue(obj, null);
                SqlParameter param = null;
                if (parameter.Contains(prop.Name))
                {
                    if (prop.GetValue(obj, null) != null)
                    {
                        Type type = prop.GetValue(obj, null).GetType();

                        if (_dataTypeList[0] == type || _dataTypeList[1] == type || _dataTypeList[2] == type)
                        {
                            param = new SqlParameter();
                            param.DbType = DbType.Int32;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = Convert.ToInt32(value);
                            _parameter.Parameters.Add(param);
                        }
                        else if (_dataTypeList[3] == type)
                        {
                            param = new SqlParameter();
                            param.DbType = DbType.String;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = Convert.ToString(value);
                            _parameter.Parameters.Add(param);
                        }
                        else if (_dataTypeList[4] == type)
                        {
                            param = new SqlParameter();
                            param.DbType = DbType.Double;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = Convert.ToDouble(value);
                            _parameter.Parameters.Add(param);
                        }
                        else if (_dataTypeList[5] == type)
                        {
                            param = new SqlParameter();
                            param.DbType = DbType.Boolean;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = Convert.ToBoolean(value);
                            _parameter.Parameters.Add(param);
                        }
                        else if (_dataTypeList[6] == type)
                        {
                            param = new SqlParameter();
                            param.DbType = DbType.DateTime;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = Convert.ToDateTime(value);
                            _parameter.Parameters.Add(param);
                        }
                        else if (_dataTypeList[7] == type)
                        {
                            param = new SqlParameter();
                            param.SqlDbType = SqlDbType.VarBinary;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = (byte[])value;
                            _parameter.Parameters.Add(param);
                        }
                    }
                }
            }
            return _parameter;
        }

        public IdbParameter UpdateSqlParameter(string name, object value, DataType type, IdbParameter parameters)
        {
            if(parameters == null)
            {
                throw new Exception("parameter value is null.");
            }
            var param = new SqlParameter();
            switch (type)
            {
                case DataType.AsInt:
                    param.DbType = DbType.Int32;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToInt32(value);
                    break;
                case DataType.AsString:
                    param.DbType = DbType.String;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToString(value);
                    break;
                case DataType.AsBoolean:
                    param.DbType = DbType.Boolean;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToBoolean(value);
                    break;
                case DataType.AsDataTime:
                    param.DbType = DbType.DateTime;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToDateTime(value);
                    break;
                case DataType.AsDouble:
                    param.DbType = DbType.Double;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToDateTime(value);
                    break;
                case DataType.AsByteArray:
                    param.SqlDbType = SqlDbType.VarBinary;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = (byte[])value;
                    break;
                default:
                    param.DbType = DbType.String;
                    param.ParameterName = "@" + name.Trim();
                    param.Value = Convert.ToString(value);
                    break;

            }
           (parameters as DbParameter).Parameters.Add(param);
            return parameters;
        }

        public IdbParameter UpdateSqlParameterByDataTable(string name, DataTable value, string type, IdbParameter parameters)
        {
            if (parameters == null)
            {
                throw new Exception("parameter value is null.");
            }
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@" + name.Trim();
            param.SqlDbType = SqlDbType.Structured;
            param.TypeName = type;
            param.Value = value;
            (parameters as DbParameter).Parameters.Add(param);
            return parameters;
        }
        public IdbParameter UpdateSqlParamByObj(object obj, string[] parameter, IdbParameter parameters)
        {
            if (parameter == null)
            {
                throw new Exception("Parameter value is null.");
            }
            if (obj == null)
            {
                throw new Exception("object value is null.");
            }
            if (parameters == null)
            {
                throw new Exception("parameter value is null.");
            }
            var _parameter = parameters as DbParameter;
            Type _type = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(_type.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            foreach (var prop in props)
            {
                object value = prop.GetValue(obj, null);
                SqlParameter param = null;
                if (parameter.Contains(prop.Name))
                {
                    if (prop.GetValue(obj, null) != null)
                    {
                        Type type = prop.GetValue(obj, null).GetType();

                        if (_dataTypeList[0] == type || _dataTypeList[1] == type || _dataTypeList[2] == type)
                        {
                            param = new SqlParameter();
                            param.DbType = DbType.Int32;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = Convert.ToInt32(value);
                            _parameter.Parameters.Add(param);
                        }
                        else if (_dataTypeList[3] == type)
                        {
                            param = new SqlParameter();
                            param.DbType = DbType.String;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = Convert.ToString(value);
                            _parameter.Parameters.Add(param);
                        }
                        else if (_dataTypeList[4] == type)
                        {
                            param = new SqlParameter();
                            param.DbType = DbType.Double;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = Convert.ToDouble(value);
                            _parameter.Parameters.Add(param);
                        }
                        else if (_dataTypeList[5] == type)
                        {
                            param = new SqlParameter();
                            param.DbType = DbType.Boolean;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = Convert.ToBoolean(value);
                            _parameter.Parameters.Add(param);
                        }
                        else if (_dataTypeList[6] == type)
                        {
                            param = new SqlParameter();
                            param.DbType = DbType.DateTime;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = Convert.ToDateTime(value);
                            _parameter.Parameters.Add(param);
                        }
                        else if (_dataTypeList[7] == type)
                        {
                            param = new SqlParameter();
                            param.SqlDbType = SqlDbType.VarBinary;
                            param.ParameterName = "@" + prop.Name.Trim();
                            param.Value = (byte[])value;
                            _parameter.Parameters.Add(param);
                        }
                    }
                }
            }
            return _parameter;
        }

        public List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> dataResult = null;
            try
            {
                var stringDT = JsonConvert.SerializeObject(dt);
                dataResult = JsonConvert.DeserializeObject<List<T>>(stringDT, new IntegerConverter());
                return dataResult;
            }
            finally
            {
                dataResult = null;
                dt = null;
            }
        }

        private string GenerateConnectionstring(string DataBaseName)
        {
            if (string.IsNullOrEmpty(DataBaseName) || DataBaseName.Trim() == string.Empty)
            {
                throw new Exception("DataBase Name not provided");
            }
            return this._connectionString.Replace("CommonDB", DataBaseName);
        }
    }

    public class IntegerConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(int) || objectType == typeof(float) || objectType == typeof(double);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return 0;
            }
            else
            {
                int data;
                double databb;
                if (int.TryParse(reader.Value.ToString(), out data))
                {
                    return Convert.ToInt32(reader.Value);
                }
                else if (double.TryParse(reader.Value.ToString(), out databb))
                {
                    return Convert.ToDouble(reader.Value);
                }
                else
                {
                    return Convert.ToInt64(reader.Value);
                }
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

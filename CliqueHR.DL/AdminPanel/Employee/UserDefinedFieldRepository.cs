using CliqueHR.Common.Models;
using CliqueHR.DL.Implementation.AdminPanel.Employee;
using CliqueHR.Helpers.DataHelper;
using System;
using System.Collections.Generic;
using System.Data;

namespace CliqueHR.DL.AdminPanel.Employee
{
   
    public class UserDefinedFieldRepository : IUserDefinedFieldRepository
    {
        private readonly DBHelper _dbHelper;
        public UserDefinedFieldRepository()
        {
            this._dbHelper = new DBHelper();
        }

        public List<UserDefinedField> GetAllUserDefinedField(string DbName)
        {
            try
            {
                return _dbHelper.GetDataTableToList<UserDefinedField>(DbName, "[Employee].[GetAllUserDefinedField]");
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public UserDefinedField GetUserDefinedFieldById(int id, string DbName)
        {
            try
            {
                var sqlParameterd = _dbHelper.CreateSqlParameter("Id", id, DataType.AsInt);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Employee].[GetGlobalProfileDetailsById]", sqlParameterd);
                return new UserDefinedField
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    SectionName = Convert.ToString(dt.Rows[0]["SectionName"]),
                    SectionCode = Convert.ToString(dt.Rows[0]["SectionCode"]),
                    IsEnable = Convert.ToBoolean(dt.Rows[0]["IsEnable"]),
                    FieldName = Convert.ToString(dt.Rows[0]["FieldName"]),
                    FieldTypeId = Convert.ToInt32(dt.Rows[0]["FieldTypeId"]),
                    FieldType = Convert.ToString(dt.Rows[0]["FieldType"]),
                    FieldTypeValue=Convert.ToString(dt.Rows[0]["FieldTypeValue"])
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public ApplicationResponse UpdateUserDefinedField(List<UserDefinedField> model, string DbName)
        {
            try
            {
                UserProfileXML obj = new UserProfileXML();
                string userprofilexml = XMLHelper.Serialize(model);
                obj.userprofilexml = userprofilexml;
                var parameters = new string[] { "userprofilexml" };

                var sqlParameterd = _dbHelper.CreateSqlParamByObj(obj, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Employee].[EditUserDefinedField]", sqlParameterd);
                return new ApplicationResponse
                {
                    Code = Convert.ToInt32(dt.Rows[0][0]),
                    Message = Convert.ToString(dt.Rows[0][1]),
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
    }
}

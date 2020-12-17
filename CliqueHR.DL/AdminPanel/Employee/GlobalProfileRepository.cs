using CliqueHR.Common.Models;
using CliqueHR.DL.Implementation.AdminPanel.Employee;
using CliqueHR.Helpers.DataHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.DL.AdminPanel.Employee
{
    public class GlobalProfileRepository : IGlobalProfileRepository
    {
        private readonly DBHelper _dbHelper;
        public GlobalProfileRepository()
        {
            this._dbHelper = new DBHelper();
        }

        public List<GlobalProfileModel> GetAllGlobalProfile(string DbName)
        {
            try
            {
                return _dbHelper.GetDataTableToList<GlobalProfileModel>(DbName, "[Employee].[GetAllGlobalProfileDetails]");
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public GlobalProfileModel GetGlobalProfileById(int id, string DbName)
        {
            try
            {
                var sqlParameterd = _dbHelper.CreateSqlParameter("Id", id, DataType.AsInt);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Employee].[GetGlobalProfileDetailsById]", sqlParameterd);
                return new GlobalProfileModel
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    SectionName = Convert.ToString(dt.Rows[0]["SectionName"]),
                    SectionCode = Convert.ToString(dt.Rows[0]["SectionCode"]),
                    IsEnable = Convert.ToBoolean(dt.Rows[0]["IsEnable"]),
                    CreatedBy = Convert.ToInt64(dt.Rows[0]["CreatedBy"])
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public ApplicationResponse UpdateGlobalProfile(List<GlobalProfileModel> model, string DbName)
        {
            try
            {
                GlobalProfileXML obj = new GlobalProfileXML();
                string globalprofilexml = XMLHelper.Serialize(model);
                obj.globalprofilexml = globalprofilexml;
                var parameters = new string[] { "globalprofilexml" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(obj, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Employee].[EditGlobalProfileDetails]", sqlParameterd);
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

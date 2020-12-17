using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliqueHR.Common.Models;
using CliqueHR.Helpers.DataHelper;

namespace CliqueHR.DL
{
    public class EntityRepository : IEntityRepository
    {
        private readonly DBHelper _dbHelper;
        public EntityRepository()
        {
            this._dbHelper = new DBHelper();
        }
        public List<Entity> GetEntity(Entity model, string CompanyCode)
        {
            try
            {
                var parameters = new string[] { "TransType" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                return _dbHelper.GetDataTableToList<Entity>(CompanyCode, "[Company].[EntityDetails]", sqlParameterd);
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }

        public List<Entity> GetEntityById(Entity model, string CompanyCode)
        {
            try
            {
                var parameters = new string[] { "TransType" ,"Id"};
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                return _dbHelper.GetDataTableToList<Entity>(CompanyCode, "[Company].[EntityDetails]", sqlParameterd);
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }

        public ApplicationResponse AddEntity(Entity model, string CompanyCode)
        {
            try
            {
                var parameters = new string[] { "TransType", "Id", "Name", "Code", "TypeId", "IncorporationDate", "Address", "CountryId", "StateId", "CityId", "PinCode", "ContcatNo", "WebSite", "PAN", "TAN", "GSTIN", "PF", "ESIC", "Logo", "CreatedBy", "ModifiedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(CompanyCode, "[Company].[EntityDetails]", sqlParameterd);
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
        public ApplicationResponse UpdateEntity(Entity model, string CompanyCode)
        {
            try
            {
                var parameters = new string[] { "TransType", "Id", "Name", "Code", "TypeId", "IncorporationDate", "Address", "CountryId", "StateId", "CityId", "PinCode", "ContcatNo", "WebSite", "PAN", "TAN", "GSTIN", "PF", "ESIC", "Logo", "CreatedBy", "ModifiedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(CompanyCode, "[Company].[EntityDetails]", sqlParameterd);
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

using CliqueHR.Common.Models;
using CliqueHR.Helpers.DataHelper;
using System;
using CliqueHR.Helpers.ExceptionHelper;
using System.Collections.Generic;
using System.Data;

namespace CliqueHR.DL
{
    public class PageSettingsRepository : IPageSettingsRepository
    {
        private readonly DBHelper _dbHelper;
        public PageSettingsRepository()
        {
            this._dbHelper = new DBHelper();
        }
        public List<PageSettings> GetPageSettings(PageSettings model, string CompanyCode)
        {
            try
            {
                var parameters = new string[] { "TransType" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                return _dbHelper.GetDataTableToList<PageSettings>(CompanyCode, "[Company].[PageSetting]", sqlParameterd);
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }

        public ApplicationResponse AddUpdatePageSettings(PageSettings model, string CompanyCode)
        {
            try
            {
                var parameters = new string[] { "TransType", "LoginPageBackGroundImgOne","LoginPageBackGroundImgTwo","LoginPageBackGroundImgThree",
                    "DashboardPageBackGroundImgOne","DashboardPageBackGroundImgTwo","DashboardPageBackGroundImgThree",
                    "DashboardPageBackGroundImgFour","DashboardPageBackGroundImgFive","SlideShoutContent",
                    "IsBirthdayVisible","IsWorkAnniversaryVisible","IsMarriageAnniversaryVisible",
                    "IsExitVisible","IsNewJoineeVisible", "CreatedBy", "ModifiedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(CompanyCode, "[Company].[PageSetting]", sqlParameterd);
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

using CliqueHR.Common.Models;
using CliqueHR.DL.Imp;
using CliqueHR.Helpers.DataHelper;
using CliqueHR.Helpers.ExceptionHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.DL
{
    public class TestRepository : ITestRepository
    {
        private readonly DBHelper _dbHelper;
        public TestRepository()
        {
            this._dbHelper = new DBHelper();
        }
        public void AddTestData(TestModel model)
        {
            try
            {
                var parameters = new string[] { "TypeName", "SelfService", "MinAge", "CreatedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                 _dbHelper.ExecuteNonQuery("DevDB", "[Common].[Master_AddEmployeeType]", sqlParameterd);
            }
            catch (Exception ex)
            {
                var helper = new DataException(ex);
                throw helper.GetException();
            }
        }
    }
}

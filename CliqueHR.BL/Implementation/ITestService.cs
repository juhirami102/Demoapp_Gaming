using CliqueHR.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.BL.Imp
{
    public interface ITestService
    {
        void AddTestData(TestModel model);
        TestModel GetTestData();
        TestModel GetTestDataByID(int ID);
        string UpdateTestData(TestModel model);
    }
}

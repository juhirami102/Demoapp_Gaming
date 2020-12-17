using CliqueHR.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.DL.Implementation.AdminPanel.Employee
{
    public interface IGlobalProfileRepository
    {
        List<GlobalProfileModel> GetAllGlobalProfile(string DBName);
        GlobalProfileModel GetGlobalProfileById(int Id, string DBName);
        ApplicationResponse UpdateGlobalProfile(List<GlobalProfileModel> model, string DBName);
    }
}

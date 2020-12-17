using System;
using CliqueHR.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.BL
{
    public interface IGroupCompanyService
    {
        ApplicationResponse AddUpdateGroupCompany(GroupCompany model, UserContextModel objUser);
        List<GroupCompany> GetGroupCompany(GroupCompany model, UserContextModel objUser);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliqueHR.Common.Models;

namespace CliqueHR.DL
{
    public interface IGroupCompanyRepository
    {
        ApplicationResponse AddUpdateGroupCompany(GroupCompany model, string CompanyCode);
        List<GroupCompany> GetGroupCompany(GroupCompany model, string CompanyCode);

    }
}

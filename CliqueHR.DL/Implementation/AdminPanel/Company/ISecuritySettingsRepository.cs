using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliqueHR.Common.Models;

namespace CliqueHR.DL
{
    public interface ISecuritySettingsRepository
    {
        ApplicationResponse AddUpdateSecuritySettings(SecuritySettings model, string CompanyCode);
        List<SecuritySettings> GetSecuritySettings(SecuritySettings model, string CompanyCode);

    }
}

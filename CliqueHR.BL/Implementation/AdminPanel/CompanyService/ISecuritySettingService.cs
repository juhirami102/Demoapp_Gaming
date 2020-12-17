using System;
using CliqueHR.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.BL
{
    public interface ISecuritySettingService
    {
        ApplicationResponse AddUpdateSecuritySettings(SecuritySettings model, UserContextModel objUser);
        List<SecuritySettings> GetSecuritySettings(SecuritySettings model, UserContextModel objUser);
      
    }
}

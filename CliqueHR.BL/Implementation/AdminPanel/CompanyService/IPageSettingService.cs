using System;
using CliqueHR.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.BL
{
    public interface IPageSettingService
    {
        ApplicationResponse AddUpdatePageSettings(PageSettings model, UserContextModel objUser);
        List<PageSettings> GetPageSettings(PageSettings model, UserContextModel objUser);
    }
}

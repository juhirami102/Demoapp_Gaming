using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliqueHR.Common.Models;


namespace CliqueHR.DL
{
    public interface IPageSettingsRepository
    {
        ApplicationResponse AddUpdatePageSettings(PageSettings model, string CompanyCode);
        List<PageSettings> GetPageSettings(PageSettings model, string CompanyCode);
    }
}

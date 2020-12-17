using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliqueHR.Common.Models;

namespace CliqueHR.DL
{
    public interface IEntityRepository
    {
        ApplicationResponse AddEntity(Entity model, string CompanyCode);
        ApplicationResponse UpdateEntity(Entity model, string CompanyCode);
        List<Entity> GetEntity(Entity model, string CompanyCode);
        List<Entity> GetEntityById(Entity model, string CompanyCode);
    }
}

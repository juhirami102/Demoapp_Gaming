using System;
using CliqueHR.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.BL
{
    public interface IEntityService
    {
        ApplicationResponse AddEntity(Entity model, UserContextModel objUser);
        ApplicationResponse UpdateEntity(Entity model, UserContextModel objUser);
        List<Entity> GetEntity(Entity model, UserContextModel objUser);
        List<Entity> GetEntityById(Entity model, UserContextModel objUser);
    }
}

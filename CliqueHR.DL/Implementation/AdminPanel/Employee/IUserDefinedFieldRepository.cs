using CliqueHR.Common.Models;
using System.Collections.Generic;

namespace CliqueHR.DL.Implementation.AdminPanel.Employee
{
    

    public interface IUserDefinedFieldRepository
    {
        List<UserDefinedField> GetAllUserDefinedField(string DBName);
        UserDefinedField GetUserDefinedFieldById(int Id, string DBName);
        ApplicationResponse UpdateUserDefinedField(List<UserDefinedField> model, string DBName);
    }
}

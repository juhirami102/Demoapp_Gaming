using CliqueHR.BL.Implementation.AdminPanel.Employee;
using CliqueHR.Common.Models;
using CliqueHR.DL.AdminPanel.Employee;
using CliqueHR.DL.Implementation.AdminPanel.Employee;
using CliqueHR.Helpers.ExceptionHelper;
using CliqueHR.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.BL.AdminPanelService.EmployeeService
{
    public class UserDefinedFieldService : IUserDefinedFieldService
    {
        private IUserDefinedFieldRepository _userDefinedFieldRepository;
        private UserDefineValidation _modelValidation;
        public UserDefinedFieldService()
        {
            _userDefinedFieldRepository = new UserDefinedFieldRepository();
            _modelValidation = new UserDefineValidation();
        }

        #region Global Profile

        public List<UserDefinedField> GetAllUserDefinedField(UserContextModel objUser)
        {
            try
            {
                var data = _userDefinedFieldRepository.GetAllUserDefinedField(objUser.CompanyCode);
                return data;
            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
        public UserDefinedField GetUserDefinedFieldById(int ID, UserContextModel objUser)
        {
            try
            {
                var data = _userDefinedFieldRepository.GetUserDefinedFieldById(ID, objUser.CompanyCode);
                return data;
            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
        public ApplicationResponse UpdateUserDefinedField(List<UserDefinedField> model, UserContextModel objUser)
        {
            try
            {
                var validationRespons = _modelValidation.Validate(UserDefineValidation.ValidateAll_key, model, "Section Name can not be blank.");
                foreach (ValidationResponse obj in validationRespons)
                {
                    if (obj.Messages != null && obj.Messages.Count != 0)
                    {
                        throw new ValidationException(obj);
                    }
                }

                model.ForEach(x => x.CreatedBy = objUser.UserID);

                var data = _userDefinedFieldRepository.UpdateUserDefinedField(model, objUser.CompanyCode);
                return data;

            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }

        #endregion

    }
}

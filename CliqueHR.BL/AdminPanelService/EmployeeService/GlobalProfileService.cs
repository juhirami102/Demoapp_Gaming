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
    public class GlobalProfileService : IGlobalProfileService
    {
        private IGlobalProfileRepository _globalProfileRepository;
        private GlobalProfileValidation _modelValidation;
        public GlobalProfileService()
        {
            _globalProfileRepository = new GlobalProfileRepository();
            _modelValidation = new GlobalProfileValidation();
        }

        #region Global Profile

        public List<GlobalProfileModel> GetAllGlobalProfile(UserContextModel objUser)
        {
            try
            {
                var data = _globalProfileRepository.GetAllGlobalProfile(objUser.CompanyCode);
                return data;
            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
        public GlobalProfileModel GetGlobalProfileById(int ID, UserContextModel objUser)
        {
            try
            {
                var data = _globalProfileRepository.GetGlobalProfileById(ID, objUser.CompanyCode);
                return data;
            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
        public ApplicationResponse UpdateGlobalProfile(List<GlobalProfileModel> model, UserContextModel objUser)
        {
            try
            {
                var validationRespons    = _modelValidation.Validate(GlobalProfileValidation.ValidateAll_key, model, "Display Name can not be blank.");
                foreach(ValidationResponse obj in validationRespons)
                {
                    if (obj.Messages != null && obj.Messages.Count != 0)
                    {
                        throw new ValidationException(obj);
                    }
                }
               
                model.ForEach(x => x.CreatedBy = objUser.UserID);
                
                var data = _globalProfileRepository.UpdateGlobalProfile(model, objUser.CompanyCode);
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

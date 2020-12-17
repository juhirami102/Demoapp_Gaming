using System;
using System.Collections.Generic;
using CliqueHR.Common.Models;
using CliqueHR.DL;
using CliqueHR.Helpers.ExceptionHelper;
namespace CliqueHR.BL
{
    public class SecuritySettingsService : ISecuritySettingService
    {
        private ISecuritySettingsRepository _securitysettingsRepository;
        private SecuritySettingValidation _modelValidation;
        public SecuritySettingsService()
        {
            _securitysettingsRepository = new SecuritySettingsRepository();
            _modelValidation = new SecuritySettingValidation();
        }
        public ApplicationResponse AddUpdateSecuritySettings(SecuritySettings model, UserContextModel objUser)
        {
            try
            {
                var validationResponse = _modelValidation.Validate(SecuritySettingValidation.ValidateAll_key, model, "Security settings model can not be empty.");
                if (validationResponse.Messages != null && validationResponse.Messages.Count != 0)
                {
                    throw new ValidationException(validationResponse);
                }
                model.CreatedBy = objUser.UserID;
                var data = _securitysettingsRepository.AddUpdateSecuritySettings(model, objUser.CompanyCode);
                return data;

            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
        public List<SecuritySettings> GetSecuritySettings(SecuritySettings model, UserContextModel objUser)
        {
            try
            {
                var data = _securitysettingsRepository.GetSecuritySettings(model, objUser.CompanyCode);
                return data;
            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
  
    }
}

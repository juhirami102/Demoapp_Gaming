using System;
using System.Collections.Generic;
using CliqueHR.Common.Models;
using CliqueHR.DL;
using CliqueHR.Helpers.ExceptionHelper;
namespace CliqueHR.BL
{
    public class PageSettingsService : IPageSettingService
    {

        private IPageSettingsRepository _pagesettingsRepository;
        private PageSettingValidation _modelValidation;
        public PageSettingsService()
        {
            _pagesettingsRepository = new PageSettingsRepository();
            _modelValidation = new PageSettingValidation();
        }
        public ApplicationResponse AddUpdatePageSettings(PageSettings model, UserContextModel objUser)
        {
            try
            {
                var validationResponse = _modelValidation.Validate(SecuritySettingValidation.ValidateAll_key, model, "Page settings model can not be empty.");
                if (validationResponse.Messages != null && validationResponse.Messages.Count != 0)
                {
                    throw new ValidationException(validationResponse);
                }
                model.CreatedBy = objUser.UserID;
                var data = _pagesettingsRepository.AddUpdatePageSettings(model, objUser.CompanyCode);
                return data;

            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
        public List<PageSettings> GetPageSettings(PageSettings model, UserContextModel objUser)
        {
            try
            {
                var data = _pagesettingsRepository.GetPageSettings(model, objUser.CompanyCode);
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

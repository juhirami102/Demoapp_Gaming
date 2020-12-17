using System;
using System.Collections.Generic;
using CliqueHR.Common.Models;
using CliqueHR.DL;
using CliqueHR.Helpers.ExceptionHelper;

namespace CliqueHR.BL
{
    public class GroupCompanyService : IGroupCompanyService
    {
        private IGroupCompanyRepository _groupCompanyRepository;
        private GroupCompanyValidation _modelValidation;
        public GroupCompanyService()
        {
            _groupCompanyRepository = new GroupCompanyRepository();
            _modelValidation = new GroupCompanyValidation();
        }
        public ApplicationResponse AddUpdateGroupCompany(GroupCompany model, UserContextModel objUser)
        {
            try
            {
                var validationResponse = _modelValidation.Validate(GroupCompanyValidation.ValidateAll_key, model, "Group company model can not be empty.");
                if (validationResponse.Messages != null && validationResponse.Messages.Count != 0)
                {
                    throw new ValidationException(validationResponse);
                }
                model.CreatedBy = objUser.UserID;
                var data = _groupCompanyRepository.AddUpdateGroupCompany(model, objUser.CompanyCode);
                return data;

            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
        public List<GroupCompany> GetGroupCompany(GroupCompany model, UserContextModel objUser)
        {
            try
            {
                var data = _groupCompanyRepository.GetGroupCompany(model, objUser.CompanyCode);
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

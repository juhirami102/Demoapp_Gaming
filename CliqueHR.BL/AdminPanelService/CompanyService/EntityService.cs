using System;
using System.Collections.Generic;
using CliqueHR.Common.Models;
using CliqueHR.DL;
using CliqueHR.Helpers.ExceptionHelper;

namespace CliqueHR.BL
{
    public class EntityService : IEntityService
    {
        private IEntityRepository _entityRepository;
        private EntityValidation _modelValidation;
        public EntityService()
        {
            _entityRepository = new EntityRepository();
            _modelValidation = new EntityValidation();
        }

        public ApplicationResponse AddEntity(Entity model, UserContextModel objUser)
        {
            try
            {
                var validationResponse = _modelValidation.Validate(EntityValidation.ValidateAll_key, model, "Entity model can not be empty.");
                if (validationResponse.Messages != null && validationResponse.Messages.Count != 0)
                {
                    throw new ValidationException(validationResponse);
                }
                model.CreatedBy = objUser.UserID;
                var data = _entityRepository.AddEntity(model, objUser.CompanyCode);
                return data;

            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
        public ApplicationResponse UpdateEntity(Entity model, UserContextModel objUser)
        {
            try
            {
                var validationResponse = _modelValidation.Validate(EntityValidation.ValidateAll_key, model, "Entity model can not be empty.");
                if (validationResponse.Messages != null && validationResponse.Messages.Count != 0)
                {
                    throw new ValidationException(validationResponse);
                }
                model.CreatedBy = objUser.UserID;
                var data = _entityRepository.UpdateEntity(model, objUser.CompanyCode);
                return data;

            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
        public List<Entity> GetEntity(Entity model, UserContextModel objUser)
        {
            try
            {
                var data = _entityRepository.GetEntity(model, objUser.CompanyCode);
                return data;
            }
            catch (Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
        public List<Entity> GetEntityById(Entity model, UserContextModel objUser)
        {
            try
            {
                var data = _entityRepository.GetEntityById(model, objUser.CompanyCode);
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

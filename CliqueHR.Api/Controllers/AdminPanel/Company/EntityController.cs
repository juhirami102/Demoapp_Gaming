using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CliqueHR.Api.Application;
using CliqueHR.BL;
using CliqueHR.Common.Models;
using CliqueHR.Helpers.Logger;

namespace CliqueHR.Api.Controllers
{
    public class EntityController : ApiController
    {
        private IEntityService _entityService;

        public EntityController()
        {
            _entityService = new EntityService();
        }

        [HttpPost]
        public HttpResponseMessage AddEntity(Entity model)
        {
            try
            {
                Log.Info("EntityController:AddEntity", "Add Entity Start", string.Empty);
                model.TransType = "SAVE";

                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _entityService.AddEntity(model, objUser);
                Log.Info("EntityController:AddEntity", "Add Entity  End", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }

        [HttpPost]
        public HttpResponseMessage UpdateEntity(Entity model)
        {
            try
            {
                Log.Info("EntityController:UpdateEntity", "Update Entity Start", string.Empty);
                model.TransType = "SAVE";

                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _entityService.UpdateEntity(model, objUser);
                Log.Info("EntityController:UpdateEntity", "Update Entity  End", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetEntity()
        {
            try
            {
                Log.Info("EntityController:GetEntity", "Get All Entities  Start", string.Empty);
                Entity model = new Entity();
                model.TransType = "FETCH";
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _entityService.GetEntity(model, objUser);
                Log.Info("GroupCompanyController:GetGroupCompany", "Get All Entities End", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetEntityById(Entity model)
        {
            try
            {
                Log.Info("EntityController:GetEntityById", "Get  Entities By Id  Start", string.Empty);
                model.TransType = "FETCHBYENTITYID";
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _entityService.GetEntityById(model, objUser);
                Log.Info("EntityController:GetEntityById", "Get  Entities By Id  End", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
    }
}

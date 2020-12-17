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
    public class GroupCompanyController : ApiController
    {
        private IGroupCompanyService _groupCompanyService;

        public GroupCompanyController()
        {
            _groupCompanyService = new GroupCompanyService();
        }

        [HttpPost]
        public HttpResponseMessage AddUpdateGroupCompany(GroupCompany model)
        {
            try
            {
                Log.Info("GroupCompanyController:AddUpdateGroupCompany", "Add Group Company Start", string.Empty);
                model.TransType = "SAVE";
            
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _groupCompanyService.AddUpdateGroupCompany(model, objUser);
                Log.Info("GroupCompanyController:AddUpdateGroupCompany", "Add Group Company  End", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetGroupCompany()
        {
            try
            {
                Log.Info("GroupCompanyController:GetGroupCompany", "Get Group Company  Start", string.Empty);
                GroupCompany model = new GroupCompany();
                model.TransType = "FETCH";
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _groupCompanyService.GetGroupCompany(model, objUser);
                Log.Info("GroupCompanyController:GetGroupCompany", "Get Group Company END", string.Empty);
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

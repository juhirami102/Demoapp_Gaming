using CliqueHR.Api.Application;
using CliqueHR.BL;
using CliqueHR.Common.Models;
using CliqueHR.Helpers.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CliqueHR.Api.Controllers
{
    public class SecuritySettingsController : ApiController
    {
        private ISecuritySettingService _securitySettingService;

        public SecuritySettingsController()
        {
            _securitySettingService = new SecuritySettingsService();
        }

        [HttpPost]
        public HttpResponseMessage AddUpdateSecuritySettings(SecuritySettings model)
        {
            try
            {
                Log.Info("SecuritySettingsController:AddUpdateSecuritySettings", "Add Security Settings Start", string.Empty);
                model.TransType = "SAVE";
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _securitySettingService.AddUpdateSecuritySettings(model, objUser);
                Log.Info("SecuritySettingsController:AddUpdateSecuritySettings", "Add Security Settings End", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetSecuritySettings()
        {
            try
            {
                Log.Info("SecuritySettingsController:GetSecuritySettings", "Get Security Settings Start", string.Empty);
                SecuritySettings model = new SecuritySettings();
                model.TransType = "FETCH";
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _securitySettingService.GetSecuritySettings(model, objUser);
                Log.Info("SecuritySettingsController:GetSecuritySettings", "Get Security Settings END", string.Empty);
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

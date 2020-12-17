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
    public class PageSettingsController : ApiController
    {
        private IPageSettingService _pageSettingService;

        public PageSettingsController()
        {
            _pageSettingService = new PageSettingsService();
        }

        [HttpPost]
        public HttpResponseMessage AddUpdatePageSettings(PageSettings model)
        {
            try
            {
                Log.Info("PageSettingsController:AddUpdatePageSettings", "Add Page Settings Start", string.Empty);
                model.TransType = "SAVE";
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _pageSettingService.AddUpdatePageSettings(model, objUser);
                Log.Info("PageSettingsController:AddUpdateSecuritySettings", "Add Page Settings End", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetPageSettings()
        {
            try
            {
                Log.Info("PageSettingsController:GetPageSettings", "Get Page Settings Start", string.Empty);
                PageSettings model = new PageSettings();
                model.TransType = "FETCH";
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _pageSettingService.GetPageSettings(model, objUser);
                Log.Info("PageSettingsController:GetPageSettings", "Get Page Settings End", string.Empty);
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

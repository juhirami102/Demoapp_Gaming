using CliqueHR.Api.Application;
using CliqueHR.BL.AdminPanelService.EmployeeService;
using CliqueHR.BL.Implementation.AdminPanel.Employee;
using CliqueHR.Common.Models;
using CliqueHR.Helpers.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CliqueHR.Api.Controllers.AdminPanel.Employee
{
    public class UserDefineController : ApiController
    {

        private IUserDefinedFieldService _userDefinedFieldService;

        public UserDefineController()
        {
            _userDefinedFieldService = new UserDefinedFieldService();
        }


        [HttpPost]
        public HttpResponseMessage UpdateUserDefinedField(List<UserDefinedField> model)
        {
            try
            {
              //  Log.Info("UserDefineController:UpdateUserDefinedField", "Update UserDefinedField START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _userDefinedFieldService.UpdateUserDefinedField(model, objUser);
                //Log.Info("UserDefineController:UpdateUserDefinedField", "Update UserDefinedField END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetAllUserDefinedField()
        {
            try
            {
              //  Log.Info("UserDefineController:GetAllUserDefinedField", "Get All UserDefinedField START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _userDefinedFieldService.GetAllUserDefinedField(objUser);
              //  Log.Info("UserDefineController:GetAllUserDefinedField", "Get All UserDefinedField END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetUserDefinedFieldById(int Id)
        {
            try
            {
                Log.Info("UserDefineController:GetUserDefinedFieldById", "Get CourseType By Id START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _userDefinedFieldService.GetUserDefinedFieldById(Id, objUser);
                Log.Info("UserDefineController:GetUserDefinedFieldById", "Get CourseType By Id END", string.Empty);
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

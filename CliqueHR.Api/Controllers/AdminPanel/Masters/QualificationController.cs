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
    public class QualificationController : ApiController
    {
        private IQualificationService _qualificationService;
        public QualificationController()
        {
            _qualificationService = new QualificationService();
        }

        #region Course Type
        [HttpPost]
        public HttpResponseMessage AddCourseType(CourseType model)
        {
            try
            {
                Log.Info("QualificationController:AddCourseType", "Add CourseType START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.AddCourseType(model, objUser);
                Log.Info("QualificationController:AddCourseType", "Add CourseType END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpPost]
        public HttpResponseMessage UpdateCourseType(CourseType model)
        {
            try
            {
                Log.Info("QualificationController:UpdateCourseType", "Update CourseType START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.UpdateCourseType(model, objUser);
                Log.Info("QualificationController:UpdateCourseType", "Update CourseType END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetAllCourseType()
        {
            try
            {
                Log.Info("QualificationController:GetAllCourseType", "Get All CourseType START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.GetAllCourseType(objUser);
                Log.Info("QualificationController:GetAllCourseType", "Get All CourseType END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetCourseTypeById(int Id)
        {
            try
            {
                Log.Info("QualificationController:GetCourseTypeById", "Get CourseType By Id START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.GetCourseTypeByID(Id, objUser);
                Log.Info("QualificationController:GetCourseTypeById", "Get CourseType By Id END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        #endregion
        #region Course Title
        [HttpPost]
        public HttpResponseMessage AddCourseTitle(CourseTitle model)
        {
            try
            {
                Log.Info("QualificationController:AddCourseTitle", "Add CourseTitle START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.AddCourseTitle(model, objUser);
                Log.Info("QualificationController:AddCourseTitle", "Add CourseTitle END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpPost]
        public HttpResponseMessage UpdateCourseTitle(CourseTitle model)
        {
            try
            {
                Log.Info("QualificationController:UpdateCourseTitle", "Update CourseTitle START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.UpdateCourseTitle(model, objUser);
                Log.Info("QualificationController:UpdateCourseTitle", "Update CourseTitle END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetAllCourseTitle(PaginationModel paginationModel)
        {
            try
            {
                Log.Info("QualificationController:GetAllCourseTitle", "Get All CourseTitle START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.GetAllCourseTitle(objUser);
                Log.Info("QualificationController:GetAllCourseTitle", "Get All CourseTitle END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetCourseTitleById(int Id)
        {
            try
            {
                Log.Info("QualificationController:GetCourseTitleById", "Get CourseTitle By Id START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.GetCourseTitleByID(Id, objUser);
                Log.Info("QualificationController:GetCourseTitleById", "Get CourseTitle By Id END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        #endregion
        #region Major
        [HttpPost]
        public HttpResponseMessage AddMajor(Major model)
        {
            try
            {
                Log.Info("QualificationController:AddMajor", "Add Major START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.AddMajor(model, objUser);
                Log.Info("QualificationController:AddMajor", "Add Major END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpPost]
        public HttpResponseMessage UpdateMajor(Major model)
        {
            try
            {
                Log.Info("QualificationController:UpdateMajor", "Update Major START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.UpdateMajor(model, objUser);
                Log.Info("QualificationController:UpdateMajor", "Update Major END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetAllMajor()
        {
            try
            {
                Log.Info("QualificationController:GetAllMajor", "Get All Major START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.GetAllMajor(objUser);
                Log.Info("QualificationController:GetAllMajor", "Get All Major END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetMajorById(int Id)
        {
            try
            {
                Log.Info("QualificationController:GetMajorById", "Get Major By Id START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.GetMajorByID(Id, objUser);
                Log.Info("QualificationController:GetMajorById", "Get Major By Id END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        #endregion
        #region University
        [HttpPost]
        public HttpResponseMessage AddUniversity(University model)
        {
            try
            {
                Log.Info("QualificationController:AddUniversity", "Add University START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.AddUniversity(model, objUser);
                Log.Info("QualificationController:AddUniversity", "Add University END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpPost]
        public HttpResponseMessage UpdateUniversity(University model)
        {
            try
            {
                Log.Info("QualificationController:UpdateUniversity", "Update University START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.UpdateUniversity(model, objUser);
                Log.Info("QualificationController:UpdateUniversity", "Update University END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetAllUniversity()
        {
            try
            {
                Log.Info("QualificationController:GetAllUniversity", "Get All University START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.GetAllUniversity(objUser);
                Log.Info("QualificationController:GetAllUniversity", "Get All University END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetUniversityById(int Id)
        {
            try
            {
                Log.Info("QualificationController:GetUniversityById", "Get University By Id START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.GetUniversityByID(Id, objUser);
                Log.Info("QualificationController:GetUniversityById", "Get University By Id END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        #endregion
        #region Institute
        public HttpResponseMessage AddInstitute(Institute model)
        {
            try
            {
                Log.Info("QualificationController:AddInstitute", "Add Institute START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.AddInstitute(model, objUser);
                Log.Info("QualificationController:AddInstitute", "Add Institute END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpPost]
        public HttpResponseMessage UpdateInstitute(Institute model)
        {
            try
            {
                Log.Info("QualificationController:UpdateInstitute", "Update Institute START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.UpdateInstitute(model, objUser);
                Log.Info("QualificationController:UpdateInstitute", "Update Institute END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetAllInstitute()
        {
            try
            {
                Log.Info("QualificationController:GetAllInstitute", "Get All Institute START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.GetAllInstitute(objUser);
                Log.Info("QualificationController:GetAllInstitute", "Get All Institute END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetInstituteById(int Id)
        {
            try
            {
                Log.Info("QualificationController:GetInstituteById", "Get Institute By Id START", string.Empty);
                UserContextModel objUser = new UserContextModel();
                objUser.UserID = 1;
                objUser.CompanyCode = "devDB";
                var data = _qualificationService.GetInstituteByID(Id, objUser);
                Log.Info("QualificationController:GetInstituteById", "Get Institute By Id END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
        #endregion


    }
}
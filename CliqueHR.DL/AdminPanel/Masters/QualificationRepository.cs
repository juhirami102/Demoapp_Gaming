using CliqueHR.Common.Models;
using CliqueHR.Helpers.DataHelper;
using System;
using CliqueHR.Helpers.ExceptionHelper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CliqueHR.DL
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly DBHelper _dbHelper;
        public QualificationRepository()
        {
            this._dbHelper = new DBHelper();
        }
        #region Course Type
        public ApplicationResponse AddCourseType(CourseType model, string DbName)
        {
            try
            {
                var parameters = new string[] { "TypeName", "IsActive", "CreatedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_AddCourseType]", sqlParameterd);
                return new ApplicationResponse
                {
                    Code = Convert.ToInt32(dt.Rows[0][0]),
                    Message = Convert.ToString(dt.Rows[0][1]),
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public List<CourseType> GetAllCourseType(string DbName)
        {
            try
            {
                return _dbHelper.GetDataTableToList<CourseType>(DbName, "[Common].[Master_GetAllCourseType]");
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public CourseType GetCourseTypeById(int CourseTypeId, string DbName)
        {
            try
            {
                var sqlParameterd = _dbHelper.CreateSqlParameter("Id", CourseTypeId, DataType.AsInt);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_GetCourseTypeById]", sqlParameterd);
                return new CourseType
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    TypeName = Convert.ToString(dt.Rows[0]["TypeName"]),
                    CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]),
                    CreatedDate = Convert.ToString(dt.Rows[0]["CreatedDate"]),
                    IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"])
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public ApplicationResponse UpdateCourseType(CourseType model, string DbName)
        {
            try
            {
                var parameters = new string[] { "Id", "TypeName", "IsActive", "CreatedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_EditCourseType]", sqlParameterd);
                return new ApplicationResponse
                {
                    Code = Convert.ToInt32(dt.Rows[0][0]),
                    Message = Convert.ToString(dt.Rows[0][1]),
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        #endregion
        #region Course Title
        public ApplicationResponse AddCourseTitle(CourseTitle model, string DbName)
        {
            try
            {
                var parameters = new string[] { "TitleName", "CourseTypeId", "IsActive", "CreatedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_AddCourseTitle]", sqlParameterd);
                return new ApplicationResponse
                {
                    Code = Convert.ToInt32(dt.Rows[0][0]),
                    Message = Convert.ToString(dt.Rows[0][1]),
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        //public PaginationData<CourseTitle> GetAllCourseTitle(string DbName, PaginationModel model)
        //{
        //    try
        //    {
        //        List<string> list = new List<string>();
        //        list.Add("StartRow");
        //        list.Add("EndRow");
        //        list.Add("SearchText");                                                       
        //        if (model.Sort != null)
        //        {
        //            list.Add("PropertyName");
        //            list.Add("Direction");
        //        }
        //        var parameters = list.ToArray(); 
        //        var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
        //        var data = (_dbHelper.GetDataTableToList<CourseTitle>(DbName, "[Common].[Master_GetAllCourseTitle]", sqlParameterd));
        //        var paginationData = new PaginationData<CourseTitle>();
        //        if (data != null)
        //        {
        //            paginationData.Total = data.Count();
        //            paginationData.Data = data;
        //        }
        //        return paginationData;
        //    }
        //    catch (Exception ex)
        //    {
        //        var helper = new Helpers.ExceptionHelper.DataException(ex);
        //        throw helper.GetException();
        //    }
        //}
        public CourseTitle GetCourseTitleById(int CourseTitleId, string DbName)
        {
            try
            {
                var sqlParameterd = _dbHelper.CreateSqlParameter("Id", CourseTitleId, DataType.AsInt);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_GetCourseTitleById]", sqlParameterd);
                return new CourseTitle
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    TitleName = Convert.ToString(dt.Rows[0]["TitleName"]),
                    CourseTypeName = Convert.ToString(dt.Rows[0]["CourseTypeName"]),
                    CourseTypeId = Convert.ToInt32(dt.Rows[0]["CourseTypeId"]),
                    CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]),
                    CreatedDate = Convert.ToString(dt.Rows[0]["CreatedDate"]),
                    IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"])
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public ApplicationResponse UpdateCourseTitle(CourseTitle model, string DbName)
        {
            try
            {
                var parameters = new string[] { "Id", "TitleName", "CourseTypeId", "IsActive", "CreatedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_EditCourseTitle]", sqlParameterd);
                return new ApplicationResponse
                {
                    Code = Convert.ToInt32(dt.Rows[0][0]),
                    Message = Convert.ToString(dt.Rows[0][1]),
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        #endregion
        #region Major
        public ApplicationResponse AddCourseMajor(Major model, string DbName)
        {
            try
            {
                var parameters = new string[] { "MajorName", "TitleId", "IsActive", "CreatedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_AddMajor]", sqlParameterd);
                return new ApplicationResponse
                {
                    Code = Convert.ToInt32(dt.Rows[0][0]),
                    Message = Convert.ToString(dt.Rows[0][1]),
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public List<Major> GetAllCourseMajor(string DbName)
        {
            try
            {
                return _dbHelper.GetDataTableToList<Major>(DbName, "[Common].[Master_GetAllMajor]");
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public Major GetCourseMajorById(int CourseMajorId, string DbName)
        {
            try
            {
                var sqlParameterd = _dbHelper.CreateSqlParameter("Id", CourseMajorId, DataType.AsInt);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_GetMajorById]", sqlParameterd);
                return new Major
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    TitleName = Convert.ToString(dt.Rows[0]["TitleName"]),
                    MajorName = Convert.ToString(dt.Rows[0]["MajorName"]),
                    TitleId = Convert.ToInt32(dt.Rows[0]["TitleId"]),
                    CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]),
                    CreatedDate = Convert.ToString(dt.Rows[0]["CreatedDate"]),
                    IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"])
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public ApplicationResponse UpdateCourseMajor(Major model, string DbName)
        {
            try
            {
                var parameters = new string[] { "Id", "MajorName", "TitleId", "IsActive", "CreatedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_EditMajor]", sqlParameterd);
                return new ApplicationResponse
                {
                    Code = Convert.ToInt32(dt.Rows[0][0]),
                    Message = Convert.ToString(dt.Rows[0][1]),
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        #endregion
        #region University
        public ApplicationResponse AddCourseUniversity(University model, string DbName)
        {
            try
            {
                var parameters = new string[] { "UniversityName", "CountryId", "StateId", "CityId", "IsActive", "IsBlacklist", "CreatedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "Common].[Master_AddUniversity]", sqlParameterd);
                return new ApplicationResponse
                {
                    Code = Convert.ToInt32(dt.Rows[0][0]),
                    Message = Convert.ToString(dt.Rows[0][1]),
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public List<University> GetAllCourseUniversity(string DbName)
        {
            try
            {
                return _dbHelper.GetDataTableToList<University>(DbName, "[Common].[Master_GetAllUniversity]");
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public University GetCourseUniversityById(int UniversityId, string DbName)
        {
            try
            {
                var sqlParameterd = _dbHelper.CreateSqlParameter("Id", UniversityId, DataType.AsInt);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_GetUniversityById]", sqlParameterd);
                return new University
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    UniversityName = Convert.ToString(dt.Rows[0]["UniversityName"]),
                    CountryId = Convert.ToInt32(dt.Rows[0]["CountryId"]),
                    StateId = Convert.ToInt32(dt.Rows[0]["StateId"]),
                    CityId = Convert.ToInt32(dt.Rows[0]["CityId"]),
                    CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]),
                    CreatedDate = Convert.ToString(dt.Rows[0]["CreatedDate"]),
                    IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                    IsBlacklist = Convert.ToBoolean(dt.Rows[0]["IsBlacklist"])
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public ApplicationResponse UpdateCourseUniversity(University model, string DbName)
        {
            try
            {
                var parameters = new string[] { "Id", "UniversityName", "CountryId", "StateId", "CityId", "IsActive", "IsBlacklist", "CreatedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_EditUniversity]", sqlParameterd);
                return new ApplicationResponse
                {
                    Code = Convert.ToInt32(dt.Rows[0][0]),
                    Message = Convert.ToString(dt.Rows[0][1]),
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        #endregion
        #region Institute
        public ApplicationResponse AddCourseInstitute(Institute model, string DbName)
        {
            try
            {
                var parameters = new string[] { "InstituteName", "UniversityId", "CountryId", "StateId", "CityId", "IsBlacklist", "IsActive", "CreatedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_AddInstitute]", sqlParameterd);
                return new ApplicationResponse
                {
                    Code = Convert.ToInt32(dt.Rows[0][0]),
                    Message = Convert.ToString(dt.Rows[0][1]),
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public List<Institute> GetAllCourseInstitute(string DbName)
        {
            try
            {
                return _dbHelper.GetDataTableToList<Institute>(DbName, "[Common].[Master_GetAllInstitute]");
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public Institute GetCourseInstituteById(int InstituteId, string DbName)
        {
            try
            {
                var sqlParameterd = _dbHelper.CreateSqlParameter("Id", InstituteId, DataType.AsInt);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_GetInstituteById]", sqlParameterd);
                return new Institute
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    InstituteName = Convert.ToString(dt.Rows[0]["InstituteName"]),
                    CountryId = Convert.ToInt32(dt.Rows[0]["CountryId"]),
                    StateId = Convert.ToInt32(dt.Rows[0]["StateId"]),
                    CityId = Convert.ToInt32(dt.Rows[0]["CityId"]),
                    CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]),
                    CreatedDate = Convert.ToString(dt.Rows[0]["CreatedDate"]),
                    IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]),
                    IsBlacklist = Convert.ToBoolean(dt.Rows[0]["IsBlacklist"])
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }
        public ApplicationResponse UpdateCourseInstitute(Institute model, string DbName)
        {
            try
            {
                var parameters = new string[] { "Id", "InstituteName", "UniversityId", "CountryId", "StateId", "CityId", "IsBlacklist", "IsActive", "CreatedBy" };
                var sqlParameterd = _dbHelper.CreateSqlParamByObj(model, parameters);
                DataTable dt = _dbHelper.GetDataTable(DbName, "[Common].[Master_EditInstitute]", sqlParameterd);
                return new ApplicationResponse
                {
                    Code = Convert.ToInt32(dt.Rows[0][0]),
                    Message = Convert.ToString(dt.Rows[0][1]),
                };
            }
            catch (Exception ex)
            {
                var helper = new Helpers.ExceptionHelper.DataException(ex);
                throw helper.GetException();
            }
        }

        public List<CourseTitle> GetAllCourseTitle(string DBName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

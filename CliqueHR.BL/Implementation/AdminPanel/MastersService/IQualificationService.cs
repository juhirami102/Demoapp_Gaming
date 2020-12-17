using CliqueHR.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.BL
{
    public interface IQualificationService
    {
        #region Course Type
        ApplicationResponse AddCourseType(CourseType model, UserContextModel objUser);
        List<CourseType> GetAllCourseType(UserContextModel objUser);
        CourseType GetCourseTypeByID(int ID, UserContextModel objUser);
        ApplicationResponse UpdateCourseType(CourseType model, UserContextModel objUser);
        #endregion
        #region CourseTitle
        ApplicationResponse AddCourseTitle(CourseTitle model, UserContextModel objUser);
        PaginationData<CourseTitle> GetAllCourseTitle(UserContextModel objUser, PaginationModel paginationModel);
        CourseTitle GetCourseTitleByID(int ID, UserContextModel objUser);
        ApplicationResponse UpdateCourseTitle(CourseTitle model, UserContextModel objUser);
        #endregion
        #region Major
        ApplicationResponse AddMajor(Major model, UserContextModel objUser);
        List<Major> GetAllMajor(UserContextModel objUser);
        Major GetMajorByID(int ID, UserContextModel objUser);
        ApplicationResponse UpdateMajor(Major model, UserContextModel objUser);
        #endregion
        #region University
        ApplicationResponse AddUniversity(University model, UserContextModel objUser);
        List<University> GetAllUniversity(UserContextModel objUser);
        University GetUniversityByID(int ID, UserContextModel objUser);
        ApplicationResponse UpdateUniversity(University model, UserContextModel objUser);
        #endregion
        #region Institute
        ApplicationResponse AddInstitute(Institute model, UserContextModel objUser);
        List<Institute> GetAllInstitute(UserContextModel objUser);
        Institute GetInstituteByID(int ID, UserContextModel objUser);
        ApplicationResponse UpdateInstitute(Institute model, UserContextModel objUser);
        #endregion

    }
}

using CliqueHR.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.DL
{
    public interface IQualificationRepository
    {
        #region Course Type
        ApplicationResponse AddCourseType(CourseType model, string DBName);
        List<CourseType> GetAllCourseType(string DBName);
        CourseType GetCourseTypeById(int Id, string DBName);
        ApplicationResponse UpdateCourseType(CourseType model, string DBName);
        #endregion
        #region Course Title
        ApplicationResponse AddCourseTitle(CourseTitle model, string DBName);
        List<CourseTitle> GetAllCourseTitle(string DBName);
        CourseTitle GetCourseTitleById(int Id, string DBName);
        ApplicationResponse UpdateCourseTitle(CourseTitle model, string DBName);
        #endregion
        #region Course Major
        ApplicationResponse AddCourseMajor(Major model, string DBName);
        List<Major> GetAllCourseMajor(string DBName);
        Major GetCourseMajorById(int Id, string DBName);
        ApplicationResponse UpdateCourseMajor(Major model, string DBName);
        #endregion
        #region Course University
        ApplicationResponse AddCourseUniversity(University model, string DBName);
        List<University> GetAllCourseUniversity(string DBName);
        University GetCourseUniversityById(int Id, string DBName);
        ApplicationResponse UpdateCourseUniversity(University model, string DBName);
        #endregion
        #region Course Institute
        ApplicationResponse AddCourseInstitute(Institute model, string DBName);
        List<Institute> GetAllCourseInstitute(string DBName);
        Institute GetCourseInstituteById(int Id, string DBName);
        ApplicationResponse UpdateCourseInstitute(Institute model, string DBName);
        #endregion
    }
}

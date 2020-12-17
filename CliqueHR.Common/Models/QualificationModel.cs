using CliqueHR.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.Common.Models
{
    public class QualificationModel
    {
       
    }
    public class CourseType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
    public class CourseTitle
    {
        public int Id { get; set; }
        public string TitleName { get; set; }
        public string CourseTypeName { get; set; }
        public int CourseTypeId { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
    public class Major
    {
        public int Id { get; set; }
        public string MajorName { get; set; }
        public string TitleName { get; set; }
        public int TitleId { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
    public class University
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public int CityName { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlacklist { get; set; }
    }
    public class Institute
    {
        public int Id { get; set; }
        public string InstituteName { get; set; }
        public string UniversityName { get; set; }
        public int UniversityId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public int CityName { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsBlacklist { get; set; }
    }

    public class CourseTypeValidation : AbstractValidator<CourseType>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public CourseTypeValidation()
        {
            this[ValidateAll_key] = ValidateAll;
        }
        private List<ValidationMessage> ValidateAll(CourseType model)
        {
            var message = new List<ValidationMessage>();
            if (string.IsNullOrEmpty(model.TypeName))
            {
                message.Add(new ValidationMessage
                {
                    Property = "TypeName",
                    Message = "TypeName can not be blank."
                });
            }
            return message;
        }
    }
    public class CourseTitleValidation : AbstractValidator<CourseTitle>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public CourseTitleValidation()
        {
            this[ValidateAll_key] = ValidateAll;
        }
        private List<ValidationMessage> ValidateAll(CourseTitle model)
        {
            var message = new List<ValidationMessage>();
            if (string.IsNullOrEmpty(model.TitleName))
            {
                message.Add(new ValidationMessage
                {
                    Property = "TitleName",
                    Message = "TitleName can not be blank."
                });
            }
            if (model.CourseTypeId <= 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "Course type",
                    Message = "Course type can not be blank."
                });
            }
            return message;
        }
    }

    public class MajorValidation : AbstractValidator<Major>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public MajorValidation()
        {
            this[ValidateAll_key] = ValidateAll;
        }
        private List<ValidationMessage> ValidateAll(Major model)
        {
            var message = new List<ValidationMessage>();
            if (string.IsNullOrEmpty(model.MajorName))
            {
                message.Add(new ValidationMessage
                {
                    Property = "MajorName",
                    Message = "MajorName can not be blank."
                });
            }
            if (model.TitleId <= 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "Course Title",
                    Message = "Course Title must be selected."
                });
            }
            return message;
        }
    }
    public class UniversityValidation : AbstractValidator<University>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public UniversityValidation()
        {
            this[ValidateAll_key] = ValidateAll;
        }
        private List<ValidationMessage> ValidateAll(University model)
        {
            var message = new List<ValidationMessage>();
            if (string.IsNullOrEmpty(model.UniversityName))
            {
                message.Add(new ValidationMessage
                {
                    Property = "UniversityName",
                    Message = "UniversityName can not be blank."
                });
            }
            if (model.CountryId <= 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "Country",
                    Message = "Country must be selected."
                });
            }
            if (model.StateId <= 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "State",
                    Message = "State must be selected."
                });
            }
            if (model.CityId <= 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "City",
                    Message = "City must be selected."
                });
            }
            return message;
        }
    }
    public class InstituteValidation : AbstractValidator<Institute>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public InstituteValidation()
        {
            this[ValidateAll_key] = ValidateAll;
        }
        private List<ValidationMessage> ValidateAll(Institute model)
        {
            var message = new List<ValidationMessage>();
            if (string.IsNullOrEmpty(model.InstituteName))
            {
                message.Add(new ValidationMessage
                {
                    Property = "InstituteName",
                    Message = "InstituteName can not be blank."
                });
            }
            if (model.UniversityId <= 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "University",
                    Message = "University must be selected."
                });
            }
            if (model.CountryId <= 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "Country",
                    Message = "Country must be selected."
                });
            }
            if (model.StateId <= 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "State",
                    Message = "State must be selected."
                });
            }
            if (model.CityId <= 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "City",
                    Message = "City must be selected."
                });
            }
            return message;
        }
    }

}

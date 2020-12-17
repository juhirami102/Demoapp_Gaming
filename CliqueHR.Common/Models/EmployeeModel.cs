using CliqueHR.Helpers.Validation;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CliqueHR.Common.Models
{
    public class EmployeeModel
    {
        public string TypeName { get; set; }
        public string SelfService { get; set; }
        public int MinAge { get; set; }
        public int CreatedBy { get; set; }
    }
    public class EmployeeModelValidation: AbstractValidator<EmployeeModel>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public EmployeeModelValidation()
        {
            this[ValidateAll_key] = ValidateAll;
        }

        private List<ValidationMessage> ValidateAll(EmployeeModel model)
        {
            var message = new List<ValidationMessage>();
            if (model.TypeName == "")
            {
                message.Add(new ValidationMessage
                {
                    Property = "TypeName",
                    Message = "TypeName can not be blank."
                });
            }
            if (model.SelfService == "")
            {
                message.Add(new ValidationMessage
                {
                    Property = "SelfService",
                    Message = "SelfService can not be blank."
                });
            }
            if (model.MinAge == 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "MinAge",
                    Message = "MinAge can not be 0."
                });
            }
            if (model.MinAge < 18)
            {
                message.Add(new ValidationMessage
                {
                    Property = "MinAge",
                    Message = "MinAge is greter than 18."
                });
            }
            return message;
        }
    }

    [XmlRoot("GlobalProfileModel")]
    public class GlobalProfileModel
    {
        [XmlElement]
        public int Id { get; set; }
        [XmlElement]
        public string SectionName { get; set; }
        [XmlElement]
        public string SectionCode { get; set; }
        [XmlElement]
        public bool IsEnable { get; set; }
        [XmlElement]
        public long CreatedBy { get; set; }
    }

    public class UserDefinedField
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public string SectionCode { get; set; }
        public bool IsEnable { get; set; }
        public string FieldName { get; set; }
        public int FieldTypeId { get; set; }
        public string FieldType { get; set; }
        public string FieldTypeValue { get; set; }
        public long CreatedBy { get; set; }
    }

    public class GlobalProfileValidation : AbstractValidator<GlobalProfileModel>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public GlobalProfileValidation()
        {
            this[ValidateAll_key] = ValidateAll;
        }
        private List<ValidationMessage> ValidateAll(GlobalProfileModel model)
        {
            var message = new List<ValidationMessage>();
            if (string.IsNullOrEmpty(model.SectionName))
            {
                message.Add(new ValidationMessage
                {
                    Property = "DisplayName",
                    Message = "Display Name can not be blank."
                });
            }
            return message;
        }
    }

    public class UserDefineValidation : AbstractValidator<UserDefinedField>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public UserDefineValidation()
        {
            this[ValidateAll_key] = ValidateAll;
        }
        private List<ValidationMessage> ValidateAll(UserDefinedField model)
        {
            var message = new List<ValidationMessage>();
            if (string.IsNullOrEmpty(model.SectionName))
            {
                message.Add(new ValidationMessage
                {
                    Property = "SectionName",
                    Message = "Section Name can not be blank."
                });
            }
            return message;
        }
    }

    public class GlobalProfileXML
    {
        public string globalprofilexml { get; set; }
    }

    public class UserProfileXML
    {
        public string userprofilexml { get; set; }
    }
}

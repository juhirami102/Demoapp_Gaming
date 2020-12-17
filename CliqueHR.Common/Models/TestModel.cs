using CliqueHR.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.Common.Models
{
    public class TestModel
    {
        public string TypeName { get; set; }
        public bool SelfService { get; set; }
        public int MinAge { get; set; }
        public int CreatedBy { get; set; }
    }
    public class TestModelValidation:AbstractValidator<TestModel>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public TestModelValidation()
        {
            this[ValidateAll_key] = ValidateAll;
        }

        private List<ValidationMessage> ValidateAll(TestModel model)
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
            //if (model.SelfService == "")
            //{
            //    message.Add(new ValidationMessage
            //    {
            //        Property = "SelfName",
            //        Message = "SelfName can not be blank."
            //    });
            //}
           
            if (model.MinAge < 18)
            {
                message.Add(new ValidationMessage
                {
                    Property = "MinAge",
                    Message = "MinAge should be less than 18."
                });
            }
            return message;
        }
    }
}

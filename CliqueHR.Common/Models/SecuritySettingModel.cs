using CliqueHR.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.Common.Models
{
    public class SecuritySettingModel
    {
    }

    public class SecuritySettings
    {
        public string TransType { get; set; }
        public int PasswordExpiryIndays { get; set; }
        public int SessionTimeOutInMins { get; set; }
        public string HideMobileNumberFromEd { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

    }

    public class SecuritySettingValidation : AbstractValidator<SecuritySettings>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public SecuritySettingValidation()
        {
            this[ValidateAll_key] = ValidateAll;
        }

        private List<ValidationMessage> ValidateAll(SecuritySettings model)
        {
            var message = new List<ValidationMessage>();
            if(model.PasswordExpiryIndays==0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "PasswordExpiryInDays",
                    Message = "Password Expiry In Days can not be blank."
                });
            }

            if (model.SessionTimeOutInMins == 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "SessionTimeOutInMins",
                    Message = "Session Time Out In Mins can not be blank."
                });
            }

            if (string.IsNullOrEmpty(model.HideMobileNumberFromEd))
            {
                message.Add(new ValidationMessage
                {
                    Property = "HideMobileNumberFromEd",
                    Message = "Hide Mobile Number From Ed can not be blank."
                });
            }


            return message;
        }
    }
}

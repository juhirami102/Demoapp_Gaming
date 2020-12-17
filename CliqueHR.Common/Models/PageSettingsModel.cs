using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliqueHR.Helpers.Validation;

namespace CliqueHR.Common.Models
{
    public class PageSettingsModel
    {
    }

    public class PageSettings
    {
        public string TransType { get; set; }
        public string LoginPageBackGroundImgOne { get; set; }
        public string LoginPageBackGroundImgTwo { get; set; }
        public string LoginPageBackGroundImgThree { get; set; }
        public string DashboardPageBackGroundImgOne { get; set; }
        public string DashboardPageBackGroundImgTwo { get; set; }
        public string DashboardPageBackGroundImgThree { get; set; }
        public string DashboardPageBackGroundImgFour { get; set; }
        public string DashboardPageBackGroundImgFive { get; set; }
        public int SlideShoutContent { get; set; }
        public bool IsBirthdayVisible { get; set; }
        public bool IsWorkAnniversaryVisible { get; set; }
        public bool IsMarriageAnniversaryVisible { get; set; }
        public bool IsNewJoineeVisible { get; set; }
        public bool IsExitVisible { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

    }

    public class PageSettingValidation : AbstractValidator<PageSettings>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public PageSettingValidation()
        {
            this[ValidateAll_key] = ValidateAll;
        }

        private List<ValidationMessage> ValidateAll(PageSettings model)
        {
            var message = new List<ValidationMessage>();
            if (string.IsNullOrEmpty(model.LoginPageBackGroundImgOne))
            {
                message.Add(new ValidationMessage
                {
                    Property = "LoginPageBackGroundImgOne",
                    Message = "Login Page BackGround Image One can not be blank."
                });
            }

            if (string.IsNullOrEmpty(model.DashboardPageBackGroundImgOne))
            {
                message.Add(new ValidationMessage
                {
                    Property = "DashboardPageBackGroundImgOne",
                    Message = "Dashboard Page BackGround Image One can not be blank."
                });
            }

            if (model.SlideShoutContent == 0)
            {
                message.Add(new ValidationMessage
                {
                    Property = "SlideShoutContent",
                    Message = "Slide Shout Content can not be blank."
                });
            }



            return message;
        }
    }
}

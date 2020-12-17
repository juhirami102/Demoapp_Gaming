using CliqueHR.Helpers.Validation;
using System.Collections.Generic;

namespace CliqueHR.Common.Models
{
    public class PaginationModel
    {
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public SortType Sort { get; set; }
        public string SearchText { get; set; }


    }
    public class SortType
    {
        public string PropertyName { get; set; }
        public string Direction { get; set; }
    }

    public class PaginationData<T> where T : class
    {
        public int Total { get; set; }
        public List<T> Data { get; set; }
    }

    public class PaginationValidator : AbstractValidator<PaginationModel>
    {
        public static readonly string ValidateAll_key = "ValidateAll_key";
        public PaginationValidator()
        {
            this[ValidateAll_key] = ValidateAll;
        }
        private List<ValidationMessage> ValidateAll(PaginationModel model)
        {
            var messages = new List<ValidationMessage>();

            return messages;
        }
    }
}

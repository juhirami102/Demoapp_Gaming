using System;
using System.Collections.Generic;

namespace CliqueHR.Helpers.Validation {
    public class ValidationMessage {
        public string Property { get; set; }
        public string Message { get; set; }
    }
    public class ValidationResponse {
        public List<int> Index { get; set; }
        public List<ValidationMessage> Messages { get; set; }
    }
}
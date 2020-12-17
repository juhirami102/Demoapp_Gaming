using System;

namespace CliqueHR.Helpers.ExceptionHelper
{
    public class ValidationException : Exception, IUserException {

        public new object Data { get; set; }
        public ValidationException (object data) : base ("") {
            this.Data = data;
        }
    }
}
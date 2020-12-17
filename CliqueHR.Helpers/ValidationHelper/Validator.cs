using System;
using System.Collections.Generic;

namespace CliqueHR.Helpers.Validation {
    public interface IValidator<T> {
        ValidationResponse Validate (string ValidatorName, T model, string nullMessage);
        List<ValidationResponse> Validate (string ValidatorName, List<T> modelList, string nullMessage);
    }

    public static class Validator {
        public static ValidationMessage CreateValidationMessageInstance (string Property, string Message) {
            return new ValidationMessage {
                Property = Property,
                    Message = Message
            };
        }

        public static ValidationResponse GetValidationResponseInstance () {
            return new ValidationResponse {
                Messages = new List<ValidationMessage> ()
            };
        }
    }
    public abstract class AbstractValidator<T> : IValidator<T> where T : class {
        private Dictionary<string, Func<T, List<ValidationMessage>>> validatorCol = new Dictionary<string, Func<T, List<ValidationMessage>>> ();
        protected Func<T, List<ValidationMessage>> this [string key] {
            set {
                validatorCol[key] = value;
            }
            get {
                return validatorCol[key];
            }
        }

        public ValidationResponse Validate (string ValidatorName, T model, string nullMessage) {
            ValidationResponse response = new ValidationResponse ();
            var messages = new List<ValidationMessage> ();
            if (model == null) {
                messages.Add (new ValidationMessage { Message = nullMessage });
                response = new ValidationResponse {
                    Messages = messages,
                    Index = new List<int> ()
                };
                return response;
            }
            var validatorMethod = this [ValidatorName];
            if (validatorMethod == null) {
                throw new Exception ("validator method is null");
            }
            var modelMessage = validatorMethod (model);
            if (modelMessage != null && modelMessage.Count != 0) {
                messages.AddRange (modelMessage);
                response = new ValidationResponse {
                    Messages = messages
                };
                return response;
            }
            return response;
        }
        public List<ValidationResponse> Validate (string ValidatorName, List<T> modelList, string nullMessage) {
            List<ValidationResponse> responseList = new List<ValidationResponse> ();
            if (modelList == null) {
                responseList.Add (
                    new ValidationResponse {
                         Messages =
                            new List<ValidationMessage> {
                                new ValidationMessage { Message = "Model List is null", Property = "ModelList" }
                            }
                    }
                );
                return responseList;
            }
            int i = 0;
            foreach (var model in modelList) {
                var resp = Validate (ValidatorName, model, nullMessage);
                if (resp.Messages != null) {
                    resp.Index.Add (i);
                    responseList.Add (resp);
                }
                i++;
            }
            return responseList;
        }
    }
}
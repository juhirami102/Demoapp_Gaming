using CliqueHR.Helpers.ExceptionHelper;
using CliqueHR.Helpers.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CliqueHR.Api.Application
{
    public class AppPresentationException : PresentationException
    {
        public AppPresentationException(Exception ex) : base(ex)
        {
            if (ex is ValidationStrategy)
            {
                // Log Error
                Log.Info("AppPresentationException", "Validation Message", string.Empty);
            }
            else
            {
                // Log Error
                Log.Error("AppPresentationException", "Exception occured.", ex.InnerException != null ? ex.InnerException.Message : "", ex);
            }
        }
        public HttpResponseMessage GetResponse(ApiController apiController)
        {
            var statusResponse = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), this.GetStrategy().StatusCode.ToString());
            return apiController.Request.CreateResponse(statusResponse, this.GetStrategy().GetData());
        }
    }
}
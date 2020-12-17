using CliqueHR.Api.Application;
using CliqueHR.BL;
using CliqueHR.BL.Imp;
using CliqueHR.Common.Models;
using CliqueHR.Helpers.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CliqueHR.Api.Controllers
{
    //[Route("api/[controller]")]
    public class TestController : ApiController
    {
        private ITestService _testService;
        public TestController()
        {
            _testService = new TestService();
        }
        [HttpPost]
        public HttpResponseMessage AddTestData(TestModel testModel)
        {
            try
            {
                Log.Info("TestController:AddMenu", "Add TestData START", string.Empty);
                 _testService.AddTestData(testModel);
                Log.Info("TestController:AddMenu", "Add TestData END", string.Empty);
                return this.Request.CreateResponse(HttpStatusCode.OK, new { Messsage="Data added Successfully!"});
            }
            catch (Exception ex)
            {
                var helper = new AppPresentationException(ex);
                return helper.GetResponse(this);
            }
        }
    }
}

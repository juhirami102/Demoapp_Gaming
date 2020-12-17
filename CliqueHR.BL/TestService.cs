using CliqueHR.BL.Imp;
using CliqueHR.Common.Models;
using CliqueHR.DL;
using CliqueHR.DL.Imp;
using CliqueHR.Helpers.ExceptionHelper;
using CliqueHR.Helpers.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.BL
{
    public class TestService : ITestService
    {
        private ITestRepository _testRepository;
        private TestModelValidation _modelValidation;
        public TestService()
        {
            _testRepository = new TestRepository();
            _modelValidation = new TestModelValidation();
        }
        public void AddTestData(TestModel model)
        {
            //var valResponse = Validator.GetValidationResponseInstance();
            try
            {
                var validationResponse = _modelValidation.Validate(TestModelValidation.ValidateAll_key, model, "billing model can not be empty.");
                if (validationResponse.Messages != null)
                {
                    throw new ValidationException(validationResponse);
                }
                 _testRepository.AddTestData(model);

            }
            catch(Exception ex)
            {
                var helper = new BusinessException(ex);
                throw helper.GetException();
            }
        }
        public TestModel GetTestData()
        {
            throw new NotImplementedException();
        }

        public TestModel GetTestDataByID(int ID)
        {
            throw new NotImplementedException();
        }

        public string UpdateTestData(TestModel model)
        {
            throw new NotImplementedException();
        }
    }
}

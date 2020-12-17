using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliqueHR.Common.Models
{
    public class ApplicationResponse<T> where T : class
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public class ApplicationResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}

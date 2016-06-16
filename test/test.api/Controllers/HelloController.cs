using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test.logic;

namespace Test.Api.Controllers
{
    public class HelloController : ApiController
    {
        public dynamic Get()
        {
            var testService = new TestService();
            return new
            {
                IsSuccess = true,
                Message = DateTime.Now
            };
        }
        public void WriteToFile(string str, string fileName)
        {
            throw new Exception($"File {fileName} directory invalidate.");
        }

        /// <summary>
        /// Gets the string value for a given Enum's Value.
        /// This will only work if you assign the StringValue
        /// attribute to the items in your enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetStringValue(string value)
        {
            return value?.ToUpper().Trim();
        }
    }
}

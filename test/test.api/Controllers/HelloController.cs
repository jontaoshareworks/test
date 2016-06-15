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
            string x = "急啊急啊"; 
            var testService = new TestService();
            return new
            {
                IsSuccess = true,
                Message = DateTime.Now
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAPiController : ControllerBase
    {
        protected TestService testService { get; }
        public TestAPiController(TestService _testService)
        {
            testService = _testService;
        }

        [HttpGet]
        public string GetValue()
        {
            var result = testService.GetValue();
            return result;
        }
    }
}
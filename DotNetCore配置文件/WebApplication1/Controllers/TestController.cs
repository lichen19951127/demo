using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        private readonly IOptions<AppSettingOptions> _options;
        public TestController(IOptions<AppSettingOptions> options)
        {
            _options = options;
        }

        public IActionResult Index()
        {
            var AllowedHosts = _options.Value.AllowedHosts;
            var DefaultConnection = _options.Value.ConnectionStrings.DefaultConnection;
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using reCAPTCHA.AspNetCore;
using Web.Models;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        private readonly IRecaptchaService _recaptcha;

        public TestController(IRecaptchaService recaptcha)
        {
            _recaptcha = recaptcha;
        }
        // GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var recaptchaReault = await _recaptcha.Validate(model.GoogleToken);
                //recaptchaReault.score<1m
                if (!recaptchaReault.success || recaptchaReault.score==0m)
                {
                    ModelState.AddModelError(string.Empty, "人机验证失败，请稍后重试");
                }
            }

            return View(model);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestQA.Web.Controllers
{
    public class TemplateController : Controller
    {
        //
        // GET: /Template/
        public ActionResult Post()
        {
            return View("PostTemplate");
        }

        public ActionResult Answer()
        {
            return View("AnswerTemplate");
        }
	}
}
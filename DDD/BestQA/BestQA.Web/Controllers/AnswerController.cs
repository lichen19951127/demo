using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using BestQA.Commands;
using BestQA.Web.Extensions;
using BestQA.Web.Models;
using ECommon.Utilities;
using ENode.Commanding;
using Microsoft.AspNet.Identity;

namespace BestQA.Web.Controllers
{
    public class AnswerController : Controller
    {
        private readonly ICommandService _commandService;
        public AnswerController(ICommandService commandService)
        {
            _commandService = commandService;
        }
       
        //
        // POST: /Question/Create
        [HttpPost]
        [AsyncTimeout(5000)]
        public async Task<JsonResult> Create(AnswerModel answer)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelErrorModel> modelErrors = ModelStateHelpers.GetModelStateErrors(ModelState);
                return Json(new { validationErrors = modelErrors }, JsonRequestBehavior.AllowGet);
            }

            var newId = ObjectId.GenerateNewStringId();
            var result = await _commandService.ExecuteAsync(
            new CreateAnswerCmd(answer.Content,User.Identity.GetUserName(),answer.PostId) 
                { AggregateRootId = newId });
            if (result.Data.Status == CommandStatus.Success)
            {
                return Json(new { data = newId }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = "error" }, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        //
        // POST: /Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private async Task<JsonResult> ExecuteAsync(Command<string> command)
        {
            var result = await _commandService.ExecuteAsync(command);
            if (result.Data.Status == CommandStatus.Success)
            {
                return Json(new { data = "success" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = result.Data.ErrorMessage }, JsonRequestBehavior.AllowGet);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BestQA.Commands;
using BestQA.QueryService;
using BestQA.QueryService.DTOs;
using BestQA.QueryService.Grid;
using BestQA.Web.Extensions;
using BestQA.Web.Models;
using ECommon.Utilities;
using ENode.Commanding;
using Microsoft.AspNet.Identity;

namespace BestQA.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ICommandService _commandService;
        private readonly IQuestionQuery _queryService;
        public QuestionController(ICommandService commandService, IQuestionQuery questionQuery)
        {
            _commandService = commandService;
            _queryService = questionQuery;
        }
        //
        // GET: /Question/
        public ActionResult Index(string tab)
        {
            ViewBag.Questions = "active";
            if (string.IsNullOrEmpty(tab))
                tab = "recent";
            ViewBag.ActiveTab = tab;
            return View();
        }
        //
        // GET: /Question/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.PageMode = "update";   //页面模式
            return View(_queryService.Find(id));
        }

        /// <summary>
        /// 创建问题页面
        /// </summary>
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Create = "active";
            ViewBag.PageMode = "create"; 
            QuestionDTO postViewModel = new QuestionDTO { Id = string.Empty };
            return View("Details", postViewModel);
        }

        /// <summary>
        /// 返回全部问题列表
        /// </summary>
        [HttpPost]
        public JsonResult Get(PostFilterViewModel filterView)
        {
            IList<QuestionDTO> questions = _queryService.FindAll().ToList();
            return Json(new { data = questions }, JsonRequestBehavior.AllowGet);
        }
        //
        // POST: /Question/Create
        [HttpPost]
        [Authorize]
        [AsyncTimeout(5000)]
        public async Task<JsonResult> Create(QuestionModel question)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelErrorModel> modelErrors = ModelStateHelpers.GetModelStateErrors(ModelState);
                return Json(new { validationErrors = modelErrors }, JsonRequestBehavior.AllowGet);
            }
            var newId = ObjectId.GenerateNewStringId();
            var result = await _commandService.ExecuteAsync(
            new CreateQuestionCmd(question.Title,
                question.Content,
                question.Reward,
                question.Tag,
                User.Identity.GetUserName()) 
                { AggregateRootId = newId });
            if (result.Data.Status == CommandStatus.Success)
            {
                return Json(new { data = newId }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { data = "error" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        [AsyncTimeout(5000)]
        public async Task<JsonResult> VoteUp(QuestionDTO question)
        {
            return await ExecuteAsync(new QuestionVoteUpCmd(question.Id, User.Identity.GetUserName()));
        }

        [HttpPost]
        [Authorize]
        [AsyncTimeout(5000)]
        public async Task<JsonResult> VoteDown(QuestionDTO question)
        {
            return await ExecuteAsync(new QuestionVoteDownCmd(question.Id, User.Identity.GetUserName()));
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

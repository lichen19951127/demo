using System.Threading.Tasks;
using System.Web.Mvc;

namespace BestQA.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Home = "active";
            return View();
        }
    }
}

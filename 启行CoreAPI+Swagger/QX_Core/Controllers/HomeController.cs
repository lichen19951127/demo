using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QX_Core.Common;
using QX_Core.Models;
using QX_IService;
using QX_Models;
using Newtonsoft.Json;
namespace QX_Core.Controllers
{
    public class HomeController : Controller
    {
        readonly IUserInfo userinfo;
        public HomeController(IUserInfo _userinfo)
        {
            userinfo = _userinfo;
        }
        public IActionResult Index(string txtUserName = "", string txtPassword = "")
        {
            DoSession();

            List<UserInfo> List = userinfo.GetList().ToList().Where(p => (txtUserName == null ? false : p.UserName == null ? false : p.UserName.Contains(txtUserName))
                                                                    ||
                                                                   (txtPassword == null ? false : p.Password == null ? false : p.Password.Contains(txtPassword))).ToList();
            return View(List);
        }

        public IActionResult Update(int id)
        {
            UserInfo model = userinfo.GetModel();
            return View(model);
        }

        public IActionResult DeleteDo(int id)
        {

            bool sign = userinfo.Delete(id.ToString());
            if (sign)
            {
                return Content("<script>alert('删除成功');location.href='/home/index'</script>", "text/html", System.Text.Encoding.UTF8);
            }
            else
            {
                return Content("<script>alert('删除失败');location.href='/home/index'</script>", "text/html", System.Text.Encoding.UTF8);
            }
        }

        public IActionResult UpdateDo(UserInfo Model)
        {
            bool sign = userinfo.Update(Model);
            if (sign)
            {
                return Redirect("/Home/index");
            }
            else
            {
                return Content("<script>alert('修改失败');location.href='/home/index'</script>", "text/html", System.Text.Encoding.UTF8);
            }

        }

        public IActionResult AddDo(UserInfo model)
        {

            bool sign = userinfo.Add(model);

            if (sign)
            {
                return Redirect("/Home/index");
            }
            else
            {
                return Content("<script>alert('添加失败');location.href='/home/index'</script>", "text/html", System.Text.Encoding.UTF8);
            }

        }

        public IActionResult Add()
        {
            string Values = HttpContext.Session.GetString("MyTestValue");

            string cookieValues = GetCookies("CookieTestValues");
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //保存Cookie
        public void SetCookies(string key, string value, int minutes = 30)
        {
            HttpContext.Response.Cookies.Append(key, value, new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(minutes),
                IsEssential = true
            });
        }


        /// <summary>
        /// 删除指定的cookie
        /// </summary>
        /// <param name="key">键</param>
        public void DeleteCookies(string key)
        {
            HttpContext.Response.Cookies.Delete(key);
        }

        /// <summary>
        /// 获取cookies
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>返回对应的值</returns>
        public string GetCookies(string key)
        {
            HttpContext.Request.Cookies.TryGetValue(key, out string value);
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }
        /// <summary>
        /// 关于Session的操作
        /// </summary>
        public void DoSession()
        {
            UserInfo user = new UserInfo();
            user.UserName = "admin";
            HttpContext.Session.SetString("MyTestValue", JsonConvert.SerializeObject(user));
            HttpContext.Session.SetInt32("MyTestValue", 123);
            //string Values = HttpContext.Session.GetString("MyTestValue");
            int Values = (int)HttpContext.Session.GetInt32("MyTestValue");
            //Session["Key"]="";



            SetCookies("CookieTestValues", "111111");

            string cookieValues = GetCookies("CookieTestValues");

            ClassInfo cls = new ClassInfo();
            cls.ID = 1;
            cls.ClassName = "qx1901";
            //string outStatus = "";
            //var result = HttpClientHelper.PostResponse("https://localhost:44367/api/values", JsonConvert.SerializeObject(cls), out outStatus);

            var content = new StringContent("[{\"ID\":\"1\"},{\"ClassName\":\"admin\"}]", Encoding.UTF8, "application/json");


            var result = HttpClientHelper.Client("get", "https://localhost:44367/api/values", content);
        }



    }
}

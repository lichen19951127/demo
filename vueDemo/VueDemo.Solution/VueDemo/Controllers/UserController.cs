using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VueDemo.Controllers
{
    using VueBLL;
    using MODEL;
    using Newtonsoft.Json;
    public class UserController : Controller
    {
        public UserBll userbll = new UserBll();
        // GET: User
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分页+模糊查询显示
        /// </summary>
        /// <returns></returns>
        public string IndexShow(string currentpage,string name)
        {
            ///获得所有用户信息
            string users = userbll.GetUser();
            var userlist = JsonConvert.DeserializeObject<List<TUser>>(users);
            if (currentpage == null)
            {
                currentpage = "1";
            }
            if (!String.IsNullOrEmpty(name))
            {
                userlist = userlist.Where(u=>u.Name.Contains(name)).ToList();
            }
           
            //一页显示3条
            int totlepage = userlist.Count / 3 + (userlist.Count % 3 == 0 ? 0 : 1);
            userlist = userlist.Skip((int.Parse( currentpage) - 1) * 3).Take(3).ToList();
             
            PageBox pagebox = new PageBox();
            pagebox.CurrentPage = int.Parse(currentpage);
            pagebox.TotlePage = totlepage;
            pagebox.PageData = userlist;

            var json = JsonConvert.SerializeObject(pagebox);
            return json;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int Add(TUser user)
        {  
            int result= userbll.AddUser(user);
            return result;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int Delete(int id)
        {
            int result = userbll.DeleteUser(id);
            return result;

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int Update(TUser user)
        {
            int result = userbll.UpdateUser(user);
            return result;
           // return IndexShow("1");

        }
        /// <summary>
        /// 添加用户视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddUser()
        {
            return View();
        }
    }
}
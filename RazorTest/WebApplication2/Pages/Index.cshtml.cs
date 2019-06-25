using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        //TempData是Asp.Net Core 2.0新增的特性 临时数据
        //加上TempData特性的属性，会在你跳转路由或者页面的时候隐性的传递过去
        [TempData]
        public string Message { get; set; }
        //绑定数据
        [BindProperty(SupportsGet = true)]
        public User User { get; set; }
        public void OnGet()
        {
            Message = "this is test";
            User.Id=Guid.NewGuid();
            User.Name = "张三";
        }
    }
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

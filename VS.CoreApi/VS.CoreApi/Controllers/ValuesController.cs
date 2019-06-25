using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using VS.IService;

namespace VS.CoreApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ValuesController : Controller
    {
        /// <summary>
        /// 用户服务对象
        /// </summary>
        public IUserInforService _userInforService;

        /// <summary>
        /// 注入对象
        /// </summary>
        /// <param name="userService"></param>
        public ValuesController(IUserInforService userService)
        {
            _userInforService = userService;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<UserInfor> list = _userInforService.QueryList();
            return Ok(list);
        }

        /// <summary>
        /// 获取单个用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UserInfor user = _userInforService.QueryById(id);
            return Ok(user);
        }

        /// <summary>
        /// 添加
        /// </summary>
        [HttpPost]
        public void Post()
        {
            UserInfor user = new UserInfor()
            {
                Name = "张三",
                Age = 17
            };
            _userInforService.InsertEntity(user);
        }
    }
}

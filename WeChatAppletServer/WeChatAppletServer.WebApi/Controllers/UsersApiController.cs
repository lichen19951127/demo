using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeChatAppletServer.Entity;
using WeChatAppletServer.IService;

namespace WeChatAppletServer.WebApi.Controllers
{
    [EnableCors("AllowSameDomain")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        protected IUserService _iUserService;
        public UsersApiController(IUserService iUserService)
        {
            _iUserService = iUserService;
        }
        [HttpPost]
        public bool Add(Users t)
        {
            var result = _iUserService.Add(t);
            return result;
        }
        [HttpPost]
        public bool Delete(int Id)
        {
            var result = _iUserService.Delete(Id);
            return result;
        }
        [HttpGet]
        public List<Users> GetList()
        {
            var result = _iUserService.GetList();
            return result;
        }
        [HttpGet]
        public Users GetSingle(int Id)
        {
            var result = _iUserService.GetSingle(Id);
            return result;
        }
        [HttpPost]
        public bool Update(Users t)
        {
            var result = _iUserService.Update(t);
            return result;
        }
    }
}
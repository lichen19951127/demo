using Model;
using System;
using System.Collections.Generic;
using System.Text;
using VS.IRepository;
using VS.IService;

namespace VS.Service
{
    public class UserInforService:BaseService<UserInfor>,IUserInforService
    {
        private IUserInforDal UserInforDal { get; set; }
        public UserInforService(IUserInforDal userInforDal)
        {
            base.BaseDal = userInforDal;
            UserInforDal = userInforDal;
        }
    }
}

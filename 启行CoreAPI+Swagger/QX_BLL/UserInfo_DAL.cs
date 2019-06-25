using System;
using System.Collections.Generic;
using QX_IService;
using QX_Models;
using DataAccess;
using SqlSugar;
using System.Linq;
namespace QX_Serivce
{
    public class UserInfo_DAL : SqlSugarBaseClient, IUserInfo
    {

        public bool Add(UserInfo model)
        {
            return DB.Insertable<UserInfo>(model).ExecuteCommand() > 0;
        }
       /// <summary>
       /// 1,2,3,4
       /// </summary>
       /// <param name="ids"></param>
       /// <returns></returns>
        public bool Delete(string ids)
        {
            return DB.Deleteable<UserInfo>().In(ids).ExecuteCommand() > 0;
        }

        public List<UserInfo> GetList()
        {
            ////两表联查
            //var result = DB.Queryable<UserInfo, ClassInfo>((a, b) => new object[] {
            // JoinType.Left,a.CID==b.ID})
            //.Select((a, b) => new { Student = a.UserName, Teacher = b.ClassName }).ToList();



            //多表联查
            //var result = DB.Queryable<Student, Teacher, Course>((a, b, c) => new object[] {
            //            JoinType.Left,a.CourseId == b.CourseId,
            //            JoinType.Left,b.CourseId == c.Code
            //        })
            //        .Where(a => a.Id == id)
            //        .Select((a, b, c) => new { Student = a.Name, Teacher = b.Name, Course = c.name }).ToList();



            DB.SqlQueryable<UserInfo>("select * from userinfo");

            List<UserInfo> List = DB.Queryable<UserInfo>().ToList();

            List<ClassInfo> ListClass = DB.Queryable<ClassInfo>().ToList();

            var res = from n in List
                      join b in ListClass on n.CID equals b.ID

                      select new {n.UserName,b.ClassName };

            return List;
        }

        public UserInfo GetModel()
        {
            return DB.Queryable<UserInfo>().First();
        }

        public bool Update(UserInfo model)
        {
            return DB.Updateable<UserInfo>(model).ExecuteCommand() > 0;
        }
    }
}

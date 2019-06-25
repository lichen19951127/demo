using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    using Entity;
    using SqlSugar;
    public class UsersDAL
    {
        private SqlSugar.SqlSugarClient db = null;
        public UsersDAL()
        {
            if (db == null)
                db = SqlSugarClientHelper.SqlDBConnection;
        }
        public List<Users> Query()
        {
            //分页方式2+符合查询 多where是and拼接
            var query2 = db.Queryable<Users>();

            int allCount2 = 0;
            //分页
            List<Users> list2 = query2.ToPageList(2, 2, ref allCount2);
            
            //普通查询
            var result = db.Ado.SqlQuery<Users>("select * from Users");
            return list2;
        }
        public int Add(Users u)
        {
            var sql = "insert into users values(@Name)";
            SugarParameter[] parm ={
                new SugarParameter("@Name",u.Name)
            };
            //新增
            var addResult = db.Insertable(u).ExecuteCommand();
            //修改
            var updateResult = db.Updateable(u).ExecuteCommand();
            //删除
            var deleteResult = db.Deleteable(u).ExecuteCommand();

            var result = db.Ado.ExecuteCommand(sql,parm);
            return result;
        }
        public int AddProc(Users u)
        {
            SugarParameter[] parm ={
                new SugarParameter("@Name",u.Name)
            };
            var result = db.Ado.ExecuteCommand("exec p_Add @Name", parm);
            return result;
        }
        public int Delete(int Id)
        {
            var sql = "delete from users where Id=@Id";
            SugarParameter[] parm ={
                new SugarParameter("@Id",Id)
            };
            var result = db.Ado.ExecuteCommand(sql, parm);
            return result;
        }
        public int Update(Users u)
        {
            var sql = "update users set Name=@Name where Id=@Id";
            SugarParameter[] parm ={
                new SugarParameter("@Name",u.Name),
                new SugarParameter("@Id",u.Id)
            };
            var result = db.Ado.ExecuteCommand(sql, parm);
            return result;
        }

    }
}

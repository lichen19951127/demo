using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [SugarTable("tb_user")] //数据库表名称
    public class UserInfor
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]  //配置主键 自增长
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
      
    }
}

using Dapper;
using Entity;
using IService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class UsersService : BaseRepository, IUsersService
    {
        public int Add(Users t)
        {
            var sql = string.Format("insert into Users(Id,Name) values('{0}','{1}')", t.Id,t.Name);
            var result = 0;
            using (var conn = GetMySqlConnection())
            {
                result = conn.Execute(sql);
            }
            return result;
        }

        public int Delete(int id)
        {
            var sql = string.Format("delete from Users where Id='{0}'", id);
            var result = 0;
            using (var conn = GetMySqlConnection())
            {
                result = conn.Execute(sql);
            }
            return result;
        }

        public List<Users> Query()
        {
            var sql = string.Format("select * from Users ");
            var result =new List<Users>();
            using (var conn = GetMySqlConnection())
            {
                result = conn.Query<Users>(sql).ToList();
            }
            return result;
        }

        public Users QueryById(int id)
        {
            var sql = string.Format("select * from Users where Id='{0}'",id);
            var result = new Users();
            using (var conn = GetMySqlConnection())
            {
                result = conn.QueryFirst<Users>(sql);
            }
            return result;
        }

        public int Update(Users t)
        {
            var sql = string.Format("update Users set Name='{0}' where Id='{1}'", t.Name,t.Id);
            var result = 0;
            using (var conn = GetMySqlConnection())
            {
                result = conn.Execute(sql);
            }
            return result;
        }

        public async Task<Users> FindUserByAccount(int regattaId, int userId)
        {
            try
            {
                var cmdText =
                    @"select b.id_number as IdentifierId,b.isvalid as Isvalid,a.name as Name,a.userid as InternalId,a.sex as Sexual,a.sex as SexTypeId,a.age as Age,
                                c.isprofessional as IsProfessional,c.role_type as RoleTypeId,a.weight as Weight,a.height as Height, a.phone as PhoneNumber,a.thumb_image as ThubmnailImage,
                                a.image as Image,c.athlete_id as  AthleteId from 表1 a  left join 表2 b on a.userid=b.id 
                                left join 表3 c on b.id=c.centralid where a.userid=@userId;";
                using (var conn = GetMySqlConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        await conn.OpenAsync();
                    }

                    var memberModel = conn
                        .Query<Users>(cmdText, new { userId = userId }, commandType: CommandType.Text)
                        .FirstOrDefault();
                    return memberModel ?? null;
                }
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "FindUserByAccount by Id Failed!");
                throw ex;
            }


        }


        public async Task<bool> DeleteXXX(int regattaId, int id, int userId)
        {
            var result = false;
            using (var conn = GetMySqlConnection())
            {
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        const string sqlDelClub =
                            @"delete from 表名 where 字段1=@clubId;
                              delete from 表名2 where 字段2=@clubId;
                              delete from 表名3 where 字段3=@userId and clubinfo_id=@clubId;";
                        await conn.QueryAsync(sqlDelClub, new
                        {
                            clubId = id,
                            userId = userId,
                        }, commandType: CommandType.Text);
                        transaction.Commit();
                        result = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        transaction.Rollback();
                        result = false;
                        throw;
                    }
                }
                return result;
            }
        }


        public async Task<List<Users>> GetClubsByUserId(int regattaId, int userId)
        {
            using (var conn = GetMySqlConnection())
            {
                if (conn.State == ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                }
                const string sql =
                    @"select b.club_id as id,c.name,c.image as ImageData,c.year,c.address,c.creator,c.description,b.contact ,b.phone,b.isvalid from 表1 a left join 表2 b on 
                      a.clubinfo_id=b.club_id left join 表3 c on 
                      b.clubbase_id=c.club_id where a.authorize_userid=@user_Id";
                List<Users> clubDetailList =
                    (await conn.QueryAsync<Users>(sql, new { user_Id = userId }, commandType: CommandType.Text))
                    .ToList();
                return clubDetailList;
            }
        }
    }
}

using AutoMapper;
using System;

namespace ConsoleApp4
{
    /// <summary>
    /// 使用Profile配置
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<UserProfile>());
            //不同属性名
            User user = new User()
            {
                Id = 1,
                Name = "caoyc",
                Age = 20
            };
            var dto = Mapper.Map<UserDto>(user);
            //空值替换NullSubstitute  
            User user1 = new User()
            {
                Id = 1,
                Age = 20
            };
            //Name2=值为空
            var dto1 = Mapper.Map<UserDto>(user1);
            //忽略属性Ignore
            User user2 = new User()
            {
                Id = 1,
                Name = "caoyc",
                Age = 20
            };
            //Name2=null
            var dto2 = Mapper.Map<UserDto>(user2);
        }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            base.CreateMap<User, UserDto>()
            //不同属性名
            .ForMember(d => d.Name2, opt =>
            {
                opt.MapFrom(s => s.Name);
            })
            //空值替换NullSubstitute    
            .ForMember(d => d.Name2, opt => opt.NullSubstitute("值为空"))
            //忽略属性Ignore
            .ForMember("Name2", opt => opt.Ignore())

            ;
        }
    }


    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class UserDto
    {
        public string Name2 { get; set; }
        public int Age { get; set; }
    }
}

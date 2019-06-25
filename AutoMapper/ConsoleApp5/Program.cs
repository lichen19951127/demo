using System;
using AutoMapper;

namespace ConsoleApp5
{
    /// <summary>
    /// 预设值
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<UserProfile>());

            User user = new User()
            {
                Id = 1,
                Name = "caoyc",
                Age = 20
            };

            UserDto dto = new UserDto() { Gender = "男" };
            Mapper.Map(user, dto);
        }
    }
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            base.CreateMap<User, UserDto>();
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
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}

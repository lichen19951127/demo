using System;
using AutoMapper;
namespace ConsoleApp2
{
    /// <summary>
    /// AutoMapper会根据字段名称去自动对于，忽略大小写
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(x => x.CreateMap<User, UserDto>());
            User user = new User()
            {
                Id = 1,
                Name = "caoyc",
                Age = 20
            };
            var dto = Mapper.Map<UserDto>(user);
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
    }
}

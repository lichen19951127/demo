using System;
using AutoMapper;
namespace ConsoleApp3
{
    class Program
    {
        /// <summary>
        /// 属性名称不同
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Mapper.Initialize(x =>
        x.CreateMap<User, UserDto>()
         .ForMember(d => d.Name2, opt => {
             opt.MapFrom(s => s.Name);
         })
        );

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
        public string Name2 { get; set; }
        public int Age { get; set; }
    }
}

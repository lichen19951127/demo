using AutoMapper;
using System;

namespace ConsoleApp7
{
    /// <summary>
    /// 条件约束Condition
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<UserProfile>());

            User user0 = new User() { Age = 1 };
            User user1 = new User() { Age = 150 };
            User user2 = new User() { Age = 201 };
            var dto0 = Mapper.Map<UserDto>(user0);
            var dto1 = Mapper.Map<UserDto>(user1);
            var dto2 = Mapper.Map<UserDto>(user2);

            Console.WriteLine("dto0:{0}", dto0.Age);
            Console.WriteLine("dto1:{0}", dto1.Age);
            Console.WriteLine("dto2:{0}", dto2.Age);
        }
    }
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ForMember(dest => dest.Age, opt => opt.Condition(src => src.Age >= 0 && src.Age <= 200));
        }
    }
    public class User
    {
        public int Age { get; set; }
    }

    public class UserDto
    {
        public int Age { get; set; }
    }
}

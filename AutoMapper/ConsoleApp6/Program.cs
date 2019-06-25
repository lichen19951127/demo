using System;
using AutoMapper;

namespace ConsoleApp6
{
    /// <summary>
    /// 类型转换ITypeConverter
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<UserProfile>());

            User user0 = new User() { Gender = 0 };
            User user1 = new User() { Gender = 1 };
            User user2 = new User() { Gender = 2 };
            var dto0 = Mapper.Map<UserDto>(user0);
            var dto1 = Mapper.Map<UserDto>(user1);
            var dto2 = Mapper.Map<UserDto>(user2);

            Console.WriteLine("dto0:{0}", dto0.Gender);
            Console.WriteLine("dto1:{0}", dto1.Gender);
            Console.WriteLine("dto2:{0}", dto2.Gender);
        }
    }
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<int, string>().ConvertUsing<GenderTypeConvertert>();
            //也可以写这样
            //CreateMap<int, string>().ConvertUsing(new GenderTypeConvertert());
        }
    }
    public class User
    {
        public int Gender { get; set; }
    }

    public class UserDto
    {
        public string Gender { get; set; }
    }
    public class GenderTypeConvertert : ITypeConverter<int, string>
    {
        public string Convert(int source, string destination, ResolutionContext context)
        {
            switch (source)
            {
                case 0:
                    destination = "男";
                    break;
                case 1:
                    destination = "女";
                    break;
                default:
                    destination = "未知";
                    break;
            }
            return destination;
        }
    }
}

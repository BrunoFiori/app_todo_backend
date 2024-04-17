using App_Todo_Backend.Data;
using App_Todo_Backend.Core.Models.Todo;
using App_Todo_Backend.Core.Models.User;
using AutoMapper;

namespace App_Todo_Backend.Core.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {   
            CreateMap<User, InputUser>().ReverseMap()
                .AfterMap((inusr, usr) => usr.UserName= inusr.Email);
            CreateMap<User, OutputUser>().ReverseMap();
            CreateMap<Todo, InputTodo>().ReverseMap();
            CreateMap<OutputTodo, Todo>().ReverseMap();
        }
    }
}

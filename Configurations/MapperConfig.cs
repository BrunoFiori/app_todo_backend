using App_Todo_Backend.Data;
using App_Todo_Backend.Models.Todo;
using App_Todo_Backend.Models.User;
using AutoMapper;

namespace App_Todo_Backend.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {   
            CreateMap<User, InputUser>().ReverseMap()
                .AfterMap((inusr, usr) => usr.UserName= inusr.Email);
            CreateMap<Todo, InputTodo>().ReverseMap();
            CreateMap<OutputTodo, Todo>().ReverseMap();
        }
    }
}

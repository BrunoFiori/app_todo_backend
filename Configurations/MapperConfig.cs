using App_Todo_Backend.Data;
using App_Todo_Backend.Models.Todo;

using AutoMapper;

namespace App_Todo_Backend.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {   
            CreateMap<Todo, InputTodo>().ReverseMap();
            CreateMap<OutputTodo, Todo>().ReverseMap();
        }
    }
}

using AutoMapper;
using TaskManager.Api.Dtos;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Api.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Task, TaskDto>().ReverseMap();
            CreateMap<TaskGroup, TaskGroupDto>().ReverseMap();
        }
    }
}

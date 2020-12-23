using AutoMapper;
using workLogger.DTOs;
using workLogger.Models;

namespace workLogger.Profiles
{
  public class TasksProfile : Profile
  {
    public TasksProfile()
    {
      CreateMap<Task, TaskReadDto>();
      CreateMap<TaskCreateDto, Task>();
      CreateMap<TaskUpdateDto, Task>();
    }
  }
}
using AutoMapper;
using workLogger.DTOs;
using workLogger.Models;

namespace workLogger.Profiles
{
  public class UsersProfile : Profile
  {
    public UsersProfile()
    {
      CreateMap<User, UserReadDto>();
      CreateMap<UserCreateDto, User>();
      CreateMap<UserUpdateDto, User>();
    }
  }
}
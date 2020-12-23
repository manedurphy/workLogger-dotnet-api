using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using workLogger.Models;
using workLogger.Data;
using workLogger.Validation;
using FluentValidation.Results;
using AutoMapper;
using workLogger.DTOs;

namespace workLogger.Controllers
{
  [ApiController]
  [Route("api/users")]
  public class UsersController : ControllerBase
  {
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public UsersController(IUserRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet("{id}")]
    public ActionResult<UserReadDto> GetUserById(int id)
    {
      var user = _repository.GetById(id);

      if (user == null)
      {
        return NotFound("User could not be found");
      }

      return Ok(_mapper.Map<UserReadDto>(user));
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserReadDto>> GetUsers()
    {
      var users = _repository.GetAll();

      return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
    }

    [HttpPost]
    public ActionResult<UserReadDto> Add(User userCreateDto)
    {
      UserValidator validator = new UserValidator();

      ValidationResult result = validator.Validate(userCreateDto);
      if (!result.IsValid)
      {
        return BadRequest(result.Errors[0].ErrorMessage);
      }

      var userExists = _repository.UserExists(userCreateDto.Email);
      if (userExists)
      {
        return BadRequest("User with that email already exists");
      }

      var newUser = _mapper.Map<User>(userCreateDto);
      _repository.Add(newUser);

      var userReadDto = _mapper.Map<UserReadDto>(newUser);

      return CreatedAtAction(nameof(GetUserById), new { id = userReadDto.Id }, userReadDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
    {
      var user = _repository.GetById(id);
      if (user == null)
      {
        return NotFound("User could not be found");
      }

      _mapper.Map(userUpdateDto, user);
      _repository.Update(user);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
      var user = _repository.GetById(id);
      if (user == null)
      {
        return NotFound("User could not be found");
      }

      _repository.Delete(user);
      return NoContent();
    }

  }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using workLogger.Data;
using workLogger.DTOs;
using workLogger.Models;
using AutoMapper;
using workLogger.Validation;
using FluentValidation.Results;

namespace workLogger.Controllers
{
  [ApiController]
  [Route("api/tasks")]
  public class TasksController : ControllerBase
  {
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;
    public TasksController(ITaskRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskReadDto>> GetAllTasks()
    {
      var tasks = _repository.GetAll();

      return Ok(_mapper.Map<IEnumerable<TaskReadDto>>(tasks));
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<TaskReadDto> GetTaskById(int id)
    {
      var task = _repository.GetById(id);

      if (task == null)
      {
        return NotFound();
      }

      return Ok(_mapper.Map<TaskReadDto>(task));
    }

    [HttpPost]
    public ActionResult<TaskReadDto> Add(TaskCreateDto taskCreateDto)
    {
      TaskValidator validator = new TaskValidator();

      ValidationResult result = validator.Validate(taskCreateDto);
      if (!result.IsValid)
      {
        return BadRequest(result.Errors[0].ErrorMessage);
      }

      var existingTask = _repository.TaskExists(taskCreateDto.ProjectNumber);
      if (existingTask)
      {
        return BadRequest(HttpResponses.TaskResponses.TaskExists);
      }

      var existingUser = _repository.UserExists(taskCreateDto.UserId);
      if (!existingUser)
      {
        return NotFound(HttpResponses.UserResponses.UserNotFound);
      }

      var task = _mapper.Map<Task>(taskCreateDto);
      _repository.Add(task);

      var taskReadDto = _mapper.Map<TaskReadDto>(task);

      return CreatedAtAction(nameof(GetTaskById), new { id = taskReadDto.Id }, taskReadDto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateTask(int id, TaskUpdateDto taskUpdateDto)
    {
      var existingTask = _repository.GetById(id);
      if (existingTask == null)
      {
        return NotFound(HttpResponses.TaskResponses.TaskExists);
      }

      var existingUser = _repository.UserExists(taskUpdateDto.UserId);
      if (!existingUser)
      {
        return NotFound(HttpResponses.UserResponses.UserNotFound);
      }

      _mapper.Map(taskUpdateDto, existingTask);
      _repository.Update(existingTask);

      return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteTask(int id)
    {
      var task = _repository.GetById(id);
      if (task == null)
      {
        return NotFound(HttpResponses.TaskResponses.TaskNotFound);
      }

      _repository.Delete(task);
      return NoContent();
    }
  }
}
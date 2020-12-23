using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using workLogger.Data;
using workLogger.DTOs;
using workLogger.Models;
using AutoMapper;

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
      var existingTask = _repository.TaskExists(taskCreateDto.ProjectNumber);
      if (existingTask)
      {
        return BadRequest("Task with this Project Number already exists");
      }

      var existingUser = _repository.UserExists(taskCreateDto.UserId);
      if (!existingUser)
      {
        return NotFound("User not found");
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
        return NotFound("Task with this Project Number does not exist");
      }

      var existingUser = _repository.UserExists(taskUpdateDto.UserId);
      if (!existingUser)
      {
        return NotFound("User not found");
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
        return NotFound("Task could not be found");
      }

      _repository.Delete(task);
      return NoContent();
    }
  }
}
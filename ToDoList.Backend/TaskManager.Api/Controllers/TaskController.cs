using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Api.Dtos;
using TaskManager.Api.ResponseProvider;
using TaskManager.Application.Services;
using TaskManager.Application.Services.Interface;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ITaskGroupService _taskGroupService;
        private readonly IMapper _mapper;
        private readonly IResponseProvider _responseProvider;

        public TaskController(ITaskService taskService, 
            IMapper mapper, IResponseProvider responseProvider, ITaskGroupService taskGroupService)
        {
            _taskService = taskService;
            _mapper = mapper;
            _responseProvider = responseProvider;
            _taskGroupService = taskGroupService;
        }

        [HttpGet(nameof(GetTask))]
        public ResponseDto GetTask(int taskId)
        {
            return _responseProvider.GenerateGetResponse(() =>
                _mapper.Map<TaskDto>(_taskService.GetTask(taskId)));
        }
        
        [HttpGet(nameof(GetAll))]
        public ResponseDto GetAll()
        {
            return _responseProvider.GenerateGetResponse(() =>
                _mapper.Map<IEnumerable<TaskDto>>(_taskService.GetAll()));
        }
        
        [HttpGet(nameof(GetTaskGroups))]
        public ResponseDto GetTaskGroups(int taskId)
        {
            return _responseProvider.GenerateGetResponse(() => {
                ValidateUser(taskId);
                return _mapper.Map<IEnumerable<TaskGroupDto>>(_taskService.GetTaskGroups(taskId));
            });
        }
        
        [HttpGet(nameof(GetOwner))]
        public ResponseDto GetOwner(int taskId)
        {
            return _responseProvider.GenerateGetResponse(() => {
                ValidateUser(taskId);
                return _mapper.Map<UserDto>(_taskService.GetOwner(taskId));
            });
        }

        [HttpPost(nameof(RemoveTask))]
        public ResponseDto RemoveTask(int taskId)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(taskId);
                _taskService.RemoveTask(taskId);
            });
        }
        
        [HttpPost(nameof(UpdateTask))]
        public ResponseDto UpdateTask(int taskId, [FromBody] TaskDto newTask)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(taskId);
                Task task = _mapper.Map<Task>(newTask);
                _taskService.UpdateTask(taskId, task);
            });
        }

        private void ValidateUser(int taskId)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            bool isOwner = _taskService.GetOwner(taskId).Email == userEmail;
            if (isOwner) return;

            bool isAllowedUser = false;
            var taskGroups = _taskService.GetTaskGroups(taskId);
            if(taskGroups != null)
            {
                foreach (var taskGroup in taskGroups)
                {
                    if(_taskGroupService.GetAllowedUsers(taskGroup.Id)?
                        .FirstOrDefault(user => user.Email == userEmail) != null)
                    {
                        isAllowedUser = true;
                        break;
                    }
                }
            }
            if (!isOwner && !isAllowedUser)
            {
                throw new UnauthorizedAccessException($"this user cannot perform operations with a task with the specified id: {taskId}");
            }
        }
    }
}

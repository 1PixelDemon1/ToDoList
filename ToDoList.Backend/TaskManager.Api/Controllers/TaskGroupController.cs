using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Api.Dtos;
using TaskManager.Api.ResponseProvider;
using TaskManager.Application.Services;
using TaskManager.Application.Services.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskGroupController : ControllerBase
    {
        private readonly ITaskGroupService _taskGroupService;
        private readonly IMapper _mapper;
        private readonly IResponseProvider _responseProvider;

        public TaskGroupController(ITaskGroupService taskGroupService,
            IMapper mapper, IResponseProvider responseProvider)
        {
            _taskGroupService = taskGroupService;
            _mapper = mapper;
            _responseProvider = responseProvider;
        }

        [HttpGet(nameof(GetTaskGroup))]
        public ResponseDto GetTaskGroup(int id)
        {
            return _responseProvider.GenerateGetResponse(() =>
                _mapper.Map<TaskGroupDto>(_taskGroupService.GetTaskGroup(id)));
        }
        
        [HttpGet(nameof(GetAll))]
        public ResponseDto GetAll()
        {
            return _responseProvider.GenerateGetResponse(() =>
                _mapper.Map<IEnumerable<TaskGroupDto>?>(_taskGroupService.GetAll()));
        }        
        
        [HttpGet(nameof(GetTasks))]
        public ResponseDto GetTasks(int taskGroupId)
        {
            return _responseProvider.GenerateGetResponse(() =>
            {
                ValidateUser(taskGroupId);
                return _mapper.Map<IEnumerable<TaskDto>>(_taskGroupService.GetTasks(taskGroupId));
            });
        }
        
        [HttpGet(nameof(GetOwner))]
        public ResponseDto GetOwner(int taskGroupId)
        {
            return _responseProvider.GenerateGetResponse(() =>
            {
                ValidateUser(taskGroupId);
                return _mapper.Map<UserDto>(_taskGroupService.GetOwner(taskGroupId));
            });
        }

        [HttpGet(nameof(GetAllowedUsers))]
        public ResponseDto GetAllowedUsers(int taskGroupId)
        {
            return _responseProvider.GenerateGetResponse(() =>
            {
                ValidateUser(taskGroupId);
                return _mapper.Map<IEnumerable<UserDto>>(_taskGroupService.GetAllowedUsers(taskGroupId));
            });
        }
        
        [HttpPost(nameof(RemoveTaskGroup))]
        public ResponseDto RemoveTaskGroup(int id)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(id);
                _taskGroupService.RemoveTaskGroup(id);
            });
        }
        
        [HttpPost(nameof(UpdateTaskGroup))]
        public ResponseDto UpdateTaskGroup(int id, [FromBody] TaskGroupDto taskGroupDto)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(id);
                TaskGroup taskGroup = _mapper.Map<TaskGroup>(taskGroupDto);
                _taskGroupService.UpdateTaskGroup(id, taskGroup);
            });
        }

        [HttpPost(nameof(AddTask))]
        public ResponseDto AddTask(int taskGroupId, int taskId)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(taskGroupId);
                _taskGroupService.AddTask(taskGroupId, taskId);
            });
        }

        [HttpPost(nameof(RemoveTask))]
        public ResponseDto RemoveTask(int taskGroupId, int taskId)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(taskGroupId);
                _taskGroupService.RemoveTask(taskGroupId, taskId);
            });
        }

        [HttpPost(nameof(AddAllowedUser))]
        public ResponseDto AddAllowedUser(int taskGroupId, int userId)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(taskGroupId);
                _taskGroupService.AddAllowedUser(taskGroupId, userId);
            });
        }

        [HttpPost(nameof(RemoveAllowedUser))]
        public ResponseDto RemoveAllowedUser(int taskGroupId, int userId)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(taskGroupId);
                _taskGroupService.RemoveAllowedUser(taskGroupId, userId);
            });
        }

        private void ValidateUser(int taskGroupId)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (_taskGroupService.GetOwner(taskGroupId).Email != userEmail 
                && _taskGroupService.GetAllowedUsers(taskGroupId)?.FirstOrDefault(user => user.Email == userEmail) == null)
            {
                throw new UnauthorizedAccessException($"this user cannot perform operations with an task group with the specified id: {taskGroupId}");
            }
        }
    }
}

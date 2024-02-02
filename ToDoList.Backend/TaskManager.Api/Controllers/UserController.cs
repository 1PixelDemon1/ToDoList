using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Api.Dtos;
using TaskManager.Api.ResponseProvider;
using TaskManager.Application.Services.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IResponseProvider _responseProvider;

        public UserController(IUserService userService, IMapper mapper, IResponseProvider responseProvider)
        {
            _userService = userService;
            _mapper = mapper;
            _responseProvider = responseProvider;
        }

        [HttpGet(nameof(GetUser))]
        public ResponseDto GetUser(int userId)
        {
            return _responseProvider.GenerateGetResponse(() => 
                _mapper.Map<UserDto>(_userService.GetUser(userId)));
        }
        
        [HttpGet(nameof(GetAll))]
        public ResponseDto GetAll()
        {
            return _responseProvider.GenerateGetResponse(() => 
                _mapper.Map<IEnumerable<UserDto>>(_userService.GetAll()));
        }
        
        [HttpGet(nameof(GetTasks))]
        public ResponseDto GetTasks(int userId)
        {
            return _responseProvider.GenerateGetResponse(() => 
            {
                ValidateUser(userId);
                return _mapper.Map<IEnumerable<TaskDto>>(_userService.GetTasks(userId));
            });
        }

        [HttpGet(nameof(GetTaskGroups))]
        public ResponseDto GetTaskGroups(int userId)
        {
            return _responseProvider.GenerateGetResponse(() =>
            {
                ValidateUser(userId);
                return _mapper.Map<IEnumerable<TaskGroupDto>>(_userService.GetTaskGroups(userId));
            });
        }
        
        [HttpGet(nameof(GetAccessibleGroups))]
        public ResponseDto GetAccessibleGroups(int userId)
        {
            return _responseProvider.GenerateGetResponse(() =>
            {
                ValidateUser(userId);
                return _mapper.Map<IEnumerable<TaskGroupDto>>(_userService.GetAccessibleGroups(userId));
            });
        }

        [HttpGet(nameof(GetUserByEmail))]
        public ResponseDto GetUserByEmail(string email)
        {
            return _responseProvider.GenerateGetResponse(() =>
            {
                var userDto = _mapper.Map<UserDto>(_userService.GetUserByEmail(email));
                ValidateUser(userDto.Id);
                return userDto;
            });
        }


        [HttpPost(nameof(CreateUser))]
        public ResponseDto CreateUser([FromBody] UserDto userDto)
        {
            return _responseProvider.GeneratePostResponse(() => 
            {
                User user = _mapper.Map<User>(userDto);
                _userService.AddUser(user);
            });
        }

        [HttpPost(nameof(RemoveUser))]
        public ResponseDto RemoveUser(int userId)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(userId);
                _userService.RemoveUser(userId);
            });
        }

        [HttpPost(nameof(UpdateUser))]
        public ResponseDto UpdateUser(int userId, [FromBody] UserDto userDto)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(userId);
                User user = _mapper.Map<User>(userDto);
                _userService.UpdateUser(userId, user);
            });
        }
        
        [HttpPost(nameof(AddTask))]
        public ResponseDto AddTask(int userId, [FromBody] TaskDto taskDto)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(userId);
                Task task = _mapper.Map<Task>(taskDto);
                _userService.AddTask(userId, task);
            });
        }
       
        [HttpPost(nameof(AddTaskGroup))]
        public ResponseDto AddTaskGroup(int userId, [FromBody] TaskGroupDto taskGroupDto)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                ValidateUser(userId);
                TaskGroup taskGroup = _mapper.Map<TaskGroup>(taskGroupDto);
                _userService.AddTaskGroup(userId, taskGroup);
            });
        }

        private void ValidateUser(int userId)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            if (_userService.GetUserByEmail(userEmail).Id != userId)
            {
                throw new UnauthorizedAccessException($"this user cannot perform operations with an account with the specified id: {userId}");
            }
        }
    }
}

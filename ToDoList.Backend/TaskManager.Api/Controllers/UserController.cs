using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Dtos;
using TaskManager.Api.ResponseProvider;
using TaskManager.Application.Services.Interface;
using TaskManager.Domain.Entities;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Api.Controllers
{
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
                _mapper.Map<IEnumerable<TaskDto>>(_userService.GetTasks(userId)));
        }

        [HttpGet(nameof(GetTaskGroups))]
        public ResponseDto GetTaskGroups(int userId)
        {
            return _responseProvider.GenerateGetResponse(() =>
                _mapper.Map<IEnumerable<TaskGroupDto>>(_userService.GetTaskGroups(userId)));
        }
        
        [HttpGet(nameof(GetAccessibleGroups))]
        public ResponseDto GetAccessibleGroups(int userId)
        {
            return _responseProvider.GenerateGetResponse(() =>
                _mapper.Map<IEnumerable<TaskGroupDto>>(_userService.GetAccessibleGroups(userId)));
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
                _userService.RemoveUser(userId);
            });
        }

        [HttpPost(nameof(UpdateUser))]
        public ResponseDto UpdateUser(int userId, [FromBody] UserDto userDto)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                User user = _mapper.Map<User>(userDto);
                _userService.UpdateUser(userId, user);
            });
        }
        
        [HttpPost(nameof(AddTask))]
        public ResponseDto AddTask(int userId, [FromBody] TaskDto taskDto)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                Task task = _mapper.Map<Task>(taskDto);
                _userService.AddTask(userId, task);
            });
        }
       
        [HttpPost(nameof(AddTaskGroup))]
        public ResponseDto AddTaskGroup(int userId, [FromBody] TaskGroupDto taskGroupDto)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                TaskGroup taskGroup = _mapper.Map<TaskGroup>(taskGroupDto);
                _userService.AddTaskGroup(userId, taskGroup);
            });
        }
    }
}

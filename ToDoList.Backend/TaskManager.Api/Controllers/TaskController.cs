using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Dtos;
using TaskManager.Api.ResponseProvider;
using TaskManager.Application.Services.Interface;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        private readonly IResponseProvider _responseProvider;

        public TaskController(ITaskService taskService, 
            IMapper mapper, IResponseProvider responseProvider)
        {
            _taskService = taskService;
            _mapper = mapper;
            _responseProvider = responseProvider;
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
            return _responseProvider.GenerateGetResponse(() =>
                _mapper.Map<IEnumerable<TaskGroupDto>>(_taskService.GetTaskGroups(taskId)));
        }
        
        [HttpGet(nameof(GetOwner))]
        public ResponseDto GetOwner(int taskId)
        {
            return _responseProvider.GenerateGetResponse(() =>
                _mapper.Map<UserDto>(_taskService.GetOwner(taskId)));
        }

        [HttpPost(nameof(RemoveTask))]
        public ResponseDto RemoveTask(int taskId)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                _taskService.RemoveTask(taskId);
            });
        }
        
        [HttpPost(nameof(UpdateTask))]
        public ResponseDto UpdateTask(int taskId, [FromBody] TaskDto newTask)
        {
            return _responseProvider.GeneratePostResponse(() =>
            {
                Task task = _mapper.Map<Task>(newTask);
                _taskService.UpdateTask(taskId, task);
            });
        }
    }
}

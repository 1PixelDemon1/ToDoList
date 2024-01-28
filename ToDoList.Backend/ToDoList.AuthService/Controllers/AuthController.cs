﻿using Microsoft.AspNetCore.Mvc;
using ShortModel.Models.Dtos;
using ToDoList.AuthService.Models.Dtos;
using ToDoList.AuthService.Service.IService;

namespace ToDoList.AuthService.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        protected ResponseDto _response;

        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
            _response = new();
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _authService.Register(model);
            
            if(!string.IsNullOrEmpty(errorMessage))
            {
                _response.Message = errorMessage;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if(loginResponse.User is null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        //[HttpPost("AssignRole")]
        //public async Task<IActionResult> AssignRole(RegistrationRequestDto model)
        //{
        //    var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
        //    if (!assignRoleSuccessful)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = "Error encountered";
        //        return BadRequest(_response);
        //    }
        //    return Ok(_response);
        //}
    }
}

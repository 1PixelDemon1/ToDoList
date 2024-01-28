namespace ToDoList.AuthService.Models.Dtos
{
    // When somebody tries to Login user
    // he must pass this model.
    public class LoginRequestDto
    {        
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

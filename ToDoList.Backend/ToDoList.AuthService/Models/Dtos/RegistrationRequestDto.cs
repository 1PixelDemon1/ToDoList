namespace ToDoList.AuthService.Models.Dtos
{
    // When somebody tries to Register new user
    // he must pass this model.
    public class RegistrationRequestDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}

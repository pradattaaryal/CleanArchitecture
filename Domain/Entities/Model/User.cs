using MediatR;

namespace practices.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password  { get; set; }
        public string Role { get; set; }
    }

    public class SignupUserDto : IRequest<bool>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class LoginUserDto : IRequest<String>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}

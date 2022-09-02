using Application.Common.Interface.Authentication;
using Application.Common.Interface.Presistence;
using Domain.Entities;

namespace Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerators _jwtTokenGenerators;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerators jwtTokenGenerators, IUserRepository userRepository)
        {
            this._jwtTokenGenerators = jwtTokenGenerators;
            this._userRepository = userRepository;
        }

        public AuthenticationResult Login(string Email, string Password)
        {
            // 1. validate the user
            if (_userRepository.GetUserByEmail(Email) is not User user)
                throw new Exception("Invalid User");

            if (user.Password != Password)
                throw new Exception("Invalid User");

            // 2. Create the JWT Token
            var token = _jwtTokenGenerators.GenerateToken(user);

            return new AuthenticationResult(
              user,
               token
              );
        }

        public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
        {
            // 1. validate the user
            if (_userRepository.GetUserByEmail(Email) is not null)
                throw new Exception("User already exists.");

            // 2. Create Entity

            var user = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password
            };

            _userRepository.AddNewUser(user);

            // 4. Create the JWT Token
            var token = _jwtTokenGenerators.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
using DataAccess;
using DomainModels;
using Services.Helper;
using Services.Interfaces;
using System.Linq;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }


        public UserModel Login(string username, string password)
        {
            User user = _userRepository.GetAll().FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new UserException($"User with username:\"{username}\" does not exist!");
            }

            string hashedPasswor = HashPassword.HashPass(password);

            if (user.Password != hashedPasswor)
            {
                throw new UserException($"Password does not match with user password with username:\"{username}\"");
            }

            UserModel userModel = new UserModel()
            {
                Id = user.Id,
                FirstName = user.Firstname,
                LastName = user.Lastname,
                UserName = user.Username,
            };

            return userModel;
        }


        public void Register(RegisterModel registerModel)
        {
            string username = _userRepository.GetAll()
                        .Where(u => u.Username == registerModel.Username)
                        .Select(u => u.Username)
                        .ToString();

            if (username != null)
            {
                throw new UserException($"User with username:{registerModel.Username} already exists!");
            }

            if (string.IsNullOrWhiteSpace(registerModel.Password) || string.IsNullOrWhiteSpace(registerModel.ConfirmPassword))
            {
                throw new UserException("Password required!");
            }

            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                throw new UserException($"Passwords do not match!");
            }

            if (string.IsNullOrWhiteSpace(registerModel.FirstName) || string.IsNullOrWhiteSpace(registerModel.LastName))
            {
                throw new UserException("Both Firstnam and Lastname are required!");
            }

            if (string.IsNullOrWhiteSpace(registerModel.Username))
            {
                throw new UserException("Username is required!");
            }


            string hashedPasswor = HashPassword.HashPass(registerModel.Password);


            User user = new User()
            {
                Firstname = registerModel.FirstName,
                Lastname = registerModel.LastName,
                Username = registerModel.Username,
                Password = hashedPasswor
            };

            _userRepository.Insert(user);

        }
    }
}

using CarSharing.Models.UserModels;
using CarSharing.Server.Interface;
using CarSharing.Server.Interface.Auth;
using CarSharing.Server.Models.AuthorizationModels;
using CarSharing.Server.Models.UserModels;
using CarSharing.Server.Repository;

namespace CarSharing.Server.Servisec
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHash _passwordHash;
        private readonly IJwtProvider _jwtProvider;
        private readonly IProfileRepository _profileRepository;
        public UserService(IUserRepository repository ,  IPasswordHash passwordHash , IJwtProvider jwtProvider , IProfileRepository profileRepository)
        {
            _repository = repository;
            _passwordHash = passwordHash;
            _jwtProvider = jwtProvider;
            _profileRepository = profileRepository;
        }


        public async Task Register(string userName , string password, string email )
        {
            var hashedPassword =  _passwordHash.Generate(password);

            var user = User.Creat(Guid.NewGuid(), email, hashedPassword, userName, 0);
            await _repository.Add(user);
        }

        public async Task<string> Login(string email , string password)
        {
            var user = await _repository.GetByEmail(email);
            if (user==null )
            {
                throw new Exception("Пользователь не зарегистрирован");
            }
            var result = _passwordHash.VerifyPassword(password, user.PasswordHash);
            if (result == false)
            {
                throw new Exception("Неверный пороль");
            }

            var token = _jwtProvider.GeneratToken(user);
            return token;
        }
        public async Task<UserEntity> GetUserProfile (string email)
        {
            var user = await _profileRepository.GetProfileByEmail(email);
            return user;
        }
        public async Task<bool> Update(ProfileRequist requist)
        {
 
            var profile = ProfileUser.AddDateProfile(requist);
            var result = await _profileRepository.Update(profile);
            if (result == false)
            {
                throw new Exception("Exeption select data ");

            }
            return true;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _repository.GetByEmail(email);
            return user;
        }

    }
}

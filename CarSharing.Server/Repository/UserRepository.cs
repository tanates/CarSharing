using AutoMapper;
using CarSharing.Models.UserModels;
using CarSharing.Server.Interface.Auth;
using CarSharing.Server.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace CarSharing.Server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly   ApplicationContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationContext context ,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(User user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
                RoleName= user.RoleName,
                UserBalance = user.UserBalance ,
                
            };
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }
       

        public async Task <User>GetByEmail(string email)
        {
           
            try
            {
                var userEntity = await _context.Users
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Email == email);
                return _mapper.Map<User>(userEntity);
            }
            catch (Exception ex)
            {
                // запись информации об исключении в журнал или вывод на экран
                Console.WriteLine($"Error in GetByEmail method: {ex.Message}");
                throw;
            }
           
        }

    }
}

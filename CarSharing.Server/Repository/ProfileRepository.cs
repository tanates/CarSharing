using AutoMapper;
using CarSharing.Models.UserModels;
using CarSharing.Server.Interface.Auth;
using CarSharing.Server.Models.AuthorizationModels;
using CarSharing.Server.Models.UserModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarSharing.Server.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public ProfileRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task <UserEntity> GetProfileByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email) ?? throw new Exception();

            return _mapper.Map<UserEntity>(userEntity);
        }

        public async Task<bool> Update(ProfileUser profile )
        {
            var user = await _context.Users.FirstOrDefaultAsync(item => item.Email == profile.Email);
            if (user == null)
            {
                throw new Exception("Not found user as update");
            }

            if(profile.PassportNumber!= null)
                user.PassportNumber = profile.PassportNumber;
            if (profile.PhoneNumber != null)
                user.PhoneNumber = profile.PhoneNumber;
            if (profile.DriversLicense != null)
                user.DriversLicense = profile.DriversLicense;
            if (profile.Surname != null)
                user.Surname = profile.Surname;
            if (user.Surname != null && user.PassportNumber != null && user.PhoneNumber != null
                && user.DriversLicense != null && user.Surname != null)
            {
                user.ActivatedAccount = true;
            }
            else
            {
                user.ActivatedAccount = false;
            }
            _context.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task <bool> CheckIsActivation(string email)
        {
            var user = await _context.Users.FindAsync(email);
           
            var result =  user?.ActivatedAccount == false ? true : false ;

            return result; 
        }

    }
}

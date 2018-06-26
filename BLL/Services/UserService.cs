using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _db;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public UserService(IMapper mapper,
                            IUnitOfWork db, 
                            UserManager<User> userManager, 
                            SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> Register(UserDTO userDTO)
        {
            var usr = _mapper.Map<UserDTO, User>(userDTO);

           var res = _userManager.CreateAsync(usr);

            await _db.SaveAsync();

            if (res == null)
                return IdentityResult.Failed();

            return IdentityResult.Success;
            //var user = await _db.Users.FindByEmailAsync(userDTO.Email);
            //if (user == null)
            //{
            //    user = new User
            //    {
            //        Name = userDTO.Name
            //    };
            //    await _db.Users.CreateAsync(user, userDTO.Password);
            //    await _db.SaveAsync();
            //    return IdentityResult.Success;
            //}
            //else
            //    return IdentityResult.Failed($"User with {userDTO.Email} email have already exist");
        }
    }
}

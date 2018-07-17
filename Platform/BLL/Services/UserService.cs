using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
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


        public IEnumerable<UserDTO> GetUsers()
        {
            var users = _userManager.Users;
            return _mapper.Map<IEnumerable<User>, List<UserDTO>>(users);
        }

        public async Task<IdentityResult> Register(UserDtoForRegister userDTO)
        {
            var user = _mapper.Map<UserDtoForRegister, User>(userDTO);
            user.UserName = userDTO.Email;
            user.Name = userDTO.Email;
            var res = await _userManager.CreateAsync(user, userDTO.Password);

            if (res.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return IdentityResult.Success;
            }
            return IdentityResult.Failed();
        }

        public async Task<IdentityResult> Login(UserDtoForRegister userDTO)
        {
            var result =
                await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);

            if (result.Succeeded)
                return IdentityResult.Success;

            return IdentityResult.Failed();
        }

        public async Task<IdentityResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return IdentityResult.Success;
        }

        public async Task<User> GetUserById(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception($"User with id {userId} does not exist!");
            return user;
        }

        public async Task<User> GetUserByEmail(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
                throw new Exception($"User with email {userEmail} does not exist!");
            return user;
        }

        public string GetUserId(ClaimsPrincipal claims)
        {
            var userId = _userManager.GetUserId(claims);
            return userId;
        }
    }
}

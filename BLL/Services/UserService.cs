using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IdentityResult> Register(UserDTO userDTO)
        {
            var user = _mapper.Map<UserDTO, User>(userDTO);
            user.UserName = userDTO.Email;
            var res = await _userManager.CreateAsync(user, userDTO.Password); 

            if (res.Succeeded)
            {            
                await _signInManager.SignInAsync(user, false);
                var test = user;
                return IdentityResult.Success;
            }
            return IdentityResult.Failed();
        }
        
        public async Task<IdentityResult> Login(UserDTO userDTO)
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
    }
}

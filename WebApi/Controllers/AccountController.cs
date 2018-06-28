using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        //public async Task<IActionResult> Register(RegisterModel model)
        //{
        //    return Ok();
        //}



        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var users = _userService.GetUsers();
                if (users.ToList().Count == 0)
                    throw new Exception("Users not found");
                //var users = _mapper.Map<IEnumerable<UserDTO>, List<UserModel>>(usersDTO);
                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Register([FromBody] RegisterModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var usr = new UserDTO { Email = user.Email, Password = user.Password, Name = user.Email };
            var result = _userService.Register(usr).GetAwaiter().GetResult();

            if (result == null)
                return BadRequest();

            return Ok();
        }
    }
}
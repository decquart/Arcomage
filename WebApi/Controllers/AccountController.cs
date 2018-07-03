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
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

       
        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var users = _userService.GetUsers();
                if (users.ToList().Count == 0)
                    throw new Exception("Users not found");
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
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var usr = new UserDTO { Email = user.Email, Password = user.Password, Name = user.Email };
                var result = _userService.Register(usr).GetAwaiter().GetResult();

                if (result == null)
                    return BadRequest();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }


        [HttpPost]
        [Route("login")]
        public IActionResult LogIn([FromBody] RegisterModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var usr = new UserDTO { Email = user.Email, Password = user.Password, Name = user.Email };
                var result = _userService.Login(usr).GetAwaiter().GetResult();

                if (result == null)
                    return BadRequest();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogOut()
        {
            var result = await _userService.Logout();
            if (!result.Succeeded)
                return BadRequest();
            return Ok(result);
        }

    }
}
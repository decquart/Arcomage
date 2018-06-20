using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.DTO;
using Arcomage.Entities;
using Arcomage.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers 
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService)
        {
            _userService = userService;
           // _mapper = mapper;
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
                var usersDTO = _userService.GetUsers();
                if (usersDTO.ToList().Count == 0)
                    throw new Exception("Users not found");
                var users = _mapper.Map<IEnumerable<UserDTO>, List<UserModel>>(usersDTO);
                return Json(users);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
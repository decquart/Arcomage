using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Controllers
{
   
        [AllowAnonymous]
        [Produces("application/json")]
        [Route("api/Account")]
        public class AccountController : Controller
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;
            private readonly IMapper _mapper;

            public AccountController(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _mapper = mapper;
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
                //var usersDTO = _userManager.;
                //    if (usersDTO.ToList().Count == 0)
                //        throw new Exception("Users not found");
                //    //var users = _mapper.Map<IEnumerable<UserDTO>, List<UserModel>>(usersDTO);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e.ToString());
                }
            }

        [HttpGet]
        [Route("create")]
        public IActionResult Register()
        {
            //if (user == null)
            //    return BadRequest();

           var user =  _userManager.CreateAsync(new User { UserName = "testt", Email = "decquart@gmail.com" });

           
            return Ok();
        }
    }
    
}

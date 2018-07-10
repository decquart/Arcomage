using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public LogInModel LogModel { get; set; }

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new UserDtoForRegister { Email = LogModel.Email, Password = LogModel.Password };
                    await _userService.Login(user);
                    return RedirectToPage("/Index");
                }
                catch (Exception e)
                {
                    return BadRequest(e.ToString());
                }              
            }
            return Page();
        }
    }
}
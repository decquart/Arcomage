using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Web.Pages.Game
{
    [Authorize]
    public class ListModel : PageModel
    {
        [BindProperty]
        public List<GameDto> Games { get; set; }
        [BindProperty]
        public string CurrentUserId { get; set; }


        private readonly IGameService _gameService;
        private readonly IUserService _userService;

        public ListModel(IGameService gameService, IUserService userService)
        {
            _gameService = gameService;
            _userService = userService;
        }        

        public void OnGet()
        {
            Games = _gameService.GetGameList().ToList();
            CurrentUserId = _userService.GetUserId(User);
        }
    }
}
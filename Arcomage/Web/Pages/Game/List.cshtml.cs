using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Game
{
    [Authorize]
    public class ListModel : PageModel
    {
        [BindProperty]
        public List<GameDto> Games { get; set; }

        private readonly IGameService _gameService;

        public ListModel(IGameService gameService)
        {
            _gameService = gameService;
        }        

        public void OnGet()
        {
            Games = _gameService.GetGameList().ToList();
        }
    }
}
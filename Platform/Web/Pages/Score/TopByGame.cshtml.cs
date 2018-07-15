using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Score
{
    [Authorize]
    public class TopByGameModel : PageModel
    {
        private readonly IScoreService _scoreService;
        private readonly IGameService _gameService;

        [BindProperty]
        public List<ScoreDtoWithEmail> Scores { get; set; }
        [BindProperty]
        public GameDto Game { get; set; }

        public TopByGameModel(IScoreService scoreService, IGameService gameService)
        {
            _scoreService = scoreService;
            _gameService = gameService;
        }

        public void OnGet(int id)
        {
            Scores = _scoreService.GetScoresByGame(id).ToList();
            Game = _gameService.Get(id);
        }
    }
}
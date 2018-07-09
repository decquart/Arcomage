using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Score
{
    public class TopPlayersModel : PageModel
    {
        private readonly IScoreService _scoreService;

        [BindProperty]
        public List<ScoreDtoWithEmail> Scores { get; set; }


        public TopPlayersModel(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        public void OnGet()
        {
            Scores = _scoreService.GetTotalAverageScore().ToList();
        }
    }
}
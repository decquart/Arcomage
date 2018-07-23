using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class ScoresController : Controller
    {
        private readonly IScoreService _scoreService;

        public ScoresController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }


        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] ScoreModel scoreModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _scoreService.AddScore(scoreModel.UserId, scoreModel.GameId, scoreModel.Value);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IScoreService _scoreService;

        public GameController(IGameService gameService, IScoreService scoreService)
        {
            _gameService = gameService;
            _scoreService = scoreService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var game = _gameService.Get(id);

            if (game == null)
                return NotFound();

            return Ok(game);
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            var games = _gameService.GetGameList();

            if (games.Count().Equals(0))
                return NotFound();

            return Ok(games);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] GameDto game)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _gameService.CreateGame(game);

            return Ok();
        }

        //api/game/scores/1
        [HttpGet]
        [Route("scores/{id}")]
        public IActionResult GetScoresByGame(int id)
        {
            try
            {
                var scores = _scoreService.GetScoresByGame(id);

                return Ok(scores);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
           
        }
    }
}
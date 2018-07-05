using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

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
            try
            {
                var game = _gameService.Get(id);

                if (game == null)
                    return NotFound();

                return Ok(game);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            try
            {
                var games = _gameService.GetGameList();

                if (games.Count().Equals(0))
                    return NotFound();

                return Ok(games);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] GameDto game)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _gameService.CreateGame(game);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/Game")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
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
    }
}
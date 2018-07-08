using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Interfaces;

namespace TwoCastles.Web.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IDeckService _deckService;
        private readonly ICardService _cardService;
        private Game game;

        public GameController(IGameService gameService, ICardService cardService, IDeckService deckService)
        {
            _gameService = gameService;
            _deckService = deckService;
            _cardService = cardService;
            game = _gameService.GetNewGame();

        }
        [HttpGet("play")]
        public IActionResult Play()
        {
            _gameService.IncreasePlayerResource(game.FirstPlayer);
            _deckService.Deal(game);
            var firstPlayerCard = game.FirstPlayer.Hand.FirstOrDefault();
            game.FirstPlayer.Hand.Remove(firstPlayerCard);
            _deckService.PushCard(game, firstPlayerCard);
            _cardService.Play(firstPlayerCard, game.FirstPlayer, game.SecondPlayer);


            _gameService.IncreasePlayerResource(game.SecondPlayer);
            var secondPlayerCard = game.SecondPlayer.Hand.FirstOrDefault();
            _cardService.Play(secondPlayerCard, game.SecondPlayer, game.FirstPlayer);

            return Ok();
        }


    }

}


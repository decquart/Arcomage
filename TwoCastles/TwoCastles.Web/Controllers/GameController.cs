using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Interfaces;

namespace TwoCastles.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IDeckService _deckService;
        private readonly ICardService _cardService;
        private Game game;

        public GameController(IGameService gameService, ICardService cardService, IDeckService deckService, Game game)
        {
            _gameService = gameService;
            _deckService = deckService;
            _cardService = cardService;
            this.game = game;
        }
        [HttpGet("play/{cardName}")]
        public IActionResult Play(string cardName)
        {
            game = _gameService.GetCurrentGame();

            _gameService.IncreasePlayerResource(game.FirstPlayer);
            var firstPlayerCard = game.FirstPlayer.Hand.FirstOrDefault();
            game.FirstPlayer.Hand.Remove(firstPlayerCard);
            _deckService.PushCard(game, firstPlayerCard);
            _cardService.Play(firstPlayerCard, game.FirstPlayer, game.SecondPlayer);


            _gameService.IncreasePlayerResource(game.SecondPlayer);
            var secondPlayerCard = game.SecondPlayer.Hand.FirstOrDefault();
            _cardService.Play(secondPlayerCard, game.SecondPlayer, game.FirstPlayer);

            return Ok();
        }

        [HttpGet("start")]
        public IActionResult Start()
        {
            game = _gameService.GetNewGame();
            _deckService.Deal(game);
            return Ok();
        }


        // api/game/cards
        [HttpGet("cards")]
        public IActionResult GetUserCards()
        {
            game = _gameService.GetCurrentGame();
            var cards = game.FirstPlayer.Hand.ToList();
            return Ok(cards);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Interfaces;
using AutoMapper;
using TwoCastles.Web.DTO;

namespace TwoCastles.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IDeckService _deckService;
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;
        private Game game;

        public GameController(IGameService gameService, ICardService cardService, 
            IDeckService deckService, Game game, IMapper mapper)
        {
            _gameService = gameService;
            _deckService = deckService;
            _cardService = cardService;
            _mapper = mapper;
            this.game = game;
        }

        [HttpGet("play/{cardName}")]
        public IActionResult Play(string cardName)
        {
            try
            {
                game = _gameService.GetCurrentGame();

                _gameService.IncreasePlayerResource(game.FirstPlayer);
                var playerCard = game.FirstPlayer.Hand.FirstOrDefault(c => c.Name.Equals(cardName));
                if (playerCard == null)
                    return BadRequest();

                game.FirstPlayer.Hand.Remove(playerCard);
                _deckService.PushCard(game, playerCard);
                _cardService.Play(playerCard, game.FirstPlayer, game.SecondPlayer);
                _deckService.GiveCardToPlayer(game, game.FirstPlayer);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
            
            //_gameService.IncreasePlayerResource(game.SecondPlayer);
            //var secondPlayerCard = game.SecondPlayer.Hand.FirstOrDefault();
            //_cardService.Play(secondPlayerCard, game.SecondPlayer, game.FirstPlayer);

            return Ok();
        }

        [HttpGet("discard/{cardName}")]
        public IActionResult Discard(string cardName)
        {
            try
            {
                var game = _gameService.GetCurrentGame();
                _gameService.IncreasePlayerResource(game.FirstPlayer);
                var playerCard = game.FirstPlayer.Hand.FirstOrDefault(c => c.Name.Equals(cardName));
                if (playerCard == null)
                    return BadRequest();
                game.FirstPlayer.Hand.Remove(playerCard);
                _deckService.PushCard(game, playerCard);
                _deckService.GiveCardToPlayer(game, game.FirstPlayer);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
            return Ok();
        }

        [HttpGet("start")]
        public IActionResult Start()
        {
            try
            {
                game = _gameService.GetNewGame();
                _deckService.Deal(game);                
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
            return Ok();
        }


        // api/game/cards
        [HttpGet("cards")]
        public IActionResult GetUserCards()
        {
            try
            {
                game = _gameService.GetCurrentGame();
                var cards = game.FirstPlayer.Hand.ToList();
                var uiCards = _mapper.Map<IEnumerable<Card>, List<CardDto>>(cards);
                return Ok(uiCards);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
          
        }
    }
}
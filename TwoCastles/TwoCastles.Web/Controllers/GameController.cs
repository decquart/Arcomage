using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Interfaces;
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
        private string id = "7d59be7e-5731-470e-b2c3-8e6bc4a2525e"; //test variable

        public GameController(IGameService gameService, ICardService cardService,
            IDeckService deckService, IMapper mapper)
        {
            _gameService = gameService;
            _deckService = deckService;
            _cardService = cardService;
            _mapper = mapper;
        }

        [HttpGet("play/{cardName}")]
        public IActionResult Play(string cardName)
        {
            try
            {
                var game = _gameService.GetCurrentGame(id);
                var playerCard = game.FirstPlayer.Hand.FirstOrDefault(c => c.Name.Equals(cardName));
                if (playerCard == null)
                    return BadRequest("Card not found");
                var isEnoughRes = _cardService.IsEnoughResources(playerCard, game.FirstPlayer);
                if (!isEnoughRes)
                    return BadRequest($"Player doesn't have enought resources to apply {playerCard.Name}");

                _gameService.IncreasePlayerResource(game.FirstPlayer);
                game.FirstPlayer.Hand.Remove(playerCard);
                _deckService.PushCard(game, playerCard);
                _cardService.Play(playerCard, game.FirstPlayer, game.SecondPlayer);
                _deckService.GiveCardToPlayer(game, game.FirstPlayer);
                return Ok(playerCard);
                
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

            //_gameService.IncreasePlayerResource(game.SecondPlayer);
            //var secondPlayerCard = game.SecondPlayer.Hand.FirstOrDefault();
            //_cardService.Play(secondPlayerCard, game.SecondPlayer, game.FirstPlayer);
        }

        [HttpGet("discard/{cardName}")]
        public IActionResult Discard(string cardName)
        {
            try
            {
                var game = _gameService.GetCurrentGame(id);
                _gameService.IncreasePlayerResource(game.FirstPlayer);
                var playerCard = game.FirstPlayer.Hand.FirstOrDefault(c => c.Name.Equals(cardName));
                if (playerCard == null)
                    return BadRequest();
                game.FirstPlayer.Hand.Remove(playerCard);
                _deckService.PushCard(game, playerCard);
                _deckService.GiveCardToPlayer(game, game.FirstPlayer);
                return Ok(playerCard);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }           
        }

        [HttpGet("start/{userId}")]
        public IActionResult Start(string userId)
        {
            try
            {
                Game game;
                var isExist = _gameService.Exist(userId);
                if (isExist)
                    game = _gameService.GetCurrentGame(userId);
                else
                    game = _gameService.GetNewGame(userId);

                _deckService.Shuffle(game);
                _deckService.Deal(game);



                string url = "http://localhost:4200/" + userId;



                return Redirect(url);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }


        // api/game/cards
        [HttpGet("cards")]
        public IActionResult GetUserCards()
        {
            try
            {
                var game = _gameService.GetCurrentGame(id);
                var cards = game.FirstPlayer.Hand.ToList();
                var uiCards = _mapper.Map<IEnumerable<Card>, List<CardDto>>(cards);
                return Ok(uiCards);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("castles")]
        public IActionResult GetCastles()
        {
            try
            {                
                var game = _gameService.GetCurrentGame(id);
                if (game == null)
                    return BadRequest("Game is not valid");

                var castles = new List<Castle>();
                castles.Add(game.FirstPlayer.Castle);
                castles.Add(game.SecondPlayer.Castle);

                return Ok(castles);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
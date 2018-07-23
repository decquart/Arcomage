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
        private readonly IGamePipelineService _gamePipelineService;
        private readonly IMapper _mapper;

        public GameController(IGameService gameService, ICardService cardService,
            IDeckService deckService, IGamePipelineService gamePipelineService, IMapper mapper)
        {
            _gameService = gameService;
            _deckService = deckService;
            _cardService = cardService;
            _gamePipelineService = gamePipelineService;
            _mapper = mapper;
        }

        [HttpGet("play/{cardName}/{userId}")]
        public IActionResult Play(string cardName, string userId)
        {
            try
            {
                var game = _gameService.GetCurrentGame(userId);
                var playerCard = game.FirstPlayer.Hand.FirstOrDefault(c => c.Name.Equals(cardName));
                if (playerCard == null)
                    return BadRequest("Card not found");

                var winnerId = _gamePipelineService.PlayerTurn(game, playerCard, game.FirstPlayer, game.SecondPlayer);

                //enemy player part
                // should to replace similar code to module
                var computerPlayerCard = _gameService.GetRandomCard(game.SecondPlayer);
                winnerId = _gamePipelineService.ComputerTurn(game, computerPlayerCard, game.SecondPlayer, 
                    game.FirstPlayer);

                return Ok(new {playerCard, computerPlayerCard });                
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

       
        [HttpGet("discard/{cardName}/{userId}")]
        public IActionResult Discard(string cardName, string userId)
        {
            try
            {
                var game = _gameService.GetCurrentGame(userId);
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

        [HttpGet("start/{userId}/{gameId}")]
        public IActionResult Start(string userId, int gameId)
        {
            try
            {
                Game game;

                var isExist = _gameService.Exist(userId);
                if (isExist)
                    game = _gameService.GetCurrentGame(userId);
                else
                    game = _gameService.GetNewGame(userId);
                game.Id = gameId;

                _deckService.Shuffle(game);
                _deckService.Deal(game);

                string url = "http://localhost:4200/game/" + userId;
                return Redirect(url);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("cards/{userId}")]
        public IActionResult GetUserCards(string userId)
        {
            try
            {
                var game = _gameService.GetCurrentGame(userId);
                var cards = game.FirstPlayer.Hand.ToList();
                var uiCards = _mapper.Map<IEnumerable<Card>, List<CardDto>>(cards);
                return Ok(uiCards);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("castles/{userId}")]
        public IActionResult GetCastles(string userId)
        {
            try
            {                
                var game = _gameService.GetCurrentGame(userId);
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

        [HttpGet("scores/{userId}")]
        public IActionResult GetCurrentScore(string userId)
        {
            try
            {
                var game = _gameService.GetCurrentGame(userId);
                if (game == null)
                    return BadRequest("Game is not valid");
                var scores = _gameService.CountPlayerScore(game);
                return Ok(scores);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
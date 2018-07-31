using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using TwoCastles.Data.Constants;
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
        private readonly IGamePipelineService _gamePipelineService;
        private readonly IMapper _mapper;

        public GameController(IGameService gameService, IDeckService deckService,
            IGamePipelineService gamePipelineService, IMapper mapper)
        {
            _gameService = gameService;
            _deckService = deckService;
            _gamePipelineService = gamePipelineService;
            _mapper = mapper;
        }

        [HttpGet("play/{cardName}/{userId}")]
        public IActionResult Play(string cardName, string userId)
        {
            try
            {
                var game = _gameService.GetCurrentGame(userId);
                var humanPlayer = game.FirstPlayer;
                var computerPlayer = game.SecondPlayer;

                var playerCard = humanPlayer.Hand.FirstOrDefault(c => c.Name.Equals(cardName));
                if (playerCard == null)
                    return BadRequest("Card not found");

                _gamePipelineService.PlayerTurn(game, playerCard, humanPlayer, computerPlayer);
               
                //enemy player part
                var computerPlayerCard = _gameService.GetRandomCard(computerPlayer);
                _gamePipelineService.ComputerTurn(game, computerPlayerCard, computerPlayer, 
                    humanPlayer);

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
                var humanPlayer = game.FirstPlayer;
                var computerPlayer = game.SecondPlayer;

                var playerCard = humanPlayer.Hand.FirstOrDefault(c => c.Name.Equals(cardName));
                if (playerCard == null)
                    return BadRequest("Card not found");

                _gamePipelineService.DiscardTurn(game, playerCard, humanPlayer);
               
                //enemy player part
                var computerPlayerCard = _gameService.GetRandomCard(computerPlayer);
                _gamePipelineService.ComputerTurn(game, computerPlayerCard, computerPlayer,
                    humanPlayer);
              
                return Ok(new { playerCard, computerPlayer});
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
                _deckService.Deal(game, ConstantsList.maxPlayerCards);

                string url = ConstantsList.gameStartUrl + userId;
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
                    return BadRequest("Game does not exist");
                var scores = _gameService.CalculateCurrentPlayerScore(game);
                return Ok(scores);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpGet("check/{gameId}")]
        public IActionResult CheckWinner(string gameId)
        {
            try
            {
                var game = _gameService.GetCurrentGame(gameId);
                if (game == null)
                    return BadRequest("Game does not exist");
                var res = _gameService.EndGameIfWinnerExist(game);
                return Json(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
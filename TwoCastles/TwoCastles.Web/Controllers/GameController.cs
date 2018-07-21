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

        public GameController(IGameService gameService, ICardService cardService,
            IDeckService deckService, IMapper mapper)
        {
            _gameService = gameService;
            _deckService = deckService;
            _cardService = cardService;
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
                var isEnoughRes = _cardService.IsEnoughResources(playerCard, game.FirstPlayer);
                if (!isEnoughRes)
                    return BadRequest($"Player doesn't have enought resources to apply {playerCard.Name}");

                _gameService.IncreasePlayerResource(game.FirstPlayer);
                game.FirstPlayer.Hand.Remove(playerCard);
                _deckService.PushCard(game, playerCard);
                _cardService.Play(playerCard, game.FirstPlayer, game.SecondPlayer);
                _gameService.CheckWinner(game);
                _deckService.GiveCardToPlayer(game, game.FirstPlayer);
                _gameService.NormalizeCastles(game);
                _gameService.CheckWinner(game);

                //enemy player part
                // should to replace similar code to module
                var enemyPlayerCard = _gameService.GetRandomCard(game.SecondPlayer);
                _gameService.IncreasePlayerResource(game.SecondPlayer);
                game.SecondPlayer.Hand.Remove(enemyPlayerCard);
                _deckService.PushCard(game, enemyPlayerCard);
                isEnoughRes = _cardService.IsEnoughResources(enemyPlayerCard, game.SecondPlayer);
                if (isEnoughRes)
                    _cardService.Play(enemyPlayerCard, game.SecondPlayer, game.FirstPlayer);

                _deckService.GiveCardToPlayer(game, game.SecondPlayer);
                _gameService.NormalizeCastles(game);
                _gameService.CheckWinner(game);
                return Ok(new {playerCard, enemyPlayerCard });                
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

                string url = "http://localhost:4200/" + userId;
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
    }
}
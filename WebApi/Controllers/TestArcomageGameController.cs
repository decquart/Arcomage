using BLL.Data;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApi.Models;
using BLL.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestArcomageGameController : Controller
    {
        private Deck deck;
        private DeckService _deckService;
        private InMemoryUsers _inMemoryUsers;
        private CardService _cardService;

        public TestArcomageGameController()
        {
            _inMemoryUsers = new InMemoryUsers();
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("start")]
        public ActionResult StartGame([FromBody] StartGameModel startGameModel)
        {
            deck = new DeckInitializer().Set();
            _deckService = new DeckService(_inMemoryUsers, deck);
            // _inMemoryUsers = new InMemoryUsers();
            _cardService = new CardService(_inMemoryUsers);

            var firstPlayer = _inMemoryUsers.Get(startGameModel.FirstPlayerId);
            var secondPlayer = _inMemoryUsers.Get(startGameModel.SecondPlayerId);

            if (firstPlayer == null || secondPlayer == null)
                throw new Exception($"User 1 or 2 not found");

            _deckService.Deal(startGameModel.FirstPlayerId, startGameModel.SecondPlayerId);
            return Ok();
        }

        [HttpPost]
        [Route("play")]
        public ActionResult PlayCard([FromBody] PlayCardInfoModel playCardInfo)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var currentPlayer = _inMemoryUsers.Get(playCardInfo.CurrentPlayerId);
            var oppositePlayer = _inMemoryUsers.Get(playCardInfo.EnemyPlayerId);

            if (currentPlayer == null || oppositePlayer == null)
                throw new Exception($"User 1 or 2 not found");

            var card = currentPlayer.Hand.FirstOrDefault(c => c.Name.Equals(playCardInfo.CardName));
            if (card == null)
                throw new Exception($"Card not found");

            _cardService.Play(card, playCardInfo.CurrentPlayerId, playCardInfo.EnemyPlayerId);

            return Ok();
            //PassMove
        }
    }
}

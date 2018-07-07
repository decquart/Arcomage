using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoCastles.GameLogic.Interfaces;
using TwoCastles.GameLogic.Services;

namespace TwoCastles.Web.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IDeckService _deckService;
        private readonly ICardService _cardService;

        public GameController(IGameService gameService, ICardService cardService, IDeckService deckService)
        {
            _gameService = gameService;
            _deckService = deckService;
            _cardService = cardService;
        }

        public void Play()
        {            
           
        }

    }
}

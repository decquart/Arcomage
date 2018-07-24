using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Interfaces;

namespace TwoCastles.GameLogic.Services
{
    public class GamePipelineService : IGamePipelineService
    {
        private readonly IGameService _gameService;
        private readonly IDeckService _deckService;
        private readonly ICardService _cardService;

        public GamePipelineService(IGameService gameService, IDeckService deckService,
                                    ICardService cardService)
        {
            _gameService = gameService;
            _deckService = deckService;
            _cardService = cardService;
        }

        public string PlayerTurn(Game game, Card playerCard, Player currentPlayer, Player enemyPlayer)
        {
            var isEnoughRes = _cardService.IsEnoughResources(playerCard, game.FirstPlayer);
            if (!isEnoughRes)
                throw new ApplicationException($"Player doesn't have enough resources to apply {playerCard.Name}");

            _gameService.IncreasePlayerResource(currentPlayer);
            currentPlayer.Hand.Remove(playerCard);
            _deckService.PushCard(game, playerCard);
            _cardService.Play(playerCard, currentPlayer, enemyPlayer);
            _deckService.GiveCardToPlayer(game, currentPlayer);
            _gameService.NormalizeCastles(game);
            _gameService.IncreasePlayerScore(currentPlayer, playerCard);
            return _gameService.CheckWinner(game);      //return winner id
        }

        public string ComputerTurn(Game game, Card computerPlayerCard, Player computerPlayer, Player humanPlayer)
        {
            _gameService.IncreasePlayerResource(computerPlayer);
            computerPlayer.Hand.Remove(computerPlayerCard);
            _deckService.PushCard(game, computerPlayerCard);
            var isEnoughRes = _cardService.IsEnoughResources(computerPlayerCard, computerPlayer);
            //apply card if enough resources
            if (isEnoughRes)
                _cardService.Play(computerPlayerCard, computerPlayer, humanPlayer);

            _deckService.GiveCardToPlayer(game, computerPlayer);
            _gameService.NormalizeCastles(game);
            _gameService.IncreasePlayerScore(computerPlayer, computerPlayerCard);
            _gameService.CheckWinner(game);
            return _gameService.CheckWinner(game);
        }

        public string DiscardTurn(Game game, Card playerCard, Player currentPlayer)
        {
            var isEnoughRes = _cardService.IsEnoughResources(playerCard, currentPlayer);
            if (!isEnoughRes)
                throw new ApplicationException($"Player doesn't have enough resources to apply {playerCard.Name}");

            _gameService.IncreasePlayerResource(game.FirstPlayer);           
            currentPlayer.Hand.Remove(playerCard);
            _deckService.PushCard(game, playerCard);
            _deckService.GiveCardToPlayer(game, currentPlayer);
            _gameService.NormalizeCastles(game);
            return _gameService.CheckWinner(game);
        }
    }
}

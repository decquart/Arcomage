﻿using System;
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

        public void PlayerTurn(Game game, Card playerCard, Player currentPlayer, Player enemyPlayer)
        {
            var isEnoughRes = _cardService.IsEnoughResources(playerCard, game.FirstPlayer);
            if (!isEnoughRes)
                throw new ApplicationException($"Player doesn't have enough resources to apply {playerCard.Name}");

            StartTurnPart(game, currentPlayer, playerCard);
            _cardService.Play(playerCard, currentPlayer, enemyPlayer);

            EndTurnPart(game, currentPlayer);
            _gameService.IncreasePlayerScore(currentPlayer, playerCard);
        }

        public void ComputerTurn(Game game, Card computerPlayerCard, Player computerPlayer, Player humanPlayer)
        {
            StartTurnPart(game, computerPlayer, computerPlayerCard);
            var isEnoughRes = _cardService.IsEnoughResources(computerPlayerCard, computerPlayer);

            //apply card if enough resources, otherwise - just discard without playing
            if (isEnoughRes)
                _cardService.Play(computerPlayerCard, computerPlayer, humanPlayer);

            EndTurnPart(game, computerPlayer);
            _gameService.IncreasePlayerScore(computerPlayer, computerPlayerCard);
        }

        public void DiscardTurn(Game game, Card playerCard, Player currentPlayer)
        {
            StartTurnPart(game, currentPlayer, playerCard);
            EndTurnPart(game, currentPlayer);
        }

        private void StartTurnPart(Game game, Player player, Card card)
        {
            player.Hand.Remove(card);
            _deckService.PushCard(game, card);
        }

        private void EndTurnPart(Game game, Player player)
        {
            _deckService.GiveCardToPlayer(game, player);
            _gameService.NormalizeCastles(game);
            _gameService.IncreasePlayerResource(player);
        }
    }
}

using System;
using System.Linq;
using TwoCastles.Data.Repositories;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Services;

namespace TwoCastles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UnitOfWork inMemoryDb = new UnitOfWork();
            var game = inMemoryDb.Game.GetNewGame();
            DeckService deckService = new DeckService(game);
            CardService cardService = new CardService();
            GameService gameService = new GameService(game);
            deckService.Shuffle();
            deckService.Deal();

            while (true)
            {
                gameService.IncreasePlayerResource(game.FirstPlayer);
                var firstPlayerCard = game.FirstPlayer.Hand.FirstOrDefault();
                game.FirstPlayer.Hand.Remove(firstPlayerCard);
                deckService.PushCard(firstPlayerCard);
                cardService.Play(firstPlayerCard, game.FirstPlayer, game.SecondPlayer);


                gameService.IncreasePlayerResource(game.SecondPlayer);
                var secondPlayerCard = game.SecondPlayer.Hand.FirstOrDefault();
                cardService.Play(secondPlayerCard, game.SecondPlayer, game.FirstPlayer);
            }

            Console.ReadLine();
        }
    }
}


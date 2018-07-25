using System;
using System.Linq;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Interfaces;

namespace TwoCastles.GameLogic.Services
{
    public class DeckService : IDeckService
    {
        private static Random rnd;
        public DeckService()
        {
            rnd = new Random();
        }

        public void Deal(Game game, int amountPlayerCards)
        {
            var firstUser = game.FirstPlayer;
            var secondUser = game.SecondPlayer;

            if (firstUser == null || secondUser == null)
                throw new ArgumentException($"Player is not valid");

            if (firstUser.Hand.Count >= amountPlayerCards ||
                secondUser.Hand.Count >= amountPlayerCards)
                return;

            for (int i = 0; i < amountPlayerCards; i++)
            {
                GiveCardToPlayer(game, firstUser);
                GiveCardToPlayer(game, secondUser);
            }
        }

        public void GiveCardToPlayer(Game game, Player player)
        {
            var card = game.CurrentDeck.Cards.FirstOrDefault();
            
            if (card != null)
            {
                game.CurrentDeck.Cards.Remove(card);
                player.Hand.Add(card);
            }
        }

        public void PushCard(Game game, Card card)
        {
            if (card == null)
                throw new ArgumentException("Card is not valid");
            game.CurrentDeck.Cards.Add(card);
        }

        public void Shuffle(Game game)
        {
            int n = game.CurrentDeck.Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Card value = game.CurrentDeck.Cards[k];
                game.CurrentDeck.Cards[k] = game.CurrentDeck.Cards[n];
                game.CurrentDeck.Cards[n] = value;
            }
        }
    }
}

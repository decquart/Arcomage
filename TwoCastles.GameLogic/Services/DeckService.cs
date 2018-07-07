using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwoCastles.Entities;

namespace TwoCastles.GameLogic.Services
{
    public class DeckService
    {
        private readonly Game _game;
        private static Random rnd;
        public DeckService(Game game)
        {
            _game = game;
            rnd = new Random();
        }

        public void Deal()
        {
            var firstUser = _game.FirstPlayer;
            var secondUser = _game.SecondPlayer;

            if (firstUser == null || secondUser == null)
                throw new ArgumentException($"Player is not valid");

            // amount of cards, which player'll be have
            //TODO: should to change hardcode value!!!
            var length = 6;
            for (int i = 0; i < length; i++)
            {
                GiveCardToPlayer(firstUser);
                GiveCardToPlayer(secondUser);
            }
        }

        public void GiveCardToPlayer(Player player)
        {
            var card = _game.CurrentDeck.Cards.FirstOrDefault();
            //if (card != null)
            //    throw new ArgumentException("Deck doesn't have enought cards");
            if (card != null)
            {
                _game.CurrentDeck.Cards.Remove(card);
                player.Hand.Add(card);
            }
        }

        public void PushCard(Card card)
        {
            if (card == null)
                throw new ArgumentException("Card is not valid");
            _game.CurrentDeck.Cards.Add(card);
        }

        public void Shuffle()
        {
            int n = _game.CurrentDeck.Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Card value = _game.CurrentDeck.Cards[k];
                _game.CurrentDeck.Cards[k] = _game.CurrentDeck.Cards[n];
                _game.CurrentDeck.Cards[n] = value;
            }
        }
    }
}

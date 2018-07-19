﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void Deal(Game game)
        {
            var firstUser = game.FirstPlayer;
            var secondUser = game.SecondPlayer;

            if (firstUser == null || secondUser == null)
                throw new ArgumentException($"Player is not valid");

            // amount of cards, which player'll be have
            //TODO: should to change hardcode value!!!
            var length = 6;
            for (int i = 0; i < length; i++)
            {
                GiveCardToPlayer(game, firstUser);
                GiveCardToPlayer(game, secondUser);
            }
        }

        public void GiveCardToPlayer(Game game, Player player)
        {
            var card = game.CurrentDeck.Cards.FirstOrDefault();
            //if (card != null)
            //    throw new ArgumentException("Deck doesn't have enough cards");
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

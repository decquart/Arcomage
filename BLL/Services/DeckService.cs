using BLL.DTO;
using BLL.Entities;
using BLL.Interfaces;
using BLL.Interfaces.ArcomageGameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class DeckService : IDeckService
    {
        private readonly IUserData _users;
        private readonly IDeck _deck;
        private static Random rnd;

        public DeckService(IUserData users, IDeck deck)
        {
            _users = users;
            _deck = deck;
        }

        public void Deal(string firstUserId, string secondUserId)
        {
            var firstUser = (_users.Get(firstUserId));
            var secondUser = (_users.Get(firstUserId));

            if (firstUser == null || secondUser == null)
                throw new ArgumentException($"Player {firstUserId} or {secondUserId} doesn't exists");

            // amount of cards, which player'll be have
            //TODO: should to change hardcode value!!!
            var length = 6;
            for (int i = 0; i < length; i++)
            {
                GiveCardToPlayer(firstUser);
                GiveCardToPlayer(secondUser);
            }
        }

        public void GiveCardToPlayer(ArcomageUserDTO player)
        {
            var card = _deck.Cards.FirstOrDefault();
            if (card != null)
                throw new ArgumentException("Deck doesn't have enought cards");

            _deck.Cards.Remove(card);
            player.Hand.Add(card);
        }

        public void PushCard(Card card)
        {
            if (card == null)
                throw new ArgumentException("Card is not valid");
            _deck.Cards.Add(card);
        }

        public void Shuffle()
        {
            int n = _deck.Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Card value = _deck.Cards[k];
                _deck.Cards[k] = _deck.Cards[n];
                _deck.Cards[n] = value;
            }
        }
    }

}

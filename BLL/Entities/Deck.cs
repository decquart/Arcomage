﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Entities
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        private static Random rng = new Random();

        public Deck()
        {
            Cards = new List<Card>();
        }

        /*
         * This method'll call only once, when game'll start
         */
        public void Deal(Players players)
        {
            //amount of cards, which player'll be have, should to change hardcode value!!!
            var length = 6;
            for (int i = 0; i < length; i++)
            {
                GiveCard(players.CurrentPlayer);
                GiveCard(players.EnemyPlayer);
            }

        }

        public void GiveCard(ArcomageUserDTO player)
        {
            var card = Cards.FirstOrDefault();
            if (card != null)
            {
                player.Hand.Add(card);
                Cards.Remove(card);
            }
        }

        public void PushCard(Card card)
        {
            if (card == null)
                return;
            Cards.Add(card);
        }


        /*
         * This method mix cards in deck
         */
        public void Shuffle()
        {
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }
    }
}
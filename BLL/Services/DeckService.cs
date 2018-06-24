using BLL.DTO;
using BLL.Entities;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DeckService : IDeckService
    {
        private readonly IUserData _users;

        public DeckService(IUserData users)
        {
            _users = users;
        }
        public void Deal(string firstUserId, string secondUserId)
        {
            var firstUser = (ArcomageUserDTO)(_users.Get(firstUserId));
            var secondUser = (ArcomageUserDTO)(_users.Get(firstUserId));

            if (firstUser == null || secondUser == null)
                throw new NullReferenceException($"Player {firstUserId} or {secondUserId} doesn't exists");
            var length = 6;
            for (int i = 0; i < length; i++)
            {
                GiveCardToPlayer(firstUser);
                GiveCardToPlayer(secondUser);
            }

        }

        public void GiveCardToPlayer(ArcomageUserDTO player)
        {
            throw new NotImplementedException();
        }

        public void PushCard(Card card)
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }
    }
}

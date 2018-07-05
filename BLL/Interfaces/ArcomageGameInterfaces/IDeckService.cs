﻿using BLL.DTO;
using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces.ArcomageGameInterfaces
{
    public interface IDeckService
    {
        void Shuffle();
        void GiveCardToPlayer(ArcomageUserDTO user);
        void PushCard(Card card);
        void Deal(string firstUserId, string secondUserId);
    }
}
using BLL.DTO;
using BLL.Interfaces.ArcomageGameInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Entities
{
    public class Deck : IDeck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
        }        
    }
}

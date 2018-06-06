using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Entities
{
    class Deck
    {
        public ICollection<Card> Cards { get; set; }
        public Deck()
        {
            Cards = new List<Card>();
        }
    }
}

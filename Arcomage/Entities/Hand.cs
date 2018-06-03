using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Entities
{
    class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }
        ICollection<Card> Cards { get; set; }
    }
}

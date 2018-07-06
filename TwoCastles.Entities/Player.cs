using System.Collections.Generic;

namespace TwoCastles.Entities
{
    public abstract class Player
    {
        public Castle Castle { get; set; }
        public List<Card> Hand;

        protected Player()
        {
            Hand = new List<Card>();
        }
    }
}

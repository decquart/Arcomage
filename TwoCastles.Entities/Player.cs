using System.Collections.Generic;

namespace TwoCastles.Entities
{
    public class Player
    {
        public Castle Castle { get; set; }
        public List<Card> Hand;

        public Player()
        {
            Hand = new List<Card>();
        }
        
    }
}

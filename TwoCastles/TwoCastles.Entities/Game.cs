namespace TwoCastles.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public Player FirstPlayer { get; set; }
        public Player SecondPlayer { get; set; }

        public Deck CurrentDeck { get; set; }
    }
}

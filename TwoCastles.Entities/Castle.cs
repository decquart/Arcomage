namespace TwoCastles.Entities
{
    public class Castle
    {
        public int Height { get; set; }
        public int Wall { get; set; }

        //resource
        public int Bricks { get; set; }
        public int Gems { get; set; }
        public int Recruits { get; set; }

        //buildings, which are responsible for resource increaseing
        public int Quarry { get; set; }
        public int Dungeon { get; set; }
        public int Magic { get; set; }
    }
}

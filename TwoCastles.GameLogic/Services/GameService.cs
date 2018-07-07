using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;

namespace TwoCastles.GameLogic.Services
{
    public class GameService
    {
        private readonly Game _game;
        public GameService(Game game)
        {
            _game = game;
        }

        public void NormalizeCastle(Castle castle)
        {
            if (castle.Quarry < 1) castle.Quarry = 1;
            if (castle.Magic < 1) castle.Magic = 1;
            if (castle.Dungeon < 1) castle.Dungeon = 1;

            if (castle.Bricks < 0) castle.Bricks = 0;
            if (castle.Gems < 0) castle.Gems = 0;
            if (castle.Recruits < 0) castle.Recruits = 0;

            if (castle.Wall < 0)
                castle.Wall = 0;
        }
    }
}

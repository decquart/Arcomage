using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CardBehavior
    {
        private readonly Game _game;
        public CardBehavior(Game game)
        {
            _game = game;
        }

        public void Damage(int amount)
        {
            if (_game == null)
            {
                throw new NullReferenceException();
            }

            if (_game.Players.EnemyPlayer.Castle.Wall >= amount)
                _game.Players.EnemyPlayer.Castle.Wall -= amount;
            else
            {
                var oldWallHeight = _game.Players.EnemyPlayer.Castle.Wall;
                var oldCastleHeight = _game.Players.EnemyPlayer.Castle.Height;
                if (_game.Players.EnemyPlayer.Castle.Wall > 0)
                    _game.Players.EnemyPlayer.Castle.Wall = 0;

                _game.Players.EnemyPlayer.Castle.Height -= (amount - oldWallHeight);
            }
        }

        public void AddWall(int amount)
        {
            if (_game.Players == null)
            {
                throw new NullReferenceException();
            }

            _game.Players.CurrentPlayer.Castle.Wall += amount;
        }

        public void AddMagic(int amount)
        {
            if (_game.Players == null)
            {
                throw new NullReferenceException();
            }

            _game.Players.CurrentPlayer.Castle.Magic += amount;
        }

        public void AddDungeon(int amount)
        {
            if (_game.Players == null)
            {
                throw new NullReferenceException();
            }

            _game.Players.CurrentPlayer.Castle.Dungeon += amount;
        }

        public void AddQuarry(int amount)
        {
            if (_game.Players.CurrentPlayer == null)
            {
                throw new NullReferenceException();
            }

            _game.Players.CurrentPlayer.Castle.Quarry += amount;
        }

        public void AddBricks(int amount)
        {
            if (_game == null)
            {
                throw new NullReferenceException();
            }

            _game.Players.CurrentPlayer.Castle.Bricks += amount;
        }

        public void AddGems(int amount)
        {
            if (_game == null)
            {
                throw new NullReferenceException();
            }

            _game.Players.CurrentPlayer.Castle.Gems += amount;
        }

        public void AddRecruits(int amount)
        {
            if (_game == null)
            {
                throw new NullReferenceException();
            }

            _game.Players.CurrentPlayer.Castle.Recruits += amount;
        }

        public void AddCastle(int amount)
        {
            if (_game == null)
            {
                throw new NullReferenceException();
            }
            _game.Players.CurrentPlayer.Castle.Height += amount;
        }
    }
}

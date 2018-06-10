using Arcomage.Entities;
using Arcomage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Services
{
    class CardFunctions
    {
        private readonly Players _players;
        public CardFunctions(Players players)
        {
            _players = players;
        }

        public void Damage(int amount)
        {
            if (_players == null)
            {
                throw new NullReferenceException();
            }

            if (_players.EnemyPlayer.Castle.Wall.Height >= amount)
                _players.EnemyPlayer.Castle.Wall.Height -= amount;
            else
            {
                var oldWallHeight = _players.EnemyPlayer.Castle.Wall.Height;
                var oldCastleHeight = _players.EnemyPlayer.Castle.Height;
                if (_players.EnemyPlayer.Castle.Wall.Height > 0)
                    _players.EnemyPlayer.Castle.Wall.Height = 0;

                _players.EnemyPlayer.Castle.Height -= (amount - oldWallHeight);
            }            
        }

        public void AddWall(int amount)
        {
            if (_players == null)
            {
                throw new NullReferenceException();
            }

            _players.CurrentPlayer.Castle.Wall.Height += amount;
        }

        public void AddMagic(int amount)
        {
            if (_players == null)
            {
                throw new NullReferenceException();
            }

            _players.CurrentPlayer.Castle.Magic += amount;
        }

        public void AddDungeon(int amount)
        {
            if (_players == null)
            {
                throw new NullReferenceException();
            }

            _players.CurrentPlayer.Castle.Dungeon += amount;
        }

        public void AddQuarry(int amount)
        {
            if (_players.CurrentPlayer == null)
            {
                throw new NullReferenceException();
            }

            _players.CurrentPlayer.Castle.Quarry += amount;
        }

        public void AddBricks(int amount)
        {
            if (_players == null)
            {
                throw new NullReferenceException();
            }

            _players.CurrentPlayer.Castle.Bricks += amount;
        }

        public void AddGems(int amount)
        {
            if (_players == null)
            {
                throw new NullReferenceException();
            }

            _players.CurrentPlayer.Castle.Gems += amount;
        }

        public void AddRecruits(int amount)
        {
            if (_players == null)
            {
                throw new NullReferenceException();
            }

            _players.CurrentPlayer.Castle.Recruits += amount;
        }

        public void AddCastle(int amount)
        {
            if (_players == null)
            {
                throw new NullReferenceException();
            }
            _players.CurrentPlayer.Castle.Height += amount;
        }
    }
}

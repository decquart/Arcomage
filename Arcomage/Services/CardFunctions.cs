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
        private readonly IUserData _user;
        public CardFunctions(IUserData user)
        {
            _user = user;
        }

        public void Damage(int userId, int amount)
        {
            var player = _user.Get(userId);

            if (player == null)
            {
                throw new NullReferenceException();
            }

            if (player.Castle.Wall.Height >= amount)
                player.Castle.Wall.Height -= amount;
            else
            {
                var oldWallHeight = player.Castle.Wall.Height;
                var oldCastleHeight = player.Castle.Height;
                if (player.Castle.Wall.Height > 0)
                    player.Castle.Wall.Height = 0;

                player.Castle.Height -= (amount - oldWallHeight);
            }            
        }

        public void AddWall(int userId, int amount)
        {
            var player = _user.Get(userId);

            if (player == null)
            {
                throw new NullReferenceException();
            }

            player.Castle.Wall.Height += amount;
        }

        public void AddMagic(int userId, int amount)
        {
            var player = _user.Get(userId);

            if (player == null)
            {
                throw new NullReferenceException();
            }

            player.Castle.Magic += amount;
        }

        public void AddDungeon(int userId, int amount)
        {
            var player = _user.Get(userId);

            if (player == null)
            {
                throw new NullReferenceException();
            }

            player.Castle.Dungeon += amount;
        }

        public void AddQuarry(int userId, int amount)
        {
            var player = _user.Get(userId);

            if (player == null)
            {
                throw new NullReferenceException();
            }

            player.Castle.Quarry += amount;
        }

        public void AddBricks(int userId, int amount)
        {
            var player = _user.Get(userId);

            if (player == null)
            {
                throw new NullReferenceException();
            }

            player.Castle.Bricks += amount;
        }

        public void AddGems(int userId, int amount)
        {
            var player = _user.Get(userId);

            if (player == null)
            {
                throw new NullReferenceException();
            }

            player.Castle.Gems += amount;
        }

        public void AddRecruits(int userId, int amount)
        {
            var player = _user.Get(userId);

            if (player == null)
            {
                throw new NullReferenceException();
            }

            player.Castle.Recruits += amount;
        }




    }
}

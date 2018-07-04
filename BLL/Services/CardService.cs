using BLL.Data;
using BLL.DTO;
using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CardService
    {
        private readonly InMemoryUsers _userData;
        public CardService(InMemoryUsers userData)
        {
            _userData = userData;
        }

        public void Play(Card card, string id, string oppId)
        {
            var currentPlayer = _userData.Get(id);
            var oppPlayer = _userData.Get(id);

            if (currentPlayer == null || oppPlayer == null)
                throw new Exception($"User {id} or {oppPlayer} not found");

            PayCardPrice(card, currentPlayer);
            ApplyCardAction(card, currentPlayer, oppPlayer);
        }

        void ApplyCardAction(Card card, ArcomageUserDTO currentPlayer, ArcomageUserDTO oppPlayer)
        {
            switch (card.Method)
            {
                case "AddQuarry":
                    AddQuarry(card.Argument, currentPlayer);
                    break;
                case "AddMagic":
                    AddMagic(card.Argument, currentPlayer);
                    break;
                case "AddDungeon":
                    AddDungeon(card.Argument, currentPlayer);
                    break;
                case "AddWall":
                    AddWall(card.Argument, currentPlayer);
                    break;
                case "AddCastle":
                    AddCastle(card.Argument, currentPlayer);
                    break;
                case "Damage":
                    Damage(card.Argument, currentPlayer);
                    break;
                case "AddBricks":
                    AddBricks(card.Argument, currentPlayer);
                    break;
                case "AddGems":
                    AddGems(card.Argument, currentPlayer);
                    break;
                case "AddRecruits":
                    AddRecruits(card.Argument, currentPlayer);
                    break;
                default:
                    Discard();
                    break;
            }
        }


        void PayCardPrice(Card card, ArcomageUserDTO currentPlayer)
        {
            bool isEnoughRes = isEnoughResources(card, currentPlayer);
            if (!isEnoughRes)
                throw new Exception($"Player {currentPlayer} doesn't have enought resources to apply {card.Name}");
            if (card.BrickCost > 0)
                currentPlayer.Castle.Bricks -= card.BrickCost;
            if (card.GemCost > 0)
                currentPlayer.Castle.Gems -= card.GemCost;
            if (card.RecruitCost > 0)
                currentPlayer.Castle.Gems -= card.RecruitCost;
        }

        bool isEnoughResources(Card card, ArcomageUserDTO currentPlayer)
        {
            if (card.BrickCost > currentPlayer.Castle.Bricks ||
                card.GemCost > currentPlayer.Castle.Gems ||
                card.RecruitCost > currentPlayer.Castle.Recruits)
                return false;
            return true;
        }



        void Damage(int amount, ArcomageUserDTO user)
        {
            if (user.Castle.Wall >= amount)
                user.Castle.Wall -= amount;
            else
            {
                var oldWallHeight = user.Castle.Wall;
                var oldCastleHeight = user.Castle.Height;
                if (user.Castle.Wall > 0)
                    user.Castle.Wall = 0;

                user.Castle.Height -= (amount - oldWallHeight);
            }
        }

        void AddWall(int amount, ArcomageUserDTO user)
        {
            user.Castle.Wall += amount;
        }

        void AddMagic(int amount, ArcomageUserDTO user)
        {
            user.Castle.Magic += amount;
        }

        void AddDungeon(int amount, ArcomageUserDTO user)
        {
            user.Castle.Dungeon += amount;
        }

        void AddQuarry(int amount, ArcomageUserDTO user)
        {
            user.Castle.Quarry += amount;
        }

        void AddBricks(int amount, ArcomageUserDTO user)
        {
            user.Castle.Bricks += amount;
        }

        void AddGems(int amount, ArcomageUserDTO user)
        {
            user.Castle.Gems += amount;
        }

        void AddRecruits(int amount, ArcomageUserDTO user)
        {
            user.Castle.Recruits += amount;
        }

        void AddCastle(int amount, ArcomageUserDTO user)
        {
            user.Castle.Height += amount;
        }

        void Discard()
        {
            return;
        }
    }
}

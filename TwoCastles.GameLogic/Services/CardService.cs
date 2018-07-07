using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Interfaces;

namespace TwoCastles.GameLogic.Services
{
    public class CardService : ICardService
    {
        public void Play(Card card, Player currentPlayer, Player enemyPlayer)
        {
            if (currentPlayer == null || enemyPlayer == null)
                throw new ArgumentException($"Players is not valid");

            PayCardPrice(card, currentPlayer);
            ApplyCardAction(card, currentPlayer, enemyPlayer);
        }

        private void PayCardPrice(Card card, Player currentPlayer)
        {
            bool isEnoughRes = IsEnoughResources(card, currentPlayer);
            if (!isEnoughRes)
                throw new Exception($"Player {currentPlayer} doesn't have enought resources to apply {card.Name}");
            if (card.BrickCost > 0)
                currentPlayer.Castle.Bricks -= card.BrickCost;
            if (card.GemCost > 0)
                currentPlayer.Castle.Gems -= card.GemCost;
            if (card.RecruitCost > 0)
                currentPlayer.Castle.Gems -= card.RecruitCost;
        }

        private void ApplyCardAction(Card card, Player currentPlayer, Player oppPlayer)
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
                    Damage(card.Argument, oppPlayer);
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


        public bool IsEnoughResources(Card card, Player currentPlayer)
        {
            if (card.BrickCost > currentPlayer.Castle.Bricks ||
                card.GemCost > currentPlayer.Castle.Gems ||
                card.RecruitCost > currentPlayer.Castle.Recruits)
                return false;
            return true;
        }



        private void Damage(int amount, Player user)
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

        private void AddWall(int amount, Player user)
        {
            user.Castle.Wall += amount;
        }

        private void AddMagic(int amount, Player user)
        {
            user.Castle.Magic += amount;
        }

        private void AddDungeon(int amount, Player user)
        {
            user.Castle.Dungeon += amount;
        }

        private void AddQuarry(int amount, Player user)
        {
            user.Castle.Quarry += amount;
        }

        private void AddBricks(int amount, Player user)
        {
            user.Castle.Bricks += amount;
        }

        private void AddGems(int amount, Player user)
        {
            user.Castle.Gems += amount;
        }

        private void AddRecruits(int amount, Player user)
        {
            user.Castle.Recruits += amount;
        }

        private void AddCastle(int amount, Player user)
        {
            user.Castle.Height += amount;
        }

        private void Discard()
        {
            return;
        }
    }
}

using System;
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
            if (card.BrickCost > 0)
                currentPlayer.Castle.Bricks -= card.BrickCost;
            if (card.GemCost > 0)
                currentPlayer.Castle.Gems -= card.GemCost;
            if (card.RecruitCost > 0)
                currentPlayer.Castle.Recruits -= card.RecruitCost;
        }

        private void ApplyCardAction(Card card, Player currentPlayer, Player oppPlayer)
        {
            for (int i = 0; i < card.Method.Count; i++)
            {
                switch (card.Method[i])
                {
                    case "AddQuarry":
                        AddQuarry(card.Argument[i], currentPlayer);
                        break;
                    case "AddMagic":
                        AddMagic(card.Argument[i], currentPlayer);
                        break;
                    case "AddDungeon":
                        AddDungeon(card.Argument[i], currentPlayer);
                        break;
                    case "AddEnemyDungeon":
                        AddDungeon(card.Argument[i], oppPlayer);
                        break;
                    case "AddWall":
                        AddWall(card.Argument[i], currentPlayer);
                        break;
                    case "AddCastle":
                        AddCastle(card.Argument[i], currentPlayer);
                        break;
                    case "AddEnemyCastle":
                        AddCastle(card.Argument[i], oppPlayer);
                        break;
                    case "Damage":
                        Damage(card.Argument[i], oppPlayer);
                        break;
                    case "TakeDamage":
                        Damage(card.Argument[i], currentPlayer);
                        break;
                    case "AddBricks":
                        AddBricks(card.Argument[i], currentPlayer);
                        break;
                    case "AddGems":
                        AddGems(card.Argument[i], currentPlayer);
                        break;
                    case "AddRecruits":
                        AddRecruits(card.Argument[i], currentPlayer);
                        break;
                    case "DamageCastle":
                        DamageCastle(card.Argument[i], currentPlayer);
                        break;
                    case "DamageEnemyCastle":
                        DamageCastle(card.Argument[i], oppPlayer);
                        break;
                    case "DamageWall":
                        DamageWall(card.Argument[i], currentPlayer);
                        break;
                    case "Parity":
                        Parity(currentPlayer, oppPlayer);
                        break;
                    case "ReduceBricks":
                        ReduceBricks(card.Argument[i], currentPlayer);
                        break;
                    case "ReduceEnemyBricks":
                        ReduceBricks(card.Argument[i], oppPlayer);
                        break;
                    case "ReduceGems":
                        ReduceGems(card.Argument[i], currentPlayer);
                        break;
                    case "ReduceQuarry":
                        ReduceQuarry(card.Argument[i], currentPlayer);
                        break;
                    case "ReduceRecruits":
                        ReduceRecruits(card.Argument[i], currentPlayer);
                        break;
                    case "ReduceEnemyQuarry":
                        ReduceQuarry(card.Argument[i], oppPlayer);
                        break;
                    case "ReduceEnemyGems":
                        ReduceGems(card.Argument[i], oppPlayer);
                        break;
                    case "ReduceEnemyRecruits":
                        ReduceRecruits(card.Argument[i], oppPlayer);
                        break;
                    case "ReduceEnemyDungeon":
                        ReduceDungeon(card.Argument[i], oppPlayer);
                        break;
                    case "ReduceMagic":
                        ReduceMagic(card.Argument[i], currentPlayer);
                        break;
                    case "ReduceEnemyMagic":
                        ReduceMagic(card.Argument[i], oppPlayer);
                        break;
                    case "SwapWall":
                        SwapWall(currentPlayer, oppPlayer);
                        break;
                    default:
                        break;
                }
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

        private void DamageCastle(int amount, Player user)
        {
            user.Castle.Height -= amount;
        }

        private void DamageWall(int amount, Player user)
        {
            user.Castle.Wall -= amount;
        }

        private void Parity(Player currentPlayer, Player enemyPlayer)
        {
            int maxMagic = Math.Max(currentPlayer.Castle.Magic, enemyPlayer.Castle.Magic);
            currentPlayer.Castle.Magic = maxMagic;
            enemyPlayer.Castle.Magic = maxMagic;
        }

        private void ReduceBricks(int amount, Player user)
        {
            user.Castle.Bricks -= amount;
        }

        private void ReduceGems(int amount, Player user)
        {
            user.Castle.Gems -= amount;
        }

        private void ReduceRecruits(int amount, Player user)
        {
            user.Castle.Recruits -= amount;
        }

        private void ReduceQuarry(int amount, Player user)
        {
            user.Castle.Quarry -= amount;
        }

        private void ReduceMagic(int amount, Player player)
        {
            player.Castle.Magic -= amount;
        }

        private void ReduceDungeon(int amount, Player user)
        {
            user.Castle.Dungeon -= amount;
        }

        private void SwapWall(Player currentPlayer, Player enemyPlayer)
        {
            int tempWall = currentPlayer.Castle.Wall;
            currentPlayer.Castle.Wall = enemyPlayer.Castle.Wall;
            enemyPlayer.Castle.Wall = tempWall;
        }
    }
}

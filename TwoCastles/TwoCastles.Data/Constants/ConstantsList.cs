using System;
using System.Collections.Generic;
using System.Text;

namespace TwoCastles.Data.Constants
{
    public static class ConstantsList
    {
        public const int maxPlayerCards = 6;
        public const int maxCastleHeight = 50;
        public const int minCastleHeight = 0;

        public const string gameStartUrl = "http://localhost:4200/game/";
        public const string scoreCreateUrl = "https://localhost:44364/api/scores/create/";
        public const string computerId = "AI";
        public const string winCaseMessage = "You won!Your score: ";
        public const string loseCaseMessage = "You lost!Your score: ";

        //mongodb constants
        public const string connectionString = "mongodb://localhost:27017";
        public const string cardCollectionName = "cards";
        public const string mongodbName = "game";

        public const int loseScoreСoefficient = 10;
        
        public const int castle = 20;
        public const int wall = 5;

        public const int bricks = 5;
        public const int gems = 5;
        public const int recruits = 5;

        public const int quarry = 2;
        public const int magic = 2;
        public const int dungeon = 2;

    }
}

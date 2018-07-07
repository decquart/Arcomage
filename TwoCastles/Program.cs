using System;
using TwoCastles.Data.Repositories;
using TwoCastles.Entities;
using TwoCastles.GameLogic.Helpers;
using TwoCastles.GameLogic.Services;

namespace TwoCastles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UnitOfWork inMemoryDb = new UnitOfWork();
            var game = new GameInit().Init();
            DeckService deckService = new DeckService(game);

            deckService.Deal();
            
           
            Console.ReadLine();
        }
    }
}


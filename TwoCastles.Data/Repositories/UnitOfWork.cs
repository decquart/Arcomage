using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Data.Interfaces;
using TwoCastles.Entities;

namespace TwoCastles.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private GameRepository gameRepository;

        public IGameRepository Game
        {
            get
            {
                if (gameRepository == null)

                    if (gameRepository == null)
                        gameRepository = new GameRepository();
                return gameRepository;
            }
        }
    }
}

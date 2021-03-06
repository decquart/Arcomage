﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Data.Constants;
using TwoCastles.Data.Context;
using TwoCastles.Data.Interfaces;
using TwoCastles.Entities;
using TwoCastles.Entities.Models;

namespace TwoCastles.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private GameRepository _gameRepository;
        private CardRepository _cardRepository;
        private readonly ApplicationContext _db;

        public UnitOfWork(IOptions<MongoSettings> settings)
        {
            _db = new ApplicationContext(settings.Value.ConnectionString, settings.Value.Database);
        }

        public IGameRepository Game
        {
            get
            {
                if (_gameRepository == null)

                    if (_gameRepository == null)
                        _gameRepository = new GameRepository();
                return _gameRepository;
            }
        }

        public ICardRepository Cards
        {
            get
            {
                if (_cardRepository == null)

                    if (_cardRepository == null)
                        _cardRepository = new CardRepository(_db);
                return _cardRepository;
            }
        }
    }
}

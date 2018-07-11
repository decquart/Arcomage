using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class GameService : IGameService
    {
        IUnitOfWork _db;
        IMapper _mapper;

        public GameService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void CreateGame(GameDto game)
        {
            if (game == null)
                throw new Exception ( "Game is not valid" );
            var _game = _mapper.Map<GameDto, Game>(game);
            _db.Games.Create(_game);
            _db.Save();
            
        }

        public GameDto Get(int gameId)
        {
            var game = _db.Games.Get(gameId);
            if (game == null)
                throw new Exception($"Game {gameId} not found");

            return _mapper.Map<Game, GameDto>(game);
        }

        public IEnumerable<GameDto> GetGameList()
        {
            var games = _db.Games.GetAll();
            return _mapper.Map<IEnumerable<Game>, List<GameDto>>(games);
        }
    }
}

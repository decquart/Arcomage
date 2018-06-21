using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class GameRepository : IRepository<Game>
    {
        private readonly ApplicationContext _db;

        public GameRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void Create(Game game)
        {
            _db.Games.Add(game);
        }

        public void Delete(int id)
        {
            var game = _db.Games.Find(id);
            if (game != null)
                _db.Games.Remove(game);
        }

        public IEnumerable<Game> Find(Func<Game, bool> predicate)
        {
            return _db.Games.Where(predicate);
        }

        public Game Get(int id)
        {
            return _db.Games.Find(id);
        }

        public IEnumerable<Game> GetAll()
        {
            return _db.Games.ToList();
        }

        public void Update(Game game)
        {
            _db.Entry(game).State = EntityState.Modified;
        }
    }
}

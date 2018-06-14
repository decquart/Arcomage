using Arcomage.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class HighScoreRepository : IRepository<HighScore, int>
    {
        private ApplicationContext _db;

        public HighScoreRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Create(HighScore highScore)
        {
            _db.HighScore.Add(highScore);
        }

        public void Delete(int id)
        {
            var highScore = _db.HighScore.Find(id);
            if (highScore != null)
                _db.HighScore.Remove(highScore);
        }

        public IEnumerable<HighScore> Find(Func<HighScore, bool> predicate)
        {
            return _db.HighScore.Where(predicate);
        }

        public HighScore Get(int id)
        {
            return _db.HighScore.Find(id);
        }

        public IEnumerable<HighScore> GetAll()
        {
            return _db.HighScore.ToList();
        }

        public void Update(HighScore highScore)
        {
            _db.Entry(highScore).State = EntityState.Modified;
        }
    }
}

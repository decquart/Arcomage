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
    class ScoreRepository : IRepository<Score>
    {
        private readonly ApplicationContext _db;

        public ScoreRepository(ApplicationContext db)
        {
            _db = db;
        }

        public void Create(Score score)
        {
            _db.Scores.Add(score);
        }

        public void Delete(int id)
        {
            var score = _db.Scores.Find(id);
            if (score != null)
                _db.Scores.Remove(score);
        }

        public IEnumerable<Score> Find(Func<Score, bool> predicate)
        {
            return _db.Scores.Where(predicate);
        }

        public Score Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Score> GetAll()
        {
            return _db.Scores.ToList();
        }

        public void Update(Score score)
        {
            _db.Entry(score).State = EntityState.Modified;
        }
    }
}

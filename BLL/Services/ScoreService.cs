using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ScoreService : IScoreService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public ScoreService(UserManager<User> userManager, IUnitOfWork db, IMapper mapper)
        {
            _userManager = userManager;
            _db = db;
            _mapper = mapper;
        }

        public bool AddScore(string _userId, int _gameId, int _value)
        {
            var user = _userManager.FindByIdAsync(_userId).GetAwaiter().GetResult();
            if (user == null)
                throw new ArgumentException($"User with id {_userId} does not exist!");

            var game = _db.Games.Get(_gameId);

            if (game == null)
                throw new ArgumentException($"Game {_gameId} not found");

            var score = new Score() { Value = _value, GameId = _gameId, AspNetUserId = _userId };
            game.Scores.Add(score);

            _db.Scores.Create(score);
            _db.Save();
            return true;
        }

        public IEnumerable<ScoreDtoWithEmail> GetScoresByGame(int gameId)
        {
            var game = _db.Games.Get(gameId);
            if (game == null)
                throw new ArgumentException($"Game {gameId} not found");

            var scores = _db.Scores.Find(c => c.GameId.Equals(gameId));
            var usersIQuer = _userManager.Users;

            /*this linq join id and score from score to user email*/
            IEnumerable<ScoreDtoWithEmail> joinedScore =  scores.Join(usersIQuer, 
             s => s.AspNetUserId, 
             u => u.Id, 
             (s, u) => new ScoreDtoWithEmail { Id = s.Id, Value = s.Value, Email = u.Email });

            return joinedScore.OrderByDescending(s => s.Value).ToList();
        }       

        public IEnumerable<ScoreDtoWithEmail> GetTotalAverageScore()
        {
            var scores = _db.Scores.GetAll();
            var users = _userManager.Users;

            IEnumerable<ScoreDtoWithEmail> joinedScore = scores.Join(users,
            s => s.AspNetUserId,
            u => u.Id,
            (s, u) => new ScoreDtoWithEmail { Id = s.Id, Value = s.Value, Email = u.Email });

            var grpuped = joinedScore.GroupBy(s => s.Email);


            var newUniqAverageScoreEmail = new List<ScoreDtoWithEmail>();
            foreach (var gr in grpuped)
            {
                newUniqAverageScoreEmail.Add(gr.FirstOrDefault());
            }

            int count = 0;
            foreach (var gr in grpuped)
            {
                int sumScore = 0;
                foreach (var scr in gr)
                {
                    sumScore += scr.Value;
                }
                newUniqAverageScoreEmail[count].Value = sumScore;
                count++;
            }

            return newUniqAverageScoreEmail.OrderByDescending(s => s.Value)
                .Take(10).ToList();            
        }
    }
}

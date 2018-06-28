using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BLL.Services
{
    public class MathQuizGameService : IMathQuizGameService
    {
        private readonly IUnitOfWork _db;
        private int CorrectAnswer { get; set; }
        private readonly Random _rnd;

        public MathQuizGameService(IUnitOfWork db)
        {
            _db = db;
            _rnd = new Random(DateTime.Now.Millisecond);
        }

        public bool CheckAnswer(int userAnswer)
        {
            if (userAnswer != CorrectAnswer)
                return false;
            return true;
        }

        public string GenerateQuestion()
        {
            var firstNumber = _rnd.Next(1, 100);
            var secondNumber = _rnd.Next(1, 100) % firstNumber;
            var newRnd = _rnd.Next(1, 3);

            if (newRnd == 1)
            {
                CorrectAnswer = firstNumber + secondNumber;
                return $"{firstNumber} + {secondNumber} = ?";
            }
            else
            {
                CorrectAnswer = firstNumber - secondNumber;
                return $"{firstNumber} - {secondNumber} = ?";
            }
        }        
    }
}

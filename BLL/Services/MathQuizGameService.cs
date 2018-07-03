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
        private int firstNumber;
        private int secondNumber;
        private string problem;

        public MathQuizGameService(IUnitOfWork db)
        {
            _db = db;
            _rnd = new Random(DateTime.Now.Millisecond);
        }

        public bool CheckAnswer(int userAnswer)
        {
            return userAnswer != CorrectAnswer;
        }

        public void GenerateQuestion()
        {
            firstNumber = _rnd.Next(1, 100);
            secondNumber = _rnd.Next(1, 100) % firstNumber;
            var operationRnd = _rnd.Next(1, 3);

            MathOp((Operation)operationRnd);
        }

        private void MathOp(Operation op)
        {
            switch (op)
            {
                case Operation.Add:
                    CorrectAnswer = firstNumber + secondNumber;
                    problem = $"{firstNumber} + {secondNumber} = ?";
                    break;

                case Operation.Subtract:
                    CorrectAnswer = firstNumber - secondNumber;
                    problem = $"{firstNumber} - {secondNumber} = ?";
                    break;
            }
        }

        public override string ToString()
        {
            return problem.ToString();
        }

        enum Operation
        {
            Add = 1,
            Subtract
        }
    }
}

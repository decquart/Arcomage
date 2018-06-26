using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IMathQuizGameService
    {
        string GenerateQuestion(int firstNumber, int secondNumber);
        int GetrandomNumber();
        bool CheckAnswer(int correctAnswer, int userAnswer);

    }
}

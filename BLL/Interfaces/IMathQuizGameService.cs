using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IMathQuizGameService
    {
        string GenerateQuestion();
        bool CheckAnswer(int userAnswer);

    }
}

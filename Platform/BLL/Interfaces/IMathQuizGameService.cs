using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IMathQuizGameService
    {
        void GenerateQuestion();
        bool CheckAnswer(int userAnswer);

    }
}

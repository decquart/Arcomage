using System;
using System.Collections.Generic;
using System.Text;

namespace TwoCastles.GameLogic.Interfaces
{
    public interface IApiService
    {
        void Post<T>(string url, T model);
    }
}

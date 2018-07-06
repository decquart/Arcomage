using System;
using System.Collections.Generic;
using System.Text;

namespace TwoCastles.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IGameRepository Game { get; }
    }
}

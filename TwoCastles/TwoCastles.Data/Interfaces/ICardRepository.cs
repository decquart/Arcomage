using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Entities;

namespace TwoCastles.Data.Interfaces
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAll();
    }
}

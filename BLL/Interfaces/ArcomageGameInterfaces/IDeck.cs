using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces.ArcomageGameInterfaces
{
    public interface IDeck
    {
        List<Card> Cards { get; set; }
    }
}

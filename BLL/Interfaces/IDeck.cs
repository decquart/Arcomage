using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDeck
    {
        List<Card> Cards { get; set; }
    }
}

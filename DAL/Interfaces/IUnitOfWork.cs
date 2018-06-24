using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //UserManager Users { get; }
        IRepository<Game> Games { get; }
        IRepository<Score> Scores { get; }
        Task SaveAsync();
        void Save();
    }
}

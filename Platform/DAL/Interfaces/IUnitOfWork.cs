using DAL.Entities;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Game> Games { get; }
        IRepository<Score> Scores { get; }
        Task SaveAsync();
        void Save();
    }
}

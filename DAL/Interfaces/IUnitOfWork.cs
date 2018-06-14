using DAL.Entities;
using DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<HighScore, int> HighScores { get; }
        UserManager Users { get; }
        Task SaveAsync();
        void Save();
    }
}

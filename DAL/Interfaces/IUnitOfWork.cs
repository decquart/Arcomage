using DAL.Entities;
using DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<HighScore, int> Messages { get; }
        UserManager Users { get; }
        Task SaveAsync();
        void Save();
    }
}

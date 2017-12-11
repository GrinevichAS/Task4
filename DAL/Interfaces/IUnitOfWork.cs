using System;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Manager> Managers { get; }
        IRepository<Sale> Sales { get; }
        void Save();
    }
}
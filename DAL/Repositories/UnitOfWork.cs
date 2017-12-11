using System;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private ShopContext db;
        private ManagerRepository managerRepository;
        private SaleRepository saleRepository;

        public UnitOfWork()
        {
            db = new ShopContext();
        }

        public IRepository<Manager> Managers
        {
            get
            {
                if (managerRepository == null)
                {
                    managerRepository = new ManagerRepository(db);
                }
                return managerRepository;
            }
        }

        public IRepository<Sale> Sales
        {
            get
            {
                if (saleRepository == null)
                {
                    saleRepository = new SaleRepository(db);
                }
                return saleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
           if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class SaleRepository: IRepository<Sale>
    {
        private ShopContext db;

        public SaleRepository(ShopContext context)
        {
            db = context;
        }

        public IEnumerable<Sale> GetAll()
        {
            return db.Sales.Include(o => o.Sum);
        }

        public Sale Get(int id)
        {
            return db.Sales.Find(id);
        }

        public IEnumerable<Sale> Find(Func<Sale, bool> predicate)
        {
            return db.Sales.Include(o => o.Sum).Where(predicate);
        }

        public void Create(Sale item)
        {
            db.Sales.Add(item);
        }

        public void Update(Sale item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Sale sale = db.Sales.Find(id);
            if (sale != null)
            {
                db.Sales.Remove(sale);
            }
        }
    }
}
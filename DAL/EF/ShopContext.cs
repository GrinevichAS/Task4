using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class ShopContext : DbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Sale> Sales { get; set; }

       
        public ShopContext()
        {
            System.Data.Entity.Database.SetInitializer<ShopContext>(new ShopDbInitializer());
        }
        
        public class ShopDbInitializer : DropCreateDatabaseIfModelChanges<ShopContext>
        {
            protected override void Seed(ShopContext db)
            {
               // db.Managers.Add(new Manager {LastName = "Ivanov"});
                db.SaveChanges();
            }
        }
    }
}
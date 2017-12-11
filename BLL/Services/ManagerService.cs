using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class ManagerService : IManagerService
    {
        private IUnitOfWork Database { get; set; }
        
        public ManagerService()
        {
            Database = new UnitOfWork();
        }

        public void AddSale(SaleDTO sale)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleDTO, Sale>();
            });
            IMapper mapper = config.CreateMapper();
            Database.Sales.Create(mapper.Map<SaleDTO, Sale>(sale));
            Database.Save();
        }

        public void AddSales(ICollection<SaleDTO> sales)
        {
            foreach (var item in sales)
            {
                AddSale(item);
            }
        }

        public void AddManager(ManagerDTO manager)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManagerDTO, Manager>();
            });
            IMapper mapper = config.CreateMapper();
            Database.Managers.Create(mapper.Map<ManagerDTO, Manager>(manager));
            Database.Save();
        }

        public bool CheckManager(string managerLastName)
        {
            return Database.Managers.Find(x => x.LastName == managerLastName).Any();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
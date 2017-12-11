using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using PL.Interfaces;
using PL.Models;

namespace PL.ServicesPL
{
    public class ManagerServicePL : IManagerServicePL
    {
        readonly IManagerService db;

        public ManagerServicePL()
        {
            db = new ManagerService();
        }

        private SaleDTO MapSale(SaleModel sale)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SaleModel, SaleDTO>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<SaleModel, SaleDTO>(sale);
        }

        public void SendSaleInfo(SaleModel sale)
        {
            db.AddSale(MapSale(sale));
        }

        public void SendSalesInfo(ICollection<SaleModel> sales)
        {
            ICollection<SaleDTO> salesInfo = sales.Select(MapSale).ToList();
            db.AddSales(salesInfo);
        }

        public bool CheckManager(string managerLastName)
        {
            return db.CheckManager(managerLastName);
        }

        public void SendManagerInfo(ManagerModel manager)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ManagerModel, ManagerDTO>();
            });
            IMapper mapper = config.CreateMapper();
            db.AddManager(mapper.Map<ManagerModel, ManagerDTO>(manager));
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IManagerService
    {
        void AddSale(SaleDTO sale);
        void AddSales(ICollection<SaleDTO> sales);
        bool CheckManager(string managerLastName);
        void AddManager(ManagerDTO manager);
        void Dispose();
    }
}
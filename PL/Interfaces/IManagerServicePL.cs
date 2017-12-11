using System.Collections.Generic;
using PL.Models;

namespace PL.Interfaces
{
    public interface IManagerServicePL
    {
        void SendSaleInfo(SaleModel sale);
        void SendSalesInfo(ICollection<SaleModel> sales);
        void SendManagerInfo(ManagerModel manager);
        bool CheckManager(string managerLastName);
        void Dispose();
    }
}
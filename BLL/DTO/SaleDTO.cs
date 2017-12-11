using System;

namespace BLL.DTO
{
    public class SaleDTO
    {
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public double Sum { get; set; }
    }
}
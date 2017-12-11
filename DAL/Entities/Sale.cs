using System;

namespace DAL.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public double Sum { get; set; }
    }
}
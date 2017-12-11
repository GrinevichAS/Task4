using System;

namespace PL.Models
{
    public class SaleModel
    {
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public double Sum { get; set; }

        public SaleModel( DateTime date, string customer, string product, double sum)
        {
            Date = date;
            CustomerName = customer;
            Product = product;
            Sum = sum;
        }
    }
}
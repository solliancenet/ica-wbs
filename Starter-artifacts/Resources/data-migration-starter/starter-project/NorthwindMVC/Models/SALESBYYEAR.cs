using System;

namespace NorthwindMVC.Models
{
    public class SALESBYYEAR
    {
        public DateTime ShippedDate { get; set; }

        public decimal ORDERID { get; set; }

        public double SUBTOTAL { get; set; }

        public string YEAR { get; set; }
    }
}
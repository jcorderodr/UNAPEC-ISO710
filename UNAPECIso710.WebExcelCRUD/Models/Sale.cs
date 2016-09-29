using System;

namespace UNAPECIso710.WebExcelCRUD.Models
{
    public class Sale
    {
        public double Id { get; set; }
        public double UserId { get; set; }
        public double TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
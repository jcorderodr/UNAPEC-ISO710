using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UNAPECIso710.WebExcelCRUD.Models
{
    public class Category
    {
        public double Id { get; set; }
        public string Name { get; set; }
    }

    public class Product
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public double CategoryId { get; set; }
        public double CustomerId { get; set; }


    }
}
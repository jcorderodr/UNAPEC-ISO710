using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UNAPECIso710.WebExcelCRUD.Models
{
    public class Client
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double TotalPrice { get; set; }
    }
}
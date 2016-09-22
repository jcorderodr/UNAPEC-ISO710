using LinqToExcel;
using LinqToExcel.Query;
using System;

namespace UNAPECIso710.WebExcelCRUD.Models
{
    public class DataContext : IDisposable
    {

        private readonly string dataContentFile;
        private readonly IExcelQueryFactory _factory;

        public DataContext(string path)
        {
            dataContentFile = path + "Content\\Data.xls";
            _factory = new ExcelQueryFactory(dataContentFile);


        }

        public void Dispose()
        {
            _factory.Dispose();
        }

        private ExcelQueryable<Row> GetWorksheetByName(string name)
        {
            return _factory.Worksheet(name);
        }

        public ExcelQueryable<Row> Customers
        {
            get
            {
                return GetWorksheetByName("Customers");
            }
        }

        public ExcelQueryable<Row> Categories
        {
            get
            {
                return GetWorksheetByName("Categories");
            }
        }

        public ExcelQueryable<Row> Products
        {
            get
            {
                return GetWorksheetByName("Products");
            }
        }

        public ExcelQueryable<Row> Clients
        {
            get
            {
                return GetWorksheetByName("Clients");
            }
        }

    }
}
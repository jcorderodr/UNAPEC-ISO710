using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using UNAPECIso710.WebExcelCRUD.Helpers;
using UNAPECIso710.WebExcelCRUD.Models;

namespace UNAPECIso710.WebExcelCRUD.ApiControllers
{
    public class SalesController : ApiController
    {

        private DataContext _dataContext;

        [HttpGet]
        [Route("api/sales/sum")]
        public IHttpActionResult GetMonths()
        {
            _dataContext = new DataContext(System.Web.Hosting.HostingEnvironment.MapPath("~/"));

            var sales = _dataContext.Sales.AsList<Sale>();

            var startDate = new DateTime(2016, 01, 01);
            var counterDate = startDate;
            var months = Enumerable.Range(0, 12).Select(i => 
            {
                counterDate = startDate.AddMonths(i+1);
                var total = sales.Where(p => p.Date >= startDate.AddMonths(i) && p.Date <= counterDate).Sum(p => p.TotalPrice);
                return total;
            });

            return Ok(months);
        }


        [HttpGet]
        [Route("api/sales/customers")]
        public IHttpActionResult GetWithCustomers()
        {
            _dataContext = new DataContext(System.Web.Hosting.HostingEnvironment.MapPath("~/"));

            var sales = _dataContext.Sales.AsList<Sale>();
            var clients = _dataContext.Clients.AsList<Client>();

            var total = sales.Sum(p => p.TotalPrice);
            var response = new List<object>();
            foreach (var item in sales.GroupBy(p => p.UserId))
            {
                var user = clients.Single(p => p.Id == item.Key);

                var spent = item.Sum(p => p.TotalPrice);
                response.Add(new { name = user.Name, value = spent, y =  spent * 100 / total });
            }

            return Ok(response);
        }

    }
}

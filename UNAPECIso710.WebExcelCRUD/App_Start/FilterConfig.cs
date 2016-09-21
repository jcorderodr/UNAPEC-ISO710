using System.Web;
using System.Web.Mvc;

namespace UNAPECIso710.WebExcelCRUD
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

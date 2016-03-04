using Superheroes.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace Superheroes.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AppInfoFilter());
        }
    }
}

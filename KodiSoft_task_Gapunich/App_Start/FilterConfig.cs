using System.Web;
using System.Web.Mvc;

namespace KodiSoft_task_Gapunich
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

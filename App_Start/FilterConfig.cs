using System.Web;
using System.Web.Mvc;

namespace MIS4200_Team8_Scrum
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

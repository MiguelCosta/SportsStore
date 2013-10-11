using System.Web;
using System.Web.Mvc;
using SportsStore.WebUI.Filters;

namespace SportsStore.WebUI {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ProfileAllAttribute());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.HtmlHelpers {
    public static class ProductListHelpers {

        public static void ListArrayProducts(this HtmlHelper html, IEnumerable<Product> prods) {
            foreach(Product p in prods) {
                html.RenderPartial("ProductSummary", p);
            }
        }

    }
}
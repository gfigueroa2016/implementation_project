using System;
using System.Text;
using System.Web.Mvc;
using DJMaxStore.Models;

namespace DJMaxStore.HtmlHelpers
{
    //Esta clase de PaginationHelper, ayuda a la paginacion de las paginas de html
    public static class PaginationHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper htmlHelper,
                                              PaginationModel pagination,
                                              Func<int, string> pageUrl) {

            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagination.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagination.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}
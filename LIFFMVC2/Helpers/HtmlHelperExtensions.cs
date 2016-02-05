using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LIFFMVC2.Helpers
{
    public static class HtmlHelperExtensions
    {
            public static MvcHtmlString Hyperlink(this HtmlHelper helper, string url, string linkText, bool newWindow)
            {
                return MvcHtmlString.Create(String.Format("<a href='{0}'>{1}</a>", url, linkText));
            }

        public static MvcHtmlString ExternalLink(this HtmlHelper htmlHelper, string url, object innerHtml, object htmlAttributes = null, object dataAttributes = null)
        {
            var link = new TagBuilder("a");
            link.MergeAttribute("href", url);
            link.InnerHtml = innerHtml.ToString();
            link.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

            //Data attributes are definitely a nice to have.
            //I don't know of a better way of rendering them using the RouteValueDictionary however.
            if (dataAttributes != null)
            {
                var values = new RouteValueDictionary(dataAttributes);

                foreach (var value in values)
                {
                    link.MergeAttribute("data-" + value.Key, value.Value.ToString());
                }
            }

            return MvcHtmlString.Create(link.ToString(TagRenderMode.Normal));
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.MyHtmlHelpers
{
    public static class PagingHelpers
    {
        //public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        //{
        //    StringBuilder result = new StringBuilder();
        //    for (int i = 1; i <= pagingInfo.TotalPages; i++)
        //    {
        //        TagBuilder liTag = new TagBuilder("a");
        //        liTag.MergeAttribute("href", pageUrl(i));
        //        liTag.InnerHtml = i.ToString();
        //        if (i == pagingInfo.CurrentPage)
        //            liTag.AddCssClass("selected");
        //        result.Append(liTag.ToString());
        //    }
        //    return MvcHtmlString.Create(result.ToString());
        //}

        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            int start, end;
            if (pagingInfo.CurrentPage <= 3)
                start = 1;
            else
                start = pagingInfo.CurrentPage - 2;
            if (pagingInfo.CurrentPage >= pagingInfo.TotalPages - 2)
                end = pagingInfo.TotalPages;
            else
                end = pagingInfo.CurrentPage + 2;
            if (pagingInfo.CurrentPage != 1)
                result.Append(CreateLinkButton("上一页",pagingInfo.CurrentPage-1,false,pageUrl));

            if (start != 1)
                result.Append("&nbsp...&nbsp");

            for (int i = start; i <= end; i++)
            {
                bool isCurrent = pagingInfo.CurrentPage == i;
                result.Append(CreateLinkButton(i.ToString(),i,isCurrent,pageUrl));
            }

            if (end != pagingInfo.TotalPages)
                result.Append("&nbsp...&nbsp");
            if (pagingInfo.CurrentPage != pagingInfo.TotalPages)
                result.Append(CreateLinkButton("下一页", pagingInfo.CurrentPage + 1, false, pageUrl));
            return MvcHtmlString.Create(result.ToString());
        }

        private static string CreateLinkButton(string txt, int page, bool isCurrent, Func<int, string> pageUrl)
        {
            TagBuilder liTag = new TagBuilder("li");
            TagBuilder aTag = new TagBuilder("a");
            liTag.MergeAttribute("class", "prev none");
            aTag.MergeAttribute("href", pageUrl(page));
            if (isCurrent)
                aTag.MergeAttribute("class", "current");
            aTag.InnerHtml = txt;
            liTag.InnerHtml = aTag.ToString();
            return liTag.ToString();
        }
    }
}
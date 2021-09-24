using MyMarketProject.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace MyMarketProject.Helpers
{
    public static class PagingHelpers
    {
        //public static MvcHtmlString PageLinks(this HtmlHelper html,PageInfo pageInfo, Func<int,string> PageUrl)
        //{
        //    //StringBuilder result = new StringBuilder();

        //    //TagBuilder FirstNavEl = new TagBuilder("a");
        //    //FirstNavEl.MergeAttribute("href", PageUrl(pageInfo.PageNumber - 1));
        //    //FirstNavEl.InnerHtml = "<<";
        //    //FirstNavEl.AddCssClass("btn btn-default");



        //    //if(pageInfo.PageNumber + 1 > pageInfo.TotalPages)
        //    //{

        //    //}
        //    //FirstNavEl.MergeAttribute("href", PageUrl());
        //    //FirstNavEl.InnerHtml = ">>";
        //    //FirstNavEl.AddCssClass("btn btn-default");


        //    //for(int i = 1; i <= pageInfo.TotalPages; i++)
        //    //{
        //    //    TagBuilder tag = new TagBuilder("a");
        //    //    tag.MergeAttribute("href", PageUrl(i));
        //    //    tag.InnerHtml = i.ToString();
        //    //    if(i == pageInfo.PageNumber)
        //    //    {
        //    //        tag.AddCssClass("selected");
        //    //        tag.AddCssClass("btn-primary");
        //    //    }
        //    //    tag.AddCssClass("btn btn-default");
        //    //    result.Append(tag.ToString());
        //    //}
        //    //return MvcHtmlString.Create(result.ToString());
        //}
    }
}
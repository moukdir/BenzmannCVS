using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.Mvc;
using Benzmann.Definitions;

public static class LadyExtension
{
    public static string LadyCreateTumbnail(this HtmlHelper helper, Benzmann.Definitions.Image image, string title, bool filled, string red, string green, string blue)
    {
        TagBuilder li = new TagBuilder("li");
        TagBuilder a = new TagBuilder("a");
        a.MergeAttribute("href", "/Lady/GetImage/" + image.Id.ToString() + "/1024/768");
        a.MergeAttribute("title", title);
        TagBuilder img = new TagBuilder("img");
        img.MergeAttribute("src", "/Lady/GetImage/" + image.Id.ToString() + "/160/160" + (filled ? "/1/" + red + "/" + green + "/" + blue : ""));
        img.MergeAttribute("alt", title);
        TagBuilder span = new TagBuilder("span");
        span.InnerHtml = "&nbsp;";
        a.InnerHtml = img.ToString(TagRenderMode.SelfClosing) + span.ToString(TagRenderMode.Normal);
        li.InnerHtml = a.ToString(TagRenderMode.Normal);
        // Render tag
        return li.ToString(TagRenderMode.Normal);
    }
}
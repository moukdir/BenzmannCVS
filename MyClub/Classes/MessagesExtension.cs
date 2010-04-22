using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Web.Mvc;

public static class MessagesExtension
{
    public static string Notice(this HtmlHelper helper, string msg) {
        TagBuilder div = new TagBuilder("div");
        div.AddCssClass("noticDiv");
        div.GenerateId("notice");
        TagBuilder span = new TagBuilder("span");
        span.AddCssClass("noticSpan");
        span.SetInnerText(msg);
        div.InnerHtml = span.ToString();
        // Render tag
        return div.ToString(TagRenderMode.SelfClosing);
    }
}
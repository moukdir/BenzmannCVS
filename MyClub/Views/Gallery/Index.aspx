<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Lady>>" %>
<%@ Import Namespace="Benzmann.Definitions" %>
<%@ Import Namespace="MyClub.Classes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="pageHeaderContent" runat="server">
    <%= ScriptLoader.Load(new string[] { "jquery", "lightbox" })%>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainBody" runat="server">
<%
    if(this.Model.Count == 0) {
        this.Html.Notice("Keine Frauen gefunden");
    } else {
        %>
        <ul class="thumbs">
        <%

        foreach(Lady lady in this.Model) {
            this.Html.RenderPartial("LadyThumbnail", lady);
        }
        %>
        </ul>
        <%
    }
%>
    <script type="text/javascript">
        jQuery(function() {
        $('ul a').lightBox(); // Select all links in object with gallery ID
        });
    </script>
</asp:Content>

<asp:Content ID="Footer" ContentPlaceHolderID="Footer" runat="server">
    <% Html.RenderPartial("Footer"); %>
</asp:Content>

<asp:Content ID="MenuLeft" ContentPlaceHolderID="MenuLeft" runat="server">
    <% Html.RenderPartial("MenuLeft"); %>
</asp:Content>

<asp:Content ID="MenuTop" ContentPlaceHolderID="MenuTop" runat="server">
    <% Html.RenderPartial("MenuTop"); %>
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="Header" runat="server">
    <% Html.RenderPartial("Header"); %>
</asp:Content>

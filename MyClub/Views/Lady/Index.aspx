<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lady>" %>
<%@ Import Namespace="Benzmann.Definitions" %>
<%@ Import Namespace="MyClub.Classes" %>
<asp:Content ID="LadyHeader" ContentPlaceHolderID="pageHeaderContent" runat="server">
    <%= ScriptLoader.Load(new string[] { "jquery", "lightbox" })%>
</asp:Content>

<asp:Content ID="LadyBody" ContentPlaceHolderID="MainBody" runat="server">
   <%= Html.DisplayForModel() %>
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

<asp:Content ID="Footer" ContentPlaceHolderID="Footer" runat="server">
    <% Html.RenderPartial("Footer"); %>
</asp:Content>

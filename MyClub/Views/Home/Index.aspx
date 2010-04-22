<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="LadyBody" ContentPlaceHolderID="MainBody" runat="server">
   Mein Content
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

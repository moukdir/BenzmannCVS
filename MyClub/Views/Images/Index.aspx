<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Benzmann.Definitions" %>
<asp:Content ID="MainBody" ContentPlaceHolderID="MainBody" runat="server">
    <% 
        List<Benzmann.Definitions.Image> imageList = (List<Benzmann.Definitions.Image>)this.Model;
        foreach(Benzmann.Definitions.Image image in imageList) {
            Html.RenderPartial("Image", image);
        }
    %>
</asp:Content>

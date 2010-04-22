<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Benzmann.Definitions.Lady>" %>
<%@ Import Namespace="Benzmann.Definitions" %>

<div>
    <div style="width: 400px; height: 600px; border: 1px solid black; float: left;">
        <img src="/lady/GetImage/2/500/500" alt=""/>
    </div>
    <div>
        <div>Name: <%= this.Model.Name %></div>
        <div>Description: <%= this.Model.Description %></div>
        <div>Description: <%= this.Model.BreastSize.Description %></div>
        <div>Description: <%= this.Model.Physique.Description %></div>
        <div>Description: <%= this.Model.Origin.Name %></div>
        <div>Description: <%= this.Model.Shaved %></div>
        <div>Services Count: <%= this.Model.Services.Count %></div>
    </div>
</div>


<div id="gallery">
<%
    foreach (Benzmann.Definitions.Image image in this.Model.Images)
    {
        Html.RenderPartial("LadyImage", image);
    }
%>
</div>

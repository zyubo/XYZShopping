<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<XYZShopping.Models.ProductModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditCart
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>EditCart</h2>

    <% using (Html.BeginForm("SaveCart", "Home"))
       {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                Product Name:&nbsp;<b><%: Model.Title %></b>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Pcount) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Pcount) %>
                <%: Html.ValidationMessageFor(model => model.Pcount) %>
            </div>
            
            <p>
                <%: Html.Hidden("Id", Model.Id.ToString())%>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to Cart", "ViewCart") %>
    </div>

</asp:Content>


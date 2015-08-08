<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<XYZShopping.Models.ProductModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditProduct
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>EditProduct</h2>

    <% using (Html.BeginForm("SaveProduct", "Home")) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                Product ID:&nbsp;<b><%: Model.Id %></b>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Title) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Title) %>
                <%: Html.ValidationMessageFor(model => model.Title) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Summary) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Summary) %>
                <%: Html.ValidationMessageFor(model => model.Summary) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Details) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Details) %>
                <%: Html.ValidationMessageFor(model => model.Details) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Image) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Image) %>
                <%: Html.ValidationMessageFor(model => model.Image) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Price) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Price, String.Format("{0:F}", Model.Price)) %>
                <%: Html.ValidationMessageFor(model => model.Price) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Available) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Available) %>
                <%: Html.ValidationMessageFor(model => model.Available) %>
            </div>
            
            <p>
                <%--<% using (Html.BeginForm("SaveProduct", "Home")) { %>
                        <%: Html.Hidden("Title", Model.Title.ToString())%>
                        <%: Html.Hidden("Available", Model.Available.ToString())%>
                        <%: Html.Hidden("Price", Model.Price.ToString())%>
                        <%: Html.Hidden("Image", Model.Image.ToString())%>
                        <%: Html.Hidden("Summary", Model.Summary.ToString())%>
                        <%: Html.Hidden("Details", Model.Details.ToString())%>--%>
                        <%: Html.Hidden("Id", Model.Id.ToString())%>
                        <button type="submit">Save</button>
                <%--<% } %>--%>
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to Control", "Control")%>
    </div>

</asp:Content>


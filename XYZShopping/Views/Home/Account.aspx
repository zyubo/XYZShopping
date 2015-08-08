<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<XYZShopping.Models.UserModels>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Account
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Account</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Password) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Password) %>
                <%: Html.ValidationMessageFor(model => model.Password) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.NewPassword) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NewPassword) %>
                <%: Html.ValidationMessageFor(model => model.NewPassword) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.NewPasswordRetype) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NewPasswordRetype) %>
                <%: Html.ValidationMessageFor(model => model.NewPasswordRetype) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>


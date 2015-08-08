<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<XYZShopping.Models.UserModels>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewAllUsers
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

    <h2>ViewAllUsers</h2>

    <fieldset>
        <legend>Fields</legend>

        <table style="width: 100%">
            <tr>
                <td>
                    Name</td>
                <td>
                    Email</td>
                <td>
                    Password</td>
            </tr>
        <% foreach(var user in Model.UserList) { %>
            <tr>
                <td>
                    <%: user.Username%></td>
                <td>
                    <%: user.Email%></td>
                <td>
                    <%: user.Password%></td>
            </tr>
        <% } %>
        </table>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

    </form>

</asp:Content>


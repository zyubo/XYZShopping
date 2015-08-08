<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<XYZShopping.Models.ProductModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	XYZ Shopping
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All Books</h2>

    <fieldset>
        <legend>Books</legend>
        
        <%--<div class="display-label">Id</div>--%>
        <%--rows from 0 to 4--%>
        <%--<div class="display-field"><%: Model.ProductTable.Rows[0][0]%></div>
        <div class="display-field"><%: Model.ProductTable.Rows[1][0]%></div>
        <div class="display-field"><%: Model.ProductTable.Rows[2][0]%></div>
        <div class="display-field"><%: Model.ProductTable.Rows[3][0]%></div>
        <div class="display-field"><%: Model.ProductTable.Rows[4][0]%></div>--%>
        <%--colums from 0 to 4--%>
        <%--<div class="display-field"><%: Model.ProductTable.Rows[0][0]%></div>
        <div class="display-field"><%: Model.ProductTable.Rows[0][1]%></div>
        <div class="display-field"><%: Model.ProductTable.Rows[0][2]%></div>
        <div class="display-field"><%: Model.ProductTable.Rows[0][3]%></div>
        <div class="display-field"><%: Model.ProductTable.Rows[0][4]%></div>--%>

        

        <table align="center" style="width: 100%">
        <% foreach(System.Data.DataRow dr in Model.ProductTable.Rows) { %>
                <tr>
                    <td rowspan="5">
                        <img src="<%: dr[4] %>" alt="<%: dr[1] %>" width="100" /></td>
                    <td align="left" valign="top">
                        Title:</td>
                    <td>
                        <%: dr[1] %></td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        Available:</td>
                    <td>
                        <%: dr[2] %></td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        Price:</td>
                    <td>
                        <%: dr[3] %></td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        Summary:</td>
                    <td>
                        <%: dr[5] %></td>
                </tr>
                <tr>
      <% using(Html.BeginForm("AddCart", "Home")) { %>
                    <td align="left" valign="top">
                            <%: Html.Hidden("ProductID", dr[0].ToString())%>
                            <input type="submit" value="Add to Cart" onclick="alert('Product added to cart!')" /></td>
                    <td>
                        Count:&nbsp;<%: Html.DropDownListFor(x => x.Pcount, new[] {
                                            new SelectListItem { Text = "1", Value = "1" },
                                            new SelectListItem { Text = "2", Value = "2" },
                                            new SelectListItem { Text = "3", Value = "3" },
                                            new SelectListItem { Text = "4", Value = "4" }
                                     }, "Choose an option")%>
                    </td>
                    
      <% } %>
                </tr>
        <% } %>
        </table>
    </fieldset>
    <p>
        <%--<%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>--%>
    </p>

</asp:Content>


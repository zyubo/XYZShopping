<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<XYZShopping.Models.ProductModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Check Out
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Check Out</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <table align="center" style="width: 100%">
        <% foreach(System.Data.DataRow dr in Model.ProductTable.Rows) { %>
                <tr>
                    <td rowspan="5">
                        <img src="<%: dr[2] %>" alt="<%: dr[0] %>" width="100" /></td>
                    <td align="left" valign="top">
                        Title:</td>
                    <td>
                        <%: dr[0] %></td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        Count:</td>
                    <td>
                        <%: dr[4] %></td>
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
                        <%: dr[1] %></td>
                </tr>
                <tr>
                    <td align="left" valign="top">
                        <% using (Html.BeginForm("DeleteCart", "Home")) { %>
                        <%: Html.Hidden("ProductID", dr[5].ToString())%>
                        <button type="submit">Delete</button>
                        <% } %>
                    </td>
                    <td>
                        <% using (Html.BeginForm("EditCart", "Home")) { %>
                        <%: Html.Hidden("ProductID", dr[5].ToString())%>
                        <button type="submit">Edit</button>
                    <% } %>
                    </td>
                </tr>
        <% } %>
        <tr>
            <td>Total Cost:&nbsp;<b>$<%: XYZShopping.Models.Patterns.SessionFacade.TOTAL.ToString()%></b>&nbsp;&nbsp;<button type="button" onclick="location.href='CheckOutPayment'">Proceed to Payment</button></td>
        </tr>
        </table>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Back to Home", "Index") %>
    </p>

</asp:Content>
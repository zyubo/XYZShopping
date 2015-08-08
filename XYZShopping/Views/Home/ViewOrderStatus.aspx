<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<XYZShopping.Models.OrderModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewOrderStatus
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ViewOrderStatus</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <%--<div class="display-label">Email</div>
        <div class="display-field"><%: Model.Email %></div>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">Pcount</div>
        <div class="display-field"><%: Model.Pcount %></div>
        
        <div class="display-label">Orderid</div>
        <div class="display-field"><%: Model.Orderid %></div>
        
        <div class="display-label">Address</div>
        <div class="display-field"><%: Model.Address %></div>
        
        <div class="display-label">Delivered</div>
        <div class="display-field"><%: Model.Delivered %></div>
        
        <div class="display-label">Cardnum</div>
        <div class="display-field"><%: Model.Cardnum %></div>
        
        <div class="display-label">Arrive</div>
        <div class="display-field"><%: Model.Arrive %></div>
        
        <div class="display-label">Total</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Total) %></div>--%>
        
        <table style="width: 100%">
            <tr>
                <td>
                    Product ID</td>
                <td>
                    Counts</td>
                <td style="width: 136px">
                    Order ID</td>
                <td>
                    Address</td>
                <td>
                    Delivered</td>
                <td>
                    Card Number</td>
                <td>
                    Arrive In</td>
                <td>
                    Total Price</td>
            </tr>
            
        <% foreach(System.Data.DataRow dr in Model.OrderTable.Rows) { %>

            <tr>
                <td>
                    <%: dr[0] %></td>
                <td>
                    <%: dr[1] %></td>
                <td>
                    <%: dr[2] %></td>
                <td>
                    <%: dr[3] %></td>
                <td>
                    <%: dr[4] %></td>
                <td>
                    <%: dr[5] %></td>
                <td>
                    <%: dr[6] %></td>
                <td>
                    <%: dr[7] %></td>
            </tr>
            
        <% } %>

        </table>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Continue Shopping", "Index") %>
    </p>

</asp:Content>


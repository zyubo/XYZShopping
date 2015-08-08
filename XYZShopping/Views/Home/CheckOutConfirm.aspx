<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<XYZShopping.Models.OrderModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Check Out Confirm
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Check Out Confirm</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label"><b>UserName</b></div>
        <div class="display-field"><%: XYZShopping.Models.Patterns.SessionFacade.USERNAME %></div>
        
        <div class="display-label"><b>Email</b></div>
        <div class="display-field"><%: Model.Email %></div>
        
        <div class="display-label"><b>Orderid</b></div>
        <div class="display-field"><%: Model.Orderid %></div>
        
        <div class="display-label"><b>Address</b></div>
        <div class="display-field"><%: Model.Address %></div>
        
        <div class="display-label"><b>Cardnum</b></div>
        <div class="display-field"><%: Model.Cardnum %></div>
        
        <div class="display-label"><b>Arrive</b></div>
        <div class="display-field"><%: Model.Arrive %></div>
        
        <div class="display-label"><b>Total</b></div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Total) %></div>
            
            <p>
                <% using(Html.BeginForm()) { %>
                    <input type="submit" value="Confirm Order" />&nbsp;&nbsp;<button type="button" onclick="location.href='CheckOutPayment'">Back to Modify</button>
                <% } %>
            </p>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>


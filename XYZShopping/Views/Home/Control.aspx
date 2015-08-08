<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<XYZShopping.Models.ProductModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Control
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Control</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <%--<table>
            <thead>
                <tr>
                    <td>Id</td>
                    <td>Title</td>
                    <td>Action</td>
                </tr>
            </thead>
        <% foreach(System.Data.DataRow dr in Model.ProductTable.Rows) { %>
            <tr>
                <td><%: dr[0] %></td>
                <td><%: dr[1] %></td>
                <td>
                    <% using(Html.BeginForm("DeleteItem", "Home")) { %>
                    <%: Html.Hidden("item", dr[0]) %>
                    <input type="submit" value="Delete" />
                    <% } %>
                </td>
            </tr>
        <% } %>
        </table>--%>

        <%--<table style="float: left">
        <% foreach(System.Data.DataRow dr in Model.ProductTable.Rows) { %>
                <tr>
                    <td rowspan="5">
                        <img src="<%: dr[4] %>" alt="<%: dr[1] %>" width="200" /></td>
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
                    <td align="left" valign="top">
                        <% using(Html.BeginForm("AddCart", "Home")) { %>
                        <%: Html.Hidden("item", dr[0]) %>
                    <input type="submit" value="Add to Cart" onclick="alert('Product added to cart!')" /></td>
                    <% } %>
                    <td>
                        &nbsp;</td>
                </tr>
        <% } %>
        </table>--%>

        <%--<div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">Details</div>
        <div class="display-field"><%: Model.Details %></div>
        
        <div class="display-label">Title</div>
        <div class="display-field"><%: Model.Title %></div>
        
        <div class="display-label">Summary</div>
        <div class="display-field"><%: Model.Summary %></div>
        
        <div class="display-label">Image</div>
        <div class="display-field"><%: Model.Image %></div>
        
        <div class="display-label">Price</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Price) %></div>
        
        <div class="display-label">Available</div>
        <div class="display-field"><%: Model.Available %></div>
        
        <div class="display-label">Pcount</div>
        <div class="display-field"><%: Model.Pcount %></div>
        
        <div class="display-label">Total</div>
        <div class="display-field"><%: String.Format("{0:F}", Model.Total) %></div>--%>
        
        <table align="center" style="width: 100%">
            <tr>
                <td>
                    Id</td>
                <td>
                    Title</td>
                <td>
                    Available</td>
                <td>
                    Price</td>
                <td>
                    Summary</td>
                <td>
                    Action</td>
                <td>
                    Action</td>
            </tr>
            
        <% foreach(System.Data.DataRow dr in Model.ProductTable.Rows) { %>

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
                    <%: dr[5] %></td>
                <td>
                    <% using (Html.BeginForm("DeleteProduct", "Home")) { %>
                        <%: Html.Hidden("ProductID", dr[0].ToString())%>
                        <button type="submit">Delete</button>
                    <% } %>
                </td>
                <td>
                    <% using (Html.BeginForm("EditProduct", "Home")) { %>
                        <%: Html.Hidden("ProductID", dr[0].ToString())%>
                        <button type="submit">Edit</button>
                    <% } %>
                </td>
            </tr>

            
        <% } %>

        </table>
        <br />
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Add", "AddProduct", "Home")%> |
        <%: Html.ActionLink("Back to List", "Index") %> |
        <%: Html.ActionLink("View all users", "ViewAllUsers")%>
    </p>

</asp:Content>


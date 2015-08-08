<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        欢迎您，<b><%: Page.User.Identity.Name %></b>!
        [ <%: Html.ActionLink("注销", "LogOut", "Home")%> ]
        &nbsp;
        [ <%: Html.ActionLink("更改密码", "Account", "Home")%> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("登录", "LogIn", "Home")%> ]
        &nbsp;
        [ <%: Html.ActionLink("注册", "Register", "Home")%> ]
<%
    }
%>

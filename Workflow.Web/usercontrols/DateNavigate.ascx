<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateNavigate.ascx.cs" Inherits="userControl_WebUserControl" %>
<input id="hidDateType" type="hidden" runat="server" value="999"/><%--控制选中a的颜色变化--%>
<input id="action" name="action" type="hidden" value="F"/><%--控制是否提交的Div:action=T 提交的是左边否则为右边Div--%>
<div class="divDateQueryNav" style="margin-top:10px;">
    <div style="float:left">
     <%foreach (Workflow.Da.Domain.Order.DateOptionCard doc in model.DateList)
       {
           if ("No" != doc.IndirectKey)
           {%>
           <a href="#" class="aCurrent" onclick="getByDate(<%=doc.Key %>)"><%=doc.Text%></a>
           <%}
             else
             { %>
           <a  style="width:100px; background-image:url(/images/zh_bg_04.jpg)"><%=doc.Text%></a>
       <%}
     }%>  
    </div>
    <div style="float:right;">
    <% if (CurrentDate == 0)
       {%><a href="#" class="aCurrent" style="color:red" onclick="getOrderByDate(0)">今日</a>
    <%}else{ %><a href="#" onclick="getOrderByDate(0)">今日</a>
    <%} %>

    <% if (CurrentDate == -1){ %><a href="#" class="aCurrent" style="color:red" onclick="getOrderByDate(-1)">昨日</a>
    <%}else{ %><a href="#" onclick="getOrderByDate(-1)">昨日</a>
    <%} %>

    <% if (CurrentDate == -2){ %><a href="#" class="aCurrent" style="color:red" onclick="getOrderByDate(-2)">前日</a>
    <%}else{ %><a href="#" onclick="getOrderByDate(-2)">前日</a>
    <%} %>

    <% if (CurrentDate == -7){ %><a href="#" class="aCurrent" style="color:red" onclick="getOrderByDate(-7)">近七日</a>
    <%}else{ %><a href="#" onclick="getOrderByDate(-7)">近七日</a>
    <%} %>

    <% if (CurrentDate == -14){ %><a href="#" class="aCurrent" style="color:red" onclick="getOrderByDate(-14)">近两周</a>
    <%}else{ %><a href="#" onclick="getOrderByDate(-14)">近两周</a>
    <%} %>

    <% if (CurrentDate == -30){ %><a href="#" class="aCurrent" style="color:red" onclick="getOrderByDate(-30)">本月</a>
    <%}else{ %><a href="#" onclick="getOrderByDate(-30)">本月</a>
    <%} %>
    </div>
</div>
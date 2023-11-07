<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExceptionPriceOrderView.aspx.cs"
    Inherits="ExceptionPriceOrderView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>异常价格加工单汇总</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../../css/thickbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/Calendar2.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <script type="text/javascript">
	function showOrderDetail(){
			showPage('../../order/OrderDetail.html',null,700,800,false,false);
	}
    </script>

</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12">
                        <img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0"/></td>
                    <td width="99%" bgcolor="#FFFFFF">
                        <img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                    <td width="12">
                        <img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"/></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页 -> 财务处理 -&gt; 财务查询 -&gt; 异常价格加工单汇总</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    异常价格加工单汇总</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center">
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            客户名称:</td>
                                                        <td class="item_content">
                                                            <input name="CustomerName" type="text" class="texts" value="<%=FindFinanceAction.Model.CustomerName %>" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            抹零:</td>
                                                        <td class="item_content">
                                                            <select name="SltZero">
                                                                <%
                                                                    for (int i = 0; i < FindFinanceAction.Model.OperatorList.Count; i++)
                                                                    { 
                                                                        if (FindFinanceAction.Model.OperatorList[i].Value == FindFinanceAction.Model.Operator1)
                                                                        {
                                                                        %>
                                                                        <option value="<%=FindFinanceAction.Model.OperatorList[i].Value %>" selected="selected">
                                                                            <%=FindFinanceAction.Model.OperatorList[i].Label%>
                                                                        </option>
                                                                        <%}
                                                                        else
                                                                        { %>
                                                                            <option value="<%=FindFinanceAction.Model.OperatorList[i].Value %>">
                                                                                <%=FindFinanceAction.Model.OperatorList[i].Label%>
                                                                            </option>
                                                                        <%}                                                                    
                                                                    }
                                                                %>
                                                            </select>
                                                            <input name="Zero" id="txtZero" type="text" class="num" value="<%=FindFinanceAction.Model.Amount1 %>" size="10" />
                                                            元</td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            优惠:</td>
                                                        <td class="item_content">
                                                            <select name="SltConcession">
                                                                <%
                                                                    for (int i = 0; i < FindFinanceAction.Model.OperatorList.Count; i++)
                                                                    { 
                                                                        if (FindFinanceAction.Model.OperatorList[i].Value == FindFinanceAction.Model.Operator2)
                                                                        {
                                                                        %>
                                                                        <option value="<%=FindFinanceAction.Model.OperatorList[i].Value %>" selected="selected">
                                                                            <%=FindFinanceAction.Model.OperatorList[i].Label%>
                                                                        </option>
                                                                        <%}
                                                                        else
                                                                        { %>
                                                                            <option value="<%=FindFinanceAction.Model.OperatorList[i].Value %>">
                                                                                <%=FindFinanceAction.Model.OperatorList[i].Label%>
                                                                            </option>
                                                                        <%}                                                                    
                                                                    }
                                                                %>
                                                            </select>
                                                            <input name="Concession" id="txtConcession" type="text" class="num" value="<%=FindFinanceAction.Model.Amount2 %>" size="10" />
                                                            元</td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            折让:</td>
                                                        <td class="item_content">
                                                            <select name="sltGiveAway">
                                                                <%
                                                                    for (int i = 0; i < FindFinanceAction.Model.OperatorList.Count; i++)
                                                                    { 
                                                                        if (FindFinanceAction.Model.OperatorList[i].Value == FindFinanceAction.Model.Operator3)
                                                                        {
                                                                        %>
                                                                        <option value="<%=FindFinanceAction.Model.OperatorList[i].Value %>" selected="selected">
                                                                            <%=FindFinanceAction.Model.OperatorList[i].Label%>
                                                                        </option>
                                                                        <%}
                                                                        else
                                                                        { %>
                                                                            <option value="<%=FindFinanceAction.Model.OperatorList[i].Value %>">
                                                                                <%=FindFinanceAction.Model.OperatorList[i].Label%>
                                                                            </option>
                                                                        <%}                                                                    
                                                                    }
                                                                %>
                                                            </select>
                                                            <input name="GiveAway" id="txtGiveAway" type="text" class="num" value="<%=FindFinanceAction.Model.Amount3 %>" size="10" />
                                                            元</td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            时间段:</td>
                                                        <td class="item_content">
                                                            <div>
                                                                <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts" value="<%=FindFinanceAction.Model.BalanceDateTimeString %> "  onfocus="setday(this);" readonly="readonly"/>
                                                              
                                                                <input id="txtTo" type="text" name="EndDateTime" class="datetexts" value="<%=FindFinanceAction.Model.InsertDateTimeString %>"  onfocus="setday(this);" readonly="readonly"/>
                                                               
                                                       </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="right" style="padding-right: 10px"><asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="return checkData();" Text="查询" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="left">
                                    <table width="100%" border="1" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <th width="1%" nowrap>
                                                &nbsp;NO&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;工单号&nbsp;&nbsp;</th>
                                            <th width="30%" nowrap>
                                                &nbsp;&nbsp;&nbsp;客户名称&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;总额&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                抹零</th>
                                            <th width="1%" nowrap>
                                                优惠</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;&nbsp;折让&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp应收&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;实收&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;手银&nbsp;&nbsp;</th>
                                            <th nowrap align="center">
                                                备注</th>
                                        </tr>
                                        <%
                                            for (int i = 0; i < model.OrderList.Count; i++)
                                            { %>
                                                <tr class="detailRow">
                                                    <td align="center"><%=i+1 %></td>
                                                    <td align="center"><a href="#" onclick="orderDetail(this);"><%=model.OrderList[i].No %></a><input type="hidden" name="myOrderNo"  value="<%=model.OrderList[i].No %>" /></td>
                                                    <td align="left"><%=model.OrderList[i].CustomerName %></td>
                                                    <td class="num"><%=model.OrderList[i].SumAmount %></td>
                                                    <td class="num" nowrap><%=model.OrderList[i].Zero %></td>
                                                    <td class="num"><%=model.OrderList[i].Concession %></td>
                                                    <td class="num" nowrap><%=model.OrderList[i].GiveAway %></td>
                                                    <td class="num"><%=model.OrderList[i].RealPaidAmount %></td>
                                                    <td class="num"><%=model.OrderList[i].PaidAmount %></td>
                                                    <td align="center"><%=model.OrderList[i].Name %></td>
                                                    <td align="left"><%=model.OrderList[i].Memo %></td>
                                                </tr>
                                            <%}
                                        %>
                                    </table>
                                </td>
                                <td width="3%">
                                    &nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr height="5">
                                <td>
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                                <td bgcolor="#eeeeee">
                                    &nbsp;</td>
                                <td>
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="12">
                        <img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="21"/></td>
                    <td bgcolor="#FFFFFF">
                        <img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                    <td width="12">
                        <img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="21"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function checkData()
    {
        if($("#txtZero").val()!="")
        {
            if(!checkOnlyNum($("#txtZero"),true,14))
            {
                alert("您输入的金额有误!!!");
                $("#txtZero").select();
                $("#txtZero").focus();
                return false;
            }
        }
        if($("#txtConcession").val()!="")
        {
            if(!checkOnlyNum($("#txtConcession"),true,14))
            {
                alert("您输入的天数有误!!!");
                $("#txtConcession").select();
                $("#txtConcession").focus();
                return false;
            }
        }
        if($("#txtGiveAway").val()!="")
        {
            if(!checkOnlyNum($("#txtGiveAway"),true,14))
            {
                alert("您输入的天数有误!!!");
                $("#txtGiveAway").select();
                $("#txtGiveAway").focus();
                return false;
            }
        }
        return true;
    }
    function orderDetail(o)
    {
        var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
        showPage('../../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true);
    }
    
</script>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchNewAndOldCustomer.aspx.cs"
    Inherits="SearchNewAndOldCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>新老客户消费统计</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../../js/Calendar2.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <script type="text/javascript">
	function showOldCustomer(){
		showPage('OldCustomer.html',null,700,258,false,false);
	}
	function showNewCustomer(){
		showPage('NewCustomer.html',null,700,258,false,false);
	}
	$(document).ready(function() {
		$("a[@title=老客户]").attr("href", "javascript:showOldCustomer();");
		$("a[@title=新客户]").attr("href", "javascript:showNewCustomer();");
	});	
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
                                    首页 -> 财务处理 -> 财务查询 -> 新老客户消费统计</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    新老客户消费统计</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="left">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap class="item_caption">
                                                消费金额:</td>
                                            <td class="item_content">
                                                <select name="sltSumAmount">
                                                    <%
                                                        for (int i = 0; i < model.OperatorList.Count; i++)
                                                        { 
                                                            if (model.OperatorList[i].Value == model.Operator1)
                                                            {
                                                            %>
                                                            <option value="<%=model.OperatorList[i].Value %>" selected="selected">
                                                                <%=model.OperatorList[i].Label%>
                                                            </option>
                                                            <%}
                                                            else
                                                            { %>
                                                                <option value="<%=model.OperatorList[i].Value %>">
                                                                    <%=model.OperatorList[i].Label%>
                                                                </option>
                                                            <%} 
                                                        }
                                                    %>
                                                </select>
                                                <input name="SumAmount" id="txtSumAmount" class="num" type="text" size="10" value="<%=model.Amount1 %>" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                制作数量:</td>
                                            <td class="item_content">
                                                <select name="sltPaperCount">
                                                    <%
                                                        for (int i = 0; i < model.OperatorList.Count; i++)
                                                        { 
                                                            if (model.OperatorList[i].Value == model.Operator2)
                                                            {
                                                            %>
                                                            <option value="<%=model.OperatorList[i].Value %>" selected="selected">
                                                                <%=model.OperatorList[i].Label%>
                                                            </option>
                                                            <%}
                                                            else
                                                            { %>
                                                                <option value="<%=model.OperatorList[i].Value %>">
                                                                    <%=model.OperatorList[i].Label%>
                                                                </option>
                                                            <%} 
                                                        }
                                                    %>
                                                </select>
                                                <input type="text" name="PaperCount" id="txtPaperCount" class="num" size="10" value="<%=model.Amount2%>" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                时间段:</td>
                                            <td class="item_content">
                                                <div>
                                                    <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts" value="<%=model.BalanceDateTimeString%>" onfocus="setday(this);" readonly="readonly"/>&nbsp;至&nbsp;
                                                    <input id="txtTo" type="text" name="EndDateTime" class="datetexts" value="<%=model.InsertDateTimeString%>" onfocus="setday(this);" readonly="readonly"/>
                                                <div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right" style="padding-right: 10px">
                                                <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="return checkData();"
                                                    Text="查询" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="1%" nowrap>
                                                &nbsp;NO&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;属性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;工单数&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;打印量&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;金额&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th nowrap>
                                                备注</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                        </tr>
                                        <% decimal orderCountNew = 0, orderCountOld = 0;
                                           decimal paperCountNew = 0, paperCountOld = 0;
                                           decimal sumAmountNew = 0, sumAmountOld = 0;
                                           string memoNew = "", memoOld = "";
                                           for (int i = 0; i < model.OrderList.Count; i++)
                                           {
                                               if (model.OrderList[i].OrderCount == 1)
                                               {
                                                   orderCountNew += model.OrderList[i].OrderCount;
                                                   paperCountNew += model.OrderList[i].PaperCount;
                                                   sumAmountNew += model.OrderList[i].SumAmount;
                                                   memoNew = model.OrderList[i].Memo;
                                               }
                                               else
                                               {
                                                   orderCountOld += model.OrderList[i].OrderCount;
                                                   paperCountOld += model.OrderList[i].PaperCount;
                                                   sumAmountOld += model.OrderList[i].SumAmount;
                                                   memoOld = model.OrderList[i].Memo;
                                               }
                                           }
                                        %>
                                        <tr class="detailRow">
                                            <td align="center">
                                                1</td>
                                            <td align="center">
                                                新客户</td>
                                            <td class="num">
                                                <%=orderCountNew %>
                                            </td>
                                            <td class="num">
                                                <%=paperCountNew %>
                                            </td>
                                            <td class="num">
                                                <%=sumAmountNew %>
                                            </td>
                                            <td align="left">
                                                <%=memoNew %>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr class="detailRow">
                                            <td align="center">
                                                2</td>
                                            <td align="center">
                                                老客户</td>
                                            <td class="num">
                                                <%=orderCountOld %>
                                            </td>
                                            <td class="num">
                                                <%=paperCountOld %>
                                            </td>
                                            <td class="num">
                                                <%=sumAmountOld %>
                                            </td>
                                            <td align="left">
                                                <%=memoOld %>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
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
                        <img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="11"/></td>
                    <td bgcolor="#FFFFFF">
                        <img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                    <td width="12">
                        <img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="11"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<script type="text/javascript">
    function checkData()
    {
        if($("#txtSumAmount").val()!="")
        {
            if(!checkOnlyNum($("#txtSumAmount"),true,14))
            {
                alert("您输入的金额有误!!!");
                $("#txtSumAmount").select();
                $("#txtSumAmount").focus();
                return false;
            }
        }
        if($("#txtPaperCount").val()!="")
        {
            if(!checkOnlyNum($("#txtPaperCount"),true,14))
            {
                alert("您输入的天数有误!!!");
                $("#txtPaperCount").select();
                $("#txtPaperCount").focus();
                return false;
            }
        }
        return true;
    }
</script>


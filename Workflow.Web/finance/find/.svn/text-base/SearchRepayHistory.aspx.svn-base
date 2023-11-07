<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchRepayHistory.aspx.cs"  Inherits="SearchRepayHistory" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>客户对帐表</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../../css/thickbox.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../../js/jquery.js"></script>

    <script type="text/javascript" src="../../js/default.js"></script>

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
                                    首页 -> 财务处理 -> 财务查询 -> 客户对帐表</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    客户对帐表</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="left">
                                    <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td nowrap class="item_caption">
                                                会员卡号:</td>
                                            <td class="item_content" colspan="2">
                                                <input class="texts" type="text" name="MemberCardNo" value="<%=model.MemberCardNo %>" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                客户名称:</td>
                                            <td class="item_content">
                                                <input type="text" id="txtCustomerName" name="CustomerName" value="<%=model.CustomerName%>" class="texts" />
                                                <input type="button" class="buttons selectButtons" value="选择客户" onclick="showSelectCustomer();" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right" >
                                                <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="" Text="查询" />
                                                <asp:Button ID="btnDispatchPrint" CssClass="buttons" runat="server" Text="打印" OnClick="btnDispatchPrint_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
								 <td width="3%">
                                    &nbsp;</td>
                                <td align="left">
                                <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0" bgcolor="#F0F0F0">
                                        <tr>
                                            <td width="100%" align="center" bgcolor="#FFFFFF">
                                                <table width="100%" border="1" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td nowrap class="item_caption">
                                                            客户名称:</td>                                                        
                                                        <td colspan="5" class="item_content" bgcolor="#F8F8F8">
                                                        <%if(model.Customer!=null){ %>
                                                            <%=model.Customer.Name %>
                                                         <%} %>
                                                        </td>
                                                        <td colspan="5" class="item_content" bgcolor="#F8F8F8">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption">
                                                            地址:</td>
                                                        
                                                        <td colspan="3" class="item_content" bgcolor="#F8F8F8">
                                                        <%if(model.Customer!=null){ %>
															<%=model.Customer.Address %>
                                                        <%} %>
                                                        </td>
                                                        <td colspan="3" class="item_content" bgcolor="#F8F8F8">
                                                        </td>
                                                        <td nowrap class="item_caption">
                                                            电话:</td>
                                                        <td class="item_content" bgcolor="#F8F8F8">
                                                           <%if(model.Customer!=null){ %>
															<%=model.Customer.LastTelNo %>
                                                           <%} %>
                                                        </td>
                                                        
                                                        <td class="item_content" bgcolor="#F8F8F8">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
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
                                            <th width="3%" nowrap>NO</th>
                                            <th width="10%" nowrap>订单号</th>
                                            <th width="15%" nowrap>时间</th>
                                            <th width="8%" nowrap>总金额</th>
                                            <th width="8%" nowrap>实收金额</th>
                                            <th width="8%" nowrap>抹零</th>
                                            <th width="8%" nowrap>优惠</th>
                                            <th width="8%" nowrap>折让</th>
                                            <th width="8%" nowrap>舍入少收</th>
                                            <th width="8%" nowrap>舍入多收</th>
                                            <th width="8%" nowrap>还欠</th>
                                        </tr>
                                        <%  int i = 1;
                                        	foreach(Workflow.Da.Domain.Order val in model.OrderList){ %>
                                        <tr>
											<td><%=i %></td>
											<td><%=val.No %></td>
											<td><%=val.InsertDateTime %></td>
											<td><%=val.SumAmount %></td>
											<td><%=val.PaidAmount %></td>
											<td><%=val.ZeroAmount %></td>
											<td><%=val.ConcessionAmount %></td>
											<td><%=val.RenderupAmount%></td>
											<td><%=val.NegtiveAmount%></td>
											<td><%=val.PositiveAmount%></td>
											<td><%=val.SumAmount - val.PaidAmount - val.ZeroAmount - val.ConcessionAmount - val.RenderupAmount - val.NegtiveAmount + val.PositiveAmount%></td>
                                        </tr>
                                        <% i++;
											} %>
										<%if (model.Order != null)	{ %>
										<tr>
											<td>总计</td>
											<td></td>
											<td></td>
											<td><%=model.Order.SumAmount %></td>
											<td><%=model.Order.PaidAmount %></td>
											<td><%=model.Order.ZeroAmount %></td>
											<td><%=model.Order.ConcessionAmount %></td>
											<td><%=model.Order.RenderupAmount %></td>
											<td><%=model.Order.NegtiveAmount %></td>
											<td><%=model.Order.PositiveAmount %></td>
											<td><%=model.Order.SumAmount-model.Order.PaidAmount-model.Order.ZeroAmount-model.Order.ConcessionAmount-model.Order.RenderupAmount-model.Order.NegtiveAmount+model.Order.PositiveAmount%></td>
										</tr>
										<%} %>
										<tr>
                                         <td bgcolor="#eeeeee" align="right" colspan="11">
                                               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                                </webdiyer:AspNetPager>
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
function selectCustomer(objCustomer)
{
    if(objCustomer==null) return;
    $("#customerid").attr("value",objCustomer.Id);
    $("#txtMemberCardId").attr("value",objCustomer.MemeberCardId);
    $("#txtMemberCardNo").attr("value",objCustomer.MemberCardNo);
    $("#txtTradeId").attr("value",objCustomer.TradeId);
    $("#txtCustomerName").attr("value",objCustomer.Name);
    $("#txtName").attr("value",objCustomer.LinkMan);
    $("#telNo").attr("value",objCustomer.TelNo);
    $("#txtMemo").attr("value",objCustomer.Memo);
}
function showSelectCustomer(){
    var customerName=$("#txtCustomerName").val();
	showPage('../../customer/SelectCustomer.aspx?customerName='+escape(customerName),null,890,566,false,false);
}

function orderDetail(o)
{
    var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
    showPage('../../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true);
}
</script>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DailyOrder.aspx.cs" Inherits="OrderDailyOrder"%>

<%@ Register Src="~/order/UserControls/OrderItem.ascx" TagName="OrderItem" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>订单一览</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Calendar2.js"></script>
    <script type="text/javascript" src="../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/check.js"></script>
    <script type="text/javascript" src="../js/math.js"></script>
    <script type="text/javascript" src="../js/order/order.js"></script>
    <script type="text/javascript" src="../js/keydown.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
    <script type="text/javascript">
        var self='<%=Workflow.Support.Constants.DELIVERY_TYPE_SELF_GET_VALUE %>';
        var wait='<%=Workflow.Support.Constants.DELIVERY_TYPE_WAITFOR_GET_VALUE %>';
        var delivery='<%=Workflow.Support.Constants.DELIVERY_TYPE_DELIVERY_VALUE %>';
        var position=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.PositionId %>;
        var master=<%=Workflow.Support.Constants.POSITION_SHOP_MASTER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
        var manager=<%=Workflow.Support.Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
        var accreditTypeKey='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_UPDATE_PRICE_KEY %>';
        var accreditTypeText='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_UPDATE_PRICE_TEXT %>';
        var accreditTypeId=<%=Workflow.Support.Constants.GET_USER_OPERATE_ACCREDIT_UPDATE_PRICE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;//修改价格授权Id

        //直接分配订单
        var dispatchOrderNo='<%=dispatchOrderNo %>';
        var dispatchCustomerName='<%=dispatchCustomerName %>';
        var isPrint='<%=isPrint %>'
    </script>
</head>
<body style="text-align: center" >
    <form  action="" id="orderFrom" runat="server" method="post">
    <input type="hidden" id="HiddAction" name="action" value=""/>
    <input type="hidden" id="receptionEmployeeId" name="receptionEmployeeId" value="0"/>
        <div align="center" style="width: 100%;" bgcolor="#ffffff" id="container">
            <table id="tbOuter" width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td style="width: 11px"><img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0"/></td>
                  <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10"/></td>  
                  <td width="12"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table  border="0" cellspacing="0" cellpadding="0" style=" width:100%;" >
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 订单管理 -&gt; 本日订单</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">加工单</td>
                            </tr>
                            <tr>
                                <td style="width: 3%">&nbsp;</td>
                                <td align="center">
                                    <table name="tbTest" border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">会员卡号:</td>
                                            <td colspan="5" class="item_content">
                                                <input name="MemberCardNo" type="text" class="texts" value="" id="txtMemberCardNo" onchange="return getCustomerInfo(event,this);"/>
                                                <input type="button" id="Accredit" disabled="true" value="手动输入会员卡号" onclick="accredit();"/>
                                                <input type="hidden" name="MemberCardId" id="txtMemberCardId" />
                                                <input type="hidden" name="TradeId" id="txtTradeId" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption" style="height: 26px">客户名称<font color="#FF0000">*</font>:</td>
                                            <td colspan="5" class="item_content" style="height: 26px">
                                                <input type="text" class="texts" value="" size="50" id="txtCustomerName" name="CustomerName" onchange="return CheckCustomer();"/>
                                                <input type="hidden" name="txtCustomerId" id="customerid" />
                                                <input name="Input" type="button" class="buttons selectButtons" value="选择客户" id="btnSelectCustomer" onclick="" />
                                                <input type="button" name="Submit" class="buttons selectButtons" value="新增客户" id="btnNewCustomer" />
                                            </td>
                                        </tr>
                                        <tr id="tr1">
                                            <td colspan="6" style="text-align: left">
                                                <a id="aOrderDetail" href="#" onclick="showOrderDetail();">详细信息>>></a>
                                            </td>
                                        </tr>
                                        <tr id="tr2">
                                            <td colspan="6">
                                                <table id="orderDetail" style="width: 100%; height: 100%">
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">客户类型<font color="#FF0000"></font>:</td>
                                                        <td class="item_content"><select name="sltCustomerType" id="cbCustomerType" runat="server"></select></td>
                                                        <td nowrap="nowrap" class="item_caption">真实姓名<font color="#FF0000"></font>:</td>
                                                        <td class="item_content"><input name="RealName" type="text" class="texts" value="" id="txtName" maxlength="50"/></td>
                                                        <td nowrap="nowrap" class="item_caption">联系电话:</td>
                                                        <td class="item_content"><input name="RealTelNo" type="text" class="tel" value="" id="telNo" maxlength="20"/></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">项目名称:</td>
                                                        <td class="item_content"><input name="ItemName" type="text" class="texts" value="" maxlength="50" id="txtItemName" /></td>
                                                        <td nowrap="nowrap" class="item_caption">支付方式:</td>
                                                        <td class="item_content"><select name="sltPayType" id="cbPaymentType" runat="server" disabled="true"></select></td>
                                                        <td nowrap="nowrap" class="item_caption" style="display:none;">预收款:</td>
                                                        <td class="item_content" style="display:none;"><input name="NeedPrepareMoney" class="checks" id="ckNeedPrepareMoney" onclick="prePay();" type="checkbox" runat="server" />&nbsp;
                                                            <label for="ckNeedPrepareMoney">需要</label>
                                                            &nbsp;
                                                            <input name="PrepayMoney" style="text-align:right;" type="text" class="texts" size="9" maxlength="14" id="txtPrepayMoney" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" style="display:none;" class="item_caption">发票:</td>
                                                        <td class="item_content" style="display:none;">
                                                            <input name="needTicket" type="checkbox" class="checks" id="ckNeedTicket" runat="server" />&nbsp;
                                                            <label for="ckNeedTicket">需要</label></td>
                                                        <td nowrap="nowrap" class="item_caption">送取货方式:</td>
                                                        <td class="item_content">
                                                            <select name="DeliveryType" id="cbDeliveryType" runat="server"　onchange="deliveryDateTime();"></select>
                                                        </td>
                                                        <td nowrap="nowrap" class="item_caption">送取货时间:</td>
                                                        <td class="item_content">
                                                            <div>
                                                                <input id="txtDeliveryDateTime" name="txtDeliveryDateTime" onfocus="setTime(this,this,true,true);" type="text" class="datetimetexts" size="20" maxlength="16"/>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">备注:</td>
                                                        <td nowrap="nowrap" colspan="5" align="left"><textarea name="Memo" class="textarea" cols="90" rows="3" id="txtMemo"></textarea></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 3%"> &nbsp;</td>
                            </tr>
                            <tr id="tr3">
                                <td style="width: 3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%">
                                        <tr>
                                            <td width="25%" align="left"><input type="button" onclick="addRow();" class="buttons" style="display:none;" value="新增业务明细" id="btnNewOrderItem1" /></td>
                                            <td width="50%" align="center">&nbsp;&nbsp;&nbsp;
                                                <%--<asp:Button Text="保存&amp;打印" CssClass="buttons" ID="btnDispatchAndPrint1" OnClientClick="return orderDataCheck(); " OnClick="btnDispatchAndPrint1_ServerClick" runat="server" />--%>
                                            </td>
                                            <td width="25%" style=" color:Red;">如果是不规则尺寸,请先换算为平方米
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 3%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 3%">&nbsp;</td>
                                <td align="center"><uc:OrderItem ID="tbOrderItem" runat="server" /></td>
                                <td style="width: 3%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%">
                                        <tr>
                                            <td width="25%" align="left"><input type="button" style="display:none;" onclick="addRow();" class="buttons" value="新增业务明细" id="btnNewOrderItem2" /></td>
                                            <td width="75%" colspan="2" align="right">
                                            <input id="btnPrintOrder" type="button" class="buttons" onclick="return orderDataCheck(this);" value="开单"/>
                                            <input id="btnDispatchOrder" type="button" class="buttons" onclick="return orderDataCheck(this);" value="分配订单"/>
                                            <input id="btnWaitDispatchOrder" type="button" class="buttons" onclick="return orderDataCheck(this);" value="待分配订单"/>
                                            <input type="hidden" id="isSubmit" runat="server"/>
                                            <input type="hidden" id="TagReq" value="0" runat="server"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 3%">&nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3" class="caption">本日订单</td>
                            </tr>
                            <tr>
                                <td style="width: 3%">&nbsp;</td>
                                <td align="left" style="overflow:hidden;">
                                  <iframe id="mfram" name="mframe" style="width: 100%; height: 650px;" frameborder="0" scrolling="no" src="TodayOrder.aspx"></iframe>
                                </td>
                                <td style="width: 3%">&nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"><input type="hidden" id="txtRowNo" name="RowNo" /></td>
                            </tr>
                            <tr style="height: 5px">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td style="width: 3%"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                   </td>
                </tr>
                <tr>
                    <td style="width: 11px"><img alt="" src="../images/white_main_bottom_left.gif" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" height="10" /></td>
                    <td width="10"><img alt="" src="../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>


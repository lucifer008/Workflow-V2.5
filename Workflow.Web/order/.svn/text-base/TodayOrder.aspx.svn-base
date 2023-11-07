<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TodayOrder.aspx.cs" Inherits="TodayOrder" EnableViewState="false" EnableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%--<%@ Register Src="~/order/usercontrols/DailyOrderList.ascx" TagName="DailyOrderList"
    TagPrefix="uc" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="Workflow.Support"%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>订单管理</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/optionsCard.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/dispatch.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
    <script type="text/javascript" src="../js/order/todayOrder.js"></script>
    <script type="text/javascript" src="../js/order/optionsCard.js"></script>
    <script type="text/javascript">
    var orderStatusSucessed=<%=Constants.ORDER_STATUS_SUCCESSED_VALUE%>;
    var orderStatusBlankout=<%=Constants.ORDER_STATUS_BLANKOUT_VALUE%>;
    var matureColor='<%=strList[0] %>'//到期颜色
    var overideColor='<%=strList[1] %>'//过期颜色
    var matureTime='<%=strList[2] %>'//到期时间
    </script>
   <meta http-equiv="Pragma" content="no-cache" />
  <%-- <meta http-equiv="refresh" content="40" />--%>
</head>
<body >
 <form id="form1" method="post"  runat="server" >
    <div align="center" style="width:100%; background-color:#ffffff;"  id="container">
        <input type="hidden" id="actionTag" name="actionTag" runat="server"/>
        <input type="hidden" id="orderNo" name="orderNo" value="" />
        <input type="hidden" id="paginationTag" name="paginationTag" value="false" /><%--标识是否触发分页事件--%>
        <table width="100%" id="tb">
            <tr>
                <td align="left" style="height: 24px">
                    <input type="button" class="buttons"  value="刷新" onclick="newRefresh();" id="Button1"  />
                </td>
                <td align="right" style="height: 24px">
                    <div style="width:320px;float:left">
                        <div style="float:left;width:50px;height:20px;background-color:<%=strList[0] %>"></div>
                        <span style="float:left;font-size:12px;">&nbsp送货(<%=Convert.ToInt32(Convert.ToDecimal(strList[2])*60)%>分钟)内&nbsp;&nbsp;&nbsp&nbsp&nbsp</span>
                        <div style="float:left;width:50px;height:20px;background-color:<%=strList[1] %>"></div>
                        <span style="float:left;font-size:12px">&nbsp送货超时&nbsp;&nbsp;</span>
                    </div>
                </td>
                <%--<td align="right" style="height: 24px"><input type="button" class="buttons" value="过滤" /></td>--%>
            </tr>
        </table>
         <div id="divColumnTitle" style="text-align:left" class="divHead">
              <a id="All" href="#" onclick="bindCardOptionData(this)">全部</a>
              <a id="NoDispatch" href="#" onclick="bindCardOptionData(this)"><%=Constants.ORDER_STATUS_NODISPATCHED_LABEL %></a>
              <a id="Recepting" href="#" onclick="bindCardOptionData(this)"><%=Constants.ORDER_STATUS_RECEPTING_LABEL%></a>
              <a id="Facturing" href="#" onclick="bindCardOptionData(this)"><%=Constants.ORDER_STATUS_FACTURING_LABEL%></a>
              <a id="Sucessed" href="#" onclick="bindCardOptionData(this)"><%=Constants.ORDER_STATUS_SUCCESSED_LABEL%></a>
              <a id="WaitForOrder" href="#" onclick="bindCardOptionData(this)"><%=Constants.ORDER_STATUS_NOBLANKOUTRECORD_LABEL%></a>
          </div> 
         <table width="100%" border="1" cellpadding="0" cellspacing="0"  id="tbDailyOrder">
                <tr>
                  <th class='w1' nowrap="nowrap">&nbsp;NO&nbsp;</th>
                  <th class='w1' nowrap="nowrap" >&nbsp;&nbsp;<a href="#" onclick="orderNoCompositor();">订单号</a>&nbsp;&nbsp;</th>
                  <th nowrap="nowrap">&nbsp;&nbsp;&nbsp;客户名称&nbsp;&nbsp;&nbsp;</th>
                  <th class='w1' nowrap="nowrap">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" onclick="inertDateTimeCompositor();">开单时间</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                  <th class='w1' nowrap="nowrap">取送<br />方式</th>
                  <th class='w1' nowrap="nowrap">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" onclick="deliveryDateTimeCompositor();">送取货时间</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                  <th class='w1' nowrap="nowrap">开单人</th>
                  <th class='w1' nowrap="nowrap">接待人</th>
                  <th class='w1' nowrap="nowrap">&nbsp;&nbsp;<a href="#" onclick="statusCompositor();">状态</a>&nbsp;&nbsp;</th>
                  <th class='w1' nowrap="nowrap">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;操作&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                </tr>
             <% 
                 if (null != model.DailyOrder){
                     for (int i = 0; i < model.DailyOrder.Count; i++){
                     %>
                <tr class="detailRow" rowIndex="<%=i %>" name="ordertr" >
                    <td align="center" name="orderid"><%=i + 1%><input type="hidden" id="orderStatus" name="orderStatus" value="<%=model.DailyOrder[i].Status %>" /></td>
                    <td align="center"><a href="#" onclick="orderDetail(this);"><%=model.DailyOrder[i].No%></a><input type="hidden" name="myOrderNo" value="<%=model.DailyOrder[i].No %>" /></td>
                    <td align="left"><%=model.DailyOrder[i].CustomerName%></td>
                    <td align="center" name="inserDateTime"><%=model.DailyOrder[i].InsertDateTime.ToString("MM-dd HH:mm")%><input type="hidden" name="orInsertDateTime" value="<%=model.DailyOrder[i].InsertDateTime.ToString("yyyy-MM-dd HH:mm") %>" /></td>
                    <td align="center"><%
                        #region 送货时间
                        string strDeliveryType = "";
                         string deliveryDateTime = "-";
                         switch (model.DailyOrder[i].DeliveryType){
                             case Constants.DELIVERY_TYPE_DELIVERY_VALUE:
                                 strDeliveryType =Constants.DELIVERY_TYPE_DELIVERY_LABEL;
                                 deliveryDateTime = model.DailyOrder[i].DeliveryDateTime.ToString("yyyy-MM-dd HH:mm");
                                 break;
                             case Constants.DELIVERY_TYPE_SELF_GET_VALUE:
                                 strDeliveryType = Constants.DELIVERY_TYPE_SELF_GET_LABEL;
                                 deliveryDateTime = model.DailyOrder[i].DeliveryDateTime.ToString("yyyy-MM-dd HH:mm");
                                 break;
                             case Constants.DELIVERY_TYPE_WAITFOR_GET_VALUE:
                                 strDeliveryType = Constants.DELIVERY_TYPE_WAITFOR_GET_LABEL;
                                 break;
                         }
                         if (deliveryDateTime.Equals(Constants.NULL_DATE_TIME.ToString("yyyy-MM-dd HH:mm"))){
                             deliveryDateTime = "-";
                         }
                         else{
                             deliveryDateTime = Convert.ToDateTime(deliveryDateTime).ToString("MM-dd HH:mm");
                         }
                         #endregion
                         %>
                         <%=strDeliveryType%>
                    </td>
                    <td  align="center" name="deliverydate"><%=deliveryDateTime%></td>
                    <td><%=model.DailyOrder[i].UserName%></td>
                    <td><%=model.DailyOrder[i].CashName%></td>
                    <td align="center" name="orderStatus"><%
                            #region 订单状态
                            string strOrderStatus = "";
                             switch (model.DailyOrder[i].Status)
                             {
                                 case Constants.ORDER_STATUS_NOPREPAY_VALUE:
                                     strOrderStatus = "<font color='#500002'>" + Constants.ORDER_STATUS_NOPREPAY_LABEL + "</font>";
                                     break;
                                 case Constants.ORDER_STATUS_RECEPTING_VALUE:
                                     strOrderStatus = "<font color='#500003'>" + Constants.ORDER_STATUS_RECEPTING_LABEL + "</font>";
                                     break;
                                 case Constants.ORDER_STATUS_BLANKOUT_VALUE:
                                     strOrderStatus = "<font color='#00ff00'>" + Constants.ORDER_STATUS_BLANKOUT_LABEL + "</font>";
                                     break;
                                 case Constants.ORDER_STATUS_FACTURING_VALUE:
                                     strOrderStatus = "<font color='#ff0000'>" + Constants.ORDER_STATUS_FACTURING_LABEL + "</font>";
                                     break;
                                 case Constants.ORDER_STATUS_FINISHED_VALUE:
                                     strOrderStatus = "<font color='#388000'>" + Constants.ORDER_STATUS_FINISHED_LABEL + "</font>";
                                     break;
                                 case Constants.ORDER_STATUS_NODISPATCHED_VALUE:
                                     strOrderStatus = "<font color='#988000'>" + Constants.ORDER_STATUS_NODISPATCHED_LABEL + "</font>";
                                     break;
                                 case Constants.ORDER_STATUS_SUCCESSED_VALUE:
                                     strOrderStatus = "<font color='#688000'>" + Constants.ORDER_STATUS_SUCCESSED_LABEL + "</font>";
                                     break;
                                 case Constants.ORDER_STATUS_DELIVERYED_VALUE:
                                     strOrderStatus = "<font color='#0000ff'>" + Constants.ORDER_STATUS_DELIVERYED_LABEL + "</font>";
                                     break;
                                 case Constants.ORDER_STATUS_NOPATCHUP_VALUE:
                                     strOrderStatus = "<font color='#000003'>" + Constants.ORDER_STATUS_NOPATCHUP_LABEL + "</font>";
                                     break;
                                 case Constants.ORDER_STATUS_CONFIRM_VALUE:
                                     strOrderStatus = "<font color='#000002'>" + Constants.ORDER_STATUS_CONFIRM_LABEL + "</font>";
                                     break;
                                 case Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE:
                                     strOrderStatus = "<font color='#000000'>" + Constants.ORDER_STATUS_NOBLANKOUTRECORD_LABEL + "</font>";
                                     break;
                             }   
                            Response.Write(strOrderStatus);
                            #endregion
                         %>
                    </td>
                    <td align="left">
                      <% 
                          #region 操作
                          string strALink = "";
                         switch (model.DailyOrder[i].Status)
                         {
                             case Constants.ORDER_STATUS_NOPREPAY_VALUE:
                                 break;
                             case Constants.ORDER_STATUS_NODISPATCHED_VALUE:
                                 strALink = "<a href='#' onclick='newDispatchOrder(this);'>分配</a> <a href='#' onclick='blankOut(this);'>作废</a>";
                                 break;
                             case Constants.ORDER_STATUS_RECEPTING_VALUE:
                                 strALink = "<a href='#' onclick='newDispatchOrder(this);'>转单</a>  <a href='#' onclick='blankOut(this);'>作废</a>";
                                 break;
                             case Constants.ORDER_STATUS_CONFIRM_VALUE:
                                 //strALink = "<a href='#' onclick='showRealFacture(this);'>修正</a> <a href='#' onclick='newRedoOrder(this);' >返工</a>";    
                                 strALink = "<a href='#' onclick='newPrintOrder(this);'>打印</a>  <a href='#' onclick='newRedoOrder(this);'>返回</a>";
                                 break;
                             case Constants.ORDER_STATUS_FACTURING_VALUE:
                                 strALink = "<a href='#' onclick='newFinishOrder(this);'>完工</a> <a href='#' onclick='showRealFacture(this);'>修正</a> ";
                                 break;
                             case Constants.ORDER_STATUS_FINISHED_VALUE:
                                 strALink = "<a href='#' onclick='newCheckOrder(this);'>核对</a>&nbsp;&nbsp;<a href='#' onclick='newReturnOrder(this);'>返回</a>";
                                 break;
                             case Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE:
                                 //strALink = "<a href='#' onclick='newReturnOrder(this);'>返回</a>";
                                 break;
                             case Constants.ORDER_STATUS_DELIVERYING_VALUE:
                                 strALink = "<a href='#' onclick='CancelAfterVerificationOrder(this);'>核销送货</a>";
                                 break;
                             case Constants.ORDER_STATUS_DELIVERYED_VALUE:
                                 break;
                             case Constants.ORDER_STATUS_NOPATCHUP_VALUE:
                                 strALink = "<a href='#' onclick='showPatchUpOrder(this);'>废稿</a>";
                                 break;
                         }
                         Response.Write(strALink);   
                        #endregion  
                         %>
                    </td>
                </tr>
                    <%}
                }%>
                <tr>
                    <td colspan="11" align="right">
                        <webdiyer:AspNetPager ID="AspNetPagerAll" runat="server" OnPageChanging="AspNetPagerAll_PageChanging" onclick="TagSubmit();"></webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>

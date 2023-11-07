﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DailyOrderList.ascx.cs" Inherits="OrderUserControlsOrderList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%--<link href="../../css/css.css" rel="stylesheet" type="text/css" />
--%>


            <table width="100%" border="1" cellpadding="0" cellspacing="0"  id="tbDailyOrder">
			  <tbody>
                <tr>
                  <th class='w1' nowrap="nowrap">&nbsp;NO&nbsp;</th>
                  <th class='w1' nowrap="nowrap" >&nbsp;&nbsp;<a href="#" onclick="orderNoCompositor();">订单号</a>&nbsp;&nbsp;</th>
                  <th nowrap="nowrap">&nbsp;&nbsp;&nbsp;客户名称&nbsp;&nbsp;&nbsp;</th>
<%--                  <th class='w1' nowrap="nowrap">&nbsp;&nbsp;前期&nbsp;&nbsp;</th>
--%>                  <th class='w1' nowrap="nowrap">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" onclick="inertDateTimeCompositor();">开单时间</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                  <th class='w1' nowrap="nowrap">取送<br />方式</th>
                  <th class='w1' nowrap="nowrap">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#" onclick="deliveryDateTimeCompositor();">送取货时间</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                  <th class='w1' nowrap="nowrap">开单人</th>
                  <th class='w1' nowrap="nowrap">接待</th>
                  <th class='w1' nowrap="nowrap">&nbsp;&nbsp;<a href="#" onclick="statusCompositor();">状态</a>&nbsp;&nbsp;</th>
                  <th class='w1' nowrap="nowrap">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;操作&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                </tr>
             <% for(int i = 0;i < model.DailyOrder.Count;i++) 
                {%>
                        <tr class="detailRow" rowIndex="<%=i %>" name="ordertr" ><td align="center" name="orderid"><%=i+1 %></td>
                        <td align="center"><a href="#" onclick="orderDetail(this);"><%=model.DailyOrder[i].No %></a><input type="hidden" name="myOrderNo" value="<%=model.DailyOrder[i].No %>" /></td>
                        <td align="left"><%=model.DailyOrder[i].CustomerName %></td>
                        <%--<td align="center"><%=model.DailyOrder[i].CustomerTypeName %></td>--%>
                        <td align="center" name="inserDateTime"><%=model.DailyOrder[i].InsertDateTime.ToString("yyyy-MM-dd HH:mm") %></td>
                        <td align="center"><%
                        string strDeliveryType="";
                        string deliveryDateTime = "-";
                        switch(model.DailyOrder[i].DeliveryType)
                        {
                            case Workflow.Support.Constants.DELIVERY_TYPE_DELIVERY_VALUE:
                                strDeliveryType=Workflow.Support.Constants.DELIVERY_TYPE_DELIVERY_LABEL;
                                deliveryDateTime=model.DailyOrder[i].DeliveryDateTime.ToString("yyyy-MM-dd HH:mm");
                                break;
                            case Workflow.Support.Constants.DELIVERY_TYPE_SELF_GET_VALUE:
                                strDeliveryType=Workflow.Support.Constants.DELIVERY_TYPE_SELF_GET_LABEL;
                                deliveryDateTime = model.DailyOrder[i].DeliveryDateTime.ToString("yyyy-MM-dd HH:mm");
                                break;
                            case Workflow.Support.Constants.DELIVERY_TYPE_WAITFOR_GET_VALUE:
                                strDeliveryType=Workflow.Support.Constants.DELIVERY_TYPE_WAITFOR_GET_LABEL;
                                break;
                                
                        }
                        if (deliveryDateTime.Equals(Workflow.Support.Constants.NULL_DATE_TIME.ToString("yyyy-MM-dd HH:mm")))
                        {
                            deliveryDateTime = "-";
                        }
                        Response.Write(strDeliveryType); %></td>
                        <td  align="center" name="deliverydate"><%--<%=deliveryDateTime%>--%></td>
                        <td><%=model.DailyOrder[i].UserName %></td>
                        <td><%=model.DailyOrder[i].CashName %></td>
                        <td align="center" name="orderStatus"><%
                        string strOrderStatus="";
                        switch(model.DailyOrder[i].Status)                    
                        {
                            case Workflow.Support.Constants.ORDER_STATUS_NOPREPAY_VALUE:
                                strOrderStatus = "<font color='#500002'>" + Workflow.Support.Constants.ORDER_STATUS_NOPREPAY_LABEL + "</font>";
                                break;
                            case Workflow.Support.Constants.ORDER_STATUS_BLANKOUT_VALUE:
                                strOrderStatus="<font color='#00ff00'>"+Workflow.Support.Constants.ORDER_STATUS_BLANKOUT_LABEL+"</font>";
                                break;
                            case Workflow.Support.Constants.ORDER_STATUS_FACTURING_VALUE:
                                strOrderStatus = "<font color='#ff0000'>" + Workflow.Support.Constants.ORDER_STATUS_FACTURING_LABEL+"</font>";
                                break;
                            case Workflow.Support.Constants.ORDER_STATUS_FINISHED_VALUE:
                                strOrderStatus = "<font color='#388000'>" + Workflow.Support.Constants.ORDER_STATUS_FINISHED_LABEL + "</font>";
                                break;
                            case Workflow.Support.Constants.ORDER_STATUS_NODISPATCHED_VALUE:
                                strOrderStatus = "<font color='#988000'>" + Workflow.Support.Constants.ORDER_STATUS_NODISPATCHED_LABEL + "</font>";
                                break;
                            case Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE:
                                strOrderStatus =  "<font color='#688000'>"+Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_LABEL + "</font>";
                                break;
                            case Workflow.Support.Constants.ORDER_STATUS_DELIVERYED_VALUE:
                                strOrderStatus = "<font color='#0000ff'>" + Workflow.Support.Constants.ORDER_STATUS_DELIVERYED_LABEL+ "</font>";
                                break;
                            case Workflow.Support.Constants.ORDER_STATUS_NOPATCHUP_VALUE:
                                strOrderStatus = "<font color='#000000'>" + Workflow.Support.Constants.ORDER_STATUS_NOPATCHUP_LABEL + "</font>";
                                break;
                            case Workflow.Support.Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE:
                                strOrderStatus = "<font color='#000000'>" + Workflow.Support.Constants.ORDER_STATUS_NOBLANKOUTRECORD_LABEL + "</font>";
                                break;
                        }
                        Response.Write(strOrderStatus);%></td><td align="left">
                            <% 
                                string strALink = "";
                                switch (model.DailyOrder[i].Status)
                               {
                                   case Workflow.Support.Constants.ORDER_STATUS_NOPREPAY_VALUE:
                                       //strALink = "<a href='#' onclick='prepayOrder(this);'>预付</a>  <a href='#' onclick='blankOut(this);'>作废</a>";
                                       break;
                                   case Workflow.Support.Constants.ORDER_STATUS_FACTURING_VALUE:
                                       //strALink = "<a href='#' onclick='finishOrder(this);'>完工</a>";
                                       strALink = "<a href='#' onclick='newFinishOrder(this);'>完工</a>  <a href='#' onclick='blankOut(this);'>作废</a>";
                                       break;
                                   case Workflow.Support.Constants.ORDER_STATUS_FINISHED_VALUE:
                                       //if (model.DailyOrder[i].DeliveryType == Workflow.Support.Constants.DELIVERY_TYPE_DELIVERY_VALUE)
                                       //{
                                       //    strALink = "<a href='#' onclick='showRealFacture(this);'>修正</a> <a href='#' onclick='deliveryOrder(this);'>送货</a> <a href='#' onclick='redoOrder(this);' >返工</a>";
                                       //}
                                       //else
                                       //{
                                           //strALink = "<a href='#' onclick='showRealFacture(this);'>修正</a> <a href='#' onclick='redoOrder(this);' >返工</a>";    
                                       strALink = "<a href='#' onclick='showRealFacture(this);'>修正</a> <a href='#' onclick='newRedoOrder(this);' >返工</a>";    
                                       //}
                                       break;
                                   case Workflow.Support.Constants.ORDER_STATUS_NODISPATCHED_VALUE:
                                       //strALink = "<a href='#' onclick='dispatchOrder(this);'>分配</a> <a href='#' onclick='blankOut(this);'>作废</a> <a href='#' onclick='newDispatchOrder(this);'>新分配</a>";
                                       strALink = "<a href='#' onclick='newDispatchOrder(this);'>分配</a> <a href='#' onclick='blankOut(this);'>作废</a>";
                                        
                                       break;
                                    case Workflow.Support.Constants.ORDER_STATUS_DELIVERYING_VALUE:
                                        strALink = "<a href='#' onclick='CancelAfterVerificationOrder(this);'>核销送货</a>";
                                        break;
                                    case Workflow.Support.Constants.ORDER_STATUS_DELIVERYED_VALUE:
                                        //strALink = "<a href='#' onclick='showPatchUpOrder(this);'>拼版</a>";
                                        break;
                                    case Workflow.Support.Constants.ORDER_STATUS_NOPATCHUP_VALUE:
                                        strALink = "<a href='#' onclick='showPatchUpOrder(this);'>废稿</a>";
                                        break;
                                    case Workflow.Support.Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE:
                                        //strALink = "<a href='#' onclick='showBalanceOrder(this);'>结算</a>";
                                        break;
                               }
                               Response.Write(strALink);   %>
                        </td></tr>
                <%} %>

				</tbody>
				<tfoot>
				<tr>
				    <td colspan="10" align="right">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                        </webdiyer:AspNetPager>
				    </td>
				</tr>
				</tfoot>
              </table>

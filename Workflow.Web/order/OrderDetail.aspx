<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDetail.aspx.cs" Inherits="OrderDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>订单详情</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/escExit.js"></script>
</head>
<body style="text-align: center" >
    <div align="center" style="width: 100%" id="container">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="12"><img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0"/></td>
                <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                <td width="12"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
            </tr>
            <tr>
                <td colspan="3" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="3%"></td>
                            <td align="left" bgcolor="#eeeeee">首页 -&gt; 本日订单 -&gt; 订单详情</td>
                            <td width="3%"></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="caption" align="center">订单详情</td>
                        </tr>
                        <tr>
                            <td width="3%">&nbsp;</td>
                            <td align="center">
                                <table width="100%" border="0" cellpadding="2" cellspacing="1">
                                    <tr>
                                        <th scope="col"><div align="left">NO.<%=model.NewOrder.No %></div></th>
                                        <th scope="col">
                                            <div align="right"><%=model.NewOrder.InsertDateTime.ToString("yyyy-MM-dd HH:mm") %></div>
                                        </th>
                                    </tr>
                                </table>
                            </td>
                            <td width="3%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="3%">&nbsp;</td>
                            <td align="left">
                                <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                    <tr>
                                        <td nowrap="nowrap" class="item_caption">会员卡号:</td>
                                        <td colspan="3" class="item_content"><%=model.NewOrder.MemberCardNo%></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" class="item_caption">客户名称:</td>
                                        <td class="item_content"><%=model.NewOrder.CustomerName %></td>
                                        <td nowrap="nowrap" class="item_caption">联系人:</td>
                                        <td class="item_content"><%=model.NewOrder.LinkManName %></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" class="item_caption">联系电话:</td>
                                        <td class="item_content"><%=model.NewOrder.LastTelNo %></td>
                                        <td nowrap="nowrap" class="item_caption">项目名称:</td>
                                        <td class="item_content"><%=model.NewOrder.ProjectName %></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" class="item_caption">送货方式:</td>
                                        <td class="item_content">
                                            <% string strTmp = "";
                                               switch (model.NewOrder.DeliveryType)
                                               {
                                                   case Workflow.Support.Constants.DELIVERY_TYPE_DELIVERY_VALUE:
                                                       strTmp = Workflow.Support.Constants.DELIVERY_TYPE_DELIVERY_LABEL;
                                                       break;
                                                   case Workflow.Support.Constants.DELIVERY_TYPE_SELF_GET_VALUE:
                                                       strTmp = Workflow.Support.Constants.DELIVERY_TYPE_SELF_GET_LABEL;
                                                       break;
                                                   case Workflow.Support.Constants.DELIVERY_TYPE_WAITFOR_GET_VALUE:
                                                       strTmp = Workflow.Support.Constants.DELIVERY_TYPE_WAITFOR_GET_LABEL;
                                                       break;
                                               }
                                               Response.Write(strTmp);
                                            %>
                                        </td>
                                        <td nowrap="nowrap" class="item_caption">送货时间:</td>
                                        <td class="item_content">
                                            <%
                                                string deliveryDateTime="";
                                                if (model.NewOrder.DeliveryDateTime.Equals(Workflow.Support.Constants.NULL_DATE_TIME))
                                                {
                                                    deliveryDateTime = "";
                                                }
                                                else
                                                {
                                                    deliveryDateTime = model.NewOrder.DeliveryDateTime.ToString("yyyy-MM-dd HH:mm");
                                                }
                                                Response.Write(deliveryDateTime);
                                            %>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" class="item_caption">支付方式:</td>
                                        <td class="item_content">
                                            <%
                                                switch (model.NewOrder.PayType)
                                                {
                                                    case Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE:
                                                        strTmp = Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_LABEL;
                                                        break;
                                                    case Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_VALUE:
                                                        strTmp = Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_LABEL;
                                                        break;
                                                }
                                                Response.Write(strTmp);%>
                                        </td>
                                        <td nowrap="nowrap" class="item_caption">订单状态:</td>
                                        <td class="item_content">
                                        <%
                                            string strOrderStatus="";
                                            switch(model.NewOrder.Status)                    
                                            {
                                                case Workflow.Support.Constants.ORDER_STATUS_NOPREPAY_VALUE:
                                                    strOrderStatus = "<font color='#500002'>" + Workflow.Support.Constants.ORDER_STATUS_NOPREPAY_LABEL + "</font>";
                                                    break;
                                                case Workflow.Support.Constants.ORDER_STATUS_BLANKOUT_VALUE:
                                                    strOrderStatus = "<font color='#00ff00'>" + Workflow.Support.Constants.ORDER_STATUS_BLANKOUT_LABEL + "</font>";
                                                    break;
                                                case Workflow.Support.Constants.ORDER_STATUS_FACTURING_VALUE:
                                                    strOrderStatus = "<font color='#ff0000'>" + Workflow.Support.Constants.ORDER_STATUS_FACTURING_LABEL + "</font>";
                                                    break;
                                                case Workflow.Support.Constants.ORDER_STATUS_FINISHED_VALUE:
                                                    strOrderStatus = "<font color='#388000'>" + Workflow.Support.Constants.ORDER_STATUS_FINISHED_LABEL + "</font>";
                                                    break;
                                                case Workflow.Support.Constants.ORDER_STATUS_NODISPATCHED_VALUE:
                                                    strOrderStatus = "<font color='#988000'>" + Workflow.Support.Constants.ORDER_STATUS_NODISPATCHED_LABEL + "</font>";
                                                    break;
                                                case Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE:
                                                    strOrderStatus = "<font color='#688000'>" + Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_LABEL + "</font>";
                                                    break;
                                                case Workflow.Support.Constants.ORDER_STATUS_DELIVERYED_VALUE:
                                                    strOrderStatus = "<font color='#0000ff'>" + Workflow.Support.Constants.ORDER_STATUS_DELIVERYED_LABEL + "</font>";
                                                    break;
                                                case Workflow.Support.Constants.ORDER_STATUS_NOPATCHUP_VALUE:
                                                    strOrderStatus = "<font color=''>" + Workflow.Support.Constants.ORDER_STATUS_NOPATCHUP_LABEL + "</font>";
                                                    break;
                                                case Workflow.Support.Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE:
                                                    strOrderStatus = "<font color=''>" + Workflow.Support.Constants.ORDER_STATUS_NOBLANKOUTRECORD_LABEL + "</font>";
                                                    break;
                                            }
                                            Response.Write(strOrderStatus);
                                            %>                                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" class="item_caption">预收款:</td>
                                        <td class="item_content">
                                            <%
                                                string prepay = "";
                                                if (model.NewOrder.PrepareMoney == Workflow.Support.Constants.TRUE)
                                                {
                                                    prepay = "有";
                                                }
                                                else
                                                {
                                                    prepay = "没有";
                                                }
                                                Response.Write(prepay);
                                             %>
                                        </td>
                                        <td nowrap="nowrap" class="item_caption">总金额:</td>
                                        <td class="item_content"><%=model.NewOrder.SumAmount %></td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" style="display:none;" class="item_caption">发票:</td>
                                        <td class="item_content" colspan="3" style="display:none;">
                                            <%
                                                if ("Y" == model.NewOrder.NeedTicket)
                                                {
                                                    strTmp = "需要";
                                                }
                                                else
                                                { strTmp = "不需要"; }
                                                Response.Write(strTmp);%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap="nowrap" class="item_caption">备注:</td>
                                        <td colspan="3" class="item_content"><%= model.NewOrder.Memo %></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="3%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="3%">&nbsp;</td>
                            <td align="center">
                                <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                    <tr>
                                        <th width="1%" nowrap="nowrap">&nbsp;NO&nbsp;</th>
                                        <th width="1%" nowrap="nowrap">&nbsp;&nbsp;业务类型&nbsp;&nbsp;</th>
                                        <% for (int i = 0; i < model.PriceFactor.Count; i++)
                                           {
                                        %>
                                        <th nowrap="nowrap" class="w1" index="<%=i+2 %>" id="th<%=model.PriceFactor[i].Id %>">&nbsp;<%=model.PriceFactor[i].DisplayText%>&nbsp;</th>
                                        <% } %>
                                        <th nowrap="nowrap" class="w1">&nbsp;数量&nbsp;</th>
                                        <th nowrap="nowrap" class="w1">&nbsp;单价&nbsp;</th>
                                        <th nowrap="nowrap" class="w1">&nbsp;金额&nbsp;</th>
                                        <th align="left" nowrap="nowrap">制作要求</th>
                                    </tr>
                                    <% int position = 0;
                                   for (int i = 0; i < model.OrderItem.Count; i++)
                                   {%>
                                    <tr class="detailRow">
                                        <td class="center"> <%=i + 1%></td>
                                        <td class="left"><%=model.OrderItem[i].Name%></td>
                                        <% int a = 0;
                                           
                                           for (int n = position; n < model.NewOrder.OrderItemList.Count; n++)
                                           {
                                               if (model.OrderItem[i].Id == model.NewOrder.OrderItemList[n].Id)
                                               {
                                                   int m = 0;
                                                   for (int k = (int)(model.NewOrder.OrderItemList[n].PriceFactorId % Workflow.Support.Constants.MAX_ID_BASE); k < model.PriceFactor.Count; k++)
                                                   {
                                                       int y = a;
                                                       for (int x = 0; x < ((model.NewOrder.OrderItemList[n].PriceFactorId % Workflow.Support.Constants.MAX_ID_BASE)- y-1); x++)
                                                       { %>
                                                            <td>-</td>                                                    
                                                       <%
                                                           a++;
                                                       }
                                                           
                                                       if (model.PriceFactor[k-1].Id == model.NewOrder.OrderItemList[n].PriceFactorId)
                                                       {%>
                                                            <td><%=model.NewOrder.OrderItemList[n].Name%></td>
                                                            <%
                                                            m++;
                                                            a++;
                                                            position++;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            if (a < model.PriceFactor.Count)
                                            {
                                                for (int b = 0; b < model.PriceFactor.Count - a; b++)
                                                { %>
                                                    <td>-</td>
                                                 <%}
                                            }%>
                                        <td><%=model.OrderItem[i].Amount%></td>
                                        <td><%=model.OrderItem[i].UnitPrice%></td>
                                        <td><%=(model.OrderItem[i].Amount * model.OrderItem[i].UnitPrice).ToString("#.00")%></td>
                                        <td class="left">
                                            <% string strPrint = "";
                                               for (int j = 0; j < model.OrderItemPrintRequireDetailList.Count; j++)
                                               {
                                                   if (model.OrderItem[i].Id == model.OrderItemPrintRequireDetailList[j].OrderItemId)
                                                   {
                                                       strPrint += model.OrderItemPrintRequireDetailList[j].Name + " ";
                                                   }
                                               }
                                               strPrint=strPrint.Trim()+" "+model.OrderItem[i].Memo;
                                               //if (strPrint.Length > 6)
                                               //    strPrint = strPrint.Substring(0, 4) + "...";
                                               Response.Write(strPrint); 
                                            %>
                                        </td>
                                    </tr>
                                    <%}
                                    %>
                                </table>
                            </td>
                            <td width="3%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="3%">&nbsp;</td>
                            <td align="center">
                                <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                    <%--                                    <tr>
                                        <td width="17%" align="center">
                                            <p>
                                                客户许可确认签字</p>
                                        </td>
                                        <td colspan="4">
                                            以上印制及制作要求我已完全审阅并理解，现同意制 作。</td>
                                        <td width="25%">
                                            客户签字:刘正阳</td>
                                    </tr>--%>
                                    <tr>
                                        <td nowrap class="item_caption">开单:</td>
                                            <td width="24%" class="item_content">
                                            <% 
                                                foreach(Workflow.Da.Domain.User user in model.UserList)
                                                {
                                                    if (model.NewOrder.NewOrderUserId == user.Id)
                                                    {
                                                        %>
                                                        <%=user.Employee.Name%>
                                                        <%
                                                        break;
                                                    }
                                                }
                                            %>
                                            </td>
                                        <td nowrap class="item_caption">收银:</td>
                                            <td width="20%" class="item_content">
                                           <%
                                               foreach (Workflow.Da.Domain.User user in model.UserList)
                                               {
                                                   if (model.NewOrder.CashUserId == user.Id && model.NewOrder.Status == Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE)
                                                   { %>
                                                        <%=user.Employee.Name %>    
                                                   <%}
                                               }
                                           %>     
                                            </td>
                                                
                                        <td nowrap class="item_caption">主管:</td>
                                        <td class="item_content"></td>
                                    </tr>
                                    <tr>
                                        <td nowrap class="item_caption">前期:</td>
                                        <td class="item_content">
                                            <% for (int i = 0; i < model.OrderItemEmployee.Count; i++)
                                               {
                                                   //前期
                                                   if (model.OrderItemEmployee[i].PositionId == Workflow.Support.Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                                                   {%>
                                                   <%= model.OrderItemEmployee[i].Name %><br />
                                            <%}
                                          } %>
                                        </td>
                                        <td nowrap class="item_caption">后期:</td>
                                        <td class="item_content">
                                            <% for (int i = 0; i < model.OrderItemEmployee.Count; i++)
                                               {
                                                   //后期
                                                   if (model.OrderItemEmployee[i].PositionId == Workflow.Support.Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                                                   {%>
                                                 <%= model.OrderItemEmployee[i].Name %><br />
                                            <%}
                                         } %>
                                        </td>
                                        <td nowrap class="item_caption">送货:</td>
                                        <td class="item_content"><%= model.Name %></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="3%">&nbsp;</td>
                        </tr>
                        <tr class="emptyButtonsUpperRowHight">
                            <td colspan="3"></td>
                        </tr>
                        <tr height="5">
                            <td width="3%"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                            <td bgcolor="#eeeeee">&nbsp;</td>
                            <td width="3%"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="12"><img alt="" src="../images/white_main_bottom_left.gif" width="12" height="11"/></td>
                <td bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                <td width="12"><img alt="" src="../images/white_main_bottom_right.gif" width="12" height="11"/></td>
            </tr>
        </table>
    </div>
</body>
</html>

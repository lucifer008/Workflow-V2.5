<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Delivery.aspx.cs" Inherits="OrderDelivery" %>

<%@ Import Namespace="Workflow.Support" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>送货</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/order/delivery.js"></script>
    <% if (closeFlag)
       {%>

    <script type="text/javascript">
        opener.location.reload();
        close();
    </script>

    <%} %>
    <base target="_self" />

</head>
<body style="text-align: center">
    <form id="form" action="" method="post" runat="server">
        <div align="center" style="width: 100%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12">
                        <img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF">
                        <img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12">
                        <img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                </td>
                                <td colspan="2" align="left" bgcolor="#eeeeee">
                                    首页 -&gt; 财务处理 -&gt; 送货</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    送货</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="0" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th scope="col">
                                                <div align="left">
                                                    NO.<%=model.NewOrder.No %></div>
                                            </th>
                                            <th scope="col">
                                                <div align="right">
                                                    <%=model.NewOrder.InsertDateTime.ToString("yyyy-MM-dd HH:mm") %>
                                                </div>
                                            </th>
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
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                会员卡号:</td>
                                            <td colspan="3" class="item_content">
                                                <%=model.NewOrder.MemberCardNo%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                客户名称:</td>
                                            <td class="item_content">
                                                <%=model.NewOrder.CustomerName %>
                                            </td>
                                            <td nowrap="nowrap" class="item_caption">
                                                联系人:</td>
                                            <td class="item_content">
                                                <%=model.NewOrder.LinkManName %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                联系电话:</td>
                                            <td class="item_content">
                                                <%=model.NewOrder.LastTelNo %>
                                            </td>
                                            <td nowrap="nowrap" class="item_caption">
                                                项目名称:</td>
                                            <td class="item_content">
                                                <%=model.NewOrder.ProjectName %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                送货方式:</td>
                                            <td class="item_content">
                                                <% string strTmp = "";
                                                   switch (model.NewOrder.DeliveryType)
                                                   {
                                                       case Constants.DELIVERY_TYPE_DELIVERY_VALUE:
                                                           strTmp = Constants.DELIVERY_TYPE_DELIVERY_LABEL;
                                                           break;
                                                       case Constants.DELIVERY_TYPE_SELF_GET_VALUE:
                                                           strTmp = Constants.DELIVERY_TYPE_SELF_GET_LABEL;
                                                           break;
                                                       case Constants.DELIVERY_TYPE_WAITFOR_GET_VALUE:
                                                           strTmp = Constants.DELIVERY_TYPE_WAITFOR_GET_LABEL;
                                                           break;
                                                   }
                                                   Response.Write(strTmp);
                                                %>
                                            </td>
                                            <td nowrap="nowrap" class="item_caption">
                                                送货时间:</td>
                                            <td class="item_content">
                                                <%=model.NewOrder.DeliveryDateTime %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                支付方式:</td>
                                            <td class="item_content">
                                                <%
                                                    switch (model.NewOrder.PayType)
                                                    {
                                                        case Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE:
                                                            strTmp = Constants.PAYMENT_TYPE_ACCOUNT_GET_LABEL;
                                                            break;
                                                        case Constants.PAYMENT_TYPE_CASHER_GET_VALUE:
                                                            strTmp = Constants.PAYMENT_TYPE_CASHER_GET_LABEL;
                                                            break;
                                                    }
                                                    Response.Write(strTmp);%>
                                            </td>
                                            <td nowrap="nowrap" class="item_caption">
                                                发票:</td>
                                            <td class="item_content">
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
                                            <td nowrap="nowrap" class="item_caption">
                                                送货人:</td>
                                            <td colspan="3" class="item_content">
                                                <select name="sltDeliveryEmployee">
                                                    <%
                                                        for (int i = 0; i < model.EmployeeList.Count; i++)
                                                        { 
                                                    %>
                                                    <option value="<%=model.EmployeeList[i].Employeeid %>">
                                                        <%=model.EmployeeList[i].Name %>
                                                    </option>
                                                    <%
                                                        }
                                                    %>
                                                </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                备注:</td>
                                            <td colspan="3" class="item_content">
                                                <textarea name="DeliveryMemo" cols="50" rows="4" id="TEXTAREA1"></textarea></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" nowrap="nowrap" align="center">
                                                <asp:Button ID="btnSave" OnClick="SaveDelivery" OnClientClick="dataCheck();" runat="server" Text="保存&amp;打印" CssClass="buttons" />
                                                <input type="button" class="buttons" onclick="window.close();" value="关闭" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center" colspan="2">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="1%" nowrap="nowrap">
                                                &nbsp;NO&nbsp;</th>
                                            <th width="1%" nowrap="nowrap">
                                                &nbsp;&nbsp;业务类型&nbsp;&nbsp;</th>
                                            <% for (int i = 0; i < model.PriceFactor.Count; i++)
                                               {
                                                   if (model.PriceFactor[i].IsDisplay.ToUpper() != Workflow.Support.Constants.TRUE) continue;
                                            %>
                                            <th nowrap="nowrap" class="w1" index="<%=i+2 %>" id="th<%=model.PriceFactor[i].Id %>">
                                                &nbsp;<%=model.PriceFactor[i].DisplayText%>&nbsp;</th>
                                            <% } %>
                                            <th nowrap="nowrap" class="w1">
                                                &nbsp;数量&nbsp;</th>
                                            <th nowrap="nowrap" class="w1">
                                                &nbsp;单价&nbsp;</th>
                                            <th nowrap="nowrap" class="w1">
                                                &nbsp;金额&nbsp;</th>
                                            <th align="left" nowrap="nowrap">
                                                制作要求</th>
                                        </tr>
                                        <% int position = 0;
                                           for (int i = 0; i < model.OrderItem.Count; i++)
                                           {%>
                                        <tr class="detailRow">
                                            <td class="center">
                                                <%=i + 1%>
                                            </td>
                                            <td class="left">
                                                <%=model.OrderItem[i].Name%>
                                            </td>
                                            <% int a = 0;
                                               for (int k = 0; k < model.PriceFactor.Count; k++)
                                                {
                                                    
                                                    if (position >= model.NewOrder.OrderItemList.Count) break;
                                                    if (model.OrderItem[i].Id == model.NewOrder.OrderItemList[position].Id)
                                                    {
                                                        
                                                        for (int n = position; n < model.NewOrder.OrderItemList.Count; n++)
                                                        {
                                                            int m = 0;
                                                            if (model.PriceFactor[k].Id == model.NewOrder.OrderItemList[n].PriceFactorId)
                                                            {%>
                                                                <td>
                                                                    <%=model.NewOrder.OrderItemList[n].Name%>
                                                                </td>
                                                                <%
                                                                    position++;
                                                                    m++;
                                                                a++;
                                                                break;
                                                            }
                                                            if(0==m)
                                                            {%>
                                                               <td>-</td>  
                                                            <%
                                                                a++;
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
                                                 }
                                               %>
                                            <td>
                                                <%=model.OrderItem[i].Amount%>
                                            </td>
                                            <td>
                                                <%=model.OrderItem[i].UnitPrice%>
                                            </td>
                                            <td>
                                                <%=(model.OrderItem[i].Amount * model.OrderItem[i].UnitPrice).ToString("#.00")%>
                                            </td>
                                            <td class="left">
                                                <% string strPrint = "";
                                                   for (int j = 0; j < model.OrderItemPrintRequireDetailList.Count; j++)
                                                   {
                                                       if (model.OrderItem[i].Id == model.OrderItemPrintRequireDetailList[j].OrderItemId)
                                                       {
                                                           strPrint += model.OrderItemPrintRequireDetailList[j].Name + " ";
                                                       }
                                                   }
                                                   strPrint = strPrint.Trim();
                                                   if (strPrint.Length > 6)
                                                       strPrint = strPrint.Substring(0, 4) + "...";
                                                   Response.Write(strPrint); 
                                                %>
                                            </td>
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
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee" colspan="2">
                                    &nbsp;</td>
                                <td>
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="12">
                        <img alt="" src="../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF">
                        <img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12">
                        <img alt="" src="../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BlankOutRecord.aspx.cs" Inherits="OrderBlankOutRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>废张</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Calendar2.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/jquery.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/default.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/check.js"></script>
    <script type="text/javascript" src="../js/dispatch.js"></script>
    <script type="text/javascript" src="../js/escExit.js"></script>
    <script type="text/javascript" charset="utf-8">
    var strNo='<%=Request.QueryString["strNo"] %>';
    </script>
<% if (closeFlag)
   {%>
    <script type="text/javascript">
        opener.window.close();
        close();
    </script>
    <%} %>
    <base target="_self" />
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <div align="center" style="width: 100%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF"">
                <tr>
                    <td width="11">
                        <img alt="" src="../images/white_main_top_left.gif" /></td>
                    <td width="99%">
                        <img alt="" src="../images/spacer_10_x_10.gif" height="10" /></td>
                    <td width="10">
                        <img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页 ->财务处理 ->废张</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    废张</td>
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
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                会员卡号:</td>
                                            <td class="item_content">
                                                <input name="textfield7" type="text" class="texts" value="<%=model.NewOrder.MemberCardNo%>"
                                                    disabled="disabled" /></td>
                                            <td colspan="2" align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                客户名称:</td>
                                            <td class="item_content">
                                                <input name="textfield22" type="text" class="texts" value="<%=model.NewOrder.CustomerName %>"
                                                    disabled="disabled" /></td>
                                            <td nowrap="nowrap" class="item_caption">
                                                联 系 人:</td>
                                            <td class="item_content">
                                                <input name="textfield32" type="text" class="texts" value="<%=model.NewOrder.LinkManName %>"
                                                    size="15" disabled="disabled" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                联系电话:</td>
                                            <td class="item_content">
                                                <input name="textfield42" type="text" class="tel" value="<%=model.NewOrder.LastTelNo %>"
                                                    disabled="disabled" />
                                            </td>
                                            <td nowrap="nowrap" class="item_caption">
                                                项目名称:</td>
                                            <td class="item_content">
                                                <input name="textfield52" type="text" class="texts" value="<%=model.NewOrder.ProjectName %>"
                                                    disabled="disabled" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                送货方式:</td>
                                            <td class="item_content">
                                                <select name="DeliveryType" id="cbDeliveryType" runat="server" disabled="disabled">
                                                </select>
                                            </td>
                                            <td nowrap="nowrap" class="item_caption">
                                                送货时间:</td>
                                            <td class="item_content">
                                                <div>
                                                    <input id="txtFrom" type="text" class="datetexts" maxlength="" value="<%=model.NewOrder.DeliveryDateTime %>"
                                                        disabled="disabled" />&nbsp;
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                支付方式:</td>
                                            <td class="item_content">
                                                <select name="sltPayType" id="cbPaymentType" runat="server" disabled="disabled">
                                                </select>
                                            </td>
                                            <td nowrap="nowrap" class="item_caption">
                                                发票:</td>
                                            <td class="item_content">
                                                <%if (model.NewOrder.NeedTicket == Workflow.Support.Constants.TRUE)
                                                  {%>
                                                <input type="checkbox" id="radio4" checked="checked" disabled="disabled" />
                                                <label for="radio4">
                                                    需要</label>
                                                <%}
                                                  else
                                                  {%>
                                                <input type="checkbox" name="radio2" id="radio1" disabled="disabled" />
                                                <label for="radio4">
                                                    需要</label>
                                                <%} %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">
                                                备注:</td>
                                            <td colspan="3" class="item_content">
                                                <textarea name="textarea" cols="90" rows="3" value="<%=model.NewOrder.Memo %>"
                                                    disabled="disabled"></textarea></td>
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
                                    <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="6" bgcolor="#FFFFFF">
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
                                                        <th nowrap="nowrap" class="num">
                                                            &nbsp;&nbsp;数量&nbsp;&nbsp;</th>
                                                        <th nowrap="nowrap" class="num">
                                                            &nbsp;&nbsp;单价&nbsp;&nbsp;</th>
                                                        <th nowrap="nowrap" class="num">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;金额&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                                        <th align="left" nowrap="nowrap">
                                                            &nbsp;&nbsp;废稿责任人&nbsp;&nbsp;</th>
                                                        <th nowrap="nowrap" class="w1">
                                                            废张数量</th>
                                                        <th nowrap="nowrap" class="w1">
                                                            废张原因</th>
                                                    </tr>
                                                    <% int position = 0;
                                                       for (int i = 0; i < model.RealOrderItem.Count; i++)
                                                       {%>
                                                    <tr class="detailRow">
                                                        <td class="center">
                                                            <%=i+1 %><input type="hidden" name="realOrderItemId" value="<%=model.RealOrderItem[i].Id %>" />
                                                        </td>
                                                        <td class="left">
                                                            <%=model.RealOrderItem[i].Name%>
                                                        </td>
                                                        <% int a = 0;
                                                           for (int k = 0; k < model.PriceFactor.Count; k++)
                                                           {

                                                               if (position >= model.RealOrderItemList.Count) break;
                                                               if (model.RealOrderItem[i].Id == model.RealOrderItemList[position].Id)
                                                               {

                                                                   for (int n = position; n < model.RealOrderItemList.Count; n++)
                                                                   {
                                                                       int m = 0;
                                                                       if (model.PriceFactor[k].Id == model.RealOrderItemList[n].PriceFactorId)
                                                                       {%>
                                                        <td>
                                                            <%=model.RealOrderItemList[n].Name%>
                                                        </td>
                                                        <%
                                                            position++;
                                                            m++;
                                                            a++;
                                                            break;
                                                        }
                                                        if (0 == m)
                                                        {%>
                                                        <td>
                                                            -</td>
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
                                                        <td>
                                                            -</td>
                                                        <%}
                                                      }
                                                        %>
                                                        <td>
                                                            <%=model.RealOrderItem[i].Amount%>
                                                        </td>
                                                        <td>
                                                            <%=model.RealOrderItem[i].UnitPrice%>
                                                        </td>
                                                        <td>
                                                            <%=(model.RealOrderItem[i].Amount * model.RealOrderItem[i].UnitPrice).ToString("#.00")%>
                                                        </td>
                                                        <td class="left">
                                                            <% //string strEmployee = "";
                                                                for (int n = 0; n < model.OrderItemEmployee.Count; n++)
                                                                {
                                                                    if (model.OrderItemEmployee[n].OrderItemId == model.RealOrderItem[i].OrderItemId)
                                                                    {
                                                                    %>
                                                                        <input type="checkbox" onclick="onChecked(this);" value="<%=model.OrderItemEmployee[n].Id %>" name="chkEmployee" id="chk<%=model.OrderItemEmployee[n].Id.ToString()+i.ToString() %>" />
                                                                        <label for="chk<%=model.OrderItemEmployee[n].Id.ToString()+i.ToString()  %>"><%=model.OrderItemEmployee[n].Name%></label>
                                                                <%
                                                                        //strEmployee += model.OrderItemEmployee[n].Id.ToString() + ',';
                                                                    }
                                                                }
                                                            %><input type="hidden" name="employeeId<%=i %>" value="" /><input type="hidden" name="orderItemId" value="<%=model.RealOrderItem[i].Id %>" />
                                                        </td>
                                                        <td>
                                                            <input type="text" size="6" style="text-align: right" maxlength="9" name="blankOutNum" /></td>
                                                        <td>
                                                            <select name="BlankOutReason" onchange="onReasonChange(this);">
                                                            <option value="<%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_KEY %>" selected="selected"><%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_TEXT %></option>
                                                            <%
                                                                
                                                                for (int n = 0; n < model.TrashReason.Count; n++)
                                                                { 
                                                                    %>
                                                                    <option value="<%=model.TrashReason[n].Id %>"><%=model.TrashReason[n].Name %></option>
                                                                    <%
                                                                }
                                                            
                                                             %>
                                                            </select><input type="hidden" name="Reason" value="" />
                                                        </td>
                                                    </tr>
                                                    <%} %>
                                                </table>
                                                <span class="STYLE1"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                    &nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="4">
                                    <input type="hidden" name="txtOrderNo" id="strOrderNo" /></td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center" class="bottombuttons">
<%--                                    <input name="Submit3342" type="button" class="buttons" onclick="showRealFacture()"
                                        value="修正工单" />
                                    &nbsp;&nbsp;&nbsp;
--%>                                    <asp:Button ID="btnOk" CssClass="buttons" OnClick="Save" OnClientClick="return saveBlankOutRecard();" Text="保存" runat="server" />
                                    &nbsp;
                                    <input name="Submit3342222" type="button" class="buttons" onclick="window.close()"
                                        value="关闭" />
                                </td>
                                <td width="3%">
                                    &nbsp;</td>
                            </tr>
                            <tr height="5">
                                <td>
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">
                                    &nbsp;</td>
                                <td>
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="11">
                        <img alt="" src="../images/white_main_bottom_left.gif" /></td>
                    <td width="99%" bgcolor="#FFFFFF">
                        <img alt="" src="../images/spacer_10_x_10.gif" /></td>
                    <td width="10">
                        <img alt="" src="../images/white_main_bottom_right.gif" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

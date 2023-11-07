<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PatchUpOrder.aspx.cs" Inherits="OrderPatchUpOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>拼版</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Calendar2.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/jquery.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/default.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/check.js"></script>
    <script type="text/javascript" src="../js/order/order.js"></script>
    <script type="text/javascript" src="../js/escExit.js"></script>
    <script type="text/javascript" src="../js/order/patchUpOrder.js"></script>
    <script type="text/javascript" charset="utf-8">
        var flag=false;
        var strNo='<%=Request.QueryString["strNo"]%>';
    </script>

<% if (closeFlag)
{%>
<script type="text/javascript">
   flag=true;
</script>
<%}%>
    <base target="_self" />
</head>

<body style="text-align: center">
    <form id="form" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#ffffff">
	            <tr>
		            <td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
		            <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
		            <td width="10"><img alt="" src="../images/white_main_top_right.gif"
			            width="12" height="11"/></td>
	            </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td >
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页 -&gt; 订单管理 -&gt; 拼版</td>
                                <td >
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    拼版</td>
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
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%" style="height: 397px">&nbsp;</td>
                                <td align="center" style="height: 397px">
                                    <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="center" colspan="3">
                                                <table name="tbTest" border="1" cellpadding="0" cellspacing="0" width="100%" align="left">
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            会员卡号:</td>
                                                        <td colspan="5" class="item_content">
                                                            <input name="MemberCardNo" type="text" class="texts" value="<%=model.NewOrder.MemberCardNo %>"
                                                                id="txtMemberCardNo" readonly="readonly" /><input type="hidden" name="MemberCardId" id="txtMemberCardId" value="<%=model.NewOrder.MemberCardId %>" /><input
                                                                    type="hidden" name="TradeId" id="txtTradeId" value="<%=model.NewOrder.TradeId %>" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption" style="height: 26px">
                                                            客户名称<font color="#FF0000">*</font>:</td>
                                                        <td colspan="5" class="item_content" style="height: 26px">
                                                            <input type="text" class="texts" value="<%=model.NewOrder.CustomerName %>"
                                                                size="50" id="txtCustomerName" name="CustomerName" readonly="readonly" />
                                                            <input type="hidden" name="txtCustomerId" id="customerid" value="<%=model.NewOrder.CustomerId %>" />
                                                            <input name="Input" type="button" class="buttons selectButtons" value="选择客户" id="btnSelectCustomer"
                                                                onclick="" disabled="disabled" />
                                                            <input type="button" name="Submit" class="buttons selectButtons" value="新增客户" id="btnNewCustomer" disabled="disabled" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            客户类型<font color="#FF0000">*</font>:</td>
                                                        <td class="item_content">
                                                            <select name="sltCustomerType" id="cbCustomerType" runat="server" disabled="disabled">
                                                            </select>
                                                        </td>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            真实姓名<font color="#FF0000">*</font>:</td>
                                                        <td class="item_content">
                                                            <input name="text2" type="text" class="texts" value="<%=model.NewOrder.LinkManName %>"
                                                                id="txtName" readonly="readonly"  /></td>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            联系电话:</td>
                                                        <td class="item_content">
                                                            <input name="text2" type="text" class="tel" value="<%=model.NewOrder.LastTelNo %>"
                                                                id="telNo" readonly="readonly" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption" style="height: 25px">
                                                            项目名称:</td>
                                                        <td class="item_content" style="height: 25px">
                                                            <input name="ItemName" type="text" class="texts" value="<%=model.NewOrder.ProjectName %>"
                                                                id="txtItemName" readonly="readonly"  /></td>
                                                        <td nowrap="nowrap" class="item_caption" style="height: 25px">
                                                            支付方式:</td>
                                                        <td class="item_content" style="height: 25px">
                                                            <select name="sltPayType" id="cbPaymentType" runat="server" disabled="disabled">
                                                            </select>
                                                        </td>
                                                        <td nowrap="nowrap" class="item_caption" style="height: 25px">
                                                            预收款:</td>
                                                        <td class="item_content" style="height: 25px">
                                                            <input name="NeedPrepareMoney" class="checks" id="ckNeedPrepareMoney" onchange="prePay();"
                                                                type="checkbox" runat="server" disabled="disabled"  />
                                                            &nbsp;
                                                            <label for="ckneedPrepareMoney">
                                                                需要</label>
                                                            &nbsp;
                                                            <input name="PrepayMoney" type="text" class="texts" size="9" id="txtPrepayMoney"
                                                               value="<%=model.NewOrder.PrepareMoneyAmount %>" readonly="readonly"/></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            发票:</td>
                                                        <td class="item_content">
                                                            <%if (model.NewOrder.NeedTicket == Workflow.Support.Constants.TRUE)
                                                              {%>
                                                            <input name="NeedTicket" type="checkbox" class="checks" id="ckNeedTicket" checked="checked"
                                                                runat="server" disabled="disabled"  />
                                                            &nbsp;
                                                            <label for="NeedTicket">
                                                                需要</label>
                                                            <%}
                                                              else
                                                              {%>
                                                            <input type="checkbox" name="radio4" id="radio1" class="checks" disabled="disabled"  />
                                                            <label for="radio4">
                                                                需要</label>
                                                            <%} %>
                                                        </td>
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
                                                                <input id="txtDeliveryDateTime" type="text" class="datetexts" value="<%=model.NewOrder.DeliveryDateTime %>"
                                                                    readonly="true" />&nbsp;
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            备注:</td>
                                                        <td nowrap="nowrap" colspan="5" align="left">
                                                            <textarea name="Memo" class="textarea" cols="90" rows="2" id="txtMemo" value="<%=model.NewOrder.Memo %>" readonly="readonly"></textarea>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3">
                                                <table id="tbOrderItem" name="tbOrderItem" align="left" border="1" cellpadding="0"
                                                    cellspacing="0" width="100%">
                                                        <tr>
                                                            <th nowrap="nowrap" class="w1">
                                                                &nbsp;NO&nbsp;</th>
                                                            <th nowrap="nowrap" class="w1">
                                                                &nbsp;业务类型&nbsp;</th>
                                                            <% for (int i = 0; i < model.PriceFactor.Count; i++)
                                                               {
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
                                                            <th nowrap="nowrap" class="w1">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                                        </tr>
                                                        <% 
                                                            if (!closeFlag)
                                                            {
                                                                for (int j = 0; j < model.OrderItem.Count; j++)
                                                                {%>
                                                        <tr name="">
                                                            <td align="center" class="no">
                                                                <%=j + 1%></td>
                                                            <td>
                                                                <select name="BusinessType" id="sltBusinessType" onchange="doProcess(this);">
                                                                    <option value='-1' selected="selected">请选择</option>
                                                                    <%System.Collections.Generic.IList<Workflow.Da.Domain.BusinessType> businessTypeList = model.BusinessType;
                                                                      for (int i = 0; i < businessTypeList.Count; i++)
                                                                      {
                                                                          if (model.OrderItem[j].BusinessTypeId == businessTypeList[i].Id)
                                                                          {%>
                                                                            
                                                                           <option value='<%= businessTypeList[i].Id %>' selected="selected">
                                                                                   <%=businessTypeList[i].Name%>
                                                                                   
                                                                           </option>
                                                                        <%}
                                                                          else
                                                                          {%>
                                                                           <option value='<%= businessTypeList[i].Id %>'>
                                                                                   <%=businessTypeList[i].Name%>
                                                                           </option>
                                                                          <%}
                                                                        }%>
                                                                </select>
                                                            </td>
                                                            <% for (int i = 0; i < model.PriceFactor.Count; i++)
                                                               {
                                                            %>
                                                            <td>
                                                                -</td>
                                                            <%} %>
                                                            <td>
                                                                <input type="text" name="Amount" style="text-align:right" maxlength="9" size="10" /></td>
                                                            <td name="price">
                                                                <%=model.OrderItem[j].UnitPrice%>
                                                            </td>
                                                            <td name="sumMoney">
                                                                <%=model.NewOrder.SumAmount%></td>
                                                            <td>
                                                            <%string strPrint = "";
                                                              for (int i = 0; i < model.OrderItemPrintRequireDetailList.Count; i++)
                                                              {
                                                                  if (model.OrderItem[j].Id == model.OrderItemPrintRequireDetailList[i].OrderItemId)
                                                                  {
                                                                      strPrint += model.OrderItemPrintRequireDetailList[i].Name + " ";
                                                                  }
                                                              }%>
                                                                <a href="#" onclick="showPrintRequest(this);"><%if (!Workflow.Util.StringUtils.IsEmpty(strPrint)) { Response.Write(strPrint); } else { Response.Write("选择"); } %></a><input id="factorid<%=j+1 %>" name="txtFactorId<%=j+1 %>"
                                                                    type="hidden" /><input id="factorvalue<%=j+1 %>" name="txtFactorValue<%=j+1 %>" type="hidden" /><input
                                                                        id="printRequest<%=j+1 %>" name="txtPrintRequest<%=j+1 %>" type="hidden" /><input type="hidden" name="strPrice" /><input
                                                                            type="hidden" name="txtSumMoney" /><input type="hidden" name="priceFactorId<%=j+1 %>" id="txtPriceFactorId<%=j+1 %>" /></td>
                                                            <td>
                                                                <input type="button" name="btnOrderItemOk" onclick="hideControl(this);" value="确定" />
                                                                <input type='button' style="display: none" onclick='editOrderItem(this);' value='编辑' />
                                                                <input type="button" onclick="delRow(this);" value="取消" />
                                                                <input type="hidden" name="OrderItemId" value="<%=model.OrderItem[j].Id %>" />
                                                                </td>
                                                        </tr>
                                                        <%}
                                                      }
                                                      else
                                                      {
                                                          for (int m = 0; m < model.RealOrderItem.Count; m++)
                                                          {%>
                                                            <tr name="">
                                                                <td align="center" class="no">
                                                                    <%=m + 1%></td>
                                                                <td>
                                                                    <select name="BusinessType" id="sltBusinessType1" onchange="doProcess(this);">
                                                                        <option value='-1' selected="selected">请选择</option>
                                                                        <%System.Collections.Generic.IList<Workflow.Da.Domain.BusinessType> businessTypeList = model.BusinessType;
                                                                          for (int i = 0; i < businessTypeList.Count; i++)
                                                                          {
                                                                              if (model.RealOrderItem[m].BusinessTypeId == businessTypeList[i].Id)
                                                                              {%>
                                                                                
                                                                               <option value='<%= businessTypeList[i].Id %>' selected="selected">
                                                                                       <%=businessTypeList[i].Name%>
                                                                                       
                                                                               </option>
                                                                            <%}
                                                                              else
                                                                              {%>
                                                                               <option value='<%= businessTypeList[i].Id %>'>
                                                                                       <%=businessTypeList[i].Name%>
                                                                               </option>
                                                                              <%}
                                                                            }%>
                                                                    </select>
                                                                </td>
                                                                <% for (int i = 0; i < model.PriceFactor.Count; i++)
                                                                   {
                                                                %>
                                                                <td>
                                                                    -</td>
                                                                <%} %>
                                                                <td>
                                                                    <input type="text" name="Amount" maxlength="9" size="10" value="<%=model.RealOrderItem[m].Amount %>" /></td>
                                                                <td name="price">
                                                                    <%=model.RealOrderItem[m].UnitPrice%>
                                                                </td>
                                                                <td name="sumMoney">
                                                                    <%=model.NewOrder.SumAmount%></td>
                                                                <td>
                                                                <%string strPrint = "";
                                                                  for (int i = 0; i < model.RealOrderItemPrintRequire.Count; i++)
                                                                  {
                                                                      if (model.RealOrderItem[m].Id == model.RealOrderItemPrintRequire[i].RealOrderItemId)
                                                                      {
                                                                          strPrint += model.RealOrderItemPrintRequire[i].Name + " ";
                                                                      }
                                                                  }%>
                                                                    <a href="#" onclick="showPrintRequest(this);"><%Response.Write(strPrint); %></a><input id="Hidden1" name="txtFactorId<%=m+1 %>"
                                                                        type="hidden" /><input id="Hidden2" name="txtFactorValue<%=m+1 %>" type="hidden" /><input
                                                                            id="printRequest<%=m+1 %>" name="txtPrintRequest<%=m+1 %>" type="hidden" /><input type="hidden" name="strPrice" /><input
                                                                                type="hidden" name="txtSumMoney" /><input type="hidden" name="priceFactorId<%=m+1 %>" id="txtPriceFactorId<%=m+1 %>" /></td>
                                                                <td>
                                                                    <input type="button" name="btnOrderItemOk" onclick="hideControl(this);" value="确定" />
                                                                    <input type='button' style="display: none" onclick='editOrderItem(this);' value='编辑' />
                                                                    <input type="button" onclick="delRow(this);" value="取消" />
                                                                    <input type="hidden" name="OrderItemId" value="<%=model.RealOrderItem[m].Id %>" />
                                                                    </td>
                                                            </tr>
                                                      <%}
                                                    }%>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr class="emptyButtonsUpperRowHight">
                                            <td colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="bottombuttons" colspan="3">
                                                <input type="button" onclick="addRow();" class="buttons" value="新增业务明细" id="btnNewOrderItem1" />&nbsp;
                                                <input name="btnBlankOut" type="button" class="buttons" onclick="blankOutRecord()"
                                                    value="废稿" disabled="disabled" />&nbsp;
                                                <asp:button Text="保存" CssClass="buttons" ID="btn" OnClientClick="return realOrderDataCheck(); " OnClick="OrderSave"  runat="server"/>&nbsp;
                                                <input name="Submit33423" type="button" class="buttons" onclick="window.close()"
                                                    value="关闭" />
                                                    <input type="hidden" name="OrdersId" value="<%=model.NewOrder.Id %>" />
                                            </td>
                                        </tr>
                                        <tr height="5">
                                            <td width="3%">
                                                <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                            <td bgcolor="#eeeeee">
                                                &nbsp;</td>
                                            <td width="3%">
                                                <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%" style="height: 397px">&nbsp;</td>
                            </tr>
                         </table>
                    </td>
                </tr>
	            <tr>
		            <td width="11"><img alt="" src="../images/white_main_bottom_left.gif"/></td>
		            <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif"/></td>
		            <td width="10"><img alt="" src="../images/white_main_bottom_right.gif"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>

</html>

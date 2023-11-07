<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RealFactureOrder.aspx.cs" Inherits="OrderRealFactureOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�����ӹ���</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/Calendar2.js"></script>
    <script type="text/javascript" src="../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../js/math.js"></script>
    <script type="text/javascript" src="../js/date.js"></script>
    <script type="text/javascript" src="../js/check.js"></script>
    <script type="text/javascript" src="../js/order/realFactureOrder.js"></script>    
    <script type="text/javascript" src="../js/order/order.js"></script>
  <%--  <%if (closeFlag)
    {%>
    <script type="text/javascript" >
        //opener.location.reload();
       //opener.rVal='true';
        //close();
    </script>
    <%}%>--%>
    <script type="text/javascript">
        var self=<%=Workflow.Support.Constants.DELIVERY_TYPE_SELF_GET_VALUE %>;
        var wait=<%=Workflow.Support.Constants.DELIVERY_TYPE_WAITFOR_GET_VALUE %>;
        var delivery=<%=Workflow.Support.Constants.DELIVERY_TYPE_DELIVERY_VALUE %>;
        var position=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.PositionId %>;
        var master=<%=Workflow.Support.Constants.POSITION_SHOP_MASTER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
        var manager=<%=Workflow.Support.Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;

        var strNo='<%=Request.QueryString["strNo"]%>';
    </script>
    <base target="_self" />
</head>

<body style="text-align: center"  >
    <form id="form" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#ffffff">
	            <tr>
		            <td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
		            <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
		            <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
	            </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td >
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    ��ҳ -&gt; �������� -&gt; �����ӹ���</td>
                                <td >
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    �����ӹ���</td>
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
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="center" colspan="3">
                                                <table name="tbTest" border="1" cellpadding="0" cellspacing="0" width="100%" align="left">
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            ��Ա����:</td>
                                                        <td colspan="5" class="item_content">
                                                            <input name="MemberCardNo" type="text" class="texts" value="<%=model.NewOrder.MemberCardNo %>"
                                                                id="txtMemberCardNo" onblur=" return memberCardChange(event,this);" /><input type="button" id="Accredit" value="�ֶ������Ա����" disabled="true" onclick="accredit();" /><input type="hidden" name="MemberCardId" id="txtMemberCardId" value="<%=model.NewOrder.MemberCardId %>" /><input
                                                                    type="hidden" name="TradeId" id="txtTradeId" value="<%=model.NewOrder.TradeId %>" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption" style="height: 26px">
                                                            �ͻ�����<font color="#FF0000">*</font>:</td>
                                                        <td colspan="5" class="item_content" style="height: 26px">
                                                            <input type="text" class="texts" value="<%=model.NewOrder.CustomerName %>"
                                                                size="50" id="txtCustomerName" name="CustomerName" readonly="readonly" />
                                                            <input type="hidden" name="txtCustomerId" id="customerid" value="<%=model.NewOrder.CustomerId %>" />
                                                            <input name="Input" type="button" class="buttons selectButtons" value="ѡ��ͻ�" id="btnSelectCustomer"
                                                                onclick="" />
                                                            <input type="button" name="Submit" class="buttons selectButtons" value="�����ͻ�" id="btnNewCustomer" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            �ͻ�����<font color="#FF0000">*</font>:</td>
                                                        <td class="item_content">
                                                            <select name="sltCustomerType" id="cbCustomerType" runat="server">
                                                            </select>
                                                        </td>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            ��ʵ����<font color="#FF0000">*</font>:</td>
                                                        <td class="item_content">
                                                            <input name="RealName" type="text" maxlength="50" class="texts" value="<%=model.NewOrder.LinkManName %>"
                                                                id="txtName" /></td>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            ��ϵ�绰:</td>
                                                        <td class="item_content">
                                                            <input name="RealTelNo" type="text" maxlength="20" class="tel" value="<%=model.NewOrder.LastTelNo %>"
                                                                id="telNo" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption" style="height: 25px">
                                                            ��Ŀ����:</td>
                                                        <td class="item_content" style="height: 25px">
                                                            <input name="ItemName" type="text" class="texts" maxlength="50" value="<%=model.NewOrder.ProjectName %>"
                                                                id="txtItemName" /></td>
                                                        <td nowrap="nowrap" class="item_caption" style="height: 25px">
                                                            ֧����ʽ:</td>
                                                        <td class="item_content" style="height: 25px">
                                                            <select name="sltPayType" id="cbPaymentType" disabled="true" runat="server">
                                                            </select>
                                                        </td>
                                                        <td nowrap="nowrap" class="item_caption" style="height: 25px">
                                                            Ԥ�տ�:</td>
                                                        <td class="item_content" style="height: 25px">
                                                            <input name="NeedPrepareMoney" class="checks" id="ckNeedPrepareMoney" disabled="true" type="checkbox"  runat="server" />
                                                            &nbsp;
                                                            <label for="ckneedPrepareMoney">
                                                                ��Ҫ</label>
                                                            &nbsp;
                                                            <input name="PrepayMoney" type="text" maxlength="9" class="texts" size="9" readonly="true" id="txtPrepayMoney" 
                                                                value="<%=model.NewOrder.PrepareMoneyAmount %>"  /></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption" style="display:none;">
                                                            ��Ʊ:</td>
                                                        <td class="item_content" style="display:none;">
                                                            <%if (model.NewOrder.NeedTicket == Workflow.Support.Constants.TRUE)
                                                              {%>
                                                            <input name="NeedTicket" type="checkbox" class="checks" id="ckNeedTicket" checked="checked"
                                                                runat="server" />
                                                            &nbsp;
                                                            <label for="NeedTicket">
                                                                ��Ҫ</label>
                                                            <%}
                                                              else
                                                              {%>
                                                            <input type="checkbox" name="radio4" id="radio1" class="checks" checked="checked" />
                                                            <label for="radio4">
                                                                ��Ҫ</label>
                                                            <%} %>
                                                        </td>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            �ͻ���ʽ:</td>
                                                        <td class="item_content">
                                                            <select name="DeliveryType" id="cbDeliveryType" runat="server" onchange="deliveryDateTime();">
                                                            </select>
                                                        </td>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            �ͻ�ʱ��:</td>
                                                        <td class="item_content">
                                                            <div>
                                                            <%
                                                                string strDeliveryDateTime = "";
                                                                if (!model.NewOrder.DeliveryDateTime.Equals(Workflow.Support.Constants.NULL_DATE_TIME))
                                                                {
                                                                    strDeliveryDateTime = model.NewOrder.DeliveryDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                                                                }
                                                             %>
                                                                <input id="txtDeliveryDateTime" name="txtDeliveryDateTime" type="text" class="datetimetexts" onfocus="setDayInit(this);" readonly="true" size="20" maxlength="16" value="<%=strDeliveryDateTime %>" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            ��ע:</td>
                                                        <td nowrap="nowrap" colspan="5" align="left">
                                                            <textarea name="Memo" class="textarea" cols="90" rows="3" id="txtMemo" value="<%=model.NewOrder.Memo %>"></textarea>
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
                                                                &nbsp;ҵ������&nbsp;</th>
                                                            <% for (int i = 0; i < model.PriceFactor.Count; i++)
                                                               {
                                                            %>
                                                            <th nowrap="nowrap" class="w1" index="<%=i+2 %>" id="th<%=model.PriceFactor[i].Id %>">
                                                                &nbsp;<%=model.PriceFactor[i].DisplayText%>&nbsp;</th>
                                                            <% } %>
                                                            <th nowrap="nowrap" class="w1">
                                                                &nbsp;����&nbsp;</th>
                                                            <th nowrap="nowrap" class="w1">
                                                                &nbsp;����&nbsp;</th>
                                                            <th nowrap="nowrap" class="w1">
                                                                &nbsp;���&nbsp;</th>
                                                            <th align="left" nowrap="nowrap">
                                                                ����Ҫ��</th>
                                                            <th nowrap="nowrap" class="w1">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                                        </tr>
                                                        <% if (model.OrderItem.Count > 0)
                                                           {

                                                               for (int j = 0; j < model.OrderItem.Count; j++)
                                                               {%>
                                                        <tr name="">
                                                            <td align="center" class="no">
                                                                <%=j + 1%></td>
                                                            <td>
                                                                <select name="BusinessType" id="sltBusinessType" onchange="doProcess(this);">
                                                                    <option value='-1' selected="selected">��ѡ��</option>
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
                                                                <input type="text" name="Amount" style="text-align:right" size="10" maxlength="9" onfocus="selectAll(this);" value="<%=model.OrderItem[j].Amount %>" /></td>
                                                            <td name="price">
                                                                <input name="unitPrice" type="text" size="10" style="display:none; text-align:right;"  value="<%=model.OrderItem[j].UnitPrice%>" maxlength="10"/>
                                                            </td>
                                                            <td name="sumMoney">
                                                                <%=(model.OrderItem[j].Amount * model.OrderItem[j].UnitPrice).ToString("C")%></td>
                                                            <td>
                                                            <%string strPrint = "";
                                                              for (int i = 0; i < model.OrderItemPrintRequireDetailList.Count; i++)
                                                              {
                                                                  if (model.OrderItem[j].Id == model.OrderItemPrintRequireDetailList[i].OrderItemId)
                                                                  {
                                                                      strPrint += model.OrderItemPrintRequireDetailList[i].Name + " ";
                                                                  }
                                                              }
                                                              strPrint += " " + model.OrderItem[j].Memo;
                                                                   %>
                                                                <a href="#" onclick="showPrintRequest(this);"><%if (!Workflow.Util.StringUtils.IsEmpty(strPrint.Trim())) { Response.Write(strPrint); } else { Response.Write("ѡ��"); } %></a><input id="factorid<%=j+1 %>" name="txtFactorId<%=j+1 %>"
                                                                    type="hidden" /><input id="factorvalue<%=j+1 %>" name="txtFactorValue<%=j+1 %>" type="hidden" /><input
                                                                        id="printRequest<%=j+1 %>" name="txtPrintRequest<%=j+1 %>" type="hidden" /><input type="hidden" name="strPrice" /><input
                                                                            type="hidden" name="txtSumMoney" /><input type="hidden" name="priceFactorId<%=j+1 %>" id="txtPriceFactorId<%=j+1 %>" /><input type="hidden" name="PriceId" id="txtPriceId<%=j+1 %>" /></td>
                                                            <td>
                                                                <input type="button" name="btnOrderItemOk" onclick="hideControl(this);" value="ȷ��" />
                                                                <input type='button' style="display: none" onclick='orderItemEdit(this);' value='�༭' />
                                                                <input type="button" onclick="deleteOneOrderitem(this);" value="ɾ��" /></td>
                                                        </tr>
                                                        <%}
                                                      }
                                                      else
                                                      {%>
                                                            <tr name="">
                                                                <td align="center" class="no">1</td>
                                                                <td><select name="BusinessType" id="sltBusinessType1" onchange="doProcess(this);" >
                                                                        <option value='-1' selected="selected">��ѡ��</option>
                                                                <% 
                                                            System.Collections.Generic.IList<Workflow.Da.Domain.BusinessType> businessTypeList = model.BusinessType;
                                                            for (int i = 0; i < businessTypeList.Count; i++)
                                                            {
                                                                %>
                                                                        <option value='<%= businessTypeList[i].Id %>'><%=businessTypeList[i].Name%></option>
                                                                <% }%>
                                                                    </select></td>
                                                                <% for (int i = 0; i < model.PriceFactor.Count; i++)
                                                               {
                                                                %>
                                                                <td>-</td>
                                                                <%} %>
                                                                <td><input type="text" name="Amount" style="text-align:right" maxlength="9" size="10"/></td>
                                                                <td name="price"></td>
                                                                <td name="sumMoney">
                                                                    0.00</td>
                                                                <td>
                                                                    <a href="#" onclick="showPrintRequest(this);">ѡ��</a><input id="factorid1" name="txtFactorId1" type="hidden" /><input id="factorvalue1" name="txtFactorValue1" type="hidden" /><input id="printRequest1" name="txtPrintRequest1" type="hidden" /><input type="hidden" name="strPrice" /><input type="hidden" name="txtSumMoney" /><input type="hidden" name="priceFactorId1" id="txtPriceFactorId1" /><input type="hidden" name="PriceId" id="txtPriceId1" /></td>
                                                                <td>
                                                                    <input type="button" onclick="hideControl(this);" name="btnOrderItemOk" value="ȷ��"/>
                                                                    <input type='button' style="display:none" onclick='editOrderItem(this);' value='�༭' />
                                                                    <input type="button" onclick="deleteOneOrderitem(this);" value="ɾ��" /></td>
                                                            </tr>                                                               
                                                           <%}     
                                                           %>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr class="emptyButtonsUpperRowHight">
                                            <td colspan="3"><input type="hidden" id="txtRowNo" name="RowNo" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="bottombuttons" colspan="3">
                                                <input type="button" onclick="addOneOrderItem();" class="buttons" value="����ҵ����ϸ" id="btnNewOrderItem1" />
                                                <input name="blankOut" id="btnBlankOut" type="button" class="buttons" onclick="blankOutRecord()"
                                                    value="�ϸ�" style="display:none" />
                                                <asp:Button Text="���·�����Ա" CssClass="buttons" ID="btnReturn" OnClientClick="return realOrderDataCheck(); " OnClick="OrderReturn" runat="server" />
                                                <asp:button Text="����" CssClass="buttons" ID="btnSave" OnClientClick="return realOrderDataCheck(); " OnClick="OrderSave"  runat="server"/>
                                                <input name="Submit33423" type="button" class="buttons" onclick="window.close()"
                                                    value="�ر�" /><input type="hidden" name="OrdersId" value="<%=model.NewOrder.Id %>" />
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">
                                    &nbsp;</td>
                                <td width="3%">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                         </table>
                    </td>
                </tr>
	            <tr>
		            <td width="11" >
		                <img alt="" src="../images/white_main_bottom_left.gif"/></td>
		            <td width="99%" bgcolor="#FFFFFF">
		                <img alt="" src="../images/spacer_10_x_10.gif"/></td>
		            <td width="10" >
		                <img alt="" src="../images/white_main_bottom_right.gif"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>

</html>

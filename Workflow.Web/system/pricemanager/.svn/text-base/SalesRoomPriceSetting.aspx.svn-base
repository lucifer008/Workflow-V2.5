<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesRoomPriceSetting.aspx.cs"
  Inherits="SalesRoomPriceSetting" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>门市价格设定</title>
  <link href="../../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../../js/jquery.js"></script>
  <script type="text/javascript" src="../../js/default.js"></script>
  <script type="text/javascript" src="../../js/system/priceManager/basePriceSet.js"></script>
  <script type="text/javascript" src="../../js/system/priceManager/batchDeletePrice.js"></script>
</head>
<body style="text-align: center">
  <form id="MainForm" runat="server" method="post">
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
    <input id="txtAction" name="txtAction" type="hidden" value="1"/>
    <input id="txtId" name="txtId" type="hidden"/>
    <input id="Action" name="Action" type="hidden"/>
      <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
          <td width="11"><img src="../../images/white_main_top_left.gif"></td>
          <td width="99%"><img src="../../images/spacer_10_x_10.gif" height="10"></td>
          <td width="10"><img src="../../images/white_main_top_right.gif" width="12" height="11"></td>
        </tr>
        <tr>
          <td colspan="3" bgcolor="#FFFFFF">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td bgcolor="#FFFFFF">
                  <table width="100%" border="0" cellspacing="0">
                    <tr>
                      <td></td>
                      <td align="left" bgcolor="#eeeeee">首页 -&gt; 系统管理 -&gt; 价格管理 -&gt; 门市价格设定</td>
                      <td></td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">门市价格设定</td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="center">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <td nowrap="nowrap" class="item_caption">业务类型:</td>
                            <td class="item_content"><div id="factorMemory">
                              <select id="sltBusinessType" name="sltBusinessType" onchange="queryPriceSet(this)">
                                <option value='-1' selected="selected">请选择</option>
                                <%for (int i = 0; i < model.BusinessTypeList.Count; i++)
                                  {   
                                %>
                                <%
                                    if (model.BusinessTypeList[i].Id == lngBusinessTypeId)
                                  { %>
                                <option  value="<%=model.BusinessTypeList[i].Id%>" selected="selected" >
                                  <%=model.BusinessTypeList[i].Name%>
                                </option>
                                <%}
                                  else
                                  {%>
                                <option value="<%=model.BusinessTypeList[i].Id%>">
                                  <%=model.BusinessTypeList[i].Name%>
                                </option>
                                <%
                                  }
                                }
                                %>
                              </select>&nbsp;
                                <asp:Button class="buttons" ID="btnQuery" runat="server" Text="查询" OnClick="Button1_Click" /></div>
                            </td>
                          </tr>
                         </table>
                      </td>
                      <td width="3%">&nbsp;</td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="right">
                        <input name="btnAddPrice" id="btnAddPrice" type="button" class="buttons" value="单个录入" /> &nbsp; &nbsp;
                        <input name="btnBatchAddPrice" id="btnBatchAddPrice" type="button" class="buttons" value="批量录入" /> &nbsp; &nbsp;
                        <input name="btnBatchDeletePrice" id="btnBatchDeletePrice" type="button" class="buttons" value="批量修改" />
                       </td>
                      <td width="3%">&nbsp;</td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="center">
                        <table id="tabledetail" width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <th nowrap="nowrap">
                            <input type="checkbox" id="cbSelected" onclick="allSelectedClick()"/>
                            <input type="button" id="batchDelete" name="batchDelete" size="6"  value="删除" onclick="batchDeletePrice();"/></th>
                            <th nowrap="nowrap">&nbsp;NO&nbsp;</th>                                         
                            <th nowrap="nowrap">业务类型</th>
                            <%
                              for (int i = 0; i < model.PriceFactor.Count; i++)
                              { %>
                            <th nowrap="nowrap"><%=model.PriceFactor[i].DisplayText%></th>
                            <%} 
                            %>
                            <th nowrap="nowrap">成本价格</th>
                            <th nowrap="nowrap">标准价格</th>
                            <th nowrap="nowrap">活动价格</th>
                            <th nowrap="nowrap">备用价格</th>
                            <th nowrap="nowrap">备注</th>
                            <th nowrap="nowrap">&nbsp;</th>
                          </tr>
                          <% 
                            for (int i = 0; i < model.BaseBusinessTypePriceSetList.Count; i++)
                            {
                          %>
                          <tr class="detailRow">
                           <td nowrap="nowrap">
                                <input type="checkbox" name="cbBBTPSL<%=model.BaseBusinessTypePriceSetList[i].Id %>"/>
                                <input type="hidden" name="bbtplId" value="<%=model.BaseBusinessTypePriceSetList[i].Id %>" />
                            </td>
                            <td align="center"><%=i+1%></td>
                            <td align="left"><%=model.BaseBusinessTypePriceSetList[i].BusinessType.Name%></td>
                            <%for (int j = 0; j < model.PriceFactor.Count; j++)
                              {%>
                            <td align="center" nowrap="nowrap"><%=model.BaseBusinessTypePriceSetList[i].Texts[j]%></td>
                            <%}
                            %>
                            <td class="num"><%=model.BaseBusinessTypePriceSetList[i].CostPrice %></td>
                            <td class="num"><%=model.BaseBusinessTypePriceSetList[i].StandardPrice %></td>
                            <td class="num"><%=model.BaseBusinessTypePriceSetList[i].ActivityPrice %></td>
                            <td class="num"><%=model.BaseBusinessTypePriceSetList[i].ReservePrice %></td>
                            <td>&nbsp;</td>
                            <td align="left" nowrap="nowrap">
                              <a href="#" onclick="showPriceSet(<%=model.BaseBusinessTypePriceSetList[i].Id%>)">编辑</a>&nbsp;<a href="#" onclick="deletePriceSet(<%=model.BaseBusinessTypePriceSetList[i].Id%>)">删除</a></td>
                          </tr>
                          <%
                            }
                          %>  
                            <tr class="emptyButtonsUpperRowHight">
                              <td colspan="<%=model.PriceFactor.Count+9 %>" align="right">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                </webdiyer:AspNetPager>
                              </td>
                            </tr>                        
                        </table>
                      </td>
                      <td width="3%">&nbsp;</td>
                    </tr>
                    <tr><td colspan=3></td></tr>
                    <tr height="5">
                      <td><img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                      <td bgcolor="#eeeeee">&nbsp;</td>
                      <td><img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td width="11"><img src="../../images/white_main_bottom_left.gif"/></td>
          <td width="99%"><img src="../../images/spacer_10_x_10.gif"/></td>
          <td width="10"><img src="../../images/white_main_bottom_right.gif"/></td>
        </tr>
      </table>
      <input runat="server" ID="isQuery" type="hidden" name="isQuery" value="0" />
    </div>
  </form>
</body>
</html>

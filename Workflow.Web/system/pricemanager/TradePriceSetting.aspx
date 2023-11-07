<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TradePriceSetting.aspx.cs"
  Inherits="TradePriceSetting" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>行业价格设置</title>
  <link href="../../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../../js/jquery.js"></script>
  <script type="text/javascript" src="../../js/default.js"></script>
  <script type="text/javascript" src="../../js/system/priceManager/tradePriceSetting.js"></script>

</head>
<body style="text-align: center">
  <form id="MainForm" method="post" runat="server">
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
      <input id="txtAction" type="hidden" runat="server" value="1" />
      <input id="txtId" type="hidden" runat="server" />
      <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
          <td width="11"><img src="../../images/white_main_top_left.gif"/></td>
          <td width="99%"><img src="../../images/spacer_10_x_10.gif" height="10"/></td>
          <td width="10"><img src="../../images/white_main_top_right.gif" width="12" height="11"/></td>
        </tr>
        <tr>
          <td colspan="3" bgcolor="#FFFFFF">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td bgcolor="#FFFFFF">
                  <table width="100%" border="0" cellspacing="0">
                    <tr>
                      <td></td>
                      <td align="left" bgcolor="#eeeeee">首页 -&gt; 系统管理 -&gt; 价格管理 -&gt; 行业价格设置</td>
                      <td></td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">行业价格设置</td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="center">
                        <table width="100%" border="1" cellspacing="1">
                          <tr>
                             <td nowrap="nowrap" class="item_caption">行业名称:</td>
                                <td class="item_content" colspan="3">
                                  <select name="sltSecondaryTrade" id="sltSecondaryTrade">
                                    <option value="-1" selected="selected">请选择</option>
                                    <%for (int i = 0; i < model.MasterTrade.Count; i++)
                                      {
                                    %>
                                    <option disabled="disabled" value="<%=model.MasterTrade[i].Id%>"><%=model.MasterTrade[i].Name%></option>
                                    <%
                                      for (int j = 0; j < model.MasterTrade[i].SecondaryTradeList.Count; j++)
                                      {
                                    %>
                                    <option value="<%=model.MasterTrade[i].SecondaryTradeList[j].Id%>">　<%=model.MasterTrade[i].SecondaryTradeList[j].Name%></option>
                                    <%  
                                      }
                                    %>
                                    <%} %>
                                  </select>
                                </td>                                     
                            </tr>
                            <tr class="querybuttons">
                               <td nowrap="nowrap" class="item_caption">业务类型:</td>
                                <td class="item_content" ><div id="factorMemory">
                                  <select id="sltBusinessType" name="sltBusinessType" onchange="querySettings(this)">
                                    <option value="-1" selected="selected">请选择</option>
                                    <%for (int i = 0; i < model.BusinessTypeList.Count; i++)
                                      {   
                                    %>
                                    <option value="<%=model.BusinessTypeList[i].Id%>"><%=model.BusinessTypeList[i].Name%></option>
                                    <%} %>
                                  </select>
                                  </div>
                                </td>
                              <td colspan="2" nowrap><input name="btnQuery" id="btnQuery" type="button" value="查询" class="buttons"/></td>
                            </tr>
                        </table>
                      </td>
                      <td width="3%">&nbsp;</td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="left"><input name="sltStandardPrice" type="button" class="buttons" value="选择门市价格" /></td>
                      <td width="3%">&nbsp;</td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="center">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
                            <th width="1%" nowrap="nowrap">业务名称</th>
                            <%for (int i = 0; i < model.PriceFactor.Count; i++)
                              {
                            %>
                            <th width="2%" nowrap="nowrap">
                              <%=model.PriceFactor[i].DisplayText%>
                            </th>
                            <%  
                              } 
                            %>
                            <th width="2%" nowrap>
                              成本<br />
                              价格</th>
                            <th width="2%" nowrap>
                              标准<br />
                              价格</th>
                            <th width="2%" nowrap>
                              活动<br />
                              价格</th>
                            <th width="2%" nowrap>
                              备用<br />
                              价格</th>
                            <th width="2%" nowrap>
                              行业<br />
                              价格</th>
                            <th width="2%" nowrap>
                              行业<br />
                              折扣%</th>
                            <th nowrap="nowrap">
                              备注</th>
                            <th nowrap>
                              &nbsp;</th>
                          </tr>
                          <% 
                            for (int i = 0; i < model.BusinessTypePriceSetList.Count; i++)
                            {
                          %>
                          <tr class="detailRow">
                            <td align="center">
                              <%=i+1%>
                            </td>
                            <td align="center">
                              <%=model.BusinessTypePriceSetList[i].BusinessType.Name%>
                            </td>
                            <%for (int j = 0; j < model.PriceFactor.Count; j++)
                              {
                            %>
                            <td align="center" nowrap="nowrap">
                              <%=model.BusinessTypePriceSetList[i].Texts[j]%>
                            </td>
                            <%
                              } 
                            %>
                            <td class="num">
                              <%=model.BusinessTypePriceSetList[i].CostPrice %>
                            </td>
                            <td class="num">
                              <%=model.BusinessTypePriceSetList[i].StandardPrice %>
                            </td>
                            <td class="num">
                              <%=model.BusinessTypePriceSetList[i].ActivityPrice %>
                            </td>
                            <td class="num">
                              <%=model.BusinessTypePriceSetList[i].ReservePrice %>
                            </td>
                            <td class="num"><%=model.BusinessTypePriceSetList[i].NewPrice %></td>
                            <td class="num"><%=model.BusinessTypePriceSetList[i].PriceConcession %></td>
                            <td nowrap="NOWRAP">
                              &nbsp;</td>
                            <td nowrap="NOWRAP">
                              <a href="#" onclick="showPriceSet(<%=model.BusinessTypePriceSetList[i].Id%>);">编辑</a>&nbsp;<a
                                href="#" onclick="deletePriceSet(<%=model.BusinessTypePriceSetList[i].Id %>);">删除</a></td>
                          </tr>
                          <%
                            }
                          %>
	                    <tfoot>
	                    <tr>
	                        <td colspan="<%=model.PriceFactor.Count+11%>" align="right">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                </webdiyer:AspNetPager>
	                        </td>
	                    </tr>
	                    </tfoot>                          
                        </table>
                      </td>
                      <td width="3%">&nbsp;</td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight">
                      <td colspan="3"></td>
                    </tr>
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
    </div>
  </form>
</body>
</html>

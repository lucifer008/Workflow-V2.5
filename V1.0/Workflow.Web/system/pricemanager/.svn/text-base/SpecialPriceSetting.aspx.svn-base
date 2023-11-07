<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SpecialPriceSetting.aspx.cs"
  Inherits="SpecialPriceSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title>特殊会员价格设置</title>
  <link href="../../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../../js/jquery.js"></script>
  <script type="text/javascript" src="../../js/default.js"></script>
  <script type="text/javascript" src="../../js/system/priceManager/specialPriceSettings.js"></script>
</head>
<body style="text-align: center">
  <form id="MainForm" method="post" runat="server">
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
      <input id="txtAction" type="hidden" runat="server" value="1" />
      <input id="txtId" type="hidden" runat="server" />
      <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
          <td width="11">
            <img src="../../images/white_main_top_left.gif"/></td>
          <td width="99%">
            <img src="../../images/spacer_10_x_10.gif" height="10"/></td>
          <td width="10">
            <img src="../../images/white_main_top_right.gif" width="12" height="11"/></td>
        </tr>
        <tr>
          <td colspan="3" bgcolor="#FFFFFF">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td bgcolor="#FFFFFF">
                  <table width="100%" border="0" cellspacing="0">
                    <tr>
                      <td>
                      </td>
                      <td align="left" bgcolor="#eeeeee">
                        首页 -&gt; 系统管理 -&gt; 价格管理 -&gt; 特殊会员价格设置</td>
                      <td>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">
                        特殊会员价格设置</td>
                    </tr>
                    <tr>
                      <td width="3%">
                        &nbsp;</td>
                      <td align="center">
                        <table width="100%" border="1" align="left" cellpadding="3" cellspacing="1">
                          <tr>
                            <td nowrap="nowrap" class="item_caption">
                              业务类型:</td>
                            <td class="item_content">
                              <select name="sltBusinessType">
                                <option value="0">请选择</option>
                                <%for (int i = 0; i < model.BusinessTypeList.Count; i++)
                                  {   
                                %>
                                <option value="<%=model.BusinessTypeList[i].Id%>">
                                  <%=model.BusinessTypeList[i].Name%>
                                </option>
                                <%} %>
                              </select>
                            </td>
                            <td nowrap="nowrap" class="item_caption">
                              会员卡号:</td>
                            <td class="item_content">
                              <input id="txtMemberCardNo" name="txtMemberCardId" /></td>
                          </tr>
                          <tr class="querybuttons">
                            <td colspan="4" nowrap>
                              <input name="btnQuery" type="button" value="查询" class="buttons"/></td>
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
                        <input name="sltPrice" type="button" class="buttons"
                          value="选择门市价格" />
                      <td width="3%">
                        &nbsp;</td>
                    </tr>
                    <tr>
                      <td width="3%">
                        &nbsp;</td>
                      <td align="center">
                        <table width="100%" border="1" align="left" cellpadding="3" cellspacing="1">
                          <tr>
                            <th width="1%" nowrap="nowrap">
                              &nbsp;NO&nbsp;</th>
                            <th width="1%" nowrap="nowrap">
                              业务名称</th>
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
                              会员价</th>
                            <th width="2%" nowrap>
                              会员<br />
                              折扣%</th>
                            <th nowrap="nowrap">
                              备注</th>
                            <th width="2%" nowrap>
                              &nbsp;</th>
                          </tr>
                          <tr class="detailRow">
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
                          </tr>
                        </table>
                      </td>
                      <td width="3%">
                        &nbsp;</td>
                    </tr>
                    <tr height="10px">
                      <td colspan="3">
                      </td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight">
                      <td colspan="3">
                      </td>
                    </tr>
                    <tr height="5">
                      <td>
                        <img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                      <td bgcolor="#eeeeee">
                        &nbsp;</td>
                      <td>
                        <img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td width="11">
            <img src="../../images/white_main_bottom_left.gif"/></td>
          <td width="99%">
            <img src="../../images/spacer_10_x_10.gif"/></td>
          <td width="10">
            <img src="../../images/white_main_bottom_right.gif"/></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>

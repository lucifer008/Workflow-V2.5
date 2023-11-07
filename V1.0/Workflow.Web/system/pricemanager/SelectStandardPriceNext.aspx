<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectStandardPriceNext.aspx.cs"
  Inherits="StandardPriceNext_Select" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>修改价格</title>
  <link href="../../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../../js/jquery.js"></script>
  <script type="text/javascript" src="../../js/default.js"></script>
  <script type="text/javascript" src="../../js/check.js"></script> 
  <script type="text/javascript" src="../../js/system/priceManager/selectStandardPriceNext.js"></script>
  <script type="text/javascript" src="../../js/escExit.js"></script>

  <script type="text/javascript">
<%if (closeSelf) {%>
  $().ready(function(){
    var parentWindow=window.opener;
    if (parentWindow!=null){
      opener.$("#MainForm").submit();
      window.close();
      return;
      }
  });
<%} %>
</script>
  <base target="_self"/>
 </head>
<body style="text-align: center">
  <form id="MainForm" runat="server" method="post">
    <%if (closeSelf) { return; } %>
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
      <input type="hidden" name="txtIdList" id="txtIdList" value="<%=strIdList%>" />
      <input type="hidden" name="txtBusinessTypeId" id="txtBusinessTypeId" value="<%=lngBusinessTypeId%>" />
      <input type="hidden" name="txtPageType" id="txtPageType" value="<%=intPageType%>" />
      <input type="hidden" name="txtAction" id="txtAction" />
      <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
          <td width="11">
            <img alt="" src="../../images/white_main_top_left.gif" /></td>
          <td width="99%">
            <img alt="" src="../../images/spacer_10_x_10.gif" height="10" /></td>
          <td width="10">
            <img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"></td>
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
                        首页 -&gt; 系统管理 -&gt; 价格管理 -&gt; 修改价格</td>
                      <td>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">
                        修改价格<%=strPageTypeName%></td>
                    </tr>
                    <tr>
                    <td width="3%">&nbsp;</td>
                    <td align="center">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                        <tr>
                    <td class="item_caption" nowrap><%=strQueryTitle%></td>
                      <td colspan="2" class="item_content">
                        <select id="sltTargetId" name="sltTargetId">
                          <option value="0">请选择</option>
                          <% if (intPageType == 1)
                             {
                               for (int i = 0; i < model.MemberCardLevelList.Count; i++)
                               {%>
                          <option value="<%=model.MemberCardLevelList[i].Id%>">
                            <%=model.MemberCardLevelList[i].Name%>
                          </option>
                          <%}%>
                          <%
                            }
                            else if (intPageType == 2)
                            {  %>
                          <%for (int i = 0; i < model.MasterTrade.Count; i++)
                            {
                          %>
                          <option disabled="disabled" value="<%=model.MasterTrade[i].Id%>">
                            <%=model.MasterTrade[i].Name%>
                          </option>
                          <%
                            for (int j = 0; j < model.MasterTrade[i].SecondaryTradeList.Count; j++)
                            {
                          %>
                          <option value="<%=model.MasterTrade[i].SecondaryTradeList[j].Id%>">&nbsp;&nbsp;<%=model.MasterTrade[i].SecondaryTradeList[j].Name%></option>
                          <%  
                            }
                          %>
                          <%} %>
                          <%
                            }
                            else if (intPageType == 3)
                            {
                              for (int i = 0; i < model.MemberCardList.Count; i++)
                              {%>
                          <option value="<%=model.MemberCardList[i].Id%>">
                            <%=model.MemberCardList[i].Name%>
                          </option>
                          <%}
                          }  
                          %>
                        </select>
                      </td>
                    </tr>
                        </table>
                    </td>
                    <td width="3%">&nbsp;</td>
                    </tr>
                    
                    <tr>
                      <td width="3%">
                        &nbsp;</td>
                      <td align="center">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <th width="1%" nowrap="nowrap">
                              &nbsp;NO&nbsp;</th>
                            <%for (int i = 0; i < basModel.PriceFactor.Count; i++)
                              {
                            %>
                            <th width="1%" nowrap="nowrap">
                              <%=basModel.PriceFactor[i].DisplayText%>
                            </th>
                            <%  
                              } 
                            %>
                            <th width="1%" nowrap="nowrap">
                              单价</th>
                            <th width="1%" nowrap="nowrap">
                              新单价</th>
                            <th width="1%">
                              折扣</th>
                            <th nowrap="nowrap">
                              备注</th>
                          </tr>
                          <% 
                            for (int i = 0; i < basModel.BaseBusinessTypePriceSetList.Count; i++)
                            {
                          %>
                          <tr>
                            <td align="center">
                              <%=i+1%>
                            </td>
                            <%for (int j = 0; j < basModel.PriceFactor.Count; j++)
                              {
                            %>
                            <td align="center" nowrap="nowrap">
                              <input type="hidden" name="hddFactorValueId<%=i%>" value="<%=basModel.BaseBusinessTypePriceSetList[i][j]%>" />
                              <%=basModel.BaseBusinessTypePriceSetList[i].Texts[j]
                              %>
                            </td>
                            <%
                              } 
                            %>
                            <td class="num">
                              <%=basModel.BaseBusinessTypePriceSetList[i].CostPrice%>
                            </td>
                            <td class="num">
                              <input id ="txtNewPrice<%=i%>" name="txtNewPrice" type="text" class="num" size="5" maxlength="5" /></td>
                            <td nowrap>
                              <input id = "txtPriceConcession<%=i%>" name="txtPriceConcession" type="text" class="num" size="5" maxlength="3" />
                              %</td>
                            <td>
                              &nbsp;</td>
                          </tr>
                          <%}%>
                        </table>
                      </td>
                      <td width="3%">
                        &nbsp;</td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight">
                      <td colspan="3">
                      </td>
                    </tr>
                    <tr class="bottombuttons">
                      <td colspan="3" align="center">
                        <input name="Submit34" class="buttons" value="上一步" type="button" onclick="history.back();"/>
                        &nbsp;
                        <input name="btnSavePrice" class="buttons" value="完成" type="button" onclick="savePriceSet();" />
                        &nbsp;
                        <input name="btnCancel" class="buttons" value="关闭" type="button" onclick="window.close();" /></td>
                    </tr>
                    <tr height="10px">
                      <td colspan="3">
                      </td>
                    </tr>
                    <tr height="5">
                      <td>
                        <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                      <td bgcolor="#eeeeee">
                        &nbsp;</td>
                      <td>
                        <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td width="11">
            <img alt="" src="../../images/white_main_bottom_left.gif"/></td>
          <td width="99%">
            <img alt="" src="../../images/spacer_10_x_10.gif"/></td>
          <td width="10">
            <img alt="" src="../../images/white_main_bottom_right.gif"/></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>

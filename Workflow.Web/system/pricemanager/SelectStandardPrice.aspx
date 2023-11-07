<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectStandardPrice.aspx.cs" Inherits="SelectOnePrice" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="Workflow.Da.Domain" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>选择门市价格</title>
  <link href="../../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../../js/jquery.js"></script>
  <script type="text/javascript" src="../../js/default.js"></script>
  <script type="text/javascript" src="../../js/check.js"></script>
  <script type="text/javascript" src="../../js/system/priceManager/selectStandardPrice.js"></script>
  <script type="text/javascript" src="../../js/escExit.js">
</script>
  <base target="_self"></base>
</head>
<body style="text-align: center">
  <form id="MainForm" method="post" runat="server">
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
    <input type="hidden" id="actionTag" name="actionTag" value=""  />
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
                      <td align="left" bgcolor="#eeeeee">首页 -&gt; 系统管理 -&gt; 价格管理 -&gt; 选择门市价格</td>
                      <td></td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">选择门市价格<% =strPageTypeName%></td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="center">
                        <table width="100%" border="1" cellspacing="1" cellpadding="3">
                          <tr>
 
                            <td class="item_caption">行业:</td>
                            <td class="item_content" colspan="3">
                               <select name="sltSecondaryTrade" id="sltSecondaryTrade" onchange="selectedProtent()">
                                <option value="-1">请选择</option>
                                <%for (int j = 0; j < model.SecondaryTradeList.Count; j++){
                                      if (sltTradeId == model.SecondaryTradeList[j].Id)
                                      {
                                %>
                                         <option value="<%=model.SecondaryTradeList[j].Id%>" selected="selected"><%=model.SecondaryTradeList[j].Name%></option>
                                <%
                                      }
                                      else
                                      { %>
                                        <option value="<%=model.SecondaryTradeList[j].Id%>"><%=model.SecondaryTradeList[j].Name%></option>
                                      <%  
                                      }%>
                                <%} %>
                              </select>
                            </td>
                          </tr>
                          <tr class="querybuttons" id="trQuery">
                           <td class="item_caption">业务类型:</td>
                            <td class="item_content"><div id="factorMemory">
                              <select id="sltBusinessType" name="sltBusinessType" onchange="querySettings(this)">
                                <option value="-1">请选择</option>
                                <%  
                                    for (int i = 0; i < model.BusinessTypeList.Count; i++)
                                    {
                                        if (sltBusinessTypeId == model.BusinessTypeList[i].Id)
                                        {
                                %>
                                        <option value="<%=model.BusinessTypeList[i].Id %>" selected="selected"><%=model.BusinessTypeList[i].Name%></option>
                                <%
                                        }
                                        else
                                        {
                                           %>
                                            <option value="<%=model.BusinessTypeList[i].Id %>"><%=model.BusinessTypeList[i].Name%></option>
                                        <%}
                                   }
                                %>
                              </select></div>
                            </td>                          
                            <td colspan="2" align="right">
                              <input id="btnQuery" name="btnQuery" type="button" class="buttons" value="查询" onclick="doQuery();"/>
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td width="3%">&nbsp;</td>
                    </tr>
                    <tr>
				        <td width="3%">&nbsp;</td>
				        <td align="left">
				        <input name="btnSavePriceSet" id="btnSavePriceSet" type="submit" value="保存设置" class="buttons" onclick="return saveCheck()" />
                        </td>
				        <td width="3%">&nbsp;</td>
			        </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="center">
                         <table width="100%" border="1" cellpadding="3" cellspacing="1">
                  <tr>
                    <th width="1%" nowrap="nowrap">设置</th>
                    <th width="1%" nowrap="nowrap">业务名称</th>
                    <%
                        int column = 8 + model.PriceFactor.Count;
                        for (int i = 0; i < model.PriceFactor.Count; i++){
                     %>
                    <th width="2%" nowrap="nowrap"><%=model.PriceFactor[i].DisplayText%></th>
                    <%  
                      } 
                    %>
                    
                    <th width="2%" nowrap="nowrap">成本<br/>价格</th>
                    <th width="2%" nowrap="nowrap">标准<br/>价格</th>
                    <th width="2%" nowrap="nowrap">活动<br/>价格</th>
                    <th width="2%" nowrap="nowrap">备用<br/>价格</th>
                    <th width="2%" nowrap="nowrap">行业<br/>价格</th>
                    <th width="2%" nowrap="nowrap">行业<br/>折扣%</th>
                  </tr>
                    <% 
                        if (null != model.BusinessTypePriceSetList)
                        {
                            for (int i = 0; i < model.BusinessTypePriceSetList.Count; i++)
                            {
                                BusinessTypePriceSet businessTy = model.BusinessTypePriceSetList[i];
                                long bbId = businessTy.BaseBusinessTypePriceSetId;
                    %>  
                    <tr class="detailRow">                        
                         <td align="center">
                         <%if (businessTy.IsSeted == true){%>
                         <input type="checkbox" name="chky<%=bbId%>" id="chky<%=bbId%>" checked="checked"/>
                         <%}else{ %>
                         <input type="checkbox" name="chkn<%=bbId%>" id="chkn<%=bbId%>"/>
                         <%}%>
                         <input type="hidden" id="hiddCbName" name="cbName" value="<%=bbId%>" />
                         </td>
                         <td align="center"><%=businessTy.BusinessType.Name%></td>
                        <%for (int j = 0; j < model.PriceFactor.Count; j++){%>
                            <td align="center" nowrap="nowrap"><%=model.BusinessTypePriceSetList[i].Texts[j]%></td>
                         <%}%>
                    <td class="num"><%=businessTy.CostPrice%></td>
                    <td class="num"><%=businessTy.StandardPrice%></td>
                    <td class="num"><%=businessTy.ActivityPrice%></td>
                    <td class="num"><%=businessTy.ReservePrice%></td>
                    <td nowrap="NOWRAP"><input maxlength="8" size="8" type="text" name="input1<%=bbId%>" id="input1" value="<%=businessTy.NewPrice %>" /></td>
                    <td nowrap="NOWRAP"><input maxlength="5" size="5" type="text" name="input2<%=bbId%>" id="input2" value="<%=businessTy.PriceConcession %>" /></td>
                  </tr>
                        <%}
                      }%>
                      <tfoot>
                        <tr>
                            <td colspan="<%=model.PriceFactor.Count+8 %>" align="right">
                               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                               </webdiyer:AspNetPager>
                            </td>
                        </tr>
                      </tfoot>
                    </table>
                </td>                      
                        <td width="3%">&nbsp;</td>
                    </tr>
                    <tr>
			            <td width="3%">&nbsp;</td>
			            <td align="left" colspan="<%=column%>">
			                <label for="cbSelected" style="color:Red"><input type="checkbox"  checked="checked" id="cbSelected" onclick="allSelectedClick()"/>全选</label>
			            </td>
			            <td width="3%">&nbsp;</td>
			        </tr>
<%--                   <tr>
                       <td  colspan="<%=column%>" align="right">
                           <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                           </webdiyer:AspNetPager>
                       </td> 
                    </tr>
--%>                    
                    <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
                    <tr height="10px"><td colspan="3"></td></tr>
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

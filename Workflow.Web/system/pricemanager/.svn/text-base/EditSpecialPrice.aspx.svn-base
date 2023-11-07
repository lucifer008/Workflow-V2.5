<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditSpecialPrice.aspx.cs" Inherits="system_pricemanager_EditSpecialPrice" %>

<%@ Register Assembly="PhookPager" Namespace="PhookTools" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>通过门市价格设置特殊价格</title>
  <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <script type="text/javascript" src="../../js/system/priceManager/editSpecialPrice.js"></script>
    <script type="text/javascript" src="../../js/escExit.js"></script>
</head>
<body style="text-align:center">
<form id="MainForm" method="post" runat="server">
<div align="center" style="width:99%; background-color:#ffffff"  id="container">
<input id="txtAction" name="txtAction" type="hidden" value="1"/>
<input id="txtId" name="txtId" type="hidden"/>
<table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
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
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td></td>
				<td align="left" bgcolor="#eeeeee">首页 -&gt; 系统管理 -&gt; 价格管理 -&gt; 会员卡价格设置</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center">会员卡价格设置</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
				<table width="100%" border="1" cellpadding="3" cellspacing="1">
				   <tr>
                    <td nowrap="nowrap" class="item_caption">卡级别:</td>
                    <td class="item_content"><select name="sltMemberCardLevel" id="sltMemberCardLevel" >
                      <option value="-1">请选择</option>
                      <%for (int i = 0; i < model.MemberCardLevelList.Count; i++)
                        {
                          if (model.MemberCardLevelList[i].Id != 0)
                          {
                            if (lngMemberCardLevel != -1 && model.MemberCardLevelList[i].Id == lngMemberCardLevel)
                            {
                      %>
                      <option value="<%=model.MemberCardLevelList[i].Id%>" selected="selected"><%=model.MemberCardLevelList[i].Name%></option>
                      <%
                        }
                        else
                        {
                      %>
                      <option value="<%=model.MemberCardLevelList[i].Id%>"><%=model.MemberCardLevelList[i].Name%></option>
                      <%
                        }
                      }
                    }
                          %>
                    </select></td>
                  </tr>
                  <tr>
                    <td nowrap="nowrap" class="item_caption">业务类型:</td>
                    <td class="item_content"><div id="factorMemory">
                    <select name="sltBusinessType" id="sltBusinessType" onchange="queryPriceSet(this)">
                      <option value="-1">请选择</option>
                      <%for (int i = 0; i < model.BusinessTypeList.Count; i++)
                        {
 
                      %>                      
                      <option value="<%=model.BusinessTypeList[i].Id%>"><%=model.BusinessTypeList[i].Name%></option>
                      <%
                          //}
                        }
                        %>
                    </select><input id="btnQuery" name="btnQuery" type="button" value="查询" onclick="return queryQuickly();" class="buttons"/></div></td>
                    </tr>

                </table></td>
				<td width="3%">&nbsp;</td>
			</tr>
			
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="left">
				<input name="btnSavePriceSet" type="submit" value="保存设置" class="buttons" onclick="return savecheck()" />
          </td>
				<td width="3%">&nbsp;</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center"><table width="100%" border="1" cellpadding="3" cellspacing="1">
                  <tr>
                    <th width="1%" nowrap="nowrap">设置</th>
                    <th width="1%" nowrap="nowrap">业务名称</th>
                    <%for (int i = 0; i < model.PriceFactor.Count; i++)
                      {
                    %>
                    <th width="2%" nowrap="nowrap"><%=model.PriceFactor[i].DisplayText%></th>
                    <%  
                      } 
                    %>
                    
                    <th width="2%" nowrap="nowrap">成本<br/>价格</th>
                    <th width="2%" nowrap="nowrap">标准<br/>价格</th>
                    <th width="2%" nowrap="nowrap">活动<br/>价格</th>
                    <th width="2%" nowrap="nowrap">备用<br/>价格</th>
                    <th width="2%" nowrap="nowrap">卡级<br/>别价</th>
                    <th width="2%" nowrap="nowrap">卡级别<br/>折扣%</th>
                  </tr>
                    <% 
                     for (int i = 0; i < model.BusinessTypePriceSetList.Count; i++)
                     {
                    %>  
                    <tr class="detailRow">                        
                         <td align="center">
                         <%if (model.BusinessTypePriceSetList[i].IsSeted == true)
                           {%>
                         <input type="checkbox" name="chky<%=model.BusinessTypePriceSetList[i].BaseBusinessTypePriceSetId.ToString() %>" id="chky<%=model.BusinessTypePriceSetList[i].BaseBusinessTypePriceSetId.ToString() %>" checked  />
                         <%}
                           else
                           { %>
                         <input type="checkbox" name="chkn<%=model.BusinessTypePriceSetList[i].BaseBusinessTypePriceSetId.ToString() %>" id="chkn<%=model.BusinessTypePriceSetList[i].BaseBusinessTypePriceSetId.ToString() %>"  />
                         <%} %>
                         <input type="hidden" id="hiddCbName" name="cbName" value="<%=model.BusinessTypePriceSetList[i].BaseBusinessTypePriceSetId.ToString() %>" />
                         </td>
                         <td align="center"><%=model.BusinessTypePriceSetList[i].BusinessType.Name%></td>
                        <%for (int j = 0; j < model.PriceFactor.Count; j++)
                           {
                         %>
                            <td align="center" nowrap="nowrap"><%=model.BusinessTypePriceSetList[i].Texts[j]%></td>
                         <%
                           } 
                         %>
                    <td class="num"><%=model.BusinessTypePriceSetList[i].CostPrice %></td>
                    <td class="num"><%=model.BusinessTypePriceSetList[i].StandardPrice %></td>
                    <td class="num"><%=model.BusinessTypePriceSetList[i].ActivityPrice %></td>
                    <td class="num"><%=model.BusinessTypePriceSetList[i].ReservePrice %></td>
                    <td nowrap="NOWRAP"><input maxlength="8" size="8" type="text" name="input1<%=model.BusinessTypePriceSetList[i].BaseBusinessTypePriceSetId.ToString() %>" id="input1" value="<%=model.BusinessTypePriceSetList[i].NewPrice %>" /></td>
                    <td nowrap="NOWRAP"><input maxlength="5" size="5" type="text" name="input2<%=model.BusinessTypePriceSetList[i].BaseBusinessTypePriceSetId.ToString() %>" id="input2" value="<%=model.BusinessTypePriceSetList[i].PriceConcession %>" /></td>
                  </tr>
                    <%
                     }
                     %>
                </table></td>
				<td width="3%">&nbsp;</td>
			</tr>
			<tr>
			<td width="3%">&nbsp;</td>
			<td align="left">
			    <label for="cbSelected" style="color:Red"><input type="checkbox" id="cbSelected" onclick="allSelectedClick()"/>全选</label>
			</td>
			<td width="3%">&nbsp;</td>
			</tr>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="2" align="right">
                  <cc1:PhookPager ID="PhookPager1" runat='server'>
                  </cc1:PhookPager>
				</td>
			</tr>
			<tr height="5">
				<td><img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td><img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
			</tr>
		</table>
      <input runat="server" ID="isQuery" type="hidden" name="isQuery" value="0" />

		</td>
	</tr>
</table></td>
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
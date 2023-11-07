<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BatchUpdateMemberPrice.aspx.cs" Inherits="system_pricemanager_BatchUpdateMemberPrice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>�����޸Ļ�Ա���۸�</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/system/priceManager/memberCardPriceSettings.js"></script>
</head>
<body style="text-align:center">
<form id="MainForm" method="post" runat="server">
<div align="center" style="width:99%;" bgcolor="#FFFFFF" id="container">
<input id="txtAction" name="txtAction" type="hidden" value="1"/>
<input id="deleteAction" name="deleteAction" type="hidden" value=""/>
<input id="deleteId" name="deleteId" type="hidden" value="" runat="server"/>
<input id="edmitPrice" name="edmitPrice" type="hidden"/>
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
				<td align="left" bgcolor="#eeeeee">��ҳ -&gt; ϵͳ���� -&gt; �۸���� -&gt; �����޸Ļ�Ա���۸�</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center">�����޸Ļ�Ա���۸�</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
                <table width="100%" border="1" cellpadding="3" cellspacing="1">
				   <tr>
                    <td nowrap="nowrap" class="item_caption">������:</td>
                    <td class="item_content"><select name="sltMemberCardLevel" id="sltMemberCardLevel" >
                      <option value="-1">��ѡ��</option>
                      <%for (int i = 0; i < model.MemberCardLevelList.Count; i++){%>
                          
                      <option value="<%=model.MemberCardLevelList[i].Id%>"><%=model.MemberCardLevelList[i].Name%></option>
                      <%
                      } %>
                    </select></td>
                  </tr>
                  <tr>
                    <td nowrap="nowrap" class="item_caption">ҵ������:</td>
                    <td class="item_content"><div id="factorMemory">
                    <select name="sltBusinessType" id="sltBusinessType" onchange="queryPriceSet(this)">
                      <option value="-1">��ѡ��</option>
                      <%for (int i = 0; i < model.BusinessTypeList.Count; i++){ %> 
                      
                                              
                          <option value="<%=model.BusinessTypeList[i].Id%>"><%=model.BusinessTypeList[i].Name%></option>
                      <%   
                        }
                        %>
                    </select><input id="btnQuery" name="btnQuery" type="button" value="��ѯ" onclick="queryQuickly()" class="buttons"/></div></td>
                    </tr>
                </table>
                </td>
				<td width="3%">&nbsp;</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="left"><input name="btnSelectStandardPrice" type="button" class="buttons"  value="ѡ�����м۸�"/></td>
				<td width="3%">&nbsp;</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td>
				������۸�:<input id="txtNewPrice" name="txtNewPrice" type="text" value="" class="datetexts" />
				<input type="button" value="�Ա�" onclick="arrangUpdatePrice();" />
				<% if (arrangUpdate) {%>
					<input type="button" value="ȷ���޸�" onclick="batchUpdatePrice();" />
				<%}%>
				</td>
				<td width="3%">&nbsp;</td>
            </tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center"><table width="100%" border="1" cellpadding="3" cellspacing="1">
                  <tr>
                    <th nowrap="nowrap">
                        <input type="checkbox" id="cbSelectAll" checked="checked" name="cbSelectAll" onclick="selectedAllClick()"/>
                    </th>
                    <th nowrap="nowrap">ҵ������</th>
                    <% if (-1!=lngMemberCardLevel){%>
                    <th nowrap="nowrap">������</th>
                    <%} %>
                    <%for (int i = 0; i < model.PriceFactor.Count; i++){%>
                    <th nowrap="nowrap"><%=model.PriceFactor[i].DisplayText%></th>
                    <%}%>
					<th width="1%" nowrap="nowrap">�ɱ�<br />�۸�</th>
					
					<th width="1%" nowrap="nowrap">��׼<br />�۸�</th>
					
					<th width="1%" nowrap="nowrap">�<br />�۸�</th>
					
					<th width="1%" nowrap="nowrap">����<br />�۸�</th>
					
                    <th nowrap="nowrap">����<br/>���</th>
                    <%if (arrangUpdate)
					  { %>
					<th width="1%" nowrap="nowrap">�޸ĺ�</th>
					<%} %>
                    
                    <th nowrap="nowrap">������<br/>�ۿ�%</th>
                    <th nowrap="nowrap"></th>
                  </tr>
                    <%for (int i = 0; i < model.BusinessTypePriceSetList.Count; i++){%>  
                    <tr class="detailRow">
                         <td align="center">
                         
                         <input type="checkbox" checked="checked" value="<%=model.BusinessTypePriceSetList[i].Id %>" name="chky" id="chky<%=model.BusinessTypePriceSetList[i].Id %>"/>
                        
                         </td>
                         <td align="center"><%=model.BusinessTypePriceSetList[i].BusinessType.Name%></td>
                    <% if ( -1!=lngMemberCardLevel){%>
                         <td align="center"><%=model.BusinessTypePriceSetList[i].TargetName %></td>
                    <%} %>
                         
                        <%for (int j = 0; j < model.PriceFactor.Count; j++){%>
                            <td align="center" nowrap="nowrap"><%=model.BusinessTypePriceSetList[i].Texts[j]%></td>
                         <%}%>
                    <td class="num"><%=model.BusinessTypePriceSetList[i].CostPrice %></td>
                    
                    <td class="num"><%=model.BusinessTypePriceSetList[i].StandardPrice %></td>
                    
                    <td class="num"><%=model.BusinessTypePriceSetList[i].ActivityPrice %></td>
                    
                    <td class="num"><%=model.BusinessTypePriceSetList[i].ReservePrice %></td>
                    
                    <td class="tdEdPrice"><%=model.BusinessTypePriceSetList[i].NewPrice %></td>
                    <%if (arrangUpdate)
					  { %>
                    <td><input id="newPrice<%=model.BusinessTypePriceSetList[i].Id %>" name="newPrice<%=model.BusinessTypePriceSetList[i].Id %>"
                    type="text" style="width:40px;" value="<%=newPrice==0?model.BusinessTypePriceSetList[i].NewPrice:newPrice %>" /></td>
                    <%} %>
                    <td class="num"><%=model.BusinessTypePriceSetList[i].PriceConcession %></td>
                  </tr>
                    <%}%>
                    
                </table></td>
				<td width="3%">&nbsp;<input runat="server" ID="isQuery" type="hidden" name="isQuery" value="0" /></td>
			</tr>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="2" align="right"></td>
				<td></td>
			</tr>
			<tr height="5">
				<td><img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td><img src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
			</tr>
		</table>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addFactorRelation.aspx.cs" Inherits="priceBaseData_addFactorRelation" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Workflow.Support" %>
<%@ Import Namespace="Workflow.Da.Domain" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=strTitle%></title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/priceBaseData/addFactorRelation.js"></script>
<script type="text/javascript" language="javascript">
    var businessTypeId='<%= businessTypeId%>';
    var priceFactorId='<%=priceFactorId%>';
    var passivePriceFactorId='<%=passivePriceFactorId %>';
</script>
<base target="_self" />
</head>
<body style="text-align:center" onload="loadEdmitData()">
<form id="form1" runat="server" method="post">
<input type="hidden"  id="hiddTag" name="actionTag"/>
<input type="hidden"  id="hidFactorRelationId" name="deleteFactorRelationId" runat="server"/>
 <div align="center" style="width:99%" bgcolor="#ffffff" id="container">
  <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif" /></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10" /></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td bgcolor="#FFFFFF">
		<table width="100%" border="0" cellspacing="0">
			<tr>
				<td></td>
				<td align="left" bgcolor="#eeeeee">首页 -&gt; 价格基础数据维护-&gt;<%=strTitle%></td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center"><%=strTitle%></td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
				   <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
				   	<tr>
		               <td nowrap class="item_caption">业务类型</td>
					    <td class="item_content" align="left">
					        <select id="sltBusinessType" name="businessType">
					        <option value="-1">请选择</option>
					        <%
                                if (null != model.BusinessTypeTempList)
                                {
                                    foreach (BusinessType bus in model.BusinessTypeTempList)
                                    { %>
					        <option value="<%=bus.Id %>"><%=bus.Name%></option>
					        <%}
                           }%>
					        </select>
					    </td>
					</tr>
					<tr>
		               <td nowrap class="item_caption">依赖的价格因素</td>
					    <td class="item_content" align="left">
					        <select id="sltPricesFactor" name="pricesFactor">
					        <option value="-1">请选择</option>
					        <%
                                if (null != model.PriceFactorList)
                                {
                                    foreach (PriceFactor priceFactor in model.PriceFactorList)
                                    { %>
					        <option value="<%=priceFactor.Id %>"><%=priceFactor.DisplayText%></option>
					                <%}
                           }%>
					        </select>
					    </td>
					</tr>
					<tr>
						 <td nowrap class="item_caption">被依赖的价格因素</td>
						 <td class="item_content" colspan="3" align="left">
						     <table border="0" align="left" width="100%">
				               <tr>
						         <%int count = 0;
                                 if (null != model.PriceFactorList)
                                 {
                                     foreach (PriceFactor priceFactor in model.PriceFactorList)
                                     {
                                         if (count % 5 == 0 && count != 0)
                                         {  
                                              %>
                                                        </tr> 
                                                    <%
                                                     }%> 
                                                  <td>
                                                     <label onclick="SelectedCheckBox(priceFactor<%=priceFactor.Id %>)"><%=priceFactor.DisplayText%></label>
                                                     <input type="checkbox" name="cbPriceFactor" id="priceFactor<%=priceFactor.Id %>" value="<%=priceFactor.Id %>"/>
                                                     </td>
						                        <%      count++;
                                  }
                              }%>
                             </tr>  
                          </table>
						 </td>
					</tr>
					<tr>
					    <td nowrap class="item_caption">备注</td>
					    <td nowrap class="item_content"><asp:TextBox ID="Memo" runat="server" Rows="3" TextMode="MultiLine" Width="664px" MaxLength="200"></asp:TextBox></td>
					</tr>
				</table>
			</tr>
			<tr>
				<td colspan="4" align="left"  class="bottombuttons">
                    <asp:Button ID="btnSave" runat="server" CssClass="buttons" OnClick="BtnSave_Click" OnClientClick="return checkProcess();" Text="保存" />&nbsp;
                    <input id="btnCancel" name="btnCancel" class="buttons" type="button" onclick ="window.close();" value="关闭" runat="server" />
              </td>
			</tr>
			<tr id="tr1" runat="server">
			    <td width="3%">&nbsp;</td>
			    <td width="94%" align="center">
			    <table border="1" cellpadding="3" cellspacing="1" width="100%">
					<tr>
					<th  nowrap="nowrap" align="center" width="10%">业务类型</th>
					<th  nowrap="nowrap" align="center" width="10%">依赖的价格因素</th>
					<th  nowrap="nowrap" align="center" width="10%">被依赖的价格因素</th>
					<th  nowrap="nowrap" align="center" width="10%">备注</th>
					<th  nowrap width="10%"></th>
					</tr>
					<%
                        if (null != model.FactorRelationList)
                        {
                             foreach (FactorRelation factorRelation in model.FactorRelationList)
                            { 
                                %>
                                <tr class="detailRow">
                                    <td class="pBusinessTypeName"><%=factorRelation.BusinessTypeName %></td>
                                    <td class="pPriceFactorName"><%=factorRelation.PriceFactorDisplayText %></td>
                                    <td class="pPriceFactorName2"><%=factorRelation.PriceFactorDisplayText2 %></td>
                                    <td class="pMemo"><%=factorRelation.Memo%></td>
					                 <td>
					                    <input type="hidden" name="factorRelationId" value="<%=factorRelation.Id%>"/>
					                    <input type="hidden" name="businessTypeId" value="<%=factorRelation.BusinessTypeId%>"/>
					                    <input type="hidden" name="priceFactorId" value="<%=factorRelation.PriceFactorId%>"/> 
					                    <input type="hidden" name="priceFactorId2" value="<%=factorRelation.PriceFactorId2%>"/> 
					                    <a href="#" onclick="edmitFactorRelation(this)" >编辑</a>&nbsp;
					                    <a href="#" onclick="deleteFactorRelation(this)">删除</a>
					                 </td> 
					               </tr>
    					           
                           <% 
                            } %>
                       <tr>
                         <td bgcolor="#eeeeee" align="right" colspan="5">
                         <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                         </webdiyer:AspNetPager>
                         </td>
                    </tr> 
                    <%} %>
				</table>
			    </td>
			    <td width="3%">&nbsp;</td>
			</tr>
			<tr height="5">
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
			</tr>
		</table>
		</td>
	</tr>
</table>
  </td>
  </tr>
  	<tr>
		<td width="11"><img alt="" src="../images/white_main_bottom_left.gif"/></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"/></td>
		<td width="10"><img alt="" src="../images/white_main_bottom_right.gif"/></td>
	</tr>
</table>
</div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addPriceFactor.aspx.cs" Inherits="priceBaseData_addPriceFactor" %>

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
<script type="text/javascript" src="../js/priceBaseData/addPriceFactor.js"></script>
<script type="text/javascript" language="javascript">
var isNotDisplay='<%=strIsDisplay %>';//是否显示
var isNotUsed='<%=strIsUsed%>';//是否使用
var isDisplayText='<%=Constants.IS_DISPLAY_TEXT%>';
var isDisplayKey='<%=Constants.IS_DISPLAY_KEY  %>';
var notDisplayText='<%=Constants.NOT_DISPLAY_TEXT%>';
var notDisplayKey='<%=Constants.NOT_DISPLAY_KEY  %>';
var isUsedText='<%=Constants.IS_USED_TEXT%>';
var isUsedKey='<%=Constants.IS_USED_KEY%>';
var notUsedText='<%=Constants.NOT_USED_TEXT%>';
var notUsedKey='<%=Constants.NOT_USED_KEY%>';
</script>
<base target="_self" />
</head>
<body style="text-align:center" onload="loadEdmitData()">
<form id="form1" runat="server" method="post">
<input type="hidden"  id="hiddTag" name="actionTag"/>
<input type="hidden"  id="hidPriceFactorId" name="deletePriceFactorId" runat="server"/>
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
					     <td nowrap class="item_caption">名称</td>
						 <td class="item_content" align="left"><input id="txtPriceFactorName" name="priceFactorName" type="text" runat="server"/></td>
						 <td nowrap class="item_caption">显示文本</td>
						 <td class="item_content" colspan="3" align="left"><input id="txtDisplayText" name="displayText" type="text" runat="server"/></td>
					</tr>
					<tr>
					     <td nowrap class="item_caption">使用时是否显示</td>
						 <td class="item_content" align="left">
						 <select id="sltIsDisplay" name="isDisplay">
						 <option value="-1">请选择</option>
						 <option value="<%=Constants.IS_DISPLAY_KEY %>"><%=Constants.IS_DISPLAY_TEXT%></option>
						 <option value="<%=Constants.NOT_DISPLAY_KEY %>"><%=Constants.NOT_DISPLAY_TEXT%></option>
						 </select>
						 </td>
						 <td nowrap class="item_caption">是否使用</td>
						 <td class="item_content" colspan="3" align="left">
						 <select id="sltUsed" name="isUsed">
						 <option value="-1">请选择</option>
						 <option value="<%=Constants.IS_USED_KEY %>"><%=Constants.IS_USED_TEXT%></option>
						 <option value="<%=Constants.NOT_USED_KEY %>"><%=Constants.NOT_USED_TEXT%></option>
						 </select>
						 </td>
					</tr>
                  <tr>
						<td nowrap class="item_caption">对应的表</td>
						 <td class="item_content" align="left"><input id="txtTargetTable" name="targetTable" type="text" value="FACTOR_VALUE" runat="server" readonly="readonly"/></td>
						 <td nowrap class="item_caption">对应值的列</td>
						 <td class="item_content" align="left"><input id="txtTargeValueColumn" name="targetValueColumn" type="text" value="VALUE" runat="server"  readonly="readonly"/></td>
						 <td nowrap class="item_caption">对应文本的列</td>
						 <td class="item_content" align="left"><input id="txtTargetTextColumn" name="targetTextColumn" type="text" value="TEXT" runat="server"  readonly="readonly"/></td>
                  </tr>
				</table>
			</tr>
			<tr>
				<td colspan="4" align="left"  class="bottombuttons">
				<input id="btnNewPriceFactor" name="newPriceFactor" class="buttons" type="button" onclick ="addPriceFactor();" value="新增价格因素值" runat="server" />
                    <asp:Button ID="btnSave" runat="server" CssClass="buttons" OnClick="BtnSave_Click" OnClientClick="return checkProcess();" Text="保存" />&nbsp;
                    <input id="btnCancel" name="btnCancel" class="buttons" type="button" onclick ="window.close();" value="关闭" visible="false" runat="server" />
              </td>
			</tr>
			<tr id="tr1" runat="server">
			    <td width="3%">&nbsp;</td>
			    <td width="94%" align="center">
			    <table border="1" cellpadding="3" cellspacing="1" width="100%">
					<tr>
					<th  nowrap="nowrap" align="center" width="10%">名称</th>
					<th  nowrap="nowrap" align="center" width="10%">显示文本</th>
					<th  nowrap="nowrap" align="center" width="10%">对应的表</th>
					<th  nowrap="nowrap" align="center" width="10%">对应值的列</th>
					<th  nowrap="nowrap" align="center" width="10%">对应文本的列</th>
					<th  nowrap="nowrap" align="center" width="10%">使用时是否显示</th>
					<th  nowrap="nowrap" align="center" width="10%">是否使用</th>
					<th  nowrap width="10%"></th>
					</tr>
					<%
                        if (null != model.PriceFactorList)
                        {
                            foreach (PriceFactor priceFactor in model.PriceFactorList)
                            { 
                            %>
                            <tr class="detailRow">
                                <td class="pName"><%=priceFactor.Name%></td>
                                <td class="pText"><%=priceFactor.DisplayText%></td>
                                <td class="pTable"><%=priceFactor.TargetTable%></td>
                                <td class="pColumn"><%=priceFactor.TargetValueColumn%></td>
                                <td class="pTextColumn"><%=priceFactor.TargetTextColumn%></td>
					              <td class="pIsDisplay"><%=Constants.GetPriceFactorDisplayStatus(priceFactor.IsDisplay)%></td>
					              <td class="pUsed"><%=Constants.GetPriceFactorDisplayStatus(priceFactor.Used)%></td> 
					             <td>
					                <input type="hidden" name="priceFactorId" value="<%=priceFactor.Id%>"/> 
					                <a href="#" onclick="edmitPriceFactor(this)" >编辑</a>&nbsp;
					                <a href="#" onclick="deletePriceFactor(this)">删除</a>
					             </td> 
					           </tr>
                       <%  }
                       }%>
                       <tr>
                         <td bgcolor="#eeeeee" align="right" colspan="8">
                         <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                         </webdiyer:AspNetPager>
                         </td>
                    </tr> 
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

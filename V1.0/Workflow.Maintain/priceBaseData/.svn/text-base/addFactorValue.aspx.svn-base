<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addFactorValue.aspx.cs" Inherits="priceBaseData_addFactorValue" %>
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
<script type="text/javascript" src="../js/priceBaseData/addFactorValue.js"></script>
<script type="text/javascript" language="javascript">
   var priceFactorId=<%=priceFactorId %>;
</script>
<base target="_self" />
</head>
<body style="text-align:center" onload="loadEdmitData()">
<form id="form1" runat="server" method="post">
<input type="hidden"  id="hiddTag" name="actionTag"/>
<input type="hidden"  id="hidFactorValueId" name="deleteFactorValueId" runat="server"/>
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
					    <td nowrap class="item_caption">因素值</td>
						<td class="item_content" align="left"><input id="txtFactorValue" name="factorValue" type="text" runat="server"/></td>
					</tr>
                    <tr>
						<td nowrap class="item_caption">所属价格因素</td>
						<td class="item_content" colspan="3" align="left">
						    <select id="sltPriceFactor" name="priceFactor">
						    <option value="-1">请选择</option>
						    <%
						        if (null != model.PriceFactorList)
                                {
                                    %>
                          <%
                                    foreach (PriceFactor priceFactor in model.PriceFactorList)
                                    {
                                        %>
                          <option value="<%=priceFactor.Id %>"><%=priceFactor.DisplayText%></option>
                          <%
                                    }
                                }
                              %>
                          </select>
						 </td>
                    </tr>
				</table>
			</tr>
			<tr>
				<td colspan="3" align="left"  class="bottombuttons">
                    <asp:Button ID="btnSave" runat="server" CssClass="buttons" OnClick="BtnSave_Click" OnClientClick="return checkProcess();" Text="保存" />&nbsp;
                    <input id="btnCancel" name="btnCancel" class="buttons" type="button" onclick ="window.close();" value="关闭" runat="server" />
              </td>
			</tr>
			<tr id="tr1" runat="server">
			    <td width="3%">&nbsp;</td>
			    <td width="94%" align="center">
			    <table border="1" cellpadding="3" cellspacing="1" width="100%">
					<tr>
					<th  nowrap="nowrap" align="center" width="40%">因素值</th>
					<th  nowrap="nowrap" align="center" width="20%">所属价格因素</th>
					<th  nowrap width="10%"></th>
					</tr>
					<%
                        if (null != model.FactorValueList)
                        {
                            foreach (FactorValue factorValue in model.FactorValueList)
                            { 
                            %>
                            <tr class="detailRow">
                                <td class="mName"><%=factorValue.Text%></td>
					              <td class="mPriceFactor"><a href="#" onclick="pricePactorDetail(this);"><%=factorValue.Value%></a></td>
					             <td>
					                <input type="hidden" name="priceFactorId" value="<%=factorValue.PriceFactorId%>"/> 
					                <input type="hidden" name="factorValueId" value="<%=factorValue.Id %>"/> 
					                <a href="#" onclick="edmitFactorValue(this)" >编辑</a>&nbsp;
					                <a href="#" onclick="deleteFactorValue(this)">删除</a>
					             </td> 
					           </tr>
                       <%  }
                       }%>
                       <tr>
                         <td bgcolor="#eeeeee" align="right" colspan="3">
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

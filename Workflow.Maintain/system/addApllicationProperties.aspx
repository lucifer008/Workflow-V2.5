<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addApllicationProperties.aspx.cs" Inherits="system_addApllicationProperties" %>
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
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/system/addApllicationProperties.js"></script>
<base target="_self" />
</head>
<body style="text-align:center">
<form id="form1" runat="server" method="post">
<input type="hidden"  id="hiddTag" name="actionTag"/>
<input type="hidden"  id="hidId" name="deleteId" runat="server"/>
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
						<td nowrap class="item_caption">参数Id</td>
						<td class="item_content" align="left"><input id="txtPropertyId" readonly="readonly" name="propertyId" type="text" runat="server"/></td>
						<td nowrap class="item_caption">参数值</td>
						<td class="item_content" align="left"><input id="txtPropertyValue" name="propertyValue" type="text" runat="server"/></td>
					</tr>
				</table>
			</tr>
			<tr>

			    <td align="center" colspan="3">
                    <asp:Button ID="btnInit" CssClass="buttons" OnClientClick="return initCheck();" Text="初始化" Visible="false" OnClick="btnInit_Click" runat="server"/>&nbsp;
                    <asp:Button ID="btnSave" CssClass="buttons" OnClientClick="return checkProcess();" Text="保存" OnClick="BtnSave_Click" runat="server"/>&nbsp;
                    <input id="btnCancel" name="btnCancel" class="buttons" type="button" onclick ="window.close();" value="关闭" visible="false" runat="server" />
              </td>
			</tr>
			<tr id="tr1" runat="server">
			    <td width="3%">&nbsp;</td>
			    <td width="94%" align="center">
			    <table border="1" cellpadding="3" cellspacing="1" width="100%">
					<tr>
					<th  nowrap="nowrap" align="center" width="40%">参数Id</th>
					<th  nowrap="nowrap" align="center" width="40%">参数值</th>
					<th  nowrap width="10%"></th>
					</tr>
					<%
                        if (null != model.AppliactionPropertyList)
                        {
                            foreach (ApplicationProperty ap in model.AppliactionPropertyList)
                            { 
                            %>
                            <tr class="detailRow">
                                <td class="propertyId"><%=ap.PropertyId%></td>
                                 <td class="propertyValue"><%=ap.PropertyValue%></td>
					             <td>
					                <input type="hidden" name="applicationPropertyId" value="<%=ap.Id %>"/> 
					                <a href="#" onclick="edmitApplicationProperty(this)" >编辑</a>&nbsp;
					                <a href="#" onclick="deleteApplicationProperty(this)">删除</a>
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
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addBusinessType.aspx.cs" Inherits="priceBaseData_addBusinessType" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Workflow.Support" %>
<%@ Import Namespace="Workflow.Da.Domain" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=strTitle%></title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/priceBaseData/addBusinessType.js"></script>
<script type="text/javascript" language="javascript">
        var businessTypeName='<%=businessTypeName %>';
        var businessIsNotNeedIn='<%=businessTypeIsNotInWath %>';
        var isInWatch='<%=Constants.NEED_IN_WATCH_KEY %>';
        var notWatch='<%=Constants.NEED_IN_WATCH_NOT_KEY %>';
</script>
<base target="_self" />
</head>
<body style="text-align:center" onload="loadEdmitInfo();">
<form id="form1" runat="server" method="post">
<input type="hidden"  id="hiddTag" name="actionTag"/>
<input type="hidden"  id="hidBusinessTypeId" name="deleteBusinessTypeId" runat="server"/>
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
						<td colspan="3" class="item_content" align="left"><input id="txtBusinessTypeName" name="businessTypeName" type="text" /></td>
					</tr>
                    <tr>
						<td nowrap class="item_caption">是否需要抄表</td>
						<td class="item_content" colspan="3" align="left">
						    <select id="sltIsNotInWatch" name="isNotInWatch">
						    <option value="-1">请选择</option>
						    <option value="<%=Constants.NEED_IN_WATCH_KEY %>"><%=Constants.NEED_IN_WATCH_TEXT%></option>
						    <option value="<%=Constants.NEED_IN_WATCH_NOT_KEY %>"><%=Constants.NEED_IN_WATCH_NOT_TEXT%></option>
						    </select>
						 </td>
                    </tr>
				</table>
			</tr>
			<tr>
				<td colspan="3" align="left" class="bottombuttons">
                    <asp:Button ID="btnSave" runat="server" CssClass="buttons" OnClick="BtnSave_Click" OnClientClick="return checkProcess();" Text="保存" />&nbsp;
                    <input id="btnCancel" name="btnCancel" class="buttons" type="button" onclick ="window.close();" style="display:none" value="关闭" /></td>
			</tr>
			<tr id="tr1">
			    <td width="3%">&nbsp;</td>
			    <td width="94%" align="center">
			    <table border="1" cellpadding="3" cellspacing="1" width="100%">
					<tr>
					<th  nowrap="nowrap" align="center" width="60%">名&nbsp;&nbsp;称</th>
					<th  nowrap width="20%">是否需要抄表</th>
					<th  nowrap width="10%"></th>
					</tr>
					<%
                        if (null != model.BusinessTypeList)	
                        {
                            foreach (BusinessType businessType in model.BusinessTypeList)
                            { 
                            %>
                            <tr class="detailRow">
                                
                                <td class="bName"><%=businessType.Name%></td>
					              <td class="bMachinename"><%=Constants.GetInWatchIsNot(businessType.NeedRecordMachine)%></td>
					             <td>
					                <input type="hidden" name="businessTypeId" value="<%=businessType.Id %>"/> 
					                <a href="#" onclick="edmitBusinessType(this)">编辑</a>&nbsp;
					                <a href="#" onclick="deleteBusinessType(this)">删除</a>
					             </td> 
					           </tr>
                       <%  }
                       } %>
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

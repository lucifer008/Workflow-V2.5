<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addPrintDemandDetail.aspx.cs" Inherits="orderBaseData_addPrintDemandDeteil" %>

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
<script type="text/javascript" src="../js/orderBaseData/addPrintDemandDetail.js"></script>
<script language="javascript" type="text/javascript">
    var pId='<%=strPrintDemandId %>';
</script>
<base target="_self" />
</head>
<body style="text-align:center" onload="LoadEdmit();">
<form id="form1" runat="server" method="post">
<input type="hidden"  id="hiddTag" name="actionTag"/>
<input type="hidden"  id="hidPrintDemandDetailId" name="deletePrintDemandDetailId" runat="server"/>
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
						<td nowrap class="item_caption">所属印制要求</td>
						<td class="item_content" align="left">
						<select id="sltPrintDemand" name="printDemand">
						<option value="-1">请选择</option>
						<%
                            if (null != model.PrintDemandList)
                            {
                                foreach (PrintDemand pd in model.PrintDemandList)
                                { %>
						<option value="<%=pd.Id %>"><%=pd.Name%></option>
						        <%}
                            } %>
						</select>
						</td>
					</tr>
					<tr>
						<td nowrap class="item_caption">名称</td>
						<td class="item_content" align="left"><input id="txtPrintDemandDetailName" name="printDemandDetailName" maxlength="20" type="text" runat="server"/></td>
					</tr>
					<tr>
						<td nowrap class="item_caption">备注</td>
						<td class="item_content" align="left"><textarea name="memo" id="txtMemo" cols="95" rows="3" style="width: 100%" runat="server"></textarea></td>
					</tr>
				</table>
			</tr>
			<tr>
				<td colspan="2" align="left"  class="bottombuttons">
                    <asp:Button ID="btnSave" runat="server" CssClass="buttons" OnClick="BtnSave_Click" OnClientClick="return checkProcess();" Text="保存" />&nbsp;
                    <input id="btnCancel" name="btnCancel" class="buttons" type="button" onclick ="window.close();" value="关闭" visible="false" runat="server" />
              </td>
			</tr>
			<tr id="tr1" runat="server">
			    <td width="3%">&nbsp;</td>
			    <td width="94%" align="center">
			    <table border="1" cellpadding="3" cellspacing="1" width="100%">
					<tr>
					<th  nowrap="nowrap" align="center" width="30%">所属印制要求</th>
					<th  nowrap="nowrap" align="center" width="30%">名&nbsp;&nbsp;称</th>
					<th  nowrap="nowrap" align="center" width="30%">备&nbsp;&nbsp;注</th>
					<th  nowrap width="10%"></th>
					</tr>
					<%
                        if (null != model.PrintDemandDetailList)
                        {
                            foreach (PrintDemandDetail pdd in model.PrintDemandDetailList)
                            { 
                            %>
                            <tr class="detailRow">
                            <td class="mPrintDemand"><%=pdd.PrintDemandName%></td>
                                <td class="mName"><%=pdd.Name%></td>
                                 <td class="mMemo"><%=pdd.Memo%></td>
					             <td>
					                <input type="hidden" name="printDemandDetialId" value="<%=pdd.Id %>"/> 
					                <input type="hidden" name="printDemandId" value="<%=pdd.PrintDemandId %>"/> 
					                <a href="#" onclick="edmitPrintDemandDetial(this)" >编辑</a>&nbsp;
					                <a href="#" onclick="deletePrintDemandDetial(this)">删除</a>
					             </td> 
					           </tr>
                       <%  }
                       }%>
                       <tr>
                         <td bgcolor="#eeeeee" align="right" colspan="4">
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

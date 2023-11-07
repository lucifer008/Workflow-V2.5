<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnalyzeDebtTime.aspx.cs"
    Inherits="FinanceAnalyzeDebtTime" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>帐龄分析</title>
<link href="../../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/js/jquery.js"></script>
<script type="text/javascript" src="/js/default.js"></script>
</head>

<body  style="text-align:center">
<form id="form1" runat="server">
<div align="center" style="width:99%" bgcolor="#ffffff" id="container">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="12"><img alt="" src="../../images/white_main_top_left.gif"
			width="12" height="11" border="0"/></td>
      <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif"
			width="10" height="10"/></td>
      <td width="12"><img alt="" src="../../images/white_main_top_right.gif"
			width="12" height="11"/></td>
    </tr>
    <tr>
      <td colspan="3" bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td></td>
            <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 帐龄分析</td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">帐龄分析</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">
<table width="100%" border="1" cellpadding="2" cellspacing="1">
          <tr>
            <td nowrap class="item_caption">客户名称:</td>
            <td class="item_content"><input name="UserName" type="text" class="texts" />
             </td>
          </tr>
          <tr>
            <td colspan="2" align="right"><input name="Submit" type="submit" class="buttons" value="查询" /><input name="print" type="button" class="buttons" value="打印" id="Button1" onserverclick="Button1_ServerClick" runat="server" /></td>
          </tr>
        </table>			</td>
		  </tr>
		  <tr>
				<td width="3%">&nbsp;</td>
			<td>查询结果:</td>
		  </tr>		  
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center" style="padding-bottom:5px"><table width="100%" border="1" cellpadding="2" cellspacing="1">
              <tr>
                <th width="5%" nowrap>NO</th>
                <th  nowrap>客户名称</th>
                <th width="10%" nowrap>10天以内</th>
                <th width="10%" nowrap>10-30天</th>
                <th width="10%" nowrap>30-60天</th>
                <th width="10%" nowrap>60-90天&nbsp;</th>
                <th width="10%" nowrap>90-120天</th>
                <th width="10%" nowrap>120天以上</th>
                <th width="10%" nowrap>合计</th>
              </tr>
              
              <% int i = 1; foreach (DictionaryEntry de in model.Map)
				 { %>
              <tr class="detailRow">  
				 <% Workflow.Action.Finance.AnalyzeData val = (Workflow.Action.Finance.AnalyzeData)de.Value; %>
				 <td><%=i %></td>
				 <td><%=val.CustomerName %></td>
				 <% foreach (decimal data in val.Result)
		{ %>
					<td><%=data %></td>
				 <%
	} %>
              </tr>
              <% i++;
			 } %>
			 <tr class="detailRow">
				<td>总计</td>
				<td></td>
				<% foreach (decimal val in model.ResultSum){ %>
					<td><%=val %></td>
				<%} %>
			 </tr>
            </table></td>
            <td width="3%">&nbsp;</td>			
		  </tr>		  
          <tr height="5">
            <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
            <td bgcolor="#eeeeee">&nbsp;</td>
            <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
          </tr>
        </table></td>
    </tr>
    <tr>
      <td width="12"><img alt="" src="../../images/white_main_bottom_left.gif"
			width="12" height="11"/></td>
      <td bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif"
			width="10" height="10"/></td>
      <td width="12"><img alt="" src="../../images/white_main_bottom_right.gif"
			width="12" height="11"/></td>
    </tr>
  </table>
</div>
</form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="logcounters_SearchResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>计数器查询</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
</head>
<body style="text-align:center">
<form id="MainForm" method="post" runat="server">
<input id="txtAction" name="txtAction" type="hidden"/>
<input id="hiddMachineName" name="machineName" type="hidden"/>
<div align="center" style="width:99%" bgcolor="#ffffff" id="container">
<table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">	
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0">
          <tr>
            <td></td>
            <td align="left" bgcolor="#eeeeee">首页 -&gt; 抄表处理 -&gt; 计数器查询</td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">计数器查询</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">&nbsp;</td>
            <td width="3%">&nbsp;</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellpadding="3" cellspacing="1">
                <tr>
                  <th width="10%" nowrap="nowrap">机器</th>
                  <th width="10%" nowrap="nowrap">纸型</th>
                  <th width="10%" nowrap="nowrap">颜色</th>
                  <th width="15%" nowrap="nowrap">数量</th>
                  <th width="10%" nowrap="nowrap">合计</th>
                </tr>
                <% int rowCount = 0;
                   bool isAmount=false;
                   decimal amount=0;
                	foreach(Workflow.Da.Domain.DailyRecordMachine val in model.DailyRecordMachines){ %>
                <tr>
					<%
					if(rowCount==0){	
						if(model.Map[val.MachineTypeId]!=null){
					 Workflow.Action.LogCounters.DataUnite unite = (Workflow.Action.LogCounters.DataUnite)model.Map[val.MachineTypeId];
						rowCount=unite.UniteCount;
							isAmount=true;
							amount=unite.Amount;
							
					 %>
						<td  rowspan="<%=rowCount %>"><%=val.MachineTypeName %></td>
					<%}}%>
					
					<td><%=val.PaperSpecificationName %></td>
					<td><%=Workflow.Support.Constants.GetColorType(val.ColorType) %></td>
					<td><%=val.InWatchCount%></td>
					
					
					<%if(isAmount) {%>
					<td rowspan="<%=rowCount %>"><%=amount %></td>
					<%
						isAmount = false;
					} %>
				</tr>
                <%rowCount--;
			  } %>
              </table></td>
            <td width="3%">&nbsp;</td>
          </tr>
		  <tr class="emptyButtonsUpperRowHight">
				<td colspan="3"><input name="Submit22"  type="submit" class="buttons" value="打印"/></td>
		  </tr>
          <tr height="5">
            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
            <td bgcolor="#eeeeee">&nbsp;</td>
            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
          </tr>
        </table></td>
    </tr>
  </table>
		</td>
	</tr>
	<tr>
		<td width="11"><img alt="" src="../images/white_main_bottom_left.gif"></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"></td>
		<td width="10"><img alt="" src="../images/white_main_bottom_right.gif"></td>
	</tr>
</table>
</div>
</form>
</body>
</html>


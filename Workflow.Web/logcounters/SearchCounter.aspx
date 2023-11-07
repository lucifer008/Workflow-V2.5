<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchCounter.aspx.cs" Inherits="SearchCounter" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Workflow.Da.Domain" %>
<%@ Import Namespace="Workflow.Support" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>计数器查询</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/Calendar2.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
<script type="text/javascript" src="../js/logcounters/SearchCounter.js"></script>
<%--<script type="text/javascript" src="../js/Accredit.js"></script>--%>
<script type="text/javascript">

</script>
</head>
<body style="text-align:center">
<form id="MainForm" method="post" runat="server">
<input id="txtAction" name="txtAction" type="hidden"/>
<input id="hiddMachineName" name="machineName" type="hidden"/>
<input id="hiddAction" name="hiddAction" type="hidden"  />
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
            <td align="center">
            <table width="100%" border="1" cellspacing="1" cellpadding="3">
                <tr>
                  <td class="item_caption">抄表时间</td>
                  <td class="item_content" colspan="3">
                      <input type="text" class="datetimetexts" id="txtBeginDate" runat="server" name="txtbeginDate" onfocus="setday(this)" readonly="readonly" size="16" maxlength="16"  />至
                      <input type="text" class="datetimetexts" id="txtEndDate" runat="server" name="txtEndDate" onfocus="setday(this)" readonly="readonly" size="16" maxlength="16" />
                   </td>
                   <td><input name="search"  type="button" onclick="clientSubmit();" class="buttons" value="查询"/></td>
                </tr>
                <tr>
                  <td align="right" colspan="4">
                      
                  </td>
                </tr>
              </table></td>
            <td width="3%">&nbsp;</td>
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
                  <th width="5%" align="center" nowrap="nowrap">NO</th>
                  <th width="25%" nowrap="nowrap">抄表时间</th>
                  <th width="24%" nowrap="nowrap">抄表用户</th>
                  <th width="14%" nowrap="nowrap"></th>
                </tr>
                
                 <% int i = 1; foreach (RecordMachineWatch val in model.RecordMachineWatchs)	{ %>
				<tr> 
				 <td><%=i %></td>
				 <td><%=val.RecordDateTime%></td>
				 <td><%=val.InsertUserName %></td>
				 <td><a href="SearchResult.aspx?id=<%=val.Id %>">详情</a></td>
                </tr>
				 <% i++;
	} %>
				  <tr>
					 <td bgcolor="#eeeeee" align="right" colspan="5">
						   <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
							</webdiyer:AspNetPager>
					 </td>
				  </tr>
              </table></td>
            <td width="3%">&nbsp;</td>
          </tr>
		  <tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
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

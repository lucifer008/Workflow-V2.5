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
<%--<script type="text/javascript" src="../js/Accredit.js"></script>--%>
<script type="text/javascript">
function queryProcess()
{
    $("#txtAction").attr("value","query");
    var sltMachineOptions=$("select[@name='sltMachine']")[0];
    var strMachineName="";
    for(var index=0;index<sltMachineOptions.length;index++)
    {
        if(sltMachineOptions[index].selected && sltMachineOptions[index].value!="-1")
        {
           strMachineName=$(sltMachineOptions[index]).text();
           $("#hiddMachineName").val(strMachineName);
           break;
        }
    }
  $("#MainForm").submit();
}
function printProcess()
{
    $("#txtAction").attr("value","print");
    $("#MainForm").submit();
}
</script>
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
            <td align="center">
            <table width="100%" border="1" cellspacing="1" cellpadding="3">
                <tr>
                  <td class="item_caption">抄表时间</td>
                  <td class="item_content" colspan="3">
                      <input type="text" class="datetimetexts" id="txtBeginDate" name="txtBeginDate" onfocus="setday(this)" readonly="readonly" size="16" maxlength="16"  />至
                      <input type="text" class="datetimetexts" id="txtEndDate" name="txtEndDate" onfocus="setday(this)" readonly="readonly" size="16" maxlength="16" />
                   </td>
                </tr>
                <tr class="querybuttons">
                  <td class="item_caption">机器</td>
                  <td  align="left" class="item_content">
                  <select name="sltMachine">
                      <option value="-1">请选择</option>
                      <%foreach (Machine var in model.MachineList)
                        {
                          %>
                          <option value="<%=var.Id%>"><%=var.Name%></option>    
                          <%
                        } %>
                    </select>
                  </td>
                </tr>
                <tr>
                  <td align="right" colspan="4">
                      <input name="btnQuery" onclick="queryProcess();"  type="button" class="buttons" value="查询"/>
                      <input name="print" onclick="printProcess();"  type="button" class="buttons" value="打印"/> 
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
                  <th width="16%" align="center" nowrap="nowrap">机器</th>
                  <th width="14%" nowrap="nowrap">纸型</th>
                  <th width="24%" nowrap="nowrap">颜色</th>
                  <th width="14%" nowrap="nowrap">数量</th>
                  <th width="16%" nowrap="nowrap">合计</th>
                </tr>
                <%
                    if (null != model.DailyRecordMachineList)
                    {
                        foreach (DailyRecordMachine var in model.DailyRecordMachineList)
                        {
                    %>
                <tr>
                  <td align="center"><%=var.Machine.Name%></td>
                  <td align="center"><%=var.PaperSpecification.Name%></td>
                  <td align="center"><%=Constants.GetColorType(var.ColorType)%></td>
                  <td class="num"><%=var.InWatchCount%></td>
                  <td class="num"><%=var.InWatchCount%></td>
                </tr>
                  <tr>
                     <td bgcolor="#eeeeee" align="right" colspan="5">
                           <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                            </webdiyer:AspNetPager>
                     </td>
                  </tr>
                    <%
                    }
                } %>
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

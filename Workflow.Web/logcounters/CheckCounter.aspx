<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckCounter.aspx.cs" Inherits="logcounters_CheckCounter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>核对</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" language="javascript" src="../js/default.js"></script>
    <script type="text/javascript" language="javascript" src="../js/escExit.js"></script>
    <script type="text/javascript" language="javascript" src="../js/logcounters/checkCounter.js"></script>
</head>
<body style="text-align:center" onload="pageLoad(<%=model.IsVerify %>);">
<form id="form1" runat="server">
<div align="center" style="width:99%" bgcolor="#ffffff" id="container">
<table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">	
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif"
			width="12" height="11"></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0">
          <tr>
            <td></td>
            <td align="left" bgcolor="#eeeeee">首页 -&gt; 抄表处理 -&gt; 核对</td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">核对</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellpadding="3" cellspacing="1">
                <tr>
                  <th width="20%" nowrap="nowrap">机器</th>
                  <th width="20%" nowrap="nowrap">纸型</th>
                  <th width="1%" nowrap="nowrap">颜色</th>
                  <th width="1%" nowrap="nowrap">上次计数</th>
                  <th width="1%" nowrap="nowrap">本次计数</th>
                  <th width="1%" nowrap="nowrap">实际制作数</th>
                  <th width="1%" nowrap="nowrap">补单量</th>
                  <th nowrap="nowrap">结果</th>
                </tr>
                <% foreach(Workflow.Da.Domain.MachineWatchConversionPaper conversion in model.ConversionList){ 
					   if(conversion.NeedRecordWatch){
					   %>
                <tr class="detailRow">
                  <td align="left"><%=conversion.Name %></td>
                  <td><%=conversion.PaperName.Replace("/A3出血","") %></td>
                  <td><%=conversion.PaperColor%></td>
                  <td class="num"><%=conversion.LastCount %></td>
                  <td class="num"><%=conversion.NewCount %></td>
                  <td class="num"><%=conversion.OrderUsePaperCount %></td>
                  <td class="num"><%=conversion.PatchCount %></td>
					  <% if(conversion.Result) {%>
						<td style="color:Green" class="num">数据正确</td>
					<%}else{
						 model.IsAllowVerify = false;
					%>
						<td style="color:Red" class="num">数据有误差(<%=conversion.ResultValue %>)</td>
					<%} %>
                </tr>
                <%} }%>
              </table></td>
            <td width="3%">&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="left">打印机计数器与实际制作情况不符，请查明原因，然后创建补单。</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="left"><input type="button" class="buttons" onclick="addCompensateUsedPaper(<%=model.RecordMachineWatchId %>)" value="新增补单" /></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellpadding="3" cellspacing="1">
                <tr>
                  <th width="15%" nowrap="nowrap">机器</th>
                  <th width="10%" nowrap="nowrap">纸型</th>
                  <th width="10%" nowrap="nowrap">颜色</th>
                  <th width="10%" nowrap="nowrap">数量</th>
                  <th width="20%" nowrap="nowrap">责任人</th>
                  <th nowrap="nowrap">备注</th>
                  <th width="5%">操作</th>
                </tr>
                <%if (null != model.CompensateUsedPaperList)
				  {%>
                <%	foreach (Workflow.Da.Domain.CompensateUsedPaper compensate in model.CompensateUsedPaperList)
				  { %>
               <tr>
                  <td height="18" align="left"><%=compensate.MachineType.Name%></td>
                  <td align="left"><%=compensate.PaperSpecification.Name %></td>
                  <td align="left"><%=Workflow.Support.Constants.GetColorType(compensate.ColorType) %></td>
                  <td class="num"><%=compensate.UsedPaperCount %></td>
                  <%string cmployeeStr = ""; foreach (Workflow.Da.Domain.Employee employee in compensate.EmployeeList)
					{
						cmployeeStr += " " + employee.Name;
					}%>
                  <td align="left"><%=cmployeeStr%></td>
                  <td><%=compensate.Memo %></td>
                  <td nowrap="nowrap"><a href="javascript:editCompensateUsedPaper(<%=model.RecordMachineWatchId %>,<%=compensate.Id %>)">修改</a>
                   <a href="javascript:deleteCompensate(<%=compensate.Id %>)">删除</a></td>
                </tr>
                <%}
			  }%>
              </table></td>
            <td>&nbsp;</td>
          </tr>
          
		  <tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
		  </tr>
          <tr class="bottombuttons">
            <td width="3%">&nbsp;</td>
            <td align="center"><input name="Submit2" type="button" class="buttons" onclick="window.navigate('CopyCounter.aspx')" value="重新抄表" />
            &nbsp;&nbsp;&nbsp;
            <%if (model.IsAllowVerify)
			  { %>
            <input name="Submit" onclick="completeVerify();"   type="button" class="buttons" value="完成核对" />
            <%}else{ %>
            <input name="Submit" disabled="disabled" type="button" class="buttons" value="完成核对" /></td>
            <%} %>
            </td>
            <td width="3%">&nbsp;</td>
          </tr>
          <tr height="10px">
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
<input name="id" type="hidden" value="<%=model.RecordMachineWatchId %>" />
<input id="compensateUsedPaperId" name="compensateUsedPaperId" type="hidden" value="" />
<input id="compensateVerify" name="compensateVerify" type="hidden" value="" />
</div>
</form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckCounter1.aspx.cs" Inherits="CheckCounter" %>
<%@ Import Namespace="Workflow.Da.Domain" %>
<%@ Import Namespace="Workflow.Support" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>核对</title>
<link href="/Workflow.Web/css/css.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../js/jquery.js"></script>
<script language="javascript" src="../js/default.js"></script>
<script language="javascript" >

function deleteCompensate(intId){
    if (!confirm("是否要真的删除?")) return;
    $("#txtAction").attr("value",5);
    $("#txtId").attr("value",intId);
    $("#MainForm").submit();
}

function showCompensate(lngRecordMachineWatchId){
    //txtAction标记:1初始化 2查询 3增加 4修改 5删除 6其它
    var obj=showPage('Compensate.aspx?RecordMachineWatchId='+lngRecordMachineWatchId, "curWindow", 800, 465, false, false);
}

function showEditCompensate(intId,lngRecordMachineWatchId)
{
    var obj=showPage('EditCompensate.aspx?Id='+intId+'&RecordMachineWatchId='+lngRecordMachineWatchId, "curWindow", 800, 465, false, false);
}

function saveMachineWatchData()
{
  if(!checkProcess())
  {
    alert('有未通过的数据,请确认!');
    return false;
  }
  $("#txtAction").attr("value",3);
  $("#MainForm").submit();
}
function checkProcess()
{
  var txt=$("input:hidden[@name=txtResult]");
  var blnCheck=true;
  txt.each(function(i,txtresult){
    if (txtresult.value==0)
    {
      blnCheck=false;
      return false;
    }
  }
  );
  if (!blnCheck)
  {
    return false;
  }
  return true;
}

</script>
</head>
<body style="text-align:center">
<form id="MainForm" method="post" runat="server">
<input id="txtAction" name="txtAction" type="hidden">
<input id="txtId" name="txtId" type="hidden">
<input name="txtRecordMachineWatchId" id="txtRecordMachineWatchId" value="<%=lngRecordMachineWatchId %>" type="text" />
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
                  <th width="10%" nowrap="nowrap">机器</th>
                  <th width="1%" nowrap="nowrap">纸型</th>
                  <th width="1%" nowrap="nowrap">颜色</th>
                  <th width="1%" nowrap="nowrap">理论<br />制作数</th>
                  <th width="1%" nowrap="nowrap">实际<br />制作数</th>
                  <th width="1%" nowrap="nowrap">订单<br />用纸数</th>
                  <th width="1%" nowrap="nowrap">未完工<br />用纸数</th>
                  <th width="1%" nowrap="nowrap">废张数</th>
                  <th width="1%" nowrap="nowrap">补单量</th>
                  <th width="1%" nowrap="nowrap">上次未<br />完工量</th>
                  <th nowrap="nowrap">结果(实际=订单用纸数+未完工数量+废张数+补单量-上次未完工数量)</th>
                </tr>
                <%foreach (MachineWatchConversionPaper var in model.MachineWatchConversionPaperList)
                  {
                %>
                <tr class="detailRow">
                  <td align="left"><%=var.MachineName%><input type="hidden" name="txtMachineId" value="<%=var.MachineId%>" /></td>
                  <td><%=((var.PaperSpecification==null)?"-":var.PaperSpecification.Name)%><input type="hidden" name="txtPaperSpecificationId" value="<%=((var.PaperSpecification==null)?0:var.PaperSpecification.Id)%>" /></td>
                  <td><%=Constants.GetColorType(var.ColorType)%><input type="hidden" name="txtColorType" value="<%=var.ColorType%>" /></td>
                  <td class="num"><%=var.MakeCountTheory%></td>
                  <td class="num"><%=var.MakeCount%><input type="hidden" name="txtMakeCount" value="<%=var.MakeCount%>" /></td>
                  <td class="num"><%=var.OrderUsePaperCount%></td>
                  <td class="num"><%=var.UncompeleteOrderUsePaperCount%></td>
                  <td class="num"><%=var.CashCount%><input type="hidden" name="txtCashCount" value="<%=var.CashCount%>" /></td>
                  <td class="num"><%=var.PatchCount%><input type="hidden" name="txtPatchCount" value="<%=var.PatchCount%>" /></td>
                  <td class="num"><%=var.LastTimeUncompeleteOrderUsePaperCount%></td>
                  <%if (var.MakeCount == var.MakeCountTheory)
                    {%>
                  <td><font color="blue">通过</font><input name="txtResult" type="hidden" value="1" /></td>
                  <%}else
                    { %>
                  <td><font color="red">未通过</font><input name="txtResult" type="hidden" value="0" /></td>
                    <%} %>
                </tr>    
                <%
                  } %>
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
            <td align="left"><input name="Submit3" type="button" class="buttons" onclick="showCompensate(<%=lngRecordMachineWatchId %>);" value="新增补单" /></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellpadding="3" cellspacing="1">
                <tr>
                  <th width="10%" nowrap="nowrap">机器</th>
                  <th width="10%" nowrap="nowrap">纸型</th>
                  <th width="10%" nowrap="nowrap">颜色</th>
                  <th width="10%" nowrap="nowrap">数量</th>
                  <th width="10%" nowrap="nowrap">责任人</th>
                  <th nowrap="nowrap">备注</th>
                  <th width="1%">操作</th>
                </tr>
                <%if (model.RecordMachineWatch != null)
                  {
                    foreach (CompensateUsedPaper var in model.RecordMachineWatch.CompensateUsedPaperList)
                    {%>
                      <tr>
                        <td align="center" nowrap><%=var.MachineType.Name%></td>
                        <td align="center" nowrap><%=var.PaperSpecification.Name%></td>
                        <td align="center" nowrap><%=Constants.GetColorType(var.ColorType)%></td>
                        <td class="num" nowrap><%=var.UsedPaperCount%></td>
                        <td align="left" nowrap><%=DoEmployeeProcess(var.EmployeeList)%></td>
                        <td align="left"><%=var.Memo%></td>
                        <td nowrap="nowrap">
                        <a href="#" onclick="showEditCompensate(<%=var.Id%>,<%=lngRecordMachineWatchId%>);">编辑</a> 
                        <a href="#" onclick="deleteCompensate(<%=var.Id %>);">删除</a>
                        </td>
                      </tr>
                    <%
                  }
                }
                else
                {  
                    %>
                      <tr>
                        <td align="center" nowrap>&nbsp;</td>
                        <td align="center" nowrap>&nbsp;</td>
                        <td align="center" nowrap>&nbsp;</td>
                        <td class="num" nowrap>&nbsp;</td>
                        <td align="left">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td nowrap="nowrap">&nbsp;</td>
                      </tr>
                    
                  <% 
                  } 
                    %>
                
              </table></td>
            <td>&nbsp;</td>
          </tr>
          
		  <tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
		  </tr>
          <tr class="bottombuttons">
            <td width="3%">&nbsp;</td>
            <td align="center"><input name="Submit2" type="button" class="buttons" onclick="window.navigate('CopyCounter.aspx')" value="重新抄表" />
            &nbsp;&nbsp;&nbsp;<input name="Submit" type="button" class="buttons" value="完成核对" onclick="saveMachineWatchData();" /></td>
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
</div>
</form>
</body>
</html>

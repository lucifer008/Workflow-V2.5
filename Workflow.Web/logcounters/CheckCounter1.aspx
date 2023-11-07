<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckCounter1.aspx.cs" Inherits="CheckCounter" %>
<%@ Import Namespace="Workflow.Da.Domain" %>
<%@ Import Namespace="Workflow.Support" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>�˶�</title>
<link href="/Workflow.Web/css/css.css" rel="stylesheet" type="text/css" />
<script language="javascript" src="../js/jquery.js"></script>
<script language="javascript" src="../js/default.js"></script>
<script language="javascript" >

function deleteCompensate(intId){
    if (!confirm("�Ƿ�Ҫ���ɾ��?")) return;
    $("#txtAction").attr("value",5);
    $("#txtId").attr("value",intId);
    $("#MainForm").submit();
}

function showCompensate(lngRecordMachineWatchId){
    //txtAction���:1��ʼ�� 2��ѯ 3���� 4�޸� 5ɾ�� 6����
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
    alert('��δͨ��������,��ȷ��!');
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
            <td align="left" bgcolor="#eeeeee">��ҳ -&gt; ������ -&gt; �˶�</td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">�˶�</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellpadding="3" cellspacing="1">
                <tr>
                  <th width="10%" nowrap="nowrap">����</th>
                  <th width="1%" nowrap="nowrap">ֽ��</th>
                  <th width="1%" nowrap="nowrap">��ɫ</th>
                  <th width="1%" nowrap="nowrap">����<br />������</th>
                  <th width="1%" nowrap="nowrap">ʵ��<br />������</th>
                  <th width="1%" nowrap="nowrap">����<br />��ֽ��</th>
                  <th width="1%" nowrap="nowrap">δ�깤<br />��ֽ��</th>
                  <th width="1%" nowrap="nowrap">������</th>
                  <th width="1%" nowrap="nowrap">������</th>
                  <th width="1%" nowrap="nowrap">�ϴ�δ<br />�깤��</th>
                  <th nowrap="nowrap">���(ʵ��=������ֽ��+δ�깤����+������+������-�ϴ�δ�깤����)</th>
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
                  <td><font color="blue">ͨ��</font><input name="txtResult" type="hidden" value="1" /></td>
                  <%}else
                    { %>
                  <td><font color="red">δͨ��</font><input name="txtResult" type="hidden" value="0" /></td>
                    <%} %>
                </tr>    
                <%
                  } %>
              </table></td>
            <td width="3%">&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="left">��ӡ����������ʵ��������������������ԭ��Ȼ�󴴽�������</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="left"><input name="Submit3" type="button" class="buttons" onclick="showCompensate(<%=lngRecordMachineWatchId %>);" value="��������" /></td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellpadding="3" cellspacing="1">
                <tr>
                  <th width="10%" nowrap="nowrap">����</th>
                  <th width="10%" nowrap="nowrap">ֽ��</th>
                  <th width="10%" nowrap="nowrap">��ɫ</th>
                  <th width="10%" nowrap="nowrap">����</th>
                  <th width="10%" nowrap="nowrap">������</th>
                  <th nowrap="nowrap">��ע</th>
                  <th width="1%">����</th>
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
                        <a href="#" onclick="showEditCompensate(<%=var.Id%>,<%=lngRecordMachineWatchId%>);">�༭</a> 
                        <a href="#" onclick="deleteCompensate(<%=var.Id %>);">ɾ��</a>
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
            <td align="center"><input name="Submit2" type="button" class="buttons" onclick="window.navigate('CopyCounter.aspx')" value="���³���" />
            &nbsp;&nbsp;&nbsp;<input name="Submit" type="button" class="buttons" value="��ɺ˶�" onclick="saveMachineWatchData();" /></td>
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

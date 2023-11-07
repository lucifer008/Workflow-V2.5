<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditProductionPaperAmount.aspx.cs" Inherits="logcounters_EditProductionPaperAmount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>未完成订单用纸情况</title>
	<link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" language="javascript" src="../js/default.js"></script>
	<script type="text/javascript" language="javascript" src="../js/escExit.js" ></script>
	<script type="text/javascript" language="javascript" src="../js/logcounters/editProductionPaperAmount.js" ></script>
	<base target="_self" />
</head>
<body style="text-align:center" onload="checkComplete(<%=model.RecordMachineWatchId %>);">
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
            <td align="left" bgcolor="#eeeeee">首页 -&gt; 抄表处理 -&gt; 未完成订单用纸情况</td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">未完成订单用纸情况</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellspacing="1" cellpadding="3">
                <tr>
                  <td align="right" nowrap="nowrap" class="item_caption">订单号:</td>
                  <td width="80%" class="item_content">
					<select name="orderNo">
					<%if (null != model.OrderList)
	   {%>
					<%foreach (Workflow.Da.Domain.Order order in model.OrderList)
	   { %>
					<%if (order.Id == model.OrderId)
	   { %>
					<option selected="selected" value="<%=order.Id %>"><%=order.No%></option>
	   <%}
	  else
	  { %>
                      <option value="<%=order.Id %>"><%=order.No%></option>
                    <%}
				  }%>
                    </select>
                   </td>
                </tr>
                <tr>
                  <td align="right" nowrap="nowrap" class="item_caption">机器:</td>
                  <td class="item_content">
					<select name="machineType">
					<%foreach (Workflow.Da.Domain.MachineType machineType in model.MachineTypeList)
	   {%>
					<%if (model.MachineTypeId == machineType.Id)
	   {%>
					 <option selected="selected" value="<%=machineType.Id %>"><%=machineType.Name%></option>
	   <%}
	  else
	  { %>
                      <option value="<%=machineType.Id %>"><%=machineType.Name%></option>
                     <%}
				   }%>
                    </select></td>
                </tr>
                <tr>
                  <td align="right" nowrap="nowrap" class="item_caption">纸型:</td>
                  <td class="item_content">
					<select name="paperSpecification">
					<%foreach (Workflow.Da.Domain.PaperSpecification paper in model.PaperSpecificationList)
	   { %>
					 <%if (paper.Id == model.PaperShapeId) {%>
					<option selected="selected" value="<%=paper.Id %>"><%=paper.Name%></option>
	   <%}else{ %>
                      <option value="<%=paper.Id %>"><%=paper.Name%></option>
                     <%}}
				   }%>
                    </select></td>
                </tr>
                <tr>
                  <td align="right" nowrap="nowrap" class="item_caption">颜色:</td>
                  <td class="item_content"><select name="paperColor">
					<%if(model.PaperColorType=="1") {%><option selected="selected" value="1">黑白</option><%}else{ %><option value="1">黑白</option><%} %>
                    <%if(model.PaperColorType=="2") {%><option selected="selected" value="2">彩色</option><%}else{ %><option value="2">彩色</option><%} %>
                    <%if(model.PaperColorType=="0") {%><option selected="selected" value="0">未指定</option><%}else{ %><option value="0">未指定</option><%} %>  
                    </select></td>
                </tr>
                <tr>
                  <td align="right" nowrap="nowrap" class="item_caption">数量:</td>
                  <td class="item_content">
					<input id="number" onfocus="clearData(this);" name="number" type="text" value="<%=model.Number %>" size="10" />
                  </td>
                </tr>
              </table></td>
            <td width="3%">&nbsp;</td>
          </tr>
		  <tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
		  </tr>
          <tr>
            <td colspan="3" align="center" class="bottombuttons"><input name="Submit34" class="buttons"
					value="保存" onclick="saveeProductionPaperAmount();" type="button">
              &nbsp;&nbsp;&nbsp;
              <input
					name="Submit3342" onclick="window.close();" class="buttons"
					value="关闭" type="button"></td>
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

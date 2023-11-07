<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetOrder.aspx.cs" Inherits="GetOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>上门取活</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../js/jquery.js"></script>
    <script language="javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/order/newGetOrder.js"></script>
    <script language="javascript">
    function deleteCustomer(deleteId)
    {
        $("#deleteTag").attr("value","delete");       
        
        $("#deleteId").attr("value",deleteId);
        
        document.form1.submit();
    }
</script>
</head>
<body style="text-align: center">
<form id="form1" runat="server">
<input id="deleteId" type="hidden" runat="server"/>
    <div align="center" style="width: 99%;"  bgcolor="#FFFFFF" id="container">
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
                            <td width="3%">
                            </td>
                            <td align="left" bgcolor="#eeeeee">
                                首页&nbsp;-&gt;&nbsp;订单管理&nbsp;-&gt;&nbsp;上门取活</td>
                            <td width="3%">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" class="caption" align="center">
                                上门取活</td>
                        </tr>
                        <tr>
                            <td width="3%"></td>
                            <td class="item_content">
                                <input id="NewTakeWork" type="button" value="新增取活" onclick="showPage('NewGetingOrder.aspx','_self',null,null,false,true,'status:no;');" /></td>
                            <td width="3%"></td>
                        </tr>
                        <tr>
                            <td width="3%"></td>
                            <td align="center">
                                <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                    <tr>
                                        <th width="1%" nowrap align="center">&nbsp;NO&nbsp;</th>
                                        <th width="10%" nowrap align="center">取活单号</th>
                                        <th width="15%" nowrap align="center">客户名称</th>
                                        <th width="10%" nowrap align="center">联系人</th>
                                        <th width="15%" nowrap align="center">客户地址</th>
                                        <th width="10%" nowrap align="center">电话</th>
                                        <th width="5%" nowrap align="center">取活人</th>
                                        <th width="10%" nowrap align="center">取活时间</th>
                                        <th width="5%" nowrap align="center">完成</th>
                                        <th width="15%" nowrap align="center">备注</th>
                                        <th width="1%" nowrap align="center">&nbsp;</th>
                                    </tr>
                                    <%
                                        if (model.TakeWorkList != null)
                                        {
                                            for (int i = 1; i <= model.TakeWorkList.Count; i++)
                                            {
                                                Workflow.Da.Domain.TakeWork takeWork = model.TakeWorkList[i - 1];
                                     %>
                                     <tr>                                    
                                        <td nowrap align="center"><%= i%></td>
                                        <td nowrap align="center"><%= takeWork.No%></td>
                                        <td nowrap align="left"><%= takeWork.CustomerName%></td>
                                        <td nowrap align="center"><%= takeWork.LinkManName%></td>
                                        <td nowrap align="left"><%= takeWork.Address%></td>
                                        <td nowrap class="tel"><%= takeWork.TelNo%></td>
                                        <td nowrap align="center"><%= takeWork.DeliveryName%></td>
                                        <td nowrap align="center"><%= takeWork.BeginDateTime.ToString("MM-dd HH:mm")%></td>
                                        <%
                                        if (takeWork.Finished == "1")
                                        { %>
                                        <td nowrap align="center">是</td>
                                        <%}
                                          else
                                          { %>
                                        <td nowrap align="center">否</td>
                                        <%} %>
                                        <td nowrap align="left"><%= takeWork.Memo%>       
                                        </td>
                                        <td nowrap align="left"><input id="deleteTag" type="hidden" runat="server"  />
                                        <a href="#" onclick="showPage('NewGetingOrder.aspx?Id=<%= takeWork.Id %>','_self')">编辑</a>
                                          <a href="#" onclick='deleteCustomer(<%= takeWork.Id%>)'>删除</a></td>
                                    </tr>
                                    <%}
                                  }%>
                                </table>
                            </td>
                            <td width="3%">
                            </td>
                        </tr>
                        <tr class="emptyButtonsUpperRowHight">
				          <td colspan="3"></td>
			                    </tr>
                        <tr height="5">
                            <td>
                                <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            <td bgcolor="#eeeeee">&nbsp;
                                </td>
                            <td>
                                <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
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

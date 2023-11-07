<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DispatchOrderForOrderItem.aspx.cs"
    Inherits="order_DispatchOrderForOrderItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分配订单</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/json.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/SelectEmployee.js"></script>
    <script type="text/javascript" src="../js/order/dispatchOrderForOrderItem.js"></script>
    <script type="text/javascript" src="../js/escExit.js"></script>
    <script type="text/javascript">
        var strId='<%=sb.ToString() %>';
        var cf='<%=closeFlag %>'
    </script>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="actionTag" name="actionTag" value="" />
         <%if(!closeFlag){ %>
        <div align="left" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="780" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" >
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 订单管理 ->本日订单 ->分配订单</td>
                                <td style="width: 12px"></td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="left">
                                <input id="txtOrderNo" type="hidden" name="strOrderNo" value="<%=Request.QueryString["strNo"] %>" />
                                <input id="txtCustomerName" type="hidden" name="strCustomerName" value="<%=Request.QueryString["strName"] %>" />
                                <input type="hidden" id="txtResult" name="SelectResult" value="" />
                                <div id="divContent">
                                </div>
                                </td>
                                <td style="width: 12px">&nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            
                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td style="width: 12px"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="12"><img alt="" src="../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
        <%} %>
    </form>
</body>
</html>
<script type="text/javascript">
var isPrint='<%=actionType %>';
var orderNo='<%=strOrderNo %>'
<%if(closeFlag) {%>
  if("PrintOrders"==isPrint){ 
        opener.rValOrder='true';
        opener.orderNo=orderNo;;
   }
   else if("DispatchOrders"==isPrint)
   {
        opener.rValOrder='true';
   }
   else{ 
    opener.rVal='true';
   }
    window.close()
<%} %>
</script>

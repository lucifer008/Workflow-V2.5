<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewReDoOrderForOrderItem.aspx.cs" Inherits="order_ReDoOrderForOrderItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>订单返回</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/json.js"></script>
    <script type="text/javascript" src="../js/check.js"></script>
    <script type="text/javascript" src="../js/dispatch.js"></script>
    <script type="text/javascript" src="../js/escExit.js"></script>
   <%-- <script type="text/javascript">
        var strId='<%=sb.ToString() %>';
    </script>--%>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="left" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="600" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 订单管理 ->本日订单 ->订单返回</td>
                                <td style="width: 12px"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">订单返回</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="left">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap class="item_caption">订单号:</td>
                                            <td class="item_content" colspan="4">
                                                <span id="OrderNo"><%=Request.QueryString["strNo"]%></span>
                                                <input id="txtOrderNo" type="hidden" name="strOrderNo" value="<%=Request.QueryString["strNo"] %>" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">客户名称:</td>
                                            <td class="item_content" colspan="4">
                                                <span id="CustomerName"><%=Request.QueryString["strName"]%></span>                                               
                                            </td>
                                        </tr>                                                                             
                                    </table>
                                    <table>
                                        <tr>
                                            <td nowrap class="item_caption">返工原因:</td>
                                            <td class="item_content"><textarea name="Memo"  id="txtReason" cols="65" rows="3" class="textarea"></textarea></td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 12px">&nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center" class="bottombuttons">
                                    <asp:Button ID="btnOk" CssClass="buttons" Text="确定" OnClick="SaveReDo"  OnClientClick="return newOrderReDoCheck();" runat="server" />
                                    <input type="button" class="buttons" onclick="window.close()" name="Submit" value="关闭" />
                                </td>
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
    </form>
</body>
</html>

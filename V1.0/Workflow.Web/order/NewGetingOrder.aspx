<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewGetingOrder.aspx.cs" Inherits="NewGetingOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>新增取活</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/calendar-blue.css" type="text/css" />
    <script type="text/javascript" src="../js/calendar.js"></script>
    <script type="text/javascript" src="../js/calendar-zh.js"></script>
    <script type="text/javascript" src="../js/calendar-setup.js"></script>
    <script type="text/javascript" src="../js/checkCalendar.js"></script>
    <script language="javascript" src="../js/jquery.js"></script>
    <script language="javascript" src="../js/default.js"></script>
    <script language="javascript" src="../js/dataValidate.js"></script>
    <script language="javascript">
	function selectCustomer(objCustomer)
    {
        if(objCustomer==null) return;
        $("#CustomerId").attr("value",objCustomer.Id);
        $("#CustomerName").attr("value",objCustomer.Name);
    }
    </script>

    <style type="text/css">
<!--
.STYLE1 {color: #FF0000}
-->
</style>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div align="center" style="width: 99%;" bgcolor="#FFFFFF" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11">
                        <img alt="" src="../images/white_main_top_left.gif"></td>
                    <td width="99%">
                        <img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
                    <td width="10">
                        <img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <%
                                if (TakeWorkId.Value == "")
                                {
                            %>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页&nbsp;-&gt;&nbsp;工单管理&nbsp;-&gt;&nbsp;新增取活</td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    新增取活</td>
                            </tr>
                            <%} %>
                            <%
                                if (TakeWorkId.Value != "")
                                {
                            %>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页&nbsp;-&gt;&nbsp;工单管理&nbsp;-&gt;&nbsp;编辑取活</td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    编辑取活</td>
                            </tr>
                            <%} %>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <td nowrap class="item_caption">
                                                取活工单号<span class="STYLE1">*</span>:
                                            </td>
                                            <td colspan="3" class="item_content">
                                                <asp:TextBox ID="TakeWorkNo" runat="server"></asp:TextBox>
                                                <asp:HiddenField ID="TakeWorkId" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                客户名称<span class="STYLE1">*</span>:
                                            </td>
                                            <td nowrap class="item_content">
                                                <asp:TextBox ID="CustomerName" runat="server"></asp:TextBox>&nbsp;
                                                <input type="button" value="选择" onclick="showPage('../customer/SelectCustomer.aspx', null, 1000, 700, false, false);"
                                                    class="buttons" />&nbsp;
                                                <asp:HiddenField ID="CustomerId" runat="server" />
                                            </td>
                                            <td nowrap class="item_caption">
                                                客户地址<span class="STYLE1">*</span>:</td>
                                            <td class="item_content">
                                                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                联系人<span class="STYLE1">*</span>:
                                            </td>
                                            <td class="item_content">
                                                <asp:TextBox ID="LinkMan" runat="server"></asp:TextBox>
                                                </td>
                                            <td nowrap class="item_caption">
                                                电话:
                                            </td>
                                            <td class="item_content">
                                                <asp:TextBox ID="TelNo" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                取活人<span class="STYLE1">*</span>:
                                            </td>
                                            <td class="item_content">
                                                <asp:DropDownList ID="DeliveryMan" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                                </asp:DropDownList>
                                                </td>
                                            <td nowrap class="item_caption">
                                                取活时间<span class="STYLE1">*</span>:
                                            </td>
                                            <td class="item_content">
                                                <div>
                                                    <input class="datetexts" id="txtFrom" name="txtFrom" runat="server" type="text" maxlength="10" />
                                                    <img id="btnFrom" src="../images/cal.gif" width="20" height="14" border="0" alt="Click Here to Pick up the date" />

                                                    <script type="text/javascript">
						Calendar.setup({
							firstDay       :    0,                  // first day of the week
							inputField     :    "txtFrom",     				// id of the input field
							button         :    "btnFrom",  					// trigger for the calendar (button ID)
							align          :    "Tl",           		// alignment (defaults to "Bl")
							//singleClick  :    true,
							showsTime      :    "true",
							ifFormat       :    "%Y-%m-%d"    // our date only format
							 });
							 window
                                                    </script>

                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                回来时间:
                                            </td>
                                            <td class="item_content">
                                                <div>
                                                    <input class="datetexts" id="txtTo" name="txtTo" runat="server" type="text" maxlength="10" />
                                                    <img id="btnTo" src="../images/cal.gif" width="20" height="14" border="0" alt="Click Here to Pick up the date" />

                                                    <script type="text/javascript">
						Calendar.setup({
							firstDay       :    0,                  // first day of the week
							inputField     :    "txtTo",     				// id of the input field
							button         :    "btnTo",  					// trigger for the calendar (button ID)
							align          :    "Tl",           		// alignment (defaults to "Bl")
							//singleClick  :    true,
							showsTime      :    "true",
							ifFormat       :    "%Y-%m-%d"    // our date only format
							 });
							 window
                                                    </script>

                                                </div>
                                            </td>
                                            <td nowrap class="item_caption">
                                                完成:
                                            </td>
                                            <td class="item_content">
                                                <asp:RadioButtonList ID="Finished" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                                    <asp:ListItem Value="0">否</asp:ListItem>
                                                </asp:RadioButtonList></td>
                                        </tr>
                                        <tr>
                                            <td class="item_caption" nowrap="nowrap">
                                                备注:
                                            </td>
                                            <td class="item_content" colspan="3">
                                                <asp:TextBox ID="Memo" runat="server" Columns="90" Rows="3" TextMode="MultiLine"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td width="3%" style="height: 24px">
                                    &nbsp;
                                </td>
                                <td align="center" class="bottombuttons" style="height: 24px">
                                    <asp:Button ID="InsertTakeWork" class="buttons" runat="server" Text="确定" OnClick="InsertDeliveryInfo" OnClientClick="return dataValidateNewWork();" />&nbsp;
                                    <input type="button" class="buttons" onclick="window.close();" value="返回" />
                                <td style="height: 24px">
                            </tr>
                            <tr height="5">
                                <td style="height: 5px">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee" style="height: 5px">
                                    &nbsp;
                                </td>
                                <td style="height: 5px">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="11" style="height: 11px">
                        <img alt="" src="../images/white_main_bottom_left.gif"></td>
                    <td width="99%" style="height: 11px">
                        <img alt="" src="../images/spacer_10_x_10.gif"></td>
                    <td width="10" style="height: 11px">
                        <img alt="" src="../images/white_main_bottom_right.gif"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

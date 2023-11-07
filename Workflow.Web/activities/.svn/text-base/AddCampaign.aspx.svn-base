<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCampaign.aspx.cs" Inherits="AddCampaign" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="Pragma" content="no-cache" />
    <title>营销活动添加</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Calendar2.js"></script>
    <script type="text/javascript" src="../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/activities/addCampaign.js"></script>
    <base target="_self" />
</head>
<body style="text-align: center">
    <div align="center" style="width: 99%; background-color: #ffffff" id="container">
        <form id="form1" runat="server">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
                    <td width="10"><img alt="" src="../images/white_main_top_right.gif" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    <table width="100%" border="0" cellspacing="0">
                                        <tr>
                                            <td></td>
                                            <td align="left" bgcolor="#eeeeee">首页 -&gt; 活动管理 -&gt;营销活动添加</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" class="caption" align="center">营销活动添加
                                              <input type="hidden" id="DeletedTag" name="DeletedTag"/>
                                              <input type="hidden" id="DeletedId" name="DeletedId" />
                                              <asp:HiddenField ID="HiddenCampaignId" runat="server" />               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="3%"> &nbsp;</td>
                                            <td align="left">
                                                <table width="100%" border="1" cellspacing="1" cellpadding="3">
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">名称:</td>
                                                        <td class="item_content" colspan="3"><input type="text" name="txtName" id="txtName" onblur="CheckNameIsNotUse()"/></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">开始时间:</td>
                                                        <td class="item_content">
                                                            <div>
                                                                <input name="txtBeginDateTime" id="txtBeginDateTime" readonly="readonly" type="text" runat="server" class="texts" onfocus="setday(this)" />
                                                           </div>
                                                        </td>
                                                        <td nowrap="nowrap" class="item_caption">结束时间:</td>
                                                        <td class="item_content">
                                                            <div>
                                                                <input name="txtEndDateTime" id="txtEndDateTime" readonly="readonly" type="text" runat="server" class="texts" onfocus="setday(this)"/>
                                                                
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="item_caption">说明:</td>
                                                        <td class="item_content" colspan="3">
                                                            <asp:TextBox ID="txtMemo" runat="server" Columns="94" Rows="3" TextMode="MultiLine"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="3%"> &nbsp;</td>
                                        </tr>
                                       
                                        <tr>
                                            <td width="3%">&nbsp;</td>
                                            <td align="left"></td>
                                            <td width="3%">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td width="3%">&nbsp;</td>
                                            <td align="center">
                                                
                                            </td>
                                            <td width="3%">&nbsp;</td>
                                        </tr>
                                        
                                        
                                        <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td>
                                        </tr>
                                        <tr>                            
                                            <td colspan="3" align="center" class="bottombuttons">
                                                <asp:Button ID="Campaign" Cssclass="buttons" runat="server" Text="确定" OnClick="InsertCampaign" OnClientClick="return dataValidatorCampaign();" />
                                            </td>
                                        </tr>
                                        <tr height="5">
                                            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                            <td bgcolor="#eeeeee">&nbsp;</td>
                                            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                        </tr>
                                    </table>
                                </td>
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
        </form>
    </div>
</body>
</html>

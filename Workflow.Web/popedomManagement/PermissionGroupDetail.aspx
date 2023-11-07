<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PermissionGroupDetail.aspx.cs" Inherits="popedomManagement_PermissionGroupDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>权限组详细信息</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../js/jquery.js"></script>
    <script language="javascript" src="../js/default.js"></script>
</head>
<body style="text-align:center;">
    <form id="form1" runat="server">
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
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
                        <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页&nbsp;-&gt;&nbsp;权限组管理&nbsp;-&gt;&nbsp;权限组详细</td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    权限组详细</td>
                            </tr>
                            <tr height="5">
                                <td style="height: 5px">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee" style="height: 5px">
                                    &nbsp;</td>
                                <td style="height: 5px">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            </tr>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="center">
                                    <table border="1" style="width: 100%" align="left">
                                        <tr>
                                            <td width="1%" nowrap>权限组名称
                                            </td>
                                            <td align="left">对订单的所有操作
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="1%" nowrap>备注
                                            </td>
                                            <td align="left">订单的操作权限最大
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="1%" nowrap>排序号
                                            </td>
                                            <td align="left">1
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="1%" nowrap>可以操作的权限
                                            </td>
                                            <td>
                                                <table border="1" style="width: 30%" align="left">
                                                    <tr>
                                                        <td width="1%" nowrap>添加
                                                        </td>
                                                        <td width="1%" nowrap>修改
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="1%" nowrap>删除
                                                        </td>
                                                        <td width="1%" nowrap>查询
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td width="3%" style="height: 24px">
                                </td>
                                <td align="left" style="height: 24px">
                                    <input type="button" value="返回" onclick="location.href='/popedomManagement/PermissionGroupList.aspx'" />
                                <td width="3%" style="height: 24px">
                                </td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr height="5">
                                <td style="height: 5px">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee" style="height: 5px">
                                    &nbsp;</td>
                                <td style="height: 5px">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td width="11">
                        <img alt="" src="../images/white_main_bottom_left.gif"></td>
                    <td width="99%">
                        <img alt="" src="../images/spacer_10_x_10.gif"></td>
                    <td width="10">
                        <img alt="" src="../images/white_main_bottom_right.gif"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

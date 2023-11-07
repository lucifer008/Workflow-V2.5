<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewPermission.aspx.cs" Inherits="popedomManagement_NewPermission" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>操作添加</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script  type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/popedommanagement/permission.js"></script>
    <script language="javascript" type="text/javascript">
   function LoadUpdatePermissionInfo()
   {
        var permissionId=<%=permissionId %> 
        var permissionIdentity='<%=permissionIdentity %>'
        var memo='<%=memo %>'
        if(permissionId!=0)
        {
           $("#hiddPermissionId").val(permissionId);
           $("#txtPermissionName").val(permissionIdentity);
           $("#txtMemo").val(memo);
           //$("#btnCancel").style.display="";
           document.all["btnCancel"].style.display="";//显示关闭按钮
        }
   }
    </script>
    <base target="_self" />
</head>
<body onload="LoadUpdatePermissionInfo()" style="text-align:center;">
    <form id="form1" runat="server">
    <input type="hidden" id="hiddTag" name="hiddTag" value="" />
    <input type="hidden" id="hiddPermissionId" name="hiddPermissionId" value="" />
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11"><img alt="" src="../../images/white_main_top_left.gif"></td>
                    <td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif" height="10"></td>
                    <td width="10"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                            <tr>
                                <td width="3%"></td>
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;基本操作管理&nbsp;-&gt;&nbsp;操作添加</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">操作添加</td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table border="1" style="width: 100%" align="left">
                                        <tr>
                                            <td width="1%"  class="item_caption">操作名称</td>
                                            <td align="left"><input type="text" id="txtPermissionName" name="txtPermissionName" /></td>
                                        </tr>
                                        <tr>
                                            <td width="1%"  class="item_caption">备注</td>
                                            <td align="left"><input type="text" id="txtMemo" name="txtMemo" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="left">
                                    <input id="btnAddPermission" type="button" value="保存" class="buttons" onclick="AddPermission();" />
                                    <input id="btnCancel" type="button" value="关闭" class="buttons" onclick="window.close();" style="display:none"/>
                                <td width="3%"></td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../../../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../../../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="11"><img alt="" src="../../images/white_main_bottom_left.gif"></td>
                    <td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif"></td>
                    <td width="10"><img alt="" src="../../images/white_main_bottom_right.gif"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewCustomerLinkMan.aspx.cs"
    Inherits="NewCustomerLinkMan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=model.Action %>联系人</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/customer/modifyCustomer.js"></script>
    <script type="text/javascript" src="../js/customer/newCustomerLinkMan.js"></script>
    <base target="_self" />
    <style type="text/css">
<!--
.STYLE1 {color: #FF0000}
-->
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center" style="width: 100%;" bgcolor="#FFFFFF" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
                    <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="3%"></td>
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;客户管理&nbsp;-&gt;&nbsp;<%=model.Action %>联系人</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center"><%=model.Action %>联系人</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <td nowrap class="item_caption">客户名称:</td>
                                            <td colspan="3" class="item_content"><%=model.Name %></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">联系人姓名<span class="STYLE1">*</span>:</td>
                                            <td class="item_content"><input tabindex="1" name="txtName" type="text" value="<%=model.LinkMan.Name %>" /></td>
                                            <td nowrap class="item_caption">单位电话<span class="STYLE1">*</span>:</td>
                                            <td class="item_content"><input tabindex="2" name="txtCompanyPhone" type="text" value="<%=model.LinkMan.CompanyTelNo %>" /></td> 
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">性别:</td>
                                            <td class="item_content">
                                                <% if (Workflow.Support.Constants.SEX_MALE_VALUE.ToString() == model.LinkMan.Sex) {%>
                                                男<input tabindex="3" name="radSex" checked="checked" type="radio" value="0" />
                                                女<input tabindex="4" name="radSex" type="radio" value="1"/>
                                                <%}else{ %>
                                                男<input tabindex="3" name="radSex" type="radio" value="0" />
                                                女<input tabindex="4" name="radSex" checked="checked" type="radio" value="1"/>
                                                <%} %>
                                            </td>
                                            <td nowrap class="item_caption">年龄:</td>
                                            <td class="item_content"><input tabindex="5" name="txtAge" type="text" value="<%=model.LinkMan.Age %>" /></td>
                                        </tr>

                                        <tr>
                                            <td nowrap class="item_caption">职位:</td>
                                            <td class="item_content"><input tabindex="6" name="txtPosition" type="text" value="<%=model.LinkMan.Position %>" /></td>
                                            <td nowrap class="item_caption">爱好:</td>
                                            <td class="item_content"><input tabindex="7" name="txtHobby" type="text" value="<%=model.LinkMan.Hobby %>" /></td>
                                        </tr>

                                        <tr>
                                            <td nowrap class="item_caption">手机:</td>
                                            <td class="item_content"><input tabindex="8" name="txtMobilePhone" type="text" value="<%=model.LinkMan.MobileNo %>" /></td>
                                            <td nowrap class="item_caption">QQ号码:</td>
                                            <td class="item_content"><input tabindex="9" name="txtQQ" type="text" value="<%=model.LinkMan.Qq %>" /></td>
                                        </tr>

                                        <tr>
                                            <td nowrap class="item_caption">E-Mail:</td>
                                            <td class="item_content"><input tabindex="10" name="txtEMail" type="text" value="<%=model.LinkMan.Email %>" /></td>
                                            <td nowrap class="item_caption">地址:</td>
                                            <td class="item_content"><input tabindex="11" name="txtAddress" type="text" value="<%=model.LinkMan.Address %>" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">备注:</td>
                                            <td colspan="3" class="item_content">
                                               <textArea tabindex="12" name="txtMemo" style="word-wrap:break-word;width:380px;height:40px;"><%=model.LinkMan.Memo%></textArea>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center" class="bottombuttons">
                                    <input class="buttons" type="button" value="保存" onclick="saveLinkMan();" />&nbsp;&nbsp;
                                    <input type="button" class="buttons" onclick="window.close();" value="关闭" /></td>
                                <td width="3%">&nbsp;</td>
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

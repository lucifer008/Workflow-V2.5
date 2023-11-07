<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WithoutConsumeCustomer.aspx.cs" Inherits="finance_find_WithoutConsumeCustomer" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>无消费客户查询</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/Calendar2.js"></script>
    <script type="text/javascript" src="../../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/finance/find/withoutConsumeCustomer.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <input type="hidden" id="queryCondition" name="queryCondition" />
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 无消费客户查询</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">无消费客户查询</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td nowrap class="item_caption">客户级别:</td>
                                                        <td class="item_content">
                                                            <select name="CustomerLevel">
                                                            <option value="<%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_KEY %>"><%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_TEXT %></option>
                                                            <%
                                                                for (int i = 0; i < model.CustomerLevelList.Count; i++)
                                                                {
                                                                    if (model.CustomerLevelList[i].Id == long.Parse(model.Operator1))
                                                                    {
                                                                        %>
                                                                            <option value="<%=model.CustomerLevelList[i].Id %>" selected="selected"><%=model.CustomerLevelList[i].Name%></option>
                                                                        <%
                                                                    }
                                                                    else
                                                                    { 
                                                                        %>
                                                                            <option value="<%=model.CustomerLevelList[i].Id %>"><%=model.CustomerLevelList[i].Name%></option>
                                                                        <%
                                                                    }
                                                                }
                                                            %>
                                                            </select>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption">客户类型:</td>
                                                        <td class="item_content">
                                                            <select name="CustomerType">
                                                            <option value="<%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_KEY %>"><%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_TEXT %></option>
                                                            <%
                                                                for (int i = 0; i < model.CustomerTypeList.Count; i++)
                                                                {
                                                                    if (model.CustomerTypeList[i].Id == long.Parse(model.Operator2))
                                                                    {
                                                                        %>
                                                                            <option value="<%=model.CustomerTypeList[i].Id %>" selected="selected"><%=model.CustomerTypeList[i].Name%></option>
                                                                        <%
                                                                    }
                                                                    else
                                                                    { 
                                                                        %>
                                                                            <option value="<%=model.CustomerTypeList[i].Id %>"><%=model.CustomerTypeList[i].Name%></option>
                                                                        <%
                                                                    }                                                                
                                                                }
                                                            %>
                                                            </select>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption">会员类型:</td>
                                                        <td class="item_content">
                                                            <select name="MemberCardLevel">
                                                            <option value="<%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_KEY %>"><%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_TEXT %></option>
                                                            
                                                            <%
                                                                for (int i = 0; i < model.MemberCardLevelList.Count; i++)
                                                                {
                                                                    if (model.MemberCardLevelList[i].Id == long.Parse(model.Operator3))
                                                                    {
                                                                        %>
                                                                            <option value="<%=model.MemberCardLevelList[i].Id %>" selected="selected"><%=model.MemberCardLevelList[i].Name%></option>
                                                                        <%
                                                                    }
                                                                    else
                                                                    { 
                                                                        %>
                                                                            <option value="<%=model.MemberCardLevelList[i].Id %>"><%=model.MemberCardLevelList[i].Name%></option>
                                                                        <%
                                                                    }  
                                                                }
                                                            %>
                                                            </select>
                                                            </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption">时间段:</td>
                                                        <td class="item_content">
                                                            <div>
                                                                <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts"  onfocus="setday(this);" size="16" runat="server"/>&nbsp;至&nbsp;
                                                                <input id="txtTo" type="text" name="EndDateTime" class="datetexts" onfocus="setday(this);" size="16" runat="server"/>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="right" style="padding-right: 10px">
                                                            <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="return queryCheck();" Text="查询" />&nbsp;&nbsp;
                                                            <asp:Button ID="btnPrint" CssClass="buttons" runat="server" OnClick="Print" OnClientClick="printCheck();" Text="打印" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
                                            <th width="30%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;客户名称&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>最后一次联系人</th>
                                            <th width="1%" nowrap>联系电话</th>
                                            <th width="1%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;最后一次消费时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                        </tr>
                                        <%
                                            if (model.CustomerList != null)
                                            {
                                                for (int i = 0; i < model.CustomerList.Count; i++)
                                                { %>
                                                <tr class="detailRow">
                                                    <td align="center"><%=i + 1%></td>
                                                    <td align="left"><%=model.CustomerList[i].Name%></td>
                                                    <td align="center"><%=model.CustomerList[i].LastLinkMan %></td>
                                                    <td align="center"><%=model.CustomerList[i].LastTelNo %></td>
                                                    <td align="center"><%=model.CustomerList[i].InsertDateTime%></td>
                                                 </tr>
                                                <%}
                                           }
                                        %>
                                        <tr class="detailRow">
										 <td bgcolor="#eeeeee" colspan="6" align="right">
											   <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
												</webdiyer:AspNetPager>
										 </td>
										</tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>                
                    </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

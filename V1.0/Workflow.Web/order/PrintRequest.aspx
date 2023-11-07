<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintRequest.aspx.cs" Inherits="OrderPrintRequest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>印制要求</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/order/selectPrintDemand.js"></script>
    <script type="text/javascript" src="../js/escExit.js"></script>
    <base target="_self" />
</head>
<body style="text-align: center">
<form id="form1" action=""  runat="server"  method="post">
    <div align="center" style="width: 100%" bgcolor="#ffffff" id="container">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td width="11">
                    <img alt=""  src="../images/white_main_top_left.gif"/></td>
                <td width="99%">
                    <img alt=""  src="../images/spacer_10_x_10.gif" height="10"/></td>
                <td width="10">
                    <img alt=""  src="../images/white_main_top_right.gif" width="12" height="11"/></td>
            </tr>
            <tr>
                <td colspan="3" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="3%">
                            </td>
                            <td align="left" bgcolor="#eeeeee">
                                首页 -&gt; 本日工单 -&gt; 新增工单 -&gt; 印制要求</td>
                            <td width="3%">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" class="caption" align="center">
                                印制要求</td>
                        </tr>
                        <tr>
                            <td width="3%">&nbsp;
                                </td>
                            <td align="center">
                                <table border="0" cellpadding="3" cellspacing="1" width="100%" align="left">
                                    <tr>
                                        <td width="3%">
                                        </td>
                                        <td>
                                            <table id="tbMakeDemand" border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                            <% 
                                                if (model.PrintDemandList.Count > 0)
                                                {
                                                    for (int i = 0; i < model.PrintDemandList.Count; i++)
                                                    {
                                                        if (model.PrintDemandList[i].PrintDemandDetailList.Count > 0)
                                                        {
                                                            for (int j = 0; j < model.PrintDemandList[i].PrintDemandDetailList.Count; j++)
                                                            {
                                                                if (model.PrintDemandList[i].PrintDemandDetailList[j].PrintRequireDetailList!=null)
                                                                {
                                                                    if (0 == j)
                                                                    {
                                                                        %><tr>
                                                                        <td nowrap class='item_caption w1' rowspan='<%= model.PrintDemandList[i].PrintDemandDetailList.Count  %>'><%=model.PrintDemandList[i].Name%></td>
                                                                        <td nowrap class='item_caption w1'><%= model.PrintDemandList[i].PrintDemandDetailList[j].Name%></td><td align='left'>
                                                                        <%
                                                                    }
                                                                    else
                                                                    {
                                                                        %>
                                                                        <td nowrap class='item_caption w1'><%= model.PrintDemandList[i].PrintDemandDetailList[j].Name%></td><td align='left'>
                                                                        <%
                                                                    }
                                                                    for (int k = 0; k < model.PrintDemandList[i].PrintDemandDetailList[j].PrintRequireDetailList.Count; k++)
                                                                    {
                                                                        %>
                                                                        <%--<input type='radio' class='radios' name='rdbt<%=model.PrintDemandList[i].PrintDemandDetailList[j].Id  %>' id='rdbtn<%=i.ToString() %><%=j.ToString() %><%=k.ToString() %>' value='radiobutton' /><label for='rdbtn<%=i.ToString() %><%=j.ToString() %><%=k.ToString() %>'><%=model.PrintDemandList[i].PrintDemandDetailList[j].PrintRequireDetailList[k].Name%></label>--%>
                                                                        <input type='radio' class='radios' name='rdbt<%=model.PrintDemandList[i].PrintDemandDetailList[j].Id  %>' id='<%=model.PrintDemandList[i].PrintDemandDetailList[j].PrintRequireDetailList[k].Id  %>' value='radiobutton' /><label for='<%=model.PrintDemandList[i].PrintDemandDetailList[j].PrintRequireDetailList[k].Id  %>'><%=model.PrintDemandList[i].PrintDemandDetailList[j].PrintRequireDetailList[k].Name%></label>
                                                                        <%
                                                                    }
                                                                    %>
                                                                    </td><td class='w1'><input type='button' class='buttons' value='清空' onclick='resetRadio(this)'></td></tr>
                                                                    <%
                                                                
                                                                }
                                                                else
                                                                { 
                                                                    %>
                                                                    <tr><td nowrap class='item_caption w1' rowspan='<%=model.PrintDemandList[i].PrintDemandDetailList.Count %>'><%=model.PrintDemandList[i].Name%></td>
                                                                    <td nowrap class='item_caption w1'><%=model.PrintDemandList[i].PrintDemandDetailList[j].Name%></td>
                                                                    <td></td>
                                                                    <td class='w1'><input type='button' class='buttons' value='清空' onclick='resetRadio(this)' /></td></tr>
                                                                    <%
                                                                }
                                                            }

                                                        }
                                                        else
                                                        { 
                                                            %>
                                                            <tr><td nowrap class='item_caption w1'><%=model.PrintDemandList[i].Name %></td><td></td><td></td><td class='w1'><input type='button' class='buttons' value='清空' onclick='resetRadio(this)'/></td></tr>
                                                            <%
                                                        }

                                                    }
                                                }
                                                else
                                                { 
                                                    %>
                                                    <tr><td nowrap class='item_caption w1'>对不起,没有印制要求的相关数据！！！</td><td></td><td></td><td class='w1'><input type='button' class='buttons' value='清空' onclick='resetRadio(this)'/></td></tr>
                                                    <%
                                                }
                                            %>
                                            <tr>
                                                <td nowrap class="item_caption w1">备注:</td>
                                                <td colspan="3"><textarea name="Memo" class="textarea" cols="90" rows="3" id="txtMemo"></textarea></td>
                                            </tr>
                                                                                
                                             </table>
                                        </td>
                                        <td width="3%">&nbsp;
                                            </td>
                                    </tr>
                                   
                                    <tr class="emptyButtonsUpperRowHight">
                                        <td colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="3%">&nbsp;
                                            </td>
                                        <td align="center" class="bottombuttons">
                                            <input type="button" name="Submit" class="buttons" onclick="returnPrintRequire();" value="确定" id="Button1" />&nbsp;
                                            <input type="button" onclick="window.close();" name="Submit2" class="buttons" value="关闭" />
                                        </td>
                                        <td width="3%">&nbsp;
                                            </td>
                                    </tr>
                                    <tr height="5">
                                        <td>
                                            <img alt=""  src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                                        <td bgcolor="#eeeeee">&nbsp;
                                            </td>
                                        <td>
                                            <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        
                    </table>
                    </td>
                    </tr>
                    <tr>
                            <td width="11">
                                <img alt=""  src="../images/white_main_bottom_left.gif"/></td>
                            <td width="99%">
                                <img alt=""  src="../images/spacer_10_x_10.gif"/></td>
                            <td width="10">
                                <img alt=""  src="../images/white_main_bottom_right.gif"/></td>
                        </tr>
                    </table>
    </div>
    </form>
</body>
</html>

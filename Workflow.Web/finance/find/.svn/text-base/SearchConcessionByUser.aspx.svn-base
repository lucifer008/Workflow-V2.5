<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchConcessionByUser.aspx.cs" Inherits="finance_find_SearchConcessionByUser" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<%@ Register Assembly="PhookPager" Namespace="PhookTools" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>优惠查询</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
	<script type="text/javascript" src="../../js/jquery.js"></script>
	<script type="text/javascript" src="../../js/default.js"></script>
	<script type="text/javascript" src="../../js/finance/find/searchConcession.js">
</script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%" heigth="100%">
                            <tr><td ></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 优惠查询</td>
                                <td ></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">优惠查询</td></tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <table width="100%" border="1" cellpadding="0" cellspacing="0" id="TABLE1" language="javascript" >
                                                    <tr>
                                                      <td nowrap class="item_caption">操作人</td>
                                                      <td class="item_content" colspan="2"><input id="txtOperateUser" name="txtOperateUser" type="text" size="16" runat="server"/></td>
                                                    </tr>
                                                    <tr>
                                                      <td nowrap class="item_caption"> 结算日期</td>
                                                      <td class="item_content">
                                                        <div>
                                                             <input id="txtBeginDateTime"  name="txtBeginDateTime" type="text" class="datetexts"  size="16" onfocus="setday(this);" runat="server" readonly="readOnly" />&nbsp;至&nbsp;
                                                             <input id="txtEndDateTime"  name="txtEndDateTime" type="text" class="datetexts" size="16" onfocus="setday(this)" runat="server" readonly="readonly"/>
                                                         </div>
                                                       </td>
                                                     </tr>
                                                    <tr>
                                                    <td colspan="2" align="right">
														        <asp:Button ID="btnSearch" CssClass="buttons" runat="server"  Text="查询" OnClientClick="return queryDataCheck();" OnClick="btnSearch_Click"/>&nbsp;
														  <%--  <asp:Button ID="btnDispatchPrint" CssClass="buttons" runat="server" Text="打印" />--%>
                                                    </td>
                                                    </tr>
                                                </table>
                                            </td>
										</tr>
                                    </table>
                                </td>
                                <td width="3%"> &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center">
                                  <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="5%" nowrap> &nbsp;N&nbsp; O&nbsp;</th>
                                            <th width="11%" nowrap >操作人</th>
                                            <th witdh="11%">单数</th>
                                            <th width="11%" nowrap>原价</th>
											<th width="11%" nowrap="nowrap">优惠合计<label style="color:red">(优惠+抹零+舍入少收)</label></th>
											<th width="11%">实收</th> 
											<th width="11%" nowrap="nowrap">多收合计<label style="color:red">(舍入多收)</label></th> 
                                        </tr>
                                        <%
											if (model.PaymentConcessionList != null && model.PaymentConcessionList.Count > 0)
											{
												int index = 0;
												foreach (Workflow.Da.Domain.PaymentConcession item in model.PaymentConcessionList)
												{
													index++;
											%>
                                        <tr>
											<td width="5%" nowrap> <%=index%></td>
                                            <td width="11%" nowrap ><%=item.OperateUsers == null ? "&nbsp;" : item.OperateUsers.Employee.Name%></td>
                                            <td width="11%" nowrap><%=item.OrderCount%></td>
                                            <td width="11%" nowrap><%=item.SumAmountTotal%></td>
											<td width="11%" nowrap="nowrap"  align="right"><%=item.ConcessionAmountTotal%></td>
											<td width="11%"><%=item.RealAmountTotal%></td> 
											<td width="11%" nowrap="nowrap" align="right" ><%=item.MoreConcessionAmountTotal%></td> 
                                        </tr>
                                        <% }
									   }%>
									<tr>
										<td colspan="6" align="right">
											<webdiyer:aspnetpager id="AspNetPager1" runat="server" onpagechanging="AspNetPager1_PageChanging"></webdiyer:aspnetpager>
										</td>
									</tr>
                                  </table>
                                </td>
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

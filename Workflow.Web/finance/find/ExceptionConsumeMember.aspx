<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExceptionConsumeMember.aspx.cs" Inherits="finance_find_Default5" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�쳣���ѻ�Ա��ѯ</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../../css/thickbox.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/Calendar2.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <script type="text/javascript" src="../../js/finance/find/exceptionConsumeMember.js"></script>
    <script type="text/javascript" language="javascript">
    var isExistData=false;     
    <%
        if(null==model.OrderList || 0==model.OrderList.Count)
        {
        %>
            isExistData=true;
          <%
        }
     %>
</script>
</head>
<body style="text-align: center">
<form id="form1" action="" method="post" runat="server">
    <div align="center" style="width: 99%; background-color:#FFFFFF" id="container">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0"/></td>
                <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                <td width="12"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"/></td>
            </tr>
            <tr>
                <td colspan="3" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="3%"></td>
                            <td align="left" bgcolor="#eeeeee">��ҳ&nbsp;-&gt;&nbsp;��Ա����&nbsp;-&gt;&nbsp;��Ա��ѯ&nbsp;-&gt;&nbsp;�쳣���ѻ�Ա��ѯ</td>
                            <td width="3%"></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="caption" align="center">�쳣���ѻ�Ա��ѯ</td>
                        </tr>
                        <tr>
                            <td width="3%">&nbsp;</td>
                            <td align="center">
                                <table width="100%">
                                    <tr>
                                        <td align="left" style="height: 104px">
                                            <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                                <tr>
                                                    <td class="item_caption" nowrap="nowrap">��Ա����</td>
                                                    <td class="item_content"><input type="text" name="MemberCardNo" id="txtMemberCardNo" size="16"/></td>
                                                </tr>
                                                <tr>
                                                    <td nowrap="nowrap" class="item_caption">�����ܶ�</td>
                                                    <td class="item_content">
                                                        <select name="sltSumAmount">
                                                          <option value="&gt;=">���ڵ���</option>
                                                          <option value=">">����</option>
                                                          <option value="=">����</option>
                                                          <option value="<=">С�ڵ���</option>
                                                          <option value="<">С��</option>
                                                        </select>
                                                        <input type="text" class="texts num" id="txtSumAmount" name="SumAmount" value="0" size="10" />Ԫ
                                                   </td>
                                                </tr>
                                                <tr>
                                                    <td nowrap class="item_caption" style="height: 47px">ʱ���</td>
                                                    <td class="item_content" style="height: 47px">
                                                        <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts" size="16" onfocus="setday(this);" readonly="readonly" runat="server"/>&nbsp;�� &nbsp;
                                                        <input id="txtTo" type="text" name="EndDateTime" class="datetexts" size="16" onfocus="setday(this);" readonly="readonly" runat="server"/>
                                                    </td>
                                                </tr> 
                                                <tr>
                                                    <td colspan="2" align="right" class="querybuttons">
                                                        <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="return checkData();" Text="��ѯ" />
                                                        <asp:Button ID="btnPrint" CssClass="buttons" runat="server" OnClick="Print" OnClientClick="return printCheck();" Text="��ӡ" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="3%">&nbsp;</td>
                            <td align="center">
                            <%if(null!=model.OrderList) {%>
                                <table width="100%" border="1" cellpadding="1" cellspacing="1">
                                    <tr>
                                        <th nowrap align="center">&nbsp;NO&nbsp;</th>
                                        <th nowrap align="center">��Ա����</th>
                                        <th nowrap align="center">�ͻ�����</th>
                                        <th nowrap align="center">�����ܶ�</th>
                                        <th nowrap align="center">ͬ��</th>
                                    </tr>
                                    <%  decimal totalSum = 0;
                                        for (int i = 0; i < model.OrderList.Count; i++)
                                        {
                                            totalSum += model.OrderList[i].SumAmount;
                                             %>
                                            <tr class="detailRow">
                                                <td align="center"><%=i+1 %></td>
                                                <td align="center"><a href="#" onclick="memberCardDetail(this);"><%=model.OrderList[i].MemberCardNo %></a><input type="hidden" name="txtMemberCardNo" value="<%=model.OrderList[i].MemberCardId %>" /></td>
                                                <td align="center"><%=model.OrderList[i].CustomerName %></td>
                                                <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderList[i].SumAmount)%></td>
                                                <td class="num"><%=Math.Round(model.OrderList[i].SumAmount / model.OrderList[i].HasPrePaidMoney,2)*100+"%"%></td>
                                            </tr>
                                        <%}
                                    %>
                                    <tr  class="detailRow"><td>�ϼ�</td><td colspan="4"><%=Workflow.Util.NumericUtils.ToMoney(totalSum) %></td></tr>
                                     <tr  class="detailRow">
                                       <td colspan="5" align="right">
                                          <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
                                       </td>
                                   </tr>
                                </table>
                                <%} %>
                            </td>
                            <td width="3%">&nbsp;</td>
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
        <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
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

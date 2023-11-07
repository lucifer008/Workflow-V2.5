<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AchievementComposition.aspx.cs" Inherits="achievement_AchievementComposition" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>������Ч��ѯ</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/achinevement/achievementComposition.js"></script>
</head>
<body style="text-align:center">
<form id="form" action="" method="post" runat="server">
<div align="center" style="width:99%" bgcolor="#ffffff" id="container">
<table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">	
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
	</tr>
	<tr>
	    <td colspan="3" bgcolor="#FFFFFF">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0">
              <tr>
                <td></td>
                <td align="left" bgcolor="#eeeeee">��ҳ -&gt; ҵ������ -&gt; ������Ч��ѯ</td>
                <td></td>
              </tr>
              <tr>
                <td colspan="3" class="caption" align="center">������Ч��ѯ</td>
              </tr>
              <tr>
                <td width="3%">&nbsp;</td>
                <td align="center"><table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                    <tr>
                      <td nowrap="nowrap" class="item_caption">������</td>
                      <td class="item_content" colspan="2"><input name="strNo" type="text" class="texts" value="" size="15" id="strNo" runat="server" />
                      <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="return dataQuery();" Text="����"/>
                      </td>
                    </tr>
                  </table>
                </td>
                <td width="3%">&nbsp;</td>
              </tr>
              <tr class="emptyButtonsUpperRowHight">
                <td width="3%"></td>
                <td align="center"></td>
                <td width="3%"></td>
              </tr>
              <tr>
                <td width="3%">&nbsp;</td>
                <td align="center">
                      <table width="100%" border="1" cellpadding="3" cellspacing="1">
                        <tr>
                            <td nowrap="nowrap" class="item_caption">������</td>
                            <%if (oModel.NewOrder != null){ %>
                            <td width="30%" class="item_content"><%=oModel.NewOrder.No%></td>
                            <%}else{%>
                            <td width="30%" class="item_content"></td>
                            <%}%>
                            <td nowrap="nowrap" class="item_caption">�ͻ�����</td>
                            <%if (oModel.NewOrder != null){ %>
                            <td width="30%" class="item_content"><%=oModel.NewOrder.CustomerName%></td>
                            <%}else{%>
                            <td width="30%" class="item_content"></td>
                            <%}%>
                       </tr>
                       <tr>
                            <td nowrap="nowrap" class="item_caption">��Ŀ����</td>
                            <%if (oModel.NewOrder != null){ %>
                            <td width="30%" class="item_content"><%=oModel.NewOrder.ProjectName%></td>
                            <%}else{%>
                            <td width="30%" class="item_content"></td>
                            <%}%>
                            <td nowrap="nowrap" class="item_caption">���</td>
                            <%if (oModel.NewOrder != null && oModel.NewOrder.SumAmount!=0){ %>
                            <td width="30%" class="item_content"><%=Workflow.Util.NumericUtils.ToMoney(oModel.NewOrder.SumAmount)%></td>
                            <%}else{%>
                            <td width="30%" class="item_content"></td>
                            <%}%>
                      </tr>
                    </table>
                </td>
                <td width="3%">&nbsp;</td>
              </tr>
              <tr class="emptyButtonsUpperRowHight">
                <td width="3%"></td>
                <td align="right"><asp:Button ID="btnDisPrint" CssClass="buttons" runat="server" Text="��ӡ" OnClick="btnDisPrint_Click"/></td>
                <td width="3%"></td>
              </tr>
              <tr>
                <td width="3%">&nbsp;</td>
                <td align="center"><table width="100%" border="1" cellpadding="3" cellspacing="1">
                    <tr>
                      <th width="1%" align="center" nowrap="nowrap">&nbsp;NO&nbsp;</th>
                      <th width="40%" align="center" nowrap="nowrap">Ա��</th>
                      <th width="40%" align="center" nowrap="nowrap">��������</th>
                      <th width="15%" align="center" nowrap="nowrap">��Ч</th>
                    </tr>
                    <%
                        decimal total = 0;
                        for (int i = 0; i < aaModel.AchievementList.Count; i++)
                        {
                            total += aaModel.AchievementList[i].AchievementValue;
                            %>
                            <tr class="detailRow">
                              <td align="center"><%=i+1 %></td>
                              <td align="center"><%=aaModel.AchievementList[i].EmployeeName%></td>
                              <td align="left"><%=aaModel.AchievementList[i].PositionName%></td>
                              <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(aaModel.AchievementList[i].AchievementValue)%></td>
                            </tr>  
                        <%}
                    %>
                    <tr><td>�ϼ�</td><td colspan="3" align="right"><%=Workflow.Util.NumericUtils.ToMoney(total) %></td></tr>
                   <tr>
                     <td bgcolor="#eeeeee" align="right" colspan="7">
                     <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                     </webdiyer:AspNetPager>
                     </td>
                   </tr>
                  </table></td>
                <td width="3%">&nbsp;</td>
              </tr>
			    <tr class="emptyButtonsUpperRowHight">
				    <td colspan="3"></td>
			    </tr>
              <tr height="5">
                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                <td bgcolor="#eeeeee">&nbsp;</td>
                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
              </tr>
            </table></td>
        </tr>
      </table>
	</td>
	</tr>
	<tr>
		<td width="11"><img alt="" src="../images/white_main_bottom_left.gif"/></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"/></td>
		<td width="10"><img alt="" src="../images/white_main_bottom_right.gif"/></td>
	</tr>
</table>
</div>
</form>
</body>
</html>

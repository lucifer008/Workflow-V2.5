<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AchievementDetail.aspx.cs" Inherits="AchievementDetail" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>员工工作绩效</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/escExit.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/achinevement/achievementDetail.js"></script>
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
            <td align="left" bgcolor="#eeeeee">首页 -&gt; 业绩管理 -&gt; 员工工作绩效</td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">员工工作绩效</td>
          </tr>
          <tr class="emptyButtonsUpperRowHight">
            <td width="3%"></td>
            <td align="center"></td>
            <td width="3%"></td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="left"><table width="100%" border="1" cellspacing="1" cellpadding="3">
                <tr>
                  <td width="20%" nowrap="nowrap" class="item_caption">部门:</td>
                  <td width="30%" nowrap="nowrap" class="item_content"><%=Request.QueryString["PositionName"]%></td>
                  <td width="20%" nowrap="nowrap" class="item_caption">员工:</td>
                  <td width="30%" nowrap="nowrap" class="item_content"><%=Request.QueryString["EmployeeName"] %></td>
                </tr>
                <tr>
                  <td width="20%" nowrap="nowrap" class="item_caption">时间段:</td>
                  <td width="30%" nowrap="nowrap" class="item_content" colspan="3"><%=dateTimeString%></td>
                </tr>
              </table></td>
            <td width="3%">&nbsp;</td>
          </tr>
          
          <tr class="emptyButtonsUpperRowHight">
            <td width="3%"></td>
            <td align="center"></td>
            <td width="3%"></td>
          </tr>

          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellpadding="3" cellspacing="1">
                <tr>
                  <th width="8%" align="center" nowrap="nowrap">&nbsp;NO&nbsp;</th>
                  <th width="10%" align="center" nowrap="nowrap">订单号</th>
                  <th width="20%" align="center" nowrap="nowrap">客户名称</th>
                  <th width="20%" align="center" nowrap="nowrap">绩效（元）</th>
                  <th width="20%" align="center" nowrap="nowrap">废稿（元）</th>
                  <th width="10%" align="center" nowrap="nowrap">阶段</th>
                  <th align="center" nowrap="nowrap">备注</th>
                </tr>
                <%
                    decimal sumValue = 0;
                    decimal trashPaper = 0;
                    for (int i = 0; i < model.AchievementList.Count; i++)
                    {

                        sumValue += model.AchievementList[i].AchievementValue;
                        trashPaper += model.AchievementList[i].TrashPaper;
                        %>
                            <tr>
                              <td align="center"><%=i+1 %></td>
                              <td align="center"><a href="#" onclick="orderDetail(this);"><%=model.AchievementList[i].No%></a></td>
                             <td align="center"><%=model.AchievementList[i].CustomerName%></td> 
                              <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(model.AchievementList[i].AchievementValue)%></td>
                              <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(model.AchievementList[i].TrashPaper)%></td>
                              <td align="center"><%=model.AchievementList[i].PositionName%></td>
                              <td align="left"></td>
                            </tr>
                        <%
                    }
                %>

                <tr>
                  <td>当页合计</td>
                  <td>&nbsp;</td>
                  <td align="right" colspan="2"><%=Workflow.Util.NumericUtils.ToMoney(sumValue) %></td>
                  <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(trashPaper) %></td>
                  <td align="center">&nbsp;</td>
                  <td align="center">&nbsp;</td>
                </tr>
                <tr>
                  <td>总合计</td>
                  <td>&nbsp;</td>
                  <td align="right" colspan="2"><%=Workflow.Util.NumericUtils.ToMoney(model.AchievementValueTotal) %></td>
                  <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(model.WastePaperTotal) %></td>
                  <td align="center">&nbsp;</td>
                  <td align="center">&nbsp;</td>
                </tr>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CampaignList.aspx.cs" Inherits="CampaignList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta http-equiv="Pragma" content="no-cache" />
<title>营销活动一览</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/activities/campaginList.js"></script>
</head>
<body style="text-align:center">
<div align="center" style="width:99%; background-color:#ffffff" id="container">
<form id="form1" runat="server">
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
      <td bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0" >
          <tr>
            <td></td>
            <td align="left" bgcolor="#eeeeee">首页 -&gt; 活动管理 -&gt; 营销活动一览</td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">营销活动一览
               <input type="hidden" id="hiddTag" name="hiddTag" runat="server" />
               <input type="hidden" id="hiddId" name="hiddId" runat="server"/>
            </td>
          </tr>
          
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="left"></td>
            <td width="3%">&nbsp;</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center"><table width="100%" border="1" align="left" cellpadding="3" cellspacing="1">
                <tr>
                <th width="1%" nowrap="nowrap">&nbsp;NO&nbsp;</th>
                  <th width="10%" nowrap="nowrap">名称</th>
                  <th width="10%" nowrap="nowrap">说明</th>
                  <th width="10%" nowrap="nowrap">开始时间</th>
                  <th width="10%" nowrap="nowrap">结束时间</th>
                  <th width="1%" nowrap="nowrap">&nbsp;</th>
                </tr>
                <%
                    if(model.CampaignList != null)
                    {
                        for(int i = 1; i <= model.CampaignList.Count; i++)
                        {
                            Workflow.Da.Domain.Campaign campaign = model.CampaignList[i - 1];   
                     %>
                <tr>
                  <td nowrap="nowrap" align="center"><%= i %></td>
                  <td nowrap="nowrap" align="left"><%= campaign.Name %></td>
                  <td nowrap="nowrap" align="left"><%= campaign.Memo %></td>
                  <td nowrap="nowrap" align="center"><%= campaign.BeginDateTime.ToString("yyyy-MM-dd") %></td>
                  <td  nowrap="nowrap" align="center"><%= campaign.EndDateTime.ToString("yyyy-MM-dd") %></td>
                  <td nowrap="nowrap" align="left">
                      <a href="#" onclick="edmitCampagin(<%= campaign.Id %>)">编辑</a>
                      <a href="#" onclick="deletedCampagin(<%= campaign.Id %>)">删除</a>
                  </td>
                </tr>
                <%}%>
                 <tr>
                    <td colspan="12" align="right">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
                    </td>
                 </tr>
                <%} %>
              </table></td>
            <td width="3%">&nbsp;</td>
          </tr>
          	<tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
          <tr height="5">
            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
            <td bgcolor="#eeeeee">&nbsp;</td>
            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
          </tr>
        </table></td>
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

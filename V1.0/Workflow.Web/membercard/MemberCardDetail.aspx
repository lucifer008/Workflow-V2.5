<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberCardDetail.aspx.cs" Inherits="MemberCardDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>会员资料</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/escExit.js"></script>
    <style type="text/css">
<!--
.STYLE1 {color: #333333}
-->
</style>
</head>
<body style="text-align: center">
    <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
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
                            <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;会员管理&nbsp;-&gt;&nbsp;会员详细资料</td>
                            <td width="3%"></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="caption" align="center">会员卡详细资料</td>
                        </tr>
                        <tr>
                            <td width="3%"></td>
                            <td align="center">
                                <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                    <tr>
                                        <td nowrap class="item_caption">会员卡号:</td>
                                        <td colspan="3" class="item_content"><%= model.MemberCard.MemberCardNo %></td>
                                    </tr>
                                    <tr>
                                        <td nowrap class="item_caption">客户名称:</td>
                                            <%
                                                if(model.Customer != null)
                                                {
                                                     %>
                                        <td class="item_content">
                                            <%= model.Customer.Name %></td><%
                                                }
                                                     %>
                                            <%
                                                else 
                                                {
                                                     %><td class="item_content"></td><%
                                                }
                                                                                          %>
                                        <td nowrap class="item_caption">级别:</td>
                                        <td class="item_content"><%= model.MemberCard.MemberCardLevel.Name %></td>
                                    </tr>
                                           <tr>
                                                  <td nowrap class="item_caption">发卡时间:</td>
                                                 <td class="item_content"><%= model.MemberCard.InsertDateTime.ToString("yyyy-MM-dd") %></td>
                                        <td nowrap class="item_caption">所属行业:</td>
                                            <%
                                                if(model.Customer != null)
                                                {
                                                     %>
                                                  <td class="item_content"><%= model.Customer.SecondaryTrade.Name %></td>
                                            <%
                                                } %>
                                            <%
                                              else
                                              {
                                                 %><td class="item_content"></td>
                                            <%
                                              }
                                                %>
                                          </tr>
                                    <tr>
                                        <td nowrap class="item_caption">会籍起始日:</td>
                                        <td class="item_content"><%= model.MemberCard.MemberCardBeginDate.ToString("yyyy-MM-dd") %></td>
                                        <td nowrap class="item_caption">会籍终止日:</td>
                                        <td class="item_content"><%= model.MemberCard.MemberCardEndDate.ToString("yyyy-MM-dd") %></td>
                                    </tr>
                                    <tr>
                                        <td nowrap class="item_caption">持卡人:</td>
                                        <td class="item_content"><%= model.MemberCard.Name %></td>
                                        <td nowrap class="item_caption">联系电话:</td>
                                        <td class="item_content"><%= model.MemberCard.MobileNo %></td>
                                    </tr>
                                    <tr>
                                        <td nowrap class="item_caption">客户地址:</td>
                                            <%
                                              if(model.Customer != null)
                                              { 
                                                     %>
                                                <td class="item_content" colspan="3"><%= model.Customer.Address %></td>
                                            <%
                                                }
                                                     %>
                                            <%
                                                else
                                                {
                                                     %>
                                                  <td class="item_content" colspan="3"></td>
                                            <%
                                                }
                                                  %>
                                    </tr>
                                    <tr>
                                        <td nowrap class="item_caption">消费总额:</td>
                                        <td class="item_content"><%= model.MemberCard.ConsumeAmount %></td>
                                        <td nowrap class="item_caption">积分:</td>
                                        <td class="item_content"><%= model.MemberCard.Integral %></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="3%"></td>
                        </tr>
                        <%
                            if(model.MemberCard.MemberCardConcessionList.Count != 0)
                            { 
                         %>
                        <tr>
                            <td width="3%"></td>
                            <td align="left">参与的活动:</td>
                            <td width="3%"></td>
                        </tr>
                        <tr>
                            <td width="3%"></td>
                            <td align="center">
                                <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                    <tr>
                                        <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
                                        <th width="10%" nowrap>营销活动</th>
                                        <th width="10%" nowrap>优惠方案</th>
                                        <th width="10%" nowrap >参与时间</th>
                                        <th width="10%">备注</th>
                                    </tr>
                                     <% for (int i = 1; i <= model.MemberCard.MemberCardConcessionList.Count; i++)
                                        {                    
                                     %>
                                    <tr class="detailRow">
                                        <td align="center" nowrap><%= i %></td>
                                        <td nowrap align="left"><%= Campaigns[i - 1] %></td>
                                        <td nowrap align="left"><%= model.MemberCard.MemberCardConcessionList[i - 1].Concession.Name %></td>
                                        <td nowrap align="center"><%= model.MemberCard.MemberCardConcessionList[i - 1].JoinDateTime.ToString("yyyy-MM-dd") %></td>
                                        <td nowrap><%= model.MemberCard.MemberCardConcessionList[i - 1].Concession.Memo %></td>
                                    </tr>
                                    <%
                                        } %>
                                </table>
                            </td>
                            <td width="3%"></td>
                        </tr>
                        <%} %>
                        <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
                        <tr height="5">
                            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            <td bgcolor="#eeeeee">&nbsp;</td>
                            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
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
</body>
</html>

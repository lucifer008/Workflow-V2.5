<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CampaignCharge.aspx.cs" Inherits="CampaignCharge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>��Ա��ֵ</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../css/calendar-blue.css"  type="text/css" />
<script type="text/javascript" src="../js/Calendar2.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/membercard/campaignCharge.js"></script>
<style type="text/css">
<!--
.STYLE1 {color: #FF0000}
-->
</style>
</head>

<body style="text-align:center">
<form id="form1" runat="server">
<div align="center" style="width:99%; background-color:#FFFFFF;" id="container">
<input id="hiddMemberCardId" type="hidden"  runat="server" />
<input type="hidden" id="hiddChargeCount" name="ChargeCount"/><%--�Żݷ���:��ֵ���--%>
<input type="hidden" id="hiddUnitPrice" name="unitPrice"/><%--�Żݷ���:�Żݼ۸�--%>
<input type="hidden" id="hiddPresentCount" name="presentCount"/><%--�Żݷ���:����ӡ����--%>
<input type="hidden" id="hiddConcessionId" name="ConcessionId"/><%--�Żݷ���Id--%>
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
             <td width="3%">&nbsp;</td>
             <td align="left" bgcolor="#eeeeee">��ҳ&nbsp;-&gt;&nbsp; ��Ա����&nbsp;-&gt;&nbsp;��Ա��ֵ</td>
             <td width="3%"></td>         
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">��Ա��ֵ</td>
          </tr>
          <tr>
            <td></td>
            <td align="center">
               <table  border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                <tr>
                   <td nowrap class="item_caption">��Ա����<span class="STYLE1">*</span></td>
                   <td class="item_content">
                        <asp:TextBox ID="txtMemberCardNo" runat="server"></asp:TextBox>
                        <input type="button" name="search" id="btnSearch" class="buttons" value="����" />
                   </td>
                </tr>
               </table>
            </td>
            <td></td>
          </tr> 
          <tr id="tr1">
             <td></td>
             <td align="center">
                <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                    <tr>
                        <td nowrap class="item_caption">������</td>
                        <td colspan="2" class="item_content" id="membercardlevel"></td>
                    </tr>
                    <tr>
                        <td nowrap class="item_caption">�ͻ�����</td>
                        <td class="item_content" colspan="2" id="customername"></td>
                    </tr>
                    <tr>
                        <td nowrap class="item_caption">�Żݻ<span class="STYLE1">*</span></td>
                        <td colspan="2" class="item_content">
                        <select id="sltCampaign" name="sltCampaign" onchange="getConcessionByCamId();">
                            <option value="-1">��ѡ��</option> 
                            <%if (null != campaignModel.CampaignList)
                              {
                                  for (int i = 0; i < campaignModel.CampaignList.Count; i++)
                                  { 
                                  %>
                                 <option value="<%=campaignModel.CampaignList[i].Id %>"><%=campaignModel.CampaignList[i].Name%></option> 
                             <%
                               
                                }
                            } 
                                 %>
                        </select>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap class="item_caption">�Żݷ���<span class="STYLE1">*</span></td>
                        <td colspan="2" class="item_content">
                             <select id="sltConcession" name="sltConcession" onchange="getConcessionInfo();">
                                <option value="-1" >��ѡ��</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td nowrap class="item_caption" align="right">��ֵ���<span class="STYLE1">*</span></td>
                        <td colspan="2" class="item_content">
                            <input type="text" id="txtChargeSum" name="txtChargeSum" runat="server" onblur="compareSum();" />
                        </td>
                    </tr>
                    <tr>
                        <td nowrap class="item_caption" align="right">�μӻʱ��<span class="STYLE1">*</span></td>
                        <td colspan="2" class="item_content">
                            <div><input id="txtJoinDate" class="datetexts" runat="server" type="text" size="16" readonly="readonly" onfocus="setday(this)"/>         
	    		            </div>
	    		        </td>
                    </tr>
                    <tr>
                        <td width="3%">&nbsp;</td>
                        <td align="center" class="bottombuttons">
                            <asp:Button ID="btnInsert" runat="server" Cssclass="buttons" Text="ȷ��" OnClick="InsertCampaign" OnClientClick="return insertDataValidator();"/>
                        </td>
                       <td></td>
                    </tr> 
                </table>
            </td>
             <td></td>
          </tr>
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
</form>
</body>
</html>

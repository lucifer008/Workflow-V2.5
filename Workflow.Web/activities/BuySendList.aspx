<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuySendList.aspx.cs" Inherits="activities_BuySendList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>��M��N�һ��</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
	<meta http-equiv="Pragma" content="no-cache" />
	<link href="../css/css.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../js/jquery.js"></script>
	<script type="text/javascript" src="../js/default.js"></script>
	<script type="text/javascript" src="../js/activities/BuySendList.js"></script>
</head>
<body>
    <form id="form1" runat="server">
			   <input type="hidden" id="Hidden1" name="hiddDeletedTag" runat="server" />
               <input type="hidden" id="Hidden2" name="hiddDeletedId" runat="server"/>
               <input type="hidden" id="Hidden3" name="hiddTag" runat="server"/> 
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
            <td align="left" bgcolor="#eeeeee">��ҳ -&gt; ����� -&gt; �Żݷ���һ��</td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">�Żݷ���һ��
               <input type="hidden" id="hiddDeletedTag" name="hiddDeletedTag" runat="server" />
               <input type="hidden" id="hiddDeletedId" name="hiddDeletedId" runat="server"/>
              <input type="hidden" id="hiddTag" name="hiddTag" runat="server"/> 
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
                    
                    <th width="1%" nowrap="nowrap"> &nbsp;NO&nbsp;</th>
                    <th width="10%" nowrap="nowrap">����Ӫ���</th>
                    <th width="10%" nowrap="nowrap">��������</th>
                    <th width="10%" nowrap="nowrap">��������</th>
                    <th width="10%" nowrap="nowrap">����ӡ����</th>
                    <th width="10%" nowrap="nowrap">����ӡ����</th>
                    <th nowrap="nowrap">˵��</th>
                    <th width="1%" nowrap="nowrap">����</th>
                </tr>
                
               <%if (null!=model.BuySendList)
                 {
					 for (int i = 0; i < model.BuySendList.Count; i++)
                   { %>
                   <tr>
                      <td nowrap="nowrap"><%=i+1 %></td>
                      <td nowrap="nowrap"><%=model.BuySendList[i].Campaign.Name%></td>
                      <td nowrap="nowrap"><%=model.BuySendList[i].Name%></td>
                      <td nowrap="nowrap">��<%=model.BuySendList[i].BuyCount %>��<%=model.BuySendList[i].SendCount %></td>
                      <td nowrap="nowrap"><%=model.BuySendList[i].PaperCount %></td>
                      <td nowrap="nowrap"><%=model.BuySendList[i].UsePaperCount %></td>
                      <td nowrap="nowrap"><%=model.BuySendList[i].Description%></td>
                      <td nowrap="nowrap">
                          <a href="#" onclick="EdmitBuySend(<%=model.BuySendList[i].Id %>,<%=model.BuySendList[i].BaseBusinessTypePriceSetId%>)">�༭</a>&nbsp;&nbsp;
                          <a href="#" onclick="DeleteBuySend(<%=model.BuySendList[i].Id %>)")">ɾ��</a>
                      </td>  
                   </tr>   
                   <%} %> 
                  <tr>
                    <td colspan="12" align="right">
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
                    </td>
                 </tr> 
              <% }%> 
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
</body>
</html>

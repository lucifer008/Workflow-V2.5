<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetDailyOrderDefaultCondition.aspx.cs" Inherits="order_SetDailyOrderDefaultCondition" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>����Ĭ������</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../js/Calendar2.js"></script>
	<script type="text/javascript" src="../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/order/dailyOrderFilterCondition.js"></script>
    <script type="text/javascript" src="../js/escExit.js"></script>
    <base target="_self" />
</head>

<body style="text-align:center" scroll="no">
<form id="form1" runat="server" method="post" action="" >
<%--<input name="displayOrderInnerDayCount" id="displayOrderInnerDayCount" runat="server"/>--%>
<div align="left" style="width:100%" bgcolor="#ffffff"  id="container">
<table width="600" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td width="12"><img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0"/></td>
		<td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10"/></td>
		<td width="12"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td></td>
				<td align="left" bgcolor="#eeeeee">��ҳ -> ���ն��� -> ����Ĭ������</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center">����Ĭ������</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
                    <table width="400" border="1" cellspacing="1">
                      <tr>
                        <td height="20" align="left" class="item_content">
                        <%
                            string begDateTime = "", endDateTime = "";
                            if(null!=Session["BeginDateTime"]) begDateTime=Session["BeginDateTime"].ToString();
                            if (null != Session["EndDateTime"]) endDateTime = Session["EndDateTime"].ToString();
                             %>
                            <input name="txtBeginDateTime" id="txtBeginDateTime" type="text" class="datetexts"  size="12" onfocus="setday(this);" value="<%=begDateTime %>" readonly="readOnly" />&nbsp;��&nbsp;<input name="txtEndDateTime" id="txtEndDateTime" type="text" class="datetexts" size="12" onfocus="setday(this)" value="<%=endDateTime %>" readonly="readonly"/>&nbsp;<label>����ʱ��</label>
                        </td>
                     </tr>
                      <tr>
                        <td height="20" align="left">
                            <%if (Session["ORDER_FILTER_ALL"] != null)
                              {%>
                                <input name="All" type="checkbox" checked="checked" class="checks" id="chkAll" onclick="filterCondition(this);" />
                                <label for="chkAll">ȫ��</label>
                            <%}else 
                              {%>
                                <input name="All" type="checkbox" class="checks" id="chkAll1" onclick="filterCondition(this);" />
                                <label for="chkAll1">ȫ��</label>
                              <%} %>
                        </td>
                      </tr>
		              <tr>
	                    <td align="left"">
	                    <%if (Session["ORDER_FILTER_NOPREPAY"] != null)
                        { %>
	                        <input name="NoPrepay" type="checkbox" checked="checked" class="checks"  id="chkNoPrepay" onclick="filterCondition(this);" />
                            <label for="chkNoPrepay">δԤ������</label>
                        <%}else
                        {%>
	                        <input name="NoPrepay" type="checkbox" class="checks"  id="chkNoPrepay1" onclick="filterCondition(this);" />
                            <label for="chkNoPrepay1">δԤ������</label>
                        <%}%>
                        </td>
	                  </tr>          
	                  <tr>
	                    <td align="left">
	                    <%if (Session["ORDER_FILTER_NODISPATCH"] != null)
                        { %>
	                        <input name="NoDispatch" type="checkbox" checked="checked" class="checks"  id="chkNoDispatch" onclick="filterCondition(this);" />
                            <label for="chkNoDispatch">δ���䶩��</label>
                        <%}else
                        {%>
	                        <input name="NoDispatch" type="checkbox" class="checks"  id="chkNoDispatch1" onclick="filterCondition(this);" />
                            <label for="chkNoDispatch1">δ���䶩��</label>
                        <%}%>
                        </td>
	              </tr>
                      <tr>
                        <td height="20" align="left">
                        <%if (Session["ORDER_FILTER_WORKING"] != null) 
                        {%>
                            <input name="Working" type="checkbox" checked="checked" class="checks" id="chkWorking" onclick="filterCondition(this);"  />
                            <label for="chkWorking">�����ж���</label>
                        <%}
                        else
                        {%>
                            <input name="Working" type="checkbox" class="checks" id="chkWorking1" onclick="filterCondition(this);"  />
                            <label for="chkWorking1">�����ж���</label>
                        <%}%>
                        </td>
                      </tr>
                      <tr>
                        <td height="20" align="left">
                        <%if (Session["ORDER_FILTER_RECEPTION"] != null) 
                        {%>
                            <input name="cbReception" type="checkbox" checked="checked" class="checks" id="cbReception" onclick="filterCondition(this);"  />
                            <label for="cbReception">�Ӵ���</label>
                        <%}
                        else
                        {%>
                            <input name="cbReception" type="checkbox" class="checks" id="cbReception1" onclick="filterCondition(this);"  />
                            <label for="cbReception1">�Ӵ���</label>
                        <%}%>
                        </td>
                      </tr>
                       <tr>
                        <td height="20" align="left">
                        <%if (Session["ORDER_FILTER_ADMENDMENTED"] != null) 
                        {%>
                            <input name="cbAdmendmented" type="checkbox" checked="checked" class="checks" id="cbAdmendmented" onclick="filterCondition(this);"  />
                            <label for="cbAdmendmented">������</label>
                        <%}
                        else
                        {%>
                            <input name="cbAdmendmented" type="checkbox" class="checks" id="cbAdmendmented1" onclick="filterCondition(this);"  />
                            <label for="cbAdmendmented1">������</label>
                        <%}%>
                        </td>
                      </tr>
		              <tr>
                        <td align="left">
                        <%if (Session["ORDER_FILTER_FINISHED"] != null)
                       {%>
                            <input type="checkbox" class="checks" checked="checked" name="Finish" id="chkFinish"  onclick="filterCondition(this);" />
                            <label for="chkFinish"> �����깤����</label>
                       <%}
                       else
                       {%>
                            <input type="checkbox" class="checks" name="Finish" id="chkFinish1"  onclick="filterCondition(this);" />
                            <label for="chkFinish1"> �����깤����</label>

                       <%}%>
                       </td>
		              </tr>
                      <tr>
                        <td height="20" align="left">
                        <%if (Session["ORDER_FILTER_NOCLOSED"] != null) 
                        {%>
                            <input type="checkbox" class="checks" checked="checked" name="NoClosed"  id="chkNoClosed" onclick="filterCondition(this);"  />
                            <label for="chkNoClosed">�ѵǼǶ���</label>
                        <%}
                        else 
                        {%>
                            <input type="checkbox" class="checks" name="NoClosed"  id="chkNoClosed1" onclick="filterCondition(this);"  />
                            <label for="chkNoClosed1">�ѵǼǶ���</label>
                        <%}%>
                        </td>
                      </tr>		  
                      <tr>
                        <td height="20" align="left">
                        <%if (Session["ORDER_FILTER_SUCCESSED"] != null) 
                        {%>
                            <input type="checkbox" class="checks" checked="checked" name="Closed"  id="chkClosed" onclick="filterCondition(this);"  />
                            <label for="chkClosed">����ɶ���</label>
                        <%}
                        else 
                        {%>
                            <input type="checkbox" class="checks" name="Closed"  id="chkClosed1" onclick="filterCondition(this);"  />
                            <label for="chkClosed1">����ɶ���</label>
                        <%}%>
                        </td>
                      </tr>
		              <tr>
                        <td align="left">
                        <%if (Session["ORDER_FILTER_BLANKOUT"] != null)
                          {%>
                            <input type="checkbox" class="checks" checked="checked" name="BlankOut" id="chkBlankOut" onclick="filterCondition(this);"  />
                            <label for="chkBlankOut">�����϶���</label>
                        <%}
                          else
                        {%>
                            <input type="checkbox" class="checks" name="BlankOut" id="chkBlankOut1" onclick="filterCondition(this);"  />
                            <label for="chkBlankOut1">�����϶���</label>
                        <%}%>
                       </td>
		              </tr>
                    </table>
                </td>
			</tr>
			<tr  class="emptyButtonsUpperRowHight">
				<td colspan="3" style="text-align:center; color:Red;"></td>
			</tr>			
			<tr> 
				<td width="3%">&nbsp;</td>
				<td align="center" class="bottombuttons">
			        <input id="btnOk"  type="button" class="buttons" value="ȷ��"  onclick="saveFilterCondition();"  />&nbsp;
				  <input type="button" class="buttons"  onclick="window.close();" name="btnCancel" value="�ر�" />
                </td>
			</tr>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="3">  <input id="txtAction" name="txtAction" type="hidden" value="1" /></td>
			</tr>			
			<tr height="5">
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
			</tr>
			</table>
			</td>
		</tr>
	<tr>
		<td width="12"><img alt="" src="../images/white_main_bottom_left.gif" width="12" height="11"/></td>
		<td bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10"/></td>
		<td width="12"><img alt="" src="../images/white_main_bottom_right.gif" width="12" height="11"/></td>
	</tr>
	<tr></tr>
</table>
</div>
</form>
</body>
</html>
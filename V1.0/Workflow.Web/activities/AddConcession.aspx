<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddConcession.aspx.cs" Inherits="activities_AddConcession" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Expires" content="0" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>优惠方案<%=Title %></title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../css/calendar-blue.css" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
 <script type="text/javascript" src="../js/escExit.js"></script>
<script type="text/javascript" src="../js/activities/edmitConcession.js"></script>
<script type="text/javascript" language="javascript">    
    var BusinessTypePrice='<%=BusinessTypePrice%>';
</script>
    <base target="_self" />
</head>
<body  style="text-align: center">
<div align="center" style="width: 99%; background-color: #ffffff" id="container">
<form id="form1" runat="server">
<input type="hidden" id="hiddbaseBusinessTypePriceId" name="hiddbaseBusinessTypePriceId" value="" runat="server" /><%--业务类型Id--%>
<input type="hidden" id="hiddRoomPrice" name="hiddRoomPrice" value="" runat="server"/><%--门市价格--%>
<input type="hidden" name="hiddBaseBusinessTypePriceSerIds" id="hiddBaseBusinessTypePriceSerIds" runat="server"/>
<input type="hidden" id="hiddUnitPrice" name ="hiddUnitPrice" runat="server"/>  <%--优惠价格--%>     
<input type="hidden" id="hiddConcessionId" name ="hiddConcessionId" runat="server"/>  <%--优惠方案Id--%>            
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
              <td bgcolor="#FFFFFF"><table width="100%" border="1" cellspacing="0" >
                  <tr>
                    <td width="3%"></td>
                    <td align="left" bgcolor="#eeeeee" id="tdTitle">首页 -&gt; 活动管理 -&gt; 优惠方案添加</td>
                    <td width="3%"></td>
                  </tr>
                  <tr>
                    <td colspan="3" class="caption" align="center" id="tdTitle1">优惠方案添加</td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td align="left"><table width="100%" border="0" cellspacing="1" cellpadding="2">
                  <tr>
                       <td width="2%" nowrap="nowrap" class="item_caption">所属营销活动</td>
                       <td><asp:DropDownList ID="ddlCampaign"  runat="server" AppendDataBoundItems="True"><asp:ListItem Value="-1">请选择</asp:ListItem></asp:DropDownList></td>
                     </tr>
                        <tr>  
                          <td width="1%" nowrap="nowrap" class="item_caption">方案名称:</td>
                          <td width="94%"><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                          <td nowrap="nowrap" class="item_caption">说明:</td>
                          <td><asp:TextBox ID="txtDescription" runat="server" Columns="94" Rows="3" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                      </table></td>
                    <td>&nbsp;</td>
                  </tr>     
                  <tr>
                    <td>&nbsp;</td>
                    <td align="left">选择可参与该优惠方案的会员卡的类型及级别:</td>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td align="left"><table width="100%" border="1" cellspacing="1" cellpadding="3">
                        <tr>
                          <td width="14%" class="item_caption"><label for="checkbox2">打印卡:</label></td>
                          <td colspan="3">
                          <% if(null!=concessionModel.MemberCardLevelList)
                             {
                                 for (int i = 0; i < concessionModel.MemberCardLevelList.Count;i++ )
                                 { 
                                  
                                     %>
                                  <input type="checkbox"  id="cb<%=i %>" name="cbMemberLevel" value="<%=concessionModel.MemberCardLevelList[i].Id %>"/>
                                  <label onclick="SelectedCheckBox(cb<%=i %>);"><%=concessionModel.MemberCardLevelList[i].Name %></label>
                          <%
                                 }
                             } 
                                %>
                          </td>
                        </tr>
                      </table>
                     </td>
                    <td>&nbsp;</td>
                  </tr>
                 
                    <tr>
                    <td>&nbsp;</td>
                    <td align="left">选择基础价格并指定充值金额与赠送印张数:</td>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td >&nbsp;</td>
                    <td align="left"><input name="Submit" type="button" class="buttons" onclick="" value="选择价格" /></td>
                    <td>&nbsp;</td>
                  </tr>
                
                 <tr id="tr1"></tr>  
                 <tr>
                    <td>&nbsp;</td>
                    <td align="left">优惠方案带来的差价:</td>
                    <td>&nbsp;</td>
                 </tr>
                <tr id="tr2"></tr>
               </table>
                <tr>
                    <td colspan="3" align="center" class="bottombuttons"><asp:Button ID="InsertConcession" Cssclass="buttons" runat="server" Text="保存" OnClick="InsertConcessionInfo"/></td>
                </tr> 
                  <tr height="5">
                    <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                    <td bgcolor="#eeeeee">&nbsp;</td>
                    <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                  </tr>
              </td>
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

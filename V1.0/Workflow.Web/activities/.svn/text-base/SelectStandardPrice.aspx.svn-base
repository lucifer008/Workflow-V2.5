<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectStandardPrice.aspx.cs" Inherits="SelectStandardPrice" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>选择基础价格</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/check.js"></script>
    <script type="text/javascript" src="../js/escExit.js"></script>
    <script type="text/javascript" src="../js/activities/selectStandardPrice.js"></script>
    <base target="_self" />
</head>

<body style="text-align:center">
<div align="center" style="width:99%; background-color:#FFFFFF" id="container">
<form id="form1" runat="server" >
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
		<td bgcolor="#FFFFFF">
		<table width="100%" border="0" cellspacing="0">
			<tr>
				<td></td>
				<td align="left" bgcolor="#eeeeee">首页 -&gt; 系统管理 -&gt; 活动管理 -&gt; 选择基础价格</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center">选择基础价格</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
				<table width="100%" border="1" cellspacing="1" cellpadding="3">
                  <tr>
                    <td nowrap="nowrap" class="item_caption">业务类型:</td>
                    <td class="item_content" colspan="3">
                        <select name="sltBusinessType" size="1" id="sltBusinessType">
                        <option value="0">请选择</option>
                                <%
                                  for (int i = 0; i < model.BusinessTypeList.Count; i++)
                                  {   
                                %>
                                 <%
                                    if (model.BusinessTypeList[i].Id == lngBusinessTypeId)
                                    { 
                                         %>
                                <option value="<%=model.BusinessTypeList[i].Id%>" selected>
                                  <%=model.BusinessTypeList[i].Name%>
                                </option>
                                <%
                                     }
                                    else
                                    {
                                         %>
                                <option value="<%=model.BusinessTypeList[i].Id%>">
                                  <%=model.BusinessTypeList[i].Name%>
                                </option>
                                <%
                                     }
                                }
                                %>
                      </select>
                        <asp:Button ID="Search" Cssclass="buttons" runat="server" Text="检索" OnClick="SearchPrice" /></td>
                  </tr>
                </table></td>
				<td width="3%">&nbsp;</td>
			</tr>
			
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
				    <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <th width="1%" nowrap="nowrap">&nbsp;NO&nbsp;</th>
                            <th width="2%" nowrap="nowrap">业务类型</th>
                            <%for (int i = 0; i < model.PriceFactor.Count; i++){%>
                            <th width="2%" nowrap="nowrap"><%=model.PriceFactor[i].DisplayText%></th>
                            <%}%>
                            <th width="2%" nowrap="nowrap">成本价格</th>
                            <th width="2%" nowrap="nowrap">标准价格</th>
                            <th width="2%" nowrap="nowrap">活动价格</th>
                            <th width="2%" nowrap="nowrap">备用价格</th>
                            <th nowrap="nowrap" width="2%"></th>
                          </tr>
                      <%
                        if (null != model.BaseBusinessTypePriceSetList)
                        { 
                                  %>
                          <%for (int i = 0; i < model.BaseBusinessTypePriceSetList.Count; i++)
                            {
                                %>
                          <tr class="detailRow" title="row<%=i %>">
                            
                            <td align="center"><a href="#" onclick="choiceRadio(<%=i %>,<%=model.BaseBusinessTypePriceSetList[i].Id%>)"><%=i+1%></a></td>
                            <td align="left"><%=model.BaseBusinessTypePriceSetList[i].BusinessType.Name%></td>
                            
                            <%
                                for (int j = 0; j < model.PriceFactor.Count; j++)
                                {
                                    %>
                                    <td align="center" nowrap="nowrap"><%=model.BaseBusinessTypePriceSetList[i].Texts[j]%></td>
                            <%
                                }
                                %>
                            <td class="num"><%=model.BaseBusinessTypePriceSetList[i].CostPrice %></td>
                            <td class="num"><%=model.BaseBusinessTypePriceSetList[i].StandardPrice %></td>
                            <td class="num" id="tdStandardPrice<%=i%>"><%=model.BaseBusinessTypePriceSetList[i].ActivityPrice %></td>
                            <td class="num"><%=model.BaseBusinessTypePriceSetList[i].ReservePrice %></td>
                            <td><a href="#" onclick="choiceRadio(<%=i %>,<%=model.BaseBusinessTypePriceSetList[i].Id%>)">选择</a></td>                          
                          </tr>
                          <%
                            }
                                %>
                           <tr>
                             <td colspan="14" align="right">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
                             </td>
                          </tr>
                      <%
                        }
                           %> 
                        </table>
                </td>
				<td width="3%">&nbsp;</td>
			</tr>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
			</tr>
			<tr height="10px">
				<td colspan="3"></td>
			</tr>
			<tr height="5">
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
			</tr>
		</table>

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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPrice.aspx.cs" Inherits="AddPrice" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>新增价格</title>
  <link href="../../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../js/default.js"></script>
<script type="text/javascript" src="../../js/system/priceManager/MangePrice.js"></script>
<script type="text/javascript" src="../../js/check.js"></script>
<script type="text/javascript" language="javascript" src="../../js/escExit.js"></script>
<script type="text/javascript" src="../../js/system/priceManager/addPriceSet.js"></script>
<script type="text/javascript" src="../../js/escExit.js"></script>
<script type="text/javascript" >
<%if (closeSelf) {%>
  $().ready(function(){
    var parentWindow=window.opener;
    if (parentWindow!=null){
      window.close();
      return;
      }
  });
<%} %>
</script>
<base target="_self"></base>
</head>
<body style="text-align:center">
<form id="MainForm" method="post" runat="server">
  <%if (closeSelf) { return; } %>
<div align="center" style="width:99%" bgcolor="#ffffff" id="container">
  <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
	<tr>
		<td width="11"><img alt="" src="../../images/white_main_top_left.gif" /></td>
		<td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif" height="10" /></td>
		<td width="10"><img alt="" src="../../images/white_main_top_right.gif"
			width="12" height="11"/></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td bgcolor="#FFFFFF">
		<table width="100%" border="0" cellspacing="0">
			<tr>
				<td></td>
				<td align="left" bgcolor="#eeeeee">首页 -&gt; 系统管理 -&gt; 价格管理 -&gt; 新增价格</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center">新增价格</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
				<table border="1" cellpadding="3" cellspacing="1" width="100%"
					align="left">
					<tr>
						<td nowrap class="item_caption" style="height: 24px">业务类型:</td>
						<td colspan="3" class="item_content" align="left">
                            &nbsp;
                            <asp:DropDownList ID="ddlistBusinessType" runat="server" OnSelectedIndexChanged="ddlistBusinessType_SelectedIndexChanged" AutoPostBack="True">

                            </asp:DropDownList>
                        </td>
					</tr>
					<% 	    if (closeSelf) return;
	    		    int intPriceFactorCount = model.PriceFactor.Count;
                    for (int i = 0, j = 0; i < intPriceFactorCount / 2; i++, j++)
                       {
                           //初始化的时候不显示
                           if (intAction == Workflow.Support.Constants.ACTION_INIT) break;
                    %>
                    <tr>
						<td nowrap class="item_caption"><%=model.PriceFactor[j].DisplayText %> :</td>
						<td class="item_content" align="left">
                            <select name="sltPriceFactor" id=<%="PriceFactor" + model.PriceFactor[j].Id.ToString() %> title=<%=model.PriceFactor[j].DisplayText %> onchange="PriceFactor_Changed(this)">
                            <option value="<%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_KEY %>"><%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_TEXT %></option>
                            <%for (int k = 0; k < model.PriceFactor[j].FactorValueList.Count; k++)
                              {%>
                                <option value="<%=model.PriceFactor[j].FactorValueList[k].Id %>"><%=model.PriceFactor[j].FactorValueList[k].Text %></option>  
                              <%  
                              } %>
                            </select>
                            </td>
                        <td nowrap class="item_caption" ><%=model.PriceFactor[++j].DisplayText %> :</td>
                        <td class="item_content" align="left">
                            <select name="sltPriceFactor" id=<%="PriceFactor" + model.PriceFactor[j].Id.ToString() %>  title=<%=model.PriceFactor[j].DisplayText %> onchange="PriceFactor_Changed(this)">
                            <option value="<%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_KEY %>"><%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_TEXT %></option>
                            <%for (int k = 0; k < model.PriceFactor[j].FactorValueList.Count; k++)
                              {%>
                                <option value="<%=model.PriceFactor[j].FactorValueList[k].Id %>"><%=model.PriceFactor[j].FactorValueList[k].Text %></option>  
                              <%  
                              } %>
                            </select>
                            </td>
					</tr>
                    <%
                           
                    }%>
                    <% 
                        //最后一行的处理
                        if (intAction == Workflow.Support.Constants.ACTION_SEARCH && intPriceFactorCount != 0 && intPriceFactorCount % 2 == 1)
                        { 
                    %>
                    <tr>
						<td nowrap class="item_caption"><%=model.PriceFactor[intPriceFactorCount - 1].DisplayText%> :</td>
						<td class="item_content" colspan="3" align="left">
                            <select name="sltPriceFactor" id=<%="PriceFactor" + model.PriceFactor[intPriceFactorCount - 1].Id.ToString() %>  title=<%=model.PriceFactor[intPriceFactorCount - 1].DisplayText %>  onchange="PriceFactor_Changed(this)">
                            <option value="<%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_KEY %>"><%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_TEXT %></option>
                            
                            <%for (int k = 0; k < model.PriceFactor[intPriceFactorCount-1].FactorValueList.Count; k++)
                              {%>
                                <option value="<%=model.PriceFactor[intPriceFactorCount-1].FactorValueList[k].Id %>"><%=model.PriceFactor[intPriceFactorCount - 1].FactorValueList[k].Text%></option>  
                              <%  
                              } %>
                            </select>
                            </td>
                    </tr>
                    <%
                        }        
                     %>
					  <tr>
						<td nowrap class="item_caption">成本价格:</td>
						<td nowrap class="item_content">
                            &nbsp;<asp:TextBox ID="txtCostPrice" runat="server" CssClass="num"></asp:TextBox></td>
						<td nowrap class="item_caption">标准价格:</td>
						<td nowrap class="item_content">
                            &nbsp;<asp:TextBox ID="txtStandardPrice" runat="server" CssClass="num"></asp:TextBox></td>
					  </tr>
					  <tr>
						<td nowrap class="item_caption" style="height: 24px">活动价格:</td>
						<td nowrap class="item_content" style="height: 24px">
                            &nbsp;<asp:TextBox ID="txtActivityPrice" runat="server" CssClass="num"></asp:TextBox></td>
						<td nowrap class="item_caption" style="height: 24px">备用价格:</td>
						<td nowrap class="item_content" style="height: 24px">
                            &nbsp;<asp:TextBox ID="txtReservePrice" runat="server" CssClass="num"></asp:TextBox></td>
					  </tr>
					<tr>
						<td nowrap class="item_caption">备注:</td>
						<td colspan="3" align="left" nowrap><span class="item_content" style="padding-top: 2px; padding-bottom: 2px;">&nbsp;<asp:TextBox
                                ID="txtMemo" runat="server" MaxLength="200" Rows="3" TextMode="MultiLine" Width="400px"></asp:TextBox></span></td>
					</tr>
				</table>
			</tr>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
			</tr>
			<tr>
				<td colspan="3" align="center" class="bottombuttons">
                    <asp:Button ID="btnSave" runat="server" CssClass="buttons" OnClick="BtnSave_Click" OnClientClick="return checkProcess();"
                        Text="保存" />&nbsp;
                    <input ID="btnCancel" name="btnCancel" class="buttons" type="button" onclick ="window.close();" value="关闭" /></td>
			</tr>
			<tr height="5">
				<td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
			</tr>
		</table>
		</td>
	</tr>
</table>
  </td>
  </tr>
  	<tr>
		<td width="11"><img alt="" src="../../images/white_main_bottom_left.gif"/></td>
		<td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif"/></td>
		<td width="10"><img alt="" src="../../images/white_main_bottom_right.gif"/></td>
	</tr>
</table>
</div>
</form>
</body>
</html>

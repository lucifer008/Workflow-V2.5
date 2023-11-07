<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddBuySend.aspx.cs" Inherits="activities_AddBuySend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>买M送N活动</title>
	<link href="../css/css.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../js/jquery.js"></script>
	<script type="text/javascript" src="../js/default.js"></script>
	<script type="text/javascript" src="../js/activities/AddBuySend.js"></script>
	<script type="text/javascript">
		var buySendId = '<%=model.BuySendId %>';
		var priceInfo = '<%=priceInfo%>';
	</script>
	<base target="_self" />
</head>
<body>
	<div align="center" style="width: 99%; background-color: #ffffff" id="container">
		<form id="form1" runat="server">
		
		<input type="hidden" id="hidBuySendId" runat="server" />
			  <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
                    <td width="10"><img alt="" src="../images/white_main_top_right.gif" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td bgcolor="#FFFFFF">
                                   <table width="100%" border="0" cellspacing="0">
                                        <tr>
                                            <td></td>
                                            <td align="left" bgcolor="#eeeeee">首页 -&gt; 活动管理 -&gt;买M送N活动方案<%=model.ActionInfo %></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" class="caption" align="center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="3%"> &nbsp;</td>
                                            <td align="left">
                                                <table width="100%" border="1" cellspacing="1" cellpadding="3">
                                                    <tr>
												<td colspan="3" class="caption" align="center">买M送N活动方案<%=model.ActionInfo %>
													</td>
													 </tr>
															<tr>
                                                        <td nowrap="nowrap" class="item_caption">所属营销活动:</td>
                                                        <td class="item_content" colspan="3">
															<select id="selectCapaign" name="selectCapaign">
																<option value="-1">请选择</option>
																<% if (model.CampaignList != null)
																   {
																	   foreach (Workflow.Da.Domain.Campaign campaign in model.CampaignList)
																	   {
																		   if (model.CampaignId == campaign.Id)
																		   {
																%>
																	<option selected="selected" value="<%=campaign.Id %>"><%=campaign.Name%></option>
																	<%}
												 else
												 { %>
		 																<option value="<%=campaign.Id %>"><%=campaign.Name%></option>
																<%}
											}
											}%>
															   </select>
														</td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">方案名称:</td>
                                                        <td class="item_content">
															<input type="text" id="campaignName" name="campaignName" value="<%=model.BuySendName %>" />
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td class="item_caption">说明:</td>
                                                        <td class="item_content" colspan="3">
                                                        <input id="description" name="description" type="text" style="width:300px;height:100px;" value="<%=model.BuySendDescription %>" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="item_caption">机器和纸型:</td>
                                                        <td class="item_content" colspan="3">
															<table>
																<tr>
																	<td>
																	<div id="factorMemory">
																	<select id="sltBusinessType" name="sltBusinessType" onchange="queryPriceSet(this)">
																		<option value='-1' selected="selected">请选择</option>
																		<%for (int i = 0; i < model.BusinessTypeList.Count; i++)
																		  {   
																		%>
																		<%
																			if (model.BusinessTypeList[i].Id == model.BusinessTypeId)
																		  { %>
																		<option  value="<%=model.BusinessTypeList[i].Id%>" selected="selected" >
																		  <%=model.BusinessTypeList[i].Name%>
																		</option>
																		<%}
																		  else
																		  {%>
																		<option value="<%=model.BusinessTypeList[i].Id%>">
																		  <%=model.BusinessTypeList[i].Name%>
																		</option>
																		<%
																		  }
																		}
																		%>
                              </select></div>&nbsp; <%--价格因素--%>
                              
													
																	</td>
																	<%--<td>
																		<input type="button" id="inputBtnOk" name="inputBtnOk" />
																		<input type="button" id="inputBtnReset" name="inputBtnReset" />
																	</td>--%>
																</tr>
															</table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="item_caption">数量设置:</td>
                                                        <td class="item_content" colspan="3">
                                                      
															买&nbsp;&nbsp;
															<input type="text" id="inputBuyCount" name="inputBuyCount" style="width:60px;" value="<%=model.BuyCount %>"/>&nbsp;&nbsp;送&nbsp;&nbsp;
															<input  type="text" id="inputSendCount" name="inputSendCount" style="width:60px;" value="<%=model.SendCount %>"/>
															&nbsp;例如：买1送1
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="item_caption">送印章总量:</td>
                                                        <td class="item_content" colspan="3">
															<input type="text" id="inputTotalCount" name="inputTotalCount" style="width:60px;" value="<%=model.PaperCount %>"/>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="item_caption">备     注:</td>
                                                        <td class="item_content" colspan="3">
															<input type="text" id="inputMemo" name="inputMemo" style="width:300px;height:100px;" value="<%=model.BuySendMemo %>" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="3%"> &nbsp;</td>
                                        </tr>
                                       
                                        <tr>
                                            <td width="3%">&nbsp;</td>
                                            <td align="left"></td>
                                            <td width="3%">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td width="3%">&nbsp;</td>
                                            <td align="center">
                                                
                                            </td>
                                            <td width="3%">&nbsp;</td>
                                        </tr>
                                        <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td>
                                        </tr>
                                        <tr>                            
                                            <td colspan="3" align="center" class="bottombuttons">
                                                <input type="button" onclick="submitCheck();" value="保存" /> 
                                            </td>
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

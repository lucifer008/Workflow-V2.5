<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDiscountConcession.aspx.cs" Inherits="activities_AddDiscountConcession" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="Pragma" content="no-cache" />
    <title>打折方案<%=model.ActionInfo %></title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" language="javascript" src="../js/default.js"></script>
    <script type="text/javascript" language="javascript" src="../js/activities/DiscountConcession.js"></script>
</head>
<body style="text-align: center" onload="initDiscount('<%=model.DiscountInfo %>')">
    <div align="center" style="width: 99%; background-color: #ffffff" id="container">
        <form id="form1" runat="server">
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
                                            <td align="left" bgcolor="#eeeeee">首页 -&gt; 活动管理 -&gt;打折方案<%=model.ActionInfo %></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" class="caption" align="center">打折方案<%=model.ActionInfo %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="3%"> &nbsp;</td>
                                            <td align="left">
                                                <table width="100%" border="1" cellspacing="1" cellpadding="3">
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">所属营销活动:</td>
                                                        <td class="item_content" colspan="3">
															<select id="Select1" name="campaign">
																<option value="0">请选择</option>
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
                                                            <input id="project" name="project" type="text" value="<%=model.DiscountName %>" />
                                                        </td>
                                                    </tr>
                                                    <tr>
														<td nowrap="nowrap" class="item_caption">活动冲值金额:</td>
                                                        <td class="item_content">
                                                            <input id="chargeAmount" name="chargeAmount" type="text" value="<%=model.ChargeAmount %>" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="item_caption">说明:</td>
                                                        <td class="item_content" colspan="3">
															<input id="memo" name="memo" type="text" style="width:300px;height:100px;" value="<%=model.DiscountMemo %>" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="item_caption">机器和纸型:</td>
                                                        <td class="item_content" colspan="3">
															机器:
														<select id="machine" multiple="true" size="6">
															<%if (model.MachineTypeList != null)
										 {
											 foreach (Workflow.Da.Domain.MachineType machineType in model.MachineTypeList)
											 { %>
															<option value="<%=machineType.Id %>"><%=machineType.Name%></option>
															<%}
									 }%>
														</select>
														&nbsp;&nbsp;&nbsp;
														纸型:
                 										<select id="paper" multiple="true" size="6" >
															<%if (model.PaperList != null)
										 {
											 foreach (Workflow.Da.Domain.PaperSpecification paper in model.PaperList)
											 { %>
																<option value="<%=paper.Id %>"><%=paper.Name%></option>
															<%}
									 }%>
														</select>
														&nbsp;&nbsp;&nbsp;
														折扣:
														<input id="discount" style="width:30px" type="text" value="" />%
														&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<input type="button" onclick="addDiscountValue();" value="加入" />
														&nbsp;&nbsp;&nbsp;
														<input type="button" onclick="resetDiscount();" value="重置" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="item_caption">内容信息:</td>
                                                        <td class="item_content" colspan="3">
															<div id="showDiscount" style="font-size:14px;border:solid 1px #7F9DB9;width:355px;height:150px;overflow-y:scroll;"></div>
															<div id="showDiscountCount" style="width:200px;height:22px;"></div>
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
                                                <input type="button" onclick="saveDiscount();" value="保存" /> 
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
			<input id="discountInfo" name="discountInfo" type="hidden" value="" />
        </form>
    </div>
</body>
</html>

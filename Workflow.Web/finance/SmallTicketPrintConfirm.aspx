<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmallTicketPrintConfirm.aspx.cs" Inherits="finance_SmallTicketPrintConfirm" %>
<%@ Import Namespace="Workflow.Da.Domain" %>
<%@ Import Namespace="Workflow.Support" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>打印小票</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/finance/smallTicketPrintConfirm.js"></script>
    <object id="WebBrowser" height="0" width="0"></object>
    <OBJECT  ID="jatoolsPrinter" CLASSID="CLSID:B43D3361-D975-4BE2-87FE-057188254255" codebase="jatoolsPrinter.cab"></OBJECT> 
    <style type="text/css">
		#page1 td{ font-size:10px; color:black;font-weight:bold;}
		.only_for_print{display:none;}
	</style>
    <script type="text/javascript">
        function InitPage() {
            //debugger;
            $('#inputName').val( encodeURIComponent($('#divMain')[0].innerHTML));
            $('#imgBtnSumbit').click();
        }
    </script>
</head>
   
<body style="text-align: center" onload="InitPage()">
    <form id="form1" action="" method="post" runat="server" >
         <div style="display:none;">
         <input type="text" id="inputName" name="inputName" value="" />
         <asp:ImageButton ID="imgBtnSumbit"  PostBackUrl="http://workflow.feikan.com/Print/LkSmallTicketPrint.aspx"  runat="server" OnClick="imgBtnSumbit_Click"/>
         </div>
         <div style=" text-align:center;">
            正在转向打印页面
         </div>
        <div id="divMain">
            <div align="center" style="width: 99%; " bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td style="width: 12px"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 ->打印小票</td>
                                <td></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">打印小票</td></tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center" >
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap class="item_caption">条码:</td>
                                            <td class="item_content"><%=orderNo %></td>
                                            <td nowrap class="item_caption">卡号:</td>
                                            <td class="item_content"><%=model.NewOrder.MemberCardNo %></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="15%"nowrap>业务类型</th>
                                            <th width="15%"nowrap>数量</th>
                                            <th width="10%"nowrap>单价</th>
                                            <th width="15%"nowrap>总价</th>
                                        </tr>
                                        <%
                                          for (int index = 0; index < model.OrderItemList.Count;index++ )
                                          {%>
                                        <tr class="detailRow">
                                            <td><%=model.OrderItemList[index].BusinessTypeName %></td>
                                            <td><%=Convert.ToInt32(model.OrderItemList[index].Amount) %></td>
                                            <td><%=model.OrderItemList[index].UnitPrice%></td>
                                            <td><%=Convert.ToString((model.OrderItemList[index].Amount*model.OrderItemList[index].UnitPrice)) %></td> 
                                        </tr>
                                        <%} %>
                                        <tr class="detailRow"><td align="left" class="item_caption">合计</td><td colspan="3" align="right"><%=model.NewOrder.SumAmount %></td></tr>
                                        <tr class="detailRow"><td align="left" class="item_caption" style="height: 29px">实收</td><td colspan="3" align="right" style="height: 29px"><%=model.NewOrder.PaidAmount %></td></tr>
                                        <tr class="detailRow"><td align="left" class="item_caption">开票：</td><td colspan="3" align="right"><%=model.NewOrder.PaidTicketAmount %></td></tr>
                                       <%-- <tr class="detailRow"><td align="left" class="item_caption">折让</td><td colspan="3" align="right"></td></tr>
                                        <tr class="detailRow"><td align="left" class="item_caption">抹零</td><td colspan="3" align="right"></td></tr>--%>
                                        <%
											if (model.PaymentConcessionList != null)
											{
												for (int i = 0; i < model.PaymentConcessionList.Count; i++)
												{ %>
                                          <tr><td align="left" class="item_caption" style="height: 29px"><%=model.PaymentConcessionList[i].Memo%></td><td colspan="3" align="right" style="height: 29px"><%=model.PaymentConcessionList[i].ConcessionAmount%></td></tr>
                                        <%}
									  }%>
                                     </table>
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td>
                                    
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table> 
                        
                        <%--小票打印--%>
                        <div id='myheader' style="text-align:left;" class="only_for_print"><img src="../images/Logo5.gif" alt="logo"/></div>
                        <div id="page1" class="only_for_print"  style="background:#ffffff;float:left; font-size:10px; text-align:left; color:Black; font-weight:bold; ">
							<div style="text-align:center; font-size:12px; font-weight:bold;"><%=systemModel.Company.Name %> &nbsp;&nbsp;<%=systemModel.BranchShop.Name %></div>
							时  间：<%=DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss")%><br/>
							订单号：<%=orderNo %>
							<table width="180px">
                                        <tr>
                                            <td width="20%"nowrap style="font-size:10px;">加工内容</td>
                                            <td width="10%"nowrap style="font-size:10px;" align="right">数量</td>
                                            <td width="10%"nowrap align="right" style="font-size:10px;">单价</td>
                                            <td width="15%"nowrap align="right" style="font-size:10px;"> 总价</td>
                                        </tr>
                                        <%
                                          for (int index = 0; index < model.OrderItemList.Count;index++ )
                                          {%>
                                        <tr>
                                            <td style="font-size:8px;"> 
											<%foreach (OrderItem item in model.NewOrder.OrderItemList)
											{
											if (item.Id == model.OrderItemList[index].Id){
												if (!String.IsNullOrEmpty(item.TargetTable) && item.TargetTable.Equals("PROCESS_CONTENT"))
												{
													string name = item.Name;
													if (name.Length > 5)
													{
														Response.Write(name.Substring(0,5));
													}
													else
													{
														Response.Write(name);
													}
												}
											%>
				 
											<%}
												}%>
											</td>
                                            <td style="font-size:8px;">
                                           
												<%=model.OrderItemList[index].Amount %>
											</td>
                                            <td align="right" style="font-size:8px;"><%=model.OrderItemList[index].UnitPrice%></td>
                                            <td align="right" style="font-size:8px;"><%= Workflow.Util.NumericUtils.ToMoney(model.OrderItemList[index].Amount*model.OrderItemList[index].UnitPrice) %></td> 
                                        </tr>
                                        <%} %>
                                        <tr>
											<td></td>
											<td></td>
											<td align="right" style="font-size:10px;">合计</td>
											<td align="right" style="font-size:10px;"><%=model.NewOrder.SumAmount %></td>
										</tr>
										  <%
											  decimal discount = 0.00M;						  	
											if (model.PaymentConcessionList != null)
											{
												for (int i = 0; i < model.PaymentConcessionList.Count; i++)
												{
													if (model.PaymentConcessionList[i].ConcessionType.Equals(Constants.CONCESSION_TYPE_CONCESSION_VALUE) ||
													   model.PaymentConcessionList[i].ConcessionType.Equals(Constants.CONCESSION_TYPE_RENDERUP_VALUE) ||
													   model.PaymentConcessionList[i].ConcessionType.Equals(Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE) ||
													   model.PaymentConcessionList[i].ConcessionType.Equals(Constants.CONCESSION_TYPE_ZERO_VALUE))
													{
														discount += model.PaymentConcessionList[i].ConcessionAmount; 
													}
												}
										}%>
                                          <tr>
												
											
											<td align="right"  style="font-size:10px;" colspan="3">优惠</td>
											<td align="right" style="font-size:10px;"><%=discount%></td>
										  </tr>
                                     
                                        <tr>
											<td></td>
											<td></td>
											<td align="right" style="font-size:10px;">实收</td>
											<td align="right" style="font-size:10px;"><%=model.NewOrder.PaidAmount %></td>
										</tr>
                                       
                                        
                                       <%-- <tr class="detailRow"><td align="left" class="item_caption">折让</td><td colspan="3" align="right"></td></tr>
                                        <tr class="detailRow"><td align="left" class="item_caption">抹零</td><td colspan="3" align="right"></td></tr>--%>
                                      
									 <%if (!String.IsNullOrEmpty(systemModel.BranchShop.Memo)) {%>
									  <tr>
											<td colspan="4" align="left">联系电话: <%=systemModel.BranchShop.Memo %></td>
										</tr>
										<%} %>
										<%if (!String.IsNullOrEmpty(systemModel.Company.Memo)) {%>
										 <tr>
											<td colspan="4" align="left">投诉电话: <%=systemModel.Company.Memo %></td>
										</tr>
										<%} %>
										 <tr>
											<td colspan="4" align="left"></td>
										</tr>
										<tr>
											<td colspan="4" align="left">网址: www.mylandking.com.cn</td>
										</tr>
										<tr>
											<td colspan="4" align="center">欢迎再次光临</td>
										</tr>
										<tr>
											<td colspan="4" align="center">多谢惠顾</td>
										</tr>
                                     </table>
						</div>			
                    </td>
                </tr>
                <tr>
                    <td width="12"><img alt="" src="../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
        </div>
    </form>
</body>
</html>

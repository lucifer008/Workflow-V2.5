<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExceptionPriceOrderView.aspx.cs"   Inherits="ExceptionPriceOrderView" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>异常价格加订单汇总</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../../css/thickbox.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../../js/Calendar2.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <script type="text/javascript">
//	function showOrderDetail(){
//			showPage('../../order/OrderDetail.html',null,700,800,false,false);
//	}
	showSelectCustomer=function(){
		var customerName=$("#txtCustomerName").val();
		showPage('../../customer/SelectCustomer.aspx?customerName='+escape(customerName),null,890,566,false,false);
	}
	setOptionSelected=function(id,value){
		var selObj=document.getElementById(id);
		if(selObj.options.length>0){
			var index=0;
			while(index<selObj.options.length){
				if(selObj.options[index].text==value){
					selObj.options[index].selected=true;
				}
				index++;
			}
		}
	}
	function selectCustomer(objCustomer){
		if(objCustomer==null) return;
		$("#txtCustomerName").attr("value",objCustomer.Name);
	}
    </script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12">
                        <img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0"/></td>
                    <td width="99%" bgcolor="#FFFFFF">
                        <img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                    <td width="12">
                        <img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"/></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页 -> 财务处理 -&gt; 财务查询 -&gt; 异常价格加订单汇总</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    异常价格加订单汇总</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center">
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            客户名称:</td>
                                                        <td class="item_content">
                                                            <input id="txtCustomerName" name="CustomerName" type="text" class="texts" value="<%=model.CustomerName %>" />
                                                            <input type="button" class="buttons selectButtons" value="选择客户" onclick="showSelectCustomer();" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            抹零:</td>
                                                        <td class="item_content">
                                                            <select id="SltZero" name="SltZero">
                                                                <option>小于</option>
																<option>小于等于</option>
																<option>等于</option>
																<option selected="selected">大于等于</option>
																<option>大于</option>
                                                            </select>
                                                            <%if(model.Operator1!=null){ %>
                                                            <script type="text/javascript">
                                                             setOptionSelected('SltZero','<%=model.Operator1 %>');
                                                            </script>
                                                            <%} %>
                                                            <input name="Zero" id="txtZero" type="text" class="num" value="<%=model.Amount1 %>" size="10" />
                                                            元</td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            优惠:</td>
                                                        <td class="item_content">
                                                            <select id="SltConcession" name="SltConcession">
                                                                <option>小于</option>
																<option>小于等于</option>
																<option>等于</option>
																<option selected="selected">大于等于</option>
																<option>大于</option>
                                                            </select>
                                                            <%if(model.Operator2!=null){ %>
                                                            <script type="text/javascript">
                                                             setOptionSelected('SltConcession','<%=model.Operator2 %>');
                                                            </script>
                                                            <%} %>
                                                            <input name="Concession" id="txtConcession" type="text" class="num" value="<%=model.Amount2 %>" size="10" />
                                                            元</td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            折让:</td>
                                                        <td class="item_content">
                                                            <select id="sltGiveAway" name="sltGiveAway">
                                                                <option>小于</option>
																<option>小于等于</option>
																<option>等于</option>
																<option selected="selected">大于等于</option>
																<option>大于</option>
                                                            </select>
                                                            <%if(model.Operator3!=null){ %>
                                                            <script type="text/javascript">
                                                             setOptionSelected('sltGiveAway','<%=model.Operator3 %>');
                                                            </script>
                                                            <%} %>
                                                            <input name="GiveAway" id="txtGiveAway" type="text" class="num" value="<%=model.Amount3 %>" size="10" />
                                                            元</td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">
                                                            时间段:</td>
                                                        <td class="item_content">
                                                            <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts" value="<%=model.BalanceDateTimeString %>"  size="16"  onfocus="setday(this);" readonly="readonly"/>
                                                          
                                                            <input id="txtTo" type="text" name="EndDateTime" class="datetexts" value="<%=model.InsertDateTimeString %>"  onfocus="setday(this);"  size="16" readonly="readonly"/>
                                                               
                                                       </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="right" style="padding-right: 10px"><asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="return checkData();" Text="查询" />
                                                        <asp:Button ID="btnDispatchPrint" CssClass="buttons" runat="server" Text="打印" OnClick="btnDispatchPrint_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="left">
                                    <table width="100%" border="1" cellpadding="1" cellspacing="1">
                                        <tr align="center">
                                            <th width="5%" nowrap>NO</th>
                                            <th width="7%" nowrap>订单号</th>
                                            <th width="15%" nowrap>客户名称</th>
                                            <th width="7%" nowrap>总额</th>
                                            <th width="7%" nowrap>实收</th>
                                            <th width="7%" nowrap>抹零</th>
                                            <th width="7%" nowrap>优惠</th>
                                            <th width="7%" nowrap>折让</th>
                                            <th width="7%" nowrap>舍入少收</th>
                                            <th width="7%" nowrap>舍入多收</th>
                                            <th width="7%" nowrap>收银人</th>
                                        </tr>
                                        <% int i=1;
                                        	foreach(Workflow.Da.Domain.Order val in model.OrderList){ %>
                                        <tr align="center" class="detailRow">
											<td><%=i %></td>
											<td><%=val.No %></td>
											<td><%=val.CustomerName %></td>
											<td><%=val.SumAmount %></td>
											<td><%=val.PaidAmount %></td>
											<td><%=val.ZeroAmount %></td>
											<td><%=val.ConcessionAmount %></td>
											<td><%=val.RenderupAmount%></td>
											<td><%=val.NegtiveAmount%></td>
											<td><%=val.PositiveAmount%></td>
											<td><%=val.Name %></td>
										</tr>
                                        <% i++;} %>
                                        <%if(model.Order!=null){ %>
											<tr align="center" class="detailRow">
												<td>合计:</td>
												<td></td>
												<td></td>
												<td><%=model.Order.SumAmount %></td>
												<td><%=model.Order.PaidAmount %></td>
												<td><%=model.Order.ZeroAmount %></td>
												<td><%=model.Order.ConcessionAmount %></td>
												<td><%=model.Order.RenderupAmount%></td>
												<td><%=model.Order.NegtiveAmount%></td>
												<td><%=model.Order.PositiveAmount%></td>
												<td></td>
											</tr>
                                        <%} %>
                                        <tr class="detailRow">
                                         <td bgcolor="#eeeeee" align="right" colspan="12">
                                               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                                </webdiyer:AspNetPager>
                                         </td>
                                         </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                    &nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr height="5">
                                <td>
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                                <td bgcolor="#eeeeee">
                                    &nbsp;</td>
                                <td>
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="12">
                        <img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="21"/></td>
                    <td bgcolor="#FFFFFF">
                        <img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                    <td width="12">
                        <img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="21"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function checkData()
    {
        if($("#txtZero").val()!=""){
            if(!checkOnlyNum($("#txtZero"),true,14)){
                $("#txtZero").select();
                $("#txtZero").focus();
                return false;
            }
        }
        else{
			alert("您输入的金额有误!!!");
            $("#txtZero").val(0);
            return false;
        }
        if($("#txtConcession").val()!=""){
            if(!checkOnlyNum($("#txtConcession"),true,14)){
                $("#txtConcession").select();
                $("#txtConcession").focus();
                return false;
            }
        }else{
			alert("您输入的金额有误!!!");
            $("#txtConcession").val(0);
            return false;
        }
        if($("#txtGiveAway").val()!=""){
            if(!checkOnlyNum($("#txtGiveAway"),true,14)){
                $("#txtGiveAway").select();
                $("#txtGiveAway").focus();
                return false;
            }
        }
        else{
			alert("您输入的金额有误!!!");
            $("#txtGiveAway").val(0);
            return false;
        }
        return true;
    }
    function orderDetail(o)
    {
        var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
        showPage('../../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true);
    }
    
</script>
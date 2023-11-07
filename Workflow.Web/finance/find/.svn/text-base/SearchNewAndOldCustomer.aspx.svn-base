<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchNewAndOldCustomer.aspx.cs"
    Inherits="SearchNewAndOldCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>新老客户消费统计</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../../js/Calendar2.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <script type="text/javascript">
	function showOldCustomer(){
		showPage('OldCustomer.html',null,700,258,false,false);
	}
	function showNewCustomer(){
		showPage('NewCustomer.html',null,700,258,false,false);
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
	$(document).ready(function() {
		$("a[@title=老客户]").attr("href", "javascript:showOldCustomer();");
		$("a[@title=新客户]").attr("href", "javascript:showNewCustomer();");
	});	
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
                                    首页 -> 财务处理 -> 财务查询 -> 新老客户消费统计</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    新老客户消费统计</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="left">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap class="item_caption">
                                                消费金额:</td>
                                            <td class="item_content">
                                                <select id="sltSumAmount" name="sltSumAmount">
                                                    <option>小于</option>
													<option>小于等于</option>
													<option>等于</option>
													<option selected="selected">大于等于</option>
													<option>大于</option>
                                                </select>
                                                <%if(model.Operator1!=null){ %>
                                                <script type="text/javascript">
                                                 setOptionSelected('sltSumAmount','<%=model.Operator1 %>');
                                                </script>
                                                <%} %>
                                                <input name="SumAmount" id="txtSumAmount" class="num" type="text" size="10" value="<%=model.Amount1 %>" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                制作数量:</td>
                                            <td class="item_content">
                                                <select id="sltPaperCount" name="sltPaperCount">
                                                    <option>小于</option>
													<option>小于等于</option>
													<option>等于</option>
													<option selected="selected">大于等于</option>
													<option>大于</option>
                                                </select>
                                                <%if(model.Operator2!=null){ %>
                                                <script type="text/javascript">
                                                 setOptionSelected('sltPaperCount','<%=model.Operator2 %>');
                                                </script>
                                                <%} %>
                                                <input type="text" name="PaperCount" id="txtPaperCount" class="num" size="10" value="<%=model.Amount2%>" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                时间段:</td>
                                            <td class="item_content">
                                                <div>
                                                    <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts" value="<%=model.BalanceDateTimeString%>" onfocus="setday(this);" readonly="readonly"/>&nbsp;至&nbsp;
                                                    <input id="txtTo" type="text" name="EndDateTime" class="datetexts" value="<%=model.InsertDateTimeString%>" onfocus="setday(this);" readonly="readonly"/>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right" style="padding-right: 10px">
                                                <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="return checkData();" Text="查询" />
                                                <asp:Button ID="btnDispatchPrint" CssClass="buttons" runat="server" Text="打印" OnClick="btnDispatchPrint_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="1%" nowrap>NO</th>
                                            <th width="10%" nowrap>属性</th>
                                            <th width="10%" nowrap>订单数</th>
                                            <th width="10%" nowrap>打印量</th>
                                            <th width="10%" nowrap>金额</th>
                                            <th nowrap>备注</th>
                                        </tr>
                                        <% int i = 1; foreach (Workflow.Da.Domain.Order val in model.OrderList)
										   { %>
											<tr class="detailRow">
											<td><%=i %></td>
											<td><%=val.Status==1?"新客户":"老客户" %></td>
											<td><%=val.OrderCount %></td>
											<td><%=val.PaperCount %></td>
											<td><%=val.SumAmount%></td>
											<td></td>
											</tr>
                                        <% i++;
									   } %>
                                    </table>
                                </td>
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
                        <img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="11"/></td>
                    <td bgcolor="#FFFFFF">
                        <img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                    <td width="12">
                        <img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="11"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<script type="text/javascript">
    function checkData()
    {
        if($("#txtSumAmount").val()!=""){
            if(!checkOnlyNum($("#txtSumAmount"),true,14)){
                alert("您输入的金额有误!!!");
                $("#txtSumAmount").select();
                $("#txtSumAmount").focus();
                return false;
            }
        }
        else{
			alert("您输入的金额有误!!!");
            $("#txtSumAmount").val(0);
            $("#txtSumAmount").select();
            $("#txtSumAmount").focus();
            return false;
        }
        
        if($("#txtPaperCount").val()!="")
        {
            if(!checkOnlyNum($("#txtPaperCount"),true,14)){
                alert("您输入的数量有误!!!");
                $("#txtPaperCount").select();
                $("#txtPaperCount").focus();
                return false;
            }
        }else{
			alert("您输入的数量有误!!!");
			$("#txtPaperCount").val(0);
			$("#txtPaperCount").select();
            $("#txtPaperCount").focus();
            return false;
        }
        
        if($("#txtBeginDateTime").val()==""){
			alert("必须输入时间范围!!!");
			$("#txtBeginDateTime").focus();
			return false;
        }
        
        if($("#txtTo").val()==""){
			alert("必须输入时间范围!!!");
			$("#txtTo").focus();
			return false;
        }
        return true;
    }
</script>


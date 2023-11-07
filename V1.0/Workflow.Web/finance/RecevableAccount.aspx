<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecevableAccount.aspx.cs" Inherits="RecevableAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>应收款处理</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/math.js"></script>
<script type="text/javascript" src="../js/dispatch.js"></script>
<script type="text/javascript" src="../js/arrearage.js"></script>

<script language="javascript">
var renderUpMin=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.RenderUpMin %>;
var renderUpMax=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.RenderUpMax %>;
var position=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.PositionId %>;
var master=<%=Workflow.Support.Constants.POSITION_SHOP_MASTER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
var manager=<%=Workflow.Support.Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;

function showSelectCustomer(){
	//showPage('../customer/SelectCustomer.aspx',null,890,566,false,false);
	showPage('../customer/SelectCustomer.aspx',null,900,600,false,false);

}
</script>
</head>
<body  style="text-align:center">
<form id="form1" action="" method="post" runat="server">
<div align="center" style="width:99%" bgcolor="#ffffff" id="container">
 <table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
		<td width="99%"  bgcolor="#ffffff"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
	</tr>
    <tr>
     <td colspan="3" bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td></td>
            <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 应收款处理</td>
            <td></td>
          </tr>
          <tr>
            <td></td>
            <td align="right" bgcolor="#eeeeee"></td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">应收款处理</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">	
                <table width="100%" border="1" cellpadding="2" cellspacing="1">
                   <tr>
                    <td nowrap class="item_caption">会员卡号:</td>
                    <td class="item_content"><input name="memberCardNo" id="txtMemberCardNo" type="text" class="texts" value="" onblur="return getCustomerInfo(event,this);" /></td>
                   </tr>
                  <tr>
                    <td nowrap class="item_caption">名称:</td>
                    <td class="item_content"><input name="textfield" id="txtCustomerName" type="text" class="texts" value="" />
                    <input type="button" class="buttons selectButtons" onclick="showSelectCustomer();" value="选择客户" />
                    <input type="hidden" id="txtCustomerId" name="CustomerId" />
    <%--                <asp:Button ID="sltCustomer" CssClass="buttons selectButtons" runat="server" OnClick="SelectCustomer" OnClientClick="showSelectCustomer();" Text="选择客户" />--%></td>
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
                    <td colspan="2">该客户共有 <span id="arrearageNum" style="color:Red"></span> 笔欠款，总计: <span id="sumMoney" style="color:Red"></span> 元 </td>
                  </tr>
                  <tr>
                    <td  nowrap class="item_caption">应付:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="item_content"> <input id="txtShowPayMoney" readonly="readonly" style="color:Red" name="showPayMoney" type="text" value="0" class="num"  /><input id="txtSumMoney" name="sumMoney" type="hidden" value="0" /></td>
                  </tr>
                  <tr>
                    <td  nowrap class="item_caption">本次折让:&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="item_content"><input id="txtConcession" name="Concession" type="text" maxlength="14" onblur="onCurrentPayMoney();" value="0" readonly="true" class="num" />&nbsp;<a href="#" onclick="preferentialMoney(4);">折让</a></td>
                  </tr>
                  <tr>
                        <td  nowrap class="item_caption">已预存:</td>
                        <td class="item_content"><input id="txtPreDeposits" name="preDeposits" type="text" value="0" readonly="readonly" class="num"/><input id="cbUsePreDeposits" name="usePreDeposits" type="checkbox" onclick="onCurrentPayMoney();"/><input id="realUsePreDepositsAmount" name="realUsePreDepositsAmount" type="hidden" value="0"/><label for="cbUsePreDeposits">使用预存款</label></td>
                  </tr>
                  <tr>
                    <td  nowrap class="item_caption">本次支付:&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="item_content"> 
                        <input id="txtPayMoney" name="PayMoney" maxlength="14"  onchange ="onCurrentPayMoney();"  type="text" value="0" class="num"/>
                    </td>
                  </tr>
                  <tr>
                    <td  nowrap class="item_caption">找零</td>
                    <td class="item_content">
                        <span id="spPreDeposits" style="display:none">
                            <input type="text" id="txtSavePreDepositsAmount" name="savePreDepositsAmount" value="0" size="9"/>
                            <input  type="checkbox" id="cbSavePreDeposits" name="savePreDeposits" onclick="usePreDepositsClick();"/>
                            <label for="cbSavePreDeposits" style="color:Red">预存</label>
                      </span>
                    </td>
                  </tr>
                  <tr>
                    <td  nowrap class="item_caption">还欠:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="item_content"><input id="txtArrearage" name="Arrearage" type="text" readonly="readonly" value="0" class="num" /></td>
                  </tr>
                </table>			
             </td>
            <td width="3%">&nbsp;</td>
		</tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="left"><div style="float:left">以下是 <span style="color:Red" id="sCustomerName"></span>&nbsp;&nbsp;未支付完毕的工单，请分配本次交款</div>
            <div class="strikeTheEyeNormalChar" style="text-align:right;float:right">本次支付分配余额:<span style="color:Red" id="restMoney"></span></div></td>
            <td width="3%">&nbsp;</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">	
              <table id="tbList" width="100%" border="1" cellpadding="2" cellspacing="1">
                  <tr>
                    <th width="1%" nowrap></th>
                    <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;工单号&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开单时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;结算时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;总额&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;优惠金额&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;抹零金额&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;折让金额&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;已付款额&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;应收款额&nbsp;&nbsp;</th>
                    <th  align="center" nowrap>本次结欠</th>
                  </tr>
            </table>
          </td>
            <td width="3%">&nbsp;</td>
		</tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">
                <asp:Button ID="btnOK" runat="server" CssClass="buttons" OnClick="Save" OnClientClick="return dataCheck();" Text="确定" />
                <input type="hidden" id="txtOrdersId" name="OrdersId" />
                <input type="hidden" id="txtMoney" name="Money" />
            </td>
            <td width="3%">&nbsp;</td>
		</tr>		
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
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
		<td width="11"><img alt="" src="../images/white_main_bottom_left.gif"/></td>
		<td width="99%" bgcolor="#ffffff"><img alt="" src="../images/spacer_10_x_10.gif"/></td>
		<td width="10"><img alt="" src="../images/white_main_bottom_right.gif"/></td>
	</tr>
  </table>
  </div>
</form>  
</body>
</html>

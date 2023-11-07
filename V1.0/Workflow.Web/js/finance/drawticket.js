// JScript 文件
/*
/// 
/// 版权：北京兰德肯网络信息有限公司 
/// 文 件 名：drawticket.js
/// 所属模块:财务处理--领取发票
/// 功能描述 orderDetail(o):根据工单号查询工单详情
/// 创建时间：2009-01-17
/// 创 建 人:张晓林
/// 修改时间：
/// 修改描述：
*/

//领取发票 
function ChoiceDrawTicketOrderNo(orderId)
{
//    var res=confirm("确认领取?");
//    if(!res)
//    {
//        return false;
//    }
//    else
//    {
//        $("#hiddOrderId").val(orderId);
//        var strTicketAmount="#drawTicketAmount"+i;
//        $("#hiddTicketAmount").val($(strTicketAmount).val());//领取发票金额
//        var strNotAmountSum="#NotPayTicketAmount"+i;
//        $("#hiddNotAmountSum").val($(strNotAmountSum).val());//发票的总金额
//        $("#checkTag").val("T");//Html控件传值用name的名字，服务器控件用id的名字
//        if(parseFloat($("#hiddTicketAmount").val())>parseFloat($("#hiddNotAmountSum").val()))
//        {
//           alert("领取金额不能大于发票总金额 ！");
//           $(strTicketAmount).val($(strNotAmountSum).val());
//           return false;
//        }
//        $("#form1").submit();
//    }
    showPage('DrawTicketConfirm.aspx?OrderId='+orderId,  null, 800, 700, false, false,true);
}

/*发票领取数据验证*/
function dataCheck()
{
    if(""==$("#txtDrawTicketAmount").val())
    {
        alert("领取金额不能为空!");
        return false;
    }
    else
    {
        if(!checkOnlyNum($("#txtDrawTicketAmount"),true,10))
        {
           $("#txtDrawTicketAmount").attr("value","");
           $("#txtDrawTicketAmount").focus();
           return false;
        }
        if(parseFloat($("#txtDrawTicketAmount").val())<=0)
        {
           alert("领取金额不能小于等于0!");
           $("#txtDrawTicketAmount").attr("value",$("#hiddDrawTicketAmountTotal").val());
           $("#txtDrawTicketAmount").focus();
           return false;
        }
        if(parseFloat($("#txtDrawTicketAmount").val())>parseFloat($("#hiddDrawTicketAmountTotal").val()))
        {
           alert("领取金额不能大于发票总金额!");
           $("#txtDrawTicketAmount").attr("value",$("#hiddDrawTicketAmountTotal").val());
           $("#txtDrawTicketAmount").focus();
           return false;
        }
         var yes=confirm("确认领取?");
         if(!yes)
         {
            return false;
         }
    }
    return true;
}
//工单详情 
function orderDetail(o)
{
    showPage('../order/OrderDetail.aspx?OrderNo='+o, null, 1000, 700, false, true,'status:no;');
}

//回车提交 
function document.onkeydown()
{
    var evt=window.event || arguments[0];
    if(evt.keyCode==13)
    {
        $("#Search").click();
        return false;
    }
    
    //按Esc键退出		
	if (evt.keyCode==27)	
	{
		window.close();
	}
}

///
///名称:cancelNotPaidTicket
///功能概要:取消欠发票功能
///作者:张晓林
///创建时间:2009年10月24日14:55:57
///修正履历:
///修正时间:
function cancelNotPaidTicket(orderId)
{
    var res=confirm("确认取消?");
    if(res)
    {
        var url='../../ajax/AjaxEngine.aspx?OrderId='+orderId; 
        $.getJSON(url,{a:'32'},processJson1);       
        window.navigate('DrawTicket.aspx');
    }
}
function processJson1(json){}
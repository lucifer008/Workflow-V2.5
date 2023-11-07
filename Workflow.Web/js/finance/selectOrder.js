// JScript 文件

function refresh(){    
   window.location.reload();
   rValue=false; 
}
//功能: 定时刷新页面
//作者: bxy
//时间: 2010年06月23日
function SetTimeRefresh(){
    window.location.href="selectOrder.aspx";
}

//页面加载
$().ready(function(){
   	    setInterval("SetTimeRefresh()",40000);
});

//功能: 订单结算
//作者: 张晓林
//时间: 2009年9月2日9:57:43
function payForOrder(o)
{
    var orderNo=escape($($("td",$(o).parent().parent())[1]).text());
    var strCustomerName=escape($($("td",$(o).parent().parent())[2]).text());
    var customerId=$("input[@name='customerId']",$(o).parent()).val();
    var memberCardId=$("input[@name='memberCardId']",$(o).parent()).val();//会员Id
    var url='PayForOrder.aspx?strNo='+orderNo +'&strName='+strCustomerName+'&customerId='+customerId+"&memberCardId="+memberCardId
	//return url;
	showPage(url, null, 850, 700, false, false);
}

//功能: 返回订单
//作者: 张晓林
//时间: 2009年9月2日9:57:43
var orderId;
function ReturnClew(id){
    orderId=id;
    var url = "../ajax/AjaxEngine.aspx" + "?OrderId=" + id;
    $.getJSON(url, {a : '38'},getOrderStatus);
}
function getOrderStatus(json){
    var status=json;
    if(5!=status){
        var res= confirm("确定返回?");
        if(res){
            $("#checkTag").val("T");        
            $("#searchTag").val(orderId);        
            document.form1.submit();
        }
    }
    else{
        alert("该工单已经结算完成!");
        window.location.reload();
    }
}

//功能: 显示订单详情
//作者: 张晓林
//时间: 2009年9月2日9:57:43
function orderDetail(o)
{
    var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
    showPage('../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true,'status:no;');
}

//功能: 控制回车提交
//作者: 张晓林
//时间: 2009年9月2日9:57:43
document.onkeydown=function(event_e)
{
    var evt=window.event||arguments[0];
    var element=evt.srcElement||evt.target;
    if(13==evt.keyCode)
    {
        if("txtOrderNo"==element.id || "txtMemberCardNo"==element.id || "txtCodeNo"==element.id)
        {
            $("#search").click();
            return false;
        }
    }
}
//功能概要: 修正待结算工单
//作    者: Lucifer
//日    期: 张晓林
function admentBalaOrder(o){
    var strOrderNo=o;
    var url='AmendmentBalanceOrder.aspx?strNo='+strOrderNo;
    showPage(url, null, 850, 700, false, false);
}
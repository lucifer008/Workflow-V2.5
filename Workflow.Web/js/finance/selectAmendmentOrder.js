// JScript 文件
//功能概要: 获取订单修正Js
//作    者: 张晓林
//创建时间: 2009年11月19日13:15:12
//修正履历:
//修正时间:

//功能: 查询数据验证
//作者: 张晓林
//时间: 2009年11月3日13:16:06
function dataCheck()
{
    if(""==$("#txtOrderNo").val())
    {
        alert("订单号不能为空!");
        $("#txtOrderNo").focus();
        return false;
    }
}

//功能: 控制回车提交
//作者: 张晓林
//时间: 2009年11月3日13:16:06
document.onkeydown=function()
{
    //Esc建退出
	var evt=window.event || arguments[0];
    var element=evt.srcElement || evt.target;
	//回车提交
    if(13==evt.keyCode)
    {
        if("txtOrderNo"==element.id)
        {
            $("#search").click();
            return false;
        }
    }
}

//功能: 修正订单
//作者: 张晓林
//时间: 2009年11月3日13:16:06
function amendmentOrder(o)
{
    var returnVal=false;
    switch(position)
    {
        case master:
            returnVal=true;
             break;
        case manager:
             returnVal=true;
             break;
        default:
            returnVal=accredit();
            break;
        
    } 
    if(returnVal)
    {
        var orderNo=escape($($("td",$(o).parent().parent())[1]).text());
        var strCustomerName=escape($($("td",$(o).parent().parent())[2]).text());
        var customerId=$("input[@name='customerId']",$(o).parent()).val();
        var memberCardId=$("input[@name='memberCardId']",$(o).parent()).val();//会员Id
        var url='AmendmentOrder.aspx?strNo='+orderNo +'&strName='+strCustomerName+'&customerId='+customerId+"&memberCardId="+memberCardId
	    showPage(url, null, 850, 900, false, false);
	}
}
function accredit()
{
     var url="Accredit.aspx?AccreditTypeKey="+escape(accreditTypeKey)+"&AccreditTypeText="+escape(accreditTypeText)+"&AccreditTypeLabel="+escape("订单修正授权");
     return showPage(url,null,280,500,false,true,false,false);
}

//功能: 订单详情链接实现
//作者: 张晓林
//时间: 2009年11月3日13:16:06
function orderDetail(o)
{
    var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
    showPage('../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true,'status:no;');
}
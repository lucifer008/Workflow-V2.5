// JScript 文件


var rValue=null;
$().ready(function()
{
    setInterval("refresh()",100);
});
function refresh()
{
    if(rValue)
    {
        window.location.reload();
        rValue=false;
    }
}

/*结算页面链接实现*/
function payForOrder(o)
{
    var orderNo=escape($($("td",$(o).parent().parent())[1]).text());
    var strCustomerName=escape($($("td",$(o).parent().parent())[2]).text());
    var customerId=$("input[@name='customerId']",$(o).parent()).val();
    var memberCardId=$("input[@name='memberCardId']",$(o).parent()).val();//会员Id
    var url='PayForOrder.aspx?strNo='+orderNo +'&strName='+strCustomerName+'&customerId='+customerId+"&memberCardId="+memberCardId
	//return url;
	showPage(url, null, 850, 900, false, false);
}

/* 返回工单实现*/
function ReturnClew(id)
{
     var res= confirm("确定返回?");
    if(res)
    {
        $("#checkTag").val("T");        
        $("#searchTag").val(id);        
        document.form1.submit();
    }
}



/*工单详情链接实现*/
function orderDetail(o)
{
    var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
    showPage('../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true,'status:no;');
}

/// 名    称: onkeydown
/// 功能概要: 控制回车提交
/// 创建时间：2009年9月2日9:57:43
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：

document.onkeydown=function(event_e)
{
    var evt=window.event||arguments[0];
    var element=evt.srcElement||evt.target;
    if(13==evt.keyCode)
    {
        if("txtOrderNo"==element.id)
        {
            $("#search").click();
            return false;
        }
    }
}

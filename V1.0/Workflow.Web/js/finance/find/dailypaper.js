/*
///名    称: dailyPaper
///功能概要: 日报操作JS
///作    者：张晓林
///创建时间: 2008-11-28
///修正履历:
///修正时间:
*/

function DataCheck()
{
    if(""!=$("#txtBeginDateTime").val() && ""!=$("#txtEndDateTime").val())
    {
        if($("#txtBeginDateTime").val()==$("#txtEndDateTime").val())
        {
            alert("开始日期和结束日期不能相同!");
            return false;
        }
        else if($("#txtBeginDateTime").val()>$("#txtEndDateTime").val())
        {
           alert("开始日期不能大于结束日期!");
           return false;
        }
                
    }
    if(""==$("#txtBeginDateTime").val() && ""==$("#txtEndDateTime").val())
    {
        alert("查询条件不能为空!");
        return false;
    }
}
function orderDetail(o)
{
    showPage('../../order/OrderDetail.aspx?OrderNo='+o, null, 1000, 700, false, true,'status:no;');
}

///名    称: returnOrder
///功能概要: 将已经完成的工单返回到已登记的工单
///创建时间: 2009年10月12日9:18:57
///作    者: lucifer
///修正时间:
///修正履历:
function returnOrder(orderId)
{
    var yes=confirm("确认返回吗?");
    if(yes)
    {
         var url="../../../ajax/AjaxEngine.aspx?orderId="+orderId;
        $.getJSON(url,{a:'31'},callBackReturn);     
    }
}
function callBackReturn(json)
{
    if (json == null || json) 
    {
        data=json;
    }
    else 
    {
        return;
    }
    if("1"==json)
    {
        window.navigate('DailyPaper.aspx');
    }
}
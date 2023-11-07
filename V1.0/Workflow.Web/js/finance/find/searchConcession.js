// JScript 文件
/*
///名    称：searchConcession
///功能概要: 优惠查询JS
///作    者: 张晓林
///创建时间: 2009年5月20日13:48:03
///修正履历:
///修正时间:
*/

function queryDataCheck()
{
    if(""==$("#txtOrderNo").val() && ""==$("#txtBeginDateTime").val() && ""==$("#txtEndDateTime").val())
    {
        alert("查询条件不能为空!");
        $("#txtOrderNo").focus();
        return false;
    }
    if(""!=$("#txtBeginDateTime").val() && ""!=$("#txtEndDateTime").val())
    {
        if($("#txtBeginDateTime").val()>=$("#txtEndDateTime").val())
        {
           alert("开始日期不能大于等于结束日期!");
           $("#txtBeginDateTime").focus();
           return false;
        }
    }
}

function orderDetail(o)
{
    showPage('../../order/OrderDetail.aspx?OrderNo='+$(o).html(), null, 1000, 700, false, true,'status:no;');
}
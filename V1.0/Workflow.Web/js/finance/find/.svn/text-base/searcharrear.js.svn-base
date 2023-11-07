
// JScript 文件
/*
///名    称：searcharrear
///功能概要: 应收款查询JS
///作    者: 张晓林
///创建时间: 2009-01-17
///修正履历:
///修正时间:
*/

$(document).ready(
    function()
    {
        $("#btnSearch").click(dataValidata);
    }
);

function dataValidata()
{
    if(""!=$("#BeginDateTime").val() && ""!=$("#EndDateTime").val())
    {
        if($("#BeginDateTime").val()==$("#EndDateTime").val())
        {
           alert("开始时间不能和结束时间相同！");
           return false;
        }
        else if($("#BeginDateTime").val()>$("#EndDateTime").val())
        {
           alert("开始时间不能大于结束时间！");
           return false
        }
    }
}

///名    称: showOweMoneyDetail
///功能概要: 显示客户欠款明细
///作    者: 张晓林
///创建时间: 2009年10月22日14:31:04
///修正履历:
///修正时间:
function showOweMoneyDetail(customerId,customerName)
{
    showPage('CustomerOweMoneyDetail.aspx?CustomerId='+customerId+"&CustomerName="+escape(customerName), null, 1000, 700, false, false);
}

//功能: 应收款查询JS
//作者: 张晓林
//日期: 2009-01-17

$(document).ready(
    function()
    {
        $("#btnSearch").click(dataValidata);
    }
);

//功能: 查询数据验证
//作者: 张晓林
//日期: 2009-01-17
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

//功能: 客户欠款明细页面链接
//作者: 张晓林
//日期: 2009年10月22日14:31:04
function showOweMoneyDetail(customerId,customerName)
{
    var beginDateTime="";
    var endDateTime="";
    if(""!=$("#BeginDateTime").val())
    {
        beginDateTime=$("#BeginDateTime").val();
    }
    if(""!=$("#EndDateTime").val())
    {
        endDateTime=$("#EndDateTime").val();   
    }
    var url='CustomerOweMoneyDetail.aspx?CustomerId='+customerId+"&CustomerName="+escape(customerName)+"&BeginDateTime="+escape(beginDateTime)+"&EndDateTime="+escape(endDateTime);
    showPage(url, null, 1000, 700, false, false);
}

//功能: 显示客户付款款明细
//作者: 张晓林
//日期: 2009年12月1日16:10:54
//function showPaidMoneyDetail(customerId,customerName)
//{
//    showPage('CustomerPaidMoneyDetail.aspx?CustomerId='+customerId+"&CustomerName="+escape(customerName), null, 1000, 700, false, false);
//}
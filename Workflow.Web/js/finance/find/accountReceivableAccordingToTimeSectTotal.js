
//功能: 应收款按照时间段合计JS
//作者: 张晓林
//日期: 2008-11-26


//功能: 页面属性加载
//作者: 张晓林
//日期: 2008-11-26
$(document).ready(
    function()
    {
        $("#btnSearch").click(dataValidata);
        $("input:button[@value=选择客户]").click(OpenCustomer);
    }
);

//功能: 查询数据验证
//作者: 张晓林
//日期: 2008-11-26
function dataValidata()
{
    if(""!=$("#txtBeginDateTime").val() && ""!=$("#txtTo").val())
    {
        if($("#txtBeginDateTime").val()==$("#txtTo").val())
        {
           alert("开始时间不能和结束时间相同！");
           return false;
        }
        else if($("#txtBeginDateTime").val()>$("#txtTo").val())
        {
           alert("开始时间不能大于结束时间！");
           return false
        }
    }
}

//功能: 打开选择客户对话框
//作者: 张晓林
//日期: 2008-11-26
function OpenCustomer()
{		
	showPage("../../customer/SelectCustomer.aspx?customerName="+$("#customerName").val(), null, 900,600, false, false);
}
//选择客户后加载客户信息
function selectCustomer(objCustomer)
{
	if(objCustomer==null) return;
	$("#hiddCustomerId").attr("value",objCustomer.Id);
	$("#CustomerName").attr("value",objCustomer.Name);
}

//功能: 客户欠款明细页面链接
//作者: 张晓林
//日期: 2009年10月22日14:31:04
function showOweMoneyDetail(customerId,customerName)
{
    var beginDateTime="";
    var endDateTime="";
    if(""!=$("#txtBeginDateTime").val())
    {
        beginDateTime=$("#txtBeginDateTime").val();
    }
    if(""!=$("#txtTo").val())
    {
        endDateTime=$("#txtTo").val();   
    }
    var url='CustomerOweMoneyDetail.aspx?CustomerId='+customerId+"&CustomerName="+escape(customerName)+"&BeginDateTime="+escape(beginDateTime)+"&EndDateTime="+escape(endDateTime);
    showPage(url, null, 1000, 700, false, false);
}

///名    称: showOweMoneyDetail
///功能概要: 显示客户付款款明细
///作    者: 张晓林
///创建时间: 2009年12月1日16:10:54
///修正履历:
///修正时间:
function showPaidMoneyDetail(customerId,customerName)
{
    var url='CustomerPaidMoneyDetail.aspx?CustomerId='+customerId+"&CustomerName="+escape(customerName);
    showPage(url, null, 1000, 700, false, false);
}	
	
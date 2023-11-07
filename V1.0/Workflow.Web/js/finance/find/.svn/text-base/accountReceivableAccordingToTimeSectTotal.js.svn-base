
/*
///名    称: AccountRecevableAccordingToTimeSectTotal
///功能概要: 应收款按照时间段合计JS
///作    者：张晓林
///创建时间: 2008-11-26
///修正履历:
///修正时间:
*/

$(document).ready(
    function()
    {
        $("#btnSearch").click(dataValidata);
        $("input:button[@value=选择客户]").click(OpenCustomer);
    }
);

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
function OpenCustomer()
{		
	showPage("../../customer/SelectCustomer.aspx?customerName="+$("#customerName").val(), null, 900,600, false, false);
}

function selectCustomer(objCustomer)
{
	if(objCustomer==null) return;
	$("#hiddCustomerId").attr("value",objCustomer.Id);
	$("#CustomerName").attr("value",objCustomer.Name);
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
	
	
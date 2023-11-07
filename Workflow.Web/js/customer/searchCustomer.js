// 名    称: searchCustomer.js
// 功能概要: 客户查询 Js
// 作    者: 
// 创建时间: 
// 修正履历: 
// 修正时间:


$(document).ready(function() {
	disabledSelectOption("Trade");
});
        
function checkInput() {
	var beginDateValue = $("input:text[@id$=BeginDate]").attr("value");
	var endDateValue = $("input:text[@id$=EndDate]").attr("value");
	if (beginDateValue != "" && endDateValue != "" && beginDateValue > endDateValue) {
		alert("注册日期 : 开始日期不能大于结束日期。");
		$("input:text[@id$=BeginDate]").focus();
		return false;
	}
	$("#hidDate").val("999");
	$("#dNavigate_hidDateType").val("999");
	//return true;
}

function tradeAttribute()
{
    var tradeSelect = $("#Trade");
    for(var i=0;i<tradeSelect[0].options.length;i++)
    {
        if (tradeSelect[0].options[i].value == "0")
        {
             $(tradeSelect[0].options[i]).attr("disabled","disabled");
        }
    }
 }

//客户详情
function customerDetail(o)
{
    var customerId=$("input[@name=customerId]",$(o).parent().parent()).val();
    showPage('CustomerDetail.aspx?Id='+customerId, null, 800, 550, false, true);
}

//客户消费历史
function CustomerConsumeHistory(o)
{
    var customerId=$("input[@name=customerId]",$(o).parent().parent()).val();
    var tds=$("td",$(o).parent().parent());
    var customerName=$("a",tds.get(1))[0].innerHTML;
    showPage("CustomerConsumeHistory.aspx?Id="+customerId+"&CustomerName="+escape(customerName), null, 1000, 800, false, false)
}
//通过时间获取数据
function getOrderByDate(date){
    $("#Name").val();
    $("#MemberCardNo").val("")
    $("#EndDate").val("");
    $("#BeginDate").val("");
    document.getElementById('actionTag').value="F";
	document.getElementById('hidDate').value=date;
	document.getElementById("dNavigate_hidDateType").value=date;//给用户控件上的控件赋值
	document.getElementById('form1').submit();
}

function getByDate(date){
    $("#Name").val();
    $("#MemberCardNo").val("")
    $("#EndDate").val("");
    $("#BeginDate").val("");
    $("#action").val("T");
    document.getElementById('actionTag').value="T";
	document.getElementById('hidDate').value=date;
	document.getElementById("dNavigate_hidDateType").value=date;//给用户控件上的控件赋值
	document.getElementById('form1').submit();
}
function pagerCheck(){
    $("#hidDate").val(999);
}
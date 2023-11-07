// 名    称: selectCustomer.js
// 功能概要: 选择客户 Js
// 作    者: 
// 创建时间: 
// 修正履历: 
// 修正时间:


$(document).ready(function() {
	disabledSelectOption("Trade");
});

/*客户查询条件数据验证*/
function checkInput() {
	var beginDateValue = $("input:text[@id$=BeginDate]").attr("value");
	var endDateValue = $("input:text[@id$=EndDate]").attr("value");
	if (beginDateValue != "" && endDateValue != "" && beginDateValue > endDateValue) {
		alert("注册日期 : 开始日期不能大于结束日期。");
		$("input:text[@id$=BeginDate]").focus();
		return false;
	}
	return true;
}

/*绑定选择的客户信息*/
function choiceCustomer(rowNum)
{
    var tds = $("td", $("tr[title=row"+ rowNum +"]"));
	var objCustomer = new Object();
	objCustomer.Id = tds.get(0).innerHTML;
	objCustomer.Name =$("a",tds.get(1))[0].innerHTML;
	objCustomer.Trade = tds.get(2).innerHTML;
	objCustomer.CustomerLevel = tds.get(3).innerHTML;
	objCustomer.SimpleName = $("input:hidden[@id$=simplename"+rowNum+"]").attr("value");
	objCustomer.TradeId = $("input:hidden[@id$=TradeId"+rowNum+"]").attr("value");
	objCustomer.CustomerLevelId = $("input:hidden[@id$=CustomerLevelId"+rowNum+"]").attr("value");
	objCustomer.CustomerType = tds.get(4).innerHTML;
	objCustomer.PaymentType=trimStr(tds.get(5).innerHTML);
	objCustomer.LinkMan = tds.get(7).innerHTML;//联系人
	objCustomer.TelNo = tds.get(8).innerHTML;//联系电话
	objCustomer.Address = tds.get(9).innerHTML;//联系地址
	objCustomer.NeedTicket = tds.get(10).innerHTML;//是否要发票
	objCustomer.ValidateStatus = tds.get(11).innerHTML;//客户确认状态
	objCustomer.Memo = tds.get(12).innerHTML;//备注
	callBackMethod(objCustomer);
}
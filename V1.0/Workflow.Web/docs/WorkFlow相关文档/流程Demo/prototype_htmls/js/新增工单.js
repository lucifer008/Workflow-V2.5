// JavaScript Document
//新增/编辑加工业务明细
function addOrderFormList()
{
	window.open('新增加工业务明细.html');
}
//印制要求
function printRequest()
{
	window.open('PrintRequest.html');
}
//新增客户
function newCustomer()
{
	window.open('../customer/NewCustomer.html');
}
//选择客户
function selectCustomer()
{
	window.open('../customer/SelectCustomer.html');
}
//打印工单
function printOrderForm()
{


window.open('OrderDetail.html',null,"height=1000,width=1000,status=no,toolbar=no,menubar=no,titlebar=no,location=no,fullscreen=ture,top=10,left=100");

}
//调配
function prepareOrderForm()
{
//	window.showModalDialog('DispatchOrder.html');
		showPage('DispatchOrder.html', null, 410, 465, false, true);
} 
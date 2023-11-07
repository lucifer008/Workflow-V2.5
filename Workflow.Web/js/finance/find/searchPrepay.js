// JScript 文件
// 名    称: searchPrepay.js
// 功能概要: 预付款查询 Js
// 作    者: 张晓林
// 创建时间: 2009-2-02
// 修正履历: 
// 修正时间: 

$(document).ready(function(){
    $("#btnSearch").click(dataValidate);
});

//功能: 查询数据验证  
//作者: 张晓林
//日期: 2009-2-02  
function dataValidate(){
    if(""!=$("#txtBeginDateTime").val() && ""!=$("#txtTo").val()){
        if($("#txtBeginDateTime").val()==$("#txtTo").val()){
           alert("开始时间不能和结束时间相同！");
           return false;
        }
        if($("#txtBeginDateTime").val()>$("#txtTo").val()){
           alert("开始时间不能大于结束时间！");
           return false;
        }
    }
}

//功能: 打开选择客户对话框  
//作者: 张晓林
//日期: 2009-2-02
function OpenCustomer(){		
	showPage("../../customer/SelectCustomer.aspx?customerName="+$("#CustomerName").val(), null, 900,600, false, false);
}

function selectCustomer(objCustomer){
	if(objCustomer==null) return;
	//$("#hiddCustomerId").attr("value",objCustomer.Id);
	$("#CustomerName").attr("value",objCustomer.Name);
}

//功能: 显示订单详情  
//作者: 张晓林
//日期: 2009-2-02
function orderDetail(o){
    showPage('../../order/OrderDetail.aspx?OrderNo='+o, null, 1000, 700, false, true,'status:no;');
}

//功能: 控制页面回车提交
//作者: 张晓林
//日期: 2009-2-02
document.onkeydown=inputKeyCheck;
function inputKeyCheck(e){
var e=e|| event;
if(e.keyCode==27)
    window.close();
}

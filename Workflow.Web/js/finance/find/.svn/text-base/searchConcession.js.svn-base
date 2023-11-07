// JScript 文件
/*
///名    称：searchConcession
///功能概要: 优惠查询JS
///作    者: 张晓林
///创建时间: 2009年5月20日13:48:03
///修正履历:
///修正时间:
*/


//功能: 优惠查询验证  
//作者: 张晓林
//日期: 2009年5月20日
function queryDataCheck(){
    if(""==$("#txtOrderNo").val() && ""==$("#txtBeginDateTime").val() && ""==$("#txtEndDateTime").val()){
        alert("查询条件不能为空!");
        $("#txtOrderNo").focus();
        return false;
    }
    if(""!=$("#txtBeginDateTime").val() && ""!=$("#txtEndDateTime").val()){
        if($("#txtBeginDateTime").val()>=$("#txtEndDateTime").val()){
           alert("开始日期不能大于等于结束日期!");
           $("#txtBeginDateTime").focus();
           return false;
        }
    }
}

//功能: 显示订单详情  
//作者: 张晓林
//日期: 2009年5月20日
function orderDetail(o)
{
    showPage('../../order/OrderDetail.aspx?OrderNo='+$(o).html(), null, 1000, 700, false, true,'status:no;');
}

//通过时间获取数据
function getOrderByDate(date){
    $("#txtTo").val("");
    $("#txtBeginDateTime").val("");
	document.getElementById('hidDate').value=date;
	document.getElementById('actionTag').value="F";
	document.getElementById("dateNavigate_hidDateType").value=date;//给用户控件上的控件赋值
	document.getElementById('form1').submit();
}
function getByDate(date){
    $("#txtTo").val("");
    $("#txtBeginDateTime").val("");
    $("#action").val("T");
    document.getElementById('actionTag').value="T";
	document.getElementById('hidDate').value=date;
	document.getElementById("dateNavigate_hidDateType").value=date;//给用户控件上的控件赋值
	document.getElementById('form1').submit();
}
function pagerCheck(){
    $("#hidDate").val(999);
}

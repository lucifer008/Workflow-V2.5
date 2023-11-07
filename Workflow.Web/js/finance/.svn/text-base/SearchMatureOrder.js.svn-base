// JScript 文件
// 功能概要: 获取到期订单Js
// 作    者：张晓林
// 创建时间：2009年12月5日9:50:39
// 修正履历:
// 修正时间：

//功能: 查询数据验证
//作者: 张晓林
//时间: 2009年11月3日13:16:06
function dataCheck(){
    var action=false;
    if(""!=$("#txtOrderNo").val()) action=true;
    if(""!=$("#txtInBeginDateTime").val()) action=true;
    if(""!=$("#txtInEndDateTime").val()) action=true;
    if(""!=$("#txtBaBeginDateTime").val()) action=true;
    if(""!=$("#txtBaEndDateTime").val()) action=true;
    if(!action){
        alert("请选择查询条件!");
        return false;
    }
}

//功能: 订单详情
//作者: 张晓林
//时间: 2009年11月3日13:16:06
function orderDetail(o){
     var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
    showPage('../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true,'status:no;');
}
// JScript 文件
//功能：订单消费查询JS
//作者：张晓林
//日期：2010年2月23日14:22:31


//功能: 订单详情链接
//作者: 张晓林
//日期: 2008-11-28
function orderDetail(o){
    showPage('../../order/OrderDetail.aspx?OrderNo='+$(o).html(), null, 1000, 700, false, true,'status:no;');
}
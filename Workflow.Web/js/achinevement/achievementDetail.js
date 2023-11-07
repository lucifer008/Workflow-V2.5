// JScript 文件
/*
    //名    称：achievement
    //功能概要: 绩效详情查询JS
    //作    者: 张晓林
    //创建时间: 2009年4月23日13:13:40
    //修正履历:
    //修正时间:
*/

//获取订单详情
function orderDetail(o)
{
    showPage('../order/OrderDetail.aspx?OrderNo='+$(o).html(), null, 1000, 700, false, true,'status:no;');
}
// JScript 文件
//功能概要：应收款记录JS
//作    者：张晓林
//创建时间: 2009年12月16日10:48:11
//修正履历：
//修正时间:
function queryDataCheck(){
}

//功能: 显示客户付款款明细
//作者: 张晓林
//日期: 2010年2月4日16:02:10
function showPaidMoneyDetail(o){
    var memberCardNo="";
    var customerId=$("input:hidden[@name=customerId]",$(o).parent().parent()).val();
    var customerName=$($(o).parent().parent()).find(".customerName").html();
    var gatheringDateTime=$($(o).parent().parent()).find(".gatheringDateTime").html();
    if(""!=$("#txtMemberCardNo").val()){
        memberCardNo=$("#txtMemberCardNo").val();
    }
    var url="CustomerPaidMoneyDetail.aspx?CustomerId="+customerId+"&CustomerName="+escape(customerName);
    url+="&MembercardNo="+memberCardNo+"&GatheringDateTime="+gatheringDateTime;
    showPage(url, null, 700, 600, false, false);
}

//功能: 链接订单付款明细
//作者: 张晓林
//日期: 2010年2月8日10:54:20
function showOrderPaidMoneyDetail(o){
     var customerId=$("input:hidden[@name=customerId]",$(o).parent().parent()).val();
}
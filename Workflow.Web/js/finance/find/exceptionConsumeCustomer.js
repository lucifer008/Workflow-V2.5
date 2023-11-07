// JScript 文件
//功能：波动客户消费查询
//作者:张晓林
//日期:2010年2月23日13:41:45


//功能：查询数据验证
//作者：
//日期：
function checkData(){
    if($("#txtSumAmount").val()!=""){
        if(!checkOnlyNum($("#txtSumAmount"),true,14)){
            alert("您输入的金额有误!!!");
            $("#txtSumAmount").select();
            $("#txtSumAmount").focus();
            return false;
        }
    }
    var beginDate=$("#txtBeginDateTime").val();
    var endDate=$("#txtTo").val();
    if(""==beginDate || ""==endDate){
        alert("时间段不能为空!");
        return false;
    }
    return true;
}

//功能：客户详情链接
//作者：
//日期：
function customerDetail(o){
    var customerId=$($("input[@name='txtCustomerId']",$(o).parent().parent())).val();
    showPage('../../customer/CustomerDetail.aspx?Id='+customerId, null, 800, 550, false, true);
}
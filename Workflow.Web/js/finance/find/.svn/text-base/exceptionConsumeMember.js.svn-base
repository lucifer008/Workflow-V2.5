// JScript 文件
//功能: 异常消费会员查询
//作者: 张晓林
//日期: 2010年1月21日13:56:49

//功能: 查询验证
//作者: 张晓林
//日期: 2010年2月3日10:04:55
function checkData(){
    var beginDate=$("#txtBeginDateTime").val();
    var endDate=$("#txtTo").val();
    var sumAmount=$("#txtSumAmount").val();
    if(""==beginDate || ""==endDate){
        alert("时间段不能为空!");
        return false;
    }
    if(""!=sumAmount){
        if(!checkOnlyNum($("#txtSumAmount"),true,14)){
            alert("您输入的金额有误!!!");
            $("#txtSumAmount").select();
            $("#txtSumAmount").focus();
            return false;
        }
    }
    return true;
 }
 
 //会员详情链接
function memberCardDetail(o){
    var memberCardNo=$($("input[@name='txtMemberCardNo']",$(o).parent().parent())).val();
    showPage('../../MemberCard/MemberCardDetail.aspx?Id='+memberCardNo, null, 800, 550, false, true);
}

//功能: 输出数据验证
//作者: 张晓林
//日期: 2010年2月3日15:28:19
function printCheck(){
    if(isExistData){
        alert("请先查询数据!");
        return false;
    }  
}

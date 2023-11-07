// JScript 文件
//功能:无消费客户查询验证
//作者:张晓林
//日期:2010年1月25日13:05:10
function queryCheck(){
    var beginTime=$("#txtBeginDateTime").val();
    var endTime=$("#txtTo").val();
    if(""==beginTime || ""==endTime){
        alert("时间段不能为空!");
        return false;   
    }
    var isBTime=false;
    var isETime=false;
    if(""!=beginTime){
        if(!isDate(beginTime) && !isDateTime(beginTime)){
            isBTime=true;
        }
    }
    if(""!=endTime){
        if(!isDate(endTime) && !isDateTime(endTime)){
            isETime=true;
        }
    }
    if(isBTime){
        alert("日期格式错误!请重新输入!");
        $("#txtBeginDateTime").focus();
        return false;
    }
    if(isETime){
        alert("日期格式错误!请重新输入!");
        $("#txtTo").focus();
        return false;
    }
    getQueryCondition();
}
//功能: 输出条件
//作者: 张晓林
//日期: 2010年1月27日14:35:34
function printCheck(){
    getQueryCondition();
}
//功能:获取查询条件
//作者:张晓林
//日期:2010年1月26日9:19:38
getQueryCondition=function(){
    var strQueryCondition="";
    var customerLevel=$("select[@name=CustomerLevel]")[0];
    var customerType=$("select[@name=CustomerType]")[0];
    var membercarType=$("select[@name=MemberCardLevel]")[0];
    for(var i=0;i<customerLevel.length;i++){
        var isSelected=$(customerLevel[i]).attr("selected");
        var selectValue=$(customerLevel[i]).attr("value");
        if("-1"!=selectValue && isSelected){
            strQueryCondition="客户级别:"+$(customerLevel[i]).attr("Text")+" ";
            break;
        }
    }
     for(var i=0;i<customerType.length;i++){
        var isSelected=$(customerType[i]).attr("selected");
        var selectValue=$(customerType[i]).attr("value");
        if("-1"!=selectValue && isSelected){
            strQueryCondition+="客户类型:"+$(customerType[i]).attr("Text")+" ";
            break;
        }
    }
     for(var i=0;i<membercarType.length;i++){
        var isSelected=$(membercarType[i]).attr("selected");
        var selectValue=$(membercarType[i]).attr("value");
        if("-1"!=selectValue && isSelected){
            strQueryCondition+="会员类型:"+$(membercarType[i]).attr("Text")+" ";
            break;
        }
    }
    if(""!=$("#txtBeginDateTime").val()){
        strQueryCondition+="开始时间>="+$("#txtBeginDateTime").val()+" ";
    }
    if(""!=$("#txtTo").val()){
        strQueryCondition+="结束时间<="+$("#txtTo").val();
    }  
    $("#queryCondition").val(strQueryCondition);  
}
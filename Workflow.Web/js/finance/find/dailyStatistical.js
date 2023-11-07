// JScript 文件
///  功能：日统计查询JS
///  作者：张晓林
///  日期: 2010年4月16日11:55:20

function checkQueryCondition(){
    if(""==$("#txtBeginDateTime").val()){
        alert("查询日期不能为空!");
        $("#txtBeginDateTime").focus();
        return false;
    }
    return true;
}
//功能 :岗位编辑页面数据提交
//作者 :陈汝胤
//日期 :2009-1-15
currentAction=function(){
    $("#form1").submit();
    window.returnValue="ok";
    window.close();
}
//功能 :岗位删除数据提交
//作者 :陈汝胤
//日期 :2009-1-15
deleteRow=function(id,action){
        if(confirm("确定删除当前岗位吗?")){
            $("#currentValue").val(id);
            $("#form1").submit();
            $("#currentValue").val("");
         }
}
//功能 :岗位编辑数据提交
//作者 :陈汝胤
//日期 :2009-1-15
editRow=function(id){
    var obj=showPage("NewPosition.aspx?id="+escape(id),null,890,566,false,true,false);
    if(obj)
        $("#form1").submit();
}
//功能 :岗位添加数据提交
//作者 :陈汝胤
//日期 :2009-1-15
addRow=function(){
    var obj=showPage("NewPosition.aspx?id=",null,890,566,false,true,false);
    if(obj)
        $("#form1").submit();
}


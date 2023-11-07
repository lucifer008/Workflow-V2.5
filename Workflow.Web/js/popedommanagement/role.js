//功能 :角色编辑页面数据提交
//作者 :陈汝胤
//日期 :2009-1-16
currentAction=function(){
    $("#form1").submit();
    window.returnValue="ok";
    window.close();
}
//功能 :复选框选择的控制
//作者 :陈汝胤
//日期 :2009-1-16
//checkCheckBox=function(o){
//        var checkBoxs=$(o).parent().children();
//        if(o.checked){
//            for(var i=0;i<checkBoxs.length;i++){
//                if(o!=checkBoxs[i]){
//                    checkBoxs[i].disabled="disabled";
//                }
//            }
//        }
//        else{
//            for(var i=0;i<checkBoxs.length;i++){
//                checkBoxs[i].disabled="";
//            }
//        }
//}

//功能 :角色编辑的数据提交
//作者 :陈汝胤
//日期 :2009-1-16
editorRole=function(id){
        var obj=showPage("ModifyRole.aspx?id="+escape(id),null,890,700,false,true,false);
        if(obj)
            $("#form1").submit();
}

//功能 :角色添加的数据提交
//作者 :陈汝胤
//日期 :2009-1-16
addRole=function(){
    //不传参数竟然会出现访问没有权限
    var obj=showPage("ModifyRole.aspx?id=",null,890,700,false,true,false);
    if(obj)
        $("#form1").submit();
}

//功能 :角色删除的数据提交
//作者 :陈汝胤
//日期 :2009-1-16
deleteRole=function(id){
    if(confirm("确定删除当前角色吗?")){
        $('#currentValue').val(id);
        $('#form1').submit();
        $('#currentValue').val("");
    }
}


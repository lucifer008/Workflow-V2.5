// JScript 文件
//功能: 批量删除门市价格JS
//作者: 张晓林
//日期：2010年1月15日9:35:36


//功能: 批量删除验证
//作者: 张晓林
//日期: 2010年1月15日10:51:46
function batchDeletePrice(){
    var sltCount=0;
    var arrDeleId=$("input:hidden[@name=bbtplId]");
    for(var i=0;i<arrDeleId.length;i++){
        var cbObject=$("input:checkbox[@name=cbBBTPSL"+$(arrDeleId[i]).val()+"]");
        if($(cbObject).attr("checked")){
            sltCount++;
        }
    }
    if(0==sltCount){
        alert("请选择删除的价格!");
        return false;
    }
    var yes=confirm("确认删除吗?");
    if(yes){
        $("#Action").val("Delete");
        $("#batchDelete").attr("disabled",true);
        $("#MainForm").submit();
    }
}

//功能: 批量选择与取消
//作者: 张晓林
//日期: 2010年1月15日10:51:46
function allSelectedClick(){
    var cbStatus=$("#cbSelected").attr("checked");
    var arrDeleId=$("input:hidden[@name=bbtplId]");
    var cbArr=$("input:checkbox[@name=cbBBTPSL]");
     if(cbStatus){   
        for(var i=0;i<arrDeleId.length;i++){
           var cbObject=$("input:checkbox[@name=cbBBTPSL"+$(arrDeleId[i]).val()+"]");
           $(cbObject).attr("checked",true)
        }
     }
     else{
        for(var i=0;i<arrDeleId.length;i++){
            var cbObject=$("input:checkbox[@name=cbBBTPSL"+$(arrDeleId[i]).val()+"]");
           $(cbObject).attr("checked",false)
        }
     }
}
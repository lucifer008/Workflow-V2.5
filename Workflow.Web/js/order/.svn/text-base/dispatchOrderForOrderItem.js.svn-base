// JScript 文件
//功能:订单分配动作JS
//作者:张晓林
//时间:2010年1月7日9:47:43


/////名    称: newOrderDispatchCheck
/////功能概要: 新流程-分配提交验证
/////作    者: 张晓林
/////创建时间: 2010年1月7日15:52:44
/////修正履历: 
/////修正时间: 
//function newOrderDispatchCheck(){
//    try{
//        
//        var receive=$("#receive option:selected").text();
//        if(""==receive){
//            alert('请分配接待人员!');
//            return false;
//        }
//        var selCount=0;
//        var  slt=$("#receive")[0];
//        for(var i=0;i<slt.length;i++){
//            if($(slt[i]).attr("selected")){
//                selCount++;
//            }
//        }
//        if(1<selCount){
//            alert('接待人员最多一个!');
//            return false;
//        }
//        if($("textarea[@name='Memo']").val().length>200){
//            alert("您输入的备注太长!");
//            $("textarea[@name='Memo']").focus();
//            $("textarea[@name='Memo']").select();
//            return false;
//        }
//        $("#btnOk").attr("disabled",true);
//        $("#actionTag").val("True");
//        $("#form1").submit();
//    }catch(e){}  
//    return true;
//}


// ///名    称: clearSelected
// ///功能概要: 取消选中人员
// ///作    者: 张晓林
// ///创建时间: 2010年1月7日15:52:44
// ///修正履历:
// ///修正时间:    
//function clearSelected(o){
//        var objArr=$("select[multiple]",$(o).parent().parent());        
//        for(var i=0;i<objArr.length;i++){
//            for(var j=0;j<objArr[i].length;j++)
//            {
//                $(objArr[i][j]).attr("selected",false);
//            }
//        }   
//}

$().ready(function (){
    if($("#actionTag").val()!="Finish" && "False"==cf)
    {
        var orderNo=$("#txtOrderNo").val();
        var customerName=$("#txtCustomerName").val();
        createContainer(orderNo,customerName,2,document.forms[0].id);
    }
}
);

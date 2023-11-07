//功能 :点击新增未完成工单纸张数量
//作者 :陈汝胤
//日期 :2009-2-11
editProductionPaperAmount=function(id){
	id=id || 0;
	var obj=showPage("EditProductionPaperAmount.aspx?id="+id,null,870,466,false,true,false);
	if(obj){
		$("#RecordMachineWatch").val(obj);
		$("#form1").submit();
	}
}

//功能 :删除未完工工单用纸数量
//作者 :陈汝胤
//日期 :2009.4.24
deleteRow=function(id){
    if(confirm("确定删除吗?")){
        $("#UncompleteOrder").val(id);
        $("#form1").submit();
     }
}

//功能 :验证密码
//作者 :陈汝胤
//日期 :2009.5.6
verifyRecordWatch=function(){

	var check=$("input[@class=check]");
	for(var i=0;i<check.length;i++){
		if(!$(check[i]).val()){
			alert('请输入抄表数据!');
			return;
		}
	}
	
	var password=$("#password").val();
	var userid=$("#userSel").val();
	if(!password){
		alert('请出入验证密码!');
		return;
	}
	var provider = {};
    provider.process = function(data) {
        checkPassWork(data);
    };
    $.getJSON("../ajax/AjaxEngine.aspx?id="+userid+'&pwd='+password, {a : '29'},provider.process);
	
	
}
//功能 :核实抄表
//作者 :陈汝胤
//日期 :2009.5.6
checkPassWork=function(data){
	if(data){
		$("#verify").val("ok");
		$("#form1").submit();
	}
	else
	{
		alert('请输入正确的密码!');
	}
}
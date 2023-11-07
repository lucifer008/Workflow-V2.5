
//功能 :点击新增补单
//作者 :陈汝胤
//日期 :2009-5-4
addCompensateUsedPaper=function(id){
	var val=showPage("Compensate.aspx?id="+id,null,890,466,false,true,false);
	if(val){
		$("#form1").submit();
	}
}

//功能 :点击删除当前补单
//作者 :陈汝胤
//日期 :2009-5-6
deleteCompensate=function(id){
	if(confirm('您确定要删除吗?')){
		$("#compensateUsedPaperId").val(id);
		$("#form1").submit();
	}
}

//功能 :编辑当前补单
//作者 :陈汝胤
//日期 :2009-5-6
editCompensateUsedPaper=function(id,cid){
	var val=showPage("Compensate.aspx?id="+id+"&cid="+cid,null,890,466,false,true,false);
	if(val){
		$("#form1").submit();
	}
}

//功能 :编辑当前补单
//作者 :陈汝胤
//日期 :2009-5-6
completeVerify=function(){
	$("#compensateVerify").val("ok");
	$("#form1").submit();
}


pageLoad=function(data){
	if(data){
		alert('核实完成');
		window.navigate('CopyCounter.aspx');
	}
}
//功能 :保存未完工订单用纸
//作者 :陈汝胤
//日期 :2009.4.22
saveeProductionPaperAmount=function(){
	var number=$("#number").val();
	if(number==0 || number=="")
	{
		alert("请输入数量");
		$("#number").focus();
		$("#number").val("");
	}
	else{
		$("#form1").submit();
	}
}

//功能 :检索完成状况
//作者 :陈汝胤
//日期 :2009.4.22
checkComplete=function(id){
	if(id){
		window.returnValue=id;
		window.close();
	}
}

//功能 :输入框获取到焦点的时候清理输入框的内容
//作者 :陈汝胤
//日期 :2009.5.5
clearData=function(o){
	o.value="";
}

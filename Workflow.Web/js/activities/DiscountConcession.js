//功能 :删除当前行
//作者 :陈汝胤
//日期 :2009-5-11
delRow=function(id){
	if(confirm('确定删除当前活动吗?')){
		$("#delRow").val(id);
		$("#form1").submit();
	}
}
//功能 :编辑当前行
//作者 :陈汝胤
//日期 :2009-5-12
editRow=function(id){
	window.navigate('AddDiscountConcession.aspx?id='+id);
}

//功能 :将折扣加入到队列中
//作者 :陈汝胤
//日期 :2009-5-11
var discountValue=new Array(); //存放打折记录的数组
addDiscountValue=function(){
	var discountVal=$("#discount").val();
	if(!discountVal || isNaN(discountVal)){
		alert('请输入正确的折扣值!');
		return;
	}
	var machine=getSelectdObj('machine');
	if(machine.length==0){
		alert('请选择机器类型');
		return;
	}
	var paper=getSelectdObj('paper')
	if(paper.length==0){
		alert('请选择纸型');
		return;
	}
	for(var i=0;i<machine.length;i++){
		for(var j=0;j<paper.length;j++){
			if(isExitsDiscount(machine[i].value,paper[j].value,discountVal)){
				var discount=new discountClass(discountValue.length+1,machine[i].value,machine[i].text,paper[j].value,paper[j].text,discountVal);
				discountValue.push(discount);
			}
		}
	}
	showDiscountInfo();
}


getSelectdObj=function(id){
	var objArr=new Array();
	var objs=document.getElementById(id);
	for(var i=0;i<objs.length;i++){
		if(objs[i].selected){
			var obj=new Object();
			obj.text=objs[i].text;
			obj.value=objs[i].value;
			objArr.push(obj);
		}
	}
	return objArr;
}
//功能 :创建打折记录的类
//作者 :陈汝胤
//日期 :2009-5-11
discountClass=function(id,machineId,machineName,paperId,paperName,discountVal){
	this.id=id;
	this.machineId=machineId;
	this.machineName=machineName;
	this.paperId=paperId;
	this.paperName=paperName;
	this.val=discountVal;
}
//功能 :检索打折记录是否存在
//作者 :陈汝胤
//日期 :2009-5-11
isExitsDiscount=function(machineId,paperId,val){
	for(var i=0;i<discountValue.length;i++){
		if(discountValue[i].machineId==machineId
		&& discountValue[i].paperId==paperId
		&& discountValue[i].val==val
		){
			return false;
		}
	}
	return true;
}
//功能 :删除打折记录信息
//作者 :陈汝胤
//日期 :2009-5-11
showDiscountInfo=function(){
	var showDiscount=document.getElementById('showDiscount');
	var valStr='';
	for(var i=0;i<discountValue.length;i++){
		var o=discountValue[i];
		valStr+="<div id='apply"+o.id+"'><span style='color:red'>机器类型</span>:"+o.machineName+" <span style='color:red'>纸型</span>:";
		valStr+=discountValue[i].paperName+" <span style='color:red'>折扣</span>:"+o.val+"% <a href='javascript:removeAppay("+o.id+")'>删除</a></div>"
	}
	showDiscount.innerHTML=valStr;
	var showDiscountCount=document.getElementById('showDiscountCount');
	showDiscountCount.innerHTML='当前打折相关条目数量:<span style="color:red">'+discountValue.length+'</span>';
}
//功能 :重置打折记录
//作者 :陈汝胤
//日期 :2009-5-11
resetDiscount=function(){
	discountValue=new Array();
	var showDiscount=document.getElementById('showDiscount');
	showDiscount.innerHTML='';
	var showDiscountCount=document.getElementById('showDiscountCount');
	showDiscountCount.innerHTML='当前打折相关条目数量:<span style="color:red">0</span>';
}

//功能 :保存打折记录
//作者 :陈汝胤
//日期 :2009-5-12
saveDiscount=function(){
	var campaigns=document.getElementById('campaign');
	if(campaigns.value==0){
		alert('请选择所属营销活动!');
		return;
	}
	var project=$("#project").val();
	if(!project){
		alert('请输入方案名称!');
		return;
	}
	if(discountValue.length==0){
		alert('请选择折扣相关的机器和纸型!');
		return;
	}
	var discountStr='';
	for(var i=0;i<discountValue.length;i++){
		discountStr+=discountValue[i].machineId+'\''+discountValue[i].paperId+'\''+discountValue[i].val;
		if(i+1!=discountValue.length)
			discountStr+='|';
	}
	$("#discountInfo").val(discountStr);
	$("#form1").submit();
}

//功能 :删除一条折扣描述记录
//作者 :陈汝胤
//日期 :2009-5-12
removeAppay=function(id){
	var applyObj=document.getElementById('apply'+id);
	var showDiscount=document.getElementById('showDiscount');
	showDiscount.removeChild(applyObj);
	discountValue.remove(id);
	showDiscountInfo();
}

//功能 :数组删除
//作者 :陈汝胤
//日期 :2009-5-12
Array.prototype.remove=function removeArray(dx){
    if(isNaN(dx)||dx>this.length)return false;
    for(var i=0,n=0;i<this.length;i++){
        if(this[i]!=this[dx]){
			this[n]=this[i];
			n++;
        }
	}
    this.length-=1
    return true;
}

//功能 :编辑活动时,初始化原来的数据
//作者 :陈汝胤
//日期 :2009-5-12
initDiscount=function(data){
	if(data){
		var discounts=data.split('|');
		for(var i=0;i<discounts.length;i++){
			var o=discounts[i].split(',');
			var discount=new discountClass(i+1,o[0],o[1],o[2],o[3],parseInt(o[4]*100));
			discountValue.push(discount);
		}
		showDiscountInfo();
	}
}
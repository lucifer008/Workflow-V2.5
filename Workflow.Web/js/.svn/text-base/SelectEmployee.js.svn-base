// JScript 文件
// 作    者: 陈汝胤
// 创建时间: 2010-12-18
// 描    述: 统一的订单项选取分配前期后期员工
var employeeType;
var selOrderItemIds=new Array(); //当前选中的订单信息

var resultInfoArr=new Array();
var formId="";

var msgObj; //显示层
function createContainer(orderNo,customerName,type,strFormId){
    formId=strFormId;
	employeeType=type || 2;
	msgObjWidth=780;
	if(msgObj)
		msgObj.innerHTML='';
	else
		msgObj=document.createElement("div");
	msgObj.id='msgDiv';
	with(msgObj.style){
		background='white';
		//border='0px solid #3366CC';
		position='absolute';
		wordBreak='break-all';
		width=msgObjWidth;
		top=type==1?'35%':'28%';
		left='50%';
		marginLeft=-(msgObjWidth/2)-2;
		textAlign='left';
	}
	var obj=document.getElementById("divContent");
	if(obj!=null)
	    obj.appendChild(msgObj);
	else
        document.body.appendChild(msgObj);
    
    var titleName=employeeType==1?"完工订单":"前期选择";
    
    var html='<div style="width:92%;margin:auto;font-size:16px;text-align:center"><strong>'+titleName+'</strong></div>';
    html+='<div style="width:92%;margin:auto;font-size:12px;text-align:left"><strong>订单号:'+orderNo+'</strong>&nbsp;&nbsp;&nbsp;&nbsp;客户名称:'+customerName+'</div>';
    html+='<div style="width:92%;margin:auto;font-size:12px;text-align:left"><strong>前期:</strong></div>';
    html+='<div id="prophase" style="width:92%;margin:auto;font-size:12px;text-align:left"></div>';
    if(employeeType==1){
		html+='<div style="width:92%;margin:auto;font-size:12px;text-align:left"><strong>后期:</strong></div>';
		html+='<div id="anaphase" style="width:92%;margin:auto;font-size:12px;text-align:left"></div>';
    }
    html+='<div id="orderItemDiv" style="width:92%;margin:auto;font-size:12px;text-align:left"></div>';
    html+='<div style="width:92%;margin:auto;font-size:12px;text-align:left"></div>';
    html+='<div style="width:92%;margin:auto;font-size:16px;text-align:center"><input type="button" value="确定" class="buttons" onclick="closeMsgObj()"</div>';
    msgObj.innerHTML=html;
    
    getInfo(orderNo);
}
closeMsgObj=function(){
	//selOrderItemIds=new Array();
	//document.body.removeChild(msgObj);
	//var msgObj=null;
	for(var i=0;i<resultInfoArr.length;i++)
	{
	    if(resultInfoArr[i]["prophaseIds"].length<=0 && resultInfoArr[i]["anaphaseIds"].length<=0)
	    {
	        alert('每个订单明细应至少有一个参与人员!');
	        return;
	    }   
	}
	
	$("#txtResult").val($.toJSON(resultInfoArr));
	$("input:button[@value=确定]").attr("disabled",true);
	$("#actionTag").val('Finish');
	$("#"+formId+"").submit();
}
//获取信息
function getInfo(orderNo){
    var url="../ajax/AjaxEngine.aspx?orderNo="+orderNo;
    var provider = {};
    provider.process = function(json) {
        window.getInfoComplete(json);
    };
    $.getJSON(url,{a:'34'},provider.process);
}
//数据返回
function getInfoComplete(data){
	if(data.success==false){
		alert('提供数据有错误');
		return;
	}
	createEmployee(data.Employees);
	
	createOrderItem(data.OrderItems);
	
	getMsgHeight();
	//默认绑定前期分配的人--张晓林
	if( typeof(receptionEmployeeName)!="undefined" && ""!=receptionEmployeeName){
	    selectEmployee(receptionEmployeeId,receptionEmployeeName,1);
	}
}


//创建用户层
createEmployee=function(data){
	var prophaseObj=document.getElementById('prophase');
	var anaphaseObj=document.getElementById('anaphase');
	for(var i=0;i<data.length;i++){
		if(data[i].IsProphase==1){
			prophaseObj.appendChild(createDivObj(data[i].Id,data[i].Name,1));
		}
		else{
			if(employeeType==1){
				anaphaseObj.appendChild(createDivObj(data[i].Id,data[i].Name,0));
			}
		}
	}
}

//创建雇员
createDivObj=function(id,name,isProphase){
	var divObj=document.createElement(id);
	
	divObj.id=isProphase?'prophase'+id:'anaphase'+id;
	with(divObj.style){
		border='1px dashed #988000';
		marginLeft=4;
		styleFloat='left';
		marginTop=2;
		color='#000000';
		fontSize=name.length>=4?12:16
		textAlign='center';
		cursor='pointer';
		fontWeight='bold';
		width=58;
		height=20;
	}
	divObj.onclick=new Function('selectEmployee("'+id+'","'+name+'",'+isProphase+')');
	divObj.innerHTML=name;
	return divObj;
}
//已添加的雇员
createSelDivObj=function(id,name,itemObjId,orderItemId,isProphase){
	var divObj=document.createElement(id);
	divObj.id=itemObjId+id;
	with(divObj.style){
		border='1px dashed #988000';
		marginLeft=4;
		styleFloat='left';
		marginTop=2;
		color='red';
		fontSize=name.length>=4?12:16
		textAlign='center';
		cursor='pointer';
		fontWeight='bold';
		width=58;
		height=20;
	}
	divObj.onclick=new Function('deleteSelEmployee("'+id+'","'+itemObjId+'","'+orderItemId+'",'+isProphase+')');
	divObj.innerHTML=name;
	return divObj;
}
deleteSelEmployee=function(id,itemObjId,orderItemId,isProphase){
	for(var j=0;j<resultInfoArr.length;j++){
		if(resultInfoArr[j].orderItemId==orderItemId){
			if(isProphase>0){
				for(var k=0;k<resultInfoArr[j].prophaseIds.length;k++){
					if(resultInfoArr[j].prophaseIds[k]==id){
						resultInfoArr[j].prophaseIds.splice(k,1);
					}
				}
			}
			else{
				for(var k=0;k<resultInfoArr[j].anaphaseIds.length;k++){
					if(resultInfoArr[j].anaphaseIds[k]==id){
						resultInfoArr[j].anaphaseIds.splice(k,1);
					}
				}
			}
		}
	}
	document.getElementById(itemObjId).removeChild(document.getElementById(itemObjId+id));
}
selectEmployee=function(id,name,isProphase){
	if(selOrderItemIds.length==0){
		alert('请选择要添加的订单项');
		return;
	}
	var divObj=document.getElementById(id);
	
	for(var i=0;i<selOrderItemIds.length;i++){
		var itemObjId=isProphase?'itemProphase'+selOrderItemIds[i]:'itemAnaphase'+selOrderItemIds[i];
		var itemDivObj=document.getElementById(itemObjId);
		var selObj =document.getElementById(itemObjId+id);
		if(selObj){
			deleteSelEmployee(id,itemObjId,selOrderItemIds[i],isProphase);
		}
		else{
			for(var j=0;j<resultInfoArr.length;j++){
				if(resultInfoArr[j].orderItemId==selOrderItemIds[i]){
					if(isProphase){
						resultInfoArr[j].prophaseIds.push(id);
					}
					else{
						resultInfoArr[j].anaphaseIds.push(id);
					}
				}
			}
			selObj=createSelDivObj(id,name,itemObjId,selOrderItemIds[i],isProphase);	
			itemDivObj.appendChild(selObj);
		}
	}
	
	getMsgHeight();
}

//创建订单项目
createOrderItem=function(data){
	var orderItemDiv=document.getElementById('orderItemDiv');
	
	var html=getOrderItemTitleHtml();
	
	for(var i=0;i<data.length;i++){
		html+='<tr><td><input id="checkOrderItem'+data[i].Id+'" onclick="selOrderItem(this,'+data[i].Id+')" type="checkbox" checked="checked" value="'+data[i].Id+'" /></td>';
		html+='<td>'+(i+1)+'</td><td align="center">'+data[i].Name+'</td><td align="center">'+data[i].Amount+'</td>';
		html+='<td><div id="itemProphase'+data[i].Id+'" style="width:92%;margin:auto;font-size:12px;text-align:left"></div>';
		if(employeeType==1){
			html+='<td><div id="itemAnaphase'+data[i].Id+'" style="width:92%;margin:auto;font-size:12px;text-align:left"></div></td>';
		}
		html+='</tr>'
		selOrderItemIds.push(data[i].Id);
		
		var resultInfo=new resultInfoClass(data[i].Id);
		resultInfoArr.push(resultInfo)
	}
	html+='</table>';
	
	orderItemDiv.innerHTML=html;
	
}
function resultInfoClass(id){
	this.orderItemId=id;
	this.prophaseIds=new Array();
	this.anaphaseIds=new Array();
}
selOrderItem=function(o,id){
	if(o.checked){
		o.checked=true;
		selOrderItemIds.push(id);
	}
	else{
		o.checked=false;
		
		for(var i=0;i<selOrderItemIds.length;i++){
			if(selOrderItemIds[i]==id){
				selOrderItemIds.splice(i,1);
				break;
			}
		}
	}
	
}
//重新获取层的高度
getMsgHeight=function(){
	//msgObj.style.height=msgObj.offsetHeight;
	//msgObj.style.marginTop=-(msgObj.offsetHeight/2);
	msgObj.style.marginTop=-170;
}
//订单项的html
getOrderItemTitleHtml=function(){
	var html='<table width="100%" border="1" cellpadding="2" cellspacing="1"><tr><th  nowrap style=" text-align:center" class="w1"></th><th nowrap style=" text-align:center" class="w1">No</th><th nowrap style=" text-align:center" class="w1">加工内容</th>';
    html+='<th nowrap style=" text-align:center" class="w1">数量</th><th width="40%" nowrap style=" text-align:center" >前期</th>';// <th nowrap ></th>
    if(employeeType==1){
		html+='<th width="40%" nowrap style=" text-align:center" >后期</th></tr>';
	}
    return html;                              
}


//------------------------//
//监听回车
//--------------------------//
document.onkeydown=userKeyDown;
var lastSelId;
var selPosition=1;
var lastSelIndex=0;
function userKeyDown(e){
	try{
		if(!msgObj) return;
		var evt=event || e;
		
		if(evt.keyCode==38){
			var parentObj=selPosition?document.getElementById('anaphase'):document.getElementById('prophase');
			var parentObjs=parentObj.childNodes;
			if(parentObjs){
				var obj=parentObjs[lastSelIndex-11];
				if(obj){
					setSelObjEffect(obj);
					lastSelIndex-=11;
				}
			}
			return false;	
		}
		if(evt.keyCode==40){
			var parentObj=selPosition?document.getElementById('anaphase'):document.getElementById('prophase');
			var parentObjs=parentObj.childNodes;
			if(parentObjs){
				var obj=parentObjs[lastSelIndex+11];
				if(obj){
					setSelObjEffect(obj);
					lastSelIndex+=11;
				}
			}
			return false;
		}
		
		if(evt.keyCode==39){ //右
			if(lastSelId){
				var obj=document.getElementById(lastSelId);
				var nextObj=obj.nextSibling;
				if(nextObj){
					setSelObjEffect(nextObj);
					lastSelIndex++;
				}
				return false;
			}
		}
		
		if(evt.keyCode==37){ //左
			if(lastSelId){
				var obj=document.getElementById(lastSelId);
				var lastObj=obj.previousSibling;
				if(lastObj){
					setSelObjEffect(lastObj);
					lastSelIndex--;
				}
				return false;
			}
		}
		//TABLE
		if(evt.keyCode==9){
			var parentObj=employeeType==1?selPosition?document.getElementById('prophase'):document.getElementById('anaphase'):document.getElementById('prophase');
			var firstObj=parentObj.firstChild;
			setSelObjEffect(firstObj);
			lastSelIndex=0;
			selPosition=employeeType==1?selPosition?0:1:0;
			return false;
		}
		
		if(evt.keyCode==32){
			if(lastSelId){
				var obj=document.getElementById(lastSelId);
				obj.click();
			}
			return false;
		}
	    if (evt.keyCode==27)	
	    {
		    window.close();
	    }
		
	}catch(ex){ alert('error'+ex.message);}
}
setSelObjEffect=function(o){
	if(o){
		with(o.style){
			color='#558866';
			border='1px solid #E10C0C';
		}
		if(o.id!=lastSelId)
			resumeSelObjEffect();
		lastSelId=o.id;
	}
}

resumeSelObjEffect=function(){
	if(lastSelId){
		var obj=document.getElementById(lastSelId);
		with(obj.style){
			color='#000000';
			border='1px dashed #988000';
		}
	}
}
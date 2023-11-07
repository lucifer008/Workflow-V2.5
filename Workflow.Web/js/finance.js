// JScript 文件
/*
    名    称:finance
    功能概要:收银js
    作    者:
    创建时间:
    修正履历：
    修正时间:
*/


var isCarryMoney=false;
var sumTotal=0;//订单总金额
var paperCountTotal=0;//能冲减的印章数合计
var paperAmount=0;//能冲减的金额合计
var busTypeUninPrice=0;//能冲减的业务类型的单价
/*加载页面属性*/
$(document).ready(
function()
{
    sumTotal=parseFloat($("#txtSumMoney").val());
    //检查是否存在匹配的优惠业务明细
    var memberCardId=$("#hiddMemberCardId").val();
    var orderNo=$("#hidOrderNo").val();
    var url="../ajax/AjaxEngine.aspx?memberCardId="+memberCardId+"&orderNo="+(orderNo);
    $.getJSON(url,{a:'28'},callBackLoad);
}
);

//功能 : 获取所有优惠活动
//作者 : 陈汝胤
//日期 : 2009-5-18
var tempCampaignArr;
var campaignData;
var orderItemCampaignArr=new Array();
function callBackLoad(data)
{
    if(!data || data.success==false){
		return;
    }
    campaignData=data;
    try{
		tempCampaignArr=new Array();
		var thHtml=$("#tr0").html()+'<th width="6%" nowrap="nowrap">&nbsp;选择活动&nbsp;</th><th width="3%" nowrap="nowrap">&nbsp;冲减数量(金额)&nbsp;</th>';
		thHtml+='<th width="3%" nowrap="nowrap">&nbsp;应付金额&nbsp;</th>';
		tempCampaignArr.push(thHtml);
		
		for(var i=0;i<data.OrderItemList.length;i++){
			var orderItem=data.OrderItemList[i];
			var concession='';
			//判断印章活动是否可用
			for(var j=0;j<data.MemberCardConcessionList.length;j++){
				if(orderItem.BaseBusinessTypePriceSetId==data.MemberCardConcessionList[j].BaseBusinessTypePriceSetId){
					concession="印章<input name='radCampaign"+i+"' type='radio' onclick='showChooseCampaignList(1,"+orderItem.Id+");' value=''/> ";
					break;
				}
			}
			//判断打折活动是否可用
			var isBreak=false;
			for(var j=0;j<data.MemberCardDiscountConcessionList.length;j++){
				if(isBreak) break;
			
				var contrastValues=data.MemberCardDiscountConcessionList[j].ContrastValues;
				for(var k=0;k<contrastValues.length;k++){
					var arrObj=contrastValues[k].split(',');
					if(orderItem.MachinePriceFactor==arrObj[0] && orderItem.PaperPriceFactor==arrObj[1]){
						concession+="打折<input name='radCampaign"+i+"' type='radio' onclick='showChooseCampaignList(0,"+orderItem.Id+")' value='' />";
						isBreak=true;
						break;
					}
				}
			}
			var allPrice=fltMul(orderItem.Amount,orderItem.UnitPrice);
			var tdHtml=$("#tr"+(i+1)).html()+'<td width="6%" class="left">'+concession+'</td><td id="campaignInfoCount'+orderItem.Id+'" width="3%" class="left">0</td>';
			tdHtml+='<td id="campaignInfoPayment'+orderItem.Id+'" width="3%" class="left">'+allPrice+'</td>';
			tempCampaignArr.push(tdHtml);
			var orderItemCampaign=new orderItemCampaignClass();
			orderItemCampaign.id=orderItem.Id;
			orderItemCampaign.payment=allPrice;
			orderItemCampaign.allPrice=allPrice;
			orderItemCampaign.itemPrice=orderItem.UnitPrice;
			orderItemCampaignArr.push(orderItemCampaign);
		}
		$("#spanCampaign").css("display","");
		usedCampaign(true);
    }
    catch(ex){
		alert("活动数据发生错误:错误原因"+ex.message);
    }
}


//功能 : 订单明细参加的活动类
//作者 : 陈汝胤
//日期 : 2009-5-22
//参数 : id  订单明细id,type 活动类型,campgignId 活动id,amount 使用的数量或金额,payment 应付款金额,isUsed 是否使用,usedPrice 使用金额
orderItemCampaignClass=function(id,type,campaignId,usedAmount,payment,isUsed,usedPrice,allPrice,itemPrice,campaignPrice){
	this.id=id;
	this.campaignId=campaignId;
	this.type=type;
	this.usedAmount=usedAmount;
	this.payment=payment;
	this.isUsed=isUsed;
	this.usedPrice=usedPrice;
	this.allPrice=allPrice;
	this.itemPrice=itemPrice;
	this.campaignPrice=campaignPrice;
}

//功能 : 选择使用优惠活动
//作者 : 陈汝胤
//日期 : 2009-5-20
var isUsedCampaign;
usedCampaign=function(val){
	isUsedCampaign=val;
	if(!isUsedCampaign)
		clearOrderItemCampaign();
	for(var i=0;i<tempCampaignArr.length;i++){
		var tempVal=$("#tr"+i).html();
		if(!isUsedCampaign)
			tempVal=tempVal.replace('CHECKED','');
		$("#tr"+i).html(tempCampaignArr[i]);
		tempCampaignArr[i]=tempVal;
	}
}

//功能 : 显示选中的活动列表
//作者 : 陈汝胤
//日期 : 2009-5-22
showChooseCampaignList=function(val,orderItemId){
	//显示印章活动
	var html='';
	
	clearOrderItemCampaign(orderItemId);
	
	if(val){
		html='<tr><th nowrap="nowrap">活动名称</th><th nowrap="nowrap">剩余数量</th><th nowrap="nowrap">冲抵印章数</th><th nowrap="nowrap"></th></tr>';
		for(var i=0;i<campaignData.MemberCardConcessionList.length;i++){
			var o=campaignData.MemberCardConcessionList[i];
			html+='<tr><td>'+o.ConcessionName+'</td><td>'+o.RestPaperCount+'</td><td><input id="campaignUsedCount'+o.Id+'" type="text" style="width:50px;" /></td>';
			html+='<td><input type="button" onclick="accountConcession('+o.Id+','+orderItemId+')"  value="确定"/></td><tr>';
		}
		$("#divShowCampaign").html(html);
	}
	else{ //打折活动
		html='<tr><th nowrap="nowrap">活动名称</th><th nowrap="nowrap">剩余金额</th><th nowrap="nowrap">折扣</th><th nowrap="nowrap">冲抵金额</th><th nowrap="nowrap"></th></tr>';
		for(var i=0;i<campaignData.MemberCardDiscountConcessionList.length;i++){
			var o=campaignData.MemberCardDiscountConcessionList[i];
			html+='<tr><td>'+o.DiscountConcessionName+'</td><td>'+o.RestAmount+ '</td><td>'+o.Discount+'</td><td><input id="campaignUsedCount'+o.Id+'" type="text" style="width:50px;" /></td>';
			html+='<td><input onclick="accountDiscountConcession('+o.Id+','+orderItemId+')" type="button" value="确定"/></td></tr>'; 
		}
		$("#divShowCampaign").html(html);
	}
}

//功能 : 计算送印章活动的使用
//作者 : 陈汝胤
//日期 : 2009-5-22
accountConcession=function(id,orderItemId){
	var amount=$("#campaignUsedCount"+id).val();
	if(!amount || isNaN(amount) || parseInt(amount)<0){
		alert('请输入有效数量!');
		return;
	}
	var checkAmount=amount.split('.');
	if(checkAmount.length>1){
		alert('');
		return;
	}
	
	var currentCampaign,currentOrderItem;
	//查找当前活动数据
	for(var i=0;i<campaignData.MemberCardConcessionList.length;i++){
		if(campaignData.MemberCardConcessionList[i].Id==id){
			currentCampaign=campaignData.MemberCardConcessionList[i];
			break;
		}
	}
	//查找当前订单数据
	for(var i=0;i<campaignData.OrderItemList.length;i++){
		if(campaignData.OrderItemList[i].Id==orderItemId){
			currentOrderItem=campaignData.OrderItemList[i];
			break;
		}
	}
	if(!currentCampaign || !currentOrderItem){
		alert('accountConcession中数据错误,请查证');
		return;
	}
	if(amount>currentCampaign.RestPaperCount || amount>currentOrderItem.Amount){
		alert('可冲抵数量超出可用数量范围!');
		return;
	}
	//送印章活动的可用数量冲抵
	currentCampaign.RestPaperCount=currentCampaign.RestPaperCount-amount;
	//显示信息
	$("#campaignInfoCount"+orderItemId).html(amount);
	var payment=fltMul(currentOrderItem.Amount-amount,currentOrderItem.UnitPrice);
	if(!payment || payment=='0') payment='0.00';
	$("#campaignInfoPayment"+orderItemId).html(payment);
	saveCampaignData(orderItemId,id,1,amount,payment,'',currentCampaign.ConcessionPrice);
	$("#divShowCampaign").html('<tr></tr>');
}

//功能 : 计算打折活动的使用
//作者 : 陈汝胤
//日期 : 2009-5-25
accountDiscountConcession=function(id,orderItemId){
	var amount=$("#campaignUsedCount"+id).val();
	if(!amount || isNaN(amount) || parseInt(amount)<0){
		alert('请输入冲抵金额!');
		return;
	}
	var checkAmount=amount.split('.');
	if(checkAmount.length>1 && checkAmount[1].length>2){
		alert('请输入有效的金额');
		return;
	}
	
	var currentCampaign,currentOrderItem;
	//查找当前活动数据
	for(var i=0;i<campaignData.MemberCardDiscountConcessionList.length;i++){
		if(campaignData.MemberCardDiscountConcessionList[i].Id==id){
			currentCampaign=campaignData.MemberCardDiscountConcessionList[i];
			break;
		}
	}
	//查找当前订单数据
	for(var i=0;i<campaignData.OrderItemList.length;i++){
		if(campaignData.OrderItemList[i].Id==orderItemId){
			currentOrderItem=campaignData.OrderItemList[i];
			break;
		}
	}
	if(!currentCampaign || !currentOrderItem){
		alert('accountConcession中数据错误,请查证');
		return;
	}
	var allPrice=fltMul(currentOrderItem.UnitPrice,currentOrderItem.Amount);
	if(fltSub(amount,allPrice)>0){
		alert('请输入有效的金额!');
		return;
	}
	var usedPrice=formatFloat(fltMul(amount,currentCampaign.Discount),2);
	var payment=fltSub(allPrice,amount);
	if(!payment || payment=='0') payment='0.00';
	
	currentCampaign.RestAmount=fltSub(currentCampaign.RestAmount,usedPrice);
	$("#campaignInfoCount"+orderItemId).html(amount);
	$("#campaignInfoPayment"+orderItemId).html(payment);
	saveCampaignData(orderItemId,id,0,amount,payment,usedPrice,currentCampaign.Discount);
	$("#divShowCampaign").html('<tr></tr>');
}

//功能 : 保存参加的活动的数据
//作者 : 陈汝胤
//日期 : 2009-5-22
saveCampaignData=function(orderItemId,campaignId,type,usedAmount,payment,usedPrice,campaignPrice){
	var currentData;
	for(var i=0;i<orderItemCampaignArr.length;i++){
		if(orderItemCampaignArr[i].id==orderItemId){
			currentData=orderItemCampaignArr[i];
			break;
		}
	}
	currentData.id=orderItemId;
	currentData.campaignId=campaignId;
	currentData.type=type;
	currentData.usedAmount=usedAmount;
	currentData.payment=payment;
	currentData.isUsed=1;
	currentData.usedPrice=usedPrice;
	currentData.campaignPrice=campaignPrice;
	
	//$("#txtReceivableMoney").val(amountReceivableMoney());
	realMoneyChange();
}

//功能 : 清理当前订单明细使用优惠活动的情况
//作者 : 陈汝胤
//日期 : 2009-5-25
clearOrderItemCampaign=function(orderItemId){
	$("#divShowCampaign").html('<tr></tr>');
	for(var i=0;i<orderItemCampaignArr.length;i++){
		if(orderItemCampaignArr[i].isUsed){
			if(orderItemId){
				if(orderItemCampaignArr[i].id!=orderItemId)
					continue;
			}
			var memoryOrderItemId=orderItemCampaignArr[i].id;
			var currentCampaign;
			//送印章活动
			if(orderItemCampaignArr[i].type){
				for(var j=0;j<campaignData.MemberCardConcessionList.length;j++){
					if(campaignData.MemberCardConcessionList[j].Id==orderItemCampaignArr[i].campaignId){
						currentCampaign=campaignData.MemberCardConcessionList[j];
						break;
					}
				}
				if(currentCampaign){
					currentCampaign.RestPaperCount+=parseInt(orderItemCampaignArr[i].usedAmount);
				}
				else{
					alert('送印章活动不存在.');
				}
				
			}
			else{
				for(var j=0;j<campaignData.MemberCardDiscountConcessionList.length;j++){
					if(campaignData.MemberCardDiscountConcessionList[j].Id==orderItemCampaignArr[i].campaignId){
						currentCampaign=campaignData.MemberCardDiscountConcessionList[j];
						break;
					}
				}
				if(currentCampaign){
					currentCampaign.RestAmount=fltAdd(currentCampaign.RestAmount,orderItemCampaignArr[i].usedPrice);
				}
				else{
					alert('打折活动不存在.');
				}
			}
			orderItemCampaignArr[i].isUsed=0;
			orderItemCampaignArr[i].payment=orderItemCampaignArr[i].allPrice;
			$("#campaignInfoCount"+memoryOrderItemId).html('0');
			$("#campaignInfoPayment"+memoryOrderItemId).html(orderItemCampaignArr[i].allPrice);
			//$("#txtReceivableMoney").val(amountReceivableMoney());
			realMoneyChange();
			if(orderItemId)
				break;
			else
				continue;
		}
	}
}

//功能 : 订单参加活动后的保存
//作者 : 陈汝胤
//日期 : 2009-5-25
amountReceivableMoney=function(){
	var receivableMoney=0;
	for(var i=0;i<orderItemCampaignArr.length;i++){
		receivableMoney=fltAdd(orderItemCampaignArr[i].payment,receivableMoney);
	}
	return receivableMoney;
}

//功能 : 获取活动的数据
//作者 : 陈汝胤
//日期 : 2009-5-25
getCampaignData=function(){
	var val='';
	for(var i=0;i<orderItemCampaignArr.length;i++){
		var o=orderItemCampaignArr[i];
		var oVal='';
		if(o.isUsed){
			oVal+='OrderItemId:'+o.id;
			oVal+=',CampaignId:'+o.campaignId;
			oVal+=',UsedAmount:'+o.usedAmount;
			oVal+=',Type:'+o.type;
			oVal+=',Payment:'+o.payment;
			oVal+=',ItemPrice:'+o.itemPrice;
			oVal+=',CampaignPrice:'+o.campaignPrice;
			oVal+=',orderItemAllPrice:'+o.allPrice;
			val+=val==''?oVal:'|'+oVal;
		}
	}
	return val;
}

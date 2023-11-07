// JScript 文件
// 名    称: todayOrder.js
// 功能概要: 本日工单 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 

var rVal=null;


$().ready(function(){
    	$("input:button[@value=过滤]").click(showFilterCondition);
        stakeoutTodayOrderDate(); 
   	    setInterval("refresh()",50)//100);

});
//监控订单时间快到期提示
//Author:Cry Date:2008-12-27 
stakeoutTodayOrderDate=function(){

    //alert(rVal);

    var provider = {};
    provider.process = function(date) {
        contrast(date);
    };
    $.getJSON("../ajax/AjaxEngine.aspx", {a : '20'},provider.process);
}


contrast=function(date){
    if(typeof date=='string'){
        var deliverydate=$("td[@name=deliverydate]");
        for(var i=0;i<deliverydate.length;i++){
            var selfDate=$(deliverydate[i]).html();
            if(selfDate=='-') continue;
            time=minuteDifference(selfDate,date);
            var trObj=$(deliverydate[i]).parent();
            if(0==time){
                try{
                    $(trObj[0]).css("background","#5D95A6");
                }catch(ex){}
            }
            else if(60*30*1000>time){
                try{
                    $(trObj[0]).css("background","#ED7A1F");
                }catch(ex){}
            }
        }
    }
    timeOut=setTimeout("stakeoutTodayOrderDate()",10*1000);
}



function refresh()
{
  try{
        if(rVal)
        {
            window.location.reload();
            rVal=false;
        }
    }
    catch(e)
    {
        alert(e);
    }
}



var isCompositor=false;
//排序类
orderClass=function(value,html){
    this.value=value;
    this.html=html;
}
modifyOrderId=function(){
    var orderid=$("td[@name=orderid]");
    for(var i=0;i<orderid.length;i++){
        $(orderid[i]).html(i+1);
    }
}
//订单号排序
orderNoCompositor=function(){
    isCompositor=isCompositor?false:true;
    var no=$("input:hidden[@name=myOrderNo]");
    var table;
    var orderArr=new Array();
    for(var i=0;i<no.length;i++){
        if(!table) table=$($($(no[i]).parent()).parent()).parent();
        var noValue=no[i].value;
        noValue=noValue.substring(noValue.length-7,noValue.length);
        orderArr.push(new orderClass(noValue,$($(no[i]).parent()).parent()[0].outerHTML));
        $($(no[i]).parent()).parent().remove();
    }
    //排序
    for(var i=0;i<orderArr.length;i++){
        var j=i+1;
        for(;j<orderArr.length;j++){
            if(isCompositor){
                if(orderArr[i].value>orderArr[j].value){
                    var tempObj=orderArr[j];
                    orderArr[j]=orderArr[i]
                    orderArr[i]=tempObj;
                }
            }
            else{
                if(orderArr[i].value<orderArr[j].value){
                    var tempObj=orderArr[j];
                    orderArr[j]=orderArr[i]
                    orderArr[i]=tempObj;
                }
            }
        }
    }
    for(var i=0;i<orderArr.length;i++){
        $(table).append(orderArr[i].html);
    }
    //重新顺序
    modifyOrderId();
}
//开单时间排序
inertDateTimeCompositor=function(){
    isCompositor=isCompositor?false:true;
    var no=$("td[@name=inserDateTime]");
    var table;
    var orderArr=new Array();
    for(var i=0;i<no.length;i++){
        if(!table) table=$($(no[i]).parent()).parent();
        var noValue=no[i].innerHTML;
        orderArr.push(new orderClass(noValue,$(no[i]).parent()[0].outerHTML));
        $($(no[i]).parent()).remove();
    }
    //排序
    for(var i=0;i<orderArr.length;i++){
        var j=i+1;
        for(;j<orderArr.length;j++){
            if(isCompositor){
                if(CompareDate(orderArr[i].value,orderArr[j].value)){
                    var tempObj=orderArr[j];
                    orderArr[j]=orderArr[i]
                    orderArr[i]=tempObj;
                }
            }
            else{
                if(!CompareDate(orderArr[i].value,orderArr[j].value)){
                    var tempObj=orderArr[j];
                    orderArr[j]=orderArr[i]
                    orderArr[i]=tempObj;
                }
            }
        }
    }
    for(var i=0;i<orderArr.length;i++){
        $(table).append(orderArr[i].html);
    }
    //重新顺序
    modifyOrderId();
}
//送货时间排序
deliveryDateTimeCompositor=function(){
    isCompositor=isCompositor?false:true;
    var no=$("td[@name=deliverydate]");
    var table;
    var orderArr=new Array();
    for(var i=0;i<no.length;i++){
        if(!table) table=$($(no[i]).parent()).parent();
        var noValue=no[i].innerHTML;
        orderArr.push(new orderClass(noValue,$(no[i]).parent()[0].outerHTML));
        $($(no[i]).parent()).remove();
    }
    //排序
    for(var i=0;i<orderArr.length;i++){
        var j=i+1;
        for(;j<orderArr.length;j++){
            var value1='-'==orderArr[i].value?'0000-00-00 00:00':orderArr[i].value;
            var value2='-'==orderArr[j].value?'0000-00-00 00:00':orderArr[j].value;
            if(isCompositor){
                if(CompareDate(value1,value2)){
                    var tempObj=orderArr[j];
                    orderArr[j]=orderArr[i]
                    orderArr[i]=tempObj;
                }
            }
            else{
                if(!CompareDate(value1,value2)){
                    var tempObj=orderArr[j];
                    orderArr[j]=orderArr[i]
                    orderArr[i]=tempObj;
                }
            }
        }
    }
    for(var i=0;i<orderArr.length;i++){
        $(table).append(orderArr[i].html);
    }
    //重新顺序
    modifyOrderId();
}
//状态排序
statusCompositor=function(){
    isCompositor=isCompositor?false:true;
    var no=$("td[@name=orderStatus]");
    var table;
    var orderArr=new Array();
    for(var i=0;i<no.length;i++){
        if(!table) table=$($(no[i]).parent()).parent();
        var noValue=no[i].innerHTML;
        orderArr.push(new orderClass(noValue,$(no[i]).parent()[0].outerHTML));
        $($(no[i]).parent()).remove();
    }
    //排序
    for(var i=0;i<orderArr.length;i++){
        var j=i+1;
        for(;j<orderArr.length;j++){
            var value1=CompareOrderStatus(orderArr[i].value);
            var value2=CompareOrderStatus(orderArr[j].value);
            if(isCompositor){
                if(value1>value2){
                    var tempObj=orderArr[j];
                    orderArr[j]=orderArr[i]
                    orderArr[i]=tempObj;
                }
            }
            else{
                if(value1<value2){
                    var tempObj=orderArr[j];
                    orderArr[j]=orderArr[i]
                    orderArr[i]=tempObj;
                }
            }
        }
    }
    for(var i=0;i<orderArr.length;i++){
        $(table).append(orderArr[i].html);
    }
    //重新顺序
    modifyOrderId();
}
//订单状态的对比方法;
CompareOrderStatus=function(status){
    status=status.substring(status.indexOf('>')+1,status.indexOf('</'));
    var value=0;
    switch(status){
        case "未预付" :
            value=1;
            break;
        case "未分配" :
            value=2;
            break;
        case "制作中" :
            value=3;
            break;
        case "已完工" :
            value=4;
            break;
        case "已完成" :
            value=5;
            break;
        case "已作废" :
            value=6;
            break;
        case "送货中" :
            value=7;
            break;
        case "已送出" :
            value=8;
            break;
        case "已拼版" :
            value=9;
            break;
        case "已登记" :
            value=10;
            break;
    }
    return value;
}
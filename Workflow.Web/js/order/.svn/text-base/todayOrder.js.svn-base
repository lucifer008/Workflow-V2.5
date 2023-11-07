// JScript 文件
// 名    称: todayOrder.js
// 功能概要: 本日订单 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 

var rVal=null;
$().ready(function(){
    	$("input:button[@value=过滤]").click(showFilterCondition);
        stakeoutTodayOrderDate(); 
   	    setInterval("refresh()",50);
   	    setInterval("setTimeRefresh()",40000);

});
//监控订单时间快到期提示
//Author:Cry Date:2008-12-27 
stakeoutTodayOrderDate=function(){
    var provider = {};
    provider.process = function(date) {
        contrast(date);
    };
    //获取服务器端的当前时间
    $.getJSON("../ajax/AjaxEngine.aspx", {a : '20'},provider.process);
}


//功能:跟踪订单是否已超时，及设置超时与快到期订单的颜色
//作者:
//日期:
contrast=function(date){
        var orderStatusArr=$("td[@name=orderid]");
        for(var i=0;i<orderStatusArr.length;i++){
            var oStatus=$("input:hidden[@name=orderStatus]",$(orderStatusArr[i])).val();
            if(oStatus!=orderStatusSucessed && oStatus!=orderStatusBlankout){//未完成且未作废的订单
                var inserOrderDateTime=$("input:hidden[@name=orInsertDateTime]",$("td[@name=inserDateTime]",$(orderStatusArr[i]).parent())).val();
                var nowServerDateTime=date.InsertDateTimeString;
                var timeoutCount=date.Status;//超时时间
                if(parseFloat(matureTime)>parseFloat(timeoutCount)) matureTime=0;
                var timeDiff=minuteDifference(inserOrderDateTime,nowServerDateTime);
                if(null!=timeDiff){
                    var tds=$("td",$(orderStatusArr[i]).parent())
                    if(timeoutCount*60*60*1000>timeDiff && timeDiff>(parseFloat(timeoutCount)-parseFloat(matureTime))*60*60*1000){//timeoutCount*60*60*1000>timeDiff && 2.5*60*60*1000<timeDiff){//快到期
                        try{
                            $(tds[0]).css("background",matureColor);
                        }catch(ex){}
                    }
                    else if(parseFloat(timeDiff)>parseFloat(timeoutCount)*60*60*1000){//if(timeoutCount*60*60*1000<timeDiff){//超时
                         try{
                            $(tds[0]).css("background",overideColor);
                        }catch(ex){}
                    }
                }
            }
        }
    insertMaturenessOrder();
    timeOut=setTimeout("stakeoutTodayOrderDate()",10*1000);
}

//功能:实时插入送货到期订单
//作者:张晓林 
//Date:2009年12月3日15:21:20
function insertMaturenessOrder(){
    $.getJSON("../ajax/AjaxEngine.aspx", {a : '33'},callBack);
}
function callBack(json){
}

function refresh()
{
  try{
        if(rVal){
            //window.location.reload();
            window.location.href="TodayOrder.aspx";
            //window.navigate("TodayOrder.aspx");
            rVal=false;
        }
    }
    catch(e){
        alert(e);
    }
}
//功能:手动刷新订单列表
//作者:张晓林
//日期:2010年1月9日16:26:10
function newRefresh(){
    window.location.reload();
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

document.onkeypress=keyPress;
function keyPress()
{
    var e=window.event||arguments[0];
    if(e.ctrlKey && e.shiftKey && e.keyCode==11)
    {
        window.location.href="../LoginOut.aspx";
    }

}
function setTimeRefresh(){
     window.location.href="TodayOrder.aspx";
}
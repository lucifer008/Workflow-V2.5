// JScript 文件
//  $(document).ready(function(){
//      $("input:button[@value=选择客户]").click(showSelectCustomer);
//    });
//$(document).ready(function() {
//	$("input:button[@value=选择客户]").click(showSelectCustomer);
//});


/// JScript 文件
///名    称：arrearage
///功能概要: 应收款处理JS
///作    者: 付强
///创建时间: 
///修正履历:
///修正时间:


///名    称：doSelect
///功能概要: 根据客户名称获取欠款明细
///作    者: 付强
///创建时间: 
///修正履历:
///修正时间:
function doSelect(customerId)
{    
    var provider = {};
    provider.source1 = customerId;
    provider.process = function(json) {
        window.processJsonqq(json, provider.source1);
    };
    source=customerId;
    var url = "../ajax/AjaxEngine.aspx" + "?CustomerId=" + provider.source1;
    $.getJSON(url, {a : '10'}, provider.process);  
}
function processJsonqq(json,customerId)
{    
   //document.forms[0]["loading"].style.visibility='hidden';
    if (json.success == null || json.success) 
    {
        data=json;
    }
    else 
    {
        return;
    }
    
    $("#arrearageNum").text(data.OrderList.length);
    var sumMoney=0;
    var tb=$("#tbList");
    var trArr=$("tr",$(tb));
    for(var i=1;i<trArr.length;i++)
    {
        $(trArr[i]).remove();
    }
    $("#txtShowPayMoney").val(0);
    $("#txtConcession").val(0);
    $("#txtPayMoney").val(0);
    $("#txtArrearage").val(0);
    //var strOrdersId="";
    var preDeposits=0;
    if(data.OrderList.length<=0)
    {
        alert("该客户没有欠款!!!");
        return;
    }
    for(var i=0;i<data.OrderList.length;i++)
    {   
        var x=0;
        x=fltSub(data.OrderList[i].SumAmount,data.OrderList[i].PaidAmount);
        x=fltSub(x,data.OrderList[i].Concession);
        x=fltSub(x,data.OrderList[i].RenderUp);
        x=fltSub(x,data.OrderList[i].Zero);
        sumMoney=fltAdd(sumMoney,x);
        str="<tr class='detailRow'><td><input type='checkbox' name='isClose' value='Y'/></td><td>"+ data.OrderList[i].Id+"</td><td><a href='#' onclick='orderDetail(this);'>"+ data.OrderList[i].No +"</a><input type='hidden' name='myOrderNo' value="+ data.OrderList[i].No +" /></td><td>"+ data.OrderList[i].InsertDateTimeString +"</td><td>"+ data.OrderList[i].BalanceDateTimeString +"</td><td>"+ data.OrderList[i].SumAmount +"</td><td>"+ data.OrderList[i].Concession +"</td><td>"+ data.OrderList[i].Zero +"</td><td>"+ data.OrderList[i].RenderUp +"</td><td>"+ data.OrderList[i].PaidAmount +"</td><td  name='paidAmount'>" + x + "</td><td><input type='text' size='6' class='num' name='currentPayMoney' onblur='onLeave(this);' onfocus='onFocus(this);' value='0'/></td></tr>";
        $(str).appendTo(tb);
        //strOrdersId+=data.OrderList[i].Id+',';
    }
    $("#cbUsePreDeposits").attr("disabled",true);
    if(data.PreDeposits>0)  
    {
        $("#txtPreDeposits").val(parseFloat(data.PreDeposits).toFixed(2));
        $("#cbUsePreDeposits").attr("checked",true);
        $("#cbUsePreDeposits").attr("disabled",false);
    }
    $("#txtSumMoney").val(sumMoney)
    $("#sumMoney").text(sumMoney);
    $("#txtShowPayMoney").val(sumMoney);
    //$("#txtOrdersId").val(strOrdersId);
    onCurrentPayMoney();
}

function onFocus(o)
{
    $(o).select();
    $(o).focus();
}

function onLeave(o)
{
    //如果支付金额为0
    if($("#txtPayMoney").val()==0){
        $(o).val(0);
        return;
    }
    var txtArr=$("input[@name='currentPayMoney']");
    var paidAmountObj=$("td[@name=paidAmount]");
    var paidMoney=0;
    for(var i=0;i<txtArr.length;i++)
    {
        if(!checkOnlyNum($(txtArr[i]),false,14) || parseFloat($(txtArr[i]).val("0"))>parseFloat($(paidAmountObj[i]).html()))
            $(txtArr[i]).val("0");
        paidMoney=fltAdd(paidMoney,parseFloat($(txtArr[i]).val()));
        //paidMoney+=parseFloat($(txtArr[i]).val());
    }
    //var allmoney=parseFloat($("#txtPayMoney").val())+parseFloat($("#txtConcession").val());
    //var rest=parseFloat(allmoney)-parseFloat(paidMoney);
    var allmoney=fltAdd(parseFloat($("#txtPayMoney").val()),parseFloat($("#txtConcession").val()));
    var rest=fltSub(parseFloat(allmoney),parseFloat(paidMoney));
    //如果还有余额
    if(rest>0){
        shareAlikeMoney(txtArr,rest,o);
    }
    else{
        $("#restMoney").text(0);
    }
}

function dataCheck()
{
    if(!checkOnlyNum($("#txtConcession"),false,14))
    {
        $("#txtConcession").focus();
        $("#txtConcession").select();
        return false;
    }
    if(!checkOnlyNum($("#txtPayMoney"),false,14))
    {
        $("#txtPayMoney").focus();
        $("#txtPayMoney").select();
        return false;
    }

    var allmoney=parseFloat($("#txtPayMoney").val())+parseFloat($("#txtConcession").val());
    var showmoney=parseFloat($("#txtSumMoney").val());
    if($("#cbUsePreDeposits").attr("checked")) //如果使用预收款
    {
        allmoney=fltAdd(allmoney,$("#txtPreDeposits").val());//parseFloat(allmoney).toFixed(2)+parseFloat($("#txtPreDeposits").val()).toFixed(2);
    }
//    if (allmoney>showmoney)
//    {
//        alert("付款太多了!");
//        return false;
//    }  

    //if(parseFloat($("#txtPayMoney").val())<=0)
    if(allmoney<=0 || $("#txtPayMoney").val()<0)
    
    {
        alert('本次付款不能小于等于0!!!');
        $("#txtPayMoney").select();
        $("#txtPayMoney").focus();
        return false;
    }
    var chkArr=$("input:checkbox[@name='isClose']");
    if(chkArr.length<=0)
    {
        alert('请您选择本次付款的工单!!!');
        return false;
    }
    var txtArr=$("input:text[@name='currentPayMoney']");
    var m=0;
    var strOrdersId="";
    var strMoney="";
    for(var i=0;i<chkArr.length;i++)
    {
        if(chkArr[i].checked)
        {
            if(parseFloat($(txtArr[i]).val())<=0)
            {
                if(!checkOnlyNum($(txtArr[i]),false,14))
                {
                    return false;
                }
                alert('本次付款不能小于等于0!!!');
                $(txtArr[i]).select();
                $(txtArr[i]).focus();
                return false;
            }
            else
            {
                var txtArr=$("input[@name='currentPayMoney']");
                var paidMoney=0;
                for(var j=0;j<txtArr.length;j++)
                {
                    paidMoney+=parseFloat($(txtArr[j]).val());
                }
                //var rest=parseFloat($("#txtPayMoney").val())-paidMoney;
                var rest=parseFloat(allmoney-paidMoney).toFixed(2);//处理js浮点数不精确问题
                if(rest<0)
                {
                    alert('付款金额不足!!!');
                    return false;
                }
                  strOrdersId+=$($("td", $(txtArr[i]).parent().parent()[0])[1]).text()+',';//$(txtArr[i]).parent().parent()[0])[1]).text()+','; // $($("td",$(chkArr[i]).parent().parent())[1]).text()+',';
                  strMoney+=$(txtArr[i]).val()+',';
            }
            m++;
        }
    }
    if(m<=0)
    {
        alert('请您选择本次付款的工单!!!');
        $(chkArr[0]).focus();
        return false;
    }
    var res= confirm("确定付款?");
    if (res!=true)
      return false;

    strOrdersId=strOrdersId.substr(0,strOrdersId.length-1)
    strMoney=strMoney.substr(0,strMoney.length-1)


    $("#txtOrdersId").val(strOrdersId);
    $("#txtMoney").val(strMoney);
    return true;
}
var rePaidAmount=0;
function onCurrentPayMoney()
{
    rePaidAmount=0;
    if(!checkOnlyNum($("#txtConcession"),false,14))
    {
        $("#txtConcession").val("0");
    }
    var maxRenderUp=fltMul(renderUpMax,parseFloat($("#txtSumMoney").val()));
    var minRenderUp=fltMul(renderUpMin,parseFloat($("#txtSumMoney").val()));
    if(parseFloat($("#txtConcession").val())>maxRenderUp || parseFloat($("#txtConcession").val())<minRenderUp)
    {
       alert('折让金额超出了您的权限范围!');
       $("#txtConcession").val("0");
       $("#txtConcession").focus();
       $("#txtConcession").select();
       return 
       
    }
    if(parseFloat($("#txtSumMoney").val())<parseFloat($("#txtConcession").val()))
    {
       alert('折让金额不能大于应付金额!');
       $("#txtConcession").val("0");
       $("#txtConcession").focus();
       $("#txtConcession").select();
       return 
    }
    if(!checkOnlyNum($("#txtPayMoney"),false,14))
    {
        $("#txtPayMoney").val("0");
    }
    rePaidAmount=parseFloat($("#txtPayMoney").val())+parseFloat($("#txtConcession").val());
    $("#realUsePreDepositsAmount").val(0);
    if($("#cbUsePreDeposits").attr("checked"))//如果使用预存款
    {
        if(parseFloat($("#txtSumMoney").val())>=parseFloat($("#txtPreDeposits").val()))
        {
            rePaidAmount=fltAdd(rePaidAmount,$("#txtPreDeposits").val());
        }
        else
        {
            rePaidAmount=fltAdd(rePaidAmount,$("#txtSumMoney").val());
        }
        //rePaidAmount=fltAdd(rePaidAmount,$("#txtPreDeposits").val());
        //获取实际冲减的预存款
        var rePreDe=parseFloat($("#txtPreDeposits").val()-$("#txtSumMoney").val()).toFixed(2);
        if(rePreDe>=0)
        {
            $("#realUsePreDepositsAmount").val(fltSub($("#txtSumMoney").val(),$("#txtConcession").val()));
        }
        else
        {
            $("#realUsePreDepositsAmount").val($("#txtPreDeposits").val());//fltSub($("#txtPreDeposits").val(),$("#txtConcession").val()));
        }
    }
    $("#spPreDeposits").hide();
    if(parseFloat($("#txtSumMoney").val())<rePaidAmount)
    {
        var z=rePaidAmount;
        z=fltSub(z,fltAdd($("#txtSumMoney").val(),$("#txtConcession").val()));
        if(z>0)
        {
            $("#spPreDeposits").show();
            $("#txtSavePreDepositsAmount").val(parseFloat(z).toFixed(2));   
        }
        rePaidAmount=parseFloat($("#txtSumMoney").val()).toFixed(2);
    }
    //var rest=parseFloat($("#txtSumMoney").val())-parseFloat($("#txtPayMoney").val())-parseFloat($("#txtConcession").val());
    var rest=fltSub($("#txtSumMoney").val(),rePaidAmount);
    if(rest<0) rest=0;
    $("#txtArrearage").val(rest);
    $("#restMoney").text(rePaidAmount);//$("#txtPayMoney").val());
    reAdmeasureMoney();
    
}

//admeasure重新自动分配金额
function reAdmeasureMoney()
{
    var chkArr=$("input:checkbox[@name='isClose']");
    for(var i=0;i<chkArr.length;i++)
    {
        chkArr[i].checked=false;
    }
    
    var txtArr=$("input[@name='currentPayMoney']");
    for(var j=0;j<txtArr.length;j++)
    {
        $(txtArr[j]).val("0");
    }
    //parseFloat($("#txtPayMoney").val())+parseFloat($("#txtConcession").val())
    //
    
    //var allmoney=fltAdd($("#txtPayMoney").val(),$("#txtConcession").val());
    var allmoney=rePaidAmount;//$("#txtPayMoney").val();
    var rest=allmoney;
    for(var i=0;i<chkArr.length;i++)
    {
        if(0==rest) break;
        var needPay=parseFloat( $($("td", $(txtArr[i]).parent().parent()[0])[10]).text());
        chkArr[i].checked=true;
        if (needPay>=rest)
        {
            $(txtArr[i]).val(rest);
            rest=0;
            break;
        }
        else
        {
            $(txtArr[i]).val(needPay);
            rest=fltSub(rest,needPay);
            //rest-=needPay;
        }        
    }          
}//


///功能概要:单击预存发生的动作
///作者:张晓林
///创建时间:2009年11月10日9:38:58
///修正履历:
///修正时间:
function usePreDepositsClick()
{
    if($("#cbSavePreDeposits").attr("checked"))
    {
        $("#txtSavePreDepositsAmount").hide();
    }
    else
    {
        $("#txtSavePreDepositsAmount").show();
    }
} 
function accredit(t)
{
	return window.showModalDialog('Accredit.aspx',t,'dialogHeigth:100px;dialogWidth:260px;status:no');
}

function preferentialMoney(t)
{
    var returnValue='false';
    switch(position)
    {
        case master:
        case manager:
            returnValue='true';
            break;
        default:
            if((renderUpMax-renderUpMin)>0)
            {
                returnValue='true';
            }
            else
            {
                returnValue=accredit(t);
            }
            break;
    }     
    if(returnValue=='true')
    {
        $("#txtConcession").attr("readonly",false);
        $("#txtConcession").focus();
        $("#txtConcession").select();
    }
}

//Author:Cry    2008-12-25
document.onkeydown=inputKeyCheck;
function inputKeyCheck(e){
    var e=e|| event;
    if(e.keyCode==13){
        //---添加回车自动计算金额
        var currentPayMoneyObj=$("input:text[@name=currentPayMoney]");
        for(var i=0;i<currentPayMoneyObj.length;i++){
            if(currentPayMoneyObj[i] && document.activeElement==currentPayMoneyObj[i]){
                onLeave(currentPayMoneyObj[i]);
                return false;
            }
        }
        return false;
    }
}

//Author:Cry Date:2008-12-25
//平均分配还款
//parameter: 所有项,余额
shareAlikeMoney=function(txtArr,rest,o){
    try{
        var paidAmountObj=$("td[@name=paidAmount]");
        var chkArr=$("input:checkbox[@name='isClose']");
        var currentChk;
        var allRest=0;
        for(var i=0;i<txtArr.length;i++){
            if(txtArr[i]!=o){
                allRest=rest;
                rest=fltSub(parseFloat($(paidAmountObj[i]).html()),parseFloat($(txtArr[i]).val()));
                rest=fltSub(allRest,rest);
                //rest-=(parseFloat($(paidAmountObj[i]).html())-parseFloat($(txtArr[i]).val()));
                if(rest<0){
                    $(txtArr[i]).val(allRest);
                    break;
                }
                else{
                    $(txtArr[i]).val(parseFloat($(paidAmountObj[i]).html()));
                    chkArr[i].checked=true;
                }
            }
            else{
                currentChk=chkArr[i];
            }
            if("0"==$(txtArr[i]).val()){
                chkArr[i].checked=false;
            }
        }
        if(rest>0){
            $(o).val(fltAdd(parseFloat($(o).val()),parseFloat(rest)));
            if(currentChk){
                currentChk.checked=true;
            }
        }
        $("#restMoney").text(0);
    }
    catch(ex)
    {
        alert(ex);
    }
}


function printArrearage()
{
    window.print();
}




var CustomerId;

///返回
function selectCustomer(objCustomer)
{    
    if(objCustomer==null) return;
    $("#txtCustomerId").attr("value",objCustomer.Id);
    $("#customerid").attr("value",objCustomer.Id);
    $("#txtMemberCardId").attr("value",objCustomer.MemeberCardId);
    $("#txtMemberCardNo").attr("value",objCustomer.MemberCardNo);
    $("#txtTradeId").attr("value",objCustomer.TradeId);
    $("#txtCustomerName").attr("value",objCustomer.Name);
    $("#txtName").attr("value",objCustomer.LinkMan);
    $("#telNo ").attr("value",objCustomer.TelNo);
    $("#txtMemo ").attr("value",objCustomer.Memo);
    
    $("#sCustomerName").text(objCustomer.Name);
    //$("#txtCustomerId").val(objCustomer.Id);
    CustomerId=objCustomer.Id;
    
    //doSelect(objCustomer.Id);
    window.setTimeout("getReceveableAcount()",100);
}



function getReceveableAcount()
{
//    var i= $("#customerid").val()
//    alert(CustomerId);    
    doSelect(CustomerId);
}



function getCustomerInfo(e,o)
{
//    if(13==e.keyCode)
//    {
        var memberNo=$(o).val();
        if(null==memberNo || ""==memberNo) 
        {
            //clearContent();
            return;
         }

        var url = "../ajax/AjaxEngine.aspx" + "?MemberCardNo=" + memberNo;

        $.getJSON(url, {a : '12'},CustomerInfoCallBack);
        return false;
//    }
//    else
//    {
//        return true;
//    }
    
}


function CustomerInfoCallBack(json)
{
  if (json.success == null || json.success) 
    {
        data=json;
    }
    else 
    {
        alert("您输入的卡号有误或未启用!");
        //clearContent();
        return;
    }
    if(null==data.MemberCard) 
    {
        alert("您输入的卡号有误或未启用!");
        //clearContent();    
        $("#txtMemberCardNo").focus();
        $("#txtMemberCardNo").select();

        return;
    }
    $("#txtCustomerId").attr("value",data.MemberCard.CustomerId);
    //$("#txtMemberCardId").attr("value",data.MemberCard.Id);
    $("#txtMemberCardNo").attr("value",data.MemberCard.MemberCardNo);
    //$("#txtTradeId").attr("value",data.MemberCard.TradeId);
    $("#txtCustomerName").attr("value",data.MemberCard.CustomerName);
    //$("#txtName").attr("value",data.MemberCard.LinkManName);
    //$("#telNo").attr("value",data.MemberCard.TelNo);
    //$("#txtMemo").attr("value",data.MemberCard.CustomerMemo);
    //$("#ckNeedTicket").attr("checked",false);
    
    var obj=new Object();
    obj.Id=data.MemberCard.CustomerId;
    obj.MemberCardNo=data.MemberCard.MemberCardNo;
    obj.Name=data.MemberCard.CustomerName;
    selectCustomer(obj);
}
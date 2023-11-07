// JScript 文件
//功能概要: 修正Js
//作    者: 张晓林
//创建时间: 2009年11月17日11:17:52
//修正履历:
//修正时间:

var isCarryMoney=false;//是否进行舍入
var isOwe=false;//结算方式是否为记账
//功能: 页面属性加载  
//作者: 张晓林
//日期: 2009年11月17日
$(document).ready(function(){
 try
 {
      if(parseInt($("#cbPaymentType").val())==payType2){
            $("#txtRealMoney").attr("disabled",true);
            $("#chkCarryMoney").attr("disabled",true);
            $("#cbPreSaveMoney").attr("disabled",true);
            
            $("#rdbtN").attr("disabled",true);
            $("#rdbtF").attr("disabled",true);
            $("#rdbtY").attr("checked",true);
            onTicketClick($("#rdbtY"));
            $("#txtPaidTicket").attr("readonly",true);
            
            $("#trRealMoney").hide();
            $("#trGiveZero").hide();
            $("#lblRdbtN").hide();
            $("#lblRdbtY").hide();
            $("#lblRdbtF").hide();
            //抹零与优惠
            //$("#trZero").hide();
            //$("#trPreferent").hide();
           
            document.getElementById("trZero").style.display='none';
            document.getElementById("trPreferent").style.display='none';
        }
        
        getCustomerPayType();
        
        moneyChange();
        //默认隐藏税费
       $("#lblScot").hide();
       //document.getElementById("txtZeroMoney").attachEvent("onpropertychange",checkMoney);
       //document.getElementById("txtPreferentialMoney").attachEvent("onpropertychange",checkMoney);
 }
 catch(e){}
});


//功能: 付票方式改变响应事件处理程序
//作者: 张晓林
//日期: 2009年11月17日 
function onTicketClick(o)
{
    if($('#rdbtY').attr("checked"))
    {
        $('#sown').show();
        $('#spay').hide();
        $('#txtPayTicketMoney').val('0');
        $('#txtPayTicketMoney').hide();
        $('#txtPaidTicket').show();
        $('#txtOweMoney').show();
        $('#txtOweMoney').focus();
        $('#txtOweMoney').select();
    }
    else if($('#rdbtN').attr("checked"))
    {
        $('#sown').hide();
        $('#spay').show();
        $('#txtOweMoney').val('0');
        $('#txtOweMoney').hide();
        $('#txtPaidTicket').hide();
        $('#txtPaidTicket').val('0');
        $('#txtPayTicketMoney').show();
        $('#txtPayTicketMoney').focus();
        $('#txtPayTicketMoney').select();
    }
    else
    {
        $('#sown').hide();
        $('#spay').hide();
        $('#txtOweMoney').val('0');
        $('#txtOweMoney').hide();
        $('#txtPaidTicket').hide();
        $('#txtPaidTicket').val('0');
        $('#txtPayTicketMoney').val('0');
        $('#txtPayTicketMoney').hide();
        $("#lblScot").hide();
    }
    
}


//功能: 付款方式改变响应事件处理程序
//作者: 张晓林
//日期: 2009年11月17日
function getCustomerPayType()
{
    $("#txtZeroMoney").val("0");
    $("#txtPreferentialMoney").val("0");
    $("#txtZeroMoney").attr("readonly",true);
    $("#txtPreferentialMoney").attr("readonly",true);
    moneyChange();
    var customerId=$("#txtCustomerId").val();
    var url = "../ajax/AjaxEngine.aspx" + "?CustomerId=" + customerId;
    $.getJSON(url, {a : '15'},onPayTypeChange);
}
function onPayTypeChange(json)
{
    if (json.success == null || json.success){
        data=json;
    }
    else {
        return;
    }  
    var tb=$("#cbPaymentType");
    if($("tr[@name='trAcc']",$(tb).parent().parent().parent()).length>0)
    {
        $($("tr[@name='trAcc']",$(tb).parent().parent().parent())[0]).remove();
    }
    
    if(parseInt($("#cbPaymentType").val())==payType2)
    {
        if(data.Customer.PayType==payType2)
        {
        
            $("<tr name='trAcc'><td  nowrap class='item_caption'>挂账:</td><td colspan='3' class='item_content'><input id='txtAcc' name='AccountMoney'  type='text' readonly='true' class='num'  value='0' /></td></tr>").insertAfter("#trPreferent");
             var acc=fltSub($("#txtReceivableMoney").val(),$("#txtRealMoney").val());
            if(acc>=0)
            {
                $("#txtAcc").val(acc);
            }
            $("#txtRealMoney").val(0);
            $("#chkCarryMoney").attr("checked",false);
            $("#txtRealMoney").attr("disabled",true);
            $("#chkCarryMoney").attr("disabled",true);
            $("#cbPreSaveMoney").attr("disabled",true);
            $("#cbPreSaveMoney").attr("checked",false);
            
            //记账时只能欠票
            $("#rdbtN").attr("disabled",true);
            $("#rdbtF").attr("disabled",true);
            $("#rdbtY").attr("checked",true);
            onTicketClick($("#rdbtY"));
            $("#txtPaidTicket").attr("readonly",true);
            $("#lblRdbtN").hide();
            $("#lblRdbtY").hide();
            $("#lblRdbtF").hide();
            
            $("#trGiveZero").hide();
            $("#trRealMoney").hide();
            
            //抹零与优惠
//            $("#trZero").hide();
//            $("#trPreferent").hide();
//            
            document.getElementById("trZero").style.display='none';
            document.getElementById("trPreferent").style.display='none';
              $("#txtZeroMoney").attr("readonly",true);
              $("#txtPreferentialMoney").attr("readonly",true);
            isOwe=true;    
        }
        else
        {
            isOwe=false;
            alert("该客户不是记账客户,不能记账!");
            $("#cbPaymentType").attr("value",payType1)
        }
    }
    else
    {
        $("#txtRealMoney").attr("disabled",false);
        $("#chkCarryMoney").attr("disabled",false);
        $("#cbPreSaveMoney").attr("disabled",false);
        
        $("#rdbtN").attr("disabled",false);
        $("#rdbtF").attr("disabled",false);
        $("#txtPaidTicket").show();
        $("#txtPaidTicket").attr("readonly",false);
        
        $("#lblRdbtN").show();
        $("#lblRdbtY").show();
        $("#lblRdbtF").show();
        $("#trGiveZero").show();        
        $("#trRealMoney").show();
        //抹零与优惠
        $("#trZero").show();
        $("#trPreferent").show();
        isOwe=false;
    }
    caluScotAmount();
}

/// 名    称:onkeydown
/// 功能概要:控制Esc建退出弹出窗体，回车提交
/// 作    者:张晓林
/// 创建时间:2009年11月3日13:16:06
/// 修正履历:
/// 修正时间:
document.onkeydown=function()
{
    //Esc建退出
	var evt=window.event || arguments[0];
    var element=evt.srcElement || evt.target;
	if (evt.keyCode==27)	
	{
		window.close();
	}
	//回车提交
    if(13==evt.keyCode){
        if("btnClose"!=element.id){
            $("#btnOK").click();
            return false;
        }
    }
}


//功能: 优惠金额改变响应事件处理程序
//作者: 张晓林
//日期: 2009年11月17日
function preferentialMoney(t)
{
     if(isOwe){
        alert("记账时不能优惠!");
        $("#txtPreferentialMoney").attr("readonly",true);
        return;
    }
    var returnValue='false';
     switch(position)
    {
        case master:
        case manager:
            returnValue='true';
            break;
        default:
            if(renderUpMax>0)
            {
                returnValue='true';
            }
            else
            {
                returnValue=accredit(zeroAccreditTypeKey,zeroAccreditTypeText,zeroAccreditTypeId);
            }
            break;
    } 
    if(returnValue=='true')
    {
        $("#txtPreferentialMoney").attr("readonly",false);
        $("#txtPreferentialMoney").focus();
        $("#txtPreferentialMoney").select();
    }
}


//功能: 是否能进行抹零权限验证
//作者: 张晓林
//日期: 2009年11月17日
function rasureTrail(t)
{
     if(isOwe){
        alert("记账时不能抹零!");
        $("#txtZeroMoney").attr("readonly",true);
        return;
    }
    var returnValue='false';
    switch(position)
    {
        case master:
        case manager:
            returnValue='true';
            break;
        default:
            if(concessionMax>0)
            {
                returnValue='true';
            }
            else
            {
                returnValue=accredit(zeroAccreditTypeKey,zeroAccreditTypeText,zeroAccreditTypeId);
            }
            break;
        
    }   
    if(returnValue=='true')
    {
        $("#txtZeroMoney").attr("readonly",false);
        $("#txtZeroMoney").focus();
        $("#txtZeroMoney").select();
    }
}


//功能: 修正响应事件处理程序
//作者: 张晓林
//日期: 2009年11月17日
function btnOkClick()
{  
    caluScotAmount();
    moneyChange();
    var realAmount=parseFloat($("#txtRealMoney").val()).toFixed(2);//实际收款金额
    var receivable=parseFloat($("#txtReceivableMoney").val()).toFixed(2);//实际应收金额
    if(realAmount<0)
    {
        alert("实收金额不能小于0!");
        $("#txtRealMoney").val(0);
        $("#txtRealMoney").select();
        $("#txtRealMoney").focus();
        return;
    }
    //结款方式为:现金
    $("#divGatheringInfo").show();
    var scotAmount=parseFloat($("#txtScotAmount").val());
    var reMoney=parseFloat($("#txtRealMoney").val());
    var accMoney=parseFloat($("#txtReceivableMoney").val());
    if(isNaN(scotAmount)) scotAmount=0;
    if(isNaN(reMoney)) reMoney=0;
    if(isNaN(accMoney)) accMoney=0;
    $("#tdAccountAmount").html(fltAdd(accMoney,scotAmount));
    $("#tdPreAmountDiff").html($("#realPrePayAmount").val());
    $("#tdZeroAmount").html($("#txtZeroMoney").val());
    $("#tdConcessionAmount").html($("#txtPreferentialMoney").val());
    if($("#cbPaymentType").val()!=payType1) $("#tdAccCo").html("本次记账金额");
    else $("#tdAccCo").html("本次应收金额");
    if(payType1==$("#cbPaymentType").val())
    {
         var rs=fltSub(reMoney,accMoney);
         rs=fltSub(rs,scotAmount);
        if(!isCarryMoney)
        {
            if(rs<0)
            {
                alert("您输入的金额不足!");
                $("#txtRealMoney").select();
                $("#txtRealMoney").focus();
                return false;      
            }
        }
       else
       {
            if(rs>1 || rs<-1)
            {
                alert("舍入金额超出范围!");
                $("#txtRealMoney").select();
                $("#txtRealMoney").focus();
                return false;      
            }
       }
    }
    var objTicket=$("input:radio[@name=ticket]");
    for(var i=0;i<objTicket.length;i++)
    {
        if($(objTicket[i]).attr("checked"))
        {
            if($(objTicket[i]).attr("value")=="N")//不欠发票
            {
                if(!checkOnlyNum($("#txtPayTicketMoney"),false,14))
                {
                    $("#txtPayTicketMoney").focus();
                    $("#txtPayTicketMoney").select();
                    return false;
                }                
                if(parseFloat($("#txtPayTicketMoney").val())<=0.001)
                {
                    alert('发票金额不能小于等于0!');
                    $('#txtPayTicketMoney').focus();
                    $('#txtPayTicketMoney').select();
                    return false;
                }
                else if(!isCarryMoney)
                {
                    if(parseFloat($("#txtPayTicketMoney").val())>parseFloat($("#txtHiddenSumMoney").val()) && !isUseScot)
                    {
                        alert('发票金额不能大于总计金额!');
                        $('#txtPayTicketMoney').focus();
                        $('#txtPayTicketMoney').select();
                        return false;
                    }
                }
                if(fltSub($("#txtPayTicketMoney").val(),$("#txtHiddenSumMoney").val())>1 && !isUseScot)
                {
                    alert('多开的发票金额不能大于 1 元!');
                    $('#txtPayTicketMoney').focus();
                    $('#txtPayTicketMoney').select();
                    return false;
              
                }
            }
            else if($(objTicket[i]).attr("value")=="Y")//欠发票
            {
                if(!checkOnlyNum($("#txtOweMoney"),false,14))
                {
                    $("#txtOweMoney").focus();
                    $("#txtOweMoney").select();
                    return false;
                }                
                if(parseFloat($("#txtOweMoney").val())<=0.001)
                {
                    alert('欠票金额不能小于等于0!');
                    $('#txtOweMoney').focus();
                    $('#txtOweMoney').select();
                    return false;
                }
                else if(!isCarryMoney)
                {
                    if(parseFloat($("#txtOweMoney").val())>parseFloat($("#txtHiddenSumMoney").val())  && !isUseScot)
                    {
                        alert('欠票金额不能大于总计金额!');
                        $('#txtOweMoney').focus();
                        $('#txtOweMoney').select();
                        return false;
                    }
                }
                
                if(fltSub($("#txtOweMoney").val(),$("#txtHiddenSumMoney").val())>1  && !isUseScot)
                {
                    alert('多开的发票金额不能大于 1 元!');
                    $('#txtOweMoney').focus();
                    $('#txtOweMoney').select();
                    return false;
                }
                
                var rval=fltAdd($('#txtOweMoney').val(),$('#txtPaidTicket').val());
                rval=fltSub(rval,$('#txtReceivableMoney').val());
                if($('#txtPrepayMoney').val()>0 && $('#isUsePrepay').attr('checked'))
                {
                    rval=Math.abs(fltSub(rval,$("#realPrePayAmount").val())); //$('#txtPrepayMoney').val()));处理预收款大于订单金额的情况
                }
                if(rval>1  && !isUseScot)
                {
                    alert('欠票金额与付票金额之和不能大于 实付金额!');
                    $('#txtOweMoney').focus();
                    $('#txtOweMoney').select();
                    return false;
                }
            }
        }
    }
    var res= confirm("确定修正?");
    if (!res)
    {
        return false;
    }
    $("#txtSubTag").val(1);
    $("#btnOK").attr("disabled",true);
    $("#form1").submit();
    return true;
}

//功能: 金额改变响应事件及其他更改响应处理程序
//作者: 张晓林
//日期: 2009年11月17日
var allPaidAmount=0;
function moneyChange()
{
    allPaidAmount=0;
    var reAmount=0;
    var receivableAmount=0;
    var realAmount=parseFloat($("#txtRealMoney").val());
    var preAmount=parseFloat($("#txtPrepayMoney").val());
    var sumAmount=parseFloat($("#txtHiddenSumMoney").val());
    var rasureZeroAmount=parseFloat($("#txtZeroMoney").val());
    var preferentialAmount=parseFloat($("#txtPreferentialMoney").val());
    if(rasureZeroAmount>=sumAmount)
    {
        alert("抹零金额不能大于订单总金额!");
        $("#txtZeroMoney").val(0);
        return;
    }
    if(preferentialAmount>=sumAmount)
    {
        alert("优惠金额不能大于订单总金额!");
        $("#txtPreferentialMoney").val(0);
        return;
    }
    allPaidAmount=fltAdd(rasureZeroAmount,preferentialAmount);
    allPaidAmount=fltAdd(allPaidAmount,realAmount);
    allPaidAmount=fltAdd(allPaidAmount,getDiffPreMoney());
    receivableAmount=fltSub(sumAmount,(rasureZeroAmount+preferentialAmount)); 
    receivableAmount=fltSub(receivableAmount,getDiffPreMoney());   
    $("#realPrePayAmount").val(getDiffPreMoney());//实际冲减的预收款
    if(receivableAmount>=0)
    {
        $("#txtReceivableMoney").val(parseFloat(receivableAmount).toFixed(2));
        $("#txtAcc").val(receivableAmount);//挂账
        reAmount=receivableAmount;
    }
    else if(receivableAmount<0)
    {
        $("#txtReceivableMoney").val(0); 
        $("#txtAcc").val(0);//挂账
        reAmount=0;
        receivableAmount=0;
    }
    // 计算实际收款金额
    $("#txtRealAmount").val(0);
    $("#giveBack").text("");  
    var scotAmount=parseFloat($("#txtScotAmount").val());
    if(isNaN(scotAmount)) scotAmount=0;  
    if(isCarryMoney)
    {
        $("#txtRealAmount").val(fltSub(parseFloat($("#txtRealMoney").val()),scotAmount));
        $("#giveBack").val("");
    }
    else
    {
        $("#txtRealAmount").val(reAmount);
        var z=fltSub($("#txtRealMoney").val(),receivableAmount);
        if(parseFloat(z)>=0)
        {
            $("#giveBack").text(z);    
        }
        else//支付方式为记账时:实际收款为0
        {
            $("#txtRealAmount").val(0);
        }
    }
    caluScotAmount();
}

//功能: 舍入响应事件处理程序
//作者: 张晓林
//日期: 2009年11月17日
function onCarryMoneyClick()
{
    if($("#chkCarryMoney").attr("checked"))
    {
        isCarryMoney=true;
    }
    else
    {
        isCarryMoney=false;
    }
    moneyChange();
}

//功能: 获取授权用户的优惠信息
//作者: 张晓林
//日期: 2009年11月17日
function accredit(t1,t2,t3)
{
     var url="../finance/Accredit.aspx?AccreditTypeKey="+escape(t1)+"&AccreditTypeText="+escape(t2)+"&AccreditTypeId="+escape(t3)+"&IsCallBack=True";
     return window.showModalDialog(url,window,'dialogHeigth:200px;dialogWidth:280px;status:no');
}
var accZeroMax=0,accConcessionMax=0,accRendupMax=0;
function setAccreditUsersInfo(o)
{
    accZeroMax=o.maxZero;
    accConcessionMax=o.maxConcession;
    accRendupMax=o.maxRendUp;
}

//功能: 计算税费(只有以现金结款时才计算税费)
//作者: 张晓林
//日期: 2009年11月17日
var isUseScot=false;
function caluScotAmount()
{
    var oweTicketAmount=parseFloat($("#txtOweMoney").val());
    var paidTicketAmount=parseFloat($("#txtPaidTicket").val());
    var sumMoney=parseFloat($("#txtHiddenSumMoney").val());
    var paidTicketMoney=parseFloat($("#txtPayTicketMoney").val());
    var allAmount=parseFloat(allPaidAmount);
    var accAmount=parseFloat($("#txtReceivableMoney").val());
    scotInverse=parseFloat(scotInverse);
    if(isNaN(oweTicketAmount))
    {
       oweTicketAmount=0;
    }
    if(isNaN(paidTicketAmount))
    {
        paidTicketAmount=0;
    }
    if(isNaN(paidTicketMoney))
    {
        paidTicketMoney=0;
    }
    if(isNaN(sumMoney))
    {
        sumMoney=0;
    }
    if(isNaN(scotInverse))
    {
        scotInverse=0;
    }
    if(isNaN(allAmount))
    {
        allAmount=0;
    }
    if(isNaN(accAmount))
    {
        accAmount=0;
    }
    var ticketAmount=fltAdd(oweTicketAmount,paidTicketAmount);
    ticketAmount=fltAdd(ticketAmount,paidTicketMoney);
    ticketAmount=fltSub(ticketAmount,sumMoney)
    if(1<ticketAmount)
    {
        if(parseInt($("#cbPaymentType").val())!=payType2)
        {
            $("#lblScot").show();
            ticketAmount=fltMul(ticketAmount,scotInverse);
            $("#txtScotAmount").val(parseFloat(ticketAmount).toFixed(2));
            isUseScot=true;
        }
        else
        {
            $("#lblScot").hide();
            $("#txtScotAmount").val("0");
            isUseScot=false;
        }
    }
    else
    {
        $("#lblScot").hide();
        $("#txtScotAmount").val("0");
        isUseScot=false;
    }
    //重新计算预存金额
    var scotAmount=parseFloat($("#txtScotAmount").val());
    var res=fltSub(allPaidAmount,scotAmount);
    var res=fltSub(res,accAmount)
    res=fltSub(res,getDiffPreMoney());
    res=fltAdd(res,(getPreMoney()-getDiffPreMoney()));
    res=fltSub(res,getPreferentialAmount());
    res=fltSub(res,getRasureZeroAmount());
    if(res>0)
    {
        if(!isCarryMoney) $("#giveBack").text(res);
        else $("#giveBack").text(0);
    }
    else
    {
         $("#giveBack").text(0);
    }
}
//功能: 检验优惠与抹零金额是否超出当前用户的权限范围
//作者：张晓林
//日期: 2010年1月26日16:18:43
function checkMoney(){
    var sumAmount=parseFloat($("#txtHiddenSumMoney").val());
    var rasureZeroAmount=parseFloat($("#txtZeroMoney").val());
    var preferentialAmount=parseFloat($("#txtPreferentialMoney").val());
    var maxRasureZeroAmount=parseFloat(zeroMax);
    var minRasureZeroAmount=parseFloat(zeroMin)
    var maxPreferentialAmount=fltMul(sumAmount,concessionMax);
    var minPreferentialAmount=fltMul(sumAmount,concessionMin);
    var sumAmount=parseFloat($("#txtHiddenSumMoney").val());
    if(rasureZeroAmount>maxRasureZeroAmount || rasureZeroAmount<minRasureZeroAmount){
        var yes=confirm("抹零金额超出您的权限范围！是否授权抹零?");
        if(!yes){
             $("#txtZeroMoney").val(0);
             return;
        }
        else{
            var tag=accredit(zeroAccreditTypeKey,zeroAccreditTypeText,zeroAccreditTypeId);
            if(tag){
               if(rasureZeroAmount>accZeroMax){
                    alert("授权用户权限不够!");
                    $("#txtZeroMoney").val(0);
                    return;
               }   
            }
            else{
                $("#txtZeroMoney").val(0);
                return;
            }
        }
    } 
    if(preferentialAmount>maxPreferentialAmount || preferentialAmount<minPreferentialAmount){
        //alert("优惠超出权限范围!");
        var yes=confirm("优惠金额超出您的权限范围！是否授权优惠?")
        if(!yes){
            $("#txtPreferentialMoney").val(0);
            return;
        }
        else{
            var tag=accredit(concessionAccreditTypeKey,concessionAccreditTypeText,concessionAccreditTypeId);
            if(!tag){
                $("#txtPreferentialMoney").val(0);
                return;
            }
            else{
                var accMaxConAmount=fltMul(sumAmount,accConcessionMax);//授权用户最大的优惠金额
                if(preferentialAmount>accMaxConAmount){
                    alert("授权用户权限不够!");
                    $("#txtPreferentialMoney").val(0);
                    return;
                }
            }
        }
    }
}

//功能: 获取冲减的预收款
//作者：张晓林
//日期: 2010年1月26日16:18:43
getDiffPreMoney=function(){
    var diffMoney=0;
    var isUsePrepay=$("#isUsePrepay").attr("checked");
    var preAmountTotal=parseFloat($("#txtPrepayMoney").val());
    var sumAmountTotal=parseFloat($("#txtHiddenSumMoney").val());
    if(isNaN(sumAmountTotal)){
        sumAmountTotal=0;
    }
    if(isNaN(preAmountTotal)){
        preAmountTotal=0;
    }
    if(isUsePrepay){
        if(sumAmountTotal>=preAmountTotal){
            diffMoney=preAmountTotal;
        }
        else{
            diffMoney=sumAmountTotal;
        }
        var res=fltSub(sumAmountTotal,fltAdd(diffMoney,getRasureZeroAmount()));
        if(res<0){
           diffMoney=fltSub(diffMoney,getRasureZeroAmount());
        }
        res=fltSub(res,getPreferentialAmount());
        if(res<0){
            diffMoney=fltSub(diffMoney,getPreferentialAmount());
        }
    }
    return diffMoney
}
//功能: 获取抹零金额
//作者：张晓林
//日期: 2010年1月26日16:18:43
getRasureZeroAmount=function(){
    var rasureZeroAmount=parseFloat($("#txtZeroMoney").val());
    if(isNaN(rasureZeroAmount)){
        rasureZeroAmount=0;
    }
    return rasureZeroAmount;
}

//功能: 获取优惠金额
//作者：张晓林
//日期: 2010年1月26日16:18:43
getPreferentialAmount=function(){
     var preferentialAmount=parseFloat($("#txtPreferentialMoney").val());
     if(isNaN(preferentialAmount)){
        preferentialAmount=0;
     }
     return preferentialAmount;
}
//功能: 获取预收款金额
//作者: 张晓林
//日期: 2010年1月27日10:28:40
getPreMoney=function(){
     var preAmountTotal=parseFloat($("#txtPrepayMoney").val());
     if(isNaN(preAmountTotal)){
        preAmountTotal=0;
     }
     return preAmountTotal;
}

//var Class={
//    create:function(){
//        return function(){
//          this.initialize.apply(this,arguments);  
//        };
//    }
//}
//var Customer=Class.create();
//Customer.prototype={
//    initialize:function(){
//        this.realAmount=parseFloat($("#txtRealMoney").val());//实收金额
//        this.isNotCarray=$("#chkCarryMoney").attr("checked");//是否输入
//        this.preAmount=parseFloat($("#txtPrepayMoney").val());//预收金额
//        this.sumAmount=parseFloat($("#txtHiddenSumMoney").val());//订单总金额
//        this.isNotDiffPreAmount=$("#isUsePrepay").attr("checked");//是否冲减预收款 
//        this.rasureZeroAmount=parseFloat($("#txtZeroMoney").val());//抹零金额
//        this.preferentialAmount=parseFloat($("#txtPreferentialMoney").val());//优惠金额
//        if(isNaN(this.realAmount)) this.realAmount=0;
//        if(isNaN(this.preAmount)) this.preAmount=0;
//        if(isNaN(this.sumAmount)) this.sumAmount=0;
//        if(isNaN(this.rasureZeroAmount)) this.rasureZeroAmount=0;
//        if(isNaN(this.preferentialAmount)) this.preferentialAmount=0;
//    },
//    getPreRaTotal:function(){
//        return fltAdd(this.rasureZeroAmount,this.preferentialAmount);
//    }
//    ,
//    //冲减的预收金额
//    getDiffPreAmount:function(){
//        var diff=0;
//        if(this.isNotDiffPreAmount){
//            if(this.sumAmount>=this.preAmount) diff=this.preAmount;
//            else diff=this.sumAmount;
//            
//            if(this.getPreRaTotal()>0) diff=fltSub(diff,this.getPreRaTotal());
//        }
//        else{
//            diff=0;
//        }
//        if(diff<0) diff=0;
//        return diff;
//    },
//    //获取冲减后的预收款,包括不冲减预收款后的预收款 
//    getRestPreAmount:function(){
//        var res=0;
//        if(this.isNotDiffPreAmount){
//            if(this.sumAmount>=this.preAmount) res=0;         
//            else res=fltSub(this.preAmount,this.sumAmount);
//            
//            if(this.getPreRaTotal()>0) res=fltSub(res,this.getPreRaTotal())
//            if(res<0) res=0;
//            
//        }
//        else{
//            res=this.preAmount;
//        }
//        return res;
//    },
//    //获取本次付款金额(实收金额:含冲减，舍入,收的现金)
//    getCurrentPaidAmount:function(){
//       var rel=0;
//       res=fltAdd(res,this.getDiffPreAmount());
//       if(this.isNotCarray){
//          res=fltAdd(res,this.realAmount);
//       }
//       return res;
//    },
//    //获取所有收款
//    getAllPaidAmount:function(){
//        return 0;
//    }
//    ,
//    //检查收款是否成功
//    checkBalanceIsSucessed:function(){
//        var isSu=false;
//        var d=fltSub(this.getAllPaidAmount(),this.getCurrentPaidAmount());
//        if(d>0) isSu=true;
//        return isSu;
//    }
//    
//}
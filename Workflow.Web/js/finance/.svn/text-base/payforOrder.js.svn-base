// JScript 文件
//功能概要: 收银JS
//作    者：张晓林
//日    期: 2010年3月8日15:27:02
//修正履历：正在改造中.....

var isCarryMoney=false;
var isPreAmount=false;
$(document).ready(function(){
    loadPageProperty();
});

//功能: 加载页面属性
//作者: 张晓林
//日期: 2010年3月8日15:15:35
function loadPageProperty(){
    $("#lblScot").hide();
    $("#trPreDeposits").remove();
    if(payType2==parseInt($("#cbPaymentType").val())){
        $("#txtRealMoney").attr("disabled",true);
        $("#chkCarryMoney").attr("disabled",true);
        $("#cbPreSaveMoney").attr("disabled",true);
        
        $("#rdbtN").attr("disabled",true);
        $("#rdbtF").attr("disabled",true);
        $("#rdbtY").attr("checked",true);
        $("#txtPaidTicket").attr("readonly",true);
    }
}

//功能: 结算验证
//作者: 张晓林
//日期: 2010年3月8日15:15:35
function balanceCheck(){
    var customer=new Customer();
    customer.PreAmount=$("#txtPrepayMoney").val();
    customer.RealyAmount=$("#txtRealMoney").val();
    customer.ApplyZeroAmount=$("#txtZeroMoney").val();
    customer.PreferentialAmount=$("#txtPreferentialMoney").val();
    if($("#isUsePrepay").attr("checked")){
        customer.isUsePreAmount=true;
    }
    else{
        customer.isUsePreAmount=false;
    }
    
    if(payType1==$("#cbPaymentType").val()){
       customer.PayType=payType1
    }
    if(customer.RealyAmount<(customer.GetScotAmount()+customer.GetAccountAmount())){
        alert("付款金额不足");
    }
    return false;
}

//功能: 计算应收款金额
//作者: 张晓林
//日期: 2010年3月8日15:15:35
function realMoneyChange(){
    var customer=new Customer();
    customer.PreAmount=parseFloat($("#txtPrepayMoney").val());
    customer.RealyAmount=parseFloat($("#txtRealMoney").val());
    customer.ApplyZeroAmount=parseFloat($("#txtZeroMoney").val());
    customer.PreferentialAmount=parseFloat($("#txtPreferentialMoney").val());
    if($("#isUsePrepay").attr("checked")){
        customer.isUsePreAmount=true;
    }
    else{
        customer.isUsePreAmount=false;
    }
    
    if(payType1==$("#cbPaymentType").val()){
       customer.PayType=payType1
    }else{
        customer.PayType=payType2;
    }
    $("#txtReceivableMoney").val(customer.GetAccountAmount());
    if(customer.GetScotAmount()>0){
        $("#lblScot").show();
        $("#txtScotAmount").val(customer.GetScotAmount());
    }else{
        $("#lblScot").hide();
        $("#txtScotAmount").val("0");
    }
}

function rasureTrail(t){
    var returnValue='false';
     switch(position){
        case master:
        case manager:
            returnValue='true';
            break;
        default:
            if(zeroMax>0){
                returnValue='true';
            }
            else{
                returnValue=accredit(concessionAccreditTypeKey,concessionAccreditTypeText,concessionAccreditTypeId);
            }
            break;
        
    }   
    if(returnValue=='true'){
        $("#txtZeroMoney").attr("readonly",false);
        $("#txtZeroMoney").focus();
        $("#txtZeroMoney").select();
    }
}
function preferentialMoney(t){
    var returnValue='false';
     switch(position){
        case master:
        case manager:
            returnValue='true';
            break;
        default:
            if(concessionMax>0){
                returnValue='true';
            }
            else{
                returnValue=accredit(concessionAccreditTypeKey,concessionAccreditTypeText,concessionAccreditTypeId);
            }
            break;
    } 
    if(returnValue=='true'){
        $("#txtPreferentialMoney").attr("readonly",false);
        $("#txtPreferentialMoney").focus();
        $("#txtPreferentialMoney").select();
    }
}
// 功能: 控制Esc建退出弹出窗体，回车提交
// 作者: 张晓林
// 日期: 2009年11月3日13:16:06
document.onkeydown=function(event_e){
    //Esc建退出
	if (window.event) event_e=window.event;
	var int_keycode=event_e.charCode || event_e.keyCode;
	if (int_keycode==27) window.close();
	//回车提交
	var evt=window.event || arguments[0];
    var element=evt.srcElement || evt.target;
    if(13==evt.keyCode){
        if("btnClose"!=element.id){
            $("#btnOK").click();
            return false;
        }
    }
}

//功能: 获取授权用户的优惠信息
//作者: 张晓林
//日期: 2009年11月20日
function accredit(t1,t2,t3){
     var url="../finance/Accredit.aspx?AccreditTypeKey="+escape(t1)+"&AccreditTypeText="+escape(t2)+"&AccreditTypeId="+escape(t3)+"&IsCallBack=True";
     return window.showModalDialog(url,window,'dialogHeigth:200px;dialogWidth:280px;status:no');
}
var accZeroMax=0,accConcessionMax=0,accRendupMax=0;
function setAccreditUsersInfo(o){
    accZeroMax=o.maxZero;
    accConcessionMax=o.maxConcession;
    accRendupMax=o.maxRendUp;
}

//功能: 客户支付方式更改响应处理程序
//作者: 张晓林
//日期: 2010年3月12日9:29:23
function getCustomerPayType(){
    var customerId=$("#txtCustomerId").val();
    var url = "../ajax/AjaxEngine.aspx" + "?CustomerId=" + customerId;
    $.getJSON(url, {a : '15'},onPayTypeChange);
}
function onPayTypeChange(json){
    if (json.success == null || json.success) data=json;
    else return;
    var tb=$("#cbPaymentType");
    if($("tr[@name='trAcc']",$(tb).parent().parent().parent()).length>0){
        $($("tr[@name='trAcc']",$(tb).parent().parent().parent())[0]).remove();
    }
    if(payType2==parseInt($("#cbPaymentType").val())){
        if(payType2==data.Customer.PayType){
            $("<tr name='trAcc'><td  nowrap class='item_caption'>挂账:</td><td colspan='3' class='item_content'><input id='txtAcc' name='AccountMoney'  type='text' readonly='true' class='num'  value='0' /></td></tr>").insertAfter("#trPreferent");
             var acc=fltSub($("#txtReceivableMoney").val(),$("#txtRealMoney").val());
            if(acc>=0) $("#txtAcc").val(acc);
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
        }
        else{
            alert("该客户不是记账客户,不能记账!");
            $("#cbPaymentType").attr("value",payType1)
        }
    }
    else{
        $("#txtRealMoney").attr("disabled",false);
        $("#chkCarryMoney").attr("disabled",false);
        $("#cbPreSaveMoney").attr("disabled",false);
        
        $("#rdbtN").attr("disabled",false);
        $("#rdbtF").attr("disabled",false);
        $("#txtPaidTicket").show();
        $("#txtPaidTicket").attr("readonly",false);
    }
}
function onTicketClick(o){
    if($('#rdbtY').attr("checked")){
        $('#sown').show();
        $('#spay').hide();
        $('#txtPayTicketMoney').val('0');
        $('#txtPayTicketMoney').hide();
        $('#txtPaidTicket').show();
        $('#txtOweMoney').show();
        $('#txtOweMoney').focus();
        $('#txtOweMoney').select();
    }
    else if($('#rdbtN').attr("checked")){
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
    else{
        $('#sown').hide();
        $('#spay').hide();
        $('#txtOweMoney').val('0');
        $('#txtOweMoney').hide();
        $('#txtPaidTicket').hide();
        $('#txtPaidTicket').val('0');
        $('#txtPayTicketMoney').val('0');
        $('#txtPayTicketMoney').hide();
        $("#lblScot").hide();
        $("#txtScotAmount").val("0");
    }
}
//功能: 自动计算给发票金额(只有以现金结款时才计算税费)
//作者: 张晓林
//日期: 2010年2月23日9:42:23
function computeTicket()
{
    var isPaidTicket=$('#rdbtY').attr("checked");
    if(isPaidTicket){
        if(payType2!=parseInt($("#cbPaymentType").val())){
            var oweTicketAmount=parseFloat($("#txtOweMoney").val());
            var sumMoney=parseFloat($("#txtHiddenSumMoney").val());//现金总计
            var res=fltSub(sumMoney,oweTicketAmount);
            if(res>0){
                $("#txtPaidTicket").val(res);
            }
            else{
                $("#txtPaidTicket").val(0);
            }
        }
        else{
            $("#txtPaidTicket").val(0); 
        }
    }
    else{$("#txtPaidTicket").val(0);}
}

//功能：构造一个customer类
//作者: 张晓林
//日期: 2010年3月8日16:14:54
function Customer(){
    //定义公有制属性
    this.SumAmount=parseFloat($("#txtHiddenSumMoney").val());//现金总计
    this.PreAmount;//已预收
    this.ApplyZeroAmount=0;//抹零金额
    this.PreferentialAmount=0;//优惠金额
    this.AccountAmount=0;//应收款
    this.RealyAmount=0//实际收款
    this.PayType;//支付方式
    this.PaidTicketAmount=0;//付票金额
    
    this.isUsePreAmount=false;//是否使用预收金额
    this.isCarryMoney=false//是否进行舍入
    
    //功能: 获取应收金额
    //作者：张晓林
    //日期：2010年3月9日9:21:28
    this.GetAccountAmount=function(){
        var res=0;
        try{
            if(isNaN(this.SumAmount)) this.SumAmount=0;
            if(isNaN(this.PreAmount)) this.PreAmount=0;
            if(isNaN(this.ApplyZeroAmount)) this.ApplyZeroAmount=0;
            if(isNaN(this.PreferentialAmount)) this.PreferentialAmount=0;
            if(isNaN(this.RealyAmount)) this.RealyAmount=0;
            res=this.SumAmount;
            if(this.isUsePreAmount){
                if(this.SumAmount>this.PreAmount){
                    res=fltSub(this.SumAmount,this.PreAmount);
                }
            }
            if(res>this.ApplyZeroAmount){
                res=fltSub(res,this.ApplyZeroAmount);
            }
            if(res>this.PreferentialAmount){
                res=fltSub(res,this.PreferentialAmount);
            }
            if(res<0) res=0;
        }catch(e){
            alert(e);
        }
        return res;
    }
    
    //功能：获取付票金额
    //作者：张晓林
    //日期: 2010年3月9日9:25:19
    this.GetPaidAmount=function(){
        var pTicketAmount=0;
        try{
            //不欠发票
            if($("#rdbtN").attr("checked")){
                pTicketAmount=$("#txtPayTicketMoney").val();
            }
            //无需给票
            else if($("#rdbtF").attr("checked")){
                pTicketAmount=0;
            }
            //欠发票
            else if($("#rdbtY").attr("checked")){
                pTicketAmount=$("#txtPaidTicket").val();
            }
        }catch(e){
            alert(e);
        }
        return pTicketAmount;
    }
    
    //功能: 获取欠票金额
    //作者: 张晓林
    //日期: 2010年3月9日9:26:04
    this.GetOweTicketAmount=function(){
        var oTicketAmount=0;
        try{
            if($("#rdbtY").attr("checked"))
                oTicketAmount=$("#txtOweMoney").val();
            else
                oTicketAmount=0;
        }catch(e){
            alert(e);
        }
        return oTicketAmount;
    }
    
    //功能: 获取税费
    //作者：张晓林
    //日期: 2010年3月9日9:27:04
    this.GetScotAmount=function(){
        var scotAmount=0;
        var sAmount=this.SumAmount;
        var pTicketAmount=this.GetPaidAmount();
        try{
            var res=fltSub(pTicketAmount,sAmount);
            if(res>1){
                if(this.PayType!=payType2){
                    ticketAmount=fltMul(res,scotInverse);
                    scotAmount=parseFloat(ticketAmount).toFixed(2);
                }
            }
        }catch(e){
            alert(e);
        }
        return scotAmount;
    }
}
// JScript 文件
///名    称:finance
///功能概要:收银js
///作    者:
///创建时间:
///修正履历：
///修正时间:

var isCarryMoney=false;
var isPreAmount=false;
var sumTotal=0;//工单总金额
var paperCountTotal=0;//能冲减的印章数合计
var paperAmount=0;//能冲减的金额合计
var busTypeUninPrice=0;//能冲减的业务类型的单价
/*加载页面属性*/
$(document).ready(function(){
    var returnBackMoney=$('#txtReceivableMoney').val();
    if(returnBackMoney<0){
        $('#giveBack').text(Math.abs(returnBackMoney));
        $('#txtReturnMoney').val(Math.abs(returnBackMoney));
    }
    if(parseInt($("#cbPaymentType").val())==payType2){
        $("#txtRealMoney").attr("disabled",true);
        $("#chkCarryMoney").attr("disabled",true);
        $("#cbPreSaveMoney").attr("disabled",true);
    }
    
    //去掉预存款冲减 2009年11月10日17:05:36
    $("#trPreDeposits").remove();
    realMoneyChange();
});
//$(document).ready(
//function(){
//    sumTotal=parseFloat($("#txtSumMoney").val());
//    //检查是否存在匹配的优惠业务明细
//    var memberCardId=$("#hiddMemberCardId").val();
//    if(""!=memberCardId){
//        var ordersId=$("#hiddOrderId").val();
//        var url="../ajax/AjaxEngine.aspx?MemberCardId="+memberCardId+"&OrderId="+(ordersId);
//        $.getJSON(url,{a:'28'},callBackLoad);
//    }
//});
function callBackLoad(json)
{
    if(null==json || json)
    {
       data=json;
    }
    else
    {
       return;
    }
    if(json.Id>0)
    {
        //可被冲减的优惠信息
        for(var i=0;i<json.MemberCardConcessionList.length;i++)
        {
           paperCountTotal+=json.MemberCardConcessionList[i].RestPaperCount;
           paperAmount+=json.MemberCardConcessionList[i].Amount;
        }
        //可配冲减的业务信息
        for(var index=0;index<json.MemberCardBaseBusinessTypeItemList.length;index++)
        {
           busTypeUninPrice=json.MemberCardBaseBusinessTypeItemList[index].BaseBusUnitPrice;
        }
        $("#useSavePaper").attr("disabled","");//可以冲减印章数
        $("#hiddPaperCount").val(paperCountTotal);//可冲减的印章数
        $("#hiddChargeAmout").val(paperAmount);//可冲减的会员充值金额
    }
}

/*判断是否选择冲减印章数*/
function isNotSelectedDiffPaper()
{
    if($("#useSavePaper").attr("checked"))
    {
        $("#txtUseSavePaperCounter").attr("disabled","");//印章数可用
        $("#txtUseSavePaperCounter").val(0);
    }
    else
    {
        $("#txtUseSavePaperCounter").attr("disabled","true");//印章数可用
        $("#txtUseSavePaperCounter").val("0");
        $("#txtSumMoney").val(sumTotal);
        $("#txtAcc").val(sumTotal);
        $("#txtAcc").val("0");
        $("#txtPreferentialMoney").val("0");
    }
}
function paperCountChange()
{
    if($("#txtUseSavePaperCounter").val()>paperCountTotal)
    {
        alert("该会员能冲洗的印章数还剩"+paperCountTotal);
        $("#txtUseSavePaperCounter").val("");
        $("#txtUseSavePaperCounter").focus();
        return false;
    }
    if(isNaN($("#txtUseSavePaperCounter").val()) || ""==$("#txtUseSavePaperCounter").val())
    {
        $("#txtUseSavePaperCounter").val(0);
    }
    var sumDiff=parseFloat($("#txtUseSavePaperCounter").val())*parseFloat(busTypeUninPrice);//冲减金额
    $("#txtSumMoney").val(sumTotal-sumDiff);//冲减后的工单金额
    $("#txtHiddenSumMoney").val(sumTotal-sumDiff);
    $("#txtReceivableMoney").val(sumTotal-sumDiff);
    $("#txtAcc").val("0");
    $("#txtPreferentialMoney").val("0");
    $("#hiddDiffAmount").val(sumDiff);//冲减金额
}

function comulateMoney()
{
    var sumMoney=parseFloat($("#txtHiddenSumMoney").val());//现金总计
    var prepayMoney=parseFloat($("#txtPrepayMoney").val());//已预收
    var zeroMoney=parseFloat($("#txtZeroMoney").val());//摸零金额
    var accountMoney=parseFloat($("#txtAcc").val());//挂账
    var preferentialMoney=parseFloat($("#txtPreferentialMoney").val());//优惠金额
    
    if(isNaN(sumMoney))
    {
        sumMoney=0;
    }
    if(isNaN(prepayMoney))
    {
        prepayMoney=0;
    }
    if(isNaN(zeroMoney))
    {
        zeroMoney=0;
    }
    if(isNaN(accountMoney))
    {
        accountMoney=0;
    }
    if(isNaN(preferentialMoney))
    {
        preferentialMoney=0;
    }
    if(zeroMoney<zeroMin || zeroMoney>zeroMax)
    {
        alert("抹零金额超出权限范围!");
        $("#txtZeroMoney").val(0);
        $("#txtZeroMoney").focus();
        $("#txtZeroMoney").select();
        return false;
    }
    if(zeroMoney!=0 && sumMoney<zeroMoney )
    {
        alert("抹零金额不能大于总金额!");
        $("#txtZeroMoney").val(0);
        $("#txtZeroMoney").focus();
        $("#txtZeroMoney").select();
        return false;
    }
    if(preferentialMoney<fltMul(concessionMin,sumMoney) || preferentialMoney>fltMul(concessionMax,sumMoney))
    {
        alert("优惠金额超出权限范围!");
        $("#txtPreferentialMoney").val(0);
        $("#txtPreferentialMoney").focus();
        $("#txtPreferentialMoney").select();
        return false;
    }    
    if(preferentialMoney!=0 && sumMoney<preferentialMoney)
    {
        alert("优惠金额不能大于总金额!");
        $("#txtPreferentialMoney").val(0);
        $("#txtPreferentialMoney").focus();
        $("#txtPreferentialMoney").select();
        return false;
    }

    if($("#txtAcc").length<=0)
    {
        if(sumMoney<(zeroMoney+preferentialMoney))
        {
            alert("抹零金额 + 优惠金额 不能大于总金额!");
            $("#txtZeroMoney").val(0);
            $("#txtPreferentialMoney").val(0);
            $("#txtPreferentialMoney").focus();
            $("#txtPreferentialMoney").select();
            return false;
        }
    }
    else
    {
        if(sumMoney<accountMoney)
        {
            alert("记账金额不能大于总金额!");
            $("#txtAcc").val(0);
            $("#txtAcc").focus();
            $("#txtAcc").select();
            return false;
        }    
        if(sumMoney<(zeroMoney+preferentialMoney))
        {
            alert("抹零金额 + 优惠金额 不能大于总金额!");
            $("#txtZeroMoney").val(0);
            $("#txtAcc").val(0);
            $("#txtPreferentialMoney").val(0);
            $("#txtPreferentialMoney").focus();
            $("#txtPreferentialMoney").select();
            return false;
        }
    }
    var result=fltAdd(sumMoney,0);
    var obj=$("#isUsePrepay");
    if($(obj).length>0 && $(obj)[0].checked) //如果使用预收款
    {
        result=fltSub(result,prepayMoney);
    }    
    result=fltSub(result,zeroMoney);
    //result=fltSub(result,accountMoney);
    result=fltSub(result,preferentialMoney);
//    if(parseFloat(result)>=0)
//    {
        $("#txtReceivableMoney").val(result);
//    }
//    else
//    {
//        $("#txtReceivableMoney").val("0.00");
//    }
    realMoneyChange();
    
   // $("#txtRealMoney").focus();
   return true;

}

function realMoneyChange()
{
    var obj=$("#isUsePrepay");
    var sumMoney=parseFloat($("#txtHiddenSumMoney").val());//现金总计
    var preferentialMoney=parseFloat($("#txtPreferentialMoney").val());//优惠金额
    var prepay=parseFloat($("#txtPrepayMoney").val());//预收款
    var zeroMoney=parseFloat($("#txtZeroMoney").val());//抹零
    var realMoney= parseFloat($("#txtRealMoney").val())  ;//实收金额
    var accountMoney= fltSub(sumMoney,preferentialMoney);// parseFloat($("#txtAcc").val());//挂账
    accountMoney= fltSub(accountMoney,zeroMoney);
    var preDeposits=parseFloat($("#txtPreDeposits").val());//预存款
    if(isNaN(sumMoney))
    {
        sumMoney=0;
    }
    if(isNaN(preferentialMoney))
    {
        preferentialMoney=0;
    }
    if(isNaN(realMoney))
    {
        realMoney=0;
    }
    if(isNaN(prepay))
    {
        prepay=0;
    }
    if(isNaN(zeroMoney))
    {
        zeroMoney=0;
    }
    if(isNaN(accountMoney))
    {
        accountMoney=0;
    }
    if($(obj).length>0 && $(obj)[0].checked) //如果使用预收款
    {
        if(prepay>accountMoney)
        {
            $("#realPrePayAmount").val(accountMoney);//实际冲减的预收款
            accountMoney=0;
        }
        else
        {
            accountMoney=fltSub(accountMoney,prepay);
            $("#realPrePayAmount").val(prepay);
        }
    }
    
    if($("#cbIsUsePreDeposits").attr("checked"))//如果使用预存款
    {
        if(preDeposits>accountMoney && accountMoney>0)
        {
            $("#realPreDepositsAmount").val(accountMoney);//实际冲减的预存款
            accountMoney=0;
        }
        else if(preDeposits<=accountMoney && accountMoney>0)
        {
            accountMoney=fltSub(accountMoney,preDeposits);
            $("#realPreDepositsAmount").val(preDeposits);
        }
        else
        {
            accountMoney=0;
            $("#realPreDepositsAmount").val(0);
        }
    }
    
    $("#txtReceivableMoney").val(parseFloat(accountMoney).toFixed(2));// 
    accountMoney=fltSub(accountMoney,realMoney);
    if($("#txtRealMoney").val()!="")
    {
        if(!checkOnlyNum($("#txtRealMoney"),false,14))
        {
            return false;
        }
    }
    
    var result=fltAdd(realMoney,0);
    if($(obj).length>0 && $(obj)[0].checked) //如果使用预收款
    {
        result=fltAdd(fltAdd(realMoney,prepay)+result);
    }
    
    if($("#cbIsUsePreDeposits").attr("checked"))//如果使用预存款
    {
        result=fltAdd(fltAdd(realMoney,preDeposits)+result);
    }
    result=fltAdd(result,zeroMoney);
    result=fltAdd(result,preferentialMoney);
    result=fltSub(result,sumMoney);
    if(accountMoney>=0)
    {
        $("#txtAcc").val(accountMoney);
    }
    else
    {
        $("#txtAcc").val(0);
    }
    var receviAmount=$("#txtReceivableMoney").val();//冲减后的应收金额
    var realAmount=$("#txtRealMoney").val();//实收金额
    var reDiff=parseFloat(realAmount).toFixed(2)-parseFloat(receviAmount).toFixed(2);
    $("#realAmount").val(receviAmount);//实际收款金额
    $("#otherPreDepositAmount").hide();
    
    if(reDiff>=0 && receviAmount>=0)//实收金额>=应收金额
    {   
        if(!isCarryMoney)
        {
            if(!isPreAmount){
                $("#giveBack").text(FormatMoney(reDiff,2));
                $("#preDepositAmount").val(0);
            }
            else
            {
                $("#preDepositAmount").val(FormatMoney(reDiff,2));
                $("#giveBack").text(0);
            }
        }
        else
        {
            if(isPreAmount)
            {
                $("#otherPreDepositAmount").show();
                $("#preDepositAmount").val($("#otherPreDepositAmount").val());
                $("#giveBack").text(0);
                $("#realAmount").val(realAmount);//实际收款金额
            }
            else
            {
                 $("#realAmount").val(realAmount);//实际收款金额
                 $("#giveBack").text(0);
            }
        }
    }
    else //实收金额<应收金额(舍入少收情况)
    {
        var reDiff1=parseFloat(receviAmount).toFixed(2)-parseFloat(realAmount).toFixed(2);
        if(isCarryMoney && reDiff1>0 && reDiff1<1)//舍入少收
        {
            $("#giveBack").text(0);
            $("#realAmount").val(realAmount);
            if(isPreAmount)
            {
                $("#otherPreDepositAmount").show();
                $("#preDepositAmount").val($("#otherPreDepositAmount").val()); 
            } 
        }
        else
        {
            $("#giveBack").text(0);
            $("#realAmount").val(0);  
        }
    }
    
//    if(!isNaN(result))
//    {   
//        if(0<= result)
//        {
//            if(!isCarryMoney)
//            {
//                $("#txtReturnMoney").val(result);
//                if(!$("#cbPreSaveMoney").attr("checked")){
//                    $("#giveBack").text(FormatMoney(result,2));
//                }
//            }
//            else
//            {
//                $("#txtReturnMoney").val(0);
//                $("#giveBack").text(0);
//            }
//        }
//        else
//        {
//            $("#txtReturnMoney").val(0);
//            $("#giveBack").text(0);
//        }
//    }
//    else
//    {
//        $("#txtReturnMoney").val(0);
//        $("#giveBack").text("0");
//    }
}

///名    称: dataCheck
///功能概要: 工单结算数据验证
///作    者:
///创建时间:
///修正履历：
///修正时间:
function dataCheck()
{
    //$("#btnOK").attr("disabled",true);
    if(!comulateMoney())
    {
//        $("#btnOK").attr("disabled",false);
        return false;
    }
    if(!checkOnlyNum($("#txtZeroMoney"),false,14))
    {
        $("#txtZeroMoney").focus();
        $("#txtZeroMoney").select();
        //$("#btnOK").attr("disabled",false);
        return false;
    }  
    if(!checkOnlyNum($("#txtPreferentialMoney"),false,14))
    {
        $("#txtPreferentialMoney").focus();
        $("#txtPreferentialMoney").select();
        //$("#btnOK").attr("disabled",false);
        return false;
    }
  
    if(!checkOnlyNum($("#txtRealMoney"),false,14))
    {
        $("#txtRealMoney").focus();
        $("#txtRealMoney").select();
        //$("#btnOK").attr("disabled",false);
        return false;
    }
    
    //由于有预收款,实收金额可以是0
    if(""==$("#txtRealMoney").val() || 0>parseFloat($("#txtRealMoney").val()))
    {
        alert("您输入的金额有误!!!");
        $("#txtRealMoney").select();
        $("#txtRealMoney").focus();
        //$("#btnOK").attr("disabled",false);
        return false;
    }
    if($("#cbPaymentType").val()==payType1)
    {
        if(!isCarryMoney)
        {
            if(fltSub($("#txtRealMoney").val(),$("#txtReceivableMoney").val())<0)
            {
                alert("您输入的金额不足!!!");
                $("#txtRealMoney").select();
                $("#txtRealMoney").focus();
                //$("#btnOK").attr("disabled",false);
                return false;
            }
        }
        else
        {
            if($("#txtReceivableMoney").val()>=0)
            {
                if(Math.abs(fltSub($("#txtRealMoney").val(),$("#txtReceivableMoney").val()))>1)
                {
                    alert("您输入的金额不足!!!");
                    $("#txtRealMoney").select();
                    $("#txtRealMoney").focus();
                    //$("#btnOK").attr("disabled",false);
                    return false;
                }
            }
            else
            {
                if(fltSub($("#txtRealMoney").val(),Math.abs($("#txtReceivableMoney").val()))>1)
                {
                    alert("您输入的金额不足!!!");
                    $("#txtRealMoney").select();
                    $("#txtRealMoney").focus();
                    //$("#btnOK").attr("disabled",false);
                    return false;
                }
            }
        }
    }
    var objTicket=$("input:radio[@name=ticket]");
    for(var i=0;i<objTicket.length;i++)
    {
        if($(objTicket[i]).attr("checked"))
        {
            if($(objTicket[i]).attr("value")=="N")
            {
                //var ticketMoney=fltSub(parseFloat($("#txtPayTicketMoney").val()),$("#txtZeroMoney").val());
                //ticketMoney=fltSub(ticketMoney,$("#txtPreferentialMoney").val());
                

                if(!checkOnlyNum($("#txtPayTicketMoney"),false,14))
                {
                    $("#txtPayTicketMoney").focus();
                    $("#txtPayTicketMoney").select();
                    //$("#btnOK").attr("disabled",false);
                    return false;
                }                
                if(parseFloat($("#txtPayTicketMoney").val())<=0.001)
                {
                    alert('发票金额不能小于等于0!');
                    $('#txtPayTicketMoney').focus();
                    $('#txtPayTicketMoney').select();
                    //$("#btnOK").attr("disabled",false);
                    return false;
                }
                else if(!isCarryMoney)
                {
                    //if(parseFloat($("#txtPayTicketMoney").val())>parseFloat($("#txtHiddenSumMoney").val()))
                    if(parseFloat($("#txtPayTicketMoney").val())>parseFloat($("#txtHiddenSumMoney").val()))
                    {
                        alert('发票金额不能大于总计金额!');
                        $('#txtPayTicketMoney').focus();
                        $('#txtPayTicketMoney').select();
                        //$("#btnOK").attr("disabled",false);
                        return false;
                    }
                }
                //if(Math.abs(fltSub($("#txtPayTicketMoney").val(),$("#txtHiddenSumMoney").val()))>1)
                if(fltSub($("#txtPayTicketMoney").val(),$("#txtHiddenSumMoney").val())>1)
                {
                    alert('多开的发票金额不能大于 1 元!');
                    $('#txtPayTicketMoney').focus();
                    $('#txtPayTicketMoney').select();
                    //$("#btnOK").attr("disabled",false);
                    return false;
              
                }
/*              发票金额不能多于和少于1元
                if(Math.abs(fltSub($("#txtPayTicketMoney").val(),$("#txtHiddenSumMoney").val()))>1)
                {
                    alert('多开的发票金额不能大于 1 元!');
                    $('#txtPayTicketMoney').focus();
                    $('#txtPayTicketMoney').select();
                    return false;
                }
*/
            }
            else if($(objTicket[i]).attr("value")=="Y")
            {
                //var ticketMoney=fltSub(parseFloat($("#txtOweMoney").val()),$("#txtZeroMoney").val());
                //ticketMoney=fltSub(ticketMoney,$("#txtPreferentialMoney").val());

                if(!checkOnlyNum($("#txtOweMoney"),false,14))
                {
                    $("#txtOweMoney").focus();
                    $("#txtOweMoney").select();
                    //$("#btnOK").attr("disabled",false);
                    return false;
                }                
                if(parseFloat($("#txtOweMoney").val())<=0.001)
                {
                    alert('欠票金额不能小于等于0!');
                    $('#txtOweMoney').focus();
                    $('#txtOweMoney').select();
                    //$("#btnOK").attr("disabled",false);
                    return false;
                }
                else if(!isCarryMoney)
                {
                    //if(parseFloat($("#txtOweMoney").val())>parseFloat($("#txtHiddenSumMoney").val()))
                    if(parseFloat($("#txtOweMoney").val())>parseFloat($("#txtHiddenSumMoney").val()))
                    {
                        alert('欠票金额不能大于总计金额!');
                        $('#txtOweMoney').focus();
                        $('#txtOweMoney').select();
                        //$("#btnOK").attr("disabled",false);
                        return false;
                    }
                }
                
                if(fltSub($("#txtOweMoney").val(),$("#txtHiddenSumMoney").val())>1)
                {
                    alert('多开的发票金额不能大于 1 元!');
                    $('#txtOweMoney').focus();
                    $('#txtOweMoney').select();
//                    $("#btnOK").attr("disabled",false);
                    return false;
                }
                
                var rval=fltAdd($('#txtOweMoney').val(),$('#txtPaidTicket').val());
                    rval=fltSub(rval,$('#txtReceivableMoney').val());
                    if($('#txtPrepayMoney').val()>0 && $('#isUsePrepay').attr('checked'))
                    {
                        rval=Math.abs(fltSub(rval,$('#txtPrepayMoney').val()));
                    }
                
                if(rval>1)
                {
                    alert('欠票金额与付票金额之和不能大于 实付金额!');
                    $('#txtOweMoney').focus();
                    $('#txtOweMoney').select();
//                    $("#btnOK").attr("disabled",false);
                    return false;
                }
                
                
/*              发票金额不能多开和少开(1元之内除外)
                if(Math.abs(fltSub($("#txtOweMoney").val(),$("#txtHiddenSumMoney").val()))>1)
                {
                    alert('多开的发票金额不能大于 1 元!');
                    $('#txtOweMoney').focus();
                    $('#txtOweMoney').select();
                    return false;
                }
*/
            }
        }
    }
    if(!$("#cbIsUsePreDeposits").attr("checked"))
    {
        $("#realPreDepositsAmount").val(0);
    }
    if(!$("#isUsePrepay").attr("checked"))
    {
        $("#realPrePayAmount").val(0);
    }
    
    var res= confirm("确定结账?");
    if (res!=true)
    {
        return false;
    }
    $("#txtSubTag").val(1);
    $("#btnOK").attr("disabled",true);
    $("#form1").submit();
    return true;
}
function accredit(t)
{
	//showPage('Accredit.aspx', null, 280, 200, false, false);
	//return true ;
	return window.showModalDialog('Accredit.aspx',t,'dialogHeigth:100px;dialogWidth:260px;status:no');
}

function rasureTrail(t)
{
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
                returnValue=accredit(t);
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
            if(renderUpMax>0)
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
        $("#txtPreferentialMoney").attr("readonly",false);
        $("#txtPreferentialMoney").focus();
        $("#txtPreferentialMoney").select();
    }
}

function getCustomerPayType()
{
    var customerId=$("#txtCustomerId").val();
    var url = "../ajax/AjaxEngine.aspx" + "?CustomerId=" + customerId;
    $.getJSON(url, {a : '15'},onPayTypeChange);
}


function onPayTypeChange(json)
{
    if (json.success == null || json.success) 
    {
        data=json;
    }
    else 
    {
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
        
            $("<tr name='trAcc'><td  nowrap class='item_caption'>挂账:</td><td colspan='3' class='item_content'><input id='txtAcc' name='AccountMoney'  type='text' readonly='true' class='num'  value='0' /></td></tr>").insertAfter("#trZero");
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
        }
        else
        {
            alert("该客户不是记账客户,不能记账!");
            $("#cbPaymentType").attr("value",payType1)
        }
    }
    else
    {
        $("#txtRealMoney").attr("disabled",false);
        $("#chkCarryMoney").attr("disabled",false);
        $("#cbPreSaveMoney").attr("disabled",false);
    }
    
}



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
    }
    
}

function onCarryMoneyClick()
{
    if($("#chkCarryMoney").attr("checked"))
    {
        isCarryMoney=true;
        //$("#txtReturnMoney").val(0);
        //$("#giveBack").text("0");
        realMoneyChange();
    }
    else
    {
        isCarryMoney=false;
        realMoneyChange();
    }
}

function onOwnTicket()
{
    var rval=fltSub($('#txtReceivableMoney').val(),$('#txtOweMoney').val());
    if($("#chkCarryMoney").attr("checked"))
    {
        rval=Math.round(rval);
    }
    if(rval<=1 || isNaN(rval))
    {
        rval=0;
    }       
    $('#txtPaidTicket').val(rval);
}

///// 名    称:usePreDepositsCheck
///// 功能概要:使用预存款验证
///// 作    者:张晓林
///// 创建时间:2009年11月3日15:19:42
///// 修正履历:
///// 修正时间:
//function usePreDepositsCheck(o)
//{
//    
//    if("txtIsUsePreDeposits"==o.id)
//    {
////        if($("#txtIsUsePreDeposits").attr("checked"))
////        {
////            var sumAmount=$("#txtSumMoney").val();
////        }
//    }
//    else
//    {
//         if($("#txtIsUsePreDeposits").attr("checked"))
//         {
//            $("#txtIsUsePreDeposits").attr("checked",false)
//         }
//         else
//         {
//            $("#txtIsUsePreDeposits").attr("checked",true)
//         }
//    }
//    calculateAccountAmount();
//}

///// 名    称: calculateAccountAmount
///// 功能概要: 计算应收金额
///// 作    者: 张晓林
///// 创建时间  2009年11月3日15:36:36
///// 修正履历:
///// 修正时间:
//function calculateAccountAmount()
//{
//    var sumAmount=$("#txtSumMoney").val();//订单总金额
//    var preDeposits=0;//客户预存金额
//    var preAmount=0;
//    if($("#cbIsUsePreDeposits").attr("checked"))//有预存
//    {
//        preDeposits=$("#txtPreDeposits").val();
//    }
//    if($("#isUsePrepay").attr("checked"))//有预收
//    {
//        preAmount=$("#txtPrepayMoney").val();
//    }
//    $("#txtReceivableMoney").val(sumAmount-preDeposits-preAmount);
//}

/// 名    称:preDepositCheck
/// 功能概要:设置选中预存款
/// 作    者:张晓林
/// 创建时间:2009年11月3日13:16:06
/// 修正履历:
/// 修正时间:
function preDepositCheck(o)
{
    if("cbPreSaveMoney"==o.id)
    {
         if(!$("#cbPreSaveMoney").attr("checked"))
         {  
            isPreAmount=false;
            realMoneyChange();
//            $("#preDepositAmount").val("");
//            $("otherPreDepositAmount").attr("visible",false);
         }
         else
         {
            isPreAmount=true;
            realMoneyChange();
//            if(isCarryMoney)
//            {
//                $("otherPreDepositAmount").attr("visible",true);
//                $("#preDepositAmount").val($("otherPreDepositAmount").val());
//            }
//            else
//            {
//                $("#preDepositAmount").val($("#giveBack").text());
//                $("#giveBack").text("");
//            }
         }
    }
    else
    {
        if(!$("#cbPreSaveMoney").attr("checked"))
        {
            isPreAmount=false;
            realMoneyChange();
            $("#cbPreSaveMoney").attr("checked",true)
//            $("#preDepositAmount").val($("#giveBack").text());
//            $("#giveBack").text("");
        }
        else
        {
            isPreAmount=true;
            realMoneyChange();
//            if(!isCarryMoney)
//            {
//                $("#cbPreSaveMoney").attr("checked",false);
//                realMoneyChange();
//                $("#preDepositAmount").val("");
//                $("otherPreDepositAmount").attr("visible",false);
//            }
//            else
//            {
//                $("otherPreDepositAmount").attr("visible",true);
//                $("#preDepositAmount").val($("otherPreDepositAmount").val());
//            }
        }
    }
}

/// 名    称:onkeydown
/// 功能概要:控制Esc建退出弹出窗体，回车提交
/// 作    者:张晓林
/// 创建时间:2009年11月3日13:16:06
/// 修正履历:
/// 修正时间:
document.onkeydown=function(event_e)
{
    //Esc建退出
	if (window.event) event_e=window.event;
	var int_keycode=event_e.charCode || event_e.keyCode;
	if (int_keycode==27)	
	{
		window.close();
	}
	//回车提交
	var evt=window.event || arguments[0];
    var element=evt.srcElement || evt.target;
    if(13==evt.keyCode)
    {
        if("lblCarryMoney"==element.id || "chkCarryMoney"==element.id)
        {
            $("#chkCarryMoney").attr("checked",!$("#chkCarryMoney").attr("checked"));
            onCarryMoneyClick();    
        }
        else if("btnClose"!=element.id)
        {
            $("#btnOK").click();
            return false;
        }
    }
}

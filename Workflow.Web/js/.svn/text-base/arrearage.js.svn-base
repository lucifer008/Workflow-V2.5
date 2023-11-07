
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
    $("#txtPreDeposits").val(0);
    $("#cbUsePreDeposits").attr("checked",false);
    //var strOrdersId="";
    var preDeposits=0;
    if(data.OrderList.length<=0)
    {
        alert("该客户没有欠款!!!");
        $("#txtMemberCardNo").val("");
        $("#txtCustomerName").val("");
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
        str="<tr class='detailRow'><td><input type='checkbox' name='isClose' onclick='changeOrderClck(this)' value='Y'/></td><td>"+ data.OrderList[i].Id+"</td><td><a href='#' onclick='orderDetail(this);'>"+ data.OrderList[i].No +"</a><input type='hidden' name='myOrderNo' value="+ data.OrderList[i].No +" /></td><td>"+ data.OrderList[i].InsertDateTimeString +"</td><td>"+ data.OrderList[i].BalanceDateTimeString +"</td><td>"+ data.OrderList[i].SumAmount +"</td><td>"+ data.OrderList[i].Concession +"</td><td>"+ data.OrderList[i].Zero +"</td><td>"+ data.OrderList[i].RenderUp +"</td><td>"+ data.OrderList[i].PaidAmount +"</td><td  name='paidAmount' style='color:Red'>" + x + "</td><td><input type='text' size='6' class='num' name='currentPayMoney' readonly='readonly' value='0'/>&nbsp;&nbsp;</td></tr>";
        if(sumMoney>0)
        {
            $(str).appendTo(tb);
        }
    }
    if(sumMoney<=0)
    {
        alert("该客户没有欠款!!!");
        $("#txtMemberCardNo").val("");
        $("#txtCustomerName").val("");
        return;
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
    onCurrentPayMoney();
}

function showSelectCustomer(){
	showPage('../customer/SelectCustomer.aspx',null,900,600,false,false);
}
///加载选择客户信息
var CustomerId;
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
    CustomerId=objCustomer.Id;
    
    window.setTimeout("getReceveableAcount()",100);
}
function getReceveableAcount()
{ 
    doSelect(CustomerId);
}

//选中收款订单改变处理程序--张晓林
function changeOrderClck(o){
    var restPaidAmount=0;//实际付款(包含预存冲减)
    var paidAmount=parseFloat($("#txtPayMoney").val());//本次支付金额
    var conAmount=parseFloat($("#txtConcession").val());//本次折让
    var cbBooPre=$("#cbUsePreDeposits").attr("checked");
    var accPaidAmount=parseFloat($("#txtShowPayMoney").val());
    var preDeAmount=parseFloat($("#realUsePreDepositsAmount").val());//实际冲减的预存款
    var paidZero=parseFloat($("#txtSavePreDepositsAmount").val());
    var scotAmount=parseFloat($("#txtScotAmount").val());//税费
    
    if(isNaN(accPaidAmount)) accPaidAmount=0;
    if(isNaN(conAmount)) conAmount=0;
    if(isNaN(preDeAmount)) preDeAmount=0;
    if(isNaN(paidAmount)) paidAmount=0;
    if(isNaN(scotAmount)) scotAmount=0;
      
    if(0<conAmount){
        restPaidAmount=fltAdd(restPaidAmount,conAmount);
    }
    if(cbBooPre){
        restPaidAmount=fltAdd(restPaidAmount,preDeAmount);
    }
    if(0!=paidAmount){
        restPaidAmount=fltAdd(restPaidAmount,paidAmount);
    }
    if(isScot){
        restPaidAmount=fltSub(restPaidAmount,scotAmount);
    }
    if(0>restPaidAmount) restPaidAmount=0;
    if(0==restPaidAmount){
        alert("付款金额不能为0!");
        $(o).attr("checked",!$(o).attr("checked"));
        return;
    }
    var cbPaidOrdersArr=$("input:checkbox[@name=isClose]");
    var diffAmount=0;
    for(var i=0;i<cbPaidOrdersArr.length;i++){
        if($(cbPaidOrdersArr[i]).attr("checked")){
            var am=parseFloat($("input:text[@name=currentPayMoney]",$(cbPaidOrdersArr[i]).parent().parent()).val());
            if(isNaN(am)){
               am=0; 
            }
            diffAmount=fltAdd(diffAmount,am);   
        }
    }
    
    if(0!=diffAmount){
        restPaidAmount=fltSub(restPaidAmount,diffAmount);
    }
    if(0==restPaidAmount){
        alert("已经没有付款金额可分配!");
        $(o).attr("checked",!$(o).attr("checked"));
        return;
    }
    var oSelected=parseFloat($("td[@name=paidAmount]",$(o).parent().parent()).html());//选中订单明细欠款金额
    if($(o).attr("checked")){
        if(oSelected>=restPaidAmount){
           $("input:text[@name=currentPayMoney]",$(o).parent().parent()).val(restPaidAmount);
           $("#restMoney").text(0);
        }
        else{
            $("input:text[@name=currentPayMoney]",$(o).parent().parent()).val(oSelected);
            $("#restMoney").text(fltSub(paidAmount,fltAdd(diffAmount,oSelected)));
        }
    }
    else{
        $("input:text[@name=currentPayMoney]",$(o).parent().parent()).val(0);
        $("#restMoney").text(restPaidAmount);
    }
}
function onFocus(o)
{
   // $(o).select();
   // $(o).focus();
}

function onLeave(o)
{
    //如果支付金额为0
//    if($("#txtPayMoney").val()==0){
//        $(o).val(0);
//        return;
//    }
//    var txtArr=$("input[@name='currentPayMoney']");
//    var paidAmountObj=$("td[@name=paidAmount]");
//    var paidMoney=0;
//    for(var i=0;i<txtArr.length;i++)
//    {
//        if(!checkOnlyNum($(txtArr[i]),false,14) || parseFloat($(txtArr[i]).val("0"))>parseFloat($(paidAmountObj[i]).html()))
//            $(txtArr[i]).val("0");
//        paidMoney=fltAdd(paidMoney,parseFloat($(txtArr[i]).val()));
//    }
//    var allmoney=fltAdd(parseFloat($("#txtPayMoney").val()),parseFloat($("#txtConcession").val()));
//    var rest=fltSub(parseFloat(allmoney),parseFloat(paidMoney));
//    //如果还有余额
//    if(rest>0){
//        shareAlikeMoney(txtArr,rest,o);
//    }
//    else{
//        $("#restMoney").text(0);
//    }
}
//收款验证
function dataCheck()
{
    var allmoney=0;//实际付款金额(含折让金额，预存款冲减)
    var showmoney=parseFloat($("#txtSumMoney").val());//应付金额
    var payMoney=parseFloat($("#txtPayMoney").val());//实付金额
    var conAmount=parseFloat($("#txtConcession").val());//折让金额
    var paidTicketAmount=parseFloat($("#txtPaidTicketAmount").val());//付票金额
    var relPreDeposits=parseFloat($("#realUsePreDepositsAmount").val());//实际冲减的预存款
    var scotAmount=parseFloat($("#txtScotAmount").val());//税费
    var realPreMoney=parseFloat($("#txtSavePreDepositsAmount").val());
    if(isNaN(scotAmount)) scotAmount=0;
    if(isNaN(relPreDeposits)) relPreDeposits=0;
    if(isNaN(realPreMoney)) realPreMoney=0;
    if(!isNumber(conAmount))
    {
        alert("折让金额格式不正确!");
        $("#txtConcession").focus();
        $("#txtConcession").select();
        return false;
    }
    if(!isNumber(payMoney))
    {
        alert("实收金额格式不正确!");
        $("#txtPayMoney").focus();
        $("#txtPayMoney").select();
        return false;
    }

    allmoney=fltAdd(payMoney,conAmount);
     //如果使用预收款
    if($("#cbUsePreDeposits").attr("checked"))
    {
        allmoney=fltAdd(allmoney,relPreDeposits);
    }
    if(allmoney<=0)    
    {
        alert('本次付款不能小于等于0!!!');
        $("#txtPayMoney").select();
        $("#txtPayMoney").focus();
        return false;
    }
    var chkArr=$("input:checkbox[@name='isClose']");
    if(chkArr.length<=0)
    {
        alert('请您选择本次付款的订单!!!');
        return false;
    }
    var txtArr=$("input:text[@name='currentPayMoney']");
    var m=0;
    var strOrdersId="";//付款订单Id集合字符串
    var strMoney="";  //付款金额集合字符串
    var strAccMoney="";//付款订单欠款集合字符串
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
                var rest=parseFloat(allmoney-paidMoney).toFixed(2);//处理js浮点数不精确问题
                rest=fltSub(rest,scotAmount);
                if(rest<0)
                {
                    alert('付款金额不足!!!');
                    $("#txtPayMoney").select();
                    $("#txtPayMoney").focus();
                    return false;
                }
                  strOrdersId+=$($("td", $(txtArr[i]).parent().parent()[0])[1]).text()+',';
                  strMoney+=$(txtArr[i]).val()+',';
                  strAccMoney+=$($("td", $(txtArr[i]).parent().parent()[0])[10]).text()+',';
            }
            m++;
        }
    }
    if(m<=0)
    {
        alert('请您选择本次付款的订单!!!');
        $(chkArr[0]).focus();
        return false;
    }
    if($("#rdbtN").attr("checked"))
    {
        if(isNaN(paidTicketAmount))
			paidTicketAmount=0;
        if(0>paidTicketAmount || 0==paidTicketAmount)
        {
            alert("付票金额不能小于0!");
            $("#txtPaidTicketAmount").focus();
            $("#txtPaidTicketAmount").select();
            return false;
        }
        if(paidTicketAmount-allmoney>=1 && !isScot)
        {
            alert("付票金额不能大于收款总金额");
            $("#txtPaidTicketAmount").focus();
            $("#txtPaidTicketAmount").select();
            return false;
        }
    }
    $("#divGatheringInfo").show();
    $("#tdAccountAmount").html(payMoney);
    $("#tdOrderDisAmount").html(paidMoney);
    $("#tdPreDospsitiAmount").html("0");
    $("#tdScotAmount").html("0");
    if(isScot){
        $("#tdScotAmount").html(scotAmount);
    }
    if(isPreDepos){
        $("#tdPreDospsitiAmount").html(realPreMoney);
    }
    var res= confirm("确定付款?");
    if (res!=true) return false;
    strOrdersId=strOrdersId.substr(0,strOrdersId.length-1)
    strMoney=strMoney.substr(0,strMoney.length-1)
    strAccMoney=strAccMoney.substr(0,strAccMoney.length-1)
    $("#txtOrdersId").val(strOrdersId);
    $("#txtMoney").val(strMoney);
    $("#txtAccMoney").val(strAccMoney);
    $("#actionTag").val("True");
    $("#btnOK").attr("disabled",true);
    $("#form1").submit();
    return true;
}


var rePaidAmount=0;//实际订单消费的金额
var rePTotal=0;//本次付款总金额(含折让金额,预存金额)
var z=0;//预存金额
var reAm=0;
function onCurrentPayMoney()
{
    rePaidAmount=0;z=0;reAm=0;
    var pAmount=parseFloat($("#txtPayMoney").val());//本次支付的现金
    var cOweSumMoney=parseFloat($("#txtSumMoney").val());//客户欠款总金额
    var concessionAmount=parseFloat($("#txtConcession").val());//折让金额
    var cPreAmount=parseFloat($("#txtPreDeposits").val());//客户预存款
    var maxRenderUp=fltMul(renderUpMax,cOweSumMoney);//当前用户最大折让金额
    var minRenderUp=fltMul(renderUpMin,cOweSumMoney);//当前用户最小折让金额
    if(!isNumber(concessionAmount))
    {
        alert("折让金额格式不正确!");
        $("#txtConcession").val("0");
        $("#txtConcession").focus();
        return;
    }
    if(!isNumber(pAmount))
    {
        alert("本次支付金额格式不正确!");
        $("#txtPayMoney").val("0");
        $("#txtPayMoney").focus();
        return;
    }
    if(cOweSumMoney<concessionAmount)
    {
       alert('折让金额不能大于应付金额!');
       $("#txtConcession").val("0");
       $("#txtConcession").focus();
       $("#txtConcession").select();
       return 
    }
    if(concessionAmount>maxRenderUp || concessionAmount<minRenderUp)
    {
       var yes=confirm("折让金额超出您的权限范围！是否授权折让?")
       if(!yes)
       {
           alert('折让金额超出了您的权限范围!');
           $("#txtConcession").val("0");
           $("#txtConcession").focus();
           $("#txtConcession").select();
           return;
       }
       else
       {
            var tag=accredit(rendUpOutAccreditTypeKey,rendUpOutAccreditTypeText,"");
            if(!tag)
            {
                $("#txtConcession").val("0");
                $("#txtConcession").focus();
                $("#txtConcession").select();
                return;
            }
            else
            {
                var accMaxRendUpAmount=fltMul(cOweSumMoney,accRendupMax);//授权用户最大的折让金额
                if(concessionAmount>accMaxRendUpAmount)
                {
                    alert("授权用户权限不够!");
                    $("#txtConcession").val("0");
                    $("#txtConcession").focus();
                    $("#txtConcession").select();
                    return;
                }
            }
       } 
       
    }
    rePaidAmount=fltAdd(pAmount,concessionAmount);
    $("#realUsePreDepositsAmount").val(0);//实际冲减的预存款
    if($("#cbUsePreDeposits").attr("checked"))//如果使用预存款
    {
        if(cOweSumMoney>=cPreAmount)
        {
            rePaidAmount=fltAdd(rePaidAmount,cPreAmount);
        }
        else
        {
            rePaidAmount=fltAdd(rePaidAmount,cOweSumMoney);
        }
        //获取实际冲减的预存款
        var rePreDe=fltSub(cPreAmount,cOweSumMoney);
        if(rePreDe>=0)
        {
            $("#realUsePreDepositsAmount").val(fltSub(cOweSumMoney,concessionAmount));
        }
        else
        {
            $("#realUsePreDepositsAmount").val(cPreAmount);
        }
    }
    $("#spPreDeposits").hide();
    if(rePaidAmount>cOweSumMoney) rePTotal=cOweSumMoney;
    else rePTotal=rePaidAmount;
    caluScotAmount();
    var scotAmount=parseFloat($("#txtScotAmount").val());//税费
    if(0>rePaidAmount) rePaidAmount=0;
    if(isNaN(scotAmount)) scotAmount=0;
    if(isScot) rePaidAmount=fltSub(rePaidAmount,scotAmount);
    reAm=rePaidAmount;
    if(cOweSumMoney<rePaidAmount)//实付金额大于欠款总金额时
    {
        z=rePaidAmount;
        z=fltSub(z,cOweSumMoney);
        if(z>0)
        {
            $("#spPreDeposits").show();
            $("#txtSavePreDepositsAmount").val(parseFloat(z).toFixed(2));//预存金额/找零金额   
        }
        rePaidAmount=cOweSumMoney;
    }
    var rest=fltSub(cOweSumMoney,rePaidAmount);
    if(rest<0) rest=0;
    $("#txtArrearage").val(rest);//还欠金额
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
    var allmoney=rePaidAmount;
    var rest=allmoney;
    var pMoney=0;//订单分配金额总和
    for(var i=0;i<chkArr.length;i++)
    {
        if(0==rest) break;
        var needPay=parseFloat( $($("td", $(txtArr[i]).parent().parent()[0])[10]).text());
        chkArr[i].checked=true;
        if (needPay>=rest)
        {
            pMoney=fltAdd(rest,pMoney);
            $(txtArr[i]).val(rest);
            rest=0;
            break;
        }
        else
        {
            pMoney=fltAdd(needPay,pMoney);
            $(txtArr[i]).val(needPay);
            rest=fltSub(rest,needPay);
        }        
    }
    if(pMoney>0)
    {
        var re=fltSub(reAm,pMoney);        
        if(0<re) $("#restMoney").text(re);//记录本次付款后的余额
    }          
}


///功能概要:单击预存发生的动作
///作者:张晓林
///创建时间:2009年11月10日9:38:58
///修正履历:
///修正时间:
var isPreDepos=false;//是否预存找零金额
function usePreDepositsClick()
{
    if($("#cbSavePreDeposits").attr("checked")){ 
        $("#txtSavePreDepositsAmount").hide();
        isPreDepos=true;
    }
    else{
        $("#txtSavePreDepositsAmount").show();
        isPreDepos=false;
    }
}

//用户折让授权验证 
function accredit(t)
{
	//return window.showModalDialog('Accredit.aspx',t,'dialogHeigth:100px;dialogWidth:260px;status:no');
	 var url="../finance/Accredit.aspx?AccreditTypeKey="+escape(rendUpAccreditTypeKey)+"&AccreditTypeText="+escape(USER_ACCREDIT_TYPE_RENDUP_TEXT)+"&AccreditTypeId="+escape(5);
    return showPage(url,null,280,500,false,true,false,false);
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

//根据会员卡号获取客户欠款订单明细
function getCustomerInfo(e,o)
{
    var memberNo=$(o).val();
    if(null==memberNo || ""==memberNo) return;
    var url = "../ajax/AjaxEngine.aspx" + "?MemberCardNo=" + memberNo;
    $.getJSON(url, {a : '12'},CustomerInfoCallBack);
    return false;
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
        return;
    }
    if(null==data.MemberCard) 
    {
        alert("您输入的卡号有误或未启用!");
        $("#txtMemberCardNo").focus();
        $("#txtMemberCardNo").select();
        return;
    }
    $("#txtCustomerId").attr("value",data.MemberCard.CustomerId);
    $("#txtMemberCardNo").attr("value",data.MemberCard.MemberCardNo);
    $("#txtCustomerName").attr("value",data.MemberCard.CustomerName);    
    var obj=new Object();
    obj.Id=data.MemberCard.CustomerId;
    obj.MemberCardNo=data.MemberCard.MemberCardNo;
    obj.Name=data.MemberCard.CustomerName;
    selectCustomer(obj);
}

///获取授权用户的优惠信息(折让超出范围 张晓林)
function accredit(t1,t2,t3){
     var url="../finance/Accredit.aspx?AccreditTypeKey="+escape(t1)+"&AccreditTypeText="+escape(t2)+"&AccreditTypeLabel="+escape("折让授权")+"&IsCallBack=True";
     //return showPage(url,null,280,500,false,true,false,false);
     return window.showModalDialog(url,window,'dialogHeigth:200px;dialogWidth:280px;status:no');
}
var accZeroMax=0,accConcessionMax=0,accRendupMax=0;
function setAccreditUsersInfo(o){
    accZeroMax=o.maxZero;
    accConcessionMax=o.maxConcession;
    accRendupMax=o.maxRendUp;
}
function onTicketClick(o){
    if($("#rdbtN").attr("checked")){ 
        $("#spay").show();
    }
    else{
        $("#txtPaidTicketAmount").val(0); 
        $("#spay").hide();
    }
}
//计算税费(张晓林)
var isScot=false;
function caluScotAmount(){
    var paidTicketAmount=parseFloat($("#txtPaidTicketAmount").val());//付票金额
    var accAmount=parseFloat($("#txtSumMoney").val());//应收款金额
    var paidAmount=parseFloat(rePTotal);//>accAmount? accAmount:parseFloat(rePTotal);
    scotInverse=parseFloat(scotInverse);//税费比例
    if(isNaN(paidTicketAmount))
    {
        txtPaidTicketAmount=0;
    }
    if(isNaN(scotInverse))
    {
        scotInverse=0;
    }
    if(isNaN(paidAmount))
    {
        paidAmount=0;
    }
    var scot=fltSub(paidTicketAmount,paidAmount);//accAmount);
    if(1<scot)
    {
        isScot=true;
        $("#lblScot").show();
        scot=fltMul(scot,scotInverse);
        $("#txtScotAmount").val(parseFloat(scot).toFixed(2));
    }
    else
    {
        isScot=false;
        $("#lblScot").hide();
        $("#txtScotAmount").val(0);
    }
    //重新计算预存金额
    var scotAmount=parseFloat($("#txtScotAmount").val());
    if(isNaN(scotAmount)) scotAmount=0;
    var s=fltSub(z,scotAmount);
    if(0<s)
    {
        $("#spPreDeposits").show();
        $("#txtSavePreDepositsAmount").val(parseFloat(s).toFixed(2));//预存金额/找零金额   
    }
    else
    {
        $("#spPreDeposits").hide();
        $("#txtSavePreDepositsAmount").val(0);//预存金额/找零金额
    }
}
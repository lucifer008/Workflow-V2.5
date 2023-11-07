// JScript 文件
// 名    称: phophaseConfirm.js
// 功能概要: 前期确认 Js
// 作    者: 张晓林
// 创建时间: 2010年1月11日12:01:56
// 修正履历: 
// 修正时间: 

//隐藏/显示开单时的复杂信息
function showOrderDetail()
{
    if(orderDetailIsHidden)
    {
        trDetailHtmlX=$("#trHello").html();
        $("#tr2").append(trDetailHtmlX);
        $("#trHello").remove();
        $("#aOrderDetail").text("详细信息<<<");
        orderDetailIsHidden=false;
    }
    else
    {
        trDetailHtmlX=$("#tr2").html();
        trDetailHtmlY="<tr id='trHello'>"+trDetailHtmlX+"</tr>";
        $("#tr2").html("");
        $("#tbOuter").append(trDetailHtmlY);
        $("#trHello").css("visibility","hidden");
        $("#aOrderDetail").text("详细信息>>>");
        orderDetailIsHidden=true;
    }
}

function showSelectPrintRequest() {
	showPage('PrintRequest.aspx', null, 800, 485, false, true);
}

function selectAll(o)
{
    $(o).select();
}

document.onkeydown=inputKeyCheck;
function inputKeyCheck(e){
    //e=e||event;//IE下支持，Firefox下不支持
    var e=window.event||arguments[0];
    if (e.keyCode==27)	
    {
        window.close();
    }
    if(e.keyCode==13){
        //---添加回车自动计算金额
        try{
            //控制扫描条码
            var evt=window.event||arguments[0];
            var element=e.srcElement||src.target;

            if("txtOrderNo"==element.id){
                $("#btnOk").click();
                return false;
            }
            //修改价格
            else{
                 var amountObj=$("input:text[@name=Amount]");
                for(var i=0;i<amountObj.length;i++){
                    if(amountObj[i] && document.activeElement==amountObj[i]){
                        var butObj=$("input:button[@name=btnOrderItemOk]");
                        hideControl(butObj[i]);
                        return false;
                    }
                }
                var unitPriceObj=$("input:text[@name=unitPrice]");
                for(var i=0;i<unitPriceObj.length;i++)
                { 
                    if(unitPriceObj[i] && document.activeElement==unitPriceObj[i]){
                        modifyPriceOnKeydown(unitPriceObj[i],e);
                        return false;
                    }
                }       
            }
        }
        catch(ex){
            return false;
        }
        return false;
    }


}
function orderItemEdit(o)
{
    editOrderItem(o);
    //disableButton();
}
function disableButton()
{
    $("#btnBlankOut").attr("disabled",true);
    $("#btnSave").attr("disabled",true);
    $("#btnReturn").attr("disabled",false);

}

function memberCardChange(evnt,o)
{
    disableButton();
    return getCustomerInfo(evnt,o);

}
function blankOutRecord()
{
    //var strOrderNo=strNo;//$("#txtOrderNo").attr("value");
    showPage('BlankOutRecord.aspx?strNo='+strNo,null,1024,1024,false,true);
    close();
}
function dispatchOrder()
{
    //Flag 1:本日订单中的分配；2:开单中的总体分配 3:每一个订单明细中的分配 4:修正加订单后重新调整前后期
    showPage('DispatchOrder.aspx?strNo='+strNo+'&Flag=4', null, 410, 465, false, false);
}
//功能: 前期确认查询验证
//作者：张晓林
//日期: 2010年1月11日12:07:46
function searchCheck(){
    if(""==$("#txtOrderNo").val()){
        alert("订单号不能为空!");
        return false;
    }
    $("#Action").val("Search");
    $("#btnOk").attr("disabled",true);
    $("#form").submit();
}

function phophaseOrderDataCheck()
{
    //Author:Cry Date:2008-12-29 ,修改订单明细时,自动保存
    //--------------------
    var btnOrderItem=$("input:button[@name=btnOrderItemOk]");
    var isReturn=false;
    for(var i=0;i<btnOrderItem.length;i++){        
        if("none"!=$(btnOrderItem[i]).css("display")){
            hideControl(btnOrderItem[i],'submit');
            isReturn=true;
        }
    }
    if(isReturn) {
        //alert('请重新核实你的金额');
        return false;
    }
    //--------------------
    if(""==$('#txtCustomerName')[0].value)
    {
        alert('客户名称不能为空!');
        $('#txtCustomerName').select();
        $('#txtCustomerName').focus();
        return false;
    }
    if(-1==$('#cbCustomerType').attr("value"))
    {
        alert('请选择客户类型!');
        $('#cbCustomerType').select();
        $('#cbCustomerType').focus();
        return false;
        
    }
    if($('#ckNeedPrepareMoney')[0].checked)
    {
        if(""==$('#txtPrepayMoney')[0].value)
        {
            alert('您已经选择了预付款，所以预付款不能为空！');
            $('#txtPrepayMoney').focus();
            $('#txtPrepayMoney').select();
            return false;
        }
        else
        {
            if(parseFloat($('#txtPrepayMoney').val())<=0)
            {
                alert('预收款不能小于 0');
                $('#txtPrepayMoney').focus();
                $('#txtPrepayMoney').select();
                return false;
            }
           if(!checkOnlyNum($('#txtPrepayMoney'),false,14))
           {
                $('#txtPrepayMoney').focus();
                $('#txtPrepayMoney').select();
                return false;
           }
        }
    }
    if($("#cbDeliveryType")[0].options[$("#cbDeliveryType")[0].selectedIndex].value==delivery)
    {
        if($("#txtDeliveryDateTime").val().length<=0)
        {
            alert('您已经选择了送货方式，所以请您指定送货时间!!!');
            $("#txtDeliveryDateTime").select();
            $("#txtDeliveryDateTime").focus();
            return false;
        }
        if(!isDateTime($("#txtDeliveryDateTime").val()))
        {
            return false;
        }
    }
    if($("#cbDeliveryType")[0].options[$("#cbDeliveryType")[0].selectedIndex].value==self)
    {
        if($("#txtDeliveryDateTime").val().length>0)
        {
            if(!isDateTime($("#txtDeliveryDateTime").val()))
            {
                return false;
            }
        }
    }    
    
    
    if($("textarea[@name='Memo']")[0].value.length>200)
    {
        alert("您输入的备注太长!!!");
        $($("textarea[@name='Memo']")[0]).select();
        $($("textarea[@name='Memo']")[0]).focus();
        return false;
    }
    var sltArr=$("select",$());
    for(var i=0;i<sltArr.length;i++)
    {
        if(sltArr[i].options[sltArr[i].selectedIndex].value==-1)
        {
        
            if(sltArr[i].name=="BusinessType")
            {
                alert("请您选择业务类型!!!");
                if($(sltArr[i]).css("display").toLowerCase()!="none")
                {
                    sltArr[i].focus();
                }
                return false;
            }
            else
            {
                alert('请您选择制作条件!');
                if($(sltArr[i]).css("display").toLowerCase()!="none")
                {
                    sltArr[i].focus();
                }
                return false;

            }        
        }
    }
    var amntArr=$("input[@name='Amount']");
    for(var i=0;i<amntArr.length;i++)
    {

        if($("input[@name='Amount']")[i].value=="" || $("input[@name='Amount']")[i].value==0)
        {
            alert("请输入数量!");
            return false;
        }
        else
        {
            var btn=$($("input[@name='Amount']")[i]);
            if(!checkOnlyNum(btn,false,14))
            {
                return false;
            }
        }
    }
    var priceArr=$("input[@name='strPrice']");
    for(var i=0;i<priceArr.length;i++)
    {
        if(priceArr[i].value=="" || parseFloat(priceArr[i].value)==-1)
        {
            alert("第"+(i+1)+"个订单项匹配有误!");
            //$(priceArr[i]).focus();
            return false;
        }
    }
    var btnObj=$("input:button[@name='btnOrderItemOk']");
    for(var i=0;i<btnObj.length;i++)
    {
        if(btnObj[i].style.display=="")
        {
            alert("请先确认第 "+ (i+1) +" 个订单明细!")
            $(btnObj[i]).focus();
            return false;
        }
    }
    $("#btnSave").attr("disabled",true);
    $("#Action").val("Save");
    $("#form").submit();
    return true;
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

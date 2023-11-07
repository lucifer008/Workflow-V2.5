// 名    称: realFactureOrder.js
// 功能概要: 修正加订单 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 
function getSelectArray(index)
{
   //alert("dtdt");
   var oSelect=$("select[@name='BusinessType']")[index-1];
   var sltArr=$("select",$(oSelect).parent().parent());
   if(sltArr.length<=1)
   {
        setTimeout("getSelectArray("+index+")",500);
        //getSelectArray(index);
   }
   else
   {
        transficationOrderItemFactorValue(strNo,oSelect);
   }
}

function selectAll(o)
{
    $(o).select();
}

$().ready(
    function()
    {
        if(undefined!=$("#cbDeliveryType")[0])
        {
            if($("#cbDeliveryType")[0].options[$("#cbDeliveryType")[0].selectedIndex].value!=wait)
            {
                $("#txtDeliveryDateTime").show();
            }
            else
            {
                $("#txtDeliveryDateTime").hide();
            }
        }
    }
);

 var rowIndex=0;
$().ready(
    function()
    {
        var oSelect=$("select[@name='BusinessType']");
        for(var i=0;i<oSelect.length;i++)
        {
            if(oSelect[i].options[oSelect[i].selectedIndex].value!='-1')
            {
                doProcess(oSelect[i]);
                rowIndex=$($($("td",$(oSelect[i]).parent().parent()))[0]).text();
                getSelectArray(parseInt(rowIndex));
            }
        }
      	$("input:button[@value=选择客户]").click(disableButton);
        $("input:button[@value=新增客户]").click(disableButton);
        $("#btnReturn").attr("disabled",true);

    }

);
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
                    //modifyPriceOnKeydown(unitPriceObj[i]);//Firefox下不支持这种写法---张晓林
                    modifyPriceOnKeydown(unitPriceObj[i],e);
                    return false;
                }
            }
        }
        catch(ex){
            return false;
        }
        return false;
    }
}



function addOneOrderItem()
{
    addRow();
    //disableButton();
}

function deleteOneOrderitem(o)
{
    delRow(o);
    //disableButton();
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
    //disableButton();
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

$(document).ready(function() {
    try
    {
      if(isPrint=='True')
      {
        opener.rVal='true';
        window.close();
      } 
    }
    catch(e){alert(e)}
});


// JScript 文件
//功能: 修正JS
//作者: 张晓林
//日期: 2010年3月30日13:50:13

// JScript 文件

var source;
var factorCount = 0;
var trHtmlText = "";
//回调函数是否执行完毕的标志
var processFlag=false;
//指示当前的开单详细信息是显示还是隐藏
var orderDetailIsHidden=true;
var trDetailHtml="";
var rValOrder=null;
var orderNo=null;
$(document).ready(function() {
    //隐藏/显示开单时的复杂信息
    trDetailHtmlX=$("#tr2").html();
    trDetailHtmlY="<tr id='trHello'>"+trDetailHtmlX+"</tr>";
    $("#tr2").html("");
    $("#tbOuter").append(trDetailHtmlY);
    $("#trHello").css("visibility","hidden");
    //$("#tr2").css("visibility","hidden");
    $("#aOrderDetail").text("详细信息>>>");
    orderDetailIsHidden=true;
    
	$("input:button[@value=选择客户]").click(showSelectCustomer);
    $("input:button[@value=新增客户]").click(showNewCustomer);

    var table = $("#tbOrderItem");
    var lastTr = $("tr:last-child", table);
    trHtmlText = lastTr.html();
    $("input:hidden[@name=orderItemId]",$(trHtmlText)).remove();
    $('#txtPrepayMoney').hide();
});

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


//向页面传递订单明细因素的植
function transficationOrderItemFactorValue(orderNo,oSelect)
{
    if(null==orderNo || ""==orderNo ) return;
    var url="../ajax/AjaxEngine.aspx?orderNo="+orderNo;
    source=oSelect;
    
    var provider = {};
    provider.source1 = oSelect;
    provider.process = function(json) {
        window.setOrderItemFactorValue(json, provider.source1);
    };
    $.getJSON(url,{a:'7'},provider.process);
}
function setOrderItemFactorValue(json,oSlt)
{
    if (json.success == null || json.success) 
    {
        data=json;
    }
    else 
    {
        return;
    }
    var sltArr=$("select",$(oSlt).parent().parent());
    var lastIndex=parseInt($($("td",$(oSlt).parent().parent())[0]).text());
    var sltNum=0;
    var factorNum=0;
    var strFactorId="";
    var strFactorValue="";
    for(var m=sltNum;m<sltArr.length;m++)
    {
        var breakFlag=false;
        if(sltArr[m].name=="BusinessType")continue;
        for(var i=factorNum;i<data.OrderItemList.length;i++)
        {
            if(data.OrderItemList[i].Id==data.OrderList[lastIndex-1].Id)
            {
                for(var n=0;n<sltArr[m].options.length;n++)
                {
                    if(sltArr[m].options[n].value==data.OrderItemList[i].Values)
                    {
                        strFactorId+=data.OrderItemList[i].Values+',';
                        strFactorValue+=data.OrderItemList[i].Name+',';
                        sltArr[m].options[n].selected=true;
                        sltNum++;
                        factorNum++;
                        breakFlag=true;
                        break;
                    }
                }
            }
            else
            {
                factorNum++;
            }
            if(breakFlag)
            {
                break;
            }
        }
    }
    var rowIndex=$($($("td",$(oSlt).parent().parent()))[0]).text();
    $("#factorid"+rowIndex).attr("value",strFactorId);
    $("#factorvalue"+rowIndex).attr("value",strFactorValue);
    
    var printTextStr="";
    var printValueStr="";
    for(var i=0;i<data.OrderItemPrintRequireDetailList.length;i++)
    {
        if(data.OrderList[lastIndex-1].Id==data.OrderItemPrintRequireDetailList[i].OrderItemId)
        {
            printTextStr+=data.OrderItemPrintRequireDetailList[i].Name+" ";
            printValueStr+=data.OrderItemPrintRequireDetailList[i].PrintRequireDetailId+',';
        }
    }
    $("#printRequest"+rowIndex).attr("value",printValueStr);
    //价格
    $($("input:hidden[@name='strPrice']")[rowIndex-1]).attr("value",data.OrderList[lastIndex-1].SumAmount);
    //数量
    $($("input:text[@name='Amount']")[rowIndex-1]).attr("value",data.OrderList[lastIndex-1].PrepareMoneyAmount);
    //金额
    $($("input:hidden[@name='txtSumMoney']")[rowIndex-1]).attr("value",data.OrderList[lastIndex-1].SumAmount *data.OrderList[lastIndex-1].PrepareMoneyAmount);
    
    var button=$("input:button",$(oSlt).parent().parent())[0];
    var lastIndex=parseInt($($("td",$(button).parent().parent())[0]).text());
    $("span",$(button).parent().parent()).remove();
    var strFactorId="";
    var strFactorValue="";
    var strPriceFactorId="";
    for(var i=0;i<sltArr.length;i++)
    {
        var strTmp='<span>'+sltArr[i].options[sltArr[i].selectedIndex].text+'</span>';
        $(strTmp).appendTo(sltArr[i].parentNode);
        $(sltArr[i]).hide();
        if("BusinessType"==sltArr[i].name) continue;
        strFactorId+=sltArr[i].options[sltArr[i].selectedIndex].value+',';
        strFactorValue+=sltArr[i].options[sltArr[i].selectedIndex].text+',';
        strPriceFactorId+=parseInt((sltArr[i].id.split('x'))[1]).toString()+',';
    }
    var txtArr=$("input[@type='text']",$(button).parent().parent());
    for(var i=0;i<txtArr.length;i++)
    {
        var strTmp='<span>'+txtArr[i].value+'</span>';
        if($(txtArr[i]).attr("name")=="unitPrice")
        {
            strTmp='<a href="#"  name="modifyPrice" onclick="modifyPrice(this,2);"><span>'+txtArr[i].value+'</span></a>';
        }
        $(strTmp).appendTo(txtArr[i].parentNode);
        $(txtArr[i]).hide();
    }
    $("#txtPriceFactorId"+lastIndex).attr("value",strPriceFactorId);
    $("#factorid"+lastIndex).attr("value",strFactorId);
    $("#factorvalue"+lastIndex).attr("value",strFactorValue);
    
    $("select",sltArr).hide();
    $("input[@type='text']",$(button).parent().parent()).hide();
        
    $($("input",$(button).parent())[1]).show();
    $(button).hide();
    
    $("#txtRowNo").attr("value",lastIndex)
    $('#txtPrepayMoney').show();
}

//获取价格
function doPrice(oButton,submit)
{
    source=$("#sltBusinessType",$(oButton).parent().parent());
    if(0==source.length)
    {
        source=$("#sltBusinessType1",$(oButton).parent().parent());
    }
    if(oButton.value==-1) return;
    var oSelects=$("select",$(oButton).parent().parent());
    var customerid=$("#txtCustomerId").val();
    var memberCardNo=$("#txtMemberCardNo").val();
    //var memberCardLevelId=$("#txtMemberCardLevelId").val();
    var tradeid=$("#txtTradeId").val();
    var strTmp="";
    var strFactorSortNo="";
    var oSelect=$("select",$(oButton).parent().parent());
    var amount=$("input[@name=Amount]",$(oButton).parent().parent()).val();
    for(var i=1;i<oSelect.length;i++)
    {
        
        if(i+1<oSelect.length)
        {
            strTmp+=oSelect[i].value+",";
            strFactorSortNo+=oSelect[i].id+",";
        }
        else
        {
            strTmp+=oSelect[i].value;
            strFactorSortNo+=oSelect[i].id;
        }
    }
    var price = {};
    price.source1 = oButton;
    price.source2=submit;
    price.process = function(json) {
        window.priceProcess(json, price.source1,price.source2);
    };    
    var url = "../ajax/AjaxEngine.aspx" + "?businessTypeId=" + source[0].value +"&TradeId="+tradeid+"&MemberCardNo="+memberCardNo+"&CustomerId="+customerid+"&FactorsId="+strTmp+"&FactorsSortNo="+strFactorSortNo+"&Amount="+amount;
    source=oButton;
    $.getJSON(url, {a : '5'}, price.process);
}
function priceProcess(json, sourcex,source)
{
    if (json.success == null || json.success) 
    {
        data=json;
    }
    else 
    {
        return;
    }
    var index=parseInt($($("td",$(sourcex).parent().parent())[0]).text());
    var money= data.BaseBusinessTypePriceSet.StandardPrice;
    var strPriceHtml="<a href='#' name='modifyPrice'  onclick='modifyPrice(this,2);'>"+ money +"</a><input type='text' name='unitPrice' size='10' style='display:none; text-align:right;'  value='"+ data.BaseBusinessTypePriceSet.StandardPrice +"' maxlength='10'/>";
    //$("td[@name='price']",$(sourcex).parent().parent()).text(data.BaseBusinessTypePriceSet.StandardPrice);
    $("td[@name='price']",$(sourcex).parent().parent()).html(strPriceHtml);
    $("#txtPriceId"+index).val(data.BaseBusinessTypePriceSet.Id);
    $("input[@name='strPrice']",$(sourcex).parent().parent()).val(data.BaseBusinessTypePriceSet.StandardPrice);
    //var sumMoney=parseFloat(data.BaseBusinessTypePriceSet.StandardPrice)*parseFloat($($("input[@name='Amount']",$(sourcex).parent().parent())).val());
    var sumMoney=fltMul(data.BaseBusinessTypePriceSet.StandardPrice,$($("input[@name='Amount']",$(sourcex).parent().parent())).val());
    $("input[@name='txtSumMoney']",$(sourcex).parent().parent()).val(sumMoney);
    $("td[@name='sumMoney']",$(sourcex).parent().parent()).text(FormatMoney(sumMoney,2));
    if(source){
        $("#btn").click();
    }
}

var isDepreciate='false';
function modifyPrice(o,t)
{
    var returnVal='false';
    switch(position)
    {
        case master:
        case manager:
        default:
            returnVal='true';
            break;
        //default:
            //returnVal=accredit(t);
            //isDepreciate=returnVal;
            //break;
        
    }    
    if(returnVal=='true')
    {
        $($("input",$(o).parent())[0]).val($(o).text());
        $(o).hide();
        $($("input",$(o).parent())[0]).show();
        $($("input",$(o).parent())[0]).focus();
        $($("input",$(o).parent())[0]).select();
    }
   
}
function modifyPriceOnKeydown(o,e){
    //var e=e|| event;//IE下支持，Firefox下不支持---张晓林
    if(e.keyCode==13)
    {
        //checkDbl(objTemp,blnEmpty,maxLen) 
        if(checkOnlyNum($(o),false,10))
        {
            var amountObj=$($("input[@name=Amount]",$(o).parent().parent())[0]);
            if(!checkOnlyNum($(amountObj),false,9))
            {
                //alert("请先输入数量!");
                $($("td[@name=sumMoney]",$(o).parent().parent())[0]).focus();
                $($("td[@name=sumMoney]",$(o).parent().parent())[0]).select();
                return false;
            }
            switch(position)
            {
                case master:
                case manager:
                    break;
                default:
                    if(parseFloat($($("input[@name='strPrice']",$(o).parent().parent())[0]).val())>parseFloat($(o).val()))
                    {
                        if(isDepreciate=='false')
                        {
                            var returnValue='false';
                            returnValue=accredit();
                            
                            if(returnValue!='true')
                            {
                                $($("a",$(o).parent())[0]).show();
                                $($("a",$(o).parent())[0]).text($($("input[@name='strPrice']",$(o).parent().parent())[0]).val());
                                $($("td[@name=sumMoney]",$(o).parent().parent())[0]).text(fltMul($($("input[@name='strPrice']",$(o).parent().parent())[0]).val(),$(amountObj).val()));
                                //$($("input[@name='strPrice']",$(o).parent().parent())[0]).val($(o).val());
                                $($("input[@name='txtSumMoney']",$(o).parent().parent())[0]).val($(o).val());
                                $(o).hide();
                                alert("对不起,您没有权限降价!");
                                return false;
                            }

                        }
                    }
                    break;
            }
            //判断输入价格的格式是否合法 张晓林 2010年4月9日13:07:34
            var inputPrice=$(o).val();
            var indexB=inputPrice.indexOf(".");
            inputPrice=inputPrice.substring(indexB+1,inputPrice.length);
            if(-1!=indexB && 2<inputPrice.length){ alert("价格小数位不能超过三位!");$(o).select();return false;}
            $($("a",$(o).parent())[0]).show();
            $($("a",$(o).parent())[0]).text($(o).val());
            $($("td[@name=sumMoney]",$(o).parent().parent())[0]).text(fltMul($(o).val(),$(amountObj).val()));
            $($("input[@name='strPrice']",$(o).parent().parent())[0]).val($(o).val());
            $($("input[@name='txtSumMoney']",$(o).parent().parent())[0]).val(parseFloat($(o).val())*parseFloat($(amountObj).val()));
            
            $(o).hide();
        }
        return false;
    }
}
//获取动态因素
function doProcess(sourceSelect)
{
    $(sourceSelect).attr("disabled",true);
    var sltArr=$("select",$(sourceSelect).parent().parent());
        
    for(var i=0;i<sltArr.length;i++)
    {
        if(sltArr[i].id!="sltBusinessType" && sltArr[i].id!="sltBusinessType1")
        {
            //$(sltArr[i]).parent().text("-");
            $(sltArr[i]).remove();
        }
    }

    if (sourceSelect.value == -1) {
        var currentTr = $(sourceSelect).parent().parent();
        var pos = $(".no", currentTr).html();
        clearTrContext($("td",currentTr));
        if($(sourceSelect).attr("disabled"))
        {
            $(sourceSelect).attr("disabled",false);
        }
        return;
    }
    
    var provider = {};
    provider.source1 = sourceSelect;
    provider.process = function(json) {
        window.processJson(json, provider.source1);
    };
    source = sourceSelect;
    var url = "../ajax/AjaxEngine.aspx" + "?businessTypeId=" + sourceSelect.value;

    $.getJSON(url, {a : '2'}, provider.process);
    $(sourceSelect).attr("disabled",false);
    
}

//function reBuildTableHeader(data,sourceSelect)
//{
//    var tableHeader=$('tr:first-child',$(sourceSelect).parent().parent().parent());
//    
//    var trHeader="<tr><th nowrap='nowrap' class='w1'>&nbsp;NO&nbsp;</th><th nowrap='nowrap' class='w1'>&nbsp;业务类型&nbsp;</th>";
//    
//    for(var i=0;i<data.PriceFactor.length;i++)
//    {
//        trHeader+="<th nowrap='nowrap' class='w1' index='"+(i+2)+"id='th"+ data.PriceFactor[i].Id +"'>&nbsp;"+data.PriceFactor[i].DisplayText+"&nbsp;</th>";
//        
//        //$('<th>'+ data.PriceFactor[i].DisplayText +'</th>').insertAfter($("th",tableHeader)[1+i]);
//    }
//    
//    
////    <th nowrap="nowrap" class="w1" index="<%=i+2 %>" id="th<%=newOrderAction.Model.PriceFactor[i].Id %>">
////                &nbsp;<%=newOrderAction.Model.PriceFactor[i].DisplayText%>&nbsp;</th>
//    
//    trHeader+="<th nowrap='nowrap' class='w1'>&nbsp;数量&nbsp;</th><th nowrap='nowrap' class='w1'>&nbsp;单价&nbsp;</th><th nowrap='nowrap' class='w1'>&nbsp;金额&nbsp;</th><th align='left' nowrap='nowrap'>制作要求</th><th nowrap='nowrap' class='w1'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th></tr>"
//    $(tableHeader).html(trHeader);

//}


function processJson(json, sourceSelect){
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }
    //reBuildTableHeader(data,sourceSelect);
    var currentProcessTr = $(sourceSelect).parent().parent();
    var currentRowNumber=$($("TD",currentProcessTr)[0]).text();
    //var pos = $(".no", currentProcessTr).html();
    clearTrContext($("td",currentProcessTr));
    var currentColumnIndex = 2;
    for (var i = 0; i < data.PriceFactor.length; i++) {
        var pf = data.PriceFactor[i];
        var th = $("#th" + pf.Id);
        if(undefined!=th.attr("index"))
        {
            currentColumnIndex=th.attr("index");
        }
        else
        {
            continue;
        }
        var currentCell = $($("td",currentProcessTr)[currentColumnIndex]);
        currentCell.html("");
        
        //var currentCell=$("<td></td>");
        
        var select = $("<select name="+currentRowNumber+pf.Id+"f id="+currentRowNumber+"x"+pf.Id+" onchange='doRelationFactor(this);' ><option value='-1' selected='selected'>请选择</option></select>");
        
        
        for (var j = 0; j < pf.FactorValueList.length; j++){
            var fv = pf.FactorValueList[j];
            $("<option value='" + fv.Id + "'>" + fv.Text + "</option>").appendTo(select);
        }
        $(select).attr("value","-1");
        
        select.appendTo(currentCell);
        currentColumnIndex++;
    }
    //$(currentProcessTr).focus();
}

function clearTrContext(tr) {
    var begin = 2;
    for (var i = 0; i < factorCount; i++) {
        $(tr[begin + i]).html("-");
    }    
}

//获取因素的制约关系
function doRelationFactor(sourceSlt)
{
    if(sourceSlt.value==-1) return;
    $(sourceSlt).attr("disabled",true);
    var currentProcessTr = $(sourceSlt).parent().parent();
    var currentRowNumber=$($("TD",currentProcessTr)[0]).text();
    
    var businessTypeId=$("select[@name='BusinessType']")[currentRowNumber-1].value;
    var nextSltId=parseInt(sourceSlt.id)+1;
    


    var provider = {};
    provider.source1 = currentRowNumber;
    provider.process = function(json) {
        window.processRelationFactor(json, provider.source1);
    };
    //source = sourceSlt;
    var url = "../ajax/AjaxEngine.aspx" + "?businessTypeId=" + businessTypeId+"&PriceFactorId="+(sourceSlt.id.split('x'))[1]+"&SourceValue="+sourceSlt.value;

    $.getJSON(url, {a : '2'}, provider.process);
    $(sourceSlt).attr("disabled",false);

}
function processRelationFactor(json,currentRowNumber)
{
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }    
    //var factorValueList=data.PriceFactor[0].FactorValueList;
    var priceFactor=data.PriceFactor;
    
    //如果找到制约因素的值，则添加，否则，默认为全部
   
    for(var i=0;i<priceFactor.length;i++)
    {
        var obj=priceFactor[i];
        
        if(obj.FactorValueList.length>0)
        {
            $("#"+currentRowNumber+"x"+obj.Id).html("<option value='-1' selected=true>请选择</option>");
            for(var j=0;j<obj.FactorValueList.length;j++)
            {
                $("<option value='" + obj.FactorValueList[j].Id + "'>" + obj.FactorValueList[j].Text + "</option>").appendTo($("#"+currentRowNumber+"x"+obj.Id));
            }
            $($('option',$("#"+currentRowNumber+"x"+obj.Id))[0]).attr('selected',true);
        }
    }
}
//功能:新增一条业务明细
//作者:
//日期:
function addRow() {
    
    var table = $("#tbOrderItem");
    var lastIndex = $("td:first-child", $("tr:last-child", table)).html();
    var tr = $("<tr>" + trHtmlText + "</tr>");
    var sltArr=$("select",tr);
    var txtArr=$("input:text",tr);
    var hiddenArr=$("input:hidden[type!='button']",tr);
    var tdArr=$("td",tr);
    for(var i=0;i<sltArr.length;i++)
    {
        $(sltArr[i]).attr("value","-1");
    }
    for(var i=0;i<txtArr.length;i++)
    {
        $(txtArr[i]).attr("value","");
    }
    for(var i=0;i<hiddenArr.length;i++)
    {
        $(hiddenArr[i]).attr("value","");
    }
    var i;
    for(i=2;i<tdArr.length-2;i++)
    {
        $(tdArr[i]).text("-");
    }
    $(tdArr[i-3]).html("<input type='text' name='Amount' style='text-align:right' maxlength='9'size='10'/>");
    $(tdArr[tdArr.length-2]).html("<a href='#' onclick='showPrintRequest(this);'>选择</a><input id='factorid1' name='txtFactorId1' type='hidden' /><input id='factorvalue1' name='txtFactorValue1' type='hidden' /><input id='printRequest1' name='txtPrintRequest1' type='hidden' /><input type='hidden' name='strPrice' /><input type='hidden' name='txtSumMoney' /><input type='hidden' name='priceFactorId1' id='txtPriceFactorId1' /><input type='hidden' name='PriceId' id='txtPriceId1' /><input type='hidden' name='printDemandMemo' /></td>");
    tr.appendTo(table);
    $(tr.children()[0]);
    lastIndex = parseInt(lastIndex) + 1;
    $("td:first-child", $("tr:last-child", table)).html(lastIndex);
    
    var inputHideArr=$("input:hidden",tr);
    $(inputHideArr[1]).attr("id","factorid"+lastIndex);
    $(inputHideArr[1]).attr("name","txtFactorId"+lastIndex);
    $(inputHideArr[2]).attr("id","factorvalue"+lastIndex); 
    $(inputHideArr[2]).attr("name","txtFactorValue"+lastIndex);
    $(inputHideArr[3]).attr("id","printRequest"+lastIndex);
    $(inputHideArr[3]).attr("name","txtPrintRequest"+lastIndex);    
    $(inputHideArr[6]).attr("id","txtPriceFactorId"+lastIndex);
    $(inputHideArr[6]).attr("name","priceFactorId"+lastIndex);  
    $(inputHideArr[7]).attr("id","txtPriceId"+lastIndex);
    //$(inputHideArr[6]).attr("name","PriceId"+lastIndex);
}

//功能: 删除业务明细
//作者:
//日期:
function delRow(button) {
    var table = $("#tbOrderItem");
    if ($("tr", table).length <= 2) return;
    $(button).parent().parent().remove();
    refreshRowNo();
    
}
function refreshRowNo() {
    var table = $("#tbOrderItem");
    var trs = $("tr", table);
    trs.each(function(i){
        if (i == 0) return;
        $("td:first-child", $(this)).html(i);
        var hiddenTxt=$("input:hidden[@name!='Amount']",this);
        $(hiddenTxt[2]).attr("id","factorid"+i);
        $(hiddenTxt[2]).attr("name","txtFactorId"+i);
        $(hiddenTxt[3]).attr("id","factorvalue"+i);
        $(hiddenTxt[3]).attr("name","txtFactorValue"+i);
        $(hiddenTxt[4]).attr("id","printRequest"+i);
        $(hiddenTxt[4]).attr("name","txtPrintRequest"+i);    
        $(hiddenTxt[7]).attr("id","txtPriceFactorId"+i);
        $(hiddenTxt[7]).attr("name","priceFactorId"+i);
        $(hiddenTxt[8]).attr("id","txtPriceId"+i);       
    });
}
//Modify:Cry,Date:2008-12-29 添加参数2,时候自动提交
function hideControl(button,submit)
{
    var lastIndex=parseInt($($("td",$(button).parent().parent())[0]).text());
    
    //var table = $("#tbOrderItem");
    //var lastIndex = $("td:first-child", $("tr:last-child", table)).html();
    //lastIndex = parseInt(lastIndex);

    var sltArr=$("select",$(button).parent().parent());
    for(var i=0;i<sltArr.length;i++)
    {
        if(sltArr[i].options[sltArr[i].selectedIndex].value==-1)
        {
            if(sltArr[i].name=="BusinessType")
            {
                alert("请您选择业务类型!!!");
                sltArr[i].focus();
                return ;
            }
            else
            {
                alert('请您选择制作条件!!!');
                sltArr[i].focus();
                return;

            }
        }
    }
    
    //return checkDbl($($("input[@name='Amount']",$(button).parent().parent())[0]),false,9);

    if($("input[@name='Amount']",$(button).parent().parent()).val()=="")
    {
        alert("请输入数量!!!");
        $("input[@name='Amount']",$(button).parent().parent())[0].focus();
        $("input[@name='Amount']",$(button).parent().parent())[0].select();
        return;
    }
    else
    {
        if(!isNumberDbl($("input[@name='Amount']",$(button).parent().parent()).val()))
        {
            alert("数量不能为负数!");
            $("input[@name='Amount']",$(button).parent().parent()).focus();
            $("input[@name='Amount']",$(button).parent().parent()).select();
            return;
        }
        if(!isNumberInt($("input[@name='Amount']",$(button).parent().parent()).val()))
        {
            alert("请输入有效的数!");
            $("input[@name='Amount']",$(button).parent().parent()).focus();
            $("input[@name='Amount']",$(button).parent().parent()).select();
            return;
        }
    }
    //输入了，但不是数字
    //else if()
    
    $("span",$(button).parent().parent()).remove();
    var strFactorId="";
    var strFactorValue="";
    var strPriceFactorId="";
    for(var i=0;i<sltArr.length;i++)
    {
        var strTmp='<span>'+sltArr[i].options[sltArr[i].selectedIndex].text+'</span>';
        $(strTmp).appendTo(sltArr[i].parentNode);
        $(sltArr[i]).hide();
        if("BusinessType"==sltArr[i].name) continue;
        strFactorId+=sltArr[i].options[sltArr[i].selectedIndex].value+',';
        strFactorValue+=sltArr[i].options[sltArr[i].selectedIndex].text+',';
        strPriceFactorId+=parseInt((sltArr[i].id.split('x'))[1]).toString()+',';

        //sltArr[i].parentNode.value=sltArr[i].options[sltArr[i].selectedIndex].text;
    }
    var txtArr=$("input[@type='text']",$(button).parent().parent());
    for(var i=0;i<txtArr.length;i++)
    {
        var strTmp='<span>'+txtArr[i].value+'</span>';
        $(strTmp).appendTo(txtArr[i].parentNode);
        $(txtArr[i]).hide();
    
    }
    $("#txtPriceFactorId"+lastIndex).val(strPriceFactorId);
    $("#factorid"+lastIndex).val(strFactorId);
    $("#factorvalue"+lastIndex).val(strFactorValue);
    
    $("select",sltArr).hide();
    $("input[@type='text']",$(button).parent().parent()).hide();
        
    $($("input",$(button).parent())[1]).show();
    $(button).hide();
    
    var aArr=$("a[@name=modifyPrice]",$(button).parent().parent());
    if(aArr.length>0)
        $(aArr[0]).hide();

    
    $("#txtRowNo").val(lastIndex);
    
    doPrice(button,submit);
    
    //addRow();
}
//功能: 编辑业务明细
//作者:
//日期:
function editOrderItem(button)
{
    var lastIndex=parseInt($($("td",$(button).parent().parent())[0]).text());

    var sltArr=$("select",$(button).parent().parent());
    var spArr=$("span",$(button).parent().parent());
//    var aArr=$("a[@name=modifyPrice]",$(button).parent().parent());
//    if(aArr.length>0)
//        $(aArr[0]).hide();
    $(spArr).hide();
    //$("span",spArr).hide();
    $($("input[@name='unitPrice']",$(button).parent().parent())).val(0);
    $($("input[@name='txtSumMoney']",$(button).parent().parent())).val(0);
    $($("input[@name='strPrice']",$(button).parent().parent())).val(0);
    
    $($("a[@name=modifyPrice]",$(button).parent().parent())).text(0);
    $(button).parent().prev().prev().text(0);

    $("#Price"+lastIndex).attr("value","");
    $("#factorid"+lastIndex).attr("value","");
    $("#factorvalue"+lastIndex).attr("value","");
    $("#txtPriceFactor"+lastIndex).attr("value","");
    
    for(var i=0;i<sltArr.length;i++)
    {
        $(spArr[i]).hide();
        $(sltArr[i]).show();
    }
    
    $($("input",$(button).parent())[0]).show();
    
    $("input[@type='text']",$(button).parent().parent()).show();
    $("input[@name='unitPrice']",$(button).parent().parent()).hide();
    $(button).hide();
}

//功能: 开单数据验证
//作者: 付强
//日期: 
function orderDataCheck(o){
    if(""==$('#txtCustomerName').val()){
        alert('客户名称不能为空!');
        $('#txtCustomerName').focus();
        $('#txtCustomerName').select();
        return false;
    }
    if($('#ckNeedPrepareMoney')[0].checked){
        if(""==$('#txtPrepayMoney')[0].value){
            alert('您已经选择了预付款，所以预付款不能为空！');
            $('#txtPrepayMoney').focus();
            $('#txtPrepayMoney').select();
            return false;
        }
        else{
            if(parseFloat($('#txtPrepayMoney').val())<=0){
                alert('预收款不能小于或等于 0');
                $('#txtPrepayMoney').focus();
                $('#txtPrepayMoney').select();
                return false;
            }
           if(!checkOnlyNum($('#txtPrepayMoney'),false,14)){
                $('#txtPrepayMoney').focus();
                $('#txtPrepayMoney').select();
                return false;
           }
        }
    }
    if($("#cbDeliveryType").val()==delivery){
        if($("#txtDeliveryDateTime").val().length<=0){
            alert('请您选择送取货时间!!!');
            $("#txtDeliveryDateTime").focus();
            $("#txtDeliveryDateTime").select();
            return false;
        }
        if(!isDateTime($("#txtDeliveryDateTime").val())){
            $("#txtDeliveryDateTime").focus();
            return false;
        }
    }
    if($("#cbDeliveryType").val()==self){
        if($("#txtDeliveryDateTime").val().length>0){
            if(!isDateTime($("#txtDeliveryDateTime").val())){
                $("#txtDeliveryDateTime").focus();
                return false;
            }
        }
    } 
    if($("textarea[@name='Memo']")[0].value.length>200){
        alert("您输入的备注太长!!!");
        $($("textarea[@name='Memo']")[0]).select();
        $($("textarea[@name='Memo']")[0]).focus();
        return false;
    }
    var operateType=$(o).attr("value");
    if("打印订单"==operateType){
        var sltArr=$("select",$());
        for(var i=0;i<sltArr.length;i++){
            if(-1==sltArr[i].selectedIndex) continue;
            if(sltArr[i].options[sltArr[i].selectedIndex].value==-1){
            
                if(sltArr[i].name=="BusinessType"){
                    alert("请您选择业务类型!!!");
                    sltArr[i].focus();
                    return false;
                }
                else{
                    alert('请您选择制作条件!!!');
                    sltArr[i].focus();
                    return false;

                }        
            }
        }
        var amntArr=$("input[@name='Amount']");
        for(var i=0;i<amntArr.length;i++){
            amountInput=$("input[@name='Amount']")[i].value;
            if(amountInput==""){
                alert("请输入数量!!!");
                $("input[@name='Amount']")[i].select();
                $("input[@name='Amount']")[i].focus();
                return false;
            }
            else if(0>parseFloat(amountInput) || 0==parseFloat(amountInput)){
                try{
                alert("数量不能小于等于0!!!");
                $("input[@name='Amount']")[i].select();
                $("input[@name='Amount']")[i].focus();
                return false;
                }catch(e){
                    return false;
                }
            }
            else{
                var btn=$($("input[@name='Amount']")[i]);
                if(!checkOnlyNum(btn,false,14)){
                    return false;
                }
            }
        }
    }
    var priceArr=$("input[@name='strPrice']");
    var sumAmountArr=$("input[@name='txtSumMoney']");
    
    for(var i=0;i<priceArr.length;i++){
        //if(priceArr[i].value=="" || parseFloat(priceArr[i].value)==-1 || parseFloat(priceArr[i].value)==0)
        if(parseFloat(priceArr[i].value)==-1 )//开单时,价格可以没有,可以为0,但不能为 -1
        {
            $(priceArr[i]).val(0);
            $(sumAmountArr[i]).val(0);
            //alert("没有找到相应价格!!!");
            //return false;
        }
    }
//    var btnObj=$("input:button[@name='btnOrderItemOk']");
//    for(var i=0;i<btnObj.length;i++)
//    {
//        if(btnObj[i].style.display=="")
//        {
//            alert("请先确认第 "+ (i+1) +" 个订单明细!!!")
//            $(btnObj[i]).focus();
//            return false;
//        }
//    }

  //  $("#HiddAction").val("Yes");
  //  $("#btnDispatchAndPrint2").attr("disabled",true);
  //  $("#btnDispatchAndPrint1").attr("disabled",true);
  //  $("#orderFrom").submit();
    return true;
}

function realOrderDataCheck()
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
    if($("#cbDeliveryType").val()==delivery)
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
    if($("#cbDeliveryType").val()==self)
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
    $("#Action").val("Save");
    $("#btnSave").attr("disabled",true);
    $("#form").submit();
    return true;
}
function deliveryDateTime()
{
    //if($("#cbDeliveryType")[0].options[$("#cbDeliveryType").attr("selectedIndex")].value==2)
    if($("#cbDeliveryType").val()==wait)
    {
        $("#txtDeliveryDateTime").hide();
    }
    else
    {
        $("#txtDeliveryDateTime").show();
    }
}

//预付款
function prePay()
{
    if($("#ckNeedPrepareMoney").attr("checked"))
    {
        $('#txtPrepayMoney').show();
    }
    else
    {
        $('#txtPrepayMoney').val("");
        $('#txtPrepayMoney').hide();
    }
}

var aObj;
function showPrintRequest(aPrintRequest)
{
	aObj=aPrintRequest;
	showPage('PrintRequest.aspx', null, 800, 485, false, false);
}
function getPrintRequest()
{
    var returnValue=new Object();
    var strDetailId = $($("input:hidden",$(aObj).parent())[2]).attr("value");
    var printDemandMemo=$("input:hidden[@name=printDemandMemo]",$(aObj).parent()).val();
    if(!strDetailId) 
    {
        returnValue.IdArr=null;
    }
    else
    {
        returnValue.IdArr=strDetailId.split(",");
    }
    if(!printDemandMemo)
    {
        returnValue.Memo="";
    }
    else
    {
        returnValue.Memo=printDemandMemo;
    }
    return returnValue;
}

function setPrintRequest(demands,memo)
{
    if (demands.length ==0 && memo=="") {
        //$(aObj).attr("innerText","选择");
        $(aObj).text("选择");
        $($("input:hidden",$(aObj).parent())[2]).attr("value","");
        aObj=null;
        return;
    }
    else
    {
        var strRequest="";
        var strId="";
        for(var i=0;i<demands.length;i++)
        {
            if(i<demands.length)
            {
                strRequest+=demands[i].name+" ";
                strId+=demands[i].id.toString()+",";
            }
            else
            {
                strRequest+=demands[i].name;
                strId+=demands[i].id.toString();
            }
        }
        //$(aObj).attr("innerText",strRequest);
        $(aObj).text(strRequest+memo);
        $($("input:hidden",$(aObj).parent())[2]).attr("value",strId);
        $("input:hidden[@name=printDemandMemo]",$(aObj).parent()).attr("value",memo);
    }
}
///返回
function selectCustomer(objCustomer)
{
    if(objCustomer==null) return;
    $("#customerid").attr("value",objCustomer.Id);
    //不直接带出会员卡，需要客户报卡号输入,防止会员卡号被窃取
    //$("#txtMemberCardId").attr("value",objCustomer.MemeberCardId);
    //$("#txtMemberCardNo").attr("value",objCustomer.MemberCardNo);
    $("#txtMemberCardId").attr("value","-1");
    $("#txtMemberCardNo").attr("value","");
    
    $("#txtTradeId").attr("value",objCustomer.TradeId);
    $("#txtCustomerName").attr("value",objCustomer.Name);
    $("#txtName").attr("value",objCustomer.LinkMan);
    $("#telNo").attr("value",objCustomer.TelNo);
    $("#txtMemo").attr("value",objCustomer.Memo);
    $("#ckNeedTicket").attr("checked",false);
    $("#cbDeliveryType").attr("value",1);
    $("#ckNeedPrepareMoney").attr("checked",false);
    $("#txtPrepayMoney").val("");
    $("#txtDeliveryDateTime").val("");
    for(var i=0;i<$("#cbCustomerType").attr("length");i++)
    {
        var options=$("option",$("#cbCustomerType"));
        if(objCustomer.CustomerType==$("#cbCustomerType")[0].options[i].text)
        {
            $("#cbCustomerType")[0].options[i].selected=true;
            break;
        }
    }
    for(var i=0;i<$("#cbPaymentType").attr("length");i++)
    {
        //var options=$("option",$("#cbPaymentType"));
        if(objCustomer.PaymentType==$("#cbPaymentType")[0].options[i].text)
        {
            $("#cbPaymentType")[0].options[i].selected=true;
            break;
        }
    }
    if(objCustomer.NeedTicket=="需要")
    {
        $("#ckNeedTicket").attr("checked",true);
        
    }
    else
    {
        $("#ckNeedTicket").attr("checked",false);
    }
    if($("#tr2").html()!="")
    {
        trDetailHtmlX=$("#tr2").html();
        trDetailHtmlY="<tr id='trHello'>"+trDetailHtmlX+"</tr>";
    }
    else
    {
        trDetailHtmlX=$("#trHello").html();
        trDetailHtmlY="<tr id='trHello'>"+trDetailHtmlX+"</tr>";
    }
    var btnArr=$("input:button[@value=编辑]");
    for(var i=0;i<btnArr.length;i++)
    {
        if($(btnArr[i]).css("display")=="inline")
        {
            var trObj=$(btnArr[i]).parent().parent()
            if(i==0)
            {
                editOrderItem(btnArr[i]);
                var sltObj=$("select",trObj);
                if(0<sltObj.length)
                {
                    $(sltObj[0]).attr("selectedIndex",0);
                    doProcess(sltObj[0]);
                    $("input[@name=Amount]",trObj).val("");
                    $($("td",trObj)[$("td",trObj).length-4]).text("");
                    $($("td",trObj)[$("td",trObj).length-3]).text("选择");
                }
            }
            else
            {
                $(trObj).remove();
            }
        }
    }
}


function showSelectCustomer(){
    var customerName=$("#txtCustomerName").val();
	showPage('../customer/SelectCustomer.aspx?customerName='+escape(customerName),null,900,600,false,false);
}

function showNewCustomer(){
	showPage('../customer/NewCustomer.aspx?Tag=2',null,890,566,false,false);
}

function getCustomerInfo(e,o)
{
    var memberNo=$(o).val();
    if(null==memberNo || ""==memberNo) 
    {
        clearContent();
        return;
     }

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
        clearContent();
        return;
    }
    if(null==data.MemberCard) 
    {
        alert("您输入的卡号有误或未启用!");
        clearContent();    
        $("#txtMemberCardNo").focus();
        $("#txtMemberCardNo").select();
        return;
    }
    $("#customerid").attr("value",data.MemberCard.CustomerId);
    $("#txtMemberCardId").attr("value",data.MemberCard.Id);
    $("#txtMemberCardNo").attr("value",data.MemberCard.MemberCardNo);
    $("#txtTradeId").attr("value",data.MemberCard.TradeId);
    $("#txtCustomerName").attr("value",data.MemberCard.CustomerName);
    $("#txtName").attr("value",data.MemberCard.LinkManName);
    $("#telNo").attr("value",data.MemberCard.TelNo);
    $("#txtMemo").attr("value",data.MemberCard.CustomerMemo);
    $("#ckNeedTicket").attr("checked",false);
    var options=$("#cbCustomerType")[0].options;
    for(var i=0;i<options.length;i++)
    {
        if(parseInt($(options[i]).val())==data.MemberCard.CustomerTypeId)
        {
            $(options[i]).attr("selected","selected");
            break;
        }
    }
    options=$("#cbPaymentType")[0].options;
    for(var i=0;i<options.length;i++)
    {
        if(parseInt($(options[i]).val())==data.MemberCard.PayType)
        {
            $(options[i]).attr("selected","selected");
            break;
        }
    }
    if("Y"==data.MemberCard.NeedTicket.toUpperCase())
    {
        $("#ckNeedTicket").attr("checked",true);
    }
    if($("#tr2").html()!="")
    {
        trDetailHtmlX=$("#tr2").html();
        trDetailHtmlY="<tr id='trHello'>"+trDetailHtmlX+"</tr>";
    }
    else
    {
        trDetailHtmlX=$("#trHello").html();
        trDetailHtmlY="<tr id='trHello'>"+trDetailHtmlX+"</tr>";
    }
    //删除订单明细
    var btnArr=$("input:button[@value=编辑]");
    for(var i=0;i<btnArr.length;i++)
    {
        if($(btnArr[i]).css("display")=="inline")
        {
            var trObj=$(btnArr[i]).parent().parent()
            if(i==0)
            {
                editOrderItem(btnArr[i]);
                var sltObj=$("select",trObj);
                if(0<sltObj.length)
                {
                    $(sltObj[0]).attr("selectedIndex",0);
                    doProcess(sltObj[0]);
                    $("input[@name=Amount]",trObj).val("");
                    $($("td",trObj)[$("td",trObj).length-4]).text("-");
                    $($("td",trObj)[$("td",trObj).length-3]).text("-");
                    //删除印制要求
                    $("a",$($("td",trObj)[$("td",trObj).length-2])).text("选择");
                }
            }
            else
            {
                $(trObj).remove();
            }
        }
    }
    var txtFactorId=$("input:hidden[@name=txtFactorId1]")
    for(var i=0;i<txtFactorId.length;i++)
    {
        $(txtFactorId[i]).val("");
    }
    var txtFactorValue=$("input:hidden[@name=txtFactorValue1]")
    for(var i=0;i<txtFactorValue.length;i++)
    {
        $(txtFactorValue[i]).val("");
    }
    var txtPrintRequest=$("input:hidden[@name=txtPrintRequest1]")
    for(var i=0;i<txtPrintRequest.length;i++)
    {
        $(txtPrintRequest[i]).val("");
    }
    var strPrice=$("input:hidden[@name=strPrice]")
    for(var i=0;i<strPrice.length;i++)
    {
        $(strPrice[i]).val("");
    }
    var txtSumMoney=$("input:hidden[@name=txtSumMoney]")
    for(var i=0;i<txtSumMoney.length;i++)
    {
        $(txtSumMoney[i]).val("");
    }
    var priceFactorId1=$("input:hidden[@name=priceFactorId1]")
    for(var i=0;i<priceFactorId1.length;i++)
    {
        $(priceFactorId1[i]).val("");
    }
    
    $("input:hidden[@name=printDemandMemo]").val("");
}

function clearContent(value)
{
    $("#txtMemberCardId").attr("value","");
    $("#txtMemberCardNo").attr("value","");
    if(value!=null){
        $("#txtName").attr("value",value);
    }
    else{
        $("#txtCustomerName").attr("value","");
        $("#txtName").attr("value","");
    }
    $("#customerid").attr("value","");
    $("#txtMemo").attr("value","");
    $("#txtTradeId").attr("value","");
    $("#telNo").attr("value","");
    $("#cbCustomerType").attr("value",1);
    $("#cbPaymentType").attr("value",1);
    $("#ckNeedTicket").attr("checked",false);
    $("#cbDeliveryType").attr("value",1);
    $("#ckNeedPrepareMoney").attr("checked",false);
    $("#txtPrepayMoney").val("");
    $("#txtDeliveryDateTime").val("");
    //删除订单明细
    var btnArr=$("input:button[@value=编辑]");
    for(var i=0;i<btnArr.length;i++)
    {
        if($(btnArr[i]).css("display")=="inline")
        {
            var trObj=$(btnArr[i]).parent().parent()
            if(i==0)
            {
                editOrderItem(btnArr[i]);
                var sltObj=$("select",trObj);
                if(0<sltObj.length)
                {
                    $(sltObj[0]).attr("selectedIndex",0);
                    doProcess(sltObj[0]);
                    $("input[@name=Amount]",trObj).val("");
                    $($("td",trObj)[$("td",trObj).length-4]).text("-");
                    $($("td",trObj)[$("td",trObj).length-3]).text("-");
                    //删除印制要求
                    $("a",$($("td",trObj)[$("td",trObj).length-2])).text("选择");

                }
            }
            else
            {
                $(trObj).remove();
            }
        }
    }
    var txtFactorId=$("input:hidden[@name=txtFactorId1]")
    for(var i=0;i<txtFactorId.length;i++)
    {
        $(txtFactorId[i]).val("");
    }
    var txtFactorValue=$("input:hidden[@name=txtFactorValue1]")
    for(var i=0;i<txtFactorValue.length;i++)
    {
        $(txtFactorValue[i]).val("");
    }
    var txtPrintRequest=$("input:hidden[@name=txtPrintRequest1]")
    for(var i=0;i<txtPrintRequest.length;i++)
    {
        $(txtPrintRequest[i]).val("");
    }
    var strPrice=$("input:hidden[@name=strPrice]")
    for(var i=0;i<strPrice.length;i++)
    {
        $(strPrice[i]).val("");
    }
    var txtSumMoney=$("input:hidden[@name=txtSumMoney]")
    for(var i=0;i<txtSumMoney.length;i++)
    {
        $(txtSumMoney[i]).val("");
    }
    var priceFactorId1=$("input:hidden[@name=priceFactorId1]")
    for(var i=0;i<priceFactorId1.length;i++)
    {
        $(priceFactorId1[i]).val("");
    }
    $("input:hidden[@name=printDemandMemo]").val("");
}

function accredit()
{
    var url="../finance/Accredit.aspx?AccreditTypeKey="+escape(accreditTypeKey)+"&AccreditTypeText="+escape(accreditTypeText)+"&AccreditTypeId="+escape(accreditTypeId);
    return showPage(url,null,280,500,false,true,false,false);
}

//用户控件的初始话.用于判断用户选择时间不能比当前时间小
//Author:Cry Date:2008-12-27
setDayInit=function(o){
    var provider = {};
    provider.par=o;
    provider.process = function(date) {
        getServerDate(date,provider.par);
    };
    $.getJSON("../ajax/AjaxEngine.aspx", {a : '20'},provider.process);
}
getServerDate=function(date,o){
    if(typeof date=='string'){
        setTime(o,o,true,false,date);
    }
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


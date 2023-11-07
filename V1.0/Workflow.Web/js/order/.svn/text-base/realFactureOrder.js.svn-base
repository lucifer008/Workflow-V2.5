// 名    称: realFactureOrder.js
// 功能概要: 修正加工单 Js
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

        if($("#cbDeliveryType")[0].options[$("#cbDeliveryType")[0].selectedIndex].value!=wait)
        {
            $("#txtDeliveryDateTime").show();
        }
        else
        {
            $("#txtDeliveryDateTime").hide();
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
    disableButton();
}

function deleteOneOrderitem(o)
{
    delRow(o);
    disableButton();
}
function orderItemEdit(o)
{
    editOrderItem(o);
    disableButton();
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
    //Flag 1:本日工单中的分配；2:开单中的总体分配 3:每一个工单明细中的分配 4:修正加工单后重新调整前后期
    showPage('DispatchOrder.aspx?strNo='+strNo+'&Flag=4', null, 410, 465, false, false);
}

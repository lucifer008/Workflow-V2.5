// JScript 文件


var strOrderNo;
var strCustomerName;
function dispatchOrder(o)
{
    strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    //strCustomerName=$($("td",$(o).parent().parent())[2]).text();
    //Flag 1:本日订单中的分配；2:开单中的总体分配 3:每一个订单明细中的分配 4:修正加订单后重新调整前后期
    showPage('DispatchOrder.aspx?strNo='+strOrderNo+'&Flag=1', null, 420, 465, false, false);

}
function newDispatchOrder(o)
{
    strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    strCustomerName=escape($($("td",$(o).parent().parent())[2]).text());
    showPage('DispatchOrderForOrderItem.aspx?strNo='+strOrderNo+'&strName='+strCustomerName, null, 780, 800, false, false);

}
function prepayOrder(o)
{
    strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    strCustomerName=escape($($("td",$(o).parent().parent())[2]).text());
    showPage('PrepayOrder.aspx?strNo='+strOrderNo+'&strName='+strCustomerName,null,420,370,false,false);
}

function blankOut(o)
{
	strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    strCustomerName=escape($($("td",$(o).parent().parent())[2]).text());
    showPage('BlankOut.aspx?strNo='+strOrderNo +'&strName='+strCustomerName, null, 416, 328, false, false);
}
function finishOrder(o)
{
	strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    strCustomerName=escape($($("td",$(o).parent().parent())[2]).text());
	showPage('Finish.aspx?strNo='+strOrderNo +'&strName='+strCustomerName,null,430,495,false,false);

}
function newFinishOrder(o)
{
	strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    strCustomerName=escape($($("td",$(o).parent().parent())[2]).text());
	showPage('FinishOrderForOrderItem.aspx?strNo='+strOrderNo +'&strName='+strCustomerName,null,800,600,false,false);
}
function redoOrder(o)
{
	strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    strCustomerName=escape($($("td",$(o).parent().parent())[2]).text());
    showPage('Redo.aspx?strNo='+strOrderNo +'&strName='+strCustomerName,null,590,520,false,false);
}
function newRedoOrder(o)
{
	strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    strCustomerName=escape($($("td",$(o).parent().parent())[2]).text());
    showPage('NewReDoOrderForOrderItem.aspx?strNo='+strOrderNo +'&strName='+strCustomerName,null,620,800,false,false);
}
//功能:核对订单
//作者:张晓林
//日期:2010年1月7日14:35:56
function newCheckOrder(o){
    strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());    
	showPage('CheckOrder.aspx?OrderNo='+strOrderNo+"&Action=check" ,null,900,800,false,false);
}

//功能:打印订单
//作者:张晓林
//日期:2010年1月7日14:35:59
function newPrintOrder(o){
    strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());    
	showPage('CheckOrder.aspx?OrderNo='+strOrderNo+"&Action=print" ,null,900,800,false,false);
}
//功能:返回订单
//作者:张晓林
//日期:2010年1月7日14:35:5
function newReturnOrder(o){
     strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());    
	 showPage('CheckOrder.aspx?OrderNo='+strOrderNo+"&Action=return" ,null,900,800,false,false);
}
function deliveryOrder(o)
{
    strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    showPage('Delivery.aspx?strNo='+strOrderNo,null,890,606,false,false);
}


function showRealFacture(o)
{
    strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    
	showPage('NewRealFactureOrder.aspx?strNo='+strOrderNo,null,950,700,false,false);
}

function CancelAfterVerificationOrder(o)
{
	strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    strCustomerName=escape($($("td",$(o).parent().parent())[2]).text());
    showPage('CanceAfterVerificationDelivery.aspx?strNo='+strOrderNo +'&strName='+strCustomerName, null, 406, 328, false, false);
}


function showPatchUpOrder(o)
{
    strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
	showPage('PatchUpOrder.aspx?strNo='+strOrderNo,null,950,700,false,false,true);
}

function showBalanceOrder(o)
{
    strOrderNo=escape($($("td",$(o).parent().parent())[1]).text());
    var customerName=escape($($("td",$(o).parent().parent())[2]).text());
	showPage('../finance/PayForOrder.aspx?strNo='+strOrderNo+'&strName='+customerName,null,950,700,false,false,true);
    
}
function showFilterCondition() {
	showPage('SetDailyOrderDefaultCondition.aspx',null,620,420,false,false);
}

function dataCheck()
{
    if($("#PrepayMoney").val()=="")
    {
       alert("请输入预收金额!");
       $("#PrepayMoney").focus();
       return false;
    }
    //alert()
    if($("#labNo").text()=="")
    {
       alert("请选择收款单号");
       return false;
    }
    confirmvalue=checkOnlyNum($("input:text[@name='PrepayMoney']"),false,14);
    if(confirmvalue!=true)
      return false;       
   
    if (parseFloat($("input:text[@name='PrepayMoney']").val())<0.001)
    {
        alert("预交款金额不正确!!!");
        $("#txtPrepayMoney").select();
        $("#txtPrepayMoney").focus();
        return false;
    }
    var confirmvalue= confirm("确定要交款吗?");
    if(confirmvalue!=true)
      return false;
    return true;
}

function orderDetail(o)
{
    var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
    showPage('../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true,'status:no;');
}
    
///名    称: newOrderFinishCheck
///功能概要: 完工提交验证
///作    者: 付强
///创建时间: 
///修正履历: 修改为兼容其他浏览器--张晓林
///修正时间: 2009年9月3日14:19:13
function newOrderFinishCheck(){
    try{
        var orderItemIdArr=strId.split(',');
        for(var i=0;i<orderItemIdArr.length;i++){
            var isSelected=false;
            var anaphase=$("#anaphase"+orderItemIdArr[i]+" option:selected").text();
            var prophase=$("#prophase"+orderItemIdArr[i]+" option:selected").text();
            if(""==anaphase && ""==prophase){
                alert('每条订单明细至少应该有一个参与者!');
                return false;
            }
        }
        if($("textarea[@name='Memo']").val().length>200){
            alert("您输入的备注太长!");
            $("textarea[@name='Memo']").focus();
            $("textarea[@name='Memo']").select();
            return false;
        }
        $("#btnOk").attr("disabled",true);
        $("#actionTag").val("Finish");
        $("#formFinishOrderForOrderItem").submit();
    }catch(e){}  
    return true;
}
    
function newOrderReDoCheck()
{
//    if($("#sltDutyMan").attr("selectedIndex")<0)
//    {
//        alert("至少应该有一个责任人!");
//        $("#sltDutyMan").focus();
//        return false;
//    }

//    if($("#txtDutyMoney")[0].value=="")
//    {
//        alert("请填写责任金额!");
//        $("#txtDutyMoney").focus();
//        return false;
//    }
//    //checkOnlyNum($("#txtDutyMoney"),false,14)
//    if(!checkOnlyNum($("#txtDutyMoney"),false,14))
//    {
//        return false;
//    }
//    if(parseFloat($("#txtDutyMoney")[0].value)<=0)
//    {
//        alert("责任金额不能小于等于0!");
//        $("#txtDutyMoney").focus();
//        return false
//    }
//    var orderItemIdArr=strId.split(',');
//    for(var i=0;i<orderItemIdArr.length;i++)
//    {
//        if($("#prophase"+orderItemIdArr[i]).attr("selectedIndex")<=0 && $("#anaphase"+orderItemIdArr[i]).attr("selectedIndex")<=0)
//        {
//            alert('每条订单明细至少应该有一个参与者!');
//            return false;
//        }
//    }

    if($("#txtReason").val()=="")
    {
        alert("您还没有填写返回原因!");
        $('#txtReason').val("");
        $('#txtReason').focus();
        //$("#txtReason").val("");
        return false;
    }
    if($("#txtReason").val().length>200)
    {
        alert("您输入的返回原因太长!");
        $("textarea[@name='Memo']").focus();
        $("textarea[@name='Memo']").select();
        return false;
    }  
    return true;
}

 ///名    称: clearSelected
 ///功能概要: 取消选中人员
 ///作    者: 付强
 ///创建时间: 
 ///修正履历:兼容其他浏览器--张晓林
 ///修正时间: 2009年9月3日15:35:53   
function clearSelected(o){
    var objArr=$("select[multiple]",$(o).parent().parent());       
    for(var i=0;i<objArr.length;i++){
        for(var j=0;j<objArr[i].length;j++){
            //$(objArr[i][j]).attr("value","");
            $(objArr[i][j]).attr("selected",false);
        }
    }   
}
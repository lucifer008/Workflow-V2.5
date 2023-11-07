//功能: 发票领取JS  
//作者: 张晓林
//日期: 2009-01-17


//功能: 订单详情  
//作者: 张晓林
//日期: 2009-01-17
function orderDetail(o)
{
    showPage('../order/OrderDetail.aspx?OrderNo='+o, null, 1000, 700, false, true,'status:no;');
}

//功能: 领取验证
//作者: 张晓林
//日期: 2009-01-17
function drawTikcetCheck()
{
    if(!checkTag())
    {
        alert("请选择领取的发票!");
        return false;
    }
    var yes=confirm("确认领取?");
    if(yes)
    {
        $("#btnOk").attr("disabled",true);
        $("#btnCancel").attr("disabled",true);
        $("#Tag").val("True");
        $("#form1").submit();
    }
}
function checkTag()
{
    var seCount=0;
    var orderIdArr=$("input:hidden[name=orderId]");
    for(var i=0;i<orderIdArr.length;i++)
    {
        var orId=$(orderIdArr[i]).val();
        //var cb=$("input:checkbox[@name=cbDrawTicket"+orId+"][checked]");
        var cb=$("#cb"+orId).attr("checked");//$("input:checkbox[@name=cbDrawTicket"+orId+"]");
        if(cb)
        {
            seCount++;
        }
    }
    if(0==seCount)
    {
        return false;
    }   
    return true;
}

//功能: 取消验证
//作者: 张晓林
//日期: 2009-01-17
function cancelTikcetCheck()
{
    if(!checkTag())
    {
        alert("请选择取消的发票!");
        return false;
    }
    var yes=confirm("确认取消?");
    if(yes)
    {
        $("#btnOk").attr("disabled",true);
        $("#btnCancel").attr("disabled",true);
        $("#Tag").val("False");
        $("#form1").submit();
    }
}

//功能: 全部选中checkBox
//作者: 张晓林
//日期: 2009-01-17
function allSelectedClick()
{
    var orderIdArr=$("input:hidden[name=orderId]");
    if($("#cbSelected").attr("checked")){
        for(var i=0;i<orderIdArr.length;i++){
            var orId=$(orderIdArr[i]).val();
            //var cb=$("input:checkbox[@name=cbDrawTicket"+orId+"][@checked='']");
            var cb=$("#cb"+orId).attr("checked");
            if(!cb)
            { 
                $("#cb"+orId).attr("checked",true);
            }   
        }
    }
    else{
        allCancelClick();
    }
}

//功能: 全部取消选中
//作者: 张晓林
//日期: 2009-01-17
function allCancelClick()
{
    var orderIdArr=$("input:hidden[name=orderId]");
    for(var i=0;i<orderIdArr.length;i++)
    {
        var orId=$(orderIdArr[i]).val();
        //var cb=$("input:checkbox[@name=cbDrawTicket"+orId+"][checked]");
        //if(0!=cb.length) $(cb).attr("checked",false);    
        var cb=$("#cb"+orId).attr("checked");
        if(cb)
        { 
            $("#cb"+orId).attr("checked",false);
        }   
    }
}

//功能: 判断领取的发票金额是否超出范围
//作者: 张晓林
//日期: 2009-01-17
function checkInputTicketAmount(o)
{
    var paidTicketAmount=$(o).val();
    var notPaidTicketAmount=$($(o).parent().parent()).find(".notPayTicketAmount").html().replace(',','');//欠票金额
    if(isNaN(paidTicketAmount))
    {
        alert("输入格式错误!");
        $(o).focus();
        $(o).val(notPaidTicketAmount);
        $(o).select();
    }
    if(parseFloat(paidTicketAmount)>parseFloat(notPaidTicketAmount))
    {
        alert("领取金额部能大于实际欠票金额!");
        $(o).focus();
        $(o).select();
    }
    //重新计算金额合计
    var orderIdArr=$("input:hidden[name=orderId]");
    var totalMoney=0;
    for(var i=0;i<orderIdArr.length;i++)
    {
        totalMoney=fltAdd(totalMoney,parseFloat($("input:text[@name=oweTicketAmount"+$(orderIdArr[i]).val()+"]").val()));
    }
    $("#trTotalMoney").find(".totalMoney").html(totalMoney);
}

//功能: 查询数据验证
//作者: 张晓林
//日期: 2009-01-17
function queryDataCheck()
{
    if(""==$("#txtCustomerName").val() && ""==$("#OrderNo").val() && "" == $("#memberNo").val())
    {
        alert("查询条件不能为空!");
        $("#txtCustomerName").focus()
        return false;
    }
}

//功能: 打印数据验证
//作者: 张晓林
//日期: 2009-01-17
function printDataCheck()
{
    if(""==$("#txtCustomerName").val() && ""==$("#OrderNo").val() && "" == $("#memberNo").val())
    {
        alert("打印条件不能为空!");
        $("#txtCustomerName").focus()
        return false;
    }
}

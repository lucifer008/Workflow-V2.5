// JScript 文件
//名    称: mortgageOrder
//功能概要: 订单冲减JS
//作    者: 张晓林
//修正履历:
//修正时间:

var orStatus=true;
$(document).ready(function(){
    $("#txtOrderNo").focus();
});
//功能: 查询验证
//作者: 张晓林
//时间: 2009年11月3日13:16:06
function searchCheck()
{
    if(""==$("#txtOrderNo").val())
    {
        alert("订单号不能为空!");
        $("#txtOrderNo").focus();
        return false;
    }
    var returnVal=false;
    switch(position)
    {
        case master:
            returnVal=true;
             break;
        case manager:
             returnVal=true;
             break;
        default:
            returnVal=accredit();
            break;
    } 
    if(returnVal)
    {
        $("#tagAction").val("Search");
        $("#txtSearch").attr("disabled",true);
        $("#form1").submit();
    }
    else
    {
        return false;
    }
}
function accredit()
{
     var url="Accredit.aspx?AccreditTypeKey="+escape(accreditTypeKey)+"&AccreditTypeText="+escape(accreditTypeText)+"&AccreditTypeLabel="+escape("订单冲减授权");
     return showPage(url,null,280,500,false,true,false,false);
}


//功能: 冲减验证
//作者: 张晓林
//时间: 2009年11月3日13:16:06
function mortgage()
{
    var orderItem=$("input:hidden[@name=itemId]");
    if(orderItem.length==0) return;
    var sum=0;
    for(var i=0;i<orderItem.length;i++)
    {
        var diffItemNum=parseFloat($("#diffItemNum"+$(orderItem[i]).val()).val());
        if(!isNaN(diffItemNum))
        {
            sum+=diffItemNum;
        }
    }
    if(0==sum)
    {
        alert("冲减数量必须大于0!");
        return false;
    }
    var yes=confirm("确认冲减?");
    if(!yes) return false;
    $("#tagAction").val("Mortgage");
    $("#btnMortgage").attr("disabled",true);
    $("#form1").submit();
}


//功能: 检验输入冲减数量是否合法
//作者: 张晓林
//时间: 2009年11月3日13:16:06
var t=false;
function inputMortgageNum(o)
{
    try
    {
        var updateVal=parseFloat($(o).html());
        if(isNaN(updateVal))
        {
            updateVal=0;
        }
        var str="<input type='text' name='mortgageNum' style='width:100%' onblur='checkInputNum(this)' value='"+updateVal+"'/>"
        var lbl=$(o).attr("id");
        $("#"+lbl).html(str);
        $("input[@name=mortgageNum]").select();
    }
    catch(e)
    {
        alert(e);
    }
}

function checkInputNum(o)
{
    try
    {
        var sourceItemNum=parseFloat($($(o).parent().parent().parent()).find(".ItemNum").html());//原订单明细数量
        var diffItemNumed=parseFloat($($(o).parent().parent().parent()).find(".DiffItemNum").html());//已经冲减的数量
        var diffItemNum=parseFloat($(o).val());//本次冲减的数量
        var diffItemPrice=parseFloat($($(o).parent().parent().parent()).find(".ItemPrice").html());//冲减订单明细单价
        var diffItemAmount=$($($(o).parent().parent().parent()).find(".DiffItemAmount"));//冲减的订单明细金额列
        if(isNaN($(o).val()))
        {
            alert("输入的冲减数量格式错误!");
            $(o).focus();
            $(o).val(0);
            $(o).select();
            return;
        }
        if(!isInteger($(o).val()))
        {
            alert("输入的冲减数量格式错误!");
            $(o).focus();
            $(o).val(0);
            $(o).select();
            return;
        }
        if(diffItemNum>(sourceItemNum-diffItemNumed))
        {
            alert("被冲减数量不够!");
            $(o).focus();
            $(o).val(0);
            $(o).select();
            return;
        }
        if(diffItemNum<0)
        {
            alert("冲减数量不能小于0!");
            $(o).focus();
            $(o).select();
            return;
        }
        var itemId=$("input[@name=itemId]",$(o).parent().parent().parent()).val();
        var str="<label id='"+$($(o).parent()).attr("id")+"' onclick='inputMortgageNum(this)' style='width:100%;color:Blue;cursor:pointer;' title='单击输入冲减数量'>"
        str+=diffItemNum;
        str+="</label>";
        str+="<input type='hidden' id='diffItemNum"+itemId+"' name='diffItemNum"+itemId+"' value='"+diffItemNum+"'/>";
        $($(o).parent().parent()).html(str);
        //计算冲减金额
        var money=fltMul(parseFloat(diffItemNum),parseFloat(diffItemPrice));
        if(isNaN(money)) money=0;
        $(diffItemAmount).html(money);
        var sumMoney=0;
        var tdItemMoney=$("td[class=DiffItemAmount]");
        for(var i=0;i<tdItemMoney.length;i++)
        {
            if(!isNaN(parseFloat($(tdItemMoney[i]).html())))
            {
                sumMoney=fltAdd(sumMoney,parseFloat($(tdItemMoney[i]).html()));
            }
        }
        if(0!=sumMoney){ $("#divDiffSumAmount").html("本次冲减金额合计:"+sumMoney);}
        else{$("#divDiffSumAmount").html("");}
    }
    catch(e)
    {
        alert(e);
    }
    
}

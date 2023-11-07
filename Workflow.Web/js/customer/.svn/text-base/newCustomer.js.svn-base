// 名    称: newCustomer.js
// 功能概要: 客户添加 Js
// 作    者: 
// 创建时间: 
// 修正履历: 
// 修正时间:

$(document).ready(function() {
    disabledSelectOption("Trade");
    $("#CustomerName").focus();
});

function showNewLinkManPage()
{ 
    showPage('NewCustomerLinkMan.aspx?Id='+$("#txtCustomerId").attr("value"), null, 800, 550, false, false);
}

//记账客户授权
function arrear()
{
    if($("#cbPaymentType").attr("value")==payType)//记账
    {
        var isAdd=false;
        switch(position)
        {
            case manager:
            isAdd=true;
            break;
            default:
            isAdd=false;
            break;
        }
        if(!isAdd){
            var returnValue=accredit();
            if(returnValue!='true'){
                alert("对不起！该客户没有记账权限!");
                $("#cbPaymentType").attr("value",payTypeCash);
            }
        }
    }
}
function accredit()
{
    var url="../finance/Accredit.aspx?AccreditTypeKey="+escape(accreditTypeKey)+"&AccreditTypeText="+escape(accreditTypeText)+"&AccreditTypeId="+escape(accreditTypeId);
    return showPage(url,null,280,500,false,true,false,false);
	//return window.showModalDialog(url,window,'dialogHeigth:200px;dialogWidth:280px;status:no');
}

//新增客户
function dataValidateNewCustomer()
{
    var patrnDataNumber = /^\d+(\.d+)?$/;
    if($("#CustomerName").val() == "")
    {
        alert(MESSAGE_EMPTY+":客户名称");
        $("#CustomerName").focus();
        return false;
    }

    var trade = $("#Trade");
    if(trade[0].selectedIndex == 0)
    {
        alert(MESSAGE_CHOICE+":所属行业");
        $("#Trade").focus();
        return false;
    }

    var customertype = $("#sltCustomerType");
    if(customertype[0].selectedIndex == 0)
    {
        
        $("#sltCustomerType").focus();
        alert(MESSAGE_CHOICE+":客户类型");
        return false;
    }
    for(var i=0;i<customertype[0].length;i++)
    {
        if(customertype[0][i].selected)
        {
           $("#hiddCutomerTypeName").val(customertype[0][i].text);
           break;
        }
    }

    var dropDownValue=$("#PayType").val();
    if(0==dropDownValue)
    {
        alert("请选择:支付方式");
        $("#PayType").focus();
        return false;
    }
    var yes=confirm("确认添加?");  
    if(!yes)
    {
        return false;
    }
    return true;
}
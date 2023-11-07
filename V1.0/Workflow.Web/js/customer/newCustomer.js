// 名    称: newCustomer.js
// 功能概要: 客户添加 Js
// 作    者: 
// 创建时间: 
// 修正履历: 
// 修正时间:

$(document).ready(function() {
disabledSelectOption("Trade");

});

function showNewLinkManPage()
{ 
    showPage('NewCustomerLinkMan.aspx?Id='+$("#txtCustomerId").attr("value"), null, 800, 550, false, false);
}
 
function accredit(t)
{
	return window.showModalDialog('../finance/Accredit.aspx',t,'dialogHeigth:200px;dialogWidth:280px;status:no');

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
    return true;
}
// 名    称: customerConbinatin.js
// 功能概要: 客户合并 Js
// 作    者: 
// 创建时间: 
// 修正履历: 
// 修正时间:


/*选择客户*/
selectedCustomer=function()
{
    showPage('SelectCustomer.aspx?Tag=1',null, 900,600, false, false);    
}

/*绑定选择的客户信息*/
function selectCustomer(objCustomer)
{
    if(objCustomer==null) return;
    $("#customerid").attr("value",objCustomer.Id);
    $("#customername").html(objCustomer.Name);
    $("#trade").html(objCustomer.Trade);
    $("#customerlevel").html(objCustomer.CustomerLevel);
    $("#customertype").html(objCustomer.CustomerType);
    $("#linkman").html(objCustomer.LinkMan);
    $("#telno").html(objCustomer.TelNo);
    $("#address").html(objCustomer.Address);
    $("#needticket").html(objCustomer.NeedTicket);
    $("#validatestatus").html(objCustomer.ValidateStatus);
    $("#memo").html(objCustomer.Memo);  
}
    
function DataValidator()
{
    if($("#customerid").val() == "")
    {
        alert("请选择要合并的客户！")
        $("#customerid").focus();
        return false;
    }   
    return true;
}

customerDetail=function(customerId)
{
    showPage('CustomerDetail.aspx?Id='+customerId);
}

/*返回*/
returnConbination=function()
{
    showPage('CustomerValidate.aspx?Tag=1','_self');
}


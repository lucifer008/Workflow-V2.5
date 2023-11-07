// JScript 文件
/*
//名    称：addCustomerType
//功能概要: 客户类型操作JS
//作    者: 张晓林
//创建时间: 2009年5月19日9:21:00
//修正履历:
//修正时间:
*/
function checkProcess()
{
    if(""==$("#txtCustomerTypeName").val())
    {
        alert("客户类型名称不能为空!");
        $("#txtCustomerTypeName").focus();
        return false;
    }
}

//编辑客户类型
function edmitCustomerType(o)
{
    var customerTypeId=$("input[@name=customerTypeId]",$(o).parent()).val();
    var customerTypeName=$($(o).parent().parent()).find(".mName").html();
    var url="addCustomerType.aspx?CustomerTypeId="+customerTypeId+"&CustomerTypeName="+escape(customerTypeName)+"&action=edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate("addCustomerType.aspx");
    }
}

//删除客户类型
var deleteCustomerTypeId;
function deleteCustomerType(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         deleteCustomerTypeId=$("input[@name=customerTypeId]",$(o).parent()).val();
         var url='../../ajax/AjaxEngine.aspx'+'?Tag=CustomerType&BusinessTypeId='+deleteCustomerTypeId;
         $.getJSON(url ,{a:'35'},window.checkIsUseCallBack);
    }
}

function checkIsUseCallBack(json)
{
    if (json.success == null || json.success) 
    {
        data=json;
    }
    else 
    {
        return;
    }
    if("0"==json)
    {
           $("#hidCustomerTypelId").val(deleteCustomerTypeId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该客户类型正在使用,不能删除!");
        return false;
    } 
}
document.onkeydown=function()
{
　　var evt=window.event || arguments[0];
	var element=evt.srcElement || evt.target;		
	if (evt.keyCode==27)	
	{
		window.close();
	}
	if(evt.keyCode == 13)
	{
   	    $("#btnSave").click();
       return false;   
	}
}
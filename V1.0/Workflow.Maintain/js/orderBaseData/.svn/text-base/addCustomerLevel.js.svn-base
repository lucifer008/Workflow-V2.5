// JScript 文件
/*
//名    称：addCustomerLevel
//功能概要: 客户级别操作JS
//作    者: 张晓林
//创建时间: 2009年5月19日9:21:00
//修正履历:
//修正时间:
*/

//添加客户级别数据验证
function checkProcess()
{
    if(""==$("#txtCustomerLevelName").val())
    {
        alert("客户级别名称不能为空!");
        $("#txtCustomerLevelName").focus();
        return false;
    }
}


//编辑客户级别
function edmitCustomerLevel(o)
{
    var customerLevelId=$("input[@name=customerLevelId]",$(o).parent()).val();
    var customerLevelName=$($(o).parent().parent()).find(".mName").html();
    var url="addCustomerLevel.aspx?CustomerLevelId="+customerLevelId+"&CustomerLevelName="+escape(customerLevelName)+"&action=edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate("addCustomerLevel.aspx");
    }
}

//删除客户级别
var deleteCustomerLevelId;
function deleteCustomerLevel(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         deleteCustomerLevelId=$("input[@name=customerLevelId]",$(o).parent()).val();
         var url='../ajax/AjaxEngine.aspx'+'?Tag=CustomerLevel&BusinessTypeId='+deleteCustomerLevelId;
         $.getJSON(url ,{a:'29'},window.checkIsUseCallBack);
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
           $("#hidCutomerLevelId").val(deleteCustomerLevelId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该客户级别正在使用,不能删除!");
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

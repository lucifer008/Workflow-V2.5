// JScript 文件
/*
//名    称：addCompany
//功能概要: 公司维护JS
//作    者: 张晓林
//创建时间: 2009年6月9日13:01:16
//修正履历:
//修正时间:
*/

function checkProcess()
{
    if(""==$("#txtCompanyName").val())
    {
        alert("公司名称不能为空!");
        $("#txtCompanyName").focus();
        return false;
    }
}

//编辑公司
function edmitCompany(o)
{
    var companyId=$("input[@name=companyId]",$(o).parent()).val();
    var companyName=$($(o).parent().parent()).find(".companyName").html();
    var memo=$($(o).parent().parent()).find(".memo").html();
    var url="addCompany.aspx?CompanyId="+companyId+"&CompanyName="+escape(companyName)+"&Memo="+escape(memo)+"&action=edmit";
    var yes=showPage(url,null,900,800,false,true,false);
    if(yes)
    {
        window.navigate("addCompany.aspx");
    }
}

//删除公司
var delCompanyId;
function deleteCompany(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         delCompanyId=$("input[@name=companyId]",$(o).parent()).val();
         var url='../ajax/AjaxEngine.aspx'+'?Tag=Company&BusinessTypeId='+delCompanyId;
         $.getJSON(url ,{a:'1'},window.checkIsUseCallBack);
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
           $("#hidId").val(delCompanyId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该公司正在使用,不能删除!");
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
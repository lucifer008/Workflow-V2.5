// JScript 文件
/*
//名    称：addReportLessMode
//功能概要: 挂失方式操作JS
//作    者: 张晓林
//创建时间: 2009年5月27日9:57:39
//修正履历:
//修正时间:
*/


function checkProcess()
{
    if(""==$("#txtReportLessModeName").val())
    {
        alert("名称不能为空!");
        $("#txtReportLessModeName").focus();
        return false;
    }
}

//编辑挂失方式
function edmitReportLessMode(o)
{
    var reportLessModeId=$("input[@name=reportLessModeId]",$(o).parent()).val();
    var reportLessModeName=$($(o).parent().parent()).find(".mName").html();
    var url="addReportLessMode.aspx?ReportLessModeId="+reportLessModeId+"&ReportLessModeName="+escape(reportLessModeName)+"&action=edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate("addReportLessMode.aspx");
    }
}

//删除挂失方式
var delReportLessModeId;
function deleteReportLessMode(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         delReportLessModeId=$("input[@name=reportLessModeId]",$(o).parent()).val();
         var url='../../ajax/AjaxEngine.aspx'+'?Tag=ReportLessMode&BusinessTypeId='+delReportLessModeId;
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
           $("#hidReportLessId").val(delReportLessModeId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该挂失方式正在使用,不能删除!");
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
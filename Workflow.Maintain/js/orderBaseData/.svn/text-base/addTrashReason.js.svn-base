// JScript 文件
/*
//名    称：addTrashReason
//功能概要: 废张原因操作JS
//作    者: 张晓林
//创建时间: 2009年6月2日9:57:39
//修正履历:
//修正时间:
*/

function checkProcess()
{
    if(""==$("#txtTrashReasonName").val())
    {
        alert("名称不能为空!");
        $("#txtTrashReasonName").focus();
        return false;
    }
}

//编辑废张原因
function edmitTrashReason(o)
{
    var trashReasonId=$("input[@name=trashReasonId]",$(o).parent()).val();
    var trashReasonName=$($(o).parent().parent()).find(".mName").html();
    var trashReasonMemo=$($(o).parent().parent()).find(".mMemo").html();
    var url="addTrashReason.aspx?TrashReasonId="+trashReasonId+"&TrashReasonName="+escape(trashReasonName)+"&Memo="+escape(trashReasonMemo)+"&action=edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate("addTrashReason.aspx");
    }
}

//删除废张原因
var delTrashReasonId;
function deleteTrashReason(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         delTrashReasonId=$("input[@name=trashReasonId]",$(o).parent()).val();
         var url='../ajax/AjaxEngine.aspx'+'?Tag=TrashReason&BusinessTypeId='+delTrashReasonId;
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
           $("#hidTrashReasonId").val(delTrashReasonId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该废张原因正在使用,不能删除!");
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
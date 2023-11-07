// JScript 文件
/*
//名    称：addPrintDemandDetail
//功能概要: 印制要求值 操作JS
//作    者: 张晓林
//创建时间: 2009年5月26日10:16:07
//修正履历:
//修正时间:
*/

function checkProcess()
{
    if("-1"==$("#sltPrintDemand").attr("value"))
    {
        alert("请选择印制要求!");
        $("#sltPrintDemand").focus();
        return false;
    }
    if(""==$("#txtPrintDemandDetailName"))
    {
        alert("名称不能为空!");
        $("#txtPrintDemandDetailName").focus();
        return false;
    }
    if(""==$("#txtMemo"))
    {
        alert("备注不能为空!");
        $("#txtMemo").focus();
    }   
}

//编辑印制要求明细
function edmitPrintDemandDetial(o)
{
    var printDemandDetailId=$("input[@name=printDemandDetialId]",$(o).parent()).val();
    var printDemandId=$("input[@name=printDemandId]",$(o).parent()).val();
    var printDemandDetailName=$($(o).parent().parent()).find(".mName").html();
    var printDemandDetailMemo=$($(o).parent().parent()).find(".mMemo").html();
    var url="addPrintDemandDetail.aspx?PrintDemandDetailId="+printDemandDetailId+"&PrintDemandDetailName="+escape(printDemandDetailName);
    url+="&Memo="+escape(printDemandDetailMemo)+"&PrintDemandId="+printDemandId+"&action=edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        $("#form1").submit();
    }
}

//删除印制要求明细
function deletePrintDemandDetial(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
        $("#hiddTag").val("delete");
        $("#hidPrintDemandDetailId").val($("input[@name=printDemandDetialId]",$(o).parent()).val());
        $("#form1").submit();
    }
}

function LoadEdmit()
{
    if(""!=pId)
    {
        $("#sltPrintDemand").attr("value",pId);
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
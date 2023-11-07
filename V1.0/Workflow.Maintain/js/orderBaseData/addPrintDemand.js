// JScript 文件
/*
//名    称：addPrintDemand
//功能概要: 印制要求操作JS
//作    者: 张晓林
//创建时间: 2009年5月26日10:16:07
//修正履历:
//修正时间:
*/

function checkProcess()
{
    if(""==$("#txtPrintDemandName").val())
    {
        alert("名称不能为空!");
        $("#txtPrintDemandName").focus();
        return false;
    }
    if(""==$("#txtMemo").val())
    {
        alert("备注不能为空!");
        $("#txtMemo").focus();
        return false;
    }
}

//编辑印制要求
function edmitPrintDemand(o)
{
    var printDemandId=$("input[@name=printDemandId]",$(o).parent()).val();
    var printDemandName=$($(o).parent().parent()).find(".mName").html();
    var printDemandMemo=$($(o).parent().parent()).find(".mMemo").html();
    var url="addPrintDemand.aspx?PrintDemandId="+printDemandId+"&PrintDemandName="+escape(printDemandName);
    url+="&Memo="+escape(printDemandMemo)+"&action=edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate("addPrintDemand.aspx");
    }
}

//删除印制要求
var delPrintDemandId;
function deletePrintDemand(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         delPrintDemandId=$("input[@name=printDemandId]",$(o).parent()).val();
         var url='../ajax/AjaxEngine.aspx'+'?Tag=PrintDemand&BusinessTypeId='+delPrintDemandId;
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
           $("#hidPrintDemandId").val(delPrintDemandId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该印制要求正在使用,不能删除!");
        return false;
    } 
}

//新增印制要求明细
function NewPrintDemandValue()
{
    showPage("addPrintDemandDetail.aspx?Tag=1",null,900,800,false,true,false);
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
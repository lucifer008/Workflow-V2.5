// JScript 文件
/*
//名    称：addBusinessType
//功能概要:新增业务类型JS
//作    者:张晓林
//创建时间:2009年4月28日16:46:22
//修正履历:
//修正时间:
*/


/*新增业务类型数据验证*/
function checkProcess()
{
    if(""==$("#txtBusinessTypeName").val())
    {
        alert("业务类型名称不能为空!");
        $("#txtBusinessTypeName").focus();
        return false;
    }
    if(-1==$("#sltIsNotInWatch").attr("value"))
    {
        alert("是否抄表不能为空!");
        $("#sltIsNotInWatch").focus();
        return false;
    }
}

/*编辑业务类型*/
function edmitBusinessType(o)
{
    var businessTypeId=$("input[@name=businessTypeId]",$(o).parent()).val();
    var businessName=$($(o).parent().parent()).find(".bName").html();
    var businessIsNoInW=$($(o).parent().parent()).find(".bMachinename").html();
    var url="addBusinessType.aspx?BusinessTypeId="+businessTypeId+"&BusinessName="+escape(businessName)+"&BusinessIsNoInW="+escape(businessIsNoInW)+"&actionTag="+"edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate('addBusinessType.aspx');
    }
}

/*删除业务类型*/
var businessTypeId=0;
deleteBusinessType=function(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         businessTypeId=$("input[@name=businessTypeId]",$(o).parent()).val();
         var url='../ajax/AjaxEngine.aspx'+'?Tag=BusinessType&BusinessTypeId='+businessTypeId;
         $.getJSON(url ,{a:'1'},window.CheckIsUseCallBack);
    }
}

function CheckIsUseCallBack(json)
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
           $("#hidBusinessTypeId").val(businessTypeId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该业务类型正在使用,不能删除!");
        return false;
    } 
}

function loadEdmitInfo()
{
    if(""!=businessTypeName)
    {
       $("#tr1").html("");
       $("#btnCancel").show();
       $("#txtBusinessTypeName").val(businessTypeName);
       if(businessIsNotNeedIn=='<%=Constants.NEED_IN_WATCH_TEXT %>')
       {
           $("#sltIsNotInWatch").attr("value",isInWatch);    
       }
       else
       {
           $("#sltIsNotInWatch").attr("value",notWatch);
       }
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

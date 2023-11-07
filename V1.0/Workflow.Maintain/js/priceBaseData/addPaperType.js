// JScript 文件
/*
//名    称:addPaperTypeJS
//功能概要:纸质操作JS
//作    者:张晓林
//创建时间:2009年5月6日9:24:18
//修正履历:
//修正时间:
*/

//添加数据验证
checkProcess=function()
{
    if(""==$("#txtPaperTypeName").val())
    {
        alert("名称不能为空!");
        $("#txtPaperTypeName").focus();
        return false;
    }
}

//编辑纸质 
edmitPaperType=function(o)
{
    var paperTypeId=$("input[@name=paperTypeId]",$(o).parent()).val();
    var paperTypeName=$($(o).parent().parent()).find(".mName").html();
    var url="addPaperType.aspx?PaperTypeId="+paperTypeId+"&PaperTypeName="+escape(paperTypeName)+"&actionTag="+"edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate('addPaperType.aspx');
    }
}

//删除纸质
deletePaperType=function(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
           var paperTypeId=$("input[@name=paperTypeId]",$(o).parent()).val();
           $("#hidPaperTypeId").val(paperTypeId);
           $("#hiddTag").val("delete");
           $("#form1").submit(); 
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
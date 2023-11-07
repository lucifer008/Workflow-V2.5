// JScript 文件

/// 名    称: addPaperSecifiation
/// 功能概要: 添加纸型JS
/// 作    者: 张晓林
/// 创建时间: 2009年5月5日15:06:12
/// 修正履历:
/// 修正时间:

//添加数据验证
function checkProcess()
{
    if(""==$("#txtPaperSpecificationName").val())
    {
        alert("名称不能为空");
        $("#txtPaperSpecificationName").focus();
        return false;
    }
}

//编辑纸型
function edmitPaperSpecification(o)
{
    var paperSpecifiationId=$("input[@name=paperSpecificationId]",$(o).parent()).val();
    var paperSpecifiationName=$($(o).parent().parent()).find(".mName").html();
    var url="addPaperSpecifiation.aspx?PaperSpecifiationId="+paperSpecifiationId+"&PaperSpecifiationName="+escape(paperSpecifiationName)+"&actionTag="+"edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate('addPaperSpecifiation.aspx');
    }
}

//删除纸型
function deletePaperSpecification(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
           var paperSpecifiationId=$("input[@name=paperSpecificationId]",$(o).parent()).val();
           $("#hidPaperId").val(paperSpecifiationId);
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
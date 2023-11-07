// JScript 文件
/*
//名    称：addApllicationProperties
//功能概要: 应用程序参数维护JS
//作    者: 张晓林
//创建时间: 2009年6月8日9:31:16
//修正履历:
//修正时间:
*/

//初始化数据验证
initCheck=function()
{
    if(!confirm("确认初始化吗?"))
    {
        return false;
    }
}

//数据操作验证
checkProcess=function()
{
    if(""==$("#txtPropertyId").val())
    {
        alert("参数Id不能为空!");
        $("#txtPropertyId").focus();
        return false;
    }
    if(""==$("#txtPropertyValue").val())
    {
        alert("参数值不能为空!");
        $("#txtPropertyValue").focus();
        return false;
    }
//    if(!isNumber($("#txtPropertyValue").val()))
//    {
//        alert("参数值不能为非数字类型!");
//        $("#txtPropertyValue").focus();
//        return false;
//    }
}

//编辑应用程序参数
edmitApplicationProperty=function(o)
{
    var applicationPropertyId=$("input[@name=applicationPropertyId]",$(o).parent()).val();
    var propertyId=$($(o).parent().parent()).find(".propertyId").html();
    var propertyValue=$($(o).parent().parent()).find(".propertyValue").html();
    var url="addApllicationProperties.aspx?ApplictionPropertyId="+applicationPropertyId+"&PropertyId="+escape(propertyId);
        url+="&PropertyValue="+escape(propertyValue)+"&action=edmit";
    var yes=showPage(url,null,900,800,false,true,false);
    if(yes)
    {
        window.navigate("addApllicationProperties.aspx");
    }
}

//删除应用程序参数 
deleteApplicationProperty=function(o)
{
    if(!confirm("确认删除吗?"))
    {
        return false;
    }
    var applicationPropertyId=$("input[@name=applicationPropertyId]",$(o).parent()).val();
    $("#hiddTag").val("delete");
    $("#hidId").val(applicationPropertyId);
    $("#form1").submit();
}

//回车提交,Esc键关闭窗体
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
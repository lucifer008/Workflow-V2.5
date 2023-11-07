// JScript 文件
/*
//名    称：idVindicate
//功能概要: Id维护JS
//作    者: 张晓林
//创建时间: 2009年6月6日9:57:30
//修正履历:
//修正时间:
*/

//初始化数据客户端验证
function initCheck()
{
    var yes=confirm("确认初始化吗?");
    if(!yes)
    {
        return false;
    }
}

//编辑Id数据验证
function checkProcess()
{
    if(""==$("#txtFlagNo").val())
    {
        alert("提示符不能为空!");
        $("#txtFlagNo").focus();
        return false;
    }
    if(""==$("#txtBeginValue").val())
    {
        alert("开始值不能为空!");
        $("#txtBeginValue").focus();
        return false;
    }
    if(!checkOnlyNum($('#txtBeginValue'),true,14))
    {
        alert("开始值不能非数字类型!");
        $("#txtBeginValue").focus();
        return false;
    } 
    if(""==$("#txtCurrentValue").val())
    {
        alert("当前值不能为空!");
        $("#txtCurrentValue").focus();
        return false;
    }
    if(!checkOnlyNum($('#txtCurrentValue'),true,14))
    {
        alert("当前值不能非数字类型!");
        $("#txtCurrentValue").focus();
        return false;
    }
    if(""==$("#txtEndValue").val())
    {
        alert("结束值不能为空!");
        $("#txtEndValue").focus();
        return false;
    }
    if(!checkOnlyNum($('#txtEndValue'),true,14))
    {
        alert("结束值不能非数字类型!");
        $("#txtEndValue").focus();
        return false;
    }    
}

//编辑Id
function edmitIdGenerator(o)
{
    var idGeneratorId=$("input[@name=idGeneratorId]",$(o).parent()).val();
    var flagNo=$($(o).parent().parent()).find(".flagNo").html();
    var beginValue=$($(o).parent().parent()).find(".beginValue").html();
    var currentValue=$($(o).parent().parent()).find(".currentValue").html();
    var endValue=$($(o).parent().parent()).find(".endValue").html();
    var memo=$($(o).parent().parent()).find(".memo").html();
    var url="edmitId.aspx?IdGeneratorId="+idGeneratorId+"&FlagNo="+escape(flagNo)+"&BeginValue="+escape(beginValue);
        url+="&CurrentValue="+escape(currentValue)+"&EndValue="+escape(endValue)+"&Memo="+escape(memo);
    var yes=showPage(url,null,900,800,false,true,false);
    if(yes)
    {
        window.navigate("idVindicate.aspx");
    }
}

//删除Id
function deleteIdGenerator(o)
{
    var yes=confirm("确认删除吗？");
    if(yes)
    {
        var idGeneratorId=$("input[@name=idGeneratorId]",$(o).parent()).val();
        $("#hiddIdKey").val(idGeneratorId);
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
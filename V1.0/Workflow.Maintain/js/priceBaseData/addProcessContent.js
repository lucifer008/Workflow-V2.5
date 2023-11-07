// JScript 文件
/*
//名    称：addProcessContent
//功能概要: 新增加工类型JS
//作    者: 张晓林
//创建时间: 2009年4月29日15:42:57
//修正履历:
//修正时间:
*/

//加工内容操作数据验证
function checkProcess()
{
    if(""==$("#txtProcessContentName").val())
    {
        alert("名称不能为空!");
        $("#txtProcessContentName").focus();
        return false;
    }
    if("-1"==$("#sltRepartitionColor").attr("value"))
    {
        alert("请选择区分颜色!");
        $("#sltRepartitionColor").focus();
        return false;
    }
    if("-1"==$("#sltBusinessType").attr("value"))
    {
        alert("请选择业务类型!");
        $("#sltBusinessType").focus();
        return false;
    }
}

//编辑加工内容
function edmitProcessContent(o)
{
    var processContentId=$("input[@name=processContentId]",$(o).parent()).val();
    var businessTypeId=$("input[@name=businessTypeId]",$(o).parent()).val();
    var pConName=$($(o).parent().parent()).find(".bName").html();
    var bColor=$($(o).parent().parent()).find(".bColor").html();
    var url="addProcessContent.aspx?ProcessContentId="+processContentId+"&BusinessTypeId="+businessTypeId+"&ProcessConName="+escape(pConName)+"&ColorType="+escape(bColor)+"&actionTag1="+"edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate('addProcessContent.aspx');
    }
}

//删除加工内容
var processContentId;
function deleteProcessContent(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
        processContentId=$("input[@name=processContentId]",$(o).parent()).val();
        var url='../ajax/AjaxEngine.aspx'+'?Tag=ProcessContent&BusinessTypeId='+processContentId;
        $.getJSON(url ,{a:'29'},window.CheckIsUseCallBack);
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
        $("#hiddTag").val("delete");
        $("#hidProcessContentId").val(processContentId);
        $("#form1").submit();      
    }
    else
    {
        alert("该加工内容正在使用,不能删除!");
        return false;
    } 
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
//编辑业绩比例值
function edmitAchievementValueRate()
{
    var url="../orderBaseData/addProcessContentAchievementRate.aspx?Tag=1";
    showPage(url,null,900,900,false,true,false);
}

 loadEdmitInfo=function()
 {
       if(""!=strProcessContentName)
       {
           $("#tr1").html("");
           $("#btnCancel").show();
           $("#txtProcessContentName").val(strProcessContentName);
           $("#sltBusinessType").attr("value",strBusinessTypeId);
           if(ColorType==colorBlackText)
           {
               $("#sltRepartitionColor").attr("value",colorBlackKey);
           }
           else if(ColorType==colorColourText)
           {
               $("#sltRepartitionColor").attr("value",colorColourKey);
           }
       }
}

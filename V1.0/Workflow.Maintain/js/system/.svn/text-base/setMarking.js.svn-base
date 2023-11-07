// JScript 文件
/*
//名    称：setMarking
//功能概要: 设置积分JS
//作    者: 张晓林
//创建时间: 2009年10月28日11:02:41
//修正履历:
//修正时间:
*/

//积分设置验证
function checkProcess()
{
     var processContent=$("#dropListProcessContent");
    if(-1==processContent[0].selectedIndex)
    {
        alert(MESSAGE_CHOICE+":加工内容!");
        $(processContent).focus();
        return false;
    }
    if(""==$("#txtMarkingAmount").val())
    {
        alert("金额不能为空!");
        $("#txtMarkingAmount").val("");
        $("#txtMarkingAmount").focus();
        return false;
    }
    else
    {
        if(!checkOnlyNum($("#txtMarkingAmount")))
        {
            //alert("输入格式有误!");
            $("#txtMarkingAmount").focus();
            return false;   
        }
    }
    
    if(""==$.trim($("#txtMarkingCount").val()))
    {
        alert("积分不能为空!");
        $("#txtMarkingCount").val("");
        $("#txtMarkingCount").focus();
        return false;
    }
    else
    {
        if(!checkOnlyNum($("#txtMarkingCount")))
        {
            //alert("输入格式有误!");
            $("#txtMarkingCount").focus();
            return false;   
        }
    }
}

//编辑积分
function edmitMarking(o)
{
    var markSettingId=$("input[@name=markingId]",$(o).parent()).val();
    var processContentId=$("input[@name=processContentId]",$(o).parent()).val();
    var amount=$($(o).parent().parent()).find(".amount").html();
    var marking=$($(o).parent().parent()).find(".marking").html();
    var memo=$($(o).parent().parent()).find(".memo").html();
    var url="setMarking.aspx?MarkSettingId="+markSettingId+"&ProcessContentId="+processContentId+"&Memo="+escape(memo)+"&action=edmit";
    url+="&Amount="+amount+"&Marking="+marking;
    var yes=showPage(url,null,900,800,false,true,false);
    if(yes)
    {
        window.navigate("setMarking.aspx");
    }
}

//删除积分
function deleteMarking(o)
{
    var yes=confirm("确认删除吗？");
    if(yes)
    {
        var markSettingId=$("input[@name=markingId]",$(o).parent()).val();
        $("#hidId").val(markSettingId);
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

function clearSelected()
{
    var processContent=$("#dropListProcessContent");
    processContent[0].selectedIndex=-1;
}
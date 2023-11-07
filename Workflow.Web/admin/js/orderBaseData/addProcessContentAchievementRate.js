// JScript 文件
/*
//名    称：addProcessContentAchievementRate js
//功能概要: 加工内容业绩比例操作JS
//作    者: 张晓林
//创建时间: 2009年6月2日
//修正履历:
//修正时间:
*/

function checkProcess()
{
    if(-1==$("#sltProcessContent").attr("value"))
    {
        alert("请选择加工内容!");
        $("#sltProcessContent").focus();
        return false;
    }
    if(""==$("#txtAcievementRateValue").val())
    {
        alert("业绩比例值不能为空!");
        $("#txtAcievementRateValue").focus();
        return false;
    }
    if(!isNumber($("#txtAcievementRateValue").val()))
    {
        alert("请务必输入数字!");
        $("#txtAcievementRateValue").focus();
        return false;
    }
    else
    {
        if(1<parseFloat($("#txtAcievementRateValue").val()))
        {
            alert("请输入正确的比例值!");
            $("#txtAcievementRateValue").focus();
            return false;
        }
    }
    if(""==$("#txtMemo").val())
    {
        alert("备注不能为空!");
        $("#txtMemo").focus();
        return false;   
    }
}

//编辑加工内容业绩比例
function edmitProcessContentAchievementRate(o)
{
    var processContentAchievementRateId=$("input[@name=processContentAchievementRateId]",$(o).parent()).val();
    var processContentId=$("input[@name=processContentId]",$(o).parent()).val();
    var memo=$($(o).parent().parent()).find(".mMemo").html();
    var achievementRateValue=$($(o).parent().parent()).find(".mAchievementValue").html();
    var url="addProcessContentAchievementRate.aspx?ProcessContentAchievementRateId="+processContentAchievementRateId+"&AchievementRateValue="+achievementRateValue+"&ProcessContentId="+escape(processContentId)+"&Memo="+escape(memo)+"&action=edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate("addProcessContentAchievementRate.aspx");
    }
}

//删除加工内容业绩比例
function deleteProcessContentAchievementRate(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
           var delId=$("input[@name=processContentAchievementRateId]",$(o).parent()).val();
           $("#hidProcessContentAchievementRateId").val(delId);
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
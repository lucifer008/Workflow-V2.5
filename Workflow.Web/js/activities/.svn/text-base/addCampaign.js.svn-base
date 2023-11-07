// JScript 文件
// 名    称: addCampagin.js
// 功能概要: 新增营销活动Js
// 作    者: 张晓林
// 创建时间:2009年2月16日9:39:44 
// 修正履历:
// 修正时间:
// 修正描述:


function dataValidatorCampaign()
{
    if($("#txtName").val() == "")
    {
        alert(MESSAGE_EMPTY+":营销活动名称");
        $("#txtName").focus();
        return false;
    }

    if($("#txtBeginDateTime").val() == "")
    {
        alert(MESSAGE_CHOICE+":开始时间");
        return false;
    }

    if($("#txtEndDateTime").val() == "")
    {
        alert(MESSAGE_CHOICE+":结束时间");
        return false;
    }

    var beginDateValue = $("input:text[@id$=txtBeginDateTime]").attr("value");
    var endDateValue = $("input:text[@id$=txtEndDateTime]").attr("value");
    if (beginDateValue != "" && endDateValue != "" && beginDateValue > endDateValue) {
	    alert("注册日期 : 开始日期不能大于结束日期。");
	    $("input:text[@id$=txtBeginDateTime]").focus();
	    return false;
    }
    return true;
}

/////删除优惠方案
//function DeletedConcession(deletedId)
//{
//    $("#DeletedTag").attr("value", "delete");
//    $("#DeletedId").attr("value", deletedId);
//    document.form1.submit();
//}


/////新增优惠方案
//function NewPreferentialProject(campaignId)
//{
//    showPage("AddPreferentialProject.aspx?Id="+campaignId+"&Tag=1","_self");
//}

/////编辑优惠方案
//function EdmitConcession(campaignId,concessionId)
//{
//    showPage("ModifyPreferentialProject.aspx?Id="+campaignId+"&ConcessionId="+concessionId+"&Tag=1","_self");
//}

//检查活动名称是否可用
function CheckNameIsNotUse()
{
    if(""!=$("#txtName").val())
    {
       var campaignName=$("#txtName").val();
        var url="../ajax/AjaxEngine.aspx?CampaignName="+campaignName+"&Tag=4";
        $.getJSON(url,{a:'23'},processJson);
    }
}
function processJson(json)
{
    if(json==null) return;
    else if("1"==json)
    {
        alert("改名称已经存在!请重新输入名称");
        $("#txtName").val("");
        return;
    }
}
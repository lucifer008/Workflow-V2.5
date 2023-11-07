// JScript 文件

// 名    称: edmitCampagin.js
// 功能概要: 营销活动编辑Js
// 作    者: 张晓林
// 创建时间:2009年2月16日9:39:44 
// 修正履历:
// 修正时间:
// 修正描述:


//添加营销活动数据判断
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
    

////新增优惠方案    
//function NewPreferentialProject(campaignId)
//{
//    showPage("AddPreferentialProject.aspx?Id="+campaignId+"&Tag=1","_self");   
//}

////删除优惠方案
//function DeletePreferentialProject(concessionId)
//{
//    var yes=confirm("确认删除吗?");
//    if(yes)
//    {
//        $("#hiddDeletedTag").attr("value", "delete");
//        $("#hiddDeletedId").attr("value", concessionId);
//        $("#form1").submit();
//    }
//    
//}
////编辑优惠方案
//function EdmitPreferentialProject(campaignId,concessionId)
//{
//    showPage("ModifyPreferentialProject.aspx?Id="+campaignId+"&ConcessionId="+concessionId+"&Tag=2",null,1000,650,false,true,false)
//}
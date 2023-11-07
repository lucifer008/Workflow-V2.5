// JScript 文件

// 名    称: campaginList.js
// 功能概要: 营销活动管理 Js
// 作    者: 张晓林
// 创建时间:2009年2月16日9:39:44 
// 修正履历:
// 修正时间:
// 修正描述: 


///删除优惠活动
var camId=0;
function deletedCampagin(campaginId)
{
    var yes=confirm("确认删除该营销活动吗?");
    if(0!=campaginId)
    {
        if(yes)
        {
            var url="../ajax/AjaxEngine.aspx?CampaignId="+campaginId+"&Tag=3";
            $.getJSON(url,{a:'23'},processJson);
            camId=campaginId;
        }
    }
}

function processJson(json)
{
    if(null==json) return 
    if("0"!=json)
    {
        alert("该活动名称 正在使用不能删除!");
        return;
    }
    if(0!=camId)
    {
        $("#hiddTag").attr("value", "delete");
        $("#hiddId").attr("value", camId);
        $("#form1").submit();
    }
}
///编辑优惠活动
function edmitCampagin(campaginId)
{
    var yes=showPage('ModifyCampaign.aspx?Id='+campaginId,null,800,550,false,true,false)
    if(yes)
    {
       $("#hiddTag").attr("value", "edmit");
       $("#form1").submit();    
    }
}

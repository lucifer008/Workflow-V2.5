// JScript 文件
// 名    称: dailyOrderFilterCondition.js
// 功能概要: 本日订单过滤条件 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 
function filterCondition(objChk)
{
    if((objChk.id=="chkAll1" || objChk.id=="chkAll") && $(objChk).attr("checked"))
    {
        $($("input[@name=NoDispatch]")[0]).attr("checked",false);
        $($("input[@name=Working]")[0]).attr("checked",false);
        $($("input[@name=Finish]")[0]).attr("checked",false);
        $($("input[@name=Closed]")[0]).attr("checked",false);
        $($("input[@name=BlankOut]")[0]).attr("checked",false);
        $($("input[@name=NoPrepay]")[0]).attr("checked",false);
        $($("input[@name=NoClosed]")[0]).attr("checked",false);
        $($("input[@name=cbReception]")[0]).attr("checked",false);
        $($("input[@name=cbAdmendmented]")[0]).attr("checked",false);
    }
    else
    {
        $($("input[@name=All]")[0]).attr("checked",false);
    }
}

function saveFilterCondition()
{
    var action=false;
    if($("input[@name=All]").attr("checked"))
    {
        action=true;
    }
    if($("input[@name=NoPrepay]").attr("checked"))
    {
        action=true;
    }
    if($("input[@name=NoDispatch]").attr("checked"))
    {
        action=true;
    }
    if($("input[@name=Working]").attr("checked"))
    {
        action=true;
    }
    if($("input[@name=Finish]").attr("checked"))
    {
        action=true;
    }
    if($("input[@name=NoClosed]").attr("checked"))
    {
        action=true;
    }
    if($("input[@name=Closed]").attr("checked"))
    {
        action=true;
    }
    if($("input[@name=BlankOut]").attr("checked"))
    {
        action=true;
    }
    if($("input[@name=cbReception]").attr("checked"))
    {
        action=true;
    }
    if($("input[@name=cbAdmendmented]").attr("checked"))
    {
        action=true;
    }
    if(!action)
    {
        alert("至少选择一个过滤条件!");
        return false;
    }
    $("#txtAction").attr("value",2);
    $("#form1").submit();
}

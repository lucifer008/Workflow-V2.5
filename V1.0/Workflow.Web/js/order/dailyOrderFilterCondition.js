// JScript 文件
// 名    称: dailyOrderFilterCondition.js
// 功能概要: 本日工单过滤条件 Js
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
    }
    else
    {
        $($("input[@name=All]")[0]).attr("checked",false);
    }
}

function saveFilterCondition()
{
    $("#txtAction").attr("value",2);
    $("#form1").submit();
}

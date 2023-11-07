// JScript 文件
//名    称：AchievementComposition
//功能概要: 订单绩效分配情况JS
//作    者:张晓林
//创建时间:2009年9月2日10:54:31
//修正履历:
//修正时间:

///名    称:dataQuery
///功能概要:检索数据验证
///作    者:张晓林
///创建时间:
///修正时间:
///修正履历:
function dataQuery()
{
    if($("#strNo").val()=="")
    {
        alert('请检索的订单号!!!');
        $("strNo").select();
        $("#strNo").focus();
        return false;
    }
    return true;
}

///名    称:onkeydown
///功能概要:控制回车提交
///作    者:张晓林
///创建时间:2009年9月2日10:28:57
///修正时间:
///修正履历:
document.onkeydown=function(event_e)
{
    var evt=window.event||arguments[0];
    var element=evt.srcElement||src.target;
    if(13==evt.keyCode)
    {
        if("strNo"==element.id)
        {
            $("#btnSearch").click();
            return false;
        }
    }
}


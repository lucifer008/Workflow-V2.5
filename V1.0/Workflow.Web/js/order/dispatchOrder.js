// JScript 文件
// 名    称: dispatchOrder.js
// 功能概要: 分配工单 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 
$().ready(
    
    function(){
      $("#OrderNo").text(strNo);
      $("#txtOrderNo").attr("value",strNo);
    }
);
function dataCheck()
{
    if($("#prophase").attr("selectedIndex")<=0 && $("#anaphase").attr("selectedIndex")<=0)
    {
        alert('至少应该有一个参与者!');
        return false;
    }
    if($($("textarea[@name='Memo']")[0]).val().length>200)
    {
        alert("您输入的备注太长!");
        $($("textarea[@name='Memo']")[0]).focus();
        return false;
    }  
    return true;
}  
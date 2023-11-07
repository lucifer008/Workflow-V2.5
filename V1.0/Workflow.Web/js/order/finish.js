// JScript 文件
// 名    称: finish.js
// 功能概要: 工单完工 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 
document.onkeydown=function(event_e)
{
    if (window.event)
        event_e=window.event;
    var int_keycode=event_e.charCode || event_e.keyCode;
    //alert(int_keycode);	
		
    if (int_keycode==27)	
    {
        window.close();
    }
} 
$().ready(
    function(){
      $("#OrderNo").text(strNo);
      $("#CustomerName").text(strName);
      $("#txtOrderNo").attr("value",strNo);
    }
);
function dataCheck()
{
    if($("#prophase").attr("selectedIndex")<=0 && $("#anaphase").attr("selectedIndex")<=0)
    {
        alert('至少应该有一个制作者！！！');
        return false;
    }
    if($($("textarea[@name='Memo']")[0]).val().length>200)
    {
        alert("您输入的备注太长!!!");
        $($("textarea[@name='Memo']")[0]).focus();
        return false;
    }  
    return true;
}  
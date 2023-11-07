// JScript 文件
// 名    称: delivery.js
// 功能概要: 送货 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 
function dataCheck()
{
    if($($("textarea[@name='DeliveryMemo']")[0]).attr("value").length>200)
    {
        alert("您输入的备注太长!!!");
        $($("textarea[@name='DeliveryMemo']")[0]).focus();
        return false;
    }    
}
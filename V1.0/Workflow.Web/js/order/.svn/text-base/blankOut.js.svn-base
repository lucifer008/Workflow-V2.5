// JScript 文件
// 名    称: blankOut.js
// 功能概要: 工单作废 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间: 

$(document).ready(
function(){
  $("#OrderNo").text(strNo);
  $("#CustomerName").text(strName);
  $("#txtOrderNO").attr("value",strNo);
}
);
function checkData()
{
    if(""==$("#txtMemo").val())
    {
        alert("请填写作废原因！！！");
        $("#txtMemo").val("");
        $("#txtMemo").focus();
        return false;
    }
    if($($("textarea[@name='Memo']")[0]).attr("value").length>200)
    {
        alert("您输入的备注太长!!!");
        $($("textarea[@name='Memo']")[0]).focus();
        return false;
    }

    return confirm("您确认要作废吗?");
}

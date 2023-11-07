// JScript 文件
// 名    称: prepayMoney.js
// 功能概要: 订单预付 Js
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
    
    if(""==$("#txtPayMoney").val())
    {
        alert("请填预付金额!!!");
        $("#txtPayMoney").focus();
        return false;
    }
    if(!checkOnlyNum($("#txtPayMoney"),false,6))
    {
        $("#txtPayMoney").focus();
        return false;
    }
    if(parseFloat($("#txtPayMoney").val())!=parseFloat($("#prepayMoney").text()))
    {
        alert("您输入的金额必须与应付金额相同!!!")
        $("#txtPayMoney").focus();
        return false;
    }
}
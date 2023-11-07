// JScript 文件
function showPriceSet(intId){
    //pageType 1 会员卡价格 2行业价格 3特殊行业会员价格
    var pageType = 2;
    $("#txtAction").attr("value",4);
    showPage('SetPrice.aspx?ID='+intId+'&pageType='+pageType, null, 800, 465, false, false);
}
function deletePriceSet(intId){
    if (!confirm("是否要真的删除?")) return;
    $("#txtAction").attr("value",5);
    $("#txtId").attr("value",intId);
    $("#MainForm").submit();
}
function queryPriceSet(){
    $("#txtAction").attr("value",2);
    $("#MainForm").submit();
}
function showStandardPrice()
{
    var pageType = 2;
    showPage('SelectStandardPrice.aspx?pageType='+pageType, "curWindow", 800, 800, false, false);
}
$(document).ready(function(){
    $("input:button[@value=选择门市价格]").click(showStandardPrice);
    $("input:button[@value=查询]").click(queryPriceSet);
    disabledSelectOption("sltSecondaryTrade");
});

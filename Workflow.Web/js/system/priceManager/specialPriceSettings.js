// JScript 文件
function showPriceSet(intId){
    //pageType 1 会员卡价格 2行业价格 3特殊行业会员价格
    var pageType = 3;
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
    var pageType = 3;
    showPage('SelectStandardPrice.aspx?pageType='+pageType, "curWindow", 800, 900, false, false);
}
$(document).ready(function(){
    $("input:button[@value=选择门市价格]").click(showStandardPrice);
    $("input:button[@value=查询]").click(queryPriceSet);
});


function querySettings(sourceSelect){
//    if (document.forms[0]["sltMemberCardLevel"].value==-1)
//    {
//        return false;
//    }
//    if (document.forms[0]["sltBusinessType"].value==-1)
//    {
//        return false;
//    }

    //$("#isQuery").val("1");
    var provider = {};
    provider.source1 = sourceSelect;
    provider.process = function(json) {
        window.processJson(json, provider.source1);
    };
    source = sourceSelect;
    var url = "../../ajax/AjaxEngine.aspx" + "?businessTypeId=" + sourceSelect.value;

    $.getJSON(url, {a : '2'}, provider.process);
}
function processJson(json, sourceSelect){
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }
    var sltBusinessType=$("#sltBusinessType"); //处理业务类型
    var btnQuery=$("#btnQuery");  //处理按钮
    var factorMemory=$("#factorMemory").html("");
    factorMemory.append(sltBusinessType);
    for(var i=0; i<data.PriceFactor.length;i++){    
        pf=data.PriceFactor[i];
        var select = $("<select name=factorValuex"+pf.Id+" id=factorValuex"+pf.Id+" onchange='doRelationFactor(this);' ><option value='-1' selected='selected'>请选择</option></select>");
        for (var j = 0; j < pf.FactorValueList.length; j++){
            var fv = pf.FactorValueList[j];
            $("<option value='" + fv.Id + "'>" + fv.Text + "</option>").appendTo(select);
        }
        $(select).attr("value","-1");
        factorMemory.append(select);
    }
    factorMemory.append(btnQuery);
    //处理按钮
}

//获取因素的制约关系
function doRelationFactor(sourceSlt){
    if(sourceSlt.value==-1) return;
    $(sourceSlt).attr("disabled",true);
    var businessTypeId=$("#sltBusinessType")[0].value;
    
    var provider = {};
    provider.source1 = sourceSlt;
    provider.process = function(json) {
        window.processRelationFactor(json, provider.source1);
    };
    //source = sourceSlt;
    var url = "../../ajax/AjaxEngine.aspx" + "?businessTypeId=" + businessTypeId+"&PriceFactorId="+(sourceSlt.id.split('x'))[1]+"&SourceValue="+sourceSlt.value;

    $.getJSON(url, {a : '2'}, provider.process);
}

function processRelationFactor(json,sourceSlt){
    if (json.success == null || json.success) {
        data=json;
    } else {
        return;
    }
    $(sourceSlt).attr("disabled",false);
    var priceFactor=data.PriceFactor;
    
    for(var i=0;i<priceFactor.length;i++){
        var obj=priceFactor[i];
        
        if(obj.FactorValueList.length>0){
            $("#factorValuex"+obj.Id).html("<option value='-1' selected=true>请选择</option>");
            for(var j=0;j<obj.FactorValueList.length;j++)
            {
                $("<option value='" + obj.FactorValueList[j].Id + "'>" + obj.FactorValueList[j].Text + "</option>").appendTo($("#factorValuex"+obj.Id));
            }
            $($('option',$("#factorValuex"+obj.Id))[0]).attr('selected',true);
        }
    }
}

// JScript 文件






//动态获取价格设定的Ajax方法
function getBasePriceSetProcess(sourceSelect)
{

    sourceSelect.disabled="disabled";
    var sltArr=$("select",$(sourceSelect).parent().parent());      

    
    var provider = {};
    provider.source1 = sourceSelect;
    provider.process = function(json) {
        window.processJson(json, provider.source1);
    };
    source = sourceSelect;
    var url = "../../ajax/AjaxEngine.aspx" + "?sltBusinessTypeName=" + sourceSelect.value;

    $.getJSON(url, {a : '14'}, provider.process);
    
    sourceSelect.disabled="";

}

function processJson(json, sourceSelect){
    if (json.success == null || json.success) 
    {
        data=json;
        //reBuildTableRows2(data);    
        //alert(data);
        reBuildTableRows2(data);    

    } 
    else 
    {
        return;
    }
}



function reBuildTableRows2(data)
{  

    //表头
    var firstrow='<tr><th width="1%" nowrap="nowrap">&nbsp;NO&nbsp;</th><th width="1%" nowrap="nowrap">业务类型</th>';

    for (var i = 0; i < data.PriceFactor.length ; i++)
    {
        firstrow +='<th width="1%" nowrap="nowrap">'+data.PriceFactor[i].DisplayText+'</th>';
    }
    firstrow+='<th width="1%" nowrap="nowrap">成本<br />价格</th><th width="1%" nowrap="nowrap">标准<br />价格</th><th width="1%" nowrap="nowrap">活动<br />价格</th><th width="1%" nowrap="nowrap">备用<br />价格</th><th nowrap="nowrap">备注</th><th width="1%" nowrap="nowrap">&nbsp;</th></tr>';
                          
                          
    var nextrow='';
    
    for (var i=0;i<data.BaseBusinessTypePriceSetList.length;i++)
    {
        nextrow+='<tr class="detailRow"><td align="center">'+(i+1)+'</td>';
        nextrow+='<td align="left">' + data.BaseBusinessTypePriceSetList[i].BusinessType.Name + '</td>';
        
        for (var j = 0; j < data.PriceFactor.length; j++)
        {
            nextrow+='<td align="center" nowrap="nowrap">'+ data.BaseBusinessTypePriceSetList[i].Texts[j]+ '</td>';
        }
        
        nextrow+='<td class="num">'+data.BaseBusinessTypePriceSetList[i].CostPrice +'</td>';
        nextrow+='<td class="num">'+data.BaseBusinessTypePriceSetList[i].StandardPrice + '</td>';
        nextrow+='<td class="num">'+data.BaseBusinessTypePriceSetList[i].ActivityPrice+ '</td>';
        nextrow+='<td class="num">'+data.BaseBusinessTypePriceSetList[i].ReservePrice + '</td>';
        nextrow+='<td>&nbsp;</td>';
        nextrow+='<td align="left" nowrap="nowrap"><a href="#" onclick="showPriceSet(' + data.BaseBusinessTypePriceSetList[i].Id + ')">编辑</a>&nbsp;<a href="#" onclick="deletePriceSet(' + data.BaseBusinessTypePriceSetList[i].Id + ')">删除</a></td></tr>';
                          
    }
    var allrows=firstrow+nextrow;
    $("#tabledetail").html(allrows);
    
}

function queryPriceSet(sourceSelect){
    $("#isQuery").val("1");
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
    
function showPriceSet(intId){
  //pageType 0门市价格 1 会员卡价格 2行业价格 3特殊行业会员价格
  //txtAction标记:1初始化 2查询 3增加 4修改 5删除 6其它
  var pageType = 0;
  var obj=showPage('BaseSetPrice.aspx?ID='+intId, "curWindow", 840, 480, false, false);
}

function deletePriceSet(intId){
  if (!confirm("是否要真的删除?")) return;
  $("#txtAction").attr("value",5);
  $("#txtId").attr("value",intId);
  $("#MainForm").submit();
}

function showAddPrice()
{
    $("#txtAction").attr("value",3);
    var slt=document.forms[0]["sltBusinessType"].value;
    showPage('AddPrice.aspx?sltBusinessType='+  slt , "curWindow", 812, 435, false, false);//门市价格单个录入接口
    //showPage('BatchAddPrice.aspx?sltBusinessType='+  slt , "curWindow", 900, 600, false, false);//门市价格批量录入接口
}

$(document).ready(function(){
  $("input:button[@value=查询]").click(queryPriceSet);
  $("input:button[@value=新增价格]").click(showAddPrice);
});
formSubmit=function(){
    $("#MainForm").submit();
}
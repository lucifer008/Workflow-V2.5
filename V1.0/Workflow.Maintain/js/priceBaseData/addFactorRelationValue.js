// JScript 文件
/*
//名    称：addFactorRelationValue
//功能概要: 价格因素依赖关系值操作JS
//作    者: 张晓林
//创建时间: 2009年5月18日10:21:57
//修正履历:
//修正时间:
*/

$(document).ready(function(){
    $("#trFactorValue").hide();
    $("#sltFactorRelation").bind("change",factorRelationCharge);
});

function checkProcess()
{
    if("-1"==$("#sltFactorRelation").attr("value"))
    {
        alert("请选择价格因素依赖关系!");
        $("#sltFactorRelation").focus();
        return  false;
    }
    if(null==$("#sltFactorValue").val())
    {
        alert("请选择依赖因素!");
        return false;
    }
    if(null==$("#sltFactorValue2").val())
    {
        alert("请选择被依赖的因素!");
        return false;
    }
}

//编辑价格因素依赖关系值
function edmitFactorRelationValue(o)
{
    var factorRelationId=$("input[@name=factorRelationId]",$(o).parent()).val();
    var factorRelationValueId=$("input[@name=factorRelationValueId]",$(o).parent()).val();
    var sourceValue=$("input[@name=pSourceValue]",$(o).parent().parent().find(".SourceValue")).val();
    var targetValue=$("input[@name=pTargetValue]",$(o).parent().parent().find(".TargetValue")).val();
    var url="addFactorRelationValue.aspx?FactorRelationId="+factorRelationId+"&FactorRelationValueId="+factorRelationValueId+"&action=edmit";
    url+="&SourceValue="+sourceValue+"&TargetValue="+targetValue;
    var yes=showPage(url,null,900,800,false,true,false);
    if(yes)
    {
       window.navigate('addFactorRelationValue.aspx');   
    }
}

//删除价格因素依赖关系值
function deleteFactorRelationValue(o)
{
    var yes=confirm("确认删除吗?");
    var factorRelationValueId=$("input[@name=factorRelationValueId]",$(o).parent()).val();
    if(yes)
    {
        $("#hidFactorRelationValueId").val(factorRelationValueId);
        $("#hiddTag").val("delete");
        $("#form1").submit();
    }
}

//加载编辑数据
var isBooBing=false;//标示是否是编辑
function loadEdmitData()
{
    if(""!=factorRelationId)
    {
        document.form1.reset();//js实现清楚缓存
        $("#sltFactorRelation").attr("value",factorRelationId)
        $("#trFactorValue").show();
        isBooBing=true;
        var url='../ajax/AjaxEngine.aspx'+'?FactorRelationId='+factorRelationId;
        $.getJSON(url ,{a:'30'},callBackLoadFactorValue);
        $("#btnSearch").hide();
        $("#sltFactorValue").removeAttr("multiple");
        $("#sltFactorValue2").removeAttr("multiple");
        $("input[@name=btnClear]").hide();
    }
}

//根据关系依赖获取所有依赖因素下的值
//
function factorRelationCharge()
{
    if("-1"==$("#sltFactorRelation").val()){
        alert("请选择因素之间的关系依赖!");
        $("#sltFactorRelation").focus();
        $("#trFactorValue").hide();
        return;
    }
    
    var url='../ajax/AjaxEngine.aspx'+'?FactorRelationId='+$("#sltFactorRelation").val();
         $.getJSON(url ,{a:'30'},callBackLoadFactorValue);
}
function callBackLoadFactorValue(json)
{
    if (json.success == null || json.success) 
    {
        data=json;
    }
    else 
    {
        return;
    }
    var strPriceFactorList="";
    for(var i=0;i<data.PriceFactorList.length;i++)
    {
        if(isBooBing && sourceValue==data.PriceFactorList[i].Id){
            strPriceFactorList+="<option selected=selected value="+data.PriceFactorList[i].Id;
        }else{
            strPriceFactorList+="<option value="+data.PriceFactorList[i].Id;
        }
        strPriceFactorList+=">"+data.PriceFactorList[i].Name+"</option>"
    }
    $("#sltFactorValue").html(strPriceFactorList);
    
    strPriceFactorList="";
    for(var i=0;i<data.PriceFactorList2.length;i++)
    {
        if(isBooBing && targetValue==data.PriceFactorList2[i].Id){
            strPriceFactorList+="<option selected=selected value="+data.PriceFactorList2[i].Id;
        }
        else{
            strPriceFactorList+="<option value="+data.PriceFactorList2[i].Id;
        }
        strPriceFactorList+=">"+data.PriceFactorList2[i].Name+"</option>"
    }
    $("#sltFactorValue2").html(strPriceFactorList);
    $("#trFactorValue").show(); 
}
function clearSelected(o)
{
    var sltPriceFactor=$("select[@name='factorValue']",$(o).parent()).attr("id");
    var sltPriceFactor1=$("select[@name='factorValue1']",$(o).parent()).attr("id");
    var slt=undefined!=sltPriceFactor?sltPriceFactor:sltPriceFactor1;
    for(var i=0;i<$("#"+slt).length;i++)
    {
        $($("#"+slt)[i]).attr("selectedIndex",-1);
    }
}

document.onkeydown=function()
{
　　var evt=window.event || arguments[0];
	var element=evt.srcElement || evt.target;		
	if (evt.keyCode==27)	
	{
		window.close();
	}
	if(evt.keyCode == 13)
	{
   	    $("#btnSave").click();
       return false;   
	}
}



// JScript 文件
/*
//名    称：addFactorRelation
//功能概要:价格因素之间的依赖JS
//作    者:张晓林
//创建时间:2009年5月14日9:35:05
//修正履历:
//修正时间:
*/

//添加数据验证
function checkProcess()
{
    var priceFactor=$("input:checkbox[@name=cbPriceFactor]");
    var priceFactorLength=priceFactor.length;
    var count=0;
    if("-1"==$("#sltBusinessType").attr("value"))
    {
        alert("请选择业务类型!");
        $("#sltBusinessType").focus();
        return false;
    }
    if("-1"==$("#sltPricesFactor").attr("value"))
    {
        alert("请选择依赖的价格因素!");
        $("#sltPricesFactor").focus();
        return false;
    }
    for(var i=0;i<priceFactorLength;i++)
    {
       if(priceFactor[i].checked)
       {
            count++;
       } 
    }
    if(0==count)
    {
        alert("至少得选择一个被依赖的价格因素!");
        return false;
    }
    if(""==$("#Memo").val())
    {
        alert("备注不能为空!");
        $("#Memo").focus();
        return false
    }
}

//编辑价格因素之间的依赖关系
function edmitFactorRelation(o)
{
    var factorRelationId=$("input[@name=factorRelationId]",$(o).parent()).val();
    var businessTypeId=$("input[@name=businessTypeId]",$(o).parent()).val();
    var priceFactorId=$("input[@name=priceFactorId]",$(o).parent()).val();
    var priceFactorId2=$("input[@name=priceFactorId2]",$(o).parent()).val();
    var memo=$($(o).parent().parent()).find(".pMemo").html();
    var url="addFactorRelation.aspx?FactorRelationId="+factorRelationId+"&BusinessTypeId="+businessTypeId;
    url+="&PriceFactorId="+priceFactorId+"&PriceFactorId2="+priceFactorId2+"&Memo="+escape(memo)+"&actionTag1=edmit";
    var yes=showPage(url,null,900,800,false,true,false);
    if(yes)
    {
       window.navigate('addFactorRelation.aspx');   
    }
}

//删除价格因素之间的依赖关系
var factorRelationId;
function deleteFactorRelation(o)
{
    factorRelationId=$("input[@name=factorRelationId]",$(o).parent()).val();
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         var url='../../ajax/AjaxEngine.aspx'+'?Tag=FactorRelation&BusinessTypeId='+factorRelationId;
         $.getJSON(url ,{a:'35'},window.callbackDeleteFactorRelation);
    }
}
function callbackDeleteFactorRelation(json)
{
    if (json.success == null || json.success) 
    {
        data=json;
    }
    else 
    {
        return;
    }
    if("0"==json)
    {
           $("#hidFactorRelationId").val(factorRelationId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该依赖关系正在使用,不能删除!");
        return;
    } 
}

//加载编辑数据
loadEdmitData=function()
{
    if(""!=businessTypeId)
    {
        $("#sltBusinessType").attr("value",businessTypeId)
        $("#sltPricesFactor").attr("value",priceFactorId);
        var priceFactor=$("input:checkbox[@name=cbPriceFactor]");
        var priceFactorLength=priceFactor.length;
        for(var i=0;i<priceFactorLength;i++)
        {
           if(priceFactor[i].value==passivePriceFactorId)
           {
               priceFactor[i].checked=true;
               break; 
           }
        }
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



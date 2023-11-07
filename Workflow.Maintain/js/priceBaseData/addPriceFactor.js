// JScript 文件
/*
//名    称: addPriceFactor
//功能概要: 价格因素操作JS
//作    者: 张晓林
//创建时间: 2009年5月6日13:36:14
//修正履历：
//修正时间:
*/


//添加价格因素数据验证
checkProcess=function()
{
    if(""==$("#txtPriceFactorName").val())
    {
        alert("名称不能为空!");
        $("#txtPriceFactorName").focus();
        return false;
    }
    if(""==$("#txtDisplayText").val())
    {
        alert("显示文本不能为空!");
        $("#txtDisplayText").focus();
        return false;
    }
    if("-1"==$("#sltIsDisplay").attr("value"))
    {
        alert("请选择是否显示!");
        $("#sltIsDisplay").focus();
        return false;
    }
    if("-1"==$("#sltUsed").attr("value"))
    {
        alert("请选择是否使用!");
        $("#sltUsed").focus();
        return false;
    } 
    if(""==$("#txtTargetTable").val())
    {
        alert("表明不能为空!");
        $("#txtTargetTable").focus();
        return false;
    }
    if(""==$("#txtTargeValueColumn").val())
    {
        alert("值不能为空!");
        $("#txtTargeValueColumn").focus();
        return false;
    }
    
    if(""==$("#txtTargetTextColumn").val())
    {
        alert("列不能为空!");
        $("#txtTargetTextColumn").focus();
        return false;
    }
}

//编辑价格因素
edmitPriceFactor=function(o)
{
    var priceFactorId=$("input[@name=priceFactorId]",$(o).parent()).val();
    var pName=$($(o).parent().parent()).find(".pName").html();
    var pText=$($(o).parent().parent()).find(".pText").html();
    var pTable=$($(o).parent().parent()).find(".pTable").html();
    var pColumn=$($(o).parent().parent()).find(".pColumn").html();
    var pTextColumn=$($(o).parent().parent()).find(".pTextColumn").html();
    var pIsDisplay=$($(o).parent().parent()).find(".pIsDisplay").html();
    var pUsed=$($(o).parent().parent()).find(".pUsed").html();
    var url="addPriceFactor.aspx?PriceFactorId="+priceFactorId+"&Name="+escape(pName);
    url+="&Text="+escape(pText)+"&Table="+escape(pTable)+"&Column="+escape(pColumn);
    url+="&TextColumn="+escape(pTextColumn)+"&IsDisplay="+escape(pIsDisplay)+"&Used="+escape(pUsed)+"&actionTag="+"edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        $("#form1").submit();
    }
}

//删除价格因素
var priceFactorId;
deletePriceFactor=function(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         priceFactorId=$("input[@name=priceFactorId]",$(o).parent()).val();
        var url='../ajax/AjaxEngine.aspx'+'?Tag=PriceFactor&BusinessTypeId='+priceFactorId;
        $.getJSON(url ,{a:'1'},callback);
    }
}
callback=function(json)
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
           $("#hidPriceFactorId").val(priceFactorId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该价格因素正在使用,不能删除!");
        return false;
    } 
}

loadEdmitData=function()
{
    if(""!=isNotDisplay)
    {
        if(isDisplayText==isNotDisplay)
        {
           $("#sltIsDisplay").attr("value",isDisplayKey);   
        }
        else if(notDisplayText==isNotDisplay)
        {
           $("#sltIsDisplay").attr("value",notDisplayKey);    
        }
    }
    if(""!=isNotUsed)
    {
        if(isUsedText==isNotUsed)
        {
           $("#sltUsed").attr("value",isUsedKey);   
        }
        else if(notUsedText==isNotUsed)
        {
           $("#sltUsed").attr("value",notUsedKey);    
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

//新增价格因素值
addPriceFactor=function()
{
    var yes=showPage("addFactorValue.aspx?Tag=1",null,900,800,false,true,false);
    if(yes)
    {
        $("#form1").submit();
    }
}
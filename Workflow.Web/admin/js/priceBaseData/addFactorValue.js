// JScript 文件
/*
//名    称: addFactorValue
//功能概要: 价格因素值JS
//作    者: 张晓林
//创建时间: 2009年5月6日13:36:14
//修正履历：
//修正时间:
*/

//添加价格因素值数据验证
checkProcess=function()
{
    if(""==$("#txtFactorValue").val())
    {
        alert("因素值不能为空!");
        $("#txtFactorValue").focus();
        return false;
    }
    if("-1"==$("#sltPriceFactor").attr("value"))
    {
        alert("请选择价格因素!");
        $("#sltPriceFactor").focus();
        return false;
    }
}

//编辑因素值
edmitFactorValue=function(o)
{
    var factorValueId=$("input[@name=factorValueId]",$(o).parent()).val();
    var priceFactorId=$("input[@name=priceFactorId]",$(o).parent()).val();
    var factorText=$($(o).parent().parent()).find(".mName").html();
    var url="addFactorValue.aspx?FactorValueId="+factorValueId+"&PriceFactorId="+priceFactorId+"&FactorText="+escape(factorText)+"&actionTag="+"edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        //window.navigate('addFactorValue.aspx');
        $("#form1").submit();
    }
}

//删除因素值
deleteFactorValue=function(o)
{
   var yes=confirm("确认删除吗?");
    if(yes)
    {
           var factorValueId=$("input[@name=factorValueId]",$(o).parent()).val();
           $("#hidFactorValueId").val(factorValueId);
           $("#hiddTag").val("delete");
           $("#form1").submit();
    }
}

//获取价格因素详情
pricePactorDetail=function(o)
{
    var priceFactorId=$("input[@name=priceFactorId]",$(o).parent().parent()).val();
    var url="priceFactorDetail.aspx?PriceFactorId="+priceFactorId;
    showPage(url,null,900,600,false,true,false);
}

loadEdmitData=function()
{
   if(0!=priceFactorId)
   {
        $("#sltPriceFactor").attr("value",priceFactorId);
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


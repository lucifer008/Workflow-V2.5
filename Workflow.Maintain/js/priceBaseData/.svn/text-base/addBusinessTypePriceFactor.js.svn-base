// JScript 文件
/*
//名    称: addBusinessTypePriceFactor JS
//功能概要: 业务类型包含的价格因素操作JS
//作    者: 张晓林
//创建时间: 2009年5月13日9:43:44
//修正履历:
//修正时间:
*/

//数据验证
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
    for(var i=0;i<priceFactorLength;i++)
    {
       if(priceFactor[i].checked)
       {
            count++;
       } 
    }
    if(0==count)
    {
        alert("至少得选择一个价格因素!");
        return false;
    }   
}

//编辑业务类型包含的价格因素
edmitBusinessTypePriceFactor=function(o)
{
    var businessTypeId=$("input[@name=businessTypeId]",$(o).parent()).val();
    var url="addBusinessTypePriceFactor.aspx?BusinessTypeId="+businessTypeId+"&actionTag1="+"edmit";
    var yes=showPage(url,null,900,800,false,true,false);
    if(yes)
    {
        window.navigate('addBusinessTypePriceFactor.aspx');
    }
}

//删除业务类型包含的价格因素
deleteBusinessTypePriceFactor=function(o)
{
    var businessTypeId=$("input[@name=businessTypeId]",$(o).parent()).val();
    var yes=confirm("确认删除吗?");
    if(yes)
    {
        $("#hiddTag").val("delete");
        $("#hidBusinessTypeId").val(businessTypeId);
        $("#form1").submit();
    }
}

//设置选择标签即选择CheckBox
function SelectedCheckBox(obj)
{
    if(!obj.disabled)
    {
	    obj.checked=!obj.checked;
	}
}
//加载编辑数据
loadEdmitData=function()
{
    if(""!=priceFactorArr)
    {
        priceFactorArr=priceFactorArr.split(',');
        $("#sltBusinessType").attr("value",businessTypeId);
        var priceFactor=$("input:checkbox[@name=cbPriceFactor]");
        var priceFactorLength=priceFactor.length;
        for(var i=0;i<priceFactorLength;i++)
        {
           for(var j=0;j<priceFactorArr.length;j++)
           {
               if(priceFactor[i].value==priceFactorArr[j])
               {
                   priceFactor[i].checked=true;
               }
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

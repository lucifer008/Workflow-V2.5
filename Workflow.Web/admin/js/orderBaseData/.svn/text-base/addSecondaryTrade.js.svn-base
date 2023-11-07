// JScript 文件
/*
//名    称：addSecondaryTrade
//功能概要: 客户子行业操作JS
//作    者: 张晓林
//创建时间: 2009年5月20日9:32:32
//修正履历:
//修正时间:
*/

//数据操作验证
function checkProcess()
{
    if("-1"==$("#sltMasterTrade").attr("value"))
    {
        alert("请选择主行业!");
        $("#sltMasterTrade").focus();
        return false;
    }
    if(""==$("#txtSecondaryTradeName").val())
    {
        alert("子行业名称不能为空!");
        $("#txtSecondaryTradeName").focus();
        return false;
    }   
}

//编辑子行业
function edmitSecondaryTrade(o)
{
    var secondaryTradeId=$("input[@name=secondaryTradeId]",$(o).parent()).val();
    var masterTradeId=$("input[@name=masterTradeId]",$(o).parent()).val();
    var secondaryTradeName=$($(o).parent().parent()).find(".mName").html();
    var url="addSecondaryTrade.aspx?SecondaryTradeId="+secondaryTradeId+"&SecondaryTradeName="+escape(secondaryTradeName)+"&MasterTradeId="+masterTradeId+"&action=edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
         $("#form1").submit();
    }
}

//删除子行业
function deleteSecondaryTrade(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
        $("#hiddTag").val("delete");
        $("#hidSecondaryId").val($("input[@name=secondaryTradeId]",$(o).parent()).val());
        $("#form1").submit();
    }
}

function LoadEdmitData()
{
    if(""!=strMasterTradeId)
    {
        $("#sltMasterTrade").attr("value",strMasterTradeId);
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

































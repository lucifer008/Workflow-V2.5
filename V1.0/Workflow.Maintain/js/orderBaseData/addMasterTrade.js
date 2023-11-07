// JScript 文件
/*
//名    称：addMasterTrade
//功能概要: 客户主行业操作JS
//作    者: 张晓林
//创建时间: 2009年5月20日9:32:32
//修正履历:
//修正时间:
*/

//数据操作验证
function checkProcess()
{
    if(""==$("#txtMasterTradeName").val())
    {
        alert("行业名称不能为空!");
        $("#txtMasterTradeName").focus();
        return false;
    }
}

//编辑主行业
function edmitMasterTrade(o)
{
    var masterTradeId=$("input[@name=masterTradeId]",$(o).parent()).val();
    var masterTradeName=$($(o).parent().parent()).find(".mName").html();
    var url="addMasterTrade.aspx?MasterTradeId="+masterTradeId+"&MasterTradeName="+escape(masterTradeName)+"&action=edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate("addMasterTrade.aspx");
    }
}

//删除主行业
var deleteMasterTradeId;
function deleteMasterTrade(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         deleteMasterTradeId=$("input[@name=masterTradeId]",$(o).parent()).val();
         var url='../ajax/AjaxEngine.aspx'+'?Tag=MasterTrade&BusinessTypeId='+deleteMasterTradeId;
         $.getJSON(url ,{a:'29'},window.checkIsUseCallBack);
    }
}
function checkIsUseCallBack(json)
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
           $("#hidMasterTradelId").val(deleteMasterTradeId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该行业正在使用,不能删除!");
        return false;
    } 
}
//新增客户子行业

function NewSecondaryTrade()
{
    var url="addSecondaryTrade.aspx?Tag=1";
    showPage(url,null,900,800,false,true,false);
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

// JScript 文件
/*
//名    称：addBranchShop
//功能概要: 分店信息维护JS
//作    者: 张晓林
//创建时间: 2009年6月11日11:30:16
//修正履历:
//修正时间:
*/

//分店信息操作数据验证
function checkProcess()
{
    if("-1"==$("#sltCompany").attr("value"))
    {
        alert("请选择公司所属的公司!");
        $("#sltCompany").focus();
        return false;
    }
    if(""==$("#txtBranchShopName").val())
    {
        alert("分店名称不能为空!");
        $("#txtBranchShopName").focus();
        return false;
    }
}

//编辑分店信息
function edmitBranchShop(o)
{
    var branchShopId=$("input[@name=branchShopId]",$(o).parent()).val();
    var branchShopName=$($(o).parent().parent()).find(".branchShopName").html();
    var memo=$($(o).parent().parent()).find(".memo").html();
    var companyId=$("input[@name=companyId]",$(o).parent()).val();
    var url="addBranchShop.aspx?BranchShopId="+branchShopId+"&BranchShopName="+escape(branchShopName)+"&Memo="+escape(memo);
        url+="&CompanyId="+companyId+"&action=edmit";
     var yes=showPage(url,null,900,800,false,true,false);
    if(yes)
    {
        window.navigate("addBranchShop.aspx");
    }
}

//删除分店信息
function deleteBranchShop(o)
{
    var branchShopId=$("input[@name=branchShopId]",$(o).parent()).val();
    $("#hidId").val(branchShopId);
    $("#hiddTag").val("delete");
    $("#form1").submit(); 
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
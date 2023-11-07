// JScript 文件
/*
//名    称：addMemberCardLevel
//功能概要: 会员卡级别操作JS
//作    者: 张晓林
//创建时间: 2009年5月23日10:01:30
//修正履历:
//修正时间:
*/

//客户级别操作数据验证
function checkProcess()
{
    if(""==$("#txtMemberCardLevelName").val())
    {
        alert("名称不能为空!");
        return false;
    }
}

//编辑客户级别
function edmitMemberCardLevel(o)
{
    var memberCardLevelId=$("input[@name=memberCardLevelId]",$(o).parent()).val();
    var memberCardLevelName=$($(o).parent().parent()).find(".mName").html();
    var url="addMemberCardLevel.aspx?MemberCardLevelId="+memberCardLevelId+"&MemberCardLevelName="+escape(memberCardLevelName)+"&action=edmit";
    var yes=showPage(url,null,900,600,false,true,false);
    if(yes)
    {
        window.navigate("addMemberCardLevel.aspx");
    }
}

//删除客户级别
var delMemberCardLevelId;
function deleteMemberCardLevel(o)
{
    var yes=confirm("确认删除吗?");
    if(yes)
    {
         delMemberCardLevelId=$("input[@name=memberCardLevelId]",$(o).parent()).val();
         var url='../../ajax/AjaxEngine.aspx'+'?Tag=MemberCardLevel&BusinessTypeId='+delMemberCardLevelId;
         $.getJSON(url ,{a:'35'},window.checkIsUseCallBack);
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
           $("#hidMemberCardLevelId").val(delMemberCardLevelId);
           $("#hiddTag").val("delete");
           $("#form1").submit();      
    }
    else
    {
        alert("该级别正在使用,不能删除!");
        return false;
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
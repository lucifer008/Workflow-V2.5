// JScript 文件
/*
    名    称: permissionGroup
    功能概要: 权限组操作Js
    作    者: 张晓林
    修正履历:
    修正时间:
*/

// 功能: 添加权限组数据验证
// 作者: 张晓林
// 日期: 2009年5月15日 
function checkData()
{
    if(""==$("#txtName").val())
    {
        alert("权限组名称不能为空!");
        $("#txtName").focus();
        return false;
    }
    return true;
}

// 功能: 编辑权限组
// 作者: 张晓林
// 日期: 2009年5月15日 
function edmitPermissionGroup(o)
{
    var permissonGroupId=$("input[@name=permissionGroupId]",$(o).parent()).val();
    var name=$($(o).parent().parent()).find(".Name").html();
    var memo=$($(o).parent().parent()).find(".Memo").html();
    var url="NewPermissionGroup.aspx?PermissionGroupId="+permissonGroupId+"&Memo="+escape(memo)+"&Name="+escape(name);
    var yes=showPage(url,null,900,800,false,true,false);
    if(yes)
    {
        window.navigate('PermissionGroupList.aspx');
    }
}

// 功能: 删除权限组
// 作者: 张晓林
// 日期: 2009年5月15日 
var permissonGroupId;
function deletePermissionGroup(o)
{
   var yes=confirm("确认删除?");
    if(yes)
    {
        permissonGroupId=$("input[@name=permissionGroupId]",$(o).parent()).val();
        var url="../ajax/AjaxEngine.aspx?PermissionGroupId="+permissonGroupId+"&Tag=6";
         $.getJSON(url,{a:'23'},callBackCheck);
    }
}

function callBackCheck(json)
{
    if(null==json) return;
    else if("0"!=json)
    {
       alert("该权限组正在使用,不能删除!");
       return; 
    }
    $("#hidPermissionGroupId").val(permissonGroupId);
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
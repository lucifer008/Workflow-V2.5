// JScript 文件
// JScript 文件
// 名    称: Accredit.js
// 功能概要: 授权验证 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间:
//$().ready(
//    function()
//    {
//        //$($("input[@name=accreditType]")[0]).val(permissionGroupOpterateId);
//    }
//);


function inputCheck(e)
{
    if(e.keyCode==13)
    {
        if(!accreditCheck())
        {
            return false;
        }
    }
    return true;
}

//授权验证
function accreditCheck()
{
    if(""==$("input:text[@name=userName]").val())
    {
        alert("请输入用户名!");
        $("input:text[@name=userName]").focus();
        return false;
    }
    if(""==$("input:password[@name=password]").val())
    {
        alert("请输入密码!");
        $("input:password[@name=password]").focus();
        return false;
    }
    $("#btnAccredit").attr("disabled",true);
    $("#form1").submit();
}
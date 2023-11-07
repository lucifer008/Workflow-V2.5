// JScript 文件
// JScript 文件
// 名    称: Accredit.js
// 功能概要: 授权验证 Js
// 作    者: 付强
// 创建时间: 2009-1-17
// 修正履历: 
// 修正时间:
$().ready(
    function()
    {
        //$($("input[@name=accreditType]")[0]).val(window.dialogArguments);
        $($("input[@name=accreditType]")[0]).val(permissionGroupOpterateId);
    }
);


function inputCheck(e)
{
    if(e.keyCode==13)
    {
        if(!dataCheck())
        {
            return false;
        }
    }
    return true;
}
function dataCheck()
{
    if($($("input[@name='userName']")[0]).val()==null || $($("input[@name='userName']")[0]).val()=="")
    {
        alert("请输入用户名!");
        return false;
    }
    $("#form1").submit();
//    return true;
}
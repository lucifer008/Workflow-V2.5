// JScript 文件
/*
    名    称:Top
    功能概要:Top JS
    作    者:张晓林
    创建时间:2009年4月28日14:02:09
    修正履历:
    修正时间:
*/

/*修改密码*/
function changePassword()
{
    window.parent.frames["mainFrame"].navigate("UpdatePassword.aspx");
}

/*注销用户*/
function exitCurrentUser()
{
    window.parent.navigate("LoginOut.aspx");
    
}
// JScript 文件

/*
    名    称:login
    功能概要:后台登陆JS
    作    者:张晓林
    创建时间:2009年4月28日11:36:47
    修正履历:
    修正时间:
*/

$().ready(
    function()
    {
        
        $("#txtUserName").focus();
        $("#txtUserName").select();
    }
);

function inputCheck()
{
    if(null==$("#txtUserName").val() || ""==$("#txtUserName").val())
    {
        alert("请输入用户名!");
        $("#txtUserName").focus();
        $("#txtUserName").select();
        return false;
    }
    checkLogin();
}

    
function login(e)
{
    if(13==e.keyCode)
    {
        if(null==$("#txtUserName").val() || ""==$("#txtUserName").val())
        {
            alert("请输入用户名!");
            $("#txtUserName").focus();
            $("#txtUserName").select();
            return;
        }
        checkLogin();
    }
}

function checkLogin()
{
    var userName=$("#txtUserName").val();
    var password=$("#txtPassword").val();
    var branchShopId=$("#sltBranchShop").attr("value");
    //var ip=<%= Request.ServerVariables("REMOTE_ADDR") %>;
    var url='ajax/AjaxEngine.aspx'+'?ip='+ ip +'&userName='+userName+'&password='+password+'&branchShopId='+branchShopId;
    $.getJSON(url ,{a:'16'},window.loginCallBack);
}

function loginCallBack(json)
{
    if (json.success == null || json.success) 
    {
        data=json;
    }
    else 
    {
        return;
    }
    switch(parseInt(data.LoginSuccess))
    {
        case 1:
            $("#txtLoginResult").text("用户名或密码错误");
            break;
        case 2:
            window.navigate('index.html');
            $("#txtLoginResult").text("该用户已在别处登陆");
            //window.navigate('Login.aspx');  
            break;
        case 3:
            window.navigate('index.html');    
            break;
    }
}

function clearTip(obj)
{
    $("#txtLoginResult").text("");
    $(obj).select();
}
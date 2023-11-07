// JScript 文件

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
    var url='ajax/AjaxEngine.aspx'+'?userName='+userName+'&password='+password+'&branchShopId='+branchShopId;
    $.getJSON(url ,{a:'19'},window.loginCallBack);
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
    switch(parseInt(data))
    {
        case 1:
            $("#txtLoginResult").text("用户名或密码错误");
            break;
        case 2:
            $("#txtLoginResult").text("该用户没有登陆");
            break;
        case 3:
            window.parent.navigate('index.html');    
            break;
    }
}

function clearTip(obj)
{
    $("#txtLoginResult").text("");
    $(obj).select();

}


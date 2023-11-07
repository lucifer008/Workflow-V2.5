// JScript 文件
///名    称:login
///功能概要:登陆JS
///作    者:
///创建时间:
///修正时间:
///修正履历:


///名    称:
///功能概要:页面载入加载
///作    者:
///创建时间:
///修正时间:
///修正履历:
$().ready(
    function()
    {
        $("#txtUserName").focus();
        $("#txtUserName").select();
        cssBind();
    }
);

///名    称:inputCheck
///功能概要:登陆验证
///作    者:
///创建时间:
///修正时间:
///修正履历:
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


///名    称:login
///功能概要:回车提交验证
///作    者:
///创建时间:
///修正时间:
///修正履历:    
document.onkeydown=login;
function login(e)
{
    var e=window.event||arguments[0];
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
    var clientMac=$("#txtMACAddr").val();
    var branchShopId=$("#sltBranchShop").attr("value");
    //var ip=<%= Request.ServerVariables("REMOTE_ADDR") %>;
    var url='ajax/AjaxEngine.aspx'+'?ip='+ ip +'&userName='+userName+'&password='+password+'&branchShopId='+branchShopId+"&clientMac="+clientMac;
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
        case -1:
             alert("该用户不能在此计算机登陆!请检查权限");
            break;
        case 1:
            $("#txtLoginResult").text("用户名或密码错误");
            break;
        case 2:
            $("#txtLoginResult").text("该用户已在别处登陆");
            break;
        case 3:
            //window.navigate('index.html');    //FireFox下不支持
            //$().load("index.html");
            window.location.href="index.html";//IE与FireFox下都支持
            break;
    }
}

function clearTip(obj)
{
    $("#txtLoginResult").text("");
    $(obj).select();
}

///名    称:cssBind
///功能概要:设置样式
///作    者:张晓林
///创建时间:2009年9月2日13:36:15
///修正时间:
///修正履历:
function cssBind()
{
    //Div原来的的样式
    //style="position:relative;text-align:center;left:expression(document.body.clientWidth/2-this.offsetWidth/2);top:200px;font-size: 12px;"
    var leftLength=$(document.body).attr("clientWidth")/2-$(document.body).attr("offsetWidth")/2;
    $("#container").css("position","relative");
    $("#container").css("text-align","center");
    $("#container").css("left",leftLength);
    $("#container").css("top",200);
    $("#container").css("right",-400);
    $("#container").css("font-size",12);
    
    //table原来样式
    //style=" border:solid 1px #000000; text-align:center;" width="350px" 
    $("table").css("boder","solid 1px #000000")  
    $("table").css("text-align","center");
    $("table").css("width",350);  
    
    //body
    //原来的样式
    $("body").css("background-color","#ffffff");
}
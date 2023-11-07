// JScript 文件

// JScript 文件


function checkLogin()
{
   
    var password=$("#txtPassword").val();
    if(password=="")
    {
        return false;
    }
    var branchShopId=$("#sltBranchShop").attr("value");
    var url='ajax/AjaxEngine.aspx'+'?password='+password;
    $.getJSON(url ,{a:'18'},window.loginCallBack);
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
    if(data==1)
    {
        $("#txtLoginResult").text("旧密码错误");
        $("#txtPassword").val("")
        $("#txtPassword").focus();    
    }
    else
    {
        $("#txtLoginResult").text(" ");
    }
    
}
 


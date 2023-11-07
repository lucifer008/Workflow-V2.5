
// JScript 文件
// 名    称: logoutmembercard.js
// 功能概要: 会员卡注销 Js
// 作    者: 张晓林
// 创建时间: 2008-11-17
// 修正履历: 
// 修正时间:

function SelectId(id)
{
    $("#checkTag").val("T")        
    $("#searchTag").val(id);        
    $("#form1").submit();//document.form1.submit();
} 
    
//检索客户端验证(注销)
function dataValidateSearchLogOut()
{
    if(""==$("#identityCardNo").val() && ""==$("#txtMemberCardNo").val())
    {
       alert(MESSAGE_EMPTY+"查询条件");
       $("#txtMemberCardNo").focus(); 
       return false; 
    }

   if(""!=$("#identityCardNo").val())
   { 
        var patrnIdentityCard = /\d{17}[\d|X]|\d{15}/;
        if(!patrnIdentityCard.exec($("#identityCardNo").val()))
        {
            alert(MESSAGE_IDCARD)
            $("#identityCardNo").focus();
            return false;
        }
    }
    return true;
}

 //注销客户端验证(注销)
function dataValidateLogOutCard()
{
     if($("#memo").val() == "")
    {
        alert(MESSAGE_CHOICE+":注销原因");
         $("#memo").focus();
        return false;
    }
    
    return true;
}
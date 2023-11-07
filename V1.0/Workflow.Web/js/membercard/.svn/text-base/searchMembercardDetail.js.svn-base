// JScript 文件
// 名    称: searchMembercardDetail.js
// 功能概要: 会员详情 Js
// 作    者: 张晓林
// 创建时间: 2009年2月11日
// 修正履历: 
// 修正时间:

/*会员卡详情查询数据验证*/
function dataValidator()
{
    if($("#txtMemberCardNo").val() == "")
    {
        alert(MESSAGE_EMPTY+":会员卡号");
        $("#txtMemberCardNo").focus();
        return false;
    }
    
    return true;
}

/*控制:回车提交 检索按钮事件*/
document.onkeydown=function(evt)
{
    evt=window.event||argument[0];
    var element=evt.srcElement||evt.target;
    if(13==evt.keyCode && "txtMemberCardNo"==element.id)
    {
        $("#Search").click(); 
        return false;
    }
}


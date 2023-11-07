// 名    称: customerList.js
// 功能概要: 客户编辑 Js
// 作    者: 
// 创建时间: 
// 修正履历: 张晓林
// 修正时间:2009年2月13日17:14:04
// 修正描述:添加用户删除提示信息


/*删除客户数据验证*/
function doCustomerId(cudtomerId)
{
    var yes=confirm("确认删除该客户吗?");
    if(yes)
    {
        $("#deleteId").attr("value",cudtomerId);
        $.getJSON("../ajax/AjaxEngine.aspx", getJSON("{a : '9',CustomerId:'"+cudtomerId+"'}"), customerIdJson);
    }          
}
//回调函数
function customerIdJson(json)
{
    if (json != "0") {
        alert("该客户已经有订单！不能删除！");
        
        return false;
    }
    else
    {
        $("#deleteTag").attr("value","delete");
        document.form1.submit();
    }
}

//功能 :编辑客户
//作者 :陈汝胤
//日期 :2009-1-17
editCustomer=function(id,tag){        
    var obj=showPage("ModifyCustomer.aspx?Id="+id+"&tag="+tag,null,950,800,false,true,false);
    if(obj) location.reload();
}

//功能 :添加客户
//作者 :陈汝胤
//日期 :2009-1-17
addCustomer=function(){
    var obj=showPage('NewCustomer.aspx?Tag=2',null,890,566,false,true,false);
    if(obj) location.reload();
}
$(document).ready(function(){
    $("#CustomerName").focus();
});
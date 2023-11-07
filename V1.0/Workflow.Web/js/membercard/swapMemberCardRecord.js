
// JScript 文件
// 名    称: swapMemberCardRecord.js
// 功能概要: 会员换卡记录统计 Js
// 作    者: 张晓林
// 创建时间: 2009年4月3日10:14:17
// 修正履历: 
// 修正时间:

/*查询数据验证*/
function dataValidetor()
{
    if(""==$("#txtFrom").val() && ""==$("#txtTo").val() && ""==$("#txtMemberCardNo").val())
    {
        alert("查询条件不能为空!")
        return false;
    }
    if(""!=$("#txtFrom").val()) && ""!=$("#txtTo").val())
    {
           if($("#txtFrom").val() ==$("#txtTo").val())
           {
                alert("起始时间和结束时间不能相同!");
                return false;
           }
           else if($("#txtFrom").val() >$("#txtTo").val())
           {
               alert("起始时间不能大于结束时间!");
               return false;
           }   
    }
    return true;
}

/*获取客户详情*/
function customerDetail(customerId)
{
    showPage('../customer/CustomerDetail.aspx?Id='+customerId, null, 800, 550, false, true);
}

function printDataValidetor(data)
{
    if(0==count)
    {
        alert("请先查询数据!");
        return false;
    }
}
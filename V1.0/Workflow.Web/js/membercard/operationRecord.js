// JScript 文件
// 名    称: operationRecord.js
// 功能概要: 会员管理 Js
// 作    者: 张晓林
// 创建时间: 2009年4月3日10:14:17
// 修正履历: 
// 修正时间:


/*会员管理记录查询数据验证*/
function dataValidetor()
{
    if(""==$("#txtFrom").val() && ""==$("#txtTo").val() && ""==$("#txtMemberCardNo").val())
    {
        alert("查询条件不能为空!")
        return false;
    }
    if(""!=$("#txtFrom").val() && ""!=$("#txtTo").val())
    {
        if($("#txtFrom").val()==$("#txtTo").val())
        {
           alert("开始时间和结束时间不能相同!");
           return false;
        }
        
        if($("#txtFrom").val()>$("#txtTo").val())
        {
           alert("开始时间不能大于结束时间!");
           return false;
        }
    } 
}


/* 会员管理记录打印数据验证*/
function dataPrintValidetor()
{
     if(0==count)
    {
        alert("请先查询数据!");
        return false;
    }
}
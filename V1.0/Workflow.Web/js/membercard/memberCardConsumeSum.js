// JScript 文件
// 名    称: memberCardConsumeSum.js
// 功能概要: 会员消费统计 Js
// 作    者: 张晓林
// 创建时间: 2009年2月11日
// 修正履历: 
// 修正时间:

//会员详情
function memberCardDetail(o)
{
    //var memberCardNo=$(o).html();
    showPage('MemberCardDetail.aspx?Id='+o, null, 950, 650, false, true);
}

//查询数据验证
function searchVaildal()
{
    if(""!=$("#txtBeginDateTime").val() && ""!=$("#txtTo").val())
    {
        if($("#txtBeginDateTime").val()==$("#txtTo").val())
        {
           alert("开始时间和结束时间不能相同!");
           return false;
        }
        
        if($("#txtBeginDateTime").val()>$("#txtTo").val())
        {
           alert("开始时间不能大于结束时间!");
           return false;
        }
    }
}

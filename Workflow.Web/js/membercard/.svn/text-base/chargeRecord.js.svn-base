
// JScript 文件
// 名    称: chargeRecord.js
// 功能概要: 会员充值记录统计 Js
// 作    者: 张晓林
// 创建时间: 2009年4月3日10:14:17
// 修正履历: 
// 修正时间:


/*查询数据验证*/
function dataValidetor()
{
    if(""!=$("#txtFrom").val() && ""!=$("#txtTo").val())
    {
        if($("#txtFrom").val()==$("#txtTo").val())
        {
            alert("开始时间和结束时间不能相同!")
            return false;
        }
        if($("#txtFrom").val()>$("#txtTo").val())
        {
            alert("开始时间不能大于结束时间!")
            return false;
        }        
    }
    return true;
}

/*获取会员详情*/
function memberCardDetil(memberCardId)
{
    showPage('MemberCardDetail.aspx?Id='+memberCardId, null, 800, 550, false, false);
}
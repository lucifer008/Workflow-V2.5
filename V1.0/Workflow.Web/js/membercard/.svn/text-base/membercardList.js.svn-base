// JScript 文件
// 名    称: membercardList.js
// 功能概要: 会员一览 Js
// 作    者: 张晓林
// 创建时间: 2009年2月11日
// 修正履历: 
// 修正时间:

function checkInput() 
{
    var beginDateValue = $("input:text[@id$=BeginDate]").attr("value");
    var endDateValue = $("input:text[@id$=EndDate]").attr("value");
    if (beginDateValue != "" && endDateValue != "" && beginDateValue > endDateValue) {
	    alert("注册日期 : 开始日期不能大于结束日期。");
	    $("input:text[@id$=BeginDate]").focus();
	    return false;
    }
    return true;
}

///
///功能概要:查看会员详情
///作者:张晓林
///创建时间:2009年2月12日
///
function selectMembercarDetail(membercardId)
{
    showPage("MemberCardDetail.aspx?Id="+membercardId,null, 950, 650, false, true);
}

///
///功能概要:编辑会员
///作者:张晓林
///创建时间:2009年2月12日
///
function EdmitMember(membercardId)
{
    var yes=showPage("NewMemberCard.aspx?Id="+membercardId,null,1000,680,false,false,false);
    if(yes=='yes')
   {
        $("#hiddOperateTag").val("edmit");
        $("#form1").submit();
   }
}

///
///功能概要:删除会员
///作者:张晓林
///创建时间:2009年2月12日
///
 function DeleteMember(membercardId)
 {
    var yes=confirm("确认删除该会员?");
    if(yes)
    {
        var url='../ajax/AjaxEngine.aspx'+'?membercardId='+membercardId;
        $.getJSON(url,{a:'22'},processJson);  
    }
 }
 //回调函数
 function processJson(json)
 {
    if(json==null)
    {
        return false;
    }
    else if(json=="0")
    {
         $("#hiddOperateTag").val("delete");
         $("#form1").submit();
    }
    else
    {
        alert("该会员已经有订单！不能删除！");
    }
 }
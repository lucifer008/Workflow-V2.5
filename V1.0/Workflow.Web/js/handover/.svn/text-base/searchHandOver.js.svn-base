
// JScript 文件
/// 功能概要: 交班查询Js
/// 创建时间：2009年3月26日9:12:20
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：

/*交班查询查询条件数据验证*/

function QueryProcess()
{
    var beginDateValue = $("#txtBeginDate").val();
	var endDateValue = $("#txtEndDate").val();
	if(""!=beginDateValue && ""!=endDateValue)
	{
	    if(beginDateValue==endDateValue)
	    {
	        alert("开始日期不能等于结束日期!");
	        return false;
	    }
	    if(beginDateValue>endDateValue)
	    {
	        alert("开始日期不能大于结束日期");
	        return false;
	    }
	}
    return true;
}

/*显示前台交班的详情*/
function displayStageHandOverDetail(handOverId)
{
    showPage('StageHandOverDetail.aspx?Tag=2&HandOverId='+handOverId,null,890,700,false,false,false);
}

/*显示收银交班的详情*/
function displayCasherHandOverDetail(handOverId)
{
    showPage('CasherHandOverDetail.aspx?Tag=2&HandOverId='+handOverId,null,890,700,false,false,false);
}
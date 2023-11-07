// JScript 文件
/*
    //名    称：achievementShoperManagerSum
    //功能概要: 店长经理绩效统计操作JS
    //作    者: 张晓林
    //创建时间: 2009年5月23日14:41:23
    //修正履历:
    //修正时间:
*/


//查询数据验证
function DataCheck()
{
    if(""==$("#txtMonthPaperDateTime").val())
    {
        alert("查询条件不能为空!");
        $("#txtMonthPaperDateTime").focus();
        return false;
    }
}

//显示(店长/经理)绩效详情
function showAchievementDetail(o)
{
    var employeeName=$($(o).parent().parent()).find(".tdEmployeeName").html();//雇员
    var employeePostion=$($(o).parent().parent()).find(".tdPositionName").html();//岗位
    var balanceMonth;
    if(""!=$("#txtMonthPaperDateTime").val())
    {
       balanceMonth= $("#txtMonthPaperDateTime").val()+"-01";
    }
    else
    {
        balanceMonth=(new Date()).toLocaleDateString();
    }
    var url="AchievementDetailByManagerOrShoper.aspx?bMonth="+escape(balanceMonth)+"&EmployeeName="+escape(employeeName)+"&EmployeePostion="+escape(employeePostion);
    //var yes=show
}
// JScript 文件
/// 文 件 名：searchOrderCountByEmployee
/// 功能概要: 按照人员统计工单量JS
/// 创建时间：2009年11月11日14:40:52
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：

$(document).ready(
function()
{
    //$("#lbPosition").attr("selectedIndex",0);
//    SearchPostionPerson();
}
);

/// 名    称; SearchPostionPerson
/// 功能概要: 根据岗位获取人员
/// 作    者: 张晓林
/// 创建时间: 2009年11月11日14:44:18
/// 修正履历:
/// 修正时间:
function SearchPostionPerson()
{
    var sltPosition=$("#sltPosition");
    if(null==sltPosition) return;
    var strSelected="0";
    for(var i=0;i<$(sltPosition)[0].length;i++)
    {
        if($(sltPosition[0][i]).attr("selected"))
        {
            strSelected=$(sltPosition[0][i]).attr("value");
        }
    }
    var url="../../ajax/AjaxEngine.aspx?PositionId="+strSelected;//sltPosition[0].value;
    
    $.getJSON(url,{a:'24'},BingEmployeeList);//provider.process);
}
function BingEmployeeList(json)
{
    if (json == null || json) 
    {
        data=json;
    }
    else 
    {
        return;
    }
    var sltEmployeeOptions=$("select[@name='employee']")[0];
    var strOption="";
    for(var i=0;i<data.EmployeeList.length;i++)
    {
        strOption+="<option value='"+ data.EmployeeList[i].Employeeid +"'>"+ data.EmployeeList[i].Name +"</option>"
    }
    $(sltEmployeeOptions).html(strOption); 
}
function clearSelectedEmployee()
{
    $("#sltEmployee").attr("selectedIndex",-1);
}

/// 名    称; getPrintDataQueryCondition
/// 功能概要: 获取输出条件
/// 作    者: 张晓林
/// 创建时间: 2009年11月16日14:49:16
/// 修正履历:
/// 修正时间:
function getPrintDataQueryCondition()
{
    //岗位
    var sltPosition=$("#sltPosition");
    if(null==sltPosition) return;
    var strSelected="岗位: ";
    for(var i=0;i<$(sltPosition)[0].length;i++)
    {
        if($(sltPosition[0][i]).attr("selected"))
        {
            if("-1"!=$(sltPosition[0][i]).attr("value"))
            {
                strSelected+=$(sltPosition[0][i]).attr("text")+" ";
            }
        }
    }
    //雇员
    if("岗位: "==strSelected) strSelected="雇员：";
    else    strSelected+=" 雇员：";
    var sltEmployee=$("#sltEmployee");
    if(null==sltEmployee) return;
    for(var i=0;i<$("#sltEmployee")[0].length;i++)
    {
        if($($("#sltEmployee")[0][i]).attr("selected"))
        {
            strSelected+=$($("#sltEmployee")[0][i]).attr("text")+" ";
        }
    }
    $("#queryString").val(strSelected);
}

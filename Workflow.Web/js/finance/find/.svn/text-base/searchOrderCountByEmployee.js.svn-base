// JScript 文件
/// 文 件 名：searchOrderCountByEmployee
/// 功能概要: 按照人员统计订单量JS
/// 创建时间：2009年11月11日14:40:52
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：

//$(document).ready(
//function()
//{
//    //$("#lbPosition").attr("selectedIndex",0);
////    SearchPostionPerson();
//}
//);

//功能: 根据岗位获取人员  
//作者: 张晓林
//日期: 2009年11月11日14:44:18
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

//功能: 取消选择项  
//作者: 张晓林
//日期: 2009年11月11日14:44:18
function clearSelectedEmployee()
{
    $("#sltEmployee").attr("selectedIndex",-1);
}


//功能: 获取输出报表的条件  
//作者: 张晓林
//日期: 2009年11月16日14:49:16
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

//功能: 获取员工参与开单量明细  
//作者: 张晓林
//日期: 2010年1月5日10:01:21
function showDetail(o){
   var employeeId=$("input[@name=employeeId]",$(o).parent().parent()).val(); 
   var positionId=$("input[@name=positionId]",$(o).parent().parent()).val();
   var beginDate=$("#txtBeginDateTime").val();
   var endDate=$("#txtTo").val();
   var url="SearchOrderCountDetail.aspx?EmployeeId="+escape(employeeId)+"&PositionId="+escape(positionId)+"&BeginDate="+escape(beginDate)+"&EndDate="+escape(endDate);
   showPage(url, null, 900, 700, false, false);
}

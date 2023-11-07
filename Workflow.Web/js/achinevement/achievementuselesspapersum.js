
// JScript 文件
/*
    //名    称：achievementuselesspapersum
    //功能概要: 员工绩效统计JS
    //作    者: 张晓林
    //创建时间: 2008-01-19
    //修正履历:
    //修正时间:
*/

//获取订单详情
function showDetail(o)
{
    var yesNotDefault="";
    var tag=$("#hidDate").val();
    var endDateTimeString=$("#txtTo").val();
    var positionName=$("#hiddPositionList").val();
    var beginDateTimeString=$("#txtBeginDateTime").val();
    var employeeName=$($("td",$(o).parent().parent())[1]).text();
    var val=$($("input[@name='EmployeeId']",$(o).parent().parent())[0]).val();
    
    if(""==$("#hidAction").val()) yesNotDefault="默认查询";
    var url="AchievementDetail.aspx?EmployeeId="+escape(val)+"&EmployeeName="+ escape(employeeName) 
        url+="&BeginDateTimeString="+escape(beginDateTimeString)+"&EndDateTimeString="+escape(endDateTimeString);
        url+="&PositionName="+escape(positionName)+"&YesNotDefault="+escape(yesNotDefault);
        url+="&Tag="+escape(tag);   
    showPage(url,null,900,800,false,false,false);
}
    
//数据验证
function checkQueryCondition()
{
    if(""!=$("#txtBeginDateTime").val() && ""!=$("#txtTo").val())
    {
       if($("#txtBeginDateTime").val()==$("#txtTo").val())
       {
           alert("开始时间和结束时间不能相同!");
          return false; 
       }
    }
   //获取人员列表
    var sltEmployeeListOptions=$("select[@name='sltEmployee']")[0];
    var strEmployeeList="";
    for(var index=0;index<sltEmployeeListOptions.length;index++)
    {
        if(sltEmployeeListOptions[index].selected && sltEmployeeListOptions[index].value!="")
        {
           strEmployeeList+=" "+$(sltEmployeeListOptions[index]).text();
        }
    }
    $("#hiddEmployeeList").val(strEmployeeList);
    
    //获取职位列表
    var sltPositionListOptions=$("select[@name='sltPosition']")[0];
    var strPositionList="";
    for(var index=0;index<sltPositionListOptions.length;index++)
    {
        if(sltPositionListOptions[index].selected && sltPositionListOptions[index].value!="")
        {
           strPositionList+=" "+$(sltPositionListOptions[index]).text();
        }
    }
    $("#hiddPositionList").val(strPositionList);
    $("#hidAction").val("True");//标记是否执行查询按扭
    $("#hidDate").val("999");
    $("#dateNavigate_hidDateType").val("999");
}
/*
//清空Select选择项
function clearPosSelected()
{
    var sltPosition=$("select[@name='sltPosition']");
    for(var i=0;i<sltPosition.length;i++)
    {
        $(sltPosition[i]).attr("selectedIndex",-1);
    }
}

function clearEmplSelected()
{
    var sltEmploy=$("select[@name='sltEmployee']");
    for(var i=0;i<sltEmploy.length;i++)
    {
        $(sltEmploy[i]).attr("selectedIndex",-1);
    }
}
*/
var data;
//按照部门绑定人员
function SearchPostionPerson()//oSelect)
{
    var sltPosition=$("select[@name='sltPosition']");
    if(null==sltPosition[0]) return;
    var url="../ajax/AjaxEngine.aspx?PositionId="+sltPosition[0].value;
    
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
    var sltEmployeeOptions=$("select[@name='sltEmployee']")[0];
    var strOption="";
    for(var i=0;i<data.EmployeeList.length;i++)
    {
        strOption+="<option value='"+ data.EmployeeList[i].Employeeid +"'>"+ data.EmployeeList[i].Name +"</option>"
    }
    $(sltEmployeeOptions).html(strOption); 
}
//清空Select选择项
function clearPosSelected()
{
    var sltPosition=$("select[@name='sltPosition']");
    for(var i=0;i<sltPosition.length;i++)
    {
        $(sltPosition[i]).attr("selectedIndex",-1);
    }
}

function clearEmplSelected()
{
    var sltEmploy=$("select[@name='sltEmployee']");
    for(var i=0;i<sltEmploy.length;i++)
    {
        $(sltEmploy[i]).attr("selectedIndex",-1);
    }
}

//通过时间获取数据
function getOrderByDate(date){
    $("#txtTo").val("");
    $("#hidAction").val("True");//标记是否执行查询按扭
    $("#txtBeginDateTime").val("");
	document.getElementById('hidDate').value=date;
	document.getElementById('actionTag').value="F";
	document.getElementById("dateNavigate_hidDateType").value=date;//给用户控件上的控件赋值
	document.getElementById('form').submit();
}
function getByDate(date){
    $("#txtTo").val("");
    $("#txtBeginDateTime").val("");
    $("#hidAction").val("True");//标记是否执行查询按扭
    $("#action").val("T");
    document.getElementById('actionTag').value="T";
	document.getElementById('hidDate').value=date;
	document.getElementById("dateNavigate_hidDateType").value=date;//给用户控件上的控件赋值
	document.getElementById('form').submit();
}
function pagerCheck(){
    $("#hidDate").val(999);
}

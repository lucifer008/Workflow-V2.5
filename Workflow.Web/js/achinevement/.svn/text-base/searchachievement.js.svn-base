
// JScript 文件
/*
    //名    称：searchAchievement
    //功能概要: 绩效查询JS
    //作    者: 张晓林
    //创建时间: 2008-01-19
    //修正履历:
    //修正时间:
*/
$(document).ready(
    function()
    {
        $("input[@name=clearPostion]").click(clearPosSelected);
    }
);


//获取订单详情
 function orderDetail(o)
{
    showPage('../order/OrderDetail.aspx?OrderNo='+o, null, 1000, 700, false, true,'status:no;');
}

//数据判断
function DataCheck()
{
    if(""!=$("#txtBeginDateTime").val() && ""!=$("#txtTo").val())
    {
        if($("#txtBeginDateTime").val()>=$("#txtTo").val())
        {
            alert("开始日期不能大于等于结束日期!");
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
}
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
    var sltPosition=$("select[@name=sltPosition]");
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
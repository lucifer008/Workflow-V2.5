// JScript 文件
// 功能概要: 收银交班Js
// 创建时间：2009年3月20日16:08:50
// 创 建 人: 张晓林
// 修改时间：
// 修改描述：


/*收银交班数据验证*/  
function SaveCashHandOver()
{
    if ($("#sleEmployee").val()==0)
    {
      alert('请选择接班人!');
      $("#sleEmployee").focus();
      return false;
    }
    var otherPeople;
    var employeeList=$("select[@name=sleEmployee]")[0];
    for(var i=0;i<employeeList.length;i++)
    {
        if(employeeList[i].value==$("#sleEmployee").val())
        {
           otherPeople=employeeList[i].text;
           break;
        }
    }
    $("#hiddHandOverOtherPeople").val(otherPeople);
    return true;
}


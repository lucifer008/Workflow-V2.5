// JScript 文件
/// 功能概要: 前台交班Js
/// 创建时间：2009年3月20日16:08:50
/// 创 建 人: 张晓林
/// 修改时间：
/// 修改描述：

//交班数据保存数据验证
function saveStageHandOver()
{
    if ($("#sleEmployee").val()==-1)
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
    $("#tagAction").val("True");
    $("#btnOk").attr("disabled",true);
    $("#MainForm").submit();
    return true;
}

//获取订单详情
 function orderDetail(o)
{
    showPage('../order/OrderDetail.aspx?OrderNo='+o, null, 1000, 700, false, true,'status:no;');
}


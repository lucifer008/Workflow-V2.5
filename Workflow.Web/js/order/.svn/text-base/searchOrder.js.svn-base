// 名    称: searchOrder.js
// 功能概要: 订单查询 Js
// 作    者: 张晓林
// 创建时间: 2009-1-21
// 修正履历: 
// 修正时间: 

/*订单查询条件数据验证*/

function CheckSumAmount()
{
    if(
        ""==$("#OrderNo").val() && ""==$("#MemberCardNo").val() && 
        ""==$("#CustomerName").val() && ""==$("#Money").val() && 
        ""==$("#txtFrom").val() && ""==$("#txtTo").val() &&
        ""==$("#txtMobile").val() && ""==$("#txtQQMSN").val() &&
        ""==$("#txtEmail").val() && ""==$("#txtIdentityNo").val()
        )
    {
        alert("查询条件不能为空!");
        return false;
    }
    
    if(""!=$("#txtFrom").val() && ""!=$("#txtTo").val())
    {
        if($("#txtFrom").val()==$("#txtTo").val())
        {
           alert("开始时间不能和结束时间相同！");
           return false;
        }
        else if($("#txtFrom").val()>$("#txtTo").val())
        {
           alert("开始时间不能大于结束时间！");
           return false
        }
    }
    if(!checkOnlyNum($("#Money"),true,10))
    {
        $("#Money").attr("value","");
        $("#Money").focus();
        return false;
    }
    $("#hidDate").val("999");
    return true;
}
function checkDataPrint()
{
  if(isExistData)
  {
        alert("请先查询数据!");
        $("#OrderNo").focus();
        return false;
  }
}
$(document).ready(function(){
    if('False'==isPrint){
        $("#OrderNo").focus();
    }
});

//功能: 日期选项卡处理
//作者: 张晓林
//日期: 2010年7月7日10:40:18
function getOrderByDate(date){
    document.getElementById('actionTag').value="F";
	document.getElementById('hidDate').value=date;
	document.getElementById("dNavigate_hidDateType").value=date;//给用户控件上的控件赋值
	document.getElementById('form1').submit();
}
function getByDate(date){
    $("#action").val("T");
    document.getElementById('actionTag').value="T";
	document.getElementById('hidDate').value=date;
	document.getElementById("dNavigate_hidDateType").value=date;//给用户控件上的控件赋值
	document.getElementById('form1').submit();
}
function pagerCheck(){
    $("#hidDate").val(999);
}
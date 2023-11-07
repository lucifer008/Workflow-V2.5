// 名    称: searchOrder.js
// 功能概要: 工单查询 Js
// 作    者: 张晓林
// 创建时间: 2009-1-21
// 修正履历: 
// 修正时间: 

/*工单查询条件数据验证*/

function CheckSumAmount()
{
    if(""==$("#OrderNo").val() && ""==$("#MemberCardNo").val() && ""==$("#CustomerName").val() && ""==$("#Money").val() && ""==$("#txtFrom").val() && ""==$("#txtTo").val())
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
    return true;
}

function checkDataPrint()
{
  if(isExistData)
  {
        alert("请先查询数据!");
        return false;
  }  
}
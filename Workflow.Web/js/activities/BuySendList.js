﻿// JScript 文件
// JScript 文件
/*
//名    称: BuySendList.js
//概    要: 优惠方案一览Js
//作    者: 张晓林
//创建时间: 2009年2月23日16:13:07
//修正履历:
//修正时间:
*/

//删除优惠方案
function DeleteBuySend(buySendId){
    var yes=confirm("确认删除吗?");
    if(yes){
        $("#hiddDeletedTag").attr("value", "delete");
        $("#hiddDeletedId").attr("value", buySendId);
        $("#hiddTag").val("True");
        $("#form1").submit();
    }
}
//编辑优惠方案
function EdmitBuySend(buySendId,baseBusinessTypeId){
   var url="AddBuySend.aspx?&buySendId="+buySendId;
   var yes=showPage(url,null,1000,900,false,true,false);
   if(yes){
        $("#hiddTag").val("True");
        $("#form1").submit();
   }
}


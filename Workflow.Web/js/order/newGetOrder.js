// JScript 文件
//功能概要: 上门取活JS
//作    者：张晓林
//创建时间: 2009年12月8日15:57:35
//修正履历:
//修正时间:
 //数据验证(取活)
 function dataValidateNewWork()
 {
    if($("#TakeWorkNo").val() == "")
    {
        alert(MESSAGE_EMPTY+":取活订单号");
        return false;
    }
    
    if($("#CustomerName").val() == "")
    {
        alert(MESSAGE_EMPTY+":客户名称");
        return false;
    }
    
    if($("#Address").val() == "")
    {
        alert(MESSAGE_EMPTY+":客户地址");
        return false;
    }
    
    if($("#LinkMan").val() == "")
    {
        alert(MESSAGE_EMPTY+":联系人");
        return false;
    }
    
    var patrnDevitery = $("#DeliveryMan");
    if(patrnDevitery[0].selectedIndex == 0)
    {
        alert(MESSAGE_CHOICE+":取活人");
        return false;
    }
    
    if($("#txtFrom").val() == "")
    {
        alert(MESSAGE_EMPTY+":取活时间");
        return false;
    }        
   
    return true;
 }
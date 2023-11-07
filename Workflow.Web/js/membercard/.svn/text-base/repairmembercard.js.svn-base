
// JScript 文件
// 名    称: repairmembercard.js
// 功能概要: 会员卡恢复 Js
// 作    者: 张晓林
// 创建时间: 2008-11-17
// 修正履历: 
// 修正时间:

function selectId(id)
{
    $("#checkTag").val("T")        
    $("#OldMemberCardId").val(id);
    $("#form1").submit();
}    

///验证卡号是否已经存在
///
function doMemberCardNO()
{
	var memberCardNo=$("#newMemberCardNo").val();
	var customerId=$("#hiddenCustomerId").val();		
	var url='../ajax/AjaxEngine.aspx'+'?MemberCardNo='+memberCardNo+'&CustomerId='+customerId;
	$.getJSON(url ,{a:'8'},memberCardJson);
}
function memberCardJson(json)
{
	if($("#newMemberCardNo").val()=="")
	{
		return true;
	}
    if (json != "0") {
        $("#newMemberCardNo").val("");
        alert("该卡号已存在！请重新输入！");
         $("#newMemberCardNo").focus();
        return false;
    }
    return true;
}

//补卡客户端验证(补卡)
function dataValidateRepairCard()
{
    if($("#newMemberCardNo").val() == "")
    {
        alert(MESSAGE_EMPTY+":新卡号");
        $("#newMemberCardNo").focus();
        return false;
    }        
    return true;        
}
      
//检索客户端验证(补卡)
function dataValidateSearchRepair()
{
    if(""==$("#identityCardNo").val() && ""==$("#txtMemberCardNo").val())
    {
       alert(MESSAGE_EMPTY+"查询条件");
       return false; 
    }
    
   if(""!=$("#identityCardNo").val())
   { 
        var patrnIdentityCard = /\d{17}[\d|X]|\d{15}/;
        if(!patrnIdentityCard.exec($("#identityCardNo").val()))
        {
            alert(MESSAGE_IDCARD)
            $("#identityCardNo").focus();
            return false;
        }
    }   
    return true;
 }   

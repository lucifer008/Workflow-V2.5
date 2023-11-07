
// JScript 文件
// 名    称: reportLossMembercard.js
// 功能概要: 会员管理--恢复/挂失 Js
// 作    者: 张晓林
// 创建时间: 2008-11-17
// 修正履历: 
// 修正时间:

//检索客户端验证(挂失)
function dataValidateSearchReportLoss()
{
    if(""==$("#identityCardNo").val() && ""==$("#txtMemberCardNo").val())
    {
       alert(MESSAGE_EMPTY+"查询条件");
       return false; 
    }
//            if($("#identityCardNo").val() == "")
//            {
//                alert(MESSAGE_EMPTY+":身份证号码");
//                $("#identityCardNo").attr("value", "");
//                $("#identityCardNo").focus();
//                return false;
//            }
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

function SelectId(id)
{		
    $("#passWord").val("");
    $("#reportLessName").val("");
    if($("#reportLessMode")[0]!=null)
    {
	    $("#reportLessMode")[0].selectedIndex=0;
    }
    $("#telNo").val("");

    $("#checkTag").val("T")
    $("#searchTag").val(id);

    $("#form1").submit();
}
	
//挂失客户端验证(挂失)
function dataValidateReportLossCard()
{
    if($("#passWord").val() == "")
    {
        alert(MESSAGE_EMPTY+":卡密码");
        $("#passWord").focus();
        return false;
    }

    if($("#passWordAfftirm").val()=="")
    {
	    alert(MESSAGE_EMPTY+":确认密码");
        $("#passWordAfftirm").focus();
        return false;
    }

    if($("#passWord").val()!=$("#passWordAfftirm").val())
    {
	    alert("确认密码必须和原卡密码一致!");
        $("#passWordAfftirm").focus();
        $("#passWordAfftirm").attr("value","");
        return false;
    }

    if($("#reportLessName").val() == "")
    {
        alert(MESSAGE_EMPTY+":挂失人");
        $("#reportLessName").focus();
        return false;
    }
                
    var reportlessmode = $("#reportLessMode");
    if(reportlessmode[0].selectedIndex == 0)
    {
        alert(MESSAGE_CHOICE+":挂失方式");
        $("#reportLessMode").focus();
        return false;
    }

    if($("#telNo").val() == "")
    {
        alert(MESSAGE_EMPTY+":联系电话");
        $("#telNo").focus();
        return false;
    }
    else
    {
	    var objTel=$("#telNo").val();
	    if(isNaN(objTel))
	    {
		    alert("不存在这样的电话号码!");
		    $("#telNo").attr("value", "");
		    $("#telNo").focus();
		    return false;
	    }
	    else if($("#telNo").val().length<7)
	    {
		    alert("不存在这样的电话号码!");
		    $("#telNo").attr("value", "");
		    $("#telNo").focus();
		    return false;
	    }
	    else if($("#telNo").val().length>12)
	    {
		    alert("不存在这样的电话号码!");
		    $("#telNo").attr("value", "");
		    $("#telNo").focus();
		    return false;
	    }
	    return true;
}

var patrnTelNo = /^\d+(\.d+)?$/;
if(!patrnTelNo.exec($("#telNo").val()))
{
    alert(MESSAGE_NUMERAL);
    $("#telNo").focus();
    return false;
}

return true;
}
    
                
       
               


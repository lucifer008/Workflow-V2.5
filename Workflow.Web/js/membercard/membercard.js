
// JScript 文件
// 名    称: memberCard.js
// 功能概要: 会员卡发卡 Js
// 作    者: 张晓林
// 创建时间: 2008-11-17
// 修正履历: 
// 修正时间:
$(document).ready(function() {							//所属行业
		disabledSelectOption("#trade");
	});   

///名    称:selectCustomer
///功能概要:获取选择客户的信息，并绑定选择的客户信息
///作    者:
///创建时间:
///修正履历:
///修正时间:   
function selectCustomer(objCustomer)
{
	if(objCustomer==null) return;
	$("#customerId").attr("value",objCustomer.Id);
	$("#customerName").attr("value",objCustomer.Name);
	//$("#linkMan").val(objCustomer.Name);
	//所属行业
	var select= $("#trade");							
	for(var i=0;i<select[0].options.length;i++)
	{
	  if (select[0].options[i].value==objCustomer.TradeId)
	  {
		$(select[0].options[i]).attr("selected","selected");
	  }
	}
	//客户级别
	var customerLevel = $("#customerLevel");				
	for(var j = 0; j < customerLevel[0].options.length; j++)
	{
		if(customerLevel[0].options[j].value == objCustomer.CustomerLevelId)
		{
			$(customerLevel[0].options[j]).attr("selected","selected");
		}
	}
   
  // 客户类型
 var customerType=$("#dropListCustomerType");
    for(var j=0;j<customerType[0].options.length;j++)
    {
       if(customerType[0].options[j].text==objCustomer.CustomerType)
       {
           $(customerType[0].options[j]).attr("selected","selected");
       }
    } 
  var cbPaymentType=$("#cbPaymentType"); 
   for(var j=0;j<cbPaymentType[0].options.length;j++)
   {
        if(cbPaymentType[0].options[j].text==objCustomer.PaymentType)
        {
           $(cbPaymentType[0].options[j]).attr("selected","selected");
        }
   }
	$("#simpleName").attr("value", objCustomer.SimpleName);	//简拼
	$("#telNo").attr("value",objCustomer.TelNo);			//客户联系电话
	$("#address").attr("value",objCustomer.Address);		//通讯地址
	$("#needTicket").attr("checked",objCustomer.NeedTicket);//是否需要发票
	$("#memo").attr("value",objCustomer.Memo);	//客户说明
	$("#hiddCustomerValidateStatus").attr("value",objCustomer.ValidateStatus);//确认状态
	//document.getElementById("tdPayMoney").innerText=objCustomer.PaymentType;			//客户说明
	//$("#tdPayMoney").innerHTML=objCustomer.PaymentType;//支付方式
	//document.getElementById("tdPayMoney").innerHTML=objCustomer.CustomerType;//客户类型
	//document.getElementById("cbPaymentType").innerHTML=objCustomer.PaymentType;//付款方式
	
}

///名    称:doProcess
///功能概要:验证卡号是否已经存在
///作    者:
///创建时间:
///修正履历:
///修正时间:        
function doProcess()
{
    var url='../ajax/AjaxEngine.aspx'+'?MemberCardNo='+$("#memberCardNo").val()+'&CustomerId='+$("#customerId").val();
    $.getJSON(url,{a:'8'},processJson);
}
function processJson(json)
{
	if (json != "0") {
		$("#memberCardNo").val("");
		$("#memberCardNo").focus();
		alert("该卡号已存在！请重新输入！");
	}
} 
                                  
function tradeAttribute(membercardId)
{
	var tradeSelect = $("#trade");
	for(var i=0;i<tradeSelect[0].options.length;i++)
	{
		if (tradeSelect[0].options[i].value == "0")
		{
			 $(tradeSelect[0].options[i]).attr("disabled","disabled");
		}
	}
	//显示关闭按钮
	if(membercardId!=0)
	{
	    $("#btnClose").show();
	    $("#memberCardNo").attr("readonly","readonly");;
	}
 }
 
///名    称:OpenCustomer
///功能概要:选择客户
///作    者:
///创建时间:
///修正履历:
///修正时间:
function OpenCustomer()
{		
	showPage("../customer/SelectCustomer.aspx?customerName="+$("#customerName").val(), null, 900,600, false, false);
}

function checkInput() {
	var beginDateValue = $("input:text[@id$=BeginDate]").attr("value");
	var endDateValue = $("input:text[@id$=EndDate]").attr("value");
	if (beginDateValue != "" && endDateValue != "" && beginDateValue > endDateValue) {
		alert("注册日期 : 开始日期不能大于结束日期。");
		$("input:text[@id$=BeginDate]").focus();
		return false;
	}
	return true;
}

function arrear()
{
    if($("#cbPaymentType").attr("value")==payType)
    {
        var isAdd=false;
        switch(position)
        {
            case manager:
            isAdd=true;
            break;
            default:
            isAdd=false;
            break;
        }
        if(!isAdd){
            var returnValue=accredit();
            if(returnValue!='true')
            {
                alert("对不起！该客户没有记账权限!");
                $("#cbPaymentType").attr("value",1);
            }
        }
    }
    
}

///名    称:accredit(t)
///功能概要:权限验证
///作    者:
///创建时间:
///修正履历:
///修正时间:
function accredit()
{
    var url="../finance/Accredit.aspx?AccreditTypeKey="+escape(accreditTypeKey)+"&AccreditTypeText="+escape(accreditTypeText)+"&AccreditTypeId="+escape(accreditTypeId);
    return showPage(url,null,280,500,false,true,false,false);
    //return window.showModalDialog('../finance/Accredit.aspx?AccreditType='+escape(accreditType),null,'dialogHeigth:200px;dialogWidth:280px;status:no');
}

///名    称:dataValidateNewMemberCard
///功能概要:发卡数据验证
///作    者:
///创建时间:
///修正履历:
///修正时间:
function dataValidateNewMemberCard()
{
    if($("#customerName").val() == "")
    {
        alert(MESSAGE_CHOICE+":客户名称");
        //$("#customerName").focus();
        $("#Button1").focus();
        return false;
    }

    var trade = $("#trade")
    if(trade[0].selectedIndex == 0)
    {
        alert(MESSAGE_CHOICE+":所属行业");
        $("#trade").focus();
        return false;
    }

    var customerType=$("#dropListCustomerType");
    if(customerType[0].selectedIndex == 0)
    {
       alert(MESSAGE_CHOICE+":客户类型");
        $("#dropListCustomerType").focus();
        return false;
    }

    var customerlevel = $("#customerLevel");
    if(customerlevel[0].selectedIndex == 0)        
    {
        alert(MESSAGE_CHOICE+":客户级别");
        $("#customerLevel").focus();
        return false;
    }

    if($("#linkMan").val() == "")
    {
        alert(MESSAGE_EMPTY+":持卡人");
        $("#linkMan").focus();
        return false;
    }

    if($("#identityCard").val() == "")
    {
        alert(MESSAGE_EMPTY+":身份证号");
        $("#identityCard").attr("value", "");
        $("#identityCard").focus();
        return false;
    }
    if(!$("#cbCredentials").attr("checked"))//证件为身份证号
    {
        var patrnIdentityCard = /\d{17}[\d|X]|\d{15}/;
        if(!patrnIdentityCard.exec($("#identityCard").val()))
        {
            alert(MESSAGE_IDCARD)
            $("#identityCard").focus();
            return false; 
        }
    }else{
       var identityCardNo=$("#identityCard").val();
       if(identityCardNo.length<7 || identityCardNo.length>8)
       {
            alert("请输入正确的证件格式!");
            $("#identityCard").focus();
            return false;
       } 
    }
    if($("#age").val() != "")
    {
        var patrnAge = /^[0-9]{2}$/;
        if(!patrnAge.exec($("#age").val()))
        {
            alert(MESSAGE_NUMERAL+":年龄");
            $("#age").focus();
            return false;
        }
    }

    if($("#txtFrom").val() == "")
    {
        alert(MESSAGE_CHOICE+":会籍起始时间");
        $("#btnFrom").focus();
        return false;
    }
    if($("#txtTo").val() == "")
    {
        alert(MESSAGE_CHOICE+":会籍到期时间");
        $("#txtTo").focus();
        return false;
    }

    if($("#txtFrom").val()!="" && ""!=$("#txtTo").val())
    {
	    var StartDate=$("#txtFrom").attr("value");
	    var EndDate=$("#txtTo").attr("value");
	    if(StartDate>EndDate)
	    {
		    alert("会籍起始日期 不能大于 会籍到期日期!");
		    $("#btnFrom").focus();
		    return false;
	    }
    }

    if($("#memberCardNo").val() == "")
    {
        alert(MESSAGE_EMPTY+":会员卡号");
        $("#memberCardNo").focus();
        return false;
    }

    var membercardlevel = $("#memberCardLevel");
    if(membercardlevel[0].selectedIndex == 0)
    {
        alert(MESSAGE_CHOICE+":卡级别");
        $("#memberCardLevel").focus();
        return false;
    }           
    return true;
}



///名    称:CheckFastnessTelephone
///功能概要:验证固定电话是否合法
///作    者:
///创建时间:
///修正履历:
///修正时间:
function CheckFastnessTelephone(obj)
{
    if(obj.value=="")
    {
	    return true;
    }

    if(isNaN(obj.value))
    {
	    alert("不存在这样的电话号码!");
	    obj.value="";
	    obj.focus();
	    return false;
    }
    else if(obj.value.length<7)
    {
	    alert("不存在这样的电话号码!");
	    obj.value="";
	    obj.focus();
	    return false;
    }
    else if(obj.value.length>12)
    {
	    alert("不存在这样的电话号码!");
	    obj.value="";
	    obj.focus();
	    return false;
    }
    return true;
}

///名    称:CheckMobileNo
///功能概要:验证手机号码是否合法
///作    者:
///创建时间:
///修正履历:
///修正时间:
function CheckMobileNo(obj)
{
    var objValue=obj.value;
    if(""==objValue)
	    return true;
    if(objValue.length!=11)
    {	
	    alert("这个手机号不存在！");
	    obj.focus();
	    obj.value="";
	    return false;
    }
    else if(isNaN(objValue))
    {	
	    alert("这个手机号不存在！");
	    obj.focus();
	    obj.value="";
	    return false;
    }
    return true;
}
  
///名    称:CheckEmail
///功能概要:验证Email是否合法
///作    者:
///创建时间:
///修正履历:
///修正时间:
function CheckEmail(email)
{
    var emailValue=email.value;
    var   re=/^[\w.-]+@([0-9a-z][\w-]+\.)+[a-z]{2,3}$/i;   
			     //或   var   re=new   RegExp("^[\\w.-]+@([0-9a-z][\\w-]+\\.)+[a-z]{2,3}$","i");   
    if(emailValue=="")
    {
	    return true;
    }
    if(!re.test(emailValue))   
    {   
      alert("Email地址格式不正确!");
      email.focus();   
      return   false;   
    }
    return true;   
} 
 
document.onkeydown=inputKeyCheck;
function inputKeyCheck(e){
var e=e|| event;
if(e.keyCode==27)
    window.close();
}

///名    称:selectLabelChange
///功能概要:点击标签选中CheckBox
///作    者:张晓林
///创建时间:2009年8月28日15:57:53
///修正履历:
///修正时间:
function selectLabelChange()
{
    $("#cbCredentials").attr("checked",!$("#cbCredentials").attr("checked"));
}   
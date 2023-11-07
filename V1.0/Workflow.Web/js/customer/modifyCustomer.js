// 名    称: modifyCustomer.js
// 功能概要: 客户维护 Js
// 作    者: 
// 创建时间: 
// 修正履历: 
// 修正时间:

$(document).ready(function() {
		disabledSelectOption("Trade");
    });
    
 var patrnTelNo = /^(-?\d+)(\.\d+)?$/;        
 //数据验证(取活)
 function dataValidateNewWork()
 {
    if($("#TakeWorkNo").val() == "")
    {
        alert(MESSAGE_EMPTY+":取活工单号");
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
     
 //新增客户
 function dataValidateNewCustomer()
 {
    var patrnDataNumber = /^\d+(\.d+)?$/;
    if($("#CustomerName").val() == "")
    {
        alert(MESSAGE_EMPTY+":客户名称");
        $("#CustomerName").focus();
        return false;
    }
    
    var trade = $("#Trade");
    if(trade[0].selectedIndex == 0)
    {
        alert(MESSAGE_CHOICE+":所属行业");
        $("#Trade").focus();
        return false;
    }

    var customerlevel = $("#customerLevel");
    var customertype = $("#CustomerType");
    if(customertype[0].selectedIndex == 0)
    {
        
        $("#CustomerType").focus();
        alert(MESSAGE_CHOICE+":客户类型");
        return false;
    }
    
    var dropDownValue=$("#PayType").val();
    if(0==dropDownValue){
        alert("请选择:支付方式");
        $("#PayType").focus();
        return false;
    }
    return true;
 }
 
 //添加客户联系人数据验证
function dataValidatorNewLinkMan()
{
    var patrnDataNumber = /^\d+(\.d+)?$/;
    var patrnEmail = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
    if($("#Name").val() == "")
    {
        alert(MESSAGE_EMPTY+":姓名");
        $("#Name").focus();
        
        return false;
    }
    
    if($("#CompanyTelNo").val() != "")
    {
        if(!patrnDataNumber.exec($("#CompanyTelNo").val())) 
        {
            $("#CompanyTelNo").attr("value", "");
            alert(MESSAGE_NUMERAL+":单位电话");
            $("#CompanyTelNo").focus();                
            
            return false;
        }
    
    }    

    if($("#Age").val() != "" && !patrnDataNumber.exec($("#Age").val()))
    {
        $("#Age").attr("value", "");
        $("#Age").focus();
        alert(MESSAGE_NUMERAL+":年龄");
        
        return false;        
    }

    if($("#MobileNo").val() != "" && !patrnDataNumber.exec($("#MobileNo").val()))
    {
        $("#MobileNo").attr("value", "");
        $("#MobileNo").focus();
        alert(MESSAGE_NUMERAL+":移动电话");
        return false;
    }

    if($("#QQ").val() != "" && !patrnDataNumber.exec($("#QQ").val()))
    {
        $("#QQ").attr("value", "");
        $("#QQ").focus();
        alert(MESSAGE_NUMERAL+":QQ");
        
        return false;
    }

    if($("#EMAIL").val() !="" && !patrnEmail.exec($("#EMAIL").val()))
    {
        $("#EMAIL").attr("value", "");
        $("#EMAIL").focus();
        alert(MESSAGE_EMAIL);
        return false;
    }
    return true;
}
    
//功能 :修改选择支付方式的时候需要授权
//作者 :陈汝胤
//日期 :2009-1-14
function accredit(t)
{
    return window.showModalDialog('../finance/Accredit.aspx',t,'dialogHeigth:200px;dialogWidth:280px;status:no');
}

function arrear(t)
{
    if($("#PayType").val()==2)
    {
        var returnValue=accredit(t);
        if(returnValue!='true')
        {
            $("#PayType").val(1);
            alert("对不起！该客户没有记账权限!");
        }
    }
}

function deleteCustomer(deleteId)
{
    $("#deleteTag").attr("value","delete");       
    $("#deleteId").attr("value",deleteId);
    document.form1.submit();
}
function tradeAttribute()
{
    var tradeSelect = $("#Trade");
    for(var i=0;i<tradeSelect[0].options.length;i++)
    {
      if (tradeSelect[0].options[i].value == "0")
      {
        $(tradeSelect[0].options[i]).attr("disabled","disabled");
      }
    }
}
    
function SearchValidator()
{
    if($("#CustomerId").val() == "")
    {
        alert(MESSAGE_EMPTY+":客户编号");
        $("#CustomerId").focus();
        return false;
    }
    
    return true;
}

//功能 :客户的联系人编辑
//作者 :陈汝胤
//日期 :2009-1-16
//参数 : 1:联系人id 2:客户名称
editLinkMan=function(id,name){
    var obj=showPage('NewCustomerLinkMan.aspx?id='+id+'&name='+escape(name),null, 550, 450,false,true,false);
    if(obj) $('#form1').submit();
}

//功能 :客户的联系人增加
//作者 :陈汝胤
//日期 :2009-1-17
//参数 : 1:客户id 2:客户名称
addLinkMan=function(cId,name){
    var obj=showPage('NewCustomerLinkMan.aspx?cid='+cId+'&name='+escape(name),null, 890, 430,false,true,false);
    if(obj) $("#form1").submit();
}